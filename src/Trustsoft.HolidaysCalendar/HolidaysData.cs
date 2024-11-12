// -------------------------Copyright © 2024 M.Sukhanov. All rights reserved.-------------------------
//  <copyright file="HolidaysData.cs" author="M.Sukhanov">
//      Copyright © 2024 M.Sukhanov. All rights reserved.
//  </copyright>
//  <date>09.11.2024</date>
// -------------------------Copyright © 2024 M.Sukhanov. All rights reserved.-------------------------

namespace Trustsoft.HolidaysCalendar;

using Trustsoft.HolidaysCalendar.Contracts;

internal class HolidaysData(IReadOnlyList<DateOnly> holidays, IReadOnlyList<DateOnly> workingWeekends)
        : IHolidaysData
{
    public IReadOnlyList<DateOnly> Holidays { get; } = holidays ?? [];

    public IReadOnlyList<DateOnly> WorkingWeekends { get; } = workingWeekends ?? [];

    public bool IsEmpty => !(this.Holidays.Count > 0 || this.WorkingWeekends.Count > 0);
}