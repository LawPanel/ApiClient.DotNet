using System;
using System.Collections.Generic;

namespace LawPanel.ApiClient.Models.Common
{
    public class PropertyChangedDto
    {
        public string Name      { get; set; }
        public object Original  { get; set; }
        public object Updated   { get; set; }


        public override string ToString()
        {
            return string.Format("[[['%0' changed from '%1' to '%2'|||{0}|||{1}|||{2}]]]", Clear(Name), ToString(Original), ToString(Updated));
        }


        private string ToString(object value)
        {
            switch (Original)
            {
                case DateTime _:
                    return ((DateTime) value).ToString("dd/MM/yyyy"); // TODO: it changes with user settings
                case bool _:
                    return (Boolean) value ? "Yes" : "No";
            }

            return Clear(value.ToString());
        }

        private string Clear(string text)
        {
            return text.Replace("[[[", "").Replace("]]]", "");
        }

    }

    public static class PropertyChangedDtoExt
    {

        public static string AsString(this List<PropertyChangedDto> properties)
        {
            return string.Join(", ", properties);
        }

    }

}
