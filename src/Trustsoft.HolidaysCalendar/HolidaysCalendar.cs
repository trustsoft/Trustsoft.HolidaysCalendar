// -------------------------Copyright © 2024 M.Sukhanov. All rights reserved.-------------------------
//  <copyright file="HolidaysCalendar.cs" author="M.Sukhanov">
//      Copyright © 2024 M.Sukhanov. All rights reserved.
//  </copyright>
//  <date>10.11.2024</date>
// -------------------------Copyright © 2024 M.Sukhanov. All rights reserved.-------------------------

namespace Trustsoft.HolidaysCalendar;

using System.Diagnostics;
using Trustsoft.HolidaysCalendar.Contracts;

public class HolidaysCalendar : IHolidaysCalendar
{
    private readonly IHolidaysDataProvider dataProvider;
    private readonly IHolidaysDataProvider fallbackDataProvider;
    private readonly HolidaysDataCache primaryData = new HolidaysDataCache();
    private readonly HolidaysDataCache fallbackData = new HolidaysDataCache();

    public HolidaysCalendar(IHolidaysDataProvider dataProvider, IFallbackDataProvider fallbackDataProvider1)
    {
        this.dataProvider = dataProvider ?? throw new ArgumentNullException(nameof(dataProvider));
        this.fallbackDataProvider = fallbackDataProvider1 ?? throw new ArgumentNullException(nameof(fallbackDataProvider1));
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
        IHolidaysData data = this.dataProvider.GetHolidaysData(year);

        // update primary data if exists
        return this.primaryData.UpdateData(data, year);
    }

    private bool LoadDataFromFallbackProvider(int year)
    {
        IHolidaysData data = this.fallbackDataProvider.GetHolidaysData(year);

        // update fallback data if exists
        return this.fallbackData.UpdateData(data, year);
    }

    public DateOnly AdjustForHolidaysAndWeekends(DateOnly date)
    {
        this.EnsureDataLoaded(date.Year);

        while (this.IsHoliday(date) || this.IsWeekend(date))
        {
            date = date.AddDays(1);
        }

        return date;
    }

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

    public bool IsHoliday(DateOnly date)
    {
        this.EnsureDataLoaded(date.Year);

        return this.primaryData.IsHoliday(date) || this.fallbackData.IsHoliday(date);
    }

    public bool IsWorkingWeekend(DateOnly date)
    {
        this.EnsureDataLoaded(date.Year);

        return this.primaryData.IsWorkingWeekend(date) || this.fallbackData.IsWorkingWeekend(date);
    }

    public bool IsWeekend(DateOnly date)
    {
        return date.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday &&
               !this.IsWorkingWeekend(date);
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