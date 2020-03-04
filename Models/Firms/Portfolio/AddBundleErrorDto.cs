using System;

namespace LawPanel.ApiClient.Models.Firms.Portfolio
{
    public class AddBundleErrorDto : Dto
    {

        public AddBundleErrorDto(Exception exception)
        {
            var innerExceptionMessage = "";
            if (exception.InnerException != null)
            {
                innerExceptionMessage = $"{exception.InnerException.Message}.";
            }

            Message = $"Exception message: {exception.Message}. {innerExceptionMessage}";
        }

        public string Id                { get; set; }
        public string ApplicationNumber { get; set; }
        public string MarkText          { get; set; }
        public string RegistryName      { get; set; }
        public string Step              { get; set; }
        public string Message           { get; set; }
    }
}
