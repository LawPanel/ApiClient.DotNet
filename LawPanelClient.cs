using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using LawPanel.ApiClient.Attributes;
using LawPanel.ApiClient.Base;
using LawPanel.ApiClient.Constants;
using LawPanel.ApiClient.Enums;
using LawPanel.ApiClient.Exceptions;
using LawPanel.ApiClient.Extensions;
using LawPanel.ApiClient.Interfaces;
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
using Newtonsoft.Json;
using HttpMethod = LawPanel.ApiClient.Enums.HttpMethod;

namespace LawPanel.ApiClient
{
    public class LawPanelClient : ILawPanelClient
    {
        #region Properties

        public static HttpClientLawPanel HttpClient;

        private const string SubscriptionKeyParamName = "subscription-key";
        private string ApiUrl { get; set; }
        private string SubscriptionKey { get; set; }

        private AuthCookieModel AuthCookieModel { get; set; }
        public bool UseProxy { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initialize the LawPanel's API client
        /// </summary>
        /// <param name="subscriptionKey">Mandatory: Your firm's API key.</param>
        /// <param name="userName">Optional: Some API calls require you identified as user level ( in addition to your Firm's API Key )</param>
        /// <param name="password">Optional: Some API calls require you identified as user level ( in addition to your Firm's API Key )</param>
        /// <param name="apiUrl">Optional: If not specified, will use https://api.lawpanel.com/v1/firms/ </param>
        public LawPanelClient(string subscriptionKey = null, string userName = "", string password = "", string apiUrl = "")
        {
            AuthCookieModel authCookieModel = null;

            #region Validations
            if (!string.IsNullOrEmpty(userName) && string.IsNullOrEmpty(password)) throw new ArgumentException("If you set the username you will need to set the password too", nameof(password));
            if (!string.IsNullOrEmpty(password) && string.IsNullOrEmpty(userName)) throw new ArgumentException("If you set the password you will need to set the username too", nameof(userName));
            #endregion

            // Set API url
            ApiUrl = !string.IsNullOrEmpty(apiUrl) ? apiUrl : Auth.ApiUrl;
            
            #region Get auth cookie ( if username and password are present )
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            {
                SubscriptionKey = subscriptionKey;

                authCookieModel = SetUserIdentity(new LoginBindingModel
                {
                    Email = userName,
                    Password = password,
                    RememberMe = true
                });
            }
            #endregion

            Initialize(subscriptionKey, authCookieModel, ApiUrl);
        }

        public LawPanelClient(string subscriptionKey, AuthCookieModel authCookieModel)
        {
            var apiUrl = Auth.ApiUrlForApps;

            Initialize(subscriptionKey, authCookieModel, apiUrl);
        }

        public LawPanelClient(string subscriptionKey, AuthCookieModel authCookieModel, string apiUrl)
        {
            Initialize(subscriptionKey, authCookieModel, apiUrl);
        }

        #endregion

        #region  ILawPanelClient

        #region TradeMarks

        public TrademarkDto TrademarkByApplicationNumber(string registry, string applicationNumber)
        {
            return Execute<TrademarkDto>($"trademark/{registry}/{applicationNumber}", HttpMethod.Get, null, HttpStatusCode.OK);
        }

        public IEnumerable<TrademarkDto> TrademarkSearchByText(string txt)
        {
            return Execute<IEnumerable<TrademarkDto>>($"trademark/SearchByText/{txt}", HttpMethod.Get, null, HttpStatusCode.OK);
        }

        public IEnumerable<TrademarkDto> TrademarksByIds(int[] ids)
        {
            return Execute<IEnumerable<TrademarkDto>>("trademark/searchbyids", HttpMethod.Post, ids, HttpStatusCode.OK);
        }

        public TrademarkDto TrademarksByWordMarkId(int id)
        {
            return Execute<TrademarkDto>("trademark/searchbyworkmarkid", HttpMethod.Post, new { id }, HttpStatusCode.OK);
        }

        public IEnumerable<TrademarkDto> TrademarksBySearch(SearchQuery search)
        {
            var searchPayload = new
            {
                search.SearchTerm,
                search.Classes,
                search.Registry,
                search.Weighting,
                search.Type
            };
            return Execute<IEnumerable<TrademarkDto>>("trademark/search", HttpMethod.Post, searchPayload, HttpStatusCode.OK);
        }

        public IEnumerable<TrademarkDto> TrademarkSearchByMultipleCriteria(string txt)
        {
            return Execute<IEnumerable<TrademarkDto>>($"trademark/searchbymultiplecriteria/{txt}", HttpMethod.Get, null, HttpStatusCode.OK);
        }

        public IEnumerable<TrademarkDto> TrademarkListFromLetters(int skip, int take, string registry, string startWith, bool exactLetter)
        {
            return Execute<IEnumerable<TrademarkDto>>($"trademark/filteredlist?skip={skip}&take={take}&registry={registry}&startWith={startWith}&exactLetter={exactLetter}", HttpMethod.Get, null, HttpStatusCode.OK);
        }

        public IEnumerable<string> TrademarkLetters(string startWith, int len, string registry)
        {
            return Execute<IEnumerable<string>>($"trademark/letters?startWith={startWith}&registry={registry}&len={len}", HttpMethod.Get, null, HttpStatusCode.OK);
        }

        public int TrademarkCountByLetter(string startWith, int len, string registry)
        {
            return Execute<int>($"trademark/countbyletter?startWith={startWith}&registry={registry}&len={len}", HttpMethod.Get, null, HttpStatusCode.OK);
        }

        #endregion

        #region Watching

        public WatchingDto CreateWatching(WatchingDto watching)
        {
            return Execute<WatchingDto>("watching", HttpMethod.Post, watching, HttpStatusCode.Created);
        }

        public IEnumerable<WatchingDto> ReadWatchings(int skip = 0, int take = 0, List<ColumnOrder> order = null, bool all = true)
        {
            return Read<WatchingDto>("watching", HttpMethod.Get, null, skip, take, order, true);
        }

        public ResultDto UpdateWatching(WatchingDto watching)
        {
            return Execute<ResultDto>("watching", HttpMethod.Put, watching, HttpStatusCode.OK);
        }

        public ResultDto DeleteWatching(Guid id)
        {
            return Execute<ResultDto>($"watching/{id}", HttpMethod.Delete, null, HttpStatusCode.OK);
        }

        public void CreateWatchingBundle(List<WatchingBundleDto> watchingBundles)
        {
            Execute<object>("watching/addbundle", HttpMethod.Post, watchingBundles, HttpStatusCode.Created);
        }

        #endregion

        #region FirmPortfolio

        public FirmPortfolioDto CreateFirmPortfolio(FirmPortfolioDto portfolio)
        {
            return Execute<FirmPortfolioDto>("firmportfolio", HttpMethod.Post, portfolio, HttpStatusCode.Created);
        }

        public IEnumerable<FirmPortfolioReadDto> ReadFirmPortfolios(int skip = 0, int take = 0, List<ColumnOrder> order = null, bool all = true)
        {
            return Read<FirmPortfolioReadDto>("firmportfolio", HttpMethod.Get, null, skip, take, order, true);
        }

        public ResultDto UpdateFirmPortfolio(FirmPortfolioDto firmPortfolio)
        {
            return Execute<ResultDto>("firmportfolio", HttpMethod.Put, firmPortfolio, HttpStatusCode.OK);
        }

        public ResultDto DeleteFirmPortfolio(Guid id)
        {
            return Execute<ResultDto>($"firmportfolio/{id}", HttpMethod.Delete, null, HttpStatusCode.OK);
        }

        public void CreatePortfolioBundle(List<FirmPortfolioBundle> firmPortfolioBundles)
        {
            Execute<object>("firmportfolio/addbundle", HttpMethod.Post, firmPortfolioBundles, HttpStatusCode.Created);
        }

        #endregion

        #region Watchings users settings

        public WatchingUserSettingsDto CreateWatchingUserSettings(WatchingUserSettingsDto watchingUserSettingsDto)
        {
            return Execute<WatchingUserSettingsDto>("watchingusersettings", HttpMethod.Post, watchingUserSettingsDto, HttpStatusCode.Created);
        }

        public WatchingUserSettingsDto ReadWatchingUserSettings()
        {
            return Execute<WatchingUserSettingsDto>("watchingusersettings/mysettings?use_lawpanel_query_syntax=true", HttpMethod.Get, null, HttpStatusCode.OK);
        }

        public ResultDto UpdateWatchingUserSettings(WatchingUserSettingsDto watchingUserSettingsDto)
        {
            return Execute<ResultDto>("watchingusersettings", HttpMethod.Put, watchingUserSettingsDto, HttpStatusCode.OK);
        }

        public ResultDto DeleteWatchingUserSettings(Guid id)
        {
            return Execute<ResultDto>($"watchingusersettings/{id}", HttpMethod.Delete, null, HttpStatusCode.OK);
        }

        #endregion

        #region Firms

        /// <summary>
        /// Returns the API key for current user
        /// </summary>
        /// <returns></returns>
        public string GetFirmApiKey()
        {
            var url = "firms/apikey?firmId=" + default(Guid);
            return Execute<string>(url, HttpMethod.Get, null, HttpStatusCode.OK);
        }

        #endregion

        #region Firms statistics

        public DashboardStatisticsModel ReadFirmStatisticsDashboard()
        {
            return Execute<DashboardStatisticsModel>("firmstatistics/dashboard", HttpMethod.Get, null, HttpStatusCode.OK);
        }

        #endregion

        #region Account

        public UserDto AccountRegister(RegisterDto registerDto)
        {
            return Execute<UserDto>("account/register", HttpMethod.Post, registerDto, HttpStatusCode.OK);
        }

        public UserDto AccountRegisterFromMobile(RegisterDto registerDto)
        {
            return Execute<UserDto>("account/registerfrommobile", HttpMethod.Post, registerDto, HttpStatusCode.OK);
        }

        public bool AccountEmailIsAvailableToRegister(string email)
        {
            return Execute<bool>($"account/emailisavailabletoregister?email={email}", HttpMethod.Get, null, HttpStatusCode.OK);
        }

        public bool AccountTenantIsAvailableToRegister(string tenant)
        {
            return Execute<bool>($"account/tenantisavailabletoregister/{tenant}", HttpMethod.Get, null, HttpStatusCode.OK);
        }

        #endregion

        #region Users

        public UserLoginDetailsDto GetUserLoginDetails(LoginBindingModel loginBindingModel)
        {
            return Execute<UserLoginDetailsDto>("account/login", HttpMethod.Post, loginBindingModel, HttpStatusCode.OK);
        }

        #region User identity

        public AuthCookieModel SetUserIdentityAsync(LoginBindingModel loginBindingModel)
        {
            var extraParam = "";
            if (ApiUrl.Contains(".azureedge.net"))
            {
                extraParam = "?comeFromCdn=true";
            }

            var response = HttpClient.PostAsJsonAsyncWithSnakeCase($"account/login{extraParam}?subscription-key={SubscriptionKey}", loginBindingModel).Result;
            try
            {
                if (response.StatusCode != HttpStatusCode.NoContent)
                {
                    var responseString = response.Content.ReadAsStringAsync().Result;
                    Debug.WriteLine(responseString);
                    return null;
                }

                var header = response.Headers.First(h => h.Key == "Set-Cookie");
                var cookieValue = header.Value.First().Replace($"{Auth.CookieName}=", "");

                var parts = cookieValue.Split(Convert.ToChar(";"));

                var setCookieModel = new AuthCookieModel
                {
                    Value = parts[0].Trim()
                };

                foreach (var part in parts)
                {
                    if (part.Contains("="))
                    {
                        var subParts = part.Split(Convert.ToChar("="));
                        if (subParts[0].ToLowerInvariant().Trim() == "domain")
                        {
                            setCookieModel.Domain = subParts[1].Trim();
                        }
                        if (subParts[0].ToLowerInvariant().Trim() == "path")
                        {
                            setCookieModel.Path = subParts[1].Trim();
                        }
                        if (subParts[0].ToLowerInvariant().Trim() == "expires")
                        {
                            setCookieModel.Expires = subParts[1].Trim();
                        }
                    }
                    else
                    {
                        if (setCookieModel.Value != part.Trim())
                        {
                            setCookieModel.Secure = part.Trim();
                        }
                    }
                }

                return setCookieModel;
            }
            catch (Exception ex)
            {
                var responseString = response.Content.ReadAsStringAsync().Result;
                Debug.WriteLine(responseString);

                throw;
            }
        }

        public IdentityDto GetUserDetails()
        {
            return Execute<IdentityDto>("users/getuserdetails", HttpMethod.Get, null, HttpStatusCode.OK);
        }

        public AuthCookieModel SetUserIdentity(LoginBindingModel loginBindingModel)
        {
            var extraParam = "";
            if (ApiUrl.Contains(".azureedge.net"))
            {
                extraParam = "?comeFromCdn=true";
            }

            var response = GetClient().PostAsJsonWithSnakeCase($"account/login{extraParam}?subscription-key={SubscriptionKey}", loginBindingModel);
            try
            {
                if (response.StatusCode != HttpStatusCode.NoContent)
                {
                    var responseString = response.Content.ReadAsStringAsync().Result;
                    Debug.WriteLine(responseString);
                    return null;
                }

                var header = response.Headers.First(h => h.Key == "Set-Cookie");
                var cookieValue = header.Value.First().Replace($"{Auth.CookieName}=", "");

                var parts = cookieValue.Split(Convert.ToChar(";"));

                var setCookieModel = new AuthCookieModel
                {
                    Value = parts[0].Trim()
                };

                foreach (var part in parts)
                {
                    if (part.Contains("="))
                    {
                        var subParts = part.Split(Convert.ToChar("="));
                        if (subParts[0].ToLowerInvariant().Trim() == "domain")
                        {
                            setCookieModel.Domain = subParts[1].Trim();
                        }
                        if (subParts[0].ToLowerInvariant().Trim() == "path")
                        {
                            setCookieModel.Path = subParts[1].Trim();
                        }
                        if (subParts[0].ToLowerInvariant().Trim() == "expires")
                        {
                            setCookieModel.Expires = subParts[1].Trim();
                        }
                    }
                    else
                    {
                        if (setCookieModel.Value != part.Trim())
                        {
                            setCookieModel.Secure = part.Trim();
                        }
                    }
                }

                return setCookieModel;
            }
            catch (Exception ex)
            {
                var responseString = response.Content.ReadAsStringAsync().Result;
                Debug.WriteLine(responseString);

                throw;
            }
        }

        #endregion

        #endregion

        #region Leads

        public FirmContactInfoDto CreateLead(int origin, List<LeadComponentDto> components)
        {
            return Execute<FirmContactInfoDto>($"firmcontactinfo/CreateLead/{origin}", HttpMethod.Post, components, HttpStatusCode.Created);
        }

        public void CreateSearchEmailLead(SearchEmailLeadDto searchEmailLead)
        {
            Execute<object>("firmcontactinfo/CreateSearchEmailLead", HttpMethod.Post, searchEmailLead, HttpStatusCode.Created);
        }

        #endregion

        #region Clients

        public ClientDto CreateClient(ClientCreateDto clientCreateDto)
        {
            return Execute<ClientDto>("client", HttpMethod.Post, clientCreateDto, HttpStatusCode.Created);
        }

        public IEnumerable<FirmClientDto> ReadClient(int skip = 0, int take = 0, List<ColumnOrder> order = null, bool all = true)
        {
            return Read<FirmClientDto>("client", HttpMethod.Get, null, skip, take, order, true);
        }

        public ClientDto ReadClient(Guid id)
        {
            return Execute<ClientDto>($"client/{id}", HttpMethod.Get, null, HttpStatusCode.OK);
        }

        public ResultDto UpdateClient(ClientUpdateDto clientUpdate)
        {
            return Execute<ResultDto>("client", HttpMethod.Put, clientUpdate, HttpStatusCode.OK);
        }

        public ResultDto DeleteClient(Guid id)
        {
            return Execute<ResultDto>($"client/{id}", HttpMethod.Delete, null, HttpStatusCode.OK);
        }

        #endregion

        #region ClientUsers

        public ClientUserDto CreateClientUser(ClientUserDto firmClient)
        {
            return Execute<ClientUserDto>("clientuser", HttpMethod.Post, firmClient, HttpStatusCode.Created);
        }

        public IEnumerable<ClientUserDto> ReadClientUser(int skip = 0, int take = 0, List<ColumnOrder> order = null, bool all = true)
        {
            return Read<ClientUserDto>("clientuser", HttpMethod.Get, null, skip, take, order, true);
        }

        public ResultDto UpdateClient(ClientUserDto clientUser)
        {
            return Execute<ResultDto>($"clientuser/{clientUser.Id}", HttpMethod.Put, clientUser, HttpStatusCode.OK);
        }

        public ResultDto DeleteClientUser(Guid id)
        {
            return Execute<ResultDto>($"clientuser/{id}", HttpMethod.Delete, null, HttpStatusCode.OK);
        }

        #endregion

        #region Countries

        public IEnumerable<CountryDto> ReadCountry(int skip = 0, int take = 0, List<ColumnOrder> order = null, bool all = true)
        {
            return Read<CountryDto>("countries", HttpMethod.Get, null, skip, take, order, true);
        }

        #endregion

        #region Fee items

        public FirmProductDto CreateFeeItem(FirmProductCreateDto firmProductCreate)
        {
            return Execute<FirmProductDto>("firmproduct", HttpMethod.Post, firmProductCreate, HttpStatusCode.Created);
        }

        public IEnumerable<FirmProductReadDto> ReadFeeItem(int skip = 0, int take = 0, List<ColumnOrder> order = null, bool all = true)
        {
            return Read<FirmProductReadDto>("firmproduct", HttpMethod.Get, null, skip, take, order, true);
        }

        public ResultDto UpdateFeeItem(FirmProductUpdateDto firmProductUpdate)
        {
            return Execute<ResultDto>("firmproduct", HttpMethod.Put, firmProductUpdate, HttpStatusCode.OK);
        }

        public ResultDto DeleteFeeItem(Guid id)
        {
            return Execute<ResultDto>($"firmproduct/{id}", HttpMethod.Delete, null, HttpStatusCode.OK);
        }

        #endregion

        #region Fee items bundle

        public decimal ProductFilterCalculate(string internalName, params string[][] combinations)
        {
            return Execute<decimal>($"firmproductfilter/calculate/{internalName}", HttpMethod.Post, combinations, HttpStatusCode.OK);
        }

        #endregion

        #region Folders

        public FolderReadSingleDto CreateFolder(FolderCreateDto folderCreate)
        {
            return Execute<FolderReadSingleDto>("firmfolder", HttpMethod.Post, folderCreate, HttpStatusCode.Created);
        }

        public FolderDto ReadFolder(Guid folderId)
        {
            return Execute<FolderDto>($"folder/{folderId}", HttpMethod.Get, null, HttpStatusCode.OK);
        }

        public IEnumerable<FolderReadMultipleDto> ReadFolder(int skip = 0, int take = 0, List<ColumnOrder> order = null, bool all = true)
        {
            return Read<FolderReadMultipleDto>("firmfolder", HttpMethod.Get, null, skip, take, order, true);
        }

        public ResultDto UpdateFolder(FolderDto folder)
        {
            return Execute<ResultDto>($"firmfolder/{folder.Id}", HttpMethod.Put, folder, HttpStatusCode.OK);
        }

        public ResultDto DeleteFolder(Guid id)
        {
            return Execute<ResultDto>($"firmfolder/{id}", HttpMethod.Delete, null, HttpStatusCode.OK);
        }

        #endregion

        #region Files

        public FileDto CreateFile(FileCreateDto fileCreateDto)
        {
            return Execute<FileDto>("file", HttpMethod.Post, fileCreateDto, HttpStatusCode.Created);
        }

        public FileDto ReadFile(Guid fileId)
        {
            return Execute<FileDto>($"file/{fileId}", HttpMethod.Get, null, HttpStatusCode.OK);
        }

        public IEnumerable<FileReadDto> ReadFiles(Guid? folderId, int skip = 0, int take = 0, List<ColumnOrder> order = null, bool all = true)
        {
            var url = "file";

            if (folderId.HasValue)
            {
                url = $"firmfolder/{folderId.Value}";
            }
            return Read<FileReadDto>(url, HttpMethod.Get, null, skip, take, order, true);
        }

        public ResultDto UpdateFile(FileUpdateDto fileUpdateDto)
        {
            return Execute<ResultDto>("file", HttpMethod.Put, fileUpdateDto, HttpStatusCode.OK);
        }

        public ResultDto DeleteFile(Guid id)
        {
            return Execute<ResultDto>($"file/{id}", HttpMethod.Delete, null, HttpStatusCode.OK);
        }

        public ResultDto AddNoteIntoFile(Guid fileId, FileNoteCreateDto fileNoteCreate)
        {
            return Execute<ResultDto>($"file/{fileId}/addnote", HttpMethod.Put, fileNoteCreate, HttpStatusCode.OK);
        }

        #endregion

        #region Files attachments

        public FileAttachmentDto CreateFileAttachment(FileAttachmentCreateDto fileAttachmentCreateDto)
        {
            return Execute<FileAttachmentDto>("fileattachment", HttpMethod.Post, fileAttachmentCreateDto, HttpStatusCode.Created);
        }

        public IEnumerable<FileAttachmentDto> ReadFileAttachment(int skip = 0, int take = 0, List<ColumnOrder> order = null, bool all = true)
        {
            return Read<FileAttachmentDto>("fileattachment", HttpMethod.Get, null, skip, take, order, true);
        }

        public ResultDto UpdateFile(FileAttachmentUpdateDto fileAttachmentUpdateDto)
        {
            return Execute<ResultDto>("fileattachment", HttpMethod.Put, null, HttpStatusCode.OK);
        }

        public ResultDto DeleteFileAttachment(Guid id)
        {
            return Execute<ResultDto>($"fileattachment/{id}", HttpMethod.Delete, null, HttpStatusCode.OK);
        }

        #endregion

        #region Files events

        public IEnumerable<FileEventForFolderDto> ReadFileEventsOfFolder(Guid folderId, int skip = 0, int take = 0, List<ColumnOrder> order = null, bool all = true)
        {
            return Read<FileEventForFolderDto>($"fileevent/folder/{folderId}", HttpMethod.Get, null, skip, take, order, true);
        }

        public IEnumerable<FileEventDto> ReadFileEventsOfFile(Guid fileId, int skip = 0, int take = 0, List<ColumnOrder> order = null, bool all = true)
        {
            return Read<FileEventDto>($"fileevent/file/{fileId}", HttpMethod.Get, null, skip, take, order, true);
        }

        #endregion

        #region File status

        public IEnumerable<FileStatusDto> ReadFileStatus(int skip = 0, int take = 0, List<ColumnOrder> order = null, bool all = true)
        {
            return Read<FileStatusDto>("filestatus", HttpMethod.Get, null, skip, take, order, true);
        }

        #endregion

        #region File templates

        public IEnumerable<FileTemplateDto> ReadFileTemplate(int skip = 0, int take = 0, List<ColumnOrder> order = null, bool all = true)
        {
            return Read<FileTemplateDto>("firmfiletemplate", HttpMethod.Get, null, skip, take, order, true);
        }

        #endregion

        #region Currencies

        public IEnumerable<CurrencyDto> ReadCurrency(int skip = 0, int take = 0, List<ColumnOrder> order = null, bool all = true)
        {
            return Read<CurrencyDto>("currency", HttpMethod.Get, null, skip, take, order, true);
        }

        #endregion

        #region InvoiceType

        public IEnumerable<InvoiceTypeDto> ReadInvoiceType(int skip = 0, int take = 0, List<ColumnOrder> order = null, bool all = true)
        {
            return Read<InvoiceTypeDto>("invoicetype", HttpMethod.Get, null, skip, take, order, true);
        }

        #endregion

        #region Invoices

        public InvoiceDto CreateInvoice(InvoiceCreateDto invoiceCreate)
        {
            return Execute<InvoiceDto>("firminvoice", HttpMethod.Post, invoiceCreate, HttpStatusCode.Created);
        }

        public IEnumerable<InvoiceReadDto> ReadInvoice(string entityType = null, Guid? entityId = null, int skip = 0, int take = 0, List<ColumnOrder> order = null, bool all = true)
        {
            var entityTypeParam = string.Empty;
            if (!string.IsNullOrEmpty(entityType))
            {
                entityTypeParam = $"&EntityType={entityType}";
            }

            var entityIdParam = string.Empty;
            if (entityId != null)
            {
                entityIdParam = $"&EntityId={entityId}";
            }

            var url = "firminvoice/";
            if (entityTypeParam != string.Empty && entityIdParam != string.Empty)
            {
                url = $"{url}{entityTypeParam.Replace("&", "?")}{entityIdParam}";
            }
            else
            {
                if (entityTypeParam != string.Empty && entityIdParam == string.Empty)
                {
                    url = $"{url}{entityTypeParam.Replace("&", "?")}";
                }
                else
                {
                    url = $"{url}{entityIdParam.Replace("&", "?")}";
                }
            }

            return Read<InvoiceReadDto>(url, HttpMethod.Get, null, skip, take, order, true);
        }

        public ResultDto UpdateInvoice(InvoiceUpdateDto invoiceUpdate)
        {
            return Execute<ResultDto>("firminvoice", HttpMethod.Put, invoiceUpdate, HttpStatusCode.OK);
        }

        public ResultDto DeleteInvoice(Guid id)
        {
            return Execute<ResultDto>($"firmInvoice/{id}", HttpMethod.Delete, null, HttpStatusCode.OK);
        }

        #endregion

        #region Invoice items

        public InvoiceItemDto CreateInvoiceItem(InvoiceItemCreateDto invoiceItemCreate)
        {
            return Execute<InvoiceItemDto>("invoiceitem", HttpMethod.Post, invoiceItemCreate, HttpStatusCode.Created);
        }

        public IEnumerable<InvoiceItemReadDto> ReadInvoiceItem(string entityType = null, Guid? entityId = null, int skip = 0, int take = 0, List<ColumnOrder> order = null, bool all = true)
        {
            var entityTypeParam = string.Empty;
            if (!string.IsNullOrEmpty(entityType))
            {
                entityTypeParam = $"&EntityType={entityType}";
            }

            var entityIdParam = string.Empty;
            if (entityId != null)
            {
                entityIdParam = $"&EntityId={entityId}";
            }

            var url = "firminvoice/";
            if (entityTypeParam != string.Empty && entityIdParam != string.Empty)
            {
                url = $"{url}{entityTypeParam.Replace("&", "?")}{entityIdParam}";
            }
            else
            {
                if (entityTypeParam != string.Empty && entityIdParam == string.Empty)
                {
                    url = $"{url}{entityTypeParam.Replace("&", "?")}";
                }
                else
                {
                    url = $"{url}{entityIdParam.Replace("&", "?")}";
                }
            }
            
            return Read<InvoiceItemReadDto>(url, HttpMethod.Get, null, skip, take, order, true);
        }

        public ResultDto UpdateInvoiceItem(InvoiceItemUpdateDto invoiceItemUpdate)
        {
            return Execute<ResultDto>($"invoiceitem/{invoiceItemUpdate.Id}", HttpMethod.Put, invoiceItemUpdate, HttpStatusCode.OK);
        }

        public ResultDto DeleteInvoiceItem(Guid id)
        {
            return Execute<ResultDto>($"invoiceitem/{id}", HttpMethod.Delete, null, HttpStatusCode.OK);
        }

        #endregion

        #region Languages

        public IEnumerable<LanguageDto> ReadLanguage(int skip=0, int take=0, List<ColumnOrder> order=null, bool all=true)
        {
            return Read<LanguageDto>("languages", HttpMethod.Get, null, skip, take, order, true);
        }

        #endregion

        #region PaymentMethod

        public IEnumerable<PaymentMethodDto> ReadPaymentMethod(int skip = 0, int take = 0, List<ColumnOrder> order = null, bool all = true)
        {
            return Read<PaymentMethodDto>("paymentmethod", HttpMethod.Get, null, skip, take, order, true);
        }

        #endregion

        #region PaymentTransactionType

        public IEnumerable<PaymentTransactionTypeDto> ReadPaymentTransactionType(int skip = 0, int take = 0, List<ColumnOrder> order = null, bool all = true)
        {
            return Read<PaymentTransactionTypeDto>("paymenttransactiontype", HttpMethod.Get, null, skip, take, order, true);
        }

        #endregion

        #region PaymentProvider

        public IEnumerable<PaymentProviderDto> ReadPaymentProvider(int skip = 0, int take = 0, List<ColumnOrder> order = null, bool all = true)
        {
            return Read<PaymentProviderDto>("paymentprovider", HttpMethod.Get, null, skip, take, order, true);
        }

        #endregion

        #region Payments

        public PaymentDto CreatePayment(PaymentCreateDto paymentCreate)
        {
            return Execute<PaymentDto>("firmpayment", HttpMethod.Post, paymentCreate, HttpStatusCode.Created);
        }

        public IEnumerable<PaymentReadDto> ReadPayment(Guid? invoiceId = null, int skip = 0, int take = 0, List<ColumnOrder> order = null, bool all = true)
        {
            var invoiceIdParam = string.Empty;
            if (invoiceId != null)
            {
                invoiceIdParam = $"&InvoiceId={invoiceId}";
            }

            var url = "firminvoice/";
            if (invoiceIdParam != string.Empty) url = $"{url}?{invoiceIdParam}";

            return Read<PaymentReadDto>(url, HttpMethod.Get, null, skip, take, order, true);
        }

        public ResultDto UpdatePayment(PaymentUpdateDto paymentUpdate)
        {
            return Execute<ResultDto>("firmpayment", HttpMethod.Put, paymentUpdate, HttpStatusCode.OK);
        }

        #endregion

        #region Searches

        public SearchDto CreateSearch(SearchQuery search)
        {
            return Execute<SearchDto>("search", HttpMethod.Post, search, HttpStatusCode.Created);
        }

        public SearchDto GetSearch(Guid searchId)
        {
            return Execute<SearchDto>($"search/{searchId}", HttpMethod.Get, null, HttpStatusCode.OK);
        }

        public SearchStatus GetStatus(Guid searchId)
        {
            return Execute<SearchStatus>($"search/{searchId}/status", HttpMethod.Get, null, HttpStatusCode.OK);
        }

        public IEnumerable<SearchResultDto> GetResults(Guid id)
        {
            return Execute<IEnumerable<SearchResultDto>>($"search/{id}/results", HttpMethod.Get, null, HttpStatusCode.OK, HttpStatusCode.NoContent);
        }

        #endregion

        #region Searches classes

        public IEnumerable<SearchClassDto> ReadSearchClass(int skip = 0, int take = 0, List<ColumnOrder> order = null, bool all = true)
        {
            return Read<SearchClassDto>("searchclasses", HttpMethod.Get, null, skip, take, order, true);
        }

        #endregion

        #region Searches origins

        public IEnumerable<SearchOriginDto> ReadSearchOrigin(int skip = 0, int take = 0, List<ColumnOrder> order = null, bool all = true)
        {
            return Read<SearchOriginDto>("searchorigins", HttpMethod.Get, null, skip, take, order, true);
        }

        #endregion

        #region Taxes

        public IEnumerable<TaxDto> ReadTax(int skip = 0, int take = 0, List<ColumnOrder> order = null, bool all = true)
        {
            return Read<TaxDto>("tax", HttpMethod.Get, null, skip, take, order, true);
        }

        #endregion

        #region Aux entities

        public IEnumerable<SearchClassDto> ReadSearchClasses(int skip = 0, int take = 0, List<ColumnOrder> order = null, bool all = true)
        {
            return Read<SearchClassDto>("searchclasses", HttpMethod.Get, null, skip, take, order, true);
        }

        public IEnumerable<RegistryDto> ReadRegistries(int skip = 0, int take = 0, List<ColumnOrder> order = null, bool all = true)
        {
            return Read<RegistryDto>("registries", HttpMethod.Get, null, skip, take, order, true);
        }

        public IEnumerable<FrequencyDto> ReadFrequencies(int skip = 0, int take = 0, List<ColumnOrder> order = null, bool all = true)
        {
            return Read<FrequencyDto>("frequencies", HttpMethod.Get, null, skip, take, order, true);
        }

        public List<SearchOriginDto> ReadSearchOrigins(int skip = 0, int take = 0, List<ColumnOrder> order = null, bool all = true)
        {
            return Read<SearchOriginDto>("searchorigins", HttpMethod.Get, null, skip, take, order, true);
        }

        #endregion

        #endregion

        #region Private helpers

        private void Initialize(string subscriptionKey, AuthCookieModel authCookieModel, string apiUrl)
        {
            SubscriptionKey = subscriptionKey;
            AuthCookieModel = authCookieModel;
            ApiUrl = apiUrl;

            HttpClient = new HttpClientLawPanel(apiUrl, authCookieModel);
        }

        private HttpClient GetClient()
        {
            var addressUri = new Uri(ApiUrl);
            var cookieContainer = new CookieContainer();

            // Add auth cookie to client
            if (AuthCookieModel != null)
            {
                cookieContainer.Add(addressUri, new Cookie(Auth.CookieName, AuthCookieModel.Value, AuthCookieModel.Path, AuthCookieModel.Domain));
            }

            var httpClientHandler = new HttpClientHandler();
            {
                httpClientHandler.CookieContainer = cookieContainer;
                var client = new HttpClient(httpClientHandler);
                {
                    client.BaseAddress = addressUri;

                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    return client;
                }

            }
        }

        private TReturn Execute<TReturn>(string url, HttpMethod httpMethod, object payload, params HttpStatusCode[] succesHttpStatusCode)
        {
            // Ensure subscription key is present with all queries
            url = EnsureSubscriptionKeyIntoUrl(url);

            HttpResponseMessage response;

            switch (httpMethod)
            {
                case HttpMethod.Get:
                    response = HttpClient.GetAsync(url).Result;
                    break;

                case HttpMethod.Post:
                    response = HttpClient.PostAsJsonWithSnakeCase(url, payload);
                    break;

                case HttpMethod.Put:
                    response = HttpClient.PutAsJsonAsyncWithSnakeCaseAsync(url, payload).Result;
                    break;

                case HttpMethod.Delete:
                    response = HttpClient.DeleteAsync(url).Result;
                    break;

                default: throw new LawPanelException("Invalid HTTP method");
            }

            // Response success?
            if (succesHttpStatusCode.Any(r => r == response.StatusCode))
            {
                var result = response.Content.ReadSnakeCaseToCamelCase<TReturn>();
                return result;
            }

            // Response failed?
            var responseString = response.Content.ReadAsStringAsync().Result;
            throw new LawPanelException(responseString);

        }

        private async Task<TReturn> ExecuteAsync<TReturn>(string url, HttpMethod httpMethod, object payload, params HttpStatusCode[] succesHttpStatusCode)
        {
            // Ensure subscription key is present with all queries
            url = EnsureSubscriptionKeyIntoUrl(url);

            HttpResponseMessage response;

            switch (httpMethod)
            {
                case HttpMethod.Get:
                    response = await HttpClient.GetAsync(url);
                    break;

                case HttpMethod.Post:
                    response = await HttpClient.PostAsJsonWithSnakeCaseAsync(url, payload);
                    break;

                case HttpMethod.Put:
                    response = await HttpClient.PutAsJsonAsyncWithSnakeCaseAsync(url, payload);
                    break;

                case HttpMethod.Delete:
                    response = await HttpClient.DeleteAsync(url);
                    break;

                default: throw new LawPanelException("Invalid HTTP method");
            }

            // Response success?
            if (succesHttpStatusCode.Any(r => r == response.StatusCode))
            {
                var result = response.Content.ReadSnakeCaseToCamelCase<TReturn>();
                return result;
            }

            // Response failed?
            var responseString = await response.Content.ReadAsStringAsync();
            throw new LawPanelException(responseString);
        }
        
        private List<TReturn> Read<TReturn>(string url, HttpMethod httpMethod, object payload, int skip = 0, int take = 0, List<ColumnOrder> orders = null, bool all = false)
        {
            var entities = new List<TReturn>();
            var originalTake = take;
            var originalSkip = skip;

            if(take>100) throw new ArgumentException("Max value of take is 100", nameof(take));

            // Ensure subscription key is present with all queries
            var newUrl = EnsureSubscriptionKeyIntoUrl(url);

            #region Add parameters if exists

            #region Skip
            if (skip > 0)
            {
                newUrl = $"{newUrl}&skip={skip}";
            }
            #endregion

            #region Take
            if (take == 0 && all) take = 100;
            if (take > 0)
            {
                newUrl = $"{newUrl}&take={take}";
            }
            #endregion

            #region Order
            if (orders != null)
            {
                var ordersArray = orders.Select(o => new[] { o.Name, o.Direction == OrderDirection.Asc ? "asc" : "desc" }).ToArray();
                var ordersString = JsonConvert.SerializeObject(ordersArray);

                newUrl = $"{newUrl}&order_by={ordersString}";
            }
            #endregion

            #endregion

            HttpResponseMessage response;

            #region Execute by http method
            switch (httpMethod)
            {
                case HttpMethod.Get:
                    response = HttpClient.GetAsync(newUrl).Result;
                    break;

                case HttpMethod.Post:
                    response = HttpClient.PostAsJsonWithSnakeCaseAsync(newUrl, payload).Result;
                    break;

                case HttpMethod.Put:
                    response = HttpClient.PutAsJsonAsyncWithSnakeCaseAsync(newUrl, payload).Result;
                    break;

                case HttpMethod.Delete:
                    response = HttpClient.DeleteAsync(newUrl).Result;
                    break;

                default: throw new LawPanelException("Invalid HTTP method");
            }
            #endregion

            #region No contents?
            if (response.StatusCode == HttpStatusCode.NoContent) return entities;
            #endregion

            #region Error?
            if (!response.IsSuccessStatusCode)
            {
                var responseString = response.Content.ReadAsStringAsync().Result;
                throw new LawPanelException(responseString);
            }
            #endregion

            #region Read entities 
            entities = response.Content.ReadSnakeCaseToCamelCase<List<TReturn>>();
            #endregion




            // If not all 
            if (!all || (originalTake>0)) return entities;

            #region Read to the end?

            var total = response.Headers.GetValues("Total").FirstOrDefault() == null ? 0 : int.Parse(response.Headers.GetValues("Total").FirstOrDefault());
            var skipped = response.Headers.GetValues("Skipped").FirstOrDefault() == null ? 0 : int.Parse(response.Headers.GetValues("Skipped").FirstOrDefault());
            var taken = response.Headers.GetValues("Taken").FirstOrDefault() == null ? 0 : int.Parse(response.Headers.GetValues("Taken").FirstOrDefault());
            var top = skipped + taken;
            if (top < total)
            {
                entities.AddRange(Read<TReturn>(url, httpMethod, payload, skip + taken, originalTake, orders, true));
            }

            #endregion

            return entities;
        }

        private async Task<List<TReturn>> ReadAsync<TReturn>(string url, HttpMethod httpMethod, object payload, int skip = 0, int take = 0, List<ColumnOrder> orders = null, bool readToTheEnd = false)
        {
            var entities = new List<TReturn>();

            // Ensure subscription key is present with all queries
            url = EnsureSubscriptionKeyIntoUrl(url);

            #region Add parameters if exists

            #region Skip
            if (skip > 0)
            {
                url = $"{url}&skip={skip}";
            }
            #endregion

            #region Take
            if (take > 0)
            {
                url = $"{url}&take={take}";
            }
            #endregion

            #region Order
            if (orders != null)
            {
                var ordersArray = orders.Select(o => new[] { o.Name, o.Direction == OrderDirection.Asc ? "asc" : "desc" }).ToArray();
                var ordersString = JsonConvert.SerializeObject(ordersArray);

                url = $"{url}&orders={ordersString}";
            }
            #endregion

            #endregion
            
            HttpResponseMessage response;

            #region Execute by http method
            switch (httpMethod)
            {
                case HttpMethod.Get:
                    response = await HttpClient.GetAsync(url);
                    break;

                case HttpMethod.Post:
                    response = await HttpClient.PostAsJsonWithSnakeCaseAsync(url, payload);
                    break;

                case HttpMethod.Put:
                    response = await HttpClient.PutAsJsonAsyncWithSnakeCaseAsync(url, payload);
                    break;

                case HttpMethod.Delete:
                    response = await HttpClient.DeleteAsync(url);
                    break;

                default: throw new LawPanelException("Invalid HTTP method");
            }
            #endregion

            #region No contents?
            if (response.StatusCode == HttpStatusCode.NoContent) return entities;
            #endregion

            #region Error?
            if (!response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                throw new LawPanelException(responseString);
            }
            #endregion

            #region Read entities 
            entities = response.Content.ReadSnakeCaseToCamelCase<List<TReturn>>();
            #endregion

            if (!readToTheEnd) return entities;

            #region Read to the end?

            var total = 0;
            var skipped = 0;
            var taken = 0;

            foreach (var httpResponseHeader in response.Headers)
            {
                #region Total
                if (httpResponseHeader.Key == "total")
                {
                    total = int.Parse(httpResponseHeader.Value.ToString());
                }
                #endregion

                #region Skipped
                if (httpResponseHeader.Key == "skipped")
                {
                    skipped = int.Parse(httpResponseHeader.Value.ToString());
                }
                #endregion

                #region Taken
                if (httpResponseHeader.Key == "taken")
                {
                    taken = int.Parse(httpResponseHeader.Value.ToString());
                }
                #endregion
            }

            var top = skipped + taken;
            if (top < total)
            {
                entities.AddRange(await ReadAsync<TReturn>(url, httpMethod, payload, skip + taken, take, orders, true));
            }

            #endregion

            return entities;
        }

        private string EnsureSubscriptionKeyIntoUrl(string url)
        {
            if (!url.Contains(SubscriptionKeyParamName))
            {
                url = url.Contains("?") ?
                    $"{url}&{SubscriptionKeyParamName}={SubscriptionKey}" :
                    $"{url}?{SubscriptionKeyParamName}={SubscriptionKey}";
            }

            return url;
        }

        #endregion
    }
}