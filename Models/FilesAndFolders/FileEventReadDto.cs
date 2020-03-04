using System;
using LawPanel.ApiClient.Models.Flatteneds;
using LawPanel.ApiClient.Models.User;

namespace LawPanel.ApiClient.Models.FilesAndFolders
{
    public class FileEventReadDto 
    {
        public string               Id          { get; set; }
        public DateTime             DateTime    { get; set; }
        public string               EventType   { get; set; }
        public string               By          { get; set; } // Who created the event?
        public string               Comments    { get; set; } 
        public FileEventReadFileDto File        { get; set; }
        public FileEventReadUserDto User        { get; set; }
    }

    #region Flattened DTOs

    #region FileDto
    public class FileEventReadFileDto : FlattenedDto<FileDto>
    {
        public Guid     Id      { get; set; }
        public string   Name    { get; set; }
    }
    #endregion

    #region UserDto
    public class FileEventReadUserDto : FlattenedDto<UserDto>
    {
        public Guid     Id        { get; set; }
        public string   FirstName { get; set; }
        public string   LastName  { get; set; }
    }
    #endregion

    #endregion
}
