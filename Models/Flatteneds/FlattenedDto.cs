using System.Linq;
using System.Reflection;
using LawPanel.ApiClient.Attributes;
using LawPanel.ApiClient.Constants;
using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Flatteneds
{
    public abstract class FlattenedDto<T> 
    {
        private static readonly string  EndPoint;

        public string FullEntityUrl
        {
            get
            {
                var properties = GetType().GetTypeInfo().DeclaredProperties;
                var propertyIdInfo = properties.FirstOrDefault(p=>p.Name==nameof(IIdentifiableDto.Id));
                return propertyIdInfo != null ? 
                        $"{Auth.ApiUrl}{EndPoint}/{propertyIdInfo.GetValue(this)}" :
                        $"{Auth.ApiUrl}{EndPoint}";
            }
        }

        #region Constructors

        static FlattenedDto()
        {
            #region Get the EndPoint attribute into the full DTO
            EndPoint = $"[Endpoint not defined into {typeof(T).FullName}]";
            var attributes = typeof(T).GetTypeInfo().GetCustomAttributes();
            foreach (var attribute in attributes)
            {
                if (attribute is EndPointAttribute endPointAttribute)
                {
                    EndPoint = endPointAttribute.Url;
                }
            }
            #endregion
        }

        #endregion

    }
}