// -------------------------Copyright © 2024 M.Sukhanov. All rights reserved.-------------------------
//  <copyright file="IHolidaysData.cs" author="M.Sukhanov">
//      Copyright © 2024 M.Sukhanov. All rights reserved.
//  </copyright>
//  <date>09.11.2024</date>
// -------------------------Copyright © 2024 M.Sukhanov. All rights reserved.-------------------------

namespace Trustsoft.HolidaysCalendar.Contracts;

public interface IHolidaysData
{
    /// <summary>
    ///   Gets a read-only list of holidays.
    /// </summary>
    /// <value> The read-only list of holidays. </value>
    IReadOnlyList<DateOnly> Holidays { get; }

    /// <summary>
    ///   Gets a read-only list of working weekends.
    /// </summary>
    /// <value> The read-only list of weekends. </value>
    IReadOnlyList<DateOnly> WorkingWeekends { get; }

    /// <summary>
    ///   Returns true if contained data is valid.
    /// </summary>
    /// <value> <c> true </c> if contained data is valid; otherwise, <c> false </c>. </value>
    bool IsValid { get; }
}