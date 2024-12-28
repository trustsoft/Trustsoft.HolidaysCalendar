// -------------------------Copyright © 2024 M.Sukhanov. All rights reserved.-------------------------
//  <copyright file="TestDataItem.cs" author="M.Sukhanov">
//      Copyright © 2024 M.Sukhanov. All rights reserved.
//  </copyright>
//  <date>23.11.2024</date>
// -------------------------Copyright © 2024 M.Sukhanov. All rights reserved.-------------------------

namespace Trustsoft.HolidaysCalendar.Tests.TestData;

public record TestDataItem
{
    private TestDataItem(DateOnly Day, bool IsHoliday, bool IsWorkingWeekend, bool IsWeekend)
    {
        this.Day = Day;
        this.IsHoliday = IsHoliday;
        this.IsWeekend = (IsWeekend || Day.DayOfWeek is DayOfWeek.Sunday or DayOfWeek.Saturday) && !IsWorkingWeekend;
        this.IsWorkingWeekend = IsWorkingWeekend;
    }

    public static TestDataItem Working(string date)
    {
        var day = DateOnly.ParseExact(date, "yyyy.MM.dd");
        return new TestDataItem(Day: day,
                                IsHoliday: false,
                                IsWorkingWeekend: false,
                                IsWeekend: false);
    }

    public static TestDataItem Holiday(string date, bool isWeekend = false)
    {
        var day = DateOnly.ParseExact(date, "yyyy.MM.dd");
        return new TestDataItem(Day: day,
                                IsHoliday: true,
                                IsWorkingWeekend: false,
                                IsWeekend: isWeekend);
    }

    public static TestDataItem Holiday(DateOnly date, bool isWeekend)
    {
        return new TestDataItem(Day: date,
                                IsHoliday: true,
                                IsWorkingWeekend: false,
                                IsWeekend: isWeekend);
    }

    public static TestDataItem Weekend(string date)
    {
        var day = DateOnly.ParseExact(date, "yyyy.MM.dd");
        return new TestDataItem(Day: day,
                                IsHoliday: false,
                                IsWorkingWeekend: false,
                                IsWeekend: true);
    }

    public static TestDataItem WorWeek(string date)
    {
        var day = DateOnly.ParseExact(date, "yyyy.MM.dd");
        return new TestDataItem(Day: day,
                                IsHoliday: false,
                                IsWorkingWeekend: true,
                                IsWeekend: false);
    }

    public DateOnly Day { get; }

    public bool IsHoliday { get; }

    public bool IsWeekend { get; }

    public bool IsWorkingWeekend { get; }

    public override string ToString()
    {
        return $"Day: {this.Day}, H: {this.IsHoliday}, W: {this.IsWeekend}, WW: {this.IsWorkingWeekend}";
    }
}