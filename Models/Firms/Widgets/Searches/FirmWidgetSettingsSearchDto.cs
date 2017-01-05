using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LawPanel.ApiClient.Abstractions.Base;
using LawPanel.ApiClient.Abstractions.Interfaces;
using LawPanel.ApiClient.Models.ContactInfo;
using LawPanel.ApiClient.Models.Registry;

namespace LawPanel.ApiClient.Models.Firms.Widgets.Searches
{
    public class FirmWidgetSettingsSearchDto : Dto, IIdentifiableDto
    {
        public string                                       Id                                                  { get; set; }
        public FirmDto                                      FirmDto                                             { get; set; }
        public IList<FirmWidgetSettingsSearchDomainDto>     Domains                                             { get; set; }
        public IList<RegistryDto>                           Registries                                          { get; set; }

        public bool                                         ResultsShowProbablyAvailable                        { get; set; }
        public ContactInfoDefinitionDto                     ResultsShowProbablyAvailableContactInfoDefinition   { get; set; }
        public bool                                         ResultsShowSimilarMarks                             { get; set; }
        public ContactInfoDefinitionDto                     ResultsShowSimilarMarksContactInfoDefinition        { get; set; }
        public bool                                         ResultsEmailSearchReport                            { get; set; }
        public ContactInfoDefinitionDto                     ResultsEmailSearchReportContactInfoDefinition       { get; set; }

        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "[[[E-mail is not valid]]]")]
        [Display(Name = "[[[Notificate at this email address]]]")]
        public string                                       NotificationsEmailAtThisAddress                     { get; set; }
        public FrequencyDto                                 NotificationsFrequency                              { get; set; } // null means "as they arrive"

        public bool                                         OptionsSalesLead                                    { get; set; }
        public bool                                         OptionsCommnentsBox                                 { get; set; }

        public string                                       TextOnTop                                           { get; set; }
        public string                                       TextOnSearchEnd                                     { get; set; }

    }
}
