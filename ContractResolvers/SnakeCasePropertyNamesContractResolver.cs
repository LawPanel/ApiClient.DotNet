using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using LawPanel.ApiClient.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace LawPanel.ApiClient.ContractResolvers
{
    public class SnakeCasePropertyNamesContractResolver : DefaultContractResolver
    {
        static SnakeCasePropertyNamesContractResolver() { Instance = new SnakeCasePropertyNamesContractResolver(); }

        public static SnakeCasePropertyNamesContractResolver Instance { get; }

        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var properties = base.CreateProperties(type, memberSerialization);
            return properties?.OrderBy(p => p.DeclaringType.BaseTypesAndSelf().Count()).ToList();
        }


        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName.CamelCaseToSnakeCase();
        }

    }

    public static class TypeExtensions
    {
        public static IEnumerable<Type> BaseTypesAndSelf(this Type type)
        {
            while (type != null)
            {
                yield return type;
                type = type.GetTypeInfo().BaseType;
            }
        }
    }
}
