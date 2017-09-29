using System.ComponentModel.DataAnnotations;

namespace LawPanel.ApiClient.Models.Sales.PaymentMethods
{
    public class PaymentCreateComponentDto : Dto
    {
        [Display(Name = "[[[Component name]]]"), Required(ErrorMessage = "[[[You must include the component name into the model]]]", AllowEmptyStrings = false)]
        public string Name  { get; set; }

        [Display(Name = "[[[Component value]]]")]
        public string Value { get; set; }
    }
}
