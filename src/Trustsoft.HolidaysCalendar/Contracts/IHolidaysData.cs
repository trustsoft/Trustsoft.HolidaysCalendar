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
    ///   Gets a value indicating whether this instance`s data lists are empty.
    /// </summary>
    /// <value> <c> true </c> if this instance is empty; otherwise, <c> false </c>. </value>
    bool IsEmpty { get; }
}