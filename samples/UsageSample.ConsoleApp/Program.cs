namespace UsageSample.ConsoleApp;

using Trustsoft.HolidaysCalendar.Contracts;
using Trustsoft.HolidaysCalendar.DataProviders;
using Trustsoft.HolidaysCalendar;

internal static class Program
{
    private static readonly int CurrentYear = DateTime.Now.Year;
    private static readonly Random Rnd = new Random(Environment.TickCount);

    static void Main(string[] args)
    {
        Console.WriteLine("HolidaysCalendar Sample Usage");

        IHolidaysCalendar calendar = new HolidaysCalendar();
        var dataProvider = new XmlCalendarDataProvider();
        calendar.Initialize(dataProvider);

        foreach (var date in Program.GetTestDays())
        {
            var result = calendar.IsHoliday(date);
            Console.WriteLine($"Date {date:dd.MM.yyyy} is holiday = {result}");
        }

        Console.ReadLine();
    }

    private static IEnumerable<DateOnly> GetTestDays()
    {
        var list = new List<DateOnly>();

        for (int i = 0; i < 18; i++)
        {
            list.Add(GetRandomDateOnly());
        }
        list.Add(new DateOnly(2022, 1, 1));
        list.Add(new DateOnly(2023, 1, 3));
        list.Add(new DateOnly(2024, 1, 2));

        foreach (var dateOnly in list.OrderBy(d => d))
        {
            yield return dateOnly;
        }
    }

    private static DateOnly GetRandomDateOnly()
    {
        var year = Program.Rnd.Next(CurrentYear - 2, CurrentYear);
        var month = Program.Rnd.Next(1, 12);
        var day = Program.Rnd.Next(1, DateTime.DaysInMonth(year, month));
        return new DateOnly(year, month, day);
    }
}
