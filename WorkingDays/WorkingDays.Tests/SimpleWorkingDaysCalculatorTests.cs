using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace WorkingDays.Tests
{
    public class SimpleWorkingDaysCalculatorTests
    {
        private readonly IEnumerable<DayOfWeek> _workingWeekDays;
        private readonly Date[] _noHolidays = new Date[] {};

        public SimpleWorkingDaysCalculatorTests()
        {
            _workingWeekDays = Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>().Where(x => x != DayOfWeek.Saturday && x != DayOfWeek.Sunday);

        }

        [Test]
        public void ShouldReturn1ForTheSameWorkingDate()
        {
            var sut = new SimpleWorkingDaysCalculator();
            var normalWorkingDay = new Date(2016, 5, 25);
            var expectedResult = 1u;

            Assert.That(normalWorkingDay.Value.DayOfWeek != DayOfWeek.Sunday && normalWorkingDay.Value.DayOfWeek != DayOfWeek.Saturday, "Unit test sainty check failed");
            Assert.AreEqual(expectedResult, sut.GetNumberOfWOrkingDays(normalWorkingDay, normalWorkingDay, _workingWeekDays, _noHolidays));
        }

        [Test]
        public void ShouldReturn0ForTheSameNotWorkingDate()
        {
            var sut = new SimpleWorkingDaysCalculator();
            var notWorkingWeekDay = new Date(2016, 5, 28);
            var expectedResult = 0u;

            Assert.That(notWorkingWeekDay.Value.DayOfWeek == DayOfWeek.Sunday || notWorkingWeekDay.Value.DayOfWeek == DayOfWeek.Saturday, "Unit test sainty check failed");
            Assert.AreEqual(expectedResult, sut.GetNumberOfWOrkingDays(notWorkingWeekDay, notWorkingWeekDay, _workingWeekDays, _noHolidays));
        }
    }
}
