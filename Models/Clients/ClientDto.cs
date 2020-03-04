using System.ComponentModel.DataAnnotations;
using LawPanel.ApiClient.Attributes;
using LawPanel.ApiClient.Constants;
using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.Helpers;

namespace LawPanel.ApiClient.Models.Clients
{
    [EndPoint(EndPoints.client)]
    public class ClientDto : Dto, IIdentifiableDto
    {
        public string        Id                          { get; set; }

        [ApiExportable(0)]
        [Display(Name = "[[[Company name]]]"), Required(ErrorMessage = "[[[Company name is required]]]", AllowEmptyStrings = false)]
        public string        Name                        { get; set; }

        [Display(Name = "[[[Company registration number]]]")]
        public string        CompanyRegistrationNumber   { get; set; }

        [Display(Name = "[[[Contact name]]]")]
        public string        ContactName                 { get; set; }

        [Display(Name = "[[[Contact email]]]")]
        public string        ContactEmail                { get; set; }

        [Display(Name = "[[[Contact number]]]")]
        public string        ContactNumber               { get; set; }

        [Display(Name = "[[[Company contact address]]]")]
        public AddressDto    ContactAddress              { get; set; }

        [Display(Name = "[[[Company billing address]]]")]
        public AddressDto    BillingAddress              { get; set; }

        public ClientTypeDto    ClientType { get; set; }

        public ClientDto()
        {
            BillingAddress=new AddressDto();
            ContactAddress=new AddressDto();
            ClientType=new ClientTypeDto();
        }


        public override string ToString()
        {
            return $"{Name} / {ContactEmail} / {ContactNumber}";
        }
    }
}