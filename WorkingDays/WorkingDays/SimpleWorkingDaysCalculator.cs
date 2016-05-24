using System;
using System.Collections.Generic;

namespace WorkingDays
{
    public class SimpleWorkingDaysCalculator : IAdvancedWorkingDaysCalculator
    {
        public uint GetNumberOfWOrkingDays(Date start, Date end, IEnumerable<DayOfWeek> workingWeekDays, IEnumerable<Date> holidays)
        {
            return 1;
        }
    }
}