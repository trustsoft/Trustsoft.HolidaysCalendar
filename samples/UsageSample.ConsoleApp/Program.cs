namespace UsageSample.ConsoleApp;

using Trustsoft.HolidaysCalendar;
using Trustsoft.HolidaysCalendar.Contracts;
using Trustsoft.HolidaysCalendar.DataProviders;

internal static class Program
{
    private static readonly Random Rnd = new Random(Environment.TickCount);

    static void Main()
    {
        Console.WriteLine("//-------------------------------//");
        Console.WriteLine("// HolidaysCalendar Sample Usage //");
        Console.WriteLine("//-------------------------------//");

        IHolidaysCalendar calendar = new HolidaysCalendar();
        var dataProvider = new XmlCalendarDataProvider();
        calendar.Initialize(dataProvider);

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
        Console.WriteLine("HolidaysCalendar.AdjustForHolidays(DateOnly date) usage");
        Console.WriteLine();
        number = 0;
        foreach (var date in dates)
        {
            var result = calendar.AdjustForHolidays(date);
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
        list.Add(new DateOnly(2024, 1, 2));
        list.Add(new DateOnly(2024, 5, 8));

        foreach (var dateOnly in list.OrderBy(d => d))
        {
            yield return dateOnly;
        }
    }

    private static DateOnly GetRandomDateOnly()
    {
        var month = Rnd.Next(1, 12);
        var day = Program.Rnd.Next(1, DateTime.DaysInMonth(2024, month));
        return new DateOnly(2024, month, day);
    }
}