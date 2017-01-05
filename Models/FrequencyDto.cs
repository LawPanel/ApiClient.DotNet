using System.ComponentModel.DataAnnotations;
using LawPanel.ApiClient.Abstractions.Base;
using LawPanel.ApiClient.Abstractions.Interfaces;

namespace LawPanel.ApiClient.Models
{
    public class FrequencyDto  : Dto, IIdentifiableDto
    {
        public string Id { get; set; }

        [Display(Name = "[[[Name]]]"), Required(ErrorMessage = "[[[Frequency name is required]]]", AllowEmptyStrings = false)]
        public string   Name            { get; set; }

        [Display(Name = "[[[Unit name]]]"), Required(ErrorMessage = "[[[Unit name is required]]]", AllowEmptyStrings = false)]
        public string   UnitName        { get; set; }

        [Display(Name = "[[[Years]]]"), Required(ErrorMessage = "[[[Years value is required]]]")]
        public int      Years           { get; set; }

        [Display(Name = "[[[Months]]]"), Required(ErrorMessage = "[[[Months value is required]]]")]
        public int      Months          { get; set; }

        [Display(Name = "[[[Days]]]"), Required(ErrorMessage = "[[[Days value is required]]]")]
        public int      Days            { get; set; }

        [Display(Name = "[[[Hours]]]"), Required(ErrorMessage = "[[[Hours value is required]]]")]
        public int      Hours           { get; set; }

        [Display(Name = "[[[Minutes]]]"), Required(ErrorMessage = "[[[Minutes value is required]]]")]
        public int      Minutes         { get; set; }

        [Display(Name = "[[[Seconds]]]"), Required(ErrorMessage = "[[[Seconds value is required]]]")]
        public int      Seconds         { get; set; }

        [Display(Name = "[[[Total in seconds]]]")]
        public long     TotalInSeconds  { get; set; }
    }
}
