using System;

namespace LawPanel.ApiClient.Models.Firms.Watchings
{
    public class WatchingResultCsvDto : Dto
    {
        public string   RiskLevel               { get; set; }
        public string   Id                      { get; set; }
        public string   Trademark               { get; set; }
        public string   Classes                 { get; set; }
        public string   Databases               { get; set; }
        public string   OwnerApplicant          { get; set; }
        public string   Status                  { get; set; }
        public string   DeadLineForOpposition   { get; set; }
        public string   Serial                  { get; set; }
        public string   ClientLabelComments     { get; set; }
        public string   GoodAndServices         { get; set; }

        public string StringToCalculateHash(Guid watchingId)
        {
            return $"{watchingId}{Trademark}{Classes}{Databases}{OwnerApplicant}{Status}{DeadLineForOpposition}{Serial}{ClientLabelComments}{GoodAndServices}"; // Do not change if new fields are added
        }
    }
}