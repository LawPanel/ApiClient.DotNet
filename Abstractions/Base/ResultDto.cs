using System;
using LawPanel.ApiClient.Abstractions.Interfaces;

namespace LawPanel.ApiClient.Abstractions.Base
{
    public class ResultDto : IIdentifiableDto
    {
        public string   Id          { get; set; }
        public Guid     OperationId { get; set; }
        public string   Message     { get; set; }
        public bool     Successfull { get; set; }

        // Dont remove this empty constructor, used to deserialize
        public ResultDto()
        {

        }

        public ResultDto(string resourceId, bool successfull, string message)
        {
            Id = resourceId;
            OperationId = Guid.NewGuid(); // TODO: We can use it for something...??
            Successfull = successfull;
            Message = message;
        }

        public ResultDto(Guid resourceId, bool successfull, string message)
        {
            Id = resourceId.ToString();
            OperationId = Guid.NewGuid(); // TODO: We can use it for something...??
            Successfull = successfull;
            Message = message;
        }

    }
}
