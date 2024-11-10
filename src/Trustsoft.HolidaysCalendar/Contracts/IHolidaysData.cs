// -------------------------Copyright © 2024 M.Sukhanov. All rights reserved.-------------------------
//  <copyright file="IHolidaysData.cs" author="M.Sukhanov">
//      Copyright © 2024 M.Sukhanov. All rights reserved.
//  </copyright>
//  <date>09.11.2024</date>
// -------------------------Copyright © 2024 M.Sukhanov. All rights reserved.-------------------------

namespace Trustsoft.HolidaysCalendar.Contracts;

public interface IHolidaysData
{
    IReadOnlyList<DateOnly> Holidays { get; }

    IReadOnlyList<DateOnly> WorkingWeekends { get; }

    bool IsEmpty { get; }
}