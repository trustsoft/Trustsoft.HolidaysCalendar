// -------------------------Copyright © 2024 M.Sukhanov. All rights reserved.-------------------------
//  <copyright file="Program.cs" author="M.Sukhanov">
//      Copyright © 2024 M.Sukhanov. All rights reserved.
//  </copyright>
//  <date>11.11.2024</date>
// -------------------------Copyright © 2024 M.Sukhanov. All rights reserved.-------------------------

namespace UsageSample.ConsoleApp;

using Trustsoft.HolidaysCalendar;
using Trustsoft.HolidaysCalendar.Contracts;

internal static class Program
{
    private static readonly Random Rnd = new Random(Environment.TickCount);
    private static readonly int CurrentYear = DateTime.Today.Year;

    static void Main()
    {
        Console.WriteLine("//--------------------------------------//");
        Console.WriteLine("// RussianHolidaysCalendar Sample Usage //");
        Console.WriteLine("//--------------------------------------//");

        IHolidaysCalendar calendar = new RussianHolidaysCalendar();

        Console.WriteLine();
        Console.WriteLine("HolidaysCalendar.IsHoliday(DateOnly date) usage");
        Console.WriteLine();
        var number = 0;

        var dates = GetTestDays().ToList();

        foreach (var date in dates)
        {
            var result = calendar.IsHoliday(date);
            Console.WriteLine($"#{++number:00}: {date:dd.MM.yyyy} is holiday = {result}");
        }

        Console.WriteLine();
        Console.WriteLine("HolidaysCalendar.IsWeekend(DateOnly date) usage");
        Console.WriteLine();
        number = 0;
        foreach (var date in dates)
        {
            var result = calendar.IsWeekend(date);
            Console.WriteLine($"#{++number:00}: {date:dd.MM.yyyy} is weekend = {result}");
        }

        Console.WriteLine();
        Console.WriteLine("HolidaysCalendar.IsWorkingDay(DateOnly date) usage");
        Console.WriteLine();
        number = 0;
        foreach (var date in dates)
        {
            var result = calendar.IsWorkingDay(date);
            Console.WriteLine($"#{++number:00}: {date:dd.MM.yyyy} is working day = {result}");
        }

        Console.WriteLine();
        Console.WriteLine("HolidaysCalendar.IsWorkingWeekend(DateOnly date) usage");
        Console.WriteLine();
        number = 0;
        foreach (var date in dates)
        {
            var result = calendar.IsWorkingWeekend(date);
            Console.WriteLine($"#{++number:00}: {date:dd.MM.yyyy} is working weekend = {result}");
        }

        Console.WriteLine();
        Console.WriteLine("HolidaysCalendar.GetNextWorkingDay(DateOnly date) usage");
        Console.WriteLine();
        number = 0;
        foreach (var date in dates)
        {
            var result = calendar.GetNextWorkingDay(date);
            Console.WriteLine($"#{++number:00}: {date:dd.MM.yyyy} next working day is = {result}");
        }

        Console.WriteLine();
        Console.WriteLine("HolidaysCalendar.AdjustForHolidaysAndWeekends(DateOnly date) usage");
        Console.WriteLine();
        number = 0;
        foreach (var date in dates)
        {
            var result = calendar.AdjustToWorkingDay(date);
            Console.WriteLine($"#{++number:00}: {date:dd.MM.yyyy} adjusted for holidays day is = {result}");
        }

        Console.ReadLine();
    }

    private static IEnumerable<DateOnly> GetTestDays()
    {
        var list = new List<DateOnly>();

        for (int i = 0; i < 3; i++)
        {
            list.Add(GetRandomDateOnly());
        }
        list.Add(new DateOnly(CurrentYear, month: 1, day: 2));
        list.Add(new DateOnly(CurrentYear, month: 3, day: 8));
        list.Add(new DateOnly(CurrentYear, month: 5, day: 9));

        foreach (var dateOnly in list.OrderBy(date => date))
        {
            yield return dateOnly;
        }
    }

    private static DateOnly GetRandomDateOnly()
    {
        var month = Rnd.Next(1, 12);
        var day = Rnd.Next(1, DateTime.DaysInMonth(CurrentYear, month));
        return new DateOnly(CurrentYear, month, day);
    }
}