using System;
using System.Globalization;

namespace Belyi.Nsudotnet.Calendar
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter the date: ");
            var readString = Console.ReadLine();

            DateTime readDate;
            if (DateTime.TryParse(readString, out readDate))
            {
                if (DateTimeFormatInfo.CurrentInfo != null)
                    foreach (var dayOfWeek in DateTimeFormatInfo.CurrentInfo.AbbreviatedDayNames)
                        Console.Write($"{dayOfWeek}\t");
                Console.WriteLine();

                var startDayOfWeek = (int) new DateTime(readDate.Year, readDate.Month, 1).DayOfWeek;
                for (var i = 0; i < startDayOfWeek; i++)
                    Console.Write("\t");

                var counterWorkdays = 0;
                for (var day = 1; day <= DateTime.DaysInMonth(readDate.Year, readDate.Month); day++)
                {
                    if (day == DateTime.Now.Day && readDate.Month == DateTime.Now.Month &&
                        readDate.Year == DateTime.Now.Year)
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    else if (day == readDate.Day)
                        Console.BackgroundColor = ConsoleColor.Blue;

                    Console.ForegroundColor = (day + startDayOfWeek) % 7 == 1 ? ConsoleColor.Red : ConsoleColor.Gray;
                    if (Console.ForegroundColor == ConsoleColor.Gray)
                        counterWorkdays++;

                    Console.Write(day);
                    Console.BackgroundColor = ConsoleColor.Black;

                    Console.Write((day + startDayOfWeek) % 7 == 0 ? "\n" : "\t");
                }
                Console.WriteLine($"\nNumber of workdays: {counterWorkdays}");
            }
            else
                Console.WriteLine($"'{readString}' is not date.");

            Console.ReadKey();
        }
    }
}