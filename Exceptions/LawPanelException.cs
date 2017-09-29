using System;
using LawPanel.ApiClient.Models.Helpers;

namespace LawPanel.ApiClient.Exceptions
{
    public class LawPanelException : Exception
    {

        public LawPanelException(string message) : base(message)
        {
        }

        public LawPanelException(ResultDto result) : base(result.Message)
        {
            
        }

    }
}
