using Trustsoft.HolidaysCalendar.Contracts;

namespace Trustsoft.HolidaysCalendar;

public class HolidaysCalendar : IHolidaysCalendar
{
    private readonly HashSet<DateOnly> holidaysHashSet = [];
    private readonly HashSet<DateOnly> workingWeekendsHashSet = [];
    private readonly HashSet<int> yearsHashSet = [];
    private IHolidaysDataProvider dataProvider = null!;

    private void EnsureDataLoaded(int year)
    {
        if (!this.yearsHashSet.Contains(year))
        {
            this.LoadDataByYear(year);
        }
    }

    private void LoadDataByYear(int year)
    {
        IHolidaysData holidaysData = this.dataProvider.GetHolidays(year);
        foreach (var date in holidaysData.Holidays)
        {
            this.holidaysHashSet.Add(date);
        }

        foreach (var date in holidaysData.WorkingWeekends)
        {
            this.workingWeekendsHashSet.Add(date);
        }

        this.yearsHashSet.Add(year);
    }

    public DateOnly AdjustForHolidays(DateOnly date)
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

        return this.holidaysHashSet.Contains(date);
    }

    public bool IsWorkingWeekend(DateOnly date)
    {
        this.EnsureDataLoaded(date.Year);

        return this.workingWeekendsHashSet.Contains(date);
    }

    public bool IsWeekend(DateOnly date)
    {
        return date.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday &&
               !this.IsWorkingWeekend(date);
    }

    public void Initialize(IHolidaysDataProvider provider)
    {
        this.dataProvider = provider ?? throw new ArgumentNullException(nameof(provider));
    }
}