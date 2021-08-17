using System;
using System.Collections.Generic;
using System.Globalization;

namespace MLVSoft_Common.Utilities
{
    public static class DateTimeUtilities
    {
        public static int GetWeekNumbers(int year)
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            DateTime date1 = new DateTime(year, 12, 31);
            Calendar cal = dfi.Calendar;
            return cal.GetWeekOfYear(date1, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
        }

        public static List<string> GetListWeekNumbers(int nWeeks, string weekName)
        {
            List<string> weekList = new List<string>();

            for (int i = 1; i < nWeeks + 1; i++)
                weekList.Add(string.Format("{0} {1}", weekName, i < 10 ? "0" + i.ToString() : i.ToString()));

            return weekList;
        }
    }
}