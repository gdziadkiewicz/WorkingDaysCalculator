using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace WorkingDays.Tests
{
    public class SimpleWorkingDaysCalculatorTests
    {
        private readonly IEnumerable<DayOfWeek> _workingWeekDays;
        private readonly Date[] _noHolidays = {};

        public SimpleWorkingDaysCalculatorTests()
        {
            _workingWeekDays =
                Enum.GetValues(typeof(DayOfWeek))
                    .Cast<DayOfWeek>()
                    .Where(x => x != DayOfWeek.Saturday && x != DayOfWeek.Sunday);
        }

        [Test]
        public void ShouldReturn1ForTheSameWorkingDate()
        {
            var sut = new SimpleWorkingDaysCalculator();
            var normalWorkingDay = new Date(2016, 5, 25);
            var workingWeekDays = _workingWeekDays;
            var holidays = _noHolidays;
            const uint expectedResult = 1u;

            Assert.That(
                normalWorkingDay.Value.DayOfWeek != DayOfWeek.Sunday &&
                normalWorkingDay.Value.DayOfWeek != DayOfWeek.Saturday, "Unit test sainty check failed");
            var result = sut.GetNumberOfWOrkingDays(normalWorkingDay, normalWorkingDay, workingWeekDays, holidays);
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void ShouldReturn0ForTheSameNotWorkingDate()
        {
            var sut = new SimpleWorkingDaysCalculator();
            var notWorkingWeekDay = new Date(2016, 5, 28);
            var workingWeekDays = _workingWeekDays;
            var holidays = _noHolidays;
            const uint expectedResult = 0u;

            Assert.That(
                notWorkingWeekDay.Value.DayOfWeek == DayOfWeek.Sunday ||
                notWorkingWeekDay.Value.DayOfWeek == DayOfWeek.Saturday, "Unit test sainty check failed");

            var result = sut.GetNumberOfWOrkingDays(notWorkingWeekDay, notWorkingWeekDay, workingWeekDays, holidays);
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void ShouldReturn5ForStandardWorkWeek()
        {
            var sut = new SimpleWorkingDaysCalculator();
            var startDay =  new Date(2016,6,27);
            var endDate =  new Date(2016,7, 1);
            var workingWeekDays = _workingWeekDays;
            var holidays = _noHolidays;
            const uint expectedResult = 5u;

            var result = sut.GetNumberOfWOrkingDays(startDay,endDate, workingWeekDays, holidays);
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void ShouldReturn5ForStandardWorkWeekWthSwitchedStartAndEndDates()
        {
            var sut = new SimpleWorkingDaysCalculator();
            var startDay = new Date(2016, 6, 27);
            var endDate = new Date(2016, 7, 1);
            var workingWeekDays = _workingWeekDays;
            var holidays = _noHolidays;
            const uint expectedResult = 5u;

            var result = sut.GetNumberOfWOrkingDays(endDate, startDay, workingWeekDays, holidays);
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void ShouldReturn4ForStandardWorkWeekWith1Holiday()
        {
            var sut = new SimpleWorkingDaysCalculator();
            var startDay = new Date(2016, 6, 27);
            var endDate = new Date(2016, 7, 1);
            var workingWeekDays = _workingWeekDays;
            var holidays = new Date[] {new Date(2016, 6, 27)};
            const uint expectedResult = 4u;

            var result = sut.GetNumberOfWOrkingDays(startDay, endDate, workingWeekDays, holidays);
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void ShouldReturn5ForStandardkWeek()
        {
            var sut = new SimpleWorkingDaysCalculator();
            var startDay = new Date(2016, 6, 27);
            var endDate = new Date(2016, 7, 3);
            var workingWeekDays = _workingWeekDays;
            var holidays = _noHolidays;
            const uint expectedResult = 5u;

            var result = sut.GetNumberOfWOrkingDays(startDay, endDate, workingWeekDays, holidays);
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void ShouldReturn5ForStandardkWeekWithTwoHolidaysOnWeekend()
        {
            var sut = new SimpleWorkingDaysCalculator();
            var startDay = new Date(2016, 6, 27);
            var endDate = new Date(2016, 7, 3);
            var workingWeekDays = _workingWeekDays;
            var holidays = new []{new Date(2016,7,2), new Date(2016, 7, 3)};
            const uint expectedResult = 5u;

            var result = sut.GetNumberOfWOrkingDays(startDay, endDate, workingWeekDays, holidays);
            Assert.AreEqual(expectedResult, result);
        }
    }
}