using System;
using System.Collections.Generic;

namespace WorkingDays
{
    public interface IAdvancedWorkingDaysCalculator
    {
        uint GetNumberOfWOrkingDays(Date start, Date end, IEnumerable<DayOfWeek> workingWeekDays, IEnumerable<Date> holidays );

    }
}