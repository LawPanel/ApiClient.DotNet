using System;
using System.Collections.Generic;
using LawPanel.ApiClient.Attributes;
using LawPanel.ApiClient.Constants;
using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.Clients;
using LawPanel.ApiClient.Models.User;
using LawPanel.ApiClient.Models.UserInputTemplates;

namespace LawPanel.ApiClient.Models.UserInputs
{
    [EndPoint(EndPoints.userinput)]
    public class UserInputDto : Dto, IIdentifiableDto
    {
        public string                       Id                  { get; set; }
        public UserInputTemplateDto         UserInputTemplate   { get; set; }
        public ClientDto                    Client              { get; set; }
        public UserDto                      User                { get; set; }
        public string                       Notes               { get; set; }
        public DateTime                     DateTime            { get; set; }
        public List<UserInputComponentDto>  Components          { get; set; }

        public UserInputDto()
        {
            Components = new List<UserInputComponentDto>();
        }
    }
}
