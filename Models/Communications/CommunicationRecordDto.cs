using LawPanel.ApiClient.Abstractions.Base;

namespace LawPanel.ApiClient.Models.Communications
{
    public class CommunicationRecordDto : Dto
    {
        public string   Id              { get; set; }
        public string   Channel         { get; set; }
        public string   From            { get; set; }
        public string   FromType        { get; set; }
        public string   FromId          { get; set; }
        public string   FromIdOnChannel { get; set; }
        public string   To              { get; set; }
        public string   ToType          { get; set; }
        public string   ToId            { get; set; }
        public string   ToIdOnChannel   { get; set; }
        public string   Type            { get; set; }
        public string   Message         { get; set; }
        public long     UnixTimeStamp   { get; set; }

    }
}
