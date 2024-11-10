// -------------------------Copyright © 2024 M.Sukhanov. All rights reserved.-------------------------
//  <copyright file="IHolidaysCalendar.cs" author="M.Sukhanov">
//      Copyright © 2024 M.Sukhanov. All rights reserved.
//  </copyright>
//  <date>09.11.2024</date>
// -------------------------Copyright © 2024 M.Sukhanov. All rights reserved.-------------------------

namespace Trustsoft.HolidaysCalendar.Contracts;

public interface IHolidaysCalendar
{
    void Initialize(IHolidaysDataProvider provider);

    DateOnly AdjustForHolidays(DateOnly date);

    DateOnly GetNextWorkingDay(DateOnly date);

    bool IsHoliday(DateOnly date);

    bool IsWeekend(DateOnly date);

    bool IsWorkingWeekend(DateOnly date);
}