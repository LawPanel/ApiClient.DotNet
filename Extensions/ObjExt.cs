using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

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


    public class SnakeCasePropertyNamesContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName.CamelCaseToSnakeCase();
        }
    }
}
