using System;
using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Firms.Watchings
{
    public class WatchingHistoryDto : Dto, IIdentifiableDto
    {
        #region Coordinates
        public string   WatchingId              { get; set; }
        public string   FirmId                  { get; set; }
        #endregion

        public string   Id                      { get; set; }
        public long     UnixTimeStamp           { get; set; }

        public string   ProviderId              { get; set; }
        public string   Trademark               { get; set; }
        public string   Classes                 { get; set; }
        public string   Databases               { get; set; }
        public string   OwnerApplicant          { get; set; }
        public string   Status                  { get; set; }
        public string   DeadLineForOpposition   { get; set; }
        public string   Serial                  { get; set; }
        public string   ClientLabelComments     { get; set; }
        public string   GoodAndServices         { get; set; }
        public bool     Handled                 { get; set; }

        public string Pk()
        {
            return Id.Split(Convert.ToChar("|"))[0];
        }
        public string Rk()
        {
            return Id.Split(Convert.ToChar("|"))[1];
        }
    }
}