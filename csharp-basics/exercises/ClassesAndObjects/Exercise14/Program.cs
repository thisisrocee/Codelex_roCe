using System.Globalization;

namespace Exercise14
{
    class Date
    {
        private int _year;
        private int _month;
        private int _day;

        public Date(int year, int month, int day)
        {
            _year = year;
            _month = month;
            _day = day;
        }

        public string WeekDayInDutch()
        {
            var date = new DateTime(_year, _month, _day);
            var culture = new CultureInfo("nl-NL");
            return culture.DateTimeFormat.GetDayName(date.DayOfWeek);
        }
    }
}