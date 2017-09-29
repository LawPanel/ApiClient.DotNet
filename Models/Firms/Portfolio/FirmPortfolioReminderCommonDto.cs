using System;

namespace LawPanel.ApiClient.Models.Firms.Portfolio
{
    public class FirmPortfolioReminderCommonDto
    {
        public string   Id              { get; set; }
        public bool     Selected        { get; set; }
        public DateTime DateTime        { get; set; }
        public string   UserId          { get; set; }
        public string   UserName        { get; set; }
        public string   Notes           { get; set; }
        public string   PartitionKey    { get; set; }
        public string   RowKey          { get; set; }


        public override string ToString()
        {
            return $"Id:            {Id} \n" +
                   $"Selected:      {Selected} \n" +
                   $"DateTime:      {DateTime} \n" +
                   $"UserId:        {UserId} \n" +
                   $"UserName:      {UserName} \n" +
                   $"Notes:         {Notes} \n" +
                   $"PartitionKey:  {PartitionKey} \n" +
                   $"RowKey:        {RowKey} \n";
        }
    }
}