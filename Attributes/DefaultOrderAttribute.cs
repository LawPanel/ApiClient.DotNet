using System;

namespace LawPanel.ApiClient.Attributes
{

    /// <summary>
    /// 
    /// </summary>
    public enum OrderDirection
    {

        /// <summary>
        /// Ascending order
        /// </summary>
        Asc,


        /// <summary>
        /// Descending order
        /// </summary>
        Desc
    }

    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class DefaultOrderAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly int Weight;

        /// <summary>
        /// 
        /// </summary>
        public readonly OrderDirection OrderOrderDirection;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="weight"></param>
        /// <param name="orderDirection"></param>
        public DefaultOrderAttribute(int weight, OrderDirection orderDirection)
        {
            Weight = weight;
            OrderOrderDirection = orderDirection;
        }
    }
}