using System;
using System.Collections.Generic;
using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.Flatteneds;
using LawPanel.ApiClient.Models.User;

namespace LawPanel.ApiClient.Models.BatchTasks
{
    public class BatchTaskReadDto : Dto, IIdentifiableDto
    {
        public  string                      Id                  { get; set; }
        public  string                      Observations        { get; set; }
        public  string                      EntityType          { get; set; }
        public  string                      EndPoint            { get; set; }
        public  DateTime?                   DateTimeStart       { get; set; }
        public  DateTime?                   DateTimeFinished    { get; set; }
        public  BatchTaskReadUserDto        User                { get; set; }
        public  List<BatchTaskPropertyDto>  BatchTaskProperties { get; set; }

        public BatchTaskReadDto()
        {
            BatchTaskProperties = new List<BatchTaskPropertyDto>();
        }
    }

    #region Flattened DTOs

    #region UserDto
    public class BatchTaskReadUserDto : FlattenedDto<UserDto>
    {
        public Guid     Id          { get; set; }
        public string   FirstName   { get; set; }
        public string   LastName    { get; set; }
        public string   UserName    { get; set; }
    }
    #endregion 

    #endregion
}