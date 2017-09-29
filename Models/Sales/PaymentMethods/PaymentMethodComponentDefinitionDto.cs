using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Sales.PaymentMethods
{
    public class PaymentMethodComponentDefinitionDto : Dto, IIdentifiableDto
    {
        public string           Id              { get; set; }
        public PaymentMethodDto PaymentMethod   { get; set; }
        public string           Name            { get; set; }
        public string           DisplayName     { get; set; }
        public string           ClassName       { get; set; }
        public string           Pattern         { get; set; } // Specifies a regular expression to check the input value against
        public string           Mask            { get; set; }
        public bool             Required        { get; set; } // Specifies that an input field is required(must be filled out)
        public string           SelectFrom      { get; set; } // Serialized items for user pick
        public bool             Disabled        { get; set; } // Specifies that an input field should be disabled
        public int?             Max             { get; set; } // Specifies the maximum value for an input field
        public int?             MaxLength       { get; set; } // Specifies the maximum number of character for an input field
        public int?             Min             { get; set; } // Specifies the minimum value for an input field
        public bool             ReadOnly        { get; set; } // Specifies that an input field is read only(cannot be changed)
        public int?             Step            { get; set; } // Specifies the legal number intervals for an input field
        public string           PlaceHolder     { get; set; }
        public bool             Private         { get; set; }
        public bool             Internal        { get; set; }
        public int              DisplayOrder    { get; set; }
    }
}