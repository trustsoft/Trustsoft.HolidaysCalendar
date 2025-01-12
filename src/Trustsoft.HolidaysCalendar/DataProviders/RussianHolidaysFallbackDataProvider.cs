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

/// <summary>
///   Russian holidays fallback data provider for <see cref="IHolidaysCalendar" /> implementation.
/// </summary>
/// <remarks> Generated data contains dates of all major Russian holidays. </remarks>
/// <seealso cref="IFallbackHolidaysDataProvider" />
public class RussianHolidaysFallbackDataProvider : IFallbackHolidaysDataProvider
{
    private readonly IReadOnlyList<HolidayData> holidayDescriptions =
    [
        // "New Year's Day" / "Новогодние праздники"
        new HolidayData(Month: 1, [1, 2, 3, 4, 5, 6, 8]),
        // "Orthodox Christmas Day" / "Рождество Христово"
        new HolidayData(Month: 1, [7]),
        // "Defender of the Fatherland Day" / "День защитника Отечества"
        new HolidayData(Month: 2, [23]),
        // "International Women's Day" / "Международный женский день"
        new HolidayData(Month: 3, [8]),
        // "Spring and Labor Day" / "Праздник Весны и Труда"
        new HolidayData(Month: 5, [1]),
        // "Victory Day" / "День Победы"
        new HolidayData(Month: 5, [9]),
        // "Russia Day" / "День России"
        new HolidayData(Month: 6, [12]),
        // "Unity Day" / "День народного единства"
        new HolidayData(Month: 11, [4]),
    ];

    private readonly Dictionary<int, List<DateOnly>> holidaysCache = [];

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

    /// <summary>
    ///   Gets the generated holidays data for specified year.
    /// </summary>
    /// <param name="year"> The year to get holidays data for. </param>
    /// <remarks> Generated data contains all major Russian holidays. </remarks>
    /// <returns>
    ///   The <see cref="IHolidaysData" /> object that contains
    ///   a result of fetching holidays data for specified year.
    /// </returns>
    public IHolidaysData GetHolidaysData(int year)
    {
        if (!this.holidaysCache.Keys.Contains(year))
        {
            Debug.WriteLine($"DATA CREATED FOR YEAR: {year}");
            this.GenerateDataForYear(year);
        }

        var holidays = this.holidaysCache[year];
        return HolidaysDataFactory.Valid(holidays);
    }

    private record HolidayData(int Month, List<int> Days)
    {
        public IEnumerable<DateOnly> GetDatesForYear(int year)
        {
            return this.Days.Select(day => new DateOnly(year, this.Month, day));
        }
    }
}