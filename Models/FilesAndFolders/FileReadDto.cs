using System;
using System.Collections.Generic;
using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.Clients;
using LawPanel.ApiClient.Models.FilesAndFolders.FileTemplates;
using LawPanel.ApiClient.Models.Tags;
using LawPanel.ApiClient.Models.User;

namespace LawPanel.ApiClient.Models.FilesAndFolders
{
    public class FileReadDto : Dto, IIdentifiableDto
    {
        public string                   Id                  { get; set; }
        public string                   Name                { get; set; }
        public ClientDto                Client              { get; set; } // Agent
        public Guid                     FileStatusId        { get; set; }
        public string                   FileStatusName      { get; set; }
        public FileReadFilePortfolioDto FilePortfolio       { get; set; }
        public UserDto                  Owner               { get; set; }
        public IEnumerable<UserDto>     OtherSupervisors    { get; set; }
        public DateTime?                UpdatedAt           { get; set; }
        public string                   PaymentStatus       { get; set; }
        public string                   UpdatedBy           { get; set; } // Last updated by
        public List<TagDto>             Tags                { get; set; }
        public string                   Number              { get; set; }
        public FileTemplateDto          FileTemplate        { get; set; }
        public bool                     Active              { get; set; }

        public FileReadDto()
        {
            Tags = new List<TagDto>();
        }

        #region Flattened DTOs

        #region FirmPortfolioDto
        public class FileReadFirmPortfolioDto 
        {
            public Guid                         Id                  { get; set; }
            public string                       ApplicationNumber   { get; set; }
            public DateTime                     ApplicationDate     { get; set; }
            public DateTime                     RegistrationDate    { get; set; }
            public DateTime                     ExpiryDate          { get; set; }
            public string                       MarkText            { get; set; }
            public FileReadRegistryDto          Registry            { get; set; }
            public string                       MarkOwner           { get; set; }
            public List<int>                    Classes             { get; set; }

            public FileReadFirmPortfolioDto()
            {
                Classes = new List<int>();
            }
        }
        #endregion

        #region FilePortfolioDto
        public class FileReadFilePortfolioDto 
        {
            public Guid                         Id                  { get; set; }
            public FileReadFirmPortfolioDto     FirmPortfolio       { get; set; }
            public FileReadFilePortfolioRoleDto FilePortfolioRole   { get; set; }
        }
        #endregion

        #region FilePortfolioRoleDto
        public class FileReadFilePortfolioRoleDto
        {
            public Guid     Id    { get; set; }
            public string   Name  { get; set; }
            public bool     IsOwn { get; set; }
        }
        #endregion

        #region RegistryDto
        public class FileReadRegistryDto 
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
}