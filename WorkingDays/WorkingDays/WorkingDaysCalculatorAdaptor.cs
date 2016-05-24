using System;

namespace WorkingDays
{
    public class WorkingDaysCalculatorAdaptor : IBasicWorkingDaysCalculator
    {
        private static readonly DayOfWeek[] StandardWorkingWeekDays = { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday };
        private static readonly Date[] StandardHolidays = { };

        private readonly IAdvancedWorkingDaysCalculator _calculator;
        private readonly Date[] _holidays;
        private DayOfWeek[] _workingWeekDays;

        public WorkingDaysCalculatorAdaptor(IAdvancedWorkingDaysCalculator calculator, DayOfWeek[] workingWeekDays = null, Date[] holidays = null)
        {
            _calculator = calculator;
            _workingWeekDays = workingWeekDays ?? StandardWorkingWeekDays;
            _holidays = holidays ?? StandardHolidays;
        }

        public uint GetNumberOfWOrkingDays(Date start, Date end) => _calculator.GetNumberOfWOrkingDays(start, end, StandardWorkingWeekDays, StandardHolidays);
    }
}