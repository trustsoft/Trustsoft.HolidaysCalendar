// -------------------------Copyright © 2024 M.Sukhanov. All rights reserved.-------------------------
//  <copyright file="HolidayData.cs" author="M.Sukhanov">
//      Copyright © 2024 M.Sukhanov. All rights reserved.
//  </copyright>
//  <date>23.11.2024</date>
// -------------------------Copyright © 2024 M.Sukhanov. All rights reserved.-------------------------

namespace Trustsoft.HolidaysCalendar.Tests.TestData;

public record HolidayData(int Month, List<int> Days)
{
    public IEnumerable<DateOnly> GetDatesForYear(int year)
    {
        return this.Days.Select(day => new DateOnly(year, this.Month, day));
    }
}