using System;
using System.Collections.Generic;
using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.BatchTasks
{
    public class BatchTaskDetailDto : Dto, IIdentifiableDto
    {
        public string                           Id              { get; set; }
        public IEnumerable<BatchTaskResultDto>  Results         { get; set; }
        public virtual string                   ResultMessage   { get; set; }
        public bool                             Excluded        { get; set; }
        
        public BatchTaskDetailDto()
        {
            Results = new List<BatchTaskResultDto>();
        }
    }

    #region Flattened DTOs

    #region FirmPortfolioDto
    public class BatchTaskFirmPortfolioDto 
    {
        public Guid                 Id                  { get; set; }
        public string               ApplicationNumber   { get; set; }
        public DateTime?            ApplicationDate     { get; set; }
        public DateTime?            RegistrationDate    { get; set; }
        public DateTime?            ExpiryDate          { get; set; }
        public string               MarkText            { get; set; }
        public BatchTaskRegistryDto Registry            { get; set; }
        public string               MarkOwner           { get; set; }
        public IEnumerable<int>     Classes             { get; set; }

        public BatchTaskFirmPortfolioDto()
        {
            Classes = new List<int>();
        }
    }
    #endregion

    #region RegistryDto
    public class BatchTaskRegistryDto 
    {
        public Guid     Id                      { get; set; }
        public string   Name                    { get; set; }
        public string   Description             { get; set; }
        public string   OfficialName            { get; set; }
        public string   WipoCode                { get; set; }
        public string   UrlBaseForTrademarks    { get; set; }
        public int      TrademarkRegistry       { get; set; }
    }
    #endregion

    #endregion
}