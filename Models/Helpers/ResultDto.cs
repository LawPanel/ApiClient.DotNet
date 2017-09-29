using System;
using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Helpers
{
    public class ResultDto : IIdentifiableDto
    {
        public string   Id          { get; set; }
        public string   Message     { get; set; }
        public bool     Successfull { get; set; }
        
        #region Constructors

        // Do not remove this empty constructor, it is used by deserializer
        public ResultDto(){}

        public ResultDto(string resourceId, bool successfull, string message)
        {
            Id = resourceId;
            Successfull = successfull;
            Message = message;
        }

        public ResultDto(Guid resourceId, bool successfull, string message)
        {
            Id = resourceId.ToString();
            Successfull = successfull;
            Message = message;
        }

        #endregion

    }
}
