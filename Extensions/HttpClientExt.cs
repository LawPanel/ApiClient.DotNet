using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LawPanel.ApiClient.Extensions
{
    public static class HttpClientExt
    {
        private static string ApplicationJson = "application/json";


        public static Task<HttpResponseMessage> PostAsJsonAsyncWithSnakeCase(this HttpClient client, string requestUri, object value)
        {
            var asSnakeCase = value.AsSnakeCase();
            var asSnakeCaseSerialized = JsonConvert.SerializeObject(asSnakeCase);

            var httpContent = new StringContent(asSnakeCaseSerialized, Encoding.UTF8, ApplicationJson);

            return client.PostAsync(requestUri,httpContent);
        }

        public static HttpResponseMessage PostAsJsonWithSnakeCase(this HttpClient client, string requestUri, object value)
        {
            var asSnakeCase = value.AsSnakeCase();
            var asSnakeCaseSerialized = JsonConvert.SerializeObject(asSnakeCase);

            var httpContent = new StringContent(asSnakeCaseSerialized, Encoding.UTF8, ApplicationJson);

            return client.PostAsync(requestUri, httpContent).Result;
        }

        public static Task<HttpResponseMessage> PutAsJsonAsyncWithSnakeCase(this HttpClient client, string requestUri, object value)
        {
            var asSnakeCase = value.AsSnakeCase();
            var asSnakeCaseSerialized = JsonConvert.SerializeObject(asSnakeCase);

            var httpContent = new StringContent(asSnakeCaseSerialized, Encoding.UTF8, ApplicationJson);

            return client.PutAsync(requestUri, httpContent);
        }

    }
}
