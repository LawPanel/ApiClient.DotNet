using System;
using System.Linq;
using System.Text;
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

        public static string CamelCaseToLowerCamelCase(this string camelCaseString)
        {
            if (camelCaseString == null) return null;
            if (camelCaseString == string.Empty) return string.Empty;


            var firstCharacter = camelCaseString[0].ToString().ToLowerInvariant();
            var theRest = "";

            if (camelCaseString.Length > 1)
            {
                theRest = camelCaseString.Substring(1);
            }

            var result = $"{firstCharacter}{theRest}";

            return result;

        }

        public static Guid ToGuid(this string stringValue)
        {
            Guid toReturn;
            var safeString = stringValue.Replace("_", "-").Trim();
            Guid.TryParse(safeString, out toReturn);
            return toReturn;
        }

        public static string ToHexString(this string str)
        {
            var sb = new StringBuilder();

            var bytes = Encoding.Unicode.GetBytes(str);
            foreach (var t in bytes)
            {
                sb.Append(t.ToString("X2"));
            }

            return sb.ToString(); // returns: "48656C6C6F20776F726C64" for "Hello world"
        }

        public static string FromHexString(this string hexString)
        {
            var bytes = new byte[hexString.Length / 2];
            for (var i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }

            return Encoding.Unicode.GetString(bytes, 0, bytes.Length); // returns: "Hello world" for "48656C6C6F20776F726C64"
        }
        
        public static string Truncate(this string str, int length)
        {
            if (length < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length), "Length must be >= 0");
            }

            if (str == null)
            {
                return null;
            }

            var maxLength = Math.Min(str.Length, length);
            return str.Substring(0, maxLength);
        }
    }
}
