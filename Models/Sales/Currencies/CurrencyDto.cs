using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Sales.Currencies
{
    public class CurrencyDto : Dto, IIdentifiableDto
    {
        public string           Id          { get; set; }
        public string           Name        { get; set; }
        public string           NameShort   { get; set; }
        public string           Symbol      { get; set; }

        public override string ToString()
        {
            return $"{Symbol} / {Name}";
        }
    }
}
