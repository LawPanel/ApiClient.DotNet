using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Communications
{
    public class CommunicationRecordDto : Dto, IIdentifiableDto
    {
        public string   Id              { get; set; } // Contains the ID ( name ) of blob contents
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

        public string   Table           { get; set; }
        public string   PartitionKey    { get; set; }
        public string   RowKey          { get; set; }
    }
}