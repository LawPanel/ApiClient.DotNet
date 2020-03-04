using System;
using System.Collections.Generic;
using LawPanel.ApiClient.Enums;
using LawPanel.ApiClient.Models.Account;
using LawPanel.ApiClient.Models.ApiQuery.LawPanel;
using LawPanel.ApiClient.Models.Clients;
using LawPanel.ApiClient.Models.FilesAndFolders;
using LawPanel.ApiClient.Models.FilesAndFolders.FileTemplates;
using LawPanel.ApiClient.Models.Firms;
using LawPanel.ApiClient.Models.Firms.FirmContactInfoes;
using LawPanel.ApiClient.Models.Firms.Portfolio;
using LawPanel.ApiClient.Models.Firms.Sales.FirmProducts;
using LawPanel.ApiClient.Models.FirmsContactInfo;
using LawPanel.ApiClient.Models.FirmStatistics;
using LawPanel.ApiClient.Models.Helpers;
using LawPanel.ApiClient.Models.Identities;
using LawPanel.ApiClient.Models.Registry;
using LawPanel.ApiClient.Models.Sales;
using LawPanel.ApiClient.Models.Sales.Currencies;
using LawPanel.ApiClient.Models.Sales.Invoices;
using LawPanel.ApiClient.Models.Sales.Invoices.InvoiceItems;
using LawPanel.ApiClient.Models.Sales.Invoices.InvoiceTypes;
using LawPanel.ApiClient.Models.Sales.PaymentMethods;
using LawPanel.ApiClient.Models.Sales.Payments;
using LawPanel.ApiClient.Models.Sales.PaymentTransactions;
using LawPanel.ApiClient.Models.SearchClass;
using LawPanel.ApiClient.Models.Searches;
using LawPanel.ApiClient.Models.SearchOrigins;
using LawPanel.ApiClient.Models.Trademarks;
using LawPanel.ApiClient.Models.User;
using LawPanel.ApiClient.Models.Watchings;

namespace LawPanel.ApiClient.Interfaces
{
    public interface ILawPanelClient
    {

        UserDto                                         AccountRegister(RegisterDto registerDto);
        UserDto                                         AccountRegisterFromMobile(RegisterDto registerDto);
        bool                                            AccountEmailIsAvailableToRegister(string email);
        bool                                            AccountTenantIsAvailableToRegister(string tenant);

        SearchDto                                       CreateSearch(SearchQuery search);
        SearchDto                                       GetSearch(Guid searchId);
        SearchStatus                                    GetStatus(Guid searchId);
        IEnumerable<SearchResultDto>                    GetResults(Guid id);

        IEnumerable<SearchOriginDto>                    ReadSearchOrigin(int skip = 0, int take = 0, List<ColumnOrder> order = null, bool all = true);
        IEnumerable<SearchClassDto>                     ReadSearchClass(int skip = 0, int take = 0, List<ColumnOrder> order = null, bool all = true);

        TrademarkDto                                    TrademarkByApplicationNumber(string registry, string applicationNumber);
        IEnumerable<TrademarkDto>                       TrademarkSearchByText(string txt);
        IEnumerable<TrademarkDto>                       TrademarksByIds(int[] ids);
        TrademarkDto                                    TrademarksByWordMarkId(int id);
        IEnumerable<TrademarkDto>                       TrademarksBySearch(SearchQuery search);
        IEnumerable<TrademarkDto>                       TrademarkSearchByMultipleCriteria(string txt);
        IEnumerable<TrademarkDto>                       TrademarkListFromLetters(int skip, int take, string registry, string startWith, bool exactLetter);
        IEnumerable<string>                             TrademarkLetters(string startWith, int len, string registry);
        int                                             TrademarkCountByLetter(string startWith, int len, string registry);

        IEnumerable<SearchClassDto>                     ReadSearchClasses(int skip = 0, int take = 0, List<ColumnOrder> order = null, bool all = true);
        IEnumerable<RegistryDto>                        ReadRegistries(int skip = 0, int take = 0, List<ColumnOrder> order = null, bool all = true);
        IEnumerable<FrequencyDto>                       ReadFrequencies(int skip = 0, int take = 0, List<ColumnOrder> order = null, bool all = true);
        List<SearchOriginDto>                           ReadSearchOrigins(int skip = 0, int take = 0, List<ColumnOrder> order = null, bool all = true);

        AuthCookieModel                                 SetUserIdentityAsync(LoginBindingModel loginBindingModel);
        UserLoginDetailsDto                             GetUserLoginDetails(LoginBindingModel loginBindingModel);
        IdentityDto                                     GetUserDetails();
        AuthCookieModel                                 SetUserIdentity(LoginBindingModel loginBindingModel);

        WatchingDto                                     CreateWatching(WatchingDto watching);
        IEnumerable<WatchingDto>                        ReadWatchings(int skip = 0, int take = 0, List<ColumnOrder> order = null, bool all = true);
        ResultDto                                       UpdateWatching(WatchingDto watching);
        ResultDto                                       DeleteWatching(Guid id);

        WatchingUserSettingsDto                         CreateWatchingUserSettings(WatchingUserSettingsDto watchingUserSettingsDto);
        WatchingUserSettingsDto                         ReadWatchingUserSettings();
        ResultDto                                       UpdateWatchingUserSettings(WatchingUserSettingsDto watchingUserSettingsDto);
        ResultDto                                       DeleteWatchingUserSettings(Guid id);

        FirmPortfolioDto                                CreateFirmPortfolio(FirmPortfolioDto portfolio);
        IEnumerable<FirmPortfolioReadDto>               ReadFirmPortfolios(int skip = 0, int take = 0, List<ColumnOrder> order = null, bool all = true);
        ResultDto                                       UpdateFirmPortfolio(FirmPortfolioDto firmPortfolio);
        ResultDto                                       DeleteFirmPortfolio(Guid id);

        FirmContactInfoDto                              CreateLead(int origin, List<LeadComponentDto> components);
        void                                            CreateSearchEmailLead(SearchEmailLeadDto searchEmailLead);

        ClientDto                                       CreateClient(ClientCreateDto client);
        IEnumerable<FirmClientDto>                      ReadClient(int skip = 0, int take = 0, List<ColumnOrder> order = null, bool all = true);
        ClientDto                                       ReadClient(Guid id);
        ResultDto                                       UpdateClient(ClientUpdateDto clientUpdate);
        ResultDto                                       DeleteClient(Guid id);

        IEnumerable<CountryDto>                         ReadCountry(int skip = 0, int take = 0, List<ColumnOrder> order = null, bool all = true);

        FirmProductDto                                  CreateFeeItem(FirmProductCreateDto firmProductCreate);
        IEnumerable<FirmProductReadDto>                 ReadFeeItem(int skip = 0, int take = 0, List<ColumnOrder> order = null, bool all = true);
        ResultDto                                       UpdateFeeItem(FirmProductUpdateDto firmProductUpdate);
        ResultDto                                       DeleteFeeItem(Guid id);

        FolderReadSingleDto                             CreateFolder(FolderCreateDto folderCreate);
        FolderDto                                       ReadFolder(Guid folderId);
        IEnumerable<FolderReadMultipleDto>              ReadFolder(int skip = 0, int take = 0, List<ColumnOrder> order = null, bool all = true);
        ResultDto                                       UpdateFolder(FolderDto folder);
        ResultDto                                       DeleteFolder(Guid id);

        FileDto                                         CreateFile(FileCreateDto fileCreateDto);
        FileDto                                         ReadFile(Guid fileId);
        IEnumerable<FileReadDto>                        ReadFiles(Guid? folderId, int skip = 0, int take = 0, List<ColumnOrder> order = null, bool all = true);
        IEnumerable<FileReadDto>                        ReadFiles(int skip = 0, int take = 0, List<ColumnOrder> order = null, bool all = true);
        IEnumerable<FileEventDto>                       ReadFileEventsOfFirm(int skip = 0, int take = 0, List<ColumnOrder> order = null, bool all = true);
        IEnumerable<FileReadTmdDto>                     ReadFilesTmd(Guid lawpanelClientId);
        FileReadTmdDto                                  ReadFileTmd(Guid lawpanelFileId);
        ResultDto                                       UpdateFile(FileUpdateDto fileUpdateDto);
        ResultDto                                       DeleteFile(Guid id);

        ResultDto                                       AddNoteIntoFile(Guid fileId, FileNoteCreateDto fileNoteCreate);

        FileAttachmentDto                               CreateFileAttachment(FileAttachmentCreateDto fileAttachmentCreateDto);
        IEnumerable<FileAttachmentDto>                  ReadFileAttachment(int skip = 0, int take = 0, List<ColumnOrder> order = null, bool all = true);
        ResultDto                                       UpdateFileAttachment(FileAttachmentUpdateDto fileAttachmentUpdateDto);
        ResultDto                                       DeleteFileAttachment(Guid id);

        IEnumerable<FileEventForFolderDto>              ReadFileEventsOfFolder(Guid folderId, int skip = 0, int take = 0, List<ColumnOrder> order = null, bool all = true);
        IEnumerable<FileEventDto>                       ReadFileEventsOfFile(Guid fileId, int skip = 0, int take = 0, List<ColumnOrder> order = null, bool all = true);

        IEnumerable<FileStatusDto>                      ReadFileStatus(int skip = 0, int take = 0, List<ColumnOrder> order = null, bool all = true);

        IEnumerable<FileTemplateDto>                    ReadFileTemplate(int skip = 0, int take = 0, List<ColumnOrder> order = null, bool all = true);
        
        IEnumerable<CurrencyDto>                        ReadCurrency(int skip = 0, int take = 0, List<ColumnOrder> order = null, bool all = true);

        IEnumerable<InvoiceTypeDto>                     ReadInvoiceType(int skip = 0, int take = 0, List<ColumnOrder> order = null, bool all = true);

        InvoiceItemDto                                  CreateInvoiceItem(InvoiceItemCreateDto invoiceItemCreate);
        IEnumerable<InvoiceItemReadDto>                 ReadInvoiceItem(string entityType = null, Guid? entityId = null, int skip = 0, int take = 0, List<ColumnOrder> order = null, bool all = true);

        IEnumerable<InvoiceItemReadDto>                 ReadInvoiceItem(Guid invoiceId, int skip = 0, int take = 0, List<ColumnOrder> order = null, bool all = true);
        ResultDto                                       UpdateInvoiceItem(InvoiceItemUpdateDto invoiceItemUpdate);
        ResultDto                                       DeleteInvoiceItem(Guid id);

        InvoiceDto                                      CreateInvoice(InvoiceCreateDto invoiceCreate);
        IEnumerable<InvoiceReadDto>                     ReadInvoice(string entityType = null, Guid? entityId = null, int skip = 0, int take = 0, List<ColumnOrder> order = null, bool all = true);

        ResultDto                                       UpdateInvoice(InvoiceUpdateDto invoiceUpdate);
        ResultDto                                       DeleteInvoice(Guid id);

        IEnumerable<LanguageDto>                        ReadLanguage(int skip = 0, int take = 0, List<ColumnOrder> order = null, bool all = true);

        IEnumerable<PaymentMethodDto>                   ReadPaymentMethod(int skip = 0, int take = 0, List<ColumnOrder> order = null, bool all = true);

        IEnumerable<PaymentTransactionTypeDto>          ReadPaymentTransactionType(int skip = 0, int take = 0, List<ColumnOrder> order = null, bool all = true);

        IEnumerable<PaymentProviderDto>                 ReadPaymentProvider(int skip = 0, int take = 0, List<ColumnOrder> order = null, bool all = true);

        PaymentDto                                      CreatePayment(PaymentCreateDto paymentCreate);
        IEnumerable<PaymentReadDto>                     ReadPayment(Guid? invoiceId = null, int skip = 0, int take = 0, List<ColumnOrder> order = null, bool all = true);
        ResultDto                                       UpdatePayment(PaymentUpdateDto paymentUpdate);

        void                                            CreatePortfolioBundle(List<FirmPortfolioBundle> firmPortfolioBundles);

        DashboardStatisticsModel                        ReadFirmStatisticsDashboard();

        ClientUserDto                                   CreateClientUser(ClientUserDto firmClient);
        IEnumerable<ClientUserDto>                      ReadClientUser(int skip = 0, int take = 0, List<ColumnOrder> order = null, bool all = true);
        ResultDto                                       UpdateClient(ClientUserDto clientUser);
        ResultDto                                       DeleteClientUser(Guid id);

        decimal                                         ProductFilterCalculate(string internalName, params string[][] combinations);
    }
}