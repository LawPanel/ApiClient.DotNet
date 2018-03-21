﻿using System;

namespace LawPanel.ApiClient.Models.Watchings
{
    public class WatchingBundleDto
    {
        public string   ApplicationNumber   { get; set; }
        public string   RegistryCode        { get; set; }
        public Guid     FirmPortfolioId     { get; set; }
    }
}
