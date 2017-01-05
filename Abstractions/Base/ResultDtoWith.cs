namespace LawPanel.ApiClient.Abstractions.Base
{
    public class ResultDtoWith<TResource> : ResultDto
    {
      
        public  TResource    Resource       { get; set; }
        public  string       ResourceName   { get; set; }
        private string       ResourceId     { get; set; }

        public ResultDtoWith(bool successfull, string resourceId, TResource resource, string message="") : base(resourceId, successfull, message)
        {
            ResourceName = typeof (TResource).Name;
            ResourceId = resourceId;
            Resource = resource;
        }

        public TResource GetResource()
        {
            return Resource;
        }

    }
}
