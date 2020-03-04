using LawPanel.ApiClient.Attributes;
using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.UserTypes
{
    public class UserTypeDto : Dto, IIdentifiableDto
    {
        public string   Id      { get; set; }
        [DefaultOrder(0, OrderDirection.Asc)]
        public string   Name    { get; set; }
        public int      Code    { get; set; }
    }
}
