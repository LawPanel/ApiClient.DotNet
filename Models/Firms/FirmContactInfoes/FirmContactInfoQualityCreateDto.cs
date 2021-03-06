﻿using System;
using System.ComponentModel.DataAnnotations;
using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Firms.FirmContactInfoes
{
    public class FirmContactInfoQualityCreateDto : Dto, IIdentifiableDto
    {
        public string   Id          { get; set; }
        public Guid     FirmId      { get; set; }

        [Display(Name = "[[[Name]]]"), Required(ErrorMessage = "[[[Name of the quality is required]]]", AllowEmptyStrings = false)]
        public string   Name        { get; set; }

        [Display(Name = "[[[Description]]]")]
        public string   Description { get; set; }

        [Display(Name = "[[[Display order]]]")]
        public int      Order       { get; set; }

        [Display(Name = "[[[This quality is default for new leads?]]]")]
        public bool     IsDefault   { get; set; }
    }
}
