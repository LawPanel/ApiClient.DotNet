using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Helpers
{
    public class EmailExtractedDto : Dto, IIdentifiableDto
    {
        public virtual string Name { get; set; }
        public virtual string Url { get; set; }
        public virtual string ImageLogoSrc { get; set; }
        public virtual string OrganizationFoundedInfo { get; set; }
        public virtual string LocationHref { get; set; }
        public virtual string LocationImgSrc { get; set; }
        public virtual string HeaderText { get; set; }
        public virtual string WebsiteHref { get; set; }
        public virtual string AddressText { get; set; }
        public virtual string PhoneText { get; set; }
        public virtual string Description { get; set; }
        public virtual string HeaderSubText { get; set; }
        public virtual string Email { get; set; }
        public virtual string BelongsToDomainName { get; set; }
        public virtual string ExtractedFrom { get; set; }

        public string Id { get; set; }
    }
}
