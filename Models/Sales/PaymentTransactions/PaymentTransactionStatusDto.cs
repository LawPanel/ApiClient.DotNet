using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Sales.PaymentTransactions
{
    public class PaymentTransactionStatusDto : Dto, IIdentifiableDto
    {
        public string   Id          { get; set; }
        public int      Code        { get; set; }
        public string   Name        { get; set; }
        public string   Description { get; set; }
    }
}
