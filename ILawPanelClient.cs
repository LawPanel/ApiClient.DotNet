using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LawPanel.ApiClient.Abstractions.Base;
using LawPanel.ApiClient.Enums;
using LawPanel.ApiClient.Models;
using LawPanel.ApiClient.Models.Account;
using LawPanel.ApiClient.Models.Firms.Portfolio;
using LawPanel.ApiClient.Models.Registry;
using LawPanel.ApiClient.Models.SearchClass;
using LawPanel.ApiClient.Models.SearchOrigins;
using LawPanel.ApiClient.Models.User;
using LawPanel.ApiClient.Models.Watchings;

namespace LawPanel.ApiClient
{
    public interface ILawPanelClient
    {
        SearchDto                           CreateSearch(SearchQuery search);
        SearchDto                           GetSearch(Guid searchId);
        SearchStatus                        GetStatus(Guid searchId);
        IEnumerable<SearchResultDto>        GetResults(Guid id);

        TrademarkDto                        TrademarkByApplicationNumber(string registry, string applicationNumber);
        IEnumerable<TrademarkDto>           TrademarkSearchByText(string txt);
        IEnumerable<TrademarkDto>           TrademarksByIds(int[] ids);
        TrademarkDto                        TrademarksByWordMarkId(int id);
        IEnumerable<TrademarkDto>           TrademarksBySearch(SearchQuery search);
        IEnumerable<TrademarkDto>           TrademarkSearchByMultipleCriteria(string txt);
        IEnumerable<TrademarkDto>           TrademarkListFromLetters(int skip, int take, string registry, string startWith, bool exactLetter);
        IEnumerable<string>                 TrademarkLetters(string startWith, int len, string registry);
        int                                 TrademarkCountByLetter(string startWith, int len, string registry);

        IEnumerable<SearchClassDto>         ReadSearchClasses();
        IEnumerable<RegistryDto>            ReadRegistries();
        IEnumerable<FrequencyDto>           ReadFrequencies();
        List<SearchOriginDto>               ReadSearchOrigins();

        Task<AuthCookieModel>               GetAuthCookieForUserIdentity(LoginBindingModel loginBindingModel);
        UserLoginDetailsDto                 GetUserLoginDetails(LoginBindingModel loginBindingModel);
        IdentityDto                         GetUserDetails();

        WatchingDto                         CreateWatching(WatchingDto watching);
        Task<IEnumerable<WatchingDto>>      ReadWatchings();
        ResultDto                           UpdateWatching(WatchingDto watching);
        ResultDto                           DeleteWatching(Guid id);
        Task                                CreateWatchingBundle(List<WatchingBundleDto> watchingBundles);

        WatchingUserSettingsDto             CreateWatchingUserSettings(WatchingUserSettingsDto watchingUserSettingsDto);
        WatchingUserSettingsDto             ReadWatchingUserSettings();
        ResultDto                           UpdateWatchingUserSettings(WatchingUserSettingsDto watchingUserSettingsDto);
        ResultDto                           DeleteWatchingUserSettings(Guid id);

        Task<string>                        GetFirmApiKey();

        FirmPortfolioDto                    CreateFirmPortfolio(FirmPortfolioDto portfolioDto);
        Task<IEnumerable<FirmPortfolioDto>> ReadFirmPortfolios();
        ResultDto                           UpdateFirmPortfolio(FirmPortfolioDto firmPortfolioDto);
        ResultDto                           DeleteFirmPortfolio(Guid id);

        Task CreatePortfolioBundle(List<FirmPortfolioBundle> firmPortfolioBundles);
    }
}