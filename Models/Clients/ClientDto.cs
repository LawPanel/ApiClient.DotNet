using System.ComponentModel.DataAnnotations;
using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.Helpers;

namespace LawPanel.ApiClient.Models.Clients
{
    public class ClientDto : Dto, IIdentifiableDto
    {
        public string        Id                          { get; set; }

        [Display(Name = "[[[Client name]]]"), Required(ErrorMessage = "[[[Client name is required]]]", AllowEmptyStrings = false)]
        public string        Name                        { get; set; }

        [Display(Name = "[[[Company registration number]]]")]
        public string        CompanyRegistrationNumber   { get; set; }

        [Display(Name = "[[[Contact name]]]")]
        public string        ContactName                 { get; set; }

        [Display(Name = "[[[Contact email]]]")]
        public string        ContactEmail                { get; set; }

        [Display(Name = "[[[Contact number]]]")]
        public string        ContactNumber               { get; set; }

        [Display(Name = "[[[Client contact address]]]")]
        public AddressDto    ContactAddress              { get; set; }

        [Display(Name = "[[[Client billing address]]]")]
        public AddressDto    BillingAddress              { get; set; }


        public ClientDto()
        {
            BillingAddress=new AddressDto();
            ContactAddress=new AddressDto();
        }
    }
}