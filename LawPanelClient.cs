using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using LawPanel.ApiClient.Abstractions.Base;
using LawPanel.ApiClient.Constants;
using LawPanel.ApiClient.Enums;
using LawPanel.ApiClient.Extensions;
using LawPanel.ApiClient.Models;
using LawPanel.ApiClient.Models.Account;
using LawPanel.ApiClient.Models.Firms.Portfolio;
using LawPanel.ApiClient.Models.FirmsContactInfo;
using LawPanel.ApiClient.Models.Registry;
using LawPanel.ApiClient.Models.SearchClass;
using LawPanel.ApiClient.Models.SearchOrigins;
using LawPanel.ApiClient.Models.User;
using LawPanel.ApiClient.Models.Watchings;

namespace LawPanel.ApiClient
{
    public class LawPanelClient : ILawPanelClient
    {
        #region Private properties

        public  static bool         IsLocal = false;
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
        public LawPanelClient(string subscriptionKey, string userName = "", string password = "")
        {
            AuthCookieModel authCookieModel = null;
            
            #region Validations
            if (!string.IsNullOrEmpty(userName) && string.IsNullOrEmpty(password)) throw new ArgumentException("If you set the username you will need to set the password too", nameof(password));
            if (!string.IsNullOrEmpty(password) && string.IsNullOrEmpty(userName)) throw new ArgumentException("If you set the password you will need to set the username too", nameof(userName));
            #endregion

            #region Get auth cookie ( if username and password are setting )
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            {
                authCookieModel = GetAuthCookieForUserIdentity(new LoginBindingModel
                {
                    Email = userName,
                    Password = password,
                    RememberMe = true
                }).Result;
            }
            #endregion

            Initialize(subscriptionKey, authCookieModel, Auth.ApiUrl);
        }

        public LawPanelClient(string subscriptionKey, AuthCookieModel authCookieModel)
        {
            Initialize(subscriptionKey, authCookieModel, Auth.ApiUrl);
        }

        public LawPanelClient(string subscriptionKey, AuthCookieModel authCookieModel, string apiUrl)
        {
            Initialize(subscriptionKey, authCookieModel, apiUrl);
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
                try
                {
                    if (response.Result.StatusCode == HttpStatusCode.Created)
                    {
                        return response.Result.Content.ReadAsAsync<SearchDto>();
                    }

                }
                catch (Exception ex)
                {
                    //Log
                    //ex.LogToElmah();
                    throw ex;
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
                    throw ex;
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
                    throw ex;
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
                    throw ex;
                }
            }
            return null;
        }

        #endregion

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
                            throw ex;
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
                            throw ex;
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
                            throw ex;
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
                            throw ex;
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
                            throw ex;
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
                            throw ex;
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
                            throw ex;
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
                            throw ex;
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
                            throw ex;
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
                    
                        
                    throw ex;
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

                    throw ex;
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
                    throw ex;
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
                    throw ex;
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
                    throw ex;
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

                    throw ex;
                }
                return null;
            }
        }

        public async Task<IEnumerable<FirmPortfolioDto>> ReadFirmPortfolios()
        {
            using (var client = GetClient())
            {
                var response = await client.GetAsync("firmportfolio/?order_by=mark_text&subscription-key=" + SubscriptionKey);
                try
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = response.Content.ReadSnakeCaseToCamelCase<IEnumerable<FirmPortfolioDto>>();
                        return result;
                    }

                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return new List<FirmPortfolioDto>();
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

                    throw ex;
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
                    throw ex;
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
                    throw ex;
                }
                return null;
            }
        }

        public async Task CreatePortfolioBundle(List<FirmPortfolioBundle> firmPortfolioBundles)
        {
            using (var client = GetClient())
            {
                try
                {
                    var response = await client.PostAsJsonAsyncWithSnakeCase("firmportfolio/addbundle?subscription-key=" + SubscriptionKey, firmPortfolioBundles);
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        throw new Exception(response.Content.ReadAsStringAsync().Result);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
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
                            throw ex;
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
                    throw ex;
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
                    throw ex;
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
                    throw ex;
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
                    throw ex;
                }
            }
            return null;
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
                    throw ex;
                }
            }
        }
        
        // Login normal
        public async Task<AuthCookieModel> GetAuthCookieForUserIdentity(LoginBindingModel loginBindingModel)
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

                    throw ex;
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
                    throw ex;
                }
            }
            return null;
        }

        #endregion

        #region Leads
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
                    throw ex;
                }
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
                    throw ex;
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
                    throw ex;
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
                    throw ex;
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

                    throw ex;
                }
                return null;
            }
        }

        #endregion

        #region Private helpers

        private HttpClient  GetClient()
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
    }
}