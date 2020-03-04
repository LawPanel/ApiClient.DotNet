using System;
using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.Flatteneds;
using LawPanel.ApiClient.Models.User;

namespace LawPanel.ApiClient.Models.Helpers.LawPanelNews
{
    public class LawPanelNewsReadDto : Dto, IIdentifiableDto
    {
        public string                               Id                  { get; set; }
        public LawPanelNewsReadLawPanelNewsTypeDto  LawPanelNewsType    { get; set; }
        public DateTime                             DateTime            { get; set; }
        public LawPanelNewsReadUserDto              User                { get; set; }
        public string                               Title               { get; set; } 
        public string                               SubTitle            { get; set; }
        public string                               ThumbnailUrl        { get; set; }
        public string                               Contents            { get; set; }
    }

    #region Flattened DTOs


    #region UserDto
    public class LawPanelNewsReadUserDto : FlattenedDto<UserDto>
    {
        public string FirstName { get; set; }
        public string LastName  { get; set; }
        public string Email     { get; set; }
    }
    #endregion

    #region LawPanelNewsTypeDto
    public class LawPanelNewsReadLawPanelNewsTypeDto : FlattenedDto<UserDto>
    {
        public Guid     Id   { get; set; }
        public int      Code { get; set; }
        public string   Name { get; set; }
    }
    #endregion

    #endregion

}