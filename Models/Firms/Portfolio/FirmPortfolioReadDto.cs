using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LawPanel.ApiClient.Attributes;
using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.Clients;
using LawPanel.ApiClient.Models.FilesAndFolders.FileClients;
using LawPanel.ApiClient.Models.Flatteneds;
using LawPanel.ApiClient.Models.GoodAndServices;
using LawPanel.ApiClient.Models.Registry;
using LawPanel.ApiClient.Models.SearchClass;
using LawPanel.ApiClient.Models.User;
using LawPanel.ApiClient.Models.Watchings;

namespace LawPanel.ApiClient.Models.Firms.Portfolio
{
    public class FirmPortfolioReadDto : Dto, IIdentifiableDto
    {
        #region Firm
        public string Id { get; set; }
        [Display(Name = "[[[Firm]]]"), Required(ErrorMessage = "[[[Firm is required]]]", AllowEmptyStrings = false)]
        public string FirmId { get; set; }
        public string FirmName { get; set; }
        #endregion

        #region FirmClient
        [Display(Name = "[[[Firm client]]]")]
        public string FirmClientId { get; set; }
        public string FirmClientName { get; set; }
        public FirmPortfolioReadFirmClientDto FirmClient { get; set; }
        #endregion

        #region FirmClientAgent
        [Display(Name = "[[[Agent]]]")]
        public string FirmClientAgentId { get; set; }
        public string FirmClientAgentName { get; set; }
        public FirmPortfolioReadFirmClientDto FirmClientAgent { get; set; }
        #endregion

        #region Trademark
        [Display(Name = "[[[Application number]]]"), Required(ErrorMessage = "[[[Application number is required]]]", AllowEmptyStrings = false)]
        [ApiExportable(2)]
        public string ApplicationNumber { get; set; }

        [Display(Name = "[[[Registration number]]]")]
        public string RegistrationNumber { get; set; }

        [Display(Name = "[[[Registration date]]]")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [ApiExportable(6)]
        public DateTime? RegistrationDate { set; get; }

        [Display(Name = "[[[Application date]]]")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [ApiExportable(5)]
        public DateTime? ApplicationDate { set; get; }

        [Display(Name = "[[[Expiry date]]]")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [ApiExportable(7)]
        public DateTime? ExpiryDate { get; set; }

        [Display(Name = "[[[Publication date]]]")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? PublicationDate { get; set; }

        [Display(Name = "[[[Mark feature]]]"), Required(ErrorMessage = "[[[Mark feature is required]]]", AllowEmptyStrings = true)]
        [ApiExportable(8)]
        public string MarkFeature { set; get; }

        [Display(Name = "[[[Kind mark]]]"), Required(ErrorMessage = "[[[Kind mark is required]]]", AllowEmptyStrings = true)]
        public string KindMark { get; set; }

        [Display(Name = "[[[Mark text]]]"), Required(ErrorMessage = "[[[Mark text is required]]]", AllowEmptyStrings = false)]
        [ApiExportable(4)]
        public string MarkText { get; set; }

        [Display(Name = "[[[Mark owner]]]")]
        [ApiExportable(9)]
        public FirmPortfolioReadClientDto MarkOwner { set; get; }

        [Display(Name = "[[[Mark representative]]]")]
        public FirmPortfolioReadClientDto MarkRepresentative { set; get; }

        [Display(Name = "[[[Representative reference]]]")]
        public string MarkRepresentativeReference { get; set; }

        [Display(Name = "[[[Mark agent]]]")]
        public FirmPortfolioReadClientDto MarkAgent { set; get; }

        [Display(Name = "[[[Representative reference]]]")]
        public string MarkAgentReference { get; set; }

        [Display(Name = "[[[Classes]]]"), Required(ErrorMessage = "[[[Classes list is required]]]", AllowEmptyStrings = false)]
        public List<FirmPortfolioReadSearchClassDto> Classes { get; set; }

        [Display(Name = "[[[Status]]]"), Required(ErrorMessage = "[[[Status text is required]]]", AllowEmptyStrings = false)]
        [ApiExportable(10)]
        public string Status { get; set; }

        [Display(Name = "[[[Status date]]]")]
        [ApiExportable(11)]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? StatusDate { get; set; }

        [Display(Name = "[[[Registry]]]"), Required(ErrorMessage = "[[[Registry is required]]]", AllowEmptyStrings = false)]
        [ApiExportable(3)]
        public FirmPortfolioReadRegistryDto Registry { get; set; }

        [Display(Name = "[[[Good and services]]]")]
        public List<GaSReadDto> GoodAndServices { get; set; }

        #endregion

        #region User creator of registry
        public string UserId { get; set; }
        public string UserUserName { get; set; }

        [Display(Name = "[[[Owner]]]")]
        public FirmPortfolioReadUserDto User { get; set; }
        #endregion

        public bool HasReminders { get; set; }

        public FirmPortfolioReadWatchingDto Watching { get; set; }

        public string TrademarkUrlOnIpo { get; set; }
        public string ImageUrl { get; set; }

        [ApiExportable(0)]
        [Display(Name = "[[[Case reference]]]")]
        public string CaseReference { get; set; }

        [ApiExportable(1)]
        [Display(Name = "[[[Client reference]]]")]
        public string ClientReference { get; set; }

        [Display(Name = "[[[Notes]]]")]
        public string Notes { get; set; }
    }

    #region Flattend DTOs

    #region WatchingDto
    public class FirmPortfolioReadWatchingDto : FlattenedDto<WatchingDto>
    {
        public Guid Id                                  { get; set; }
        public int  InterestingWatchingHistoryRecords   { get; set; }
    } 
    #endregion

    #region RegistryDto
    public class FirmPortfolioReadRegistryDto : FlattenedDto<RegistryDto>
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

    #region ClientDto
    public class FirmPortfolioReadClientDto : FlattenedDto<ClientDto>
    {
        public Guid                         Id              { get; set; }
        public string                       Name            { get; set; }
        public FirmPortfolioReadAddressDto  ContactAddress  { get; set; }
        public FirmPortfolioReadAddressDto  BillingAddress  { get; set; }
    }
    #endregion

    #region FirmClientDto
    public class FirmPortfolioReadFirmClientDto : FlattenedDto<FirmClientDto>
    {
        public Guid                         Id      { get; set; }
        public FirmPortfolioReadClientDto   Client  { get; set; }

        public FirmPortfolioReadFirmClientDto()
        {
            Client = new FirmPortfolioReadClientDto();
        }
    }
    #endregion

    #region UserDto
    public class FirmPortfolioReadUserDto : FlattenedDto<UserDto>
    {
        public Guid     Id          { get; set; }
        public string   FirstName   { get; set; }
        public string   LastName    { get; set; }
        public string   Email       { get; set; }
        public string   UserName    { get; set; }
    }
    #endregion

    #region SearchClassDto
    public class FirmPortfolioReadSearchClassDto : FlattenedDto<SearchClassDto>
    {
        public Guid     Id              { get; set; }
        public int      Number          { get; set; }
        public string   Name            { get; set; }
        public string   Description     { get; set; }
    }
    #endregion

    #region FileClientDto
    public class FirmPortfolioReadFileClientDto : FlattenedDto<FileClientDto>
    {
        public Guid                                 Id              { get; set; }
        public FirmPortfolioReadFileClientRoleDto   FileClientRole  { get; set; }
        public FirmPortfolioReadClientDto           Client          { get; set; }
        public string                               Reference       { get; set; }
    }
    #endregion

    #region FileClientRoleCode
    public class FirmPortfolioReadFileClientRoleDto : FlattenedDto<FileClientRoleDto>
    {
        public int Code { get; set; }
    }
    #endregion

    #region ReadFileDto
    public class FirmPortfolioReadFileDto
    {
        public Guid                                             Id              { get; set; }
        public IEnumerable<FirmPortfolioReadFilePortfolioDto>   FilePortfolios  { get; set; }
        public IEnumerable<FirmPortfolioReadFileClientDto>      FileClients     { get; set; }
    }
    #endregion

    #region FilePortfolioDto
    public class FirmPortfolioReadFilePortfolioDto
    {
        public FirmPortfolioReadFirmPortfolioDto        FirmPortfolio       { get; set; }
        public FirmPortfolioReadFilePortfolioRoleDto    FilePortfolioRole   { get; set; }

    }
    #endregion

    #region FilePortfolioRoleDto

    public class FirmPortfolioReadFilePortfolioRoleDto
    {
        public int Code { get; set; }
    }

    #endregion

    #region FirmPortfolioDto
    public class FirmPortfolioReadFirmPortfolioDto
    {
        public Guid Id { get; set; }
    }
    #endregion

    #region AddressDto

    public class FirmPortfolioReadAddressDto
    {
        public Guid     Id              { get; set; }
        public string   Line1           { get; set; }
        public string   Line2           { get; set; }
        public string   Line3           { get; set; }
        public string   Building        { get; set; }
        public string   FloorLevel      { get; set; }
        public string   PostalCode      { get; set; }
        public string   City            { get; set; }
        public string   StateProvince   { get; set; }
        public string   Region          { get; set; }
        public string   CountryName     { get; set; }
    }

    #endregion

    #endregion
}
 
