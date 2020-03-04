using System;
using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.Helpers.LawPanelNewsType;
using LawPanel.ApiClient.Models.User;

namespace LawPanel.ApiClient.Models.Helpers.LawPanelNews
{
    public class LawPanelNewsDto : Dto, IIdentifiableDto
    {
        public string               Id                  { get; set; }
        public LawPanelNewsTypeDto  LawPanelNewsType    { get; set; }
        public DateTime             DateTime            { get; set; }
        public UserDto              User                { get; set; }
        public string               Title               { get; set; } 
        public string               SubTitle            { get; set; }
        public string               ThumbnailUrl        { get; set; }
        public string               Contents            { get; set; }

        public LawPanelNewsDto()
        {
            User = new UserDto();
        }
    }
}