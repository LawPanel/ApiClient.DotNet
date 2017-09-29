using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LawPanel.ApiClient.Enums;
using LawPanel.ApiClient.Models.Account;
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

        Task<IEnumerable<SearchOriginDto>>              ReadSearchOrigin();
        Task<IEnumerable<SearchClassDto>>               ReadSearchClass();

        TrademarkDto                                    TrademarkByApplicationNumber(string registry, string applicationNumber);
        IEnumerable<TrademarkDto>                       TrademarkSearchByText(string txt);
        IEnumerable<TrademarkDto>                       TrademarksByIds(int[] ids);
        TrademarkDto                                    TrademarksByWordMarkId(int id);
        IEnumerable<TrademarkDto>                       TrademarksBySearch(SearchQuery search);
        IEnumerable<TrademarkDto>                       TrademarkSearchByMultipleCriteria(string txt);
        IEnumerable<TrademarkDto>                       TrademarkListFromLetters(int skip, int take, string registry, string startWith, bool exactLetter);
        IEnumerable<string>                             TrademarkLetters(string startWith, int len, string registry);
        int                                             TrademarkCountByLetter(string startWith, int len, string registry);

        IEnumerable<SearchClassDto>                     ReadSearchClasses();
        IEnumerable<RegistryDto>                        ReadRegistries();
        IEnumerable<FrequencyDto>                       ReadFrequencies();
        List<SearchOriginDto>                           ReadSearchOrigins();

        Task<AuthCookieModel>                           SetUserIdentityAsync(LoginBindingModel loginBindingModel);
        UserLoginDetailsDto                             GetUserLoginDetails(LoginBindingModel loginBindingModel);
        IdentityDto                                     GetUserDetails();
        AuthCookieModel                                 SetUserIdentity(LoginBindingModel loginBindingModel);

        WatchingDto                                     CreateWatching(WatchingDto watching);
        Task<IEnumerable<WatchingDto>>                  ReadWatchings();
        ResultDto                                       UpdateWatching(WatchingDto watching);
        ResultDto                                       DeleteWatching(Guid id);
        Task                                            CreateWatchingBundle(List<WatchingBundleDto> watchingBundles);

        WatchingUserSettingsDto                         CreateWatchingUserSettings(WatchingUserSettingsDto watchingUserSettingsDto);
        WatchingUserSettingsDto                         ReadWatchingUserSettings();
        ResultDto                                       UpdateWatchingUserSettings(WatchingUserSettingsDto watchingUserSettingsDto);
        ResultDto                                       DeleteWatchingUserSettings(Guid id);

        Task<string>                                    GetFirmApiKey();

        FirmPortfolioDto                                CreateFirmPortfolio(FirmPortfolioDto portfolioDto);
        Task<IEnumerable<FirmPortfolioReadDto>>         ReadFirmPortfolios();
        ResultDto                                       UpdateFirmPortfolio(FirmPortfolioDto firmPortfolioDto);
        ResultDto                                       DeleteFirmPortfolio(Guid id);

        FirmContactInfoDto                              CreateLead(int origin, List<LeadComponentDto> components);
        void                                            CreateSearchEmailLead(SearchEmailLeadDto searchEmailLead);

        ClientDto                                       CreateClient(ClientCreateDto client);
        IEnumerable<FirmClientDto>                      ReadClient();
        ClientDto                                       ReadClient(Guid id);
        ResultDto                                       UpdateClient(ClientUpdateDto clientUpdate);
        ResultDto                                       DeleteClient(Guid id);

        IEnumerable<CountryDto>                         ReadCountry();

        FirmProductDto                                  CreateFeeItem(FirmProductCreateDto firmProductCreate);
        IEnumerable<FirmProductReadDto>                 ReadFeeItem();
        ResultDto                                       UpdateFeeItem(FirmProductUpdateDto firmProductUpdate);
        ResultDto                                       DeleteFeeItem(Guid id);

        FolderReadSingleDto                             CreateFolder(FolderCreateDto folderCreate);
        IEnumerable<FolderReadMultipleDto>              ReadFolder();
        ResultDto                                       UpdateFolder(FolderDto folder);
        ResultDto                                       DeleteFolder(Guid id);

        FileDto                                         CreateFile(FileCreateDto fileCreateDto);
        FileDto                                         ReadFile(Guid fileId);
        IEnumerable<FileReadDto>                        ReadFiles(Guid? folderId);
        ResultDto                                       UpdateFile(FileUpdateDto fileUpdateDto);
        ResultDto                                       DeleteFile(Guid id);

        ResultDto                                       AddNoteIntoFile(Guid fileId, FileNoteCreateDto fileNoteCreate);

        FileAttachmentDto                               CreateFileAttachment(FileAttachmentCreateDto fileAttachmentCreateDto);
        IEnumerable<FileAttachmentDto>                  ReadFileAttachment();
        ResultDto                                       UpdateFile(FileAttachmentUpdateDto fileAttachmentUpdateDto);
        ResultDto                                       DeleteFileAttachment(Guid id);

        IEnumerable<FileEventForFolderDto>              ReadFileEventsOfFolder(Guid folderId);
        IEnumerable<FileEventDto>                       ReadFileEventsOfFile(Guid fileId);

        IEnumerable<FileStatusDto>                      ReadFileStatus();

        IEnumerable<FileTemplateDto>                    ReadFileTemplate();
        
        IEnumerable<CurrencyDto>                        ReadCurrency();

        IEnumerable<InvoiceTypeDto>                     ReadInvoiceType();

        InvoiceItemDto                                  CreateInvoiceItem(InvoiceItemCreateDto invoiceItemCreate);
        IEnumerable<InvoiceItemReadDto>                 ReadInvoiceItem(string entityType = null, Guid? entityId = null);
        ResultDto                                       UpdateInvoiceItem(InvoiceItemUpdateDto invoiceItemUpdate);
        ResultDto                                       DeleteInvoiceItem(Guid id);

        InvoiceDto                                      CreateInvoice(InvoiceCreateDto invoiceCreate);
        IEnumerable<InvoiceReadDto>                     ReadInvoice(string entityType = null, Guid? entityId = null);
        ResultDto                                       UpdateInvoice(InvoiceUpdateDto invoiceUpdate);
        ResultDto                                       DeleteInvoice(Guid id);

        IEnumerable<LanguageDto>                        ReadLanguage();

        IEnumerable<PaymentMethodDto>                   ReadPaymentMethod();

        IEnumerable<PaymentTransactionTypeDto>          ReadPaymentTransactionType();

        IEnumerable<PaymentProviderDto>                 ReadPaymentProvider();

        PaymentDto                                      CreatePayment(PaymentCreateDto paymentCreate);
        IEnumerable<PaymentReadDto>                     ReadPayment(Guid? invoiceId = null);
        ResultDto                                       UpdatePayment(PaymentUpdateDto paymentUpdate);

        void                                            CreatePortfolioBundle(List<FirmPortfolioBundle> firmPortfolioBundles);

        DashboardStatisticsModel                        ReadFirmStatisticsDashboard();
    }
}