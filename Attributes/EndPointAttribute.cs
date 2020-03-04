using System;

namespace LawPanel.ApiClient.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class EndPointAttribute : Attribute
    {
        public readonly string Url;

        public EndPointAttribute(string url)
        {
            Url = url;
        }
    }
}