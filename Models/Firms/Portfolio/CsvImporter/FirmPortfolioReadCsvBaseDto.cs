using System.ComponentModel.DataAnnotations;

namespace LawPanel.ApiClient.Models.Firms.Portfolio.CsvImporter
{
    public class FirmPortfolioReadCsvBaseDto
    {
        [Display(Name = "[[[Case reference]]]")]
        public string   CaseReference       { get; set; }

        [Display(Name = "[[[Client reference]]]")]
        public string   ClientReference     { get; set; }

        [Display(Name = "[[[Application number]]]")]
        public string   ApplicationNumber   { get; set; }

        [Display(Name = "[[[Registry]]]"), Required(ErrorMessage = "[[[Registry is required]]]", AllowEmptyStrings = false)]
        public string   Registry            { get; set; }
    }
}