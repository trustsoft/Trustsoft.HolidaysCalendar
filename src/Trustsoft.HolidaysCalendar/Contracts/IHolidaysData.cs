// -------------------------Copyright © 2024 M.Sukhanov. All rights reserved.-------------------------
//  <copyright file="IHolidaysData.cs" author="M.Sukhanov">
//      Copyright © 2024 M.Sukhanov. All rights reserved.
//  </copyright>
//  <date>09.11.2024</date>
// -------------------------Copyright © 2024 M.Sukhanov. All rights reserved.-------------------------

namespace Trustsoft.HolidaysCalendar.Contracts;

/// <summary>
///   Describes a result of fetching data by <see cref="IHolidaysDataProvider.GetHolidaysData" />.
/// </summary>
/// <remarks>
///   For custom data provider developers:
///   Use <see cref="HolidaysDataFactory" /> to create objects that implement this interface.
/// </remarks>
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
    ///   Determines whether this instance contains valid data.
    /// </summary>
    /// <value> <see langword="true" /> if contained data is valid; otherwise, <see langword="false" />. </value>
    bool IsValid { get; }
}