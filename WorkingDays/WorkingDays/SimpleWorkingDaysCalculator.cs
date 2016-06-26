using System;
using System.Collections.Generic;
using System.Linq;

namespace WorkingDays
{
    public class SimpleWorkingDaysCalculator : IWorkingDaysCalculator
    {
        /// <summary>
        /// Returns number of working days between two given dates for given working days of week and holidays.
        /// </summary>
        /// <param name="date1">first inclusive endpoint of the date interval</param>
        /// <param name="date2">second inclusive endpoint of the date interval</param>
        /// <param name="workingWeekDays"> working days of week collection </param>
        /// <param name="holidays"> holidays collection</param>
        /// <returns> number of working days</returns>
        public uint GetNumberOfWOrkingDays(Date date1, Date date2, IEnumerable<DayOfWeek> workingWeekDays, IEnumerable<Date> holidays)
        {
            var daysBetween = GetAllDaysBetween(date1, date2);
            var workingDays = FilterNonWorkingDays(daysBetween, workingWeekDays, holidays);

            return (uint)workingDays.Count();
        }

        private IEnumerable<DateTime> FilterNonWorkingDays(IEnumerable<DateTime> days, IEnumerable<DayOfWeek> workingWeekDays, IEnumerable<Date> holidays)
        {
            var workingWeekDaysSet = new HashSet<DayOfWeek>(workingWeekDays);
            var holidaysDateTimesSet = new HashSet<DateTime>(holidays.Select(day => day.Value));

            return days.Where(day => workingWeekDaysSet.Contains(day.DayOfWeek) && !holidaysDateTimesSet.Contains(day));
        }

        private IEnumerable<DateTime> GetAllDaysBetween(Date date1, Date date2)
        {
            var dateTime1 = date1.Value;
            var dateTime2 = date2.Value;

            var start = dateTime1 < dateTime2 ? dateTime1 : dateTime2;
            var end = start == dateTime1 ? dateTime2 : dateTime1;

            for (var day = start; day <= end; day = day.AddDays(1))
            {
                yield return day;
            }
        }
    }
}