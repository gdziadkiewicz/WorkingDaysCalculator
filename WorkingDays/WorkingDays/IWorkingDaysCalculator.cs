using System;
using System.Collections.Generic;

namespace WorkingDays
{
    public interface IWorkingDaysCalculator
    {
        uint GetNumberOfWOrkingDays(Date date1, Date date2, IEnumerable<DayOfWeek> workingWeekDays, IEnumerable<Date> holidays );

    }
}