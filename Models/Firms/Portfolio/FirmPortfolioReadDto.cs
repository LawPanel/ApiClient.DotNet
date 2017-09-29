﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.Registry;
using LawPanel.ApiClient.Models.SearchClass;
using LawPanel.ApiClient.Models.User;

namespace LawPanel.ApiClient.Models.Firms.Portfolio
{
    public class FirmPortfolioReadDto : Dto, IIdentifiableDto
    {
        #region Firm
        public string                   Id                      { get; set; }
        [Display(Name = "[[[Firm]]]"), Required(ErrorMessage = "[[[Firm is required]]]", AllowEmptyStrings = false)]
        public string                   FirmId                  { get; set; }
        public string                   FirmName                { get; set; }
        #endregion

        #region FirmClient
        [Display(Name = "[[[Firm client]]]")]
        public string                   FirmClientId            { get; set; }
        public string                   FirmClientName          { get; set; }
        public FirmClientDto            FirmClient              { get; set; }
        #endregion

        #region Trademark
        [Display(Name = "[[[Application number]]]"), Required(ErrorMessage = "[[[Application number is required]]]", AllowEmptyStrings = false)]
        public string                   ApplicationNumber       { get; set; }

        [Display(Name = "[[[Registration date]]]")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime?                RegistrationDate        { set; get; }

        [Display(Name = "[[[Application date]]]")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime?                ApplicationDate         { set; get; }

        [Display(Name = "[[[Expiry date]]]")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime?                ExpiryDate              { get; set; }

        [Display(Name = "[[[Mark feature]]]"), Required(ErrorMessage = "[[[Mark feature is required]]]", AllowEmptyStrings = true)]
        public string                   MarkFeature             { set; get; }

        [Display(Name = "[[[Kind mark]]]"), Required(ErrorMessage = "[[[Kind mark is required]]]", AllowEmptyStrings = true)]
        public string                   KindMark                { get; set; }

        [Display(Name = "[[[Mark text]]]"), Required(ErrorMessage = "[[[Mark text is required]]]", AllowEmptyStrings = false)]
        public string                   MarkText                { get; set; }

        [Display(Name = "[[[Classes]]]"), Required(ErrorMessage = "[[[Classes list is required]]]", AllowEmptyStrings = false)]
        public List<SearchClassDto>     Classes { get; set; }

        [Display(Name = "[[[Status]]]"), Required(ErrorMessage = "[[[Status text is required]]]", AllowEmptyStrings = false)]
        public string                   Status                  { get; set; }

        [Display(Name = "[[[Registry]]]"), Required(ErrorMessage = "[[[Registry is required]]]", AllowEmptyStrings = false)]
        public RegistryDto              Registry                { get; set; }

        #endregion

        #region User creator of registry
        public string                   UserId                  { get; set; }
        public string                   UserUserName            { get; set; }

        [Display(Name = "[[[Owner]]]")]
        public UserDto                  User                    { get; set; }
        #endregion

        public bool                     HasReminders            { get; set; }

        public bool                     HasWatchings            { get; set; }

        public string                   TrademarkUrlOnIpo       { get; set; }
        public string                   ImageUrl                { get; set; }
    }
}
