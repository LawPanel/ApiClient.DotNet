﻿using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Helpers.LawPanelNewsType
{
    public class LawPanelNewsTypeReadDto : Dto, IIdentifiableDto
    {
        public string   Id      { get; set; }
        public int      Code    { get; set; }
        public string   Name    { get; set; } 
    }
}