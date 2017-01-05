using System.IO;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace LawPanel.ApiClient.Extensions
{
    public static class HttpContentExt
    {

        private static readonly SnakeCasePropertyNamesContractResolver SnakeCasePropertyNamesContractResolver = new SnakeCasePropertyNamesContractResolver();

        public static TEntity ReadAsAsync<TEntity>(this HttpContent content)
        {
            TEntity toReturn;

            using (var stream = content.ReadAsStreamAsync().Result)
            {
                using (var streamReader = new StreamReader(stream, Encoding.GetEncoding("utf-8"))) {
                    using (var jr = new JsonTextReader(streamReader))
                    {
                        var serializer = new JsonSerializer
                        {
                            Formatting = Formatting.Indented,
                            CheckAdditionalContent = false,
                            TypeNameHandling = TypeNameHandling.Auto
                        };
                        toReturn = (TEntity) serializer.Deserialize(jr, typeof(TEntity));
                    }
                }
            }

            return toReturn;
        }

        public static TEntity ReadSnakeCaseToCamelCase<TEntity>(this HttpContent content)
        {
            TEntity toReturn;

            using (var stream = content.ReadAsStreamAsync().Result)
            {
                using (var streamReader = new StreamReader(stream, Encoding.GetEncoding("utf-8")))
                {
                    using (var jr = new JsonTextReader(streamReader))
                    {
                        var serializer = new JsonSerializer
                        {
                            Formatting = Formatting.Indented,
                            CheckAdditionalContent = false,
                            TypeNameHandling = TypeNameHandling.Auto,
                            ContractResolver = SnakeCasePropertyNamesContractResolver
                        };

                        toReturn = (TEntity) serializer.Deserialize(jr, typeof(TEntity));
                    }
                }
            }

            return toReturn;
        }
    }
}
