using System;
using System.Net;

namespace LawPanel.ApiClient.Proxy
{
    public class Proxy : IWebProxy
    {
        public ICredentials Credentials { get; set; }

        private readonly Uri _proxyUri;

        public Proxy(Uri proxyUri)
        {
            _proxyUri = proxyUri;
        }

        public Uri GetProxy(Uri destination)
        {
            return _proxyUri;
        }

        public bool IsBypassed(Uri host)
        {
            return false;
        }
    }
}
