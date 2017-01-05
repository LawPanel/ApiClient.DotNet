using LawPanel.ApiClient.Abstractions.Interfaces;

namespace LawPanel.ApiClient.Abstractions.Base
{
    public abstract class PaginableDto : IPaginableDto, IIdentifiableDto
    {
        public string           Id              { get; set; }

        protected PaginableDto()
        {
        }
    }
}
