using System;

namespace LawPanel.ApiClient.Attributes
{
    /// <summary>
    /// This property is exportable via API ?
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ApiExportableAttribute : Attribute
    {
        public readonly int Order;

        public ApiExportableAttribute(int order)
        {
            Order = order;
        }
    }
}