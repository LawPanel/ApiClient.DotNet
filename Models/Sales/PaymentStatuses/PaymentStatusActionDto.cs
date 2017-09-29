using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Sales.PaymentStatuses
{
    public class PaymentStatusActionDto : Dto,IIdentifiableDto
    {
        public string Id            { get; set; }
        public string Name          { get; set; }
        public string Description   { get; set; }
    }
}
