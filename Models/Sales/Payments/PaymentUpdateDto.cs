using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Sales.Payments
{
    public class PaymentUpdateDto : Dto, IIdentifiableDto
    {
        public string   Id                          { get; set; }
        public int      PaymentTransactionTypeCode  { get; set; }
        public decimal  Amount                      { get; set; }
        public string   Notes                       { get; set; }
    }
}
