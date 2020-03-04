using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.GoodAndServices;
using LawPanel.ApiClient.Models.User;
using LawPanel.ApiClient.Models.Watchings;

namespace LawPanel.ApiClient.Models.Firms.Portfolio
{
    public class FirmPortfolioDto : FirmPortfolioCreateDto, IIdentifiableDto
    {
        #region Firm
        public string               Id                      { get; set; }
        public string               FirmName                { get; set; }
        #endregion

        #region FirmClient
        public string               FirmClientName          { get; set; }
        public FirmClientDto        FirmClient              { get; set; }
        #endregion

        #region FirmClientAgent
        public string               ClientAgentName          { get; set; }
        public FirmClientDto        FirmClientAgent              { get; set; }
        #endregion

        #region Trademark
        public string               RegistryName            { get; set; }
        public string               RegistryOfficialName    { get; set; }
        public string               RegistryDescription     { get; set; }
        #endregion

        #region User creator of registry
        public string               UserId                  { get; set; }
        public string               UserUserName            { get; set; }

        [Display(Name = "[[[Attorney]]]")]
        public UserDto              User                    { get; set; }
        #endregion

        public string               TrademarkUrlOnIpo       { get; set; }

        public bool                 ExcludeFromAutoUpdates  { get; set; }

        public WatchingDto          Watching                { get; set; }

        public List<UserReadDto>    Observers               { get; set; }

        public string               RegistrationTypeName    { get; set; }

        public string               TrademarkTypeName       { get; set; }

        [Display(Name = "[[[Good and services]]]")]
        public List<GaSDto>         GoodAndServices         { get; set; }

        public FirmPortfolioDto()
        {
            Observers = new List<UserReadDto>();
            GoodAndServices = new List<GaSDto>();
        }
    }
}
