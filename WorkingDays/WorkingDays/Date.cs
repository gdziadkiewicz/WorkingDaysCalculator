using System;

namespace WorkingDays
{
    public struct Date
    {
        private readonly DateTime _date;

        public Date(int year, int month, int day)
        {
            _date = new DateTime(year, month, day);
        }

        private Date(DateTime dateTime)
        {
            _date = dateTime.Date;
        }

        private Date(DateTimeOffset dateTimeOffset) : this(dateTimeOffset.DateTime)
        {
        }

        public DateTime Value => _date;

        public static Date FromDateTime(DateTime dateTime) => new Date(dateTime);
        public static Date FromDateTimeOffset(DateTimeOffset dateTimeOffset) => new Date(dateTimeOffset);
        
    }
}