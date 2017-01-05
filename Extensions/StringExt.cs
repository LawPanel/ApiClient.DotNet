using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace LawPanel.ApiClient.Extensions
{
    public static class StringExt
    {
        public static string SnakeCaseToCamelCase(this string snakeCaseString)
        {
            return snakeCaseString.Split(new[] { "_" }, StringSplitOptions.RemoveEmptyEntries).Select(s => char.ToUpperInvariant(s[0]) + s.Substring(1, s.Length - 1)).Aggregate(string.Empty, (s1, s2) => s1 + s2);
        }

        public static string CamelCaseToSnakeCase(this string camelCaseString)
        {
            return Regex.Replace(camelCaseString, @"([A-Z])([A-Z][a-z])|([a-z0-9])([A-Z])", "$1$3_$2$4").ToLower();
        }
    }
}
