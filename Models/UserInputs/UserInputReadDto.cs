using System;
using LawPanel.ApiClient.Attributes;
using LawPanel.ApiClient.Constants;
using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.Clients;
using LawPanel.ApiClient.Models.Flatteneds;
using LawPanel.ApiClient.Models.User;
using LawPanel.ApiClient.Models.UserInputTemplates;

namespace LawPanel.ApiClient.Models.UserInputs
{
    [EndPoint(EndPoints.userinput)]
    public class UserInputReadDto: Dto, IIdentifiableDto
    {
        public string                               Id                  { get; set; }
        public bool                                 Filled              { get; set; }
        public UserInputReadClientDto               Client              { get; set; }
        public UserInputReadUserInputTemplateDto    UserInputTemplate   { get; set; }
        public UserInputReadUserDto                 User                { get; set; }
        public string                               Notes               { get; set; }
        public DateTime                             DateTime            { get; set; }
    }
    

    public class UserInputReadClientDto : FlattenedDto<ClientDto> {
        public string   Id          { get; set; }
        public string   Name        { get; set; }
    }

    public class UserInputReadUserInputTemplateDto : FlattenedDto<UserInputTemplateDto>
    {
        public string   Id          { get; set; }
        public string   Name        { get; set; }
    }

    public class UserInputReadUserDto : FlattenedDto<UserDto>
    {
        public string   Id          { get; set; }
        public string   UserName    { get; set; }
    }

}
