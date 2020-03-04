using System;

namespace LawPanel.ApiClient.Models.Firms.Watchings
{
    public class WatchingResultCsvDto : Dto
    {
        public string   RiskLevel               { get; set; }
        public string   Trademark               { get; set; }
        public string   Classes                 { get; set; }
        public string   Databases               { get; set; }
        public string   OwnerApplicant          { get; set; }
        public string   Status                  { get; set; }
        public string   ApplicationDate         { get; set; }
        public string   RegistrationDate        { get; set; }
        public string   DeadLineForOpposition   { get; set; }
        public string   ApplicationNumber       { get; set; }
        public string   RegistrationNumber      { get; set; }
        public string   ClientLabelComments     { get; set; }
        public string   GoodAndServices         { get; set; }

        public string StringToCalculateHash(Guid watchingId)
        {
            return $"{watchingId}{Trademark}{Classes}{Databases}{OwnerApplicant}{Status}{DeadLineForOpposition}{ClientLabelComments}{GoodAndServices}"; // Do not change if new fields are added
        }


        /*
         * "Risk level",
         * Trademark,
         * Classes,
         * Databases,
         * Owner/Applicant,
         * Status,
         * "Application date",
         * "Registration date",
         * "Deadline for opposition",
         * "Application number",
         * "Registration number",
         * Client/Label/Comments,
         * "Good and Services"
         */
    }
}