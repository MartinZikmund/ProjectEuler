using System;
using System.Diagnostics;

namespace Problem19
{
    class Program
    {
        static void Main(string[] args)
        {
            var sundayCount = 0;
            for (int year = 1901; year <= 2000; year++)
            {
                for (int month = 1; month <= 12; month++)
                {
                    var date = new DateTime(year, month, 1);
                    if (date.DayOfWeek == DayOfWeek.Sunday) sundayCount++;
                }
            }

            Console.WriteLine(sundayCount);

            sundayCount = 0;
            var firstDay = DayOfWeek.Monday;
            for (int i = 1; i <= 12; i++)
            {
                firstDay = GetNextMonthFirst(1900, i, firstDay);
            }
            for (int year = 1901; year <= 2000; year++)
            {
                for (int month = 1; month <= 12; month++)
                {
                    if (firstDay == DayOfWeek.Sunday) sundayCount++;
                    firstDay = GetNextMonthFirst(year, month, firstDay);
                }
            }
            Console.WriteLine(sundayCount);
        }

        private static DayOfWeek GetNextMonthFirst(int year, int month, DayOfWeek currentFirstDay)
        {            
            var daysInMonth = 31;
            if (month == 9 || month == 4 || month == 6 || month == 11)
            {
                daysInMonth = 30;
            }
            else if (month == 2)
            {
                daysInMonth = year % 4 == 0 && ( year % 100 != 0  || year % 400 == 0 ) ? 29 : 28;
            }
            return (DayOfWeek)(((int) currentFirstDay + daysInMonth) % 7);
        }
    }
}
