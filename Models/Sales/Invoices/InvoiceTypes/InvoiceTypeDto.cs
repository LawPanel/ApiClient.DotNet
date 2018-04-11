using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Sales.Invoices.InvoiceTypes
{
    public class InvoiceTypeDto : Dto, IIdentifiableDto
    {
        public string   Id              { get; set; }
        public string   Name            { get; set; }
        public int      Code            { get; set; }
        public string   Description     { get; set; }
        public string   LeadingZeros    { get; set; } // i.e. 000001
        public string   Prefix          { get; set; }


        public override string ToString()
        {
            return Name;
        }
    }
}
