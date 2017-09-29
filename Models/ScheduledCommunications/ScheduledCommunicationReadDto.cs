using System;
using LawPanel.ApiClient.Enums;
using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.ScheduledCommunications
{
    public class ScheduledCommunicationReadDto : Dto, IIdentifiableDto
    {
        public string Id
        {
            get
            {
                // PartitionKey|||RowKey
                return $"{Emisor}|{EmisorId}|||{ComunicationTypeName}|{ExtraParam}|{ComunicationChannel}|{Receptor}|{ReceptorId}|{DateTimeToSend.Ticks}|{ParamsId}";
            }
            set {}
        }

        public DateTime                     DateTimeToSend          { get; set; }
        public string                       Emisor                  { get; set; }
        public string                       EmisorId                { get; set; }
        public string                       EmisorIdOnChannel       { get; set; }
        public string                       Receptor                { get; set; }
        public string                       ReceptorId              { get; set; }
        public string                       ReceptorIdOnChannel     { get; set; }
        public string                       ComunicationTypeName    { get; set; }
        public string                       ComunicationChannel     { get; set; }
        public string                       ParamsId                { get; set; }
        public string                       ExtraParam              { get; set; } // Aux, used to store and recover records without get params from blobstorage. I.e.: FirmPortfolioId with reminders
        public ScheduledCommunicationState  State                   { get; set; }
        public bool                         ForceSystemAsRemitent   { get; set; } // When true communication should be send with SystemCommunicator as remitent

    }
}
