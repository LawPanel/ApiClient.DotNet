using LawPanel.ApiClient.ContractResolvers;
using LawPanel.ApiClient.Models;
using Newtonsoft.Json;

namespace LawPanel.ApiClient.Extensions
{

    public static class ObjExt
    {
        private static readonly SnakeCasePropertyNamesContractResolver SnakeCasePropertyNamesContractResolver = new SnakeCasePropertyNamesContractResolver();

        public static object AsSnakeCase(this object entity)
        {
            var jsonSerializerSettings = new JsonSerializerSettings { ContractResolver = SnakeCasePropertyNamesContractResolver };
            var serializedObject = JsonConvert.SerializeObject(entity, jsonSerializerSettings);
            return JsonConvert.DeserializeObject(serializedObject); // without settings
        }
    }

}