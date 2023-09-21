using System;
using System.Net;
using System.Net.Http;
using System.ComponentModel;

namespace Eavesdrop
{
    public class RequestInterceptedEventArgs : CancelEventArgs
    {
        private HttpWebRequest _httpRequest;

        public HttpContent Content { get; set; }

        private WebRequest _request;
        public WebRequest Request
        {
            get => _request;
            set
            {
                _request = value;
                _httpRequest = (value as HttpWebRequest);
            }
        }

        public Uri Uri => Request?.RequestUri;
        public CookieContainer CookieContainer => _httpRequest?.CookieContainer;

        public string Method
        {
            get => Request?.Method;
            set
            {
                if (Request != null)
                {
                    Request.Method = value;
                }
            }
        }
        public IWebProxy Proxy
        {
            get => Request?.Proxy;
            set
            {
                if (Request != null)
                {
                    Request.Proxy = value;
                }
            }
        }
        public string ContentType
        {
            get => Request?.ContentType;
            set
            {
                if (Request != null)
                {
                    Request.ContentType = value;
                }
            }
        }
        public WebHeaderCollection Headers
        {
            get => Request?.Headers;
            set
            {
                if (Request != null)
                {
                    Request.Headers = value;
                }
            }
        }

        public RequestInterceptedEventArgs(WebRequest request)
        {
            Request = request;
        }
    }
}