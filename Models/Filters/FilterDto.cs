﻿using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.Firms;
using LawPanel.ApiClient.Models.User;

namespace LawPanel.ApiClient.Models.Filters
{
    public class FilterDto : Dto, IIdentifiableDto
    {
        public string               Id                      { get; set; }
        public UserDto              User                    { get; set; }
        public FirmDto              Firm                    { get; set; }
        public string               EndPoint                { get; set; } // "v1/firms/firmportfolio", "v1/firms/invoices", etc.
        public string               Name                    { get; set; }
        public bool                 ItIsLastUsedWithoutSave { get; set; } // If true should be applied by default with first user call to the endpoint api
        public FilterDefinitionDto  FilterDefinition        { get; set; }
        public bool                 Applied                 { get; set; }
    }
}