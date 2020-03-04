using LawPanel.ApiClient.Enums;
using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.UserInputTemplates
{
    public class UserInputTemplateComponentPermissionDto : Dto, IIdentifiableDto
    {
        public string                                       Id          { get; set; }
        public UserInputTemplateComponentPermissionAction   Action      { get; set; }
        public string                                       Entity      { get; set; } // E.g.: Search, User, Client, Lead, etc.
        public string                                       EntityId    { get; set; }
    }
}