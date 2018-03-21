using LawPanel.ApiClient.Extensions;
using Newtonsoft.Json.Serialization;

namespace LawPanel.ApiClient.ContractResolvers
{
    public class LowerCamelCasePropertyNamesContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName.CamelCaseToLowerCamelCase();
        }
    }
}
