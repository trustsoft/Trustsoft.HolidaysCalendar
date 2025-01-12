// -------------------------Copyright © 2024 M.Sukhanov. All rights reserved.-------------------------
//  <copyright file="HolidaysCalendar.cs" author="M.Sukhanov">
//      Copyright © 2024 M.Sukhanov. All rights reserved.
//  </copyright>
//  <date>10.11.2024</date>
// -------------------------Copyright © 2024 M.Sukhanov. All rights reserved.-------------------------

namespace Trustsoft.HolidaysCalendar;

using System.Diagnostics;
using Trustsoft.HolidaysCalendar.Contracts;

/// <summary>
///   Provides a set of functions to work with holiday calendar.
/// </summary>
/// <seealso cref="IHolidaysCalendar" />
public class HolidaysCalendar : IHolidaysCalendar
{
    private readonly IHolidaysDataProvider primaryDataProvider;
    private readonly IHolidaysDataProvider fallbackDataProvider;
    private readonly HolidaysDataCache primaryData = new HolidaysDataCache();
    private readonly HolidaysDataCache fallbackData = new HolidaysDataCache();

    /// <summary>
    ///   Initializes a new instance of the <see cref="HolidaysCalendar" /> class with specified data providers.
    /// </summary>
    /// <param name="primaryProvider"> The primary data provider. </param>
    /// <param name="fallbackProvider">
    ///   The fallback data provider, used if <paramref name="primaryProvider" /> fails to provide data.
    /// </param>
    /// <exception cref="System.ArgumentNullException"> primaryProvider </exception>
    /// <exception cref="System.ArgumentNullException"> fallbackProvider </exception>
    public HolidaysCalendar(IHolidaysDataProvider primaryProvider, IFallbackDataProvider fallbackProvider)
    {
        this.primaryDataProvider = primaryProvider ?? throw new ArgumentNullException(nameof(primaryProvider));
        this.fallbackDataProvider = fallbackProvider ?? throw new ArgumentNullException(nameof(fallbackProvider));
    }

    private void EnsureDataLoaded(int year)
    {
        // Primary data provider is a preferred one.
        // If primary cache and fallback cache both has data for specified year
        // we must remove that year from the list of years for which data has been already loaded
        // Если основной и резервный кэши оба содержат данные на указанный год
        // нужно удалить данные на этот год из резервного кэша.
        if (this.primaryData.ContainsDataFor(year) && this.fallbackData.ContainsDataFor(year))
        {
            this.fallbackData.RemoveDataFor(year);
            return;
        }

        // Данные за указанный год уже загружены, используя основной провайдер данных?
        if (this.primaryData.ContainsDataFor(year))
        {
            return;
        }

        // Данные за указанный год отсутствуют загружаем их, используя основной провайдер данных
        Debug.WriteLine($"LOADED DATA FOR YEAR {year}");
        if (this.LoadDataFromMainProvider(year))
        {
            return;
        }

        if (!this.fallbackData.ContainsDataFor(year))
        {
            _ = this.LoadDataFromFallbackProvider(year);
        }
    }

    private bool LoadDataFromMainProvider(int year)
    {
        IHolidaysData data = this.primaryDataProvider.GetHolidaysData(year);

        // update primary data if exists
        return this.primaryData.UpdateData(data, year);
    }

    private bool LoadDataFromFallbackProvider(int year)
    {
        IHolidaysData data = this.fallbackDataProvider.GetHolidaysData(year);

        // update fallback data if exists
        return this.fallbackData.UpdateData(data, year);
    }

    /// <summary>
    ///   Adjusts the specified <paramref name="date" /> to ensure it is not a holiday or a weekend.
    /// </summary>
    /// <param name="date"> The date to adjust for. </param>
    /// <returns> The specified <paramref name="date" /> if it`s a working day or next working day otherwise. </returns>
    [Obsolete("AdjustForHolidaysAndWeekends is deprecated, please use AdjustToWorkingDay instead.")]
    public DateOnly AdjustForHolidaysAndWeekends(DateOnly date)
    {
        return this.AdjustToWorkingDay(date);
    }

    /// <summary>
    ///   Adjusts the specified <paramref name="date" /> to ensure it is not a holiday or a weekend.
    /// </summary>
    /// <param name="date"> The date to adjust for. </param>
    /// <returns> The specified <paramref name="date" /> if it`s a working day or next working day otherwise. </returns>
    public DateOnly AdjustToWorkingDay(DateOnly date)
    {
        this.EnsureDataLoaded(date.Year);

        while (this.IsHoliday(date) || this.IsWeekend(date))
        {
            date = date.AddDays(1);
        }

        return date;
    }

    /// <summary>
    ///   Gets the next working day after specified <paramref name="date" />.
    /// </summary>
    /// <param name="date"> The date to check for. </param>
    /// <returns> The next working day. </returns>
    public DateOnly GetNextWorkingDay(DateOnly date)
    {
        this.EnsureDataLoaded(date.Year);

        do
        {
            date = date.AddDays(1);
        }
        while (this.IsHoliday(date) || this.IsWeekend(date));

        return date;
    }

    /// <summary>
    ///   Determines whether the specified <paramref name="date" /> is holiday.
    /// </summary>
    /// <param name="date"> The date to check for. </param>
    /// <returns> <see langword="true" /> if the specified date is holiday; otherwise, <see langword="false" />. </returns>
    public bool IsHoliday(DateOnly date)
    {
        this.EnsureDataLoaded(date.Year);

        return this.primaryData.IsHoliday(date) || this.fallbackData.IsHoliday(date);
    }

    /// <summary>
    ///   Determines whether the specified <paramref name="date" /> is working weekend.
    /// </summary>
    /// <param name="date"> The date to check for. </param>
    /// <returns> <see langword="true" /> if the specified date is a working weekend; otherwise, <see langword="false" />. </returns>
    public bool IsWorkingWeekend(DateOnly date)
    {
        this.EnsureDataLoaded(date.Year);

        return this.primaryData.IsWorkingWeekend(date) || this.fallbackData.IsWorkingWeekend(date);
    }

    /// <summary>
    ///   Determines whether the specified <paramref name="date" />
    ///   is a weekend, taking into account working weekends.
    /// </summary>
    /// <param name="date"> The date to check for. </param>
    /// <returns> <see langword="true" /> if the specified date is a weekend; otherwise, <see langword="false" />. </returns>
    public bool IsWeekend(DateOnly date)
    {
        return date.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday &&
               !this.IsWorkingWeekend(date);
    }

    /// <summary>
    ///   Determines whether the specified <paramref name="date" /> is a working day.
    /// </summary>
    /// <param name="date"> The date to check for. </param>
    /// <returns> <see langword="true" /> if the specified date is a working day; otherwise, <see langword="false" />. </returns>
    public bool IsWorkingDay(DateOnly date)
    {
        if (this.IsWorkingWeekend(date))
        {
            return true;
        }

        return !(this.IsWeekend(date) || this.IsHoliday(date));
    }

    private class HolidaysDataCache
    {
        private readonly HashSet<DateOnly> holidays = [];
        private readonly HashSet<DateOnly> workingWeekends = [];
        private readonly HashSet<int> years = [];

        public bool UpdateData(IHolidaysData holidaysData, int year)
        {
            if (!holidaysData.IsValid)
            {
                return false;
            }

            // we have data
            foreach (var date in holidaysData.Holidays)
            {
                this.holidays.Add(date);
            }

            foreach (var date in holidaysData.WorkingWeekends)
            {
                this.workingWeekends.Add(date);
            }

            this.years.Add(year);

            return true;
        }

        public bool ContainsDataFor(int year)
        {
            return this.years.Contains(year);
        }

        public void RemoveDataFor(int year)
        {
            this.holidays.RemoveWhere(day => day.Year == year);
            this.workingWeekends.RemoveWhere(day => day.Year == year);
            this.years.Remove(year);
        }

        public bool IsHoliday(DateOnly date)
        {
            return this.holidays.Contains(date);
        }

        public bool IsWorkingWeekend(DateOnly date)
        {
            return this.workingWeekends.Contains(date);
        }
    }
}