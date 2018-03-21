using System.Collections.Generic;
using System.Linq;

namespace LawPanel.ApiClient.Extensions
{
    public static class ListStringExt
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string CommaSeparatedItems(this List<string> list)
        {
            return list.Count == 0 ? string.Empty : list.Select(m => m).Aggregate((accumulator, piece) => accumulator + "," + piece);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string SeparatedItemsBy(this List<string> list, string separator)
        {
            return list.Count == 0 ? string.Empty : list.Select(m => m).Aggregate((accumulator, piece) => accumulator + separator + piece);
        }
    }
}
