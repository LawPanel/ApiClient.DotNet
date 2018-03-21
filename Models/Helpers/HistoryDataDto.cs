
using System.Collections.Generic;

namespace LawPanel.ApiClient.Models.Helpers
{
    public class HistoryDataDto
    {
        public HistoryDataDto()
        {
            TypeData = "String";
        }
        public string DataName                  { get; set; }
        public string OriginalData              { get; set; }
        public string UpdatedData               { get; set; }
        public string TypeData                  { get; set; }
        public string ExtraOriginalData   { get; set; }
        public string ExtraUpdatedData    { get; set; }
    }
}