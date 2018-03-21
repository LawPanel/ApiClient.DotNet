using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using LawPanel.ApiClient.Constants;
using LawPanel.ApiClient.Models.Account;

namespace LawPanel.ApiClient.Base
{
    public class HttpClientLawPanel : HttpClient
    {
        private static readonly HttpClientHandler HttpClientHandler = new HttpClientHandler();

        public HttpClientLawPanel(string apiUrl, AuthCookieModel authCookieModel) : base(HttpClientHandler)
        {
            var baseUri= new Uri(apiUrl);

            BaseAddress = baseUri;
            Timeout = TimeSpan.FromMinutes(30);

            #region Accept headers
            DefaultRequestHeaders.Accept.Clear();
            DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            DefaultRequestHeaders.ConnectionClose = true;
            #endregion

            #region Add auth cookie 
            var addressUri = new Uri(apiUrl);
            var cookieContainer = new CookieContainer();
            if (authCookieModel != null)
            {
                cookieContainer.Add(addressUri, new Cookie(Auth.CookieName, authCookieModel.Value, authCookieModel.Path, authCookieModel.Domain));
            }
            HttpClientHandler.CookieContainer = cookieContainer;
            #endregion
        }
    }
}
