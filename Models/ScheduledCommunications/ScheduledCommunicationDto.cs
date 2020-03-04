using System;
using LawPanel.ApiClient.Enums;
using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.ScheduledCommunications
{
    public class ScheduledCommunicationDto : Dto, IIdentifiableDto
    {
        public string                       Id                      { get; set; }
        public DateTime                     DateTimeToSend          { get; set; }
        public string                       Emisor                  { get; set; }
        public string                       EmisorId                { get; set; }
        public string                       EmisorIdOnChannel       { get; set; }
        public string                       Receptor                { get; set; }
        public string                       ReceptorId              { get; set; }
        public string                       ReceptorIdOnChannel     { get; set; }
        public string                       ComunicationTypeName    { get; set; }
        public string                       ComunicationChannel     { get; set; }
        public string                       Params                  { get; set; }
        public string                       ExtraParam              { get; set; } // Aux, used to store and recover records. I.e.: FirmPortfolioId with reminders
        public ScheduledCommunicationState  State                   { get; set; }
        public bool                         ForceSystemAsRemitent   { get; set; } // When true communication should be send with SystemCommunicator as remitent
        public string                       PartitionKey            { get; set; }
        public string                       RowKey                  { get; set; }
        public string                       CreatedBy               { get; set; }


        public override string ToString()
        {
            return $"DateTimeToSend: {DateTimeToSend} \n" +
                   $"Emisor: {Emisor} \n" +
                   $"EmisorId: {EmisorId} \n" +
                   $"Receptor: {Receptor} \n" +
                   $"ReceptorId: {ReceptorId} \n" +
                   $"Params: {Params} \n" +
                   $"ExtraParam: {ExtraParam} \n" +
                   $"PartitionKey: {PartitionKey} \n" +
                   $"RowKey: {RowKey} \n";
        }
    }
}