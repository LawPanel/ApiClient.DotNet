using System;
using System.ComponentModel.DataAnnotations;

namespace LawPanel.ApiClient.Models.Firms.Portfolio.CsvImporter
{
    public class FirmPortfolioReadCsvDto 
    {
        #region Trademark
        [Display(Name = "[[[Application number]]]"), Required(ErrorMessage = "[[[Application number is required]]]", AllowEmptyStrings = false)]
        public string                   ApplicationNumber       { get; set; }

        [Display(Name = "[[[Registration date]]]")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime?                RegistrationDate        { set; get; }

        [Display(Name = "[[[Application date]]]")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime?                ApplicationDate         { set; get; }

        [Display(Name = "[[[Expiry date]]]")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime?                ExpiryDate              { get; set; }

        [Display(Name = "[[[Mark feature]]]"), Required(ErrorMessage = "[[[Mark feature is required]]]", AllowEmptyStrings = false)]
        public string                   MarkFeature             { set; get; }

        [Display(Name = "[[[Kind mark]]]"), Required(ErrorMessage = "[[[Mark feature is required]]]", AllowEmptyStrings = false)]
        public string                   KindMark                { get; set; }

        [Display(Name = "[[[Mark text]]]"), Required(ErrorMessage = "[[[Mark feature is required]]]", AllowEmptyStrings = false)]
        public string                   MarkText                { get; set; }

        [Display(Name = "[[[Classes]]]"), Required(ErrorMessage = "[[[Mark feature is required]]]", AllowEmptyStrings = false)]
        public string                   Classes { get; set; }

        [Display(Name = "[[[Status]]]"), Required(ErrorMessage = "[[[Status text is required]]]", AllowEmptyStrings = false)]
        public string                   Status                  { get; set; }

        [Display(Name = "[[[Registry]]]"), Required(ErrorMessage = "[[[Registry is required]]]", AllowEmptyStrings = false)]
        public string                   Registry                { get; set; }

        [Display(Name = "[[[Image URL]]]")]
        public string                   ImageUrl                { get; set; }

        #endregion
    }
}
