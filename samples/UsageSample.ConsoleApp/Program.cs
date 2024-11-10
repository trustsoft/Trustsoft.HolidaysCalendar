namespace UsageSample.ConsoleApp;

using Trustsoft.HolidaysCalendar;
using Trustsoft.HolidaysCalendar.Contracts;
using Trustsoft.HolidaysCalendar.DataProviders;

internal static class Program
{
    private static readonly int CurrentYear = DateTime.Now.Year;
    private static readonly Random Rnd = new Random(Environment.TickCount);

    static void Main()
    {
        Console.WriteLine("HolidaysCalendar Sample Usage");

        IHolidaysCalendar calendar = new HolidaysCalendar();
        var dataProvider = new XmlCalendarDataProvider();
        calendar.Initialize(dataProvider);
        var number = 0;
        foreach (var date in GetTestDays())
        {
            var result = calendar.IsHoliday(date);
            Console.WriteLine($"#{++number:00}: {date:dd.MM.yyyy} is holiday = {result}");
        }

        Console.ReadLine();
    }

    private static IEnumerable<DateOnly> GetTestDays()
    {
        var list = new List<DateOnly>();

        for (int i = 0; i < 21; i++)
        {
            list.Add(GetRandomDateOnly());
        }
        list.Add(new DateOnly(CurrentYear, 1, 2));

        foreach (var dateOnly in list.OrderBy(d => d))
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
