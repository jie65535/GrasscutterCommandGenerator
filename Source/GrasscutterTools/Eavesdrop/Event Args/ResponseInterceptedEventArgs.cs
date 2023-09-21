using System;
using System.Net;
using System.Net.Http;
using System.ComponentModel;
using System.Threading.Tasks;

using Eavesdrop.Network;

namespace Eavesdrop
{
    public class ResponseInterceptedEventArgs : CancelEventArgs
    {
        private WebResponse _response;
        public WebResponse Response
        {
            get => _response;
            set
            {
                _response = value;
                if (value is HttpWebResponse httpResponse)
                {
                    CookieContainer = new CookieContainer();
                    CookieContainer.Add(httpResponse.Cookies);
                }
                else CookieContainer = null;
            }
        }

        public WebRequest Request { get; }
        public Uri Uri => Response?.ResponseUri;

        public HttpContent Content { get; set; }
        public CookieContainer CookieContainer { get; private set; }

        public string ContentType
        {
            get => Response?.ContentType;
            set
            {
                if (Response != null)
                {
                    Response.ContentType = value;
                }
            }
        }
        public WebHeaderCollection Headers
        {
            get => Response?.Headers;
            set
            {
                if (Response == null) return;
                foreach (string header in value.AllKeys)
                {
                    Response.Headers[header] = value[header];
                }
            }
        }

        public ResponseInterceptedEventArgs(WebRequest request, WebResponse response)
        {
            Request = request;
            Response = response;
        }
    }
}