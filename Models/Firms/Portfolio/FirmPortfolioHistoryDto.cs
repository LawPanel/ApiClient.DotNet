using System;
using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Firms.Portfolio
{
    public class FirmPortfolioHistoryDto : Dto, IIdentifiableDto
    {
        public string   Id              { get; set; }

        #region Coordinates
        public string   FirmPortfolioId { get; set; }
        public string   FirmId          { get; set; }
        #endregion

        public long     UnixTimeStamp   { get; set; }

        public string   OriginalDataId  { get; set; }
        public string   OriginalData    { get; set; }

        public string   UpdatedDataId   { get; set; }
        public string   UpdatedData     { get; set; }

        public bool     WithChanges     { get; set; }
        public string   Comments        { get; set; }


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