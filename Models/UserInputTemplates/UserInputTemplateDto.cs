using System;
using System.Collections.Generic;
using LawPanel.ApiClient.Attributes;
using LawPanel.ApiClient.Constants;
using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.UserInputTemplates
{
    [EndPoint(EndPoints.userinputtemplate)]
    public class UserInputTemplateDto : Dto, IIdentifiableDto
    {
        public string                               Id              { get; set; }
        public string                               Name            { get; set; }
        public List<UserInputTemplateComponentDto>  Components      { get; set; }
        public bool                                 IsBase          { get; set; }
        public Guid                                 BaseId          { get; set; }
        public bool                                 UserCanCreate   { get; set; } // True means client users can create them without firm user request

        public UserInputTemplateDto()
        {
            Components = new List<UserInputTemplateComponentDto>();
        }
    }
}
