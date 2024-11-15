// -------------------------Copyright © 2024 M.Sukhanov. All rights reserved.-------------------------
//  <copyright file="FallbackDataProvider.cs" author="M.Sukhanov">
//      Copyright © 2024 M.Sukhanov. All rights reserved.
//  </copyright>
//  <date>15.11.2024</date>
// -------------------------Copyright © 2024 M.Sukhanov. All rights reserved.-------------------------

namespace Trustsoft.HolidaysCalendar.DataProviders;

using System.Diagnostics;
using System.Runtime.InteropServices;
using Trustsoft.HolidaysCalendar.Contracts;

public class FallbackDataProvider : IFallbackDataProvider
{
    private readonly IReadOnlyList<HolidayData> holidayDescriptions =
    [
        // "Новогодние праздники"
        new HolidayData(Month: 1, [1, 2, 3, 4, 5, 6, 7, 8]),
        // "День защитника Отечества"
        new HolidayData(Month: 2, [23]),
        // "Международный женский день"
        new HolidayData(Month: 3, [8]),
        // "Праздник Весны и Труда"
        new HolidayData(Month: 5, [1]),
        // "День Победы"
        new HolidayData(Month: 5, [9]),
        // "День России"
        new HolidayData(Month: 6, [12]),
        // "День народного единства"
        new HolidayData(Month: 11, [4]),
    ];

    private readonly Dictionary<int, List<DateOnly>> holidaysCache = [];

    public IHolidaysData GetHolidaysData(int year)
    {
        if (!this.holidaysCache.Keys.Contains(year))
        {
            Debug.WriteLine($"DATA CREATED FOR YEAR: {year}");
            this.GenerateDataForYear(year);
        }

        var holidays = this.holidaysCache[year];
        return HolidaysData.Valid(holidays);
    }

    private void GenerateDataForYear(int year)
    {
        var list = from holiday in this.holidayDescriptions
                   from date in holiday.GetDatesForYear(year)
                   //where date.DayOfWeek is not (DayOfWeek.Saturday or DayOfWeek.Sunday)
                   select date;

        ref var @default = ref CollectionsMarshal.GetValueRefOrAddDefault(this.holidaysCache, year, out var res);

        if (!res)
        {
            @default = new List<DateOnly>();
        }

        @default?.AddRange(list);
    }

    private record HolidayData(int Month, List<int> Days)
    {
        public IEnumerable<DateOnly> GetDatesForYear(int year)
        {
            return this.Days.Select(day => new DateOnly(year, this.Month, day));
        }
    }
}