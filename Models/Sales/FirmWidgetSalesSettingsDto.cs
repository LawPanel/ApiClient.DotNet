using System.ComponentModel.DataAnnotations;
using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Sales
{
    public class FirmWidgetSalesSettingsDto : Dto, IIdentifiableDto
    {
        public string Id                                { get; set; }

        [Display(Name = "[[[Title background color]]]"), Required(ErrorMessage = "[[[Title background color is required]]]", AllowEmptyStrings = false)]
        public string  SectionTitleBackgroundColor       { get; set; }
        [Display(Name = "[[[Title foreground color]]]"), Required(ErrorMessage = "[[[Title foreground color is required]]]", AllowEmptyStrings = false)]
        public string  SectionTitleFrontColor            { get; set; }

        [Display(Name = "[[[Categories background color]]]"), Required(ErrorMessage = "[[[Categories background color is required]]]", AllowEmptyStrings = false)]
        public string  SectionCategoriesBackgroundColor  { get; set; }
        [Display(Name = "[[[Categories foreground color]]]"), Required(ErrorMessage = "[[[Categories foreground color is required]]]", AllowEmptyStrings = false)]
        public string  SectionCategoriesFrontColor       { get; set; }

        [Display(Name = "[[[Fee items background color]]]"), Required(ErrorMessage = "[[[Fee items background color is required]]]", AllowEmptyStrings = false)]
        public string  SectionFeeItemsBackgroundColor    { get; set; }
        [Display(Name = "[[[Fee items foreground color]]]"), Required(ErrorMessage = "[[[Fee items foreground color is required]]]", AllowEmptyStrings = false)]
        public string  SectionFeeItemsFrontColor         { get; set; }

        [Display(Name = "[[[Taxes background color]]]"), Required(ErrorMessage = "[[[Taxes background color is required]]]", AllowEmptyStrings = false)]
        public string  SectionTaxesBackgroundColor       { get; set; }
        [Display(Name = "[[[Taxes foreground color]]]"), Required(ErrorMessage = "[[[Taxes foreground color is required]]]", AllowEmptyStrings = false)]
        public string  SectionTaxesFrontColor            { get; set; }

        [Display(Name = "[[[Sub-total background color]]]"), Required(ErrorMessage = "[[[Sub-total background color is required]]]", AllowEmptyStrings = false)]
        public string  SectionSubTotalBackgroundColor    { get; set; }
        [Display(Name = "[[[Sub-total foreground color]]]"), Required(ErrorMessage = "[[[Sub-total foreground color is required]]]", AllowEmptyStrings = false)]
        public string  SectionSubTotalFrontColor         { get; set; }

        [Display(Name = "[[[Total background color]]]"), Required(ErrorMessage = "[[[Total background color is required]]]", AllowEmptyStrings = false)]
        public string  SectionTotalBackgroundColor       { get; set; }
        [Display(Name = "[[[Total foreground color]]]"), Required(ErrorMessage = "[[[Total foreground color is required]]]", AllowEmptyStrings = false)]
        public string  SectionTotalFrontColor            { get; set; }

        [Display(Name = "[[[Footer background color]]]"), Required(ErrorMessage = "[[[Footer background color is required]]]", AllowEmptyStrings = false)]
        public string  SectionFooterBackgroundColor      { get; set; }
        [Display(Name = "[[[Footer foreground color]]]"), Required(ErrorMessage = "[[[Footer foreground color is required]]]", AllowEmptyStrings = false)]
        public string  SectionFooterFrontColor           { get; set; }

        [Display(Name = "[[[Hide LawPanel logo at the bottom]]]")]
        public bool    HideLogoAtBottom                  { get; set; }

        [Display(Name = "[[[Force fixed size]]]")]
        public bool    UseFixedSize                      { get; set; }

        [Display(Name = "[[[Width]]]")]
        public int     Width                             { get; set; }

        [Display(Name = "[[[Height]]]")]
        public int     Height                            { get; set; }

        [Display(Name = "[[[Zoom]]]")]
        public decimal Zoom                              { get; set; }

    }
}