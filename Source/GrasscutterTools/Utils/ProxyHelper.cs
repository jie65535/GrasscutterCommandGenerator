/**
 *  Grasscutter Tools
 *  Copyright (C) 2023 jie65535
 *
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU Affero General Public License as published
 *  by the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU Affero General Public License for more details.
 *
 *  You should have received a copy of the GNU Affero General Public License
 *  along with this program.  If not, see <https://www.gnu.org/licenses/>.
 *
 **/

using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.Win32;
using Eavesdrop;
using System.Net;

namespace GrasscutterTools.Utils
{
    internal static class ProxyHelper
    {
        private const string TAG = "Proxy";

        static ProxyHelper()
        {
            Eavesdropper.Certifier = new Certifier("jie65535", "GrasscutterTools Root Certificate Authority");
        }

        #region - Windows API -

        [DllImport("wininet.dll")]
        private static extern bool InternetSetOption(IntPtr hInternet, int dwOption, IntPtr lpBuffer, int dwBufferLength);
        private const int INTERNET_OPTION_SETTINGS_CHANGED = 39;
        private const int INTERNET_OPTION_REFRESH = 37;

        #endregion

        #region - System Proxy -

        private const string RegKeyInternetSettings = "Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings";
        private const string RegProxyEnable = "ProxyEnable";
        private const string RegProxyServer = "ProxyServer";
        private const string RegProxyOverride = "ProxyOverride";

        private const string PassBy =
            "localhost;127.*;10.*;172.16.*;172.17.*;172.18.*;172.19.*;172.20.*;172.21.*;172.22.*;172.23.*;172.24.*;172.25.*;172.26.*;172.27.*;172.28.*;172.29.*;172.30.*;172.31.*;192.168.*";

        private static void FlushOs()
        {
            InternetSetOption(IntPtr.Zero, INTERNET_OPTION_SETTINGS_CHANGED, IntPtr.Zero, 0);
            InternetSetOption(IntPtr.Zero, INTERNET_OPTION_REFRESH, IntPtr.Zero, 0);
        }

        private static bool _isSetSystemProxy;

        private static void SetSystemProxy(int proxyPort)
        {
            using (var reg = Registry.CurrentUser.OpenSubKey(RegKeyInternetSettings, true))
            {
                reg.SetValue(RegProxyServer, $"http=127.0.0.1:{proxyPort};https=127.0.0.1:{proxyPort}");
                reg.SetValue(RegProxyOverride, PassBy);
                reg.SetValue(RegProxyEnable, 1);
            }

            _isSetSystemProxy = true;
            FlushOs();
        }

        private static void CloseSystemProxy()
        {
            if (!_isSetSystemProxy) return;
            _isSetSystemProxy = false;

            using (var reg = Registry.CurrentUser.OpenSubKey(RegKeyInternetSettings, true))
                reg.SetValue(RegProxyEnable, 0);
            FlushOs();
        }

        #endregion

        #region - GS Proxy Server -

        private const string ProxyOverrides =
            "localhost;1*;" + //" 127.*;10.*;192.168.*;" +
            "*0;*1;*2;*3;*4;*5;*6;*7;*8;*9;" +
            "*a;*b;*c;*d;*e;*f;*g;*h;*i;*j;*k;*l;*n;*o;*p;*q;*r;*s;*t;*u;*v;*w;*x;*y;*z" +
            "*a.com;*b.com;*c.com;*d.com;*f.com;*g.com;*h.com;*i.com;*j.com;*k.com;*l.com;*m.com;*p.com;*q.com;*r.com;*s.com;*t.com;*u.com;*v.com;*w.com;*x.com;*y.com;*z.com;" +
            "*ae.com;*be.com;*ce.com;*de.com;*fe.com;*ge.com;*pe.com;*te.com;*me.com;*le.com;*ve.com;" +
            "*ao.com;*bo.com;*eo.com;*go.com;*ke.com;*oo.com;*so.com;*io.com" +
            "*an.com;*cn.com;*dn.com;*gn.com;*wn.com;*dn.com;*sn.com;*un.com;*in.com";
        //"*bing*;*google*;*live.com;*office.com;*weibo*;*yahoo*;*taobao*;*go.com;*csdn.com;*msn.com;*aliyun.com;*cdn.com;";
        //"*ttvnw*;*edge*;*microsoft*;*bing*;*google*;*discordapp*;*gstatic.com;*imgur.com;*hub.*;*gitlab.com;*googleapis.com;*facebook.com;*cloudfront.net;*gvt1.com;*jquery.com;*akamai.net;*ultra-rv.com;*youtube*;*ytimg*;*ggpht*;" +
        //"*baidu*;*qq*;*sohu*;*weibo*;*163*;*360*;*iqiyi*;*youku*;*bilibili*;*sogou*;*taobao*;*jd*;*zhihu*;*steam*;*ea.com;*csdn*;*.msn.*;*aliyun*;*cdn*;" +
        //"*twitter.com;*instagram.com;*wikipedia.org;*yahoo*;*xvideos.com;*whatsapp.com;*live.com;*netflix.com;*office.com;*tiktok.com;*reddit.com;*discord*;*twitch*;*duckduckgo.com";

        private static string[] urls =
        {
            "hoyoverse.com",
            "mihoyo.com",
            "yuanshen.com",
        };

        private static void StartGsProxyServer(int port)
        {
            if (Eavesdropper.IsRunning) return;
            Eavesdropper.Overrides.Clear();
            Eavesdropper.Overrides.AddRange(ProxyOverrides.Split(';'));
            Eavesdropper.RequestInterceptedAsync += EavesdropperOnRequestInterceptedAsync;
            Eavesdropper.Initiate(port);
        }

        private static Task EavesdropperOnRequestInterceptedAsync(object sender, RequestInterceptedEventArgs e)
        {
            var url = e.Request.RequestUri.OriginalString;
            foreach (var mhy in urls)
            {
                var i = url.IndexOf(mhy, StringComparison.CurrentCultureIgnoreCase);
                if (i == -1) continue;
                var p = url.IndexOf('/', i + mhy.Length);
                var target = p >= 0 ? _gcDispatch + url.Substring(p) : _gcDispatch;
                e.Request = RedirectRequest(e.Request as HttpWebRequest, new Uri(target));
                Logger.I(TAG, $"Redirect to {e.Request.RequestUri}");
                return Task.CompletedTask;
            }

            Logger.I(TAG, "Direct " + e.Request.RequestUri);

            return Task.CompletedTask;
        }

        private static HttpWebRequest RedirectRequest(HttpWebRequest request, Uri newUri)
        {
            var newRequest = WebRequest.CreateHttp(newUri);
            newRequest.ProtocolVersion = request.ProtocolVersion;
            newRequest.CookieContainer = request.CookieContainer;
            newRequest.AllowAutoRedirect = request.AllowAutoRedirect;
            newRequest.KeepAlive = request.KeepAlive;
            newRequest.Method = request.Method;
            newRequest.Proxy = request.Proxy;
            foreach (var name in request.Headers.AllKeys)
            {
                switch (name.ToLower())
                {
                    case "host"             : newRequest.Host            = request.Host;            break;
                    case "accept"           : newRequest.Accept          = request.Accept;          break;
                    case "referer"          : newRequest.Referer         = request.Referer;         break;
                    case "user-agent"       : newRequest.UserAgent       = request.UserAgent;       break;
                    case "content-type"     : newRequest.ContentType     = request.ContentType;     break;
                    case "content-length"   : newRequest.ContentLength   = request.ContentLength;   break;
                    case "if-modified-since": newRequest.IfModifiedSince = request.IfModifiedSince; break;
                    case "date"             : newRequest.Date            = request.Date;            break;
                    default: newRequest.Headers[name] = request.Headers[name]; break;
                }
            }
            //newRequest.Headers = request.Headers;
            return newRequest;
        }

        private static void StopGsProxyServer()
        {
            Eavesdropper.Terminate();
        }

        #endregion

        private const int ProxyServerPort = 8146;
        private static string _gcDispatch;
        public static void StartProxy(string gcDispatch)
        {
            // Check Url format
            var _ = new Uri(gcDispatch);
            _gcDispatch = gcDispatch.TrimEnd('/');
            Logger.I(TAG, "Start Proxy, redirect to " + _gcDispatch);
            StartGsProxyServer(ProxyServerPort);
            //SetSystemProxy(ProxyServerPort);
        }

        public static void StopProxy()
        {
            Logger.I(TAG, "Stop Proxy");
            //CloseSystemProxy();
            StopGsProxyServer();
        }

        public static bool CheckAndCreateCertificate()
        {
            return Eavesdropper.Certifier.CreateTrustedRootCertificate();
        }

        public static bool DestroyCertificate()
        {
            return Eavesdropper.Certifier.DestroyTrustedRootCertificate();
        }

        public static bool IsRunning => Eavesdropper.IsRunning;
    }
}
