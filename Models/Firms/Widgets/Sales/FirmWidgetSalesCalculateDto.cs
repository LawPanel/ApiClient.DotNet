﻿using System;
using System.Collections.Generic;

namespace LawPanel.ApiClient.Models.Firms.Widgets.Sales
{
    public class FirmWidgetSalesCalculateDto : Dto
    {
        public Guid         FirmWidgetSalesId   { get; set; }
        public List<Guid>   PriceModifiersId    { get; set; }
    }
}