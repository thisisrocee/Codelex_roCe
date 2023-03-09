namespace Exercise14
{
    public class DateTest
    {
        static void Main(string[] args)
        {
            var date1 = new Date(1970, 9, 21);
            var date2 = new Date(1945, 9, 2);
            var date3 = new Date(2001, 9, 11);

            Console.WriteLine(date1.WeekDayInDutch());
            Console.WriteLine(date2.WeekDayInDutch());
            Console.WriteLine(date3.WeekDayInDutch());
        }
    }
}
