using System;
using System.Collections.Generic;
using LawPanel.ApiClient.Extensions;

namespace LawPanel.ApiClient.Models.Firms.Portfolio
{
    public class FirmPortfolioBundle : Dto
    {
        public List<string> Ids     { get; set; }
        public string       UnitId  { get; set; }
        public int          Total   { get; set; }
        public bool         AddAll  { get; set; }



        public List<FirmPortfolioBundleComponent> GetComponents()
        {
            var components = new List<FirmPortfolioBundleComponent>();
            if (Ids is null) return components;

            foreach (var bundleId in Ids)
            {
                #region Get ApplicationNumber and Registry
                var id = bundleId.FromHexString();
                var parts = id.Split(Convert.ToChar("|"));
                var applicationNumber = parts[0] == string.Empty ? null : parts[0];
                var wipoCodeOnDataSource = parts[1] == string.Empty ? null : parts[1];
                var registrationNumber = parts[2] == string.Empty ? null : parts[2];
                var markText = parts[3] == string.Empty ? null : parts[3]; 
                #endregion 

                components.Add(new FirmPortfolioBundleComponent
                {
                    ApplicationNumber = applicationNumber,
                    RegistrationNumber = registrationNumber,
                    WipoCode = wipoCodeOnDataSource,
                    MarkText = markText
                });
            }


            return components;
        }
    }
}