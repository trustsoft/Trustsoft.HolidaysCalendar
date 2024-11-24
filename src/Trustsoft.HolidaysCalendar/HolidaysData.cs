// -------------------------Copyright © 2024 M.Sukhanov. All rights reserved.-------------------------
//  <copyright file="HolidaysData.cs" author="M.Sukhanov">
//      Copyright © 2024 M.Sukhanov. All rights reserved.
//  </copyright>
//  <date>09.11.2024</date>
// -------------------------Copyright © 2024 M.Sukhanov. All rights reserved.-------------------------

namespace Trustsoft.HolidaysCalendar;

using Trustsoft.HolidaysCalendar.Contracts;

/// <summary>
///   <see cref="IHolidaysData" /> implementation for internal usage.
/// </summary>
internal class HolidaysData(IReadOnlyList<DateOnly> holidays, IReadOnlyList<DateOnly> workingWeekends, bool isValid)
        : IHolidaysData
{
    public IReadOnlyList<DateOnly> Holidays { get; } = holidays ?? [];

    public IReadOnlyList<DateOnly> WorkingWeekends { get; } = workingWeekends ?? [];

    public bool IsValid { get; } = isValid;
}