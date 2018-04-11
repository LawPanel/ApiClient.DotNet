using System;

namespace LawPanel.ApiClient.Models.Firms
{
    public class FirmPlanDto : Dto
    {
        public decimal      Amount              { get; set; }
        public DateTime     Created             { get; set; }
        public string       Currency            { get; set; }
        public string       Interval            { get; set; }
        public int          IntervalCount       { get; set; }
        public bool         LiveMode            { get; set; }
        public string       Name                { get; set; }
        public string       StatementDescriptor { get; set; }
        public int?         TrialPeriodDays     { get; set; }
        public bool         Paid                { get; set; }
        public DateTime?    ExpirationDate      { get; set; }
    }
}
