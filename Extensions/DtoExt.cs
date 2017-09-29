using LawPanel.ApiClient.Models;
using Newtonsoft.Json;

namespace LawPanel.ApiClient.Extensions
{
    public static class DtoExt
    {
        public static string SerializeAsSnakeCase(this Dto dto)
        {
            var dtoSnaked = dto.AsSnakeCase();
            return JsonConvert.SerializeObject(dtoSnaked);
        }
    }
}