﻿using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Tags
{
    public class TagDto : Dto, IIdentifiableDto
    {
        public string   Id              { get; set; }
        public string   Name            { get; set; }
        public string   ColorText       { get; set; }
        public string   ColorBackground { get; set; }
        public TagDto   Parent          { get; set; }
    }
}