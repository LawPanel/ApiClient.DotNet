using System;
using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.Flatteneds;
using LawPanel.ApiClient.Models.User;

namespace LawPanel.ApiClient.Models.Firms.Portfolio.UpdatesFromIpo
{
    public class FirmPortfolioUpdateFromIpoReadDto : Dto, IIdentifiableDto
    {
        public  string                                  Id                  { get; set; }
        public  string                                  Observations        { get; set; }
        public  DateTime?                               DateTimeStart       { get; set; }
        public  DateTime?                               DateTimeFinished    { get; set; }
        public  FirmPortfolioUpdateFromIpoReadUserDto   User                { get; set; }
    }

    #region Flattened DTOs

    #region UserDto
    public class FirmPortfolioUpdateFromIpoReadUserDto : FlattenedDto<UserDto>
    {
        public Guid     Id          { get; set; }
        public string   FirstName   { get; set; }
        public string   LastName    { get; set; }
        public string   UserName    { get; set; }
    }
    #endregion 

    #endregion
}