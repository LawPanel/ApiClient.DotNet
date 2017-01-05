using System;
using System.Collections.Generic;
using System.Linq;
using LawPanel.ApiClient.Models;

namespace LawPanel.ApiClient.Extensions
{
    public static class ListFrequencyDtoExt
    {
        public static FrequencyDto Weekly(this List<FrequencyDto> list)
        {
            var item = list.FirstOrDefault(f => f.Years == 0 && f.Months == 0 && f.Days == 7 && f.Hours == 0 && f.Minutes == 0 && f.Seconds == 0);
            if (item==null) throw new Exception("Weekly frequency not exist!!");
            return item;
        }

        public static FrequencyDto BiWeekly(this List<FrequencyDto> list)
        {
            var item = list.FirstOrDefault(f => f.Years == 0 && f.Months == 0 && f.Days == 14 && f.Hours == 0 && f.Minutes == 0 && f.Seconds == 0);
            if (item == null) throw new Exception("Bi-Weekly frequency not exist!!");
            return item;
        }

        public static FrequencyDto Monthly(this List<FrequencyDto> list)
        {
            var item = list.FirstOrDefault(f => f.Years == 0 && f.Months == 1 && f.Days == 0 && f.Hours == 0 && f.Minutes == 0 && f.Seconds == 0);
            if (item == null) throw new Exception("Monthly frequency not exist!!");
            return item;
        }
    }
}
