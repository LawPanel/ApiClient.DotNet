using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.ContactInfo;
using LawPanel.ApiClient.Models.Helpers;
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

        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "[[[E-mail is not valid]]]")]
        [Display(Name = "[[[Notificate at this email address]]]")]
        public string                                       NotificationsEmailAtThisAddress                     { get; set; }
        public FrequencyDto                                 NotificationsFrequency                              { get; set; } // null means "as they arrive"

        public bool                                         OptionsSalesLead                                    { get; set; }
        public bool                                         OptionsCommnentsBox                                 { get; set; }

        public string                                       TextOnTop                                           { get; set; }
        public string                                       TextOnSearchEndAndTrademarkCanBeRegistered          { get; set; }
        public string                                       TextOnSearchEndAndTrademarkCanNotBeRegistered       { get; set; }

        public bool                                         UseFixedSize                                        { get; set; }
        public int                                          Width                                               { get; set; }
        public int                                          Height                                              { get; set; }
        public decimal                                      Zoom                                                { get; set; }

        public bool                                         ShowOnlyRegisteredTrademarks                        { get; set; }

        public int                                          Threshold                                           { get; set; }

    }
}
