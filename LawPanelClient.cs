using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using LawPanel.ApiClient.Constants;
using LawPanel.ApiClient.Enums;
using LawPanel.ApiClient.Exceptions;
using LawPanel.ApiClient.Extensions;
using LawPanel.ApiClient.Interfaces;
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

namespace LawPanel.ApiClient
{
    public class LawPanelClient : ILawPanelClient
    {
        #region Private properties
        private string              ApiUrl          { get; set; }
        private string              SubscriptionKey { get; set; }
        private AuthCookieModel     AuthCookieModel { get; set; }
        public bool                 UseProxy        { get; set; }

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

        /// <summary>
        /// Get trademark by application number 
        /// </summary>
        /// <param name="registry">Name of the registry (UK, USPTO, EUIPO, etc.)</param>
        /// <param name="applicationNumber">Application of the trademark</param>
        /// <returns></returns>
        public TrademarkDto TrademarkByApplicationNumber(string registry, string applicationNumber)
        {
            using (var client = GetClient())
            {
                var response = client.GetAsync($"trademark/{registry}/{applicationNumber}?subscription-key=" + SubscriptionKey);
                try
                {
                    if (response.Result.StatusCode == HttpStatusCode.OK)
                    {
                        var result = response.Result.Content.ReadAsAsync<TrademarkDto>();
                        return result;
                    }
                }
                catch (Exception ex)
                {
                    //Log
                    //ex.LogToElmah();
                    throw;
                }
                return null;
            }
        }

        public IEnumerable<TrademarkDto> TrademarkSearchByText(string txt)
        {
            using (var client = GetClient())
            {
                var response = client.GetAsync($"trademark/SearchByText/{txt}?subscription-key=" + SubscriptionKey);
                try
                {
                    if (response.Result.StatusCode == HttpStatusCode.OK)
                    {
                        var result = response.Result.Content.ReadAsAsync<IEnumerable<TrademarkDto>>();
                        return result;
                    }
                }
                catch (Exception ex)
                {
                    //Log
                    //ex.LogToElmah();
                    throw;
                }
                return null;
            }
        }

        public IEnumerable<TrademarkDto> TrademarksByIds(int[] ids)
        {
            using (var client = GetClient())
            {
                var response = client.PostAsJsonAsyncWithSnakeCase("trademark/SearchByIds?subscription-key=" + SubscriptionKey, 
                
                    ids
                );
                try
                {
                    if (response.Result.StatusCode == HttpStatusCode.OK)
                    {
                        var result = response.Result.Content.ReadAsAsync<IEnumerable<TrademarkDto>>();
                        return result;
                    }
                }
                catch (Exception ex)
                {
                    //Log
                    //ex.LogToElmah();
                    throw;
                }
                return null;
            }
        }

        public TrademarkDto TrademarksByWordMarkId(int id)
        {
            using (var client = GetClient())
            {
                var response = client.PostAsJsonAsyncWithSnakeCase("trademark/SearchByWorkMarkId?subscription-key=" + SubscriptionKey, new
                {
                    id
                });
                try
                {
                    if (response.Result.StatusCode == HttpStatusCode.OK)
                    {
                        var result = response.Result.Content.ReadAsAsync<TrademarkDto>();
                        return result;
                    }
                }
                catch (Exception ex)
                {
                    //Log
                    //ex.LogToElmah();
                    throw;
                }
                return null;
            }
        }
        
        public IEnumerable<TrademarkDto> TrademarksBySearch(SearchQuery search)
                {
                    using (var client = GetClient())
                    {
                        var response = client.PostAsJsonAsyncWithSnakeCase("trademark/Search?subscription-key=" + SubscriptionKey, new
                        {
                            search.SearchTerm,
                            search.Classes,
                            search.Registry,
                            search.Weighting,
                            search.Type
                        });
                        try
                        {
                            if (response.Result.StatusCode == HttpStatusCode.OK)
                            {
                                var result = response.Result.Content.ReadAsAsync<IEnumerable<TrademarkDto>>();
                                return result;
                            }
                        }
                        catch (Exception ex)
                        {
                            //Log
                            //ex.LogToElmah();
                            throw;
                        }
                        return null;
                    }
                }

        public IEnumerable<TrademarkDto> TrademarkSearchByMultipleCriteria(string txt)
        {
            using (var client = GetClient())
            {
                var url = $"trademark/searchbymultiplecriteria/{txt}?order_by=mark_text&subscription-key=" + SubscriptionKey;
                                      
                var response = client.GetAsync(url);
                try
                {
                    if (response.Result.StatusCode == HttpStatusCode.OK)
                    {
                        var result = response.Result.Content.ReadAsAsync<IEnumerable<TrademarkDto>>();
                        return result;
                    }
                }
                catch (Exception ex)
                {
                    //Log
                    //ex.LogToElmah();
                    throw;
                }
                return null;
            }
        }

        public IEnumerable<TrademarkDto> TrademarkListFromLetters(int skip, int take, string registry, string startWith, bool exactLetter)
        {
            using (var client = GetClient())
            {
                var url = $"trademark/filteredlist?skip={skip}&take={take}&registry={registry}&startWith={startWith}&exactLetter={exactLetter}&subscription-key=" + SubscriptionKey;

                var response = client.GetAsync(url);
                try
                {
                    if (response.Result.StatusCode == HttpStatusCode.OK)
                    {
                        var result = response.Result.Content.ReadAsAsync<IEnumerable<TrademarkDto>>();
                        return result;
                    }
                }
                catch (Exception ex)
                {
                    //Log
                    //ex.LogToElmah();
                    throw;
                }
                return null;
            }
        }

        public IEnumerable<string> TrademarkLetters(string startWith, int len, string registry)
        {
            using (var client = GetClient())
            {
                var url = $"trademark/letters?startWith={startWith}&registry={registry}&len={len}&subscription-key=" + SubscriptionKey;

                var response = client.GetAsync(url);
                try
                {
                    if (response.Result.StatusCode == HttpStatusCode.OK)
                    {
                        var result = response.Result.Content.ReadAsAsync<IEnumerable<string>>();
                        return result;
                    }
                }
                catch (Exception ex)
                {
                    //Log
                    //ex.LogToElmah();
                    throw;
                }
                return null;
            }
        }

        public int TrademarkCountByLetter(string startWith, int len, string registry)
        {
            using (var client = GetClient())
            {
                var url = $"trademark/countbyletter?startWith={startWith}&registry={registry}&len={len}&subscription-key=" + SubscriptionKey;

                var response = client.GetAsync(url);
                try
                {
                    if (response.Result.StatusCode == HttpStatusCode.OK)
                    {
                        var result = response.Result.Content.ReadAsAsync<int>();
                        return result;
                    }
                }
                catch (Exception ex)
                {
                    //Log
                    //ex.LogToElmah();
                    throw;
                }
                return 0;
            }
        }

        #endregion

        #region Watching

        public WatchingDto CreateWatching(WatchingDto watching)
        {
            using (var client = GetClient())
            {
                var response = client.PostAsJsonAsyncWithSnakeCase("watching?subscription-key=" + SubscriptionKey, watching);
                try
                {
                    if (response.Result.StatusCode == HttpStatusCode.Created)
                    {
                        return response.Result.Content.ReadSnakeCaseToCamelCase<WatchingDto>();
                    }

                    var responseString = response.Result.Content.ReadAsStringAsync().Result;
                    Debug.WriteLine(responseString);
                }
                catch (Exception ex)
                {
                    
                        
                    throw;
                }
                return null;
            }
        }

        public async Task<IEnumerable<WatchingDto>> ReadWatchings()
        {
            using (var client = GetClient())
            {
                var response = await client.GetAsync("watching/?order_by=trademark&subscription-key=" + SubscriptionKey);
                try
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = response.Content.ReadSnakeCaseToCamelCase<IEnumerable<WatchingDto>>();
                        return result;
                    }

                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return new List<WatchingDto>();
                    }

                    if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.InternalServerError)
                    {

                        var responseString = await response.Content.ReadAsStringAsync();

                        Debug.WriteLine(responseString);
                    }

                }
                catch (Exception ex)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine(responseString);

                    throw;
                }
                return null;
            }
        }

        public ResultDto UpdateWatching(WatchingDto watching)
        {
            using (var client = GetClient())
            {
                var response = client.PutAsJsonAsyncWithSnakeCase($"watching?subscription-key={SubscriptionKey}", watching);
                try
                {
                    if (response.Result.StatusCode == HttpStatusCode.OK)
                    {
                        return response.Result.Content.ReadSnakeCaseToCamelCase<ResultDto>();
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
                return null;
            }
        }

        public ResultDto DeleteWatching(Guid id)
        {
            using (var client = GetClient())
            {
                var response = client.DeleteAsync($"watching/{id}?subscription-key=" + SubscriptionKey);
                try
                {
                    if (response.Result.StatusCode == HttpStatusCode.OK)
                    {
                        return response.Result.Content.ReadSnakeCaseToCamelCase<ResultDto>();
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
                return null;
            }
        }

        public async Task CreateWatchingBundle(List<WatchingBundleDto> watchingBundles)
        {
            using (var client = GetClient())
            {
                try
                {
                    var response = await client.PostAsJsonAsyncWithSnakeCase("watching/addbundle?subscription-key=" + SubscriptionKey, watchingBundles);
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        throw new Exception(response.Content.ReadAsStringAsync().Result);
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        #endregion

        #region FirmPortfolio
        public FirmPortfolioDto CreateFirmPortfolio(FirmPortfolioDto portfolioDto)
        {
            using (var client = GetClient())
            {
                var response = client.PostAsJsonAsyncWithSnakeCase("firmportfolio?subscription-key=" + SubscriptionKey, portfolioDto);
                try
                {
                    if (response.Result.StatusCode == HttpStatusCode.Created)
                    {
                        return response.Result.Content.ReadSnakeCaseToCamelCase<FirmPortfolioDto>();
                    }

                    var responseString = response.Result.Content.ReadAsStringAsync().Result;
                    Debug.WriteLine(responseString);
                }
                catch (Exception ex)
                {

                    throw;
                }
                return null;
            }
        }

        public async Task<IEnumerable<FirmPortfolioReadDto>> ReadFirmPortfolios()
        {
            using (var client = GetClient())
            {
                var response = await client.GetAsync("firmportfolio/?order_by=mark_text&subscription-key=" + SubscriptionKey);
                try
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = response.Content.ReadSnakeCaseToCamelCase<IEnumerable<FirmPortfolioReadDto>>();
                        return result;
                    }

                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return new List<FirmPortfolioReadDto>();
                    }

                    if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.InternalServerError)
                    {

                        var responseString = await response.Content.ReadAsStringAsync();

                        Debug.WriteLine(responseString);
                    }

                }
                catch (Exception ex)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine(responseString);

                    throw;
                }
                return null;
            }
        }

        public ResultDto UpdateFirmPortfolio(FirmPortfolioDto firmPortfolioDto)
        {
            using (var client = GetClient())
            {
                var response = client.PutAsJsonAsyncWithSnakeCase($"firmportfolio?subscription-key={SubscriptionKey}", firmPortfolioDto);
                try
                {
                    if (response.Result.StatusCode == HttpStatusCode.OK)
                    {
                        return response.Result.Content.ReadSnakeCaseToCamelCase<ResultDto>();
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
                return null;
            }
        }

        public ResultDto DeleteFirmPortfolio(Guid id)
        {
            using (var client = GetClient())
            {
                var response = client.DeleteAsync($"firmportfolio/{id}?subscription-key=" + SubscriptionKey);
                try
                {
                    if (response.Result.StatusCode == HttpStatusCode.OK)
                    {
                        return response.Result.Content.ReadSnakeCaseToCamelCase<ResultDto>();
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
                return null;
            }
        }

        public void CreatePortfolioBundle(List<FirmPortfolioBundle> firmPortfolioBundles)
        {
            using (var client = GetClient())
            {
                try
                {
                    var response = client.PostAsJsonAsyncWithSnakeCase("firmportfolio/addbundle?subscription-key=" + SubscriptionKey, firmPortfolioBundles).Result;
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        throw new Exception(response.Content.ReadAsStringAsync().Result);
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
        #endregion

        #region Watchings users settings

        public WatchingUserSettingsDto CreateWatchingUserSettings(WatchingUserSettingsDto watchingUserSettingsDto)
                {
                    using (var client = GetClient())
                    {
                        var response = client.PostAsJsonAsyncWithSnakeCase("watchingusersettings?subscription-key=" + SubscriptionKey, watchingUserSettingsDto);
                        try
                        {
                            if (response.Result.StatusCode == HttpStatusCode.Created)
                            {
                                return response.Result.Content.ReadSnakeCaseToCamelCase<WatchingUserSettingsDto>();
                            }
                        }
                        catch (Exception ex)
                        {
                            throw;
                        }
                        return null;
                    }
                }

        public WatchingUserSettingsDto ReadWatchingUserSettings()
        {
            using (var client = GetClient())
            {
                var response = client.GetAsync("watchingusersettings/mysettings?use_lawpanel_query_syntax=true&subscription-key=" + SubscriptionKey);
                try
                {
                    if (response.Result.StatusCode == HttpStatusCode.OK)
                    {
                        return response.Result.Content.ReadSnakeCaseToCamelCase<WatchingUserSettingsDto>();
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
                return null;
            }
        }

        public ResultDto UpdateWatchingUserSettings(WatchingUserSettingsDto watchingUserSettingsDto)
        {
            using (var client = GetClient())
            {
                var response = client.PutAsJsonAsyncWithSnakeCase($"watchingusersettings?subscription-key={SubscriptionKey}", watchingUserSettingsDto);
                try
                {
                    if (response.Result.StatusCode == HttpStatusCode.OK)
                    {
                        return response.Result.Content.ReadSnakeCaseToCamelCase<ResultDto>();
                    }

                    if (response.Result.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        var resultDto = response.Result.Content.ReadAsAsync<ResultDto>();
                        throw new Exception(resultDto.Message);
                    }

                }
                catch (Exception ex)
                {
                    throw;
                }
                return null;
            }
        }

        public ResultDto DeleteWatchingUserSettings(Guid id)
        {
            using (var client = GetClient())
            {
                var response = client.DeleteAsync($"watchingusersettings/{id}?subscription-key=" + SubscriptionKey);
                try
                {
                    if (response.Result.StatusCode == HttpStatusCode.OK)
                    {
                        return response.Result.Content.ReadSnakeCaseToCamelCase<ResultDto>();
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
                return null;
            }
        }

        #endregion

        #region Firms

        /// <summary>
        /// Returns the API key for current user
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetFirmApiKey()
        {
            using (var client = GetClient())
            {
                var url = "firms/apikey?firmId=" + default(Guid);
                var result = await client.GetAsync(url);
                try
                {
                    if (result.StatusCode == HttpStatusCode.OK) {
                        return  result.Content.ReadSnakeCaseToCamelCase<string>();
                    }

                    var resultString = await result.Content.ReadAsStringAsync();
                    Debug.WriteLine(resultString);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return null;
        }

        #endregion

        #region Firms statistics

        public DashboardStatisticsModel ReadFirmStatisticsDashboard()
        {
            using (var client = GetClient())
            {
                var url = $"firmstatistics/dashboard?subscription-key={SubscriptionKey}";
                var response = client.GetAsync(url).Result;
                try
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = response.Content.ReadSnakeCaseToCamelCase<DashboardStatisticsModel>();
                        return result;
                    }

                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return new DashboardStatisticsModel();
                    }

                    if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        var responseString = response.Content.ReadAsStringAsync().Result;
                        Debug.WriteLine(responseString);
                    }
                }
                catch (Exception ex)
                {
                    var responseString = response.Content.ReadAsStringAsync().Result;
                    Debug.WriteLine(responseString);

                    throw;
                }
                return null;
            }
        }

        #endregion

        #region Account

        public UserDto AccountRegister(RegisterDto registerDto)
        {
            using (var client = GetClient())
            {
                var response = client.PostAsJsonAsyncWithSnakeCase("account/register", registerDto);
                try
                {
                    if (response.Result.StatusCode == HttpStatusCode.OK)
                    {
                        return response.Result.Content.ReadSnakeCaseToCamelCase<UserDto>();
                    }
                }
                catch (Exception ex)
                {
                    //Log
                    //ex.LogToElmah();
                    throw;
                }
            }
            return null;
        }

        public UserDto AccountRegisterFromMobile(RegisterDto registerDto)
        {
            using (var client = GetClient())
            {
                var response = client.PostAsJsonAsyncWithSnakeCase("account/registerfrommobile", registerDto);
                try
                {
                    if (response.Result.StatusCode == HttpStatusCode.OK)
                    {
                        return response.Result.Content.ReadSnakeCaseToCamelCase<UserDto>();
                    }
                    else
                    {
                        var responseContents = response.Result.Content.ReadAsStringAsync().Result;


                    }
                }
                catch (Exception ex)
                {
                    //Log
                    //ex.LogToElmah();
                    throw;
                }
            }
            return null;
        }

        public bool AccountEmailIsAvailableToRegister(string email)
        {
            using (var client = GetClient())
            {
                var response = client.GetAsync($"account/emailisavailabletoregister?email={email}");
                try
                {
                    var result = response.Result;
                    if (result.StatusCode == HttpStatusCode.OK)
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    //Log
                    //ex.LogToElmah();
                    throw;
                }
            }
            return false;
        }

        public bool AccountTenantIsAvailableToRegister(string tenant)
        {
            using (var client = GetClient())
            {
                var response = client.GetAsync($"account/tenantisavailabletoregister/{tenant}");
                try
                {
                    var result = response.Result;
                    if (result.StatusCode == HttpStatusCode.OK)
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    //Log
                    //ex.LogToElmah();
                    throw;
                }
            }
            return false;
        }
            
        #endregion

        #region Users

        public UserLoginDetailsDto GetUserLoginDetails(LoginBindingModel loginBindingModel)
        {
            using (var client = GetClient())
            {
                var response = client.PostAsJsonAsyncWithSnakeCase("account/login?subscription-key=" + SubscriptionKey, loginBindingModel);
                try
                {
                    // If it is 204 No Content and has the authentication cookie then 
                    // the two factor is disabled and the user is already authenticated.
                    if (response.Result.StatusCode == HttpStatusCode.NoContent)
                    {
                        return new UserLoginDetailsDto { IsTwoFactorAuthentication = false };
                    }

                    // If it is 200 OK then the payload contains the possible two factor 
                    // providers (email, SMS). The user must select one and send back 
                    // their choice to continue the workflow.
                    if (response.Result.StatusCode == HttpStatusCode.OK)
                    {
                        // Read authentication providers
                        var twoFactorAuthenticationProviders = response.Result.Content.ReadSnakeCaseToCamelCase<List<TwoFactorAuthenticationProviderDto>>();

                        return new UserLoginDetailsDto
                        {
                            IsTwoFactorAuthentication = true,
                            TwoFactorAuthenticationProviderDtos = twoFactorAuthenticationProviders
                        };
                    }

                    return null;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        #region User identity

        public async Task<AuthCookieModel> SetUserIdentityAsync(LoginBindingModel loginBindingModel)
        {
            using (var client = GetClient())
            {

                var extraParam = "";
                if (ApiUrl.Contains(".azureedge.net"))
                {
                    extraParam = "?comeFromCdn=true";
                }


                var response = await client.PostAsJsonAsyncWithSnakeCase($"account/login{extraParam}", loginBindingModel);
                try
                {
                    if (response.StatusCode != HttpStatusCode.NoContent)
                    {
                        var responseString = response.Content.ReadAsStringAsync().Result;
                        Debug.WriteLine(responseString);
                        return null;
                    }

                    var header = response.Headers.First(h=>h.Key=="Set-Cookie");
                    var cookieValue = header.Value.First().Replace($"{Auth.CookieName}=","");
                        
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
        }

        public IdentityDto GetUserDetails()
        {
            using (var client = GetClient())
            {
                var response = client.GetAsync("users/getuserdetails?subscription-key=" + SubscriptionKey);
                try
                {
                    if (response.Result.StatusCode == HttpStatusCode.OK)
                    {
                        return response.Result.Content.ReadSnakeCaseToCamelCase<IdentityDto>();
                    }
                }
                catch (Exception ex)
                {
                    //Log
                    //ex.LogToElmah();
                    throw;
                }
            }
            return null;
        }

        public AuthCookieModel SetUserIdentity(LoginBindingModel loginBindingModel)
        {
            using (var client = GetClient())
            {

                var extraParam = "";
                if (ApiUrl.Contains(".azureedge.net"))
                {
                    extraParam = "?comeFromCdn=true";
                }
                var response = client.PostAsJsonWithSnakeCase($"account/login{extraParam}", loginBindingModel);
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
        }

        #endregion

        #endregion

        #region Leads

        public FirmContactInfoDto CreateLead(int origin, List<LeadComponentDto> components)
        {
            using (var client = GetClient())
            {
                var response = client.PostAsJsonAsyncWithSnakeCase($"firmcontactinfo/CreateLead/{origin}?subscription-key=" + SubscriptionKey, components);
                try
                {
                    if (response.Result.StatusCode == HttpStatusCode.Created)
                    {
                        return response.Result.Content.ReadSnakeCaseToCamelCase<FirmContactInfoDto>();
                    }
                }
                catch (Exception ex)
                {
                    //Log
                    //ex.LogToElmah();
                    throw;
                }
            }
            return null;
        }

        public void CreateSearchEmailLead(SearchEmailLeadDto searchEmailLead)
        {
            using (var client = GetClient())
            {
                var response = client.PostAsJsonAsyncWithSnakeCase($"firmcontactinfo/CreateSearchEmailLead?subscription-key=" + SubscriptionKey, searchEmailLead);
                try
                {
                    if (response.Result.StatusCode == HttpStatusCode.Created)
                    {
                        // Ok
                    }
                }
                catch (Exception ex)
                {
                    //Log
                    //ex.LogToElmah();
                    throw;
                }
            }
        }

        #endregion

        #region Clients

        public ClientDto CreateClient(ClientCreateDto clientCreateDto)
        {
            using (var httpClient = GetClient())
            {
                var response = httpClient.PostAsJsonAsyncWithSnakeCase("client?subscription-key=" + SubscriptionKey, clientCreateDto);
                if (response.Result.StatusCode == HttpStatusCode.Created)
                {
                    return response.Result.Content.ReadSnakeCaseToCamelCase<ClientDto>();
                }

                var responseString = response.Result.Content.ReadAsStringAsync().Result;
                throw new LawPanelException(responseString);
            }
        }

        public IEnumerable<FirmClientDto> ReadClient()
        {
            using (var client = GetClient())
            {
                var url = $"client/?subscription-key={SubscriptionKey}";
                var response = client.GetAsync(url).Result;
                try
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = response.Content.ReadSnakeCaseToCamelCase<IEnumerable<FirmClientDto>>();
                        return result;
                    }

                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return new List<FirmClientDto>();
                    }

                    if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        var responseString = response.Content.ReadAsStringAsync().Result;
                        Debug.WriteLine(responseString);
                    }
                }
                catch (Exception ex)
                {
                    var responseString = response.Content.ReadAsStringAsync().Result;
                    Debug.WriteLine(responseString);

                    throw;
                }
                return null;
            }
        }

        public ClientDto ReadClient(Guid id)
        {
            using (var client = GetClient())
            {
                var url = $"client/{id}?subscription-key={SubscriptionKey}";
                var response = client.GetAsync(url).Result;
                try
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = response.Content.ReadSnakeCaseToCamelCase<ClientDto>();
                        return result;
                    }

                    if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        var responseString = response.Content.ReadAsStringAsync().Result;
                        Debug.WriteLine(responseString);
                    }
                }
                catch (Exception)
                {
                    var responseString = response.Content.ReadAsStringAsync().Result;
                    Debug.WriteLine(responseString);

                    throw;
                }
                return null;
            }
        }

        public ResultDto UpdateClient(ClientUpdateDto clientUpdate)
        {
            using (var client = GetClient())
            {
                var response = client.PutAsJsonAsyncWithSnakeCase($"client?subscription-key={SubscriptionKey}", clientUpdate);
                return response.Result.StatusCode == HttpStatusCode.OK ?
                            response.Result.Content.ReadSnakeCaseToCamelCase<ResultDto>() :
                            null;
            }
        }

        public ResultDto DeleteClient(Guid id)
        {
            using (var client = GetClient())
            {
                var response = client.DeleteAsync($"client/{id}?subscription-key=" + SubscriptionKey);
                try
                {
                    if (response.Result.StatusCode == HttpStatusCode.OK)
                    {
                        return response.Result.Content.ReadSnakeCaseToCamelCase<ResultDto>();
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
                return null;
            }
        }

        #endregion

        #region ClientUsers

        public ClientUserDto CreateClientUser(ClientUserDto firmClient)
        {
            using (var client = GetClient())
            {
                var response = client.PostAsJsonAsyncWithSnakeCase("clientuser?subscription-key=" + SubscriptionKey, firmClient);
                try
                {
                    if (response.Result.StatusCode == HttpStatusCode.Created)
                    {
                        return response.Result.Content.ReadSnakeCaseToCamelCase<ClientUserDto>();
                    }
                    var responseString = response.Result.Content.ReadAsStringAsync().Result;
                    Debug.WriteLine(responseString);
                }
                catch (Exception ex)
                {
                    throw;
                }
                return null;
            }
        }

        public async Task<IEnumerable<ClientUserDto>> ReadClientUser()
        {
            using (var client = GetClient())
            {
                var url = $"clientuser/?subscription-key={SubscriptionKey}";
                var response = await client.GetAsync(url);
                try
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = response.Content.ReadSnakeCaseToCamelCase<IEnumerable<ClientUserDto>>();
                        return result;
                    }

                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return new List<ClientUserDto>();
                    }

                    if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        var responseString = await response.Content.ReadAsStringAsync();
                        Debug.WriteLine(responseString);
                    }
                }
                catch (Exception ex)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine(responseString);

                    throw;
                }
                return null;
            }
        }

        public ResultDto UpdateClient(ClientUserDto clientUser)
        {
            using (var client = GetClient())
            {
                var response = client.PutAsJsonAsyncWithSnakeCase($"clientuser/{clientUser.Id}?subscription-key={SubscriptionKey}", clientUser);
                return response.Result.StatusCode == HttpStatusCode.OK ?
                            response.Result.Content.ReadSnakeCaseToCamelCase<ResultDto>() :
                            null;
            }
        }

        public ResultDto DeleteClientUser(Guid id)
        {
            using (var client = GetClient())
            {
                var response = client.DeleteAsync($"clientuser/{id}?subscription-key=" + SubscriptionKey);
                try
                {
                    if (response.Result.StatusCode == HttpStatusCode.OK)
                    {
                        return response.Result.Content.ReadSnakeCaseToCamelCase<ResultDto>();
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
                return null;
            }
        }

        #endregion

        #region Countries

        public IEnumerable<CountryDto> ReadCountry()
        {
            using (var client = GetClient())
            {
                var url = $"countries?subscription-key={SubscriptionKey}";
                var response = client.GetAsync(url).Result;
                try
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = response.Content.ReadSnakeCaseToCamelCase<IEnumerable<CountryDto>>();
                        return result;
                    }

                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return new List<CountryDto>();
                    }

                    if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        var responseString = response.Content.ReadAsStringAsync().Result;
                        Debug.WriteLine(responseString);
                    }
                }
                catch (Exception ex)
                {
                    var responseString = response.Content.ReadAsStringAsync().Result;
                    Debug.WriteLine(responseString);

                    throw;
                }
                return null;
            }
        }

        #endregion

        #region Fee items

        public FirmProductDto CreateFeeItem(FirmProductCreateDto firmProductCreate)
        {
            using (var client = GetClient())
            {
                var response = client.PostAsJsonAsyncWithSnakeCase("firmproduct?subscription-key=" + SubscriptionKey, firmProductCreate);
                try
                {
                    if (response.Result.StatusCode == HttpStatusCode.Created)
                    {
                        return response.Result.Content.ReadSnakeCaseToCamelCase<FirmProductDto>();
                    }
                    var responseString = response.Result.Content.ReadAsStringAsync().Result;
                    Debug.WriteLine(responseString);
                }
                catch (Exception ex)
                {
                    throw;
                }
                return null;
            }
        }

        public IEnumerable<FirmProductReadDto> ReadFeeItem()
        {
            using (var client = GetClient())
            {
                var url = $"firmproduct?subscription-key={SubscriptionKey}";
                var response = client.GetAsync(url).Result;
                try
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = response.Content.ReadSnakeCaseToCamelCase<IEnumerable<FirmProductReadDto>>();
                        return result;
                    }

                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return new List<FirmProductReadDto>();
                    }

                    if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        var responseString = response.Content.ReadAsStringAsync().Result;
                        Debug.WriteLine(responseString);
                    }
                }
                catch (Exception ex)
                {
                    var responseString = response.Content.ReadAsStringAsync().Result;
                    Debug.WriteLine(responseString);

                    throw;
                }
                return null;
            }
        }

        public ResultDto UpdateFeeItem(FirmProductUpdateDto firmProductUpdate)
        {
            using (var client = GetClient())
            {
                var response = client.PutAsJsonAsyncWithSnakeCase($"firmproduct?subscription-key={SubscriptionKey}", firmProductUpdate);
                return response.Result.StatusCode == HttpStatusCode.OK ?
                            response.Result.Content.ReadSnakeCaseToCamelCase<ResultDto>() :
                            null;
            }
        }

        public ResultDto DeleteFeeItem(Guid id)
        {
            using (var client = GetClient())
            {
                var response = client.DeleteAsync($"firmproduct/{id}?subscription-key=" + SubscriptionKey);
                try
                {
                    if (response.Result.StatusCode == HttpStatusCode.OK)
                    {
                        return response.Result.Content.ReadSnakeCaseToCamelCase<ResultDto>();
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
                return null;
            }
        }

        #endregion

        #region Fee items bundle

        public decimal ProductFilterCalculate(string internalName, params string[][] combinations)
        {
            using (var client = GetClient())
            {
                var url = $"firmproductfilter/calculate/{internalName}?subscription-key={SubscriptionKey}";
                var response = client.PostAsJsonAsyncWithSnakeCase(url, combinations);
                if (response.Result.StatusCode == HttpStatusCode.OK)
                {
                    return response.Result.Content.ReadAsAsync<decimal>();
                }

                var responseString = response.Result.Content.ReadAsStringAsync().Result;
                throw new Exception(responseString);
            }
        }

        #endregion
        
        #region Folders

        public FolderReadSingleDto CreateFolder(FolderCreateDto folderCreate)
        {
            using (var client = GetClient())
            {
                var response = client.PostAsJsonAsyncWithSnakeCase("firmfolder?subscription-key=" + SubscriptionKey, folderCreate);
                if (response.Result.StatusCode == HttpStatusCode.Created)
                {
                    return response.Result.Content.ReadSnakeCaseToCamelCase<FolderReadSingleDto>();
                }

                var responseString = response.Result.Content.ReadAsStringAsync().Result;
                Debug.WriteLine(responseString);
                return null;
            }
        }

        public IEnumerable<FolderReadMultipleDto> ReadFolder()
        {
            using (var client = GetClient())
            {
                var url = $"firmfolder/?subscription-key={SubscriptionKey}";
                var response = client.GetAsync(url).Result;
                try
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = response.Content.ReadSnakeCaseToCamelCase<IEnumerable<FolderReadMultipleDto>>();
                        return result;
                    }

                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return new List<FolderReadMultipleDto>();
                    }

                    if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        var responseString = response.Content.ReadAsStringAsync().Result;
                        Debug.WriteLine(responseString);
                    }
                }
                catch (Exception ex)
                {
                    var responseString = response.Content.ReadAsStringAsync().Result;
                    Debug.WriteLine(responseString);
                    throw;
                }
                return null;
            }
        }

        public ResultDto UpdateFolder(FolderDto folder)
        {
            using (var client = GetClient())
            {
                var response = client.PutAsJsonAsyncWithSnakeCase($"firmfolder/{folder.Id}?subscription-key={SubscriptionKey}", folder);
                return response.Result.StatusCode == HttpStatusCode.OK ?
                            response.Result.Content.ReadSnakeCaseToCamelCase<ResultDto>() :
                            null;
            }
        }

        public ResultDto DeleteFolder(Guid id)
        {
            using (var client = GetClient())
            {
                var response = client.DeleteAsync($"firmfolder/{id}?subscription-key=" + SubscriptionKey);
                try
                {
                    if (response.Result.StatusCode == HttpStatusCode.OK)
                    {
                        return response.Result.Content.ReadSnakeCaseToCamelCase<ResultDto>();
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
                return null;
            }
        }

        #endregion

        #region Files

        public FileDto CreateFile(FileCreateDto fileCreateDto)
        {
            using (var client = GetClient())
            {
                var response = client.PostAsJsonAsyncWithSnakeCase("file?subscription-key=" + SubscriptionKey, fileCreateDto);
                try
                {
                    if (response.Result.StatusCode == HttpStatusCode.Created)
                    {
                        return response.Result.Content.ReadSnakeCaseToCamelCase<FileDto>();
                    }

                    var responseString = response.Result.Content.ReadAsStringAsync().Result;
                    Debug.WriteLine(responseString);
                }
                catch (Exception ex)
                {
                    throw;
                }
                return null;
            }
        }

        public FileDto ReadFile(Guid fileId)
        {
            using (var client = GetClient())
            {
                var url = $"file/{fileId}?subscription-key={SubscriptionKey}";
                var response = client.GetAsync(url).Result;
                try
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = response.Content.ReadSnakeCaseToCamelCase<FileDto>();
                        return result;
                    }

                    if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        var responseString = response.Content.ReadAsStringAsync().Result;
                        Debug.WriteLine(responseString);
                    }
                }
                catch (Exception)
                {
                    var responseString = response.Content.ReadAsStringAsync().Result;
                    Debug.WriteLine(responseString);

                    throw;
                }
                return null;
            }
        }

        public IEnumerable<FileReadDto> ReadFiles(Guid? folderId)
        {
            using (var client = GetClient())
            {

                var url = $"file/?subscription-key={SubscriptionKey}";

                if (folderId.HasValue)
                {
                    url = $"firmfolder/{folderId.Value}/files?subscription-key={SubscriptionKey}";
                }

                var response = client.GetAsync(url).Result;
                try
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = response.Content.ReadSnakeCaseToCamelCase<IEnumerable<FileReadDto>>();
                        return result;
                    }

                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return new List<FileReadDto>();
                    }

                    if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.InternalServerError)
                    {

                        var responseString = response.Content.ReadAsStringAsync().Result;

                        Debug.WriteLine(responseString);
                    }

                }
                catch (Exception ex)
                {
                    var responseString = response.Content.ReadAsStringAsync().Result;
                    Debug.WriteLine(responseString);

                    throw;
                }
                return null;
            }
        }

        public ResultDto UpdateFile(FileUpdateDto fileUpdateDto)
        {
            using (var client = GetClient())
            {
                var response = client.PutAsJsonAsyncWithSnakeCase($"file?subscription-key={SubscriptionKey}", fileUpdateDto);
                var responseStatus = response.Result.StatusCode;
                
                if (responseStatus == HttpStatusCode.OK)
                {
                    return response.Result.Content.ReadSnakeCaseToCamelCase<ResultDto>();
                }

                var responseString = response.Result.Content.ReadAsStringAsync().Result;
                throw new LawPanelException(responseString);
            }
        }

        public ResultDto DeleteFile(Guid id)
        {
            using (var client = GetClient())
            {
                var response = client.DeleteAsync($"file/{id}?subscription-key=" + SubscriptionKey);
                try
                {
                    if (response.Result.StatusCode == HttpStatusCode.OK)
                    {
                        return response.Result.Content.ReadSnakeCaseToCamelCase<ResultDto>();
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
                return null;
            }
        }

        public ResultDto AddNoteIntoFile(Guid fileId, FileNoteCreateDto fileNoteCreate)
        {
            HttpStatusCode responseStatus;
            ResultDto result;
            using (var client = GetClient())
            {
                var response = client.PutAsJsonAsyncWithSnakeCase($"file/{fileId}/addnote?subscription-key={SubscriptionKey}", fileNoteCreate);
                responseStatus = response.Result.StatusCode;
                result = response.Result.Content.ReadSnakeCaseToCamelCase<ResultDto>();
            }

            if (responseStatus == HttpStatusCode.OK) return result;

            throw new LawPanelException(result);
        }

        #endregion

        #region Files attachments

        public FileAttachmentDto CreateFileAttachment(FileAttachmentCreateDto fileAttachmentCreateDto)
        {
            using (var client = GetClient())
            {
                var response = client.PostAsJsonAsyncWithSnakeCase("fileattachment?subscription-key=" + SubscriptionKey, fileAttachmentCreateDto);
                try
                {
                    if (response.Result.StatusCode == HttpStatusCode.Created)
                    {
                        return response.Result.Content.ReadSnakeCaseToCamelCase<FileAttachmentDto>();
                    }

                    var responseString = response.Result.Content.ReadAsStringAsync().Result;
                    Debug.WriteLine(responseString);
                }
                catch (Exception ex)
                {
                    throw;
                }
                return null;
            }
        }

        public IEnumerable<FileAttachmentDto> ReadFileAttachment()
        {
            using (var client = GetClient())
            {
                var url = $"fileattachment/?subscription-key={SubscriptionKey}";

                var response = client.GetAsync(url).Result;
                try
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = response.Content.ReadSnakeCaseToCamelCase<IEnumerable<FileAttachmentDto>>();
                        return result;
                    }

                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return new List<FileAttachmentDto>();
                    }

                    if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        var responseString = response.Content.ReadAsStringAsync().Result;
                        Debug.WriteLine(responseString);
                    }
                }
                catch (Exception ex)
                {
                    var responseString = response.Content.ReadAsStringAsync().Result;
                    Debug.WriteLine(responseString);

                    throw;
                }
                return null;
            }
        }

        public ResultDto UpdateFile(FileAttachmentUpdateDto fileAttachmentUpdateDto)
        {
            using (var client = GetClient())
            {
                var response = client.PutAsJsonAsyncWithSnakeCase($"fileattachment?subscription-key={SubscriptionKey}", fileAttachmentUpdateDto);
                return response.Result.StatusCode == HttpStatusCode.OK ?
                            response.Result.Content.ReadSnakeCaseToCamelCase<ResultDto>() :
                            null;
            }
        }

        public ResultDto DeleteFileAttachment(Guid id)
        {
            using (var client = GetClient())
            {
                var response = client.DeleteAsync($"fileattachment/{id}?subscription-key=" + SubscriptionKey);
                try
                {
                    if (response.Result.StatusCode == HttpStatusCode.OK)
                    {
                        return response.Result.Content.ReadSnakeCaseToCamelCase<ResultDto>();
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
                return null;
            }
        }

        #endregion

        #region Files events

        public IEnumerable<FileEventForFolderDto> ReadFileEventsOfFolder(Guid folderId)
        {
            using (var client = GetClient())
            {
                var url = $"fileevent/folder/{folderId}/?subscription-key={SubscriptionKey}";

                var response = client.GetAsync(url).Result;
                try
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = response.Content.ReadSnakeCaseToCamelCase<IEnumerable<FileEventForFolderDto>>();
                        return result;
                    }

                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return new List<FileEventForFolderDto>();
                    }

                    if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        var responseString = response.Content.ReadAsStringAsync().Result;
                        Debug.WriteLine(responseString);
                    }

                }
                catch (Exception ex)
                {
                    var responseString = response.Content.ReadAsStringAsync().Result;
                    Debug.WriteLine(responseString);

                    throw;
                }
                return null;
            }
        }

        public IEnumerable<FileEventDto> ReadFileEventsOfFile(Guid fileId)
        {
            using (var client = GetClient())
            {
                var url = $"fileevent/file/{fileId}?subscription-key={SubscriptionKey}";

                var response = client.GetAsync(url).Result;
                try
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = response.Content.ReadSnakeCaseToCamelCase<IEnumerable<FileEventDto>>();
                        return result;
                    }

                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return new List<FileEventDto>();
                    }

                    if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        var responseString = response.Content.ReadAsStringAsync().Result;
                        Debug.WriteLine(responseString);
                    }

                }
                catch (Exception ex)
                {
                    var responseString = response.Content.ReadAsStringAsync().Result;
                    Debug.WriteLine(responseString);

                    throw;
                }
                return null;
            }
        }

        #endregion

        #region File status

        public IEnumerable<FileStatusDto> ReadFileStatus()
        {
            using (var client = GetClient())
            {
                var url = $"filestatus?subscription-key={SubscriptionKey}";
                var response = client.GetAsync(url).Result;
                try
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = response.Content.ReadSnakeCaseToCamelCase<IEnumerable<FileStatusDto>>();
                        return result;
                    }

                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return new List<FileStatusDto>();
                    }

                    if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        var responseString = response.Content.ReadAsStringAsync().Result;
                        Debug.WriteLine(responseString);
                    }
                }
                catch (Exception ex)
                {
                    var responseString = response.Content.ReadAsStringAsync().Result;
                    Debug.WriteLine(responseString);

                    throw;
                }
                return null;
            }
        }

        #endregion

        #region File templates

        public IEnumerable<FileTemplateDto> ReadFileTemplate()
        {
            using (var client = GetClient())
            {
                var url = $"firmfiletemplate?subscription-key={SubscriptionKey}";
                var response = client.GetAsync(url).Result;
                try
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = response.Content.ReadSnakeCaseToCamelCase<IEnumerable<FileTemplateDto>>();
                        return result;
                    }

                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return new List<FileTemplateDto>();
                    }

                    if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        var responseString = response.Content.ReadAsStringAsync().Result;
                        Debug.WriteLine(responseString);
                    }
                }
                catch (Exception ex)
                {
                    var responseString = response.Content.ReadAsStringAsync().Result;
                    Debug.WriteLine(responseString);

                    throw;
                }
                return null;
            }
        }

        #endregion

        #region Currencies

        public IEnumerable<CurrencyDto> ReadCurrency()
        {
            using (var client = GetClient())
            {
                var url = $"currency?subscription-key={SubscriptionKey}";
                var response = client.GetAsync(url).Result;
                try
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = response.Content.ReadSnakeCaseToCamelCase<IEnumerable<CurrencyDto>>();
                        return result;
                    }

                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return new List<CurrencyDto>();
                    }

                    if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        var responseString = response.Content.ReadAsStringAsync().Result;
                        Debug.WriteLine(responseString);
                    }
                }
                catch (Exception ex)
                {
                    var responseString = response.Content.ReadAsStringAsync().Result;
                    Debug.WriteLine(responseString);

                    throw;
                }
                return null;
            }
        }

        #endregion

        #region InvoiceType

        public IEnumerable<InvoiceTypeDto> ReadInvoiceType()
        {
            using (var client = GetClient())
            {
                var url = $"invoicetype?subscription-key={SubscriptionKey}";
                var response = client.GetAsync(url).Result;
                try
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = response.Content.ReadSnakeCaseToCamelCase<IEnumerable<InvoiceTypeDto>>();
                        return result;
                    }

                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return new List<InvoiceTypeDto>();
                    }

                    if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        var responseString = response.Content.ReadAsStringAsync().Result;
                        Debug.WriteLine(responseString);
                    }
                }
                catch (Exception ex)
                {
                    var responseString = response.Content.ReadAsStringAsync().Result;
                    Debug.WriteLine(responseString);

                    throw;
                }
                return null;
            }
        }

        #endregion

        #region Invoices

        public InvoiceDto CreateInvoice(InvoiceCreateDto invoiceCreate)
        {
            using (var httpClient = GetClient())
            {
                var response = httpClient.PostAsJsonAsyncWithSnakeCase("firminvoice?subscription-key=" + SubscriptionKey, invoiceCreate);
                if (response.Result.StatusCode == HttpStatusCode.Created)
                {
                    return response.Result.Content.ReadSnakeCaseToCamelCase<InvoiceDto>();
                }

                var responseString = response.Result.Content.ReadAsStringAsync().Result;
                throw new LawPanelException(responseString);
            }
        }

        public IEnumerable<InvoiceReadDto> ReadInvoice(string entityType = null, Guid? entityId = null)
        {
            using (var client = GetClient())
            {

                var entityTypeParam = "";
                if (!string.IsNullOrEmpty(entityType))
                {
                    entityTypeParam = $"&EntityType={entityType}";
                }

                var entityIdParam = "";
                if (entityId != null)
                {
                    entityIdParam = $"&EntityId={entityId}";
                }

                var url = $"firminvoice/?subscription-key={SubscriptionKey}{entityTypeParam}{entityIdParam}";
                var response = client.GetAsync(url).Result;
                try
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = response.Content.ReadSnakeCaseToCamelCase<IEnumerable<InvoiceReadDto>>();
                        return result;
                    }

                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return new List<InvoiceReadDto>();
                    }

                    if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        var responseString = response.Content.ReadAsStringAsync().Result;
                        Debug.WriteLine(responseString);
                    }
                }
                catch (Exception ex)
                {
                    var responseString = response.Content.ReadAsStringAsync().Result;
                    Debug.WriteLine(responseString);

                    throw;
                }
                return null;
            }
        }

        public ResultDto UpdateInvoice(InvoiceUpdateDto invoiceUpdate)
        {
            using (var client = GetClient())
            {
                var response = client.PutAsJsonAsyncWithSnakeCase($"firminvoice/?subscription-key={SubscriptionKey}", invoiceUpdate);
                return response.Result.StatusCode == HttpStatusCode.OK ?
                            response.Result.Content.ReadSnakeCaseToCamelCase<ResultDto>() :
                            null;
            }
        }

        public ResultDto DeleteInvoice(Guid id)
        {
            using (var client = GetClient())
            {
                var response = client.DeleteAsync($"firmInvoice/{id}?subscription-key=" + SubscriptionKey);
                try
                {
                    if (response.Result.StatusCode == HttpStatusCode.OK)
                    {
                        return response.Result.Content.ReadSnakeCaseToCamelCase<ResultDto>();
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
                return null;
            }
        }

        #endregion

        #region Invoice items

        public InvoiceItemDto CreateInvoiceItem(InvoiceItemCreateDto invoiceItemCreate)
        {
            using (var httpClient = GetClient())
            {
                var response = httpClient.PostAsJsonAsyncWithSnakeCase("invoiceitem?subscription-key=" + SubscriptionKey, invoiceItemCreate);
                if (response.Result.StatusCode == HttpStatusCode.Created)
                {
                    return response.Result.Content.ReadSnakeCaseToCamelCase<InvoiceItemDto>();
                }

                var responseString = response.Result.Content.ReadAsStringAsync().Result;
                throw new LawPanelException(responseString);
            }
        }

        public IEnumerable<InvoiceItemReadDto> ReadInvoiceItem(string entityType = null, Guid? entityId = null)
        {
            using (var client = GetClient())
            {

                var entityTypeParam = "";
                if (!string.IsNullOrEmpty(entityType))
                {
                    entityTypeParam = $"&EntityType={entityType}";
                }

                var entityIdParam = "";
                if (entityId != null)
                {
                    entityIdParam = $"&EntityId={entityId}";
                }

                var url = $"invoiceitem/?subscription-key={SubscriptionKey}{entityTypeParam}{entityIdParam}";
                var response = client.GetAsync(url).Result;
                try
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = response.Content.ReadSnakeCaseToCamelCase<IEnumerable<InvoiceItemReadDto>>();
                        return result;
                    }

                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return new List<InvoiceItemReadDto>();
                    }

                    if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        var responseString = response.Content.ReadAsStringAsync().Result;
                        Debug.WriteLine(responseString);
                    }
                }
                catch (Exception ex)
                {
                    var responseString = response.Content.ReadAsStringAsync().Result;
                    Debug.WriteLine(responseString);

                    throw;
                }
                return null;
            }
        }

        public ResultDto UpdateInvoiceItem(InvoiceItemUpdateDto invoiceItemUpdate)
        {
            using (var client = GetClient())
            {
                var response = client.PutAsJsonAsyncWithSnakeCase($"invoiceitem/{invoiceItemUpdate.Id}?subscription-key={SubscriptionKey}", invoiceItemUpdate);
                return response.Result.StatusCode == HttpStatusCode.OK ?
                            response.Result.Content.ReadSnakeCaseToCamelCase<ResultDto>() :
                            null;
            }
        }

        public ResultDto DeleteInvoiceItem(Guid id)
        {
            using (var client = GetClient())
            {
                var response = client.DeleteAsync($"invoiceitem/{id}?subscription-key=" + SubscriptionKey);
                try
                {
                    if (response.Result.StatusCode == HttpStatusCode.OK)
                    {
                        return response.Result.Content.ReadSnakeCaseToCamelCase<ResultDto>();
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
                return null;
            }
        }

        #endregion

        #region Languages

        public IEnumerable<LanguageDto> ReadLanguage()
        {
            using (var client = GetClient())
            {
                var url = $"languages?subscription-key={SubscriptionKey}";
                var response = client.GetAsync(url).Result;
                try
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = response.Content.ReadSnakeCaseToCamelCase<IEnumerable<LanguageDto>>();
                        return result;
                    }

                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return new List<LanguageDto>();
                    }

                    if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        var responseString = response.Content.ReadAsStringAsync().Result;
                        Debug.WriteLine(responseString);
                    }
                }
                catch (Exception ex)
                {
                    var responseString = response.Content.ReadAsStringAsync().Result;
                    Debug.WriteLine(responseString);

                    throw;
                }
                return null;
            }
        }

        #endregion

        #region PaymentMethod

        public IEnumerable<PaymentMethodDto> ReadPaymentMethod()
        {
            using (var client = GetClient())
            {
                var url = $"paymentmethod?subscription-key={SubscriptionKey}";
                var response = client.GetAsync(url).Result;
                try
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = response.Content.ReadSnakeCaseToCamelCase<IEnumerable<PaymentMethodDto>>();
                        return result;
                    }

                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return new List<PaymentMethodDto>();
                    }

                    if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        var responseString = response.Content.ReadAsStringAsync().Result;
                        Debug.WriteLine(responseString);
                    }
                }
                catch (Exception ex)
                {
                    var responseString = response.Content.ReadAsStringAsync().Result;
                    Debug.WriteLine(responseString);

                    throw;
                }
                return null;
            }
        }

        #endregion

        #region PaymentTransactionType

        public IEnumerable<PaymentTransactionTypeDto> ReadPaymentTransactionType()
        {
            using (var client = GetClient())
            {
                var url = $"paymenttransactiontype?subscription-key={SubscriptionKey}";
                var response = client.GetAsync(url).Result;
                try
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = response.Content.ReadSnakeCaseToCamelCase<IEnumerable<PaymentTransactionTypeDto>>();
                        return result;
                    }

                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return new List<PaymentTransactionTypeDto>();
                    }

                    if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        var responseString = response.Content.ReadAsStringAsync().Result;
                        Debug.WriteLine(responseString);
                    }
                }
                catch (Exception ex)
                {
                    var responseString = response.Content.ReadAsStringAsync().Result;
                    Debug.WriteLine(responseString);

                    throw;
                }
                return null;
            }
        }

        #endregion

        #region PaymentProvider

        public IEnumerable<PaymentProviderDto> ReadPaymentProvider()
        {
            using (var client = GetClient())
            {
                var url = $"paymentprovider?subscription-key={SubscriptionKey}";
                var response = client.GetAsync(url).Result;
                try
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = response.Content.ReadSnakeCaseToCamelCase<IEnumerable<PaymentProviderDto>>();
                        return result;
                    }

                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return new List<PaymentProviderDto>();
                    }

                    if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        var responseString = response.Content.ReadAsStringAsync().Result;
                        Debug.WriteLine(responseString);
                    }
                }
                catch (Exception ex)
                {
                    var responseString = response.Content.ReadAsStringAsync().Result;
                    Debug.WriteLine(responseString);
                    throw;
                }
                return null;
            }
        }

        #endregion

        #region Payments

        public PaymentDto CreatePayment(PaymentCreateDto paymentCreate)
        {
            using (var client = GetClient())
            {
                var response = client.PostAsJsonAsyncWithSnakeCase("firmpayment?subscription-key=" + SubscriptionKey, paymentCreate);
                try
                {
                    if (response.Result.StatusCode == HttpStatusCode.Created)
                    {
                        return response.Result.Content.ReadSnakeCaseToCamelCase<PaymentDto>();
                    }

                    var responseString = response.Result.Content.ReadAsStringAsync().Result;
                    Debug.WriteLine(responseString);
                }
                catch (Exception ex)
                {
                    throw;
                }
                return null;
            }
        }

        public IEnumerable<PaymentReadDto> ReadPayment(Guid? invoiceId = null)
        {
            using (var client = GetClient())
            {
                var invoiceIdParam = "";
                if (invoiceId != null)
                {
                    invoiceIdParam = $"&InvoiceId={invoiceId}";
                }

                var url = $"firminvoice/?subscription-key={SubscriptionKey}{invoiceIdParam}";
                var response = client.GetAsync(url).Result;
                try
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = response.Content.ReadSnakeCaseToCamelCase<IEnumerable<PaymentReadDto>>();
                        return result;
                    }

                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return new List<PaymentReadDto>();
                    }

                    if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        var responseString = response.Content.ReadAsStringAsync().Result;
                        Debug.WriteLine(responseString);
                    }
                }
                catch (Exception)
                {
                    var responseString = response.Content.ReadAsStringAsync().Result;
                    Debug.WriteLine(responseString);

                    throw;
                }
                return null;
            }
        }

        public ResultDto UpdatePayment(PaymentUpdateDto paymentUpdate)
        {
            using (var client = GetClient())
            {
                var response = client.PutAsJsonAsyncWithSnakeCase($"firmpayment/?subscription-key={SubscriptionKey}", paymentUpdate);
                return response.Result.StatusCode == HttpStatusCode.OK ?
                            response.Result.Content.ReadSnakeCaseToCamelCase<ResultDto>() :
                            null;
            }
        }

        #endregion

        #region Searches

        public SearchDto CreateSearch(SearchQuery search)
        {
            using (var client = GetClient())
            {
                var response = client.PostAsJsonAsyncWithSnakeCase("search?subscription-key=" + SubscriptionKey, new
                {
                    search.SearchTerm,
                    search.Classes,
                    search.Registry,
                    search.Weighting,
                    search.Type,
                    search.ClassType,
                    search.SearchOriginId
                });
                if (response.Result.StatusCode == HttpStatusCode.Created)
                {
                    return response.Result.Content.ReadAsAsync<SearchDto>();
                }
                return null;
            }
        }

        public SearchDto GetSearch(Guid searchId)
        {
            using (var client = GetClient())
            {
                var response = client.GetAsync($"search/{searchId}?subscription-key=" + SubscriptionKey);
                try
                {
                    if (response.Result.StatusCode == HttpStatusCode.OK)
                    {
                        return response.Result.Content.ReadAsAsync<SearchDto>();
                    }
                }
                catch (Exception ex)
                {
                    //Log
                    //ex.LogToElmah();
                    throw;
                }
            }
            return null;
        }

        public SearchStatus GetStatus(Guid searchId)
        {
            using (var client = GetClient())
            {
                var response = client.GetAsync($"search/{searchId}/status?subscription-key=" + SubscriptionKey);
                try
                {
                    var result = response.Result;
                    if (result.StatusCode == HttpStatusCode.OK)
                    {
                        return result.Content.ReadAsAsync<SearchStatus>();
                    }
                }
                catch (Exception ex)
                {
                    //Log
                    //ex.LogToElmah();
                    throw;
                }
            }
            return SearchStatus.Failed;
        }

        public IEnumerable<SearchResultDto> GetResults(Guid id)
        {
            using (var client = GetClient())
            {
                var response = client.GetAsync($"search/{id}/results?subscription-key=" + SubscriptionKey);
                try
                {
                    if (response.Result.StatusCode == HttpStatusCode.OK)
                    {
                        return response.Result.Content.ReadAsAsync<IEnumerable<SearchResultDto>>();
                    }
                }
                catch (Exception ex)
                {
                    //Log
                    //ex.LogToElmah();
                    throw;
                }
            }
            return null;
        }

        #endregion

        #region Searches classes

        public async Task<IEnumerable<SearchClassDto>> ReadSearchClass()
        {
            using (var client = GetClient())
            {
                var url = $"searchclasses?subscription-key={SubscriptionKey}";
                var response = await client.GetAsync(url);
                try
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = response.Content.ReadSnakeCaseToCamelCase<IEnumerable<SearchClassDto>>();
                        return result;
                    }

                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return new List<SearchClassDto>();
                    }

                    if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        var responseString = await response.Content.ReadAsStringAsync();
                        Debug.WriteLine(responseString);
                    }
                }
                catch (Exception ex)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine(responseString);

                    throw;
                }
                return null;
            }
        }

        #endregion

        #region Searches origins

        public async Task<IEnumerable<SearchOriginDto>> ReadSearchOrigin()
        {
            using (var client = GetClient())
            {
                var url = $"searchorigins?subscription-key={SubscriptionKey}";
                var response = await client.GetAsync(url);
                try
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = response.Content.ReadSnakeCaseToCamelCase<IEnumerable<SearchOriginDto>>();
                        return result;
                    }

                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return new List<SearchOriginDto>();
                    }

                    if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        var responseString = await response.Content.ReadAsStringAsync();
                        Debug.WriteLine(responseString);
                    }
                }
                catch (Exception ex)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine(responseString);

                    throw;
                }
                return null;
            }
        }

        #endregion

        #region Taxes

        public IEnumerable<TaxDto> ReadTax()
        {
            using (var client = GetClient())
            {
                var url = $"tax?subscription-key={SubscriptionKey}";
                var response = client.GetAsync(url).Result;
                try
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = response.Content.ReadSnakeCaseToCamelCase<IEnumerable<TaxDto>>();
                        return result;
                    }

                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return new List<TaxDto>();
                    }

                    if (response.StatusCode == HttpStatusCode.BadRequest || response.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        var responseString = response.Content.ReadAsStringAsync().Result;
                        Debug.WriteLine(responseString);
                    }
                }
                catch (Exception ex)
                {
                    var responseString = response.Content.ReadAsStringAsync().Result;
                    Debug.WriteLine(responseString);

                    throw;
                }
                return null;
            }
        }

        #endregion

        #region Aux entities

        public IEnumerable<SearchClassDto>  ReadSearchClasses()
        {
            using (var client = GetClient())
            {
                var response = client.GetAsync("searchclasses/?order_by=number&subscription-key=" + SubscriptionKey).Result;
                try
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = response.Content.ReadSnakeCaseToCamelCase<IEnumerable<SearchClassDto>>();
                        return result;
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
                return null;
            }
        }

        public IEnumerable<RegistryDto>     ReadRegistries()
        {
            using (var client = GetClient())
            {
                var response = client.GetAsync("registries/?order_by=name&subscription-key=" + SubscriptionKey).Result;
                try
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = response.Content.ReadSnakeCaseToCamelCase<IEnumerable<RegistryDto>>();
                        return result;
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
                return null;
            }
        }

        public IEnumerable<FrequencyDto>    ReadFrequencies()
        {
            using (var client = GetClient())
            {
                var response = client.GetAsync("frequencies/?order_by=name&subscription-key=" + SubscriptionKey).Result;
                try
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = response.Content.ReadSnakeCaseToCamelCase<IEnumerable<FrequencyDto>>();
                        return result;
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
                return null;
            }
        }

        public List<SearchOriginDto>        ReadSearchOrigins()
        {
            using (var client = GetClient())
            {
                var response = client.GetAsync("searchorigins?use_lawpanel_query_syntax=true&subscription-key=" + SubscriptionKey);
                try
                {
                    if (response.Result.StatusCode == HttpStatusCode.OK)
                    {
                        var result = response.Result.Content.ReadSnakeCaseToCamelCase<IEnumerable<SearchOriginDto>>();
                        return result.ToList();
                    }

                    if (response.Result.StatusCode == HttpStatusCode.NoContent)
                    {
                        return new List<SearchOriginDto>();
                    }

                    var responseString = response.Result.Content.ReadAsStringAsync().Result;
                    Debug.WriteLine(responseString);

                }
                catch (Exception ex)
                {
                    var responseString = response.Result.Content.ReadAsStringAsync();
                    Debug.WriteLine(responseString);

                    throw;
                }
                return null;
            }
        }

        #endregion

        #region Private helpers

        private HttpClient GetClient()
        {
            var addressUri = new Uri(ApiUrl);
            var cookieContainer = new CookieContainer();

            // Add auth cookie to client
            if (AuthCookieModel != null) {
                cookieContainer.Add(addressUri, new Cookie(Auth.CookieName, AuthCookieModel.Value, AuthCookieModel.Path, AuthCookieModel.Domain));
            }



            var httpClientHandler = new HttpClientHandler();
            {
                httpClientHandler.CookieContainer = cookieContainer;

                if (UseProxy)
                {
                    //httpClientHandler.Proxy = new Proxy.Proxy.Proxy(new Uri("http://localhost:8888"));
                    httpClientHandler.UseProxy = true;
                }

                var client = new HttpClient(httpClientHandler);
                {
                    client.BaseAddress = addressUri;

                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    return client;
                }

            }
        }

        private void Initialize(string subscriptionKey, AuthCookieModel authCookieModel, string apiUrl)
        {
            SubscriptionKey = subscriptionKey;
            AuthCookieModel = authCookieModel;
            ApiUrl = apiUrl;
        }

       

        #endregion


        #endregion
    }
}