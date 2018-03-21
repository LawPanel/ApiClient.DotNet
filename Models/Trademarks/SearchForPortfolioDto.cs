namespace LawPanel.ApiClient.Models.Trademarks
{
    public class SearchForPortfolioDto
    {
        public string   Code        { get; set; }
        public string   SearchTerms { get; set; }
        public string   Classes     { get; set; }
        public bool     Owners      { get; set; }
    }
}
