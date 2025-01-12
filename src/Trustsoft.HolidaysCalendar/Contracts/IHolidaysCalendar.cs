// -------------------------Copyright © 2024 M.Sukhanov. All rights reserved.-------------------------
//  <copyright file="IHolidaysCalendar.cs" author="M.Sukhanov">
//      Copyright © 2024 M.Sukhanov. All rights reserved.
//  </copyright>
//  <date>09.11.2024</date>
// -------------------------Copyright © 2024 M.Sukhanov. All rights reserved.-------------------------

namespace Trustsoft.HolidaysCalendar.Contracts;

/// <summary>
///   Describes a set of functions to work with holiday calendar.
/// </summary>
public interface IHolidaysCalendar
{
    /// <summary>
    ///   Adjusts the specified <paramref name="date" /> to ensure it is not a holiday or a weekend.
    /// </summary>
    /// <param name="date"> The date to adjust for. </param>
    /// <returns>
    ///   The specified <paramref name="date" /> if it`s a working day; otherwise, next working day.
    /// </returns>
    [Obsolete("AdjustForHolidaysAndWeekends is deprecated, please use AdjustToWorkingDay, with same signature, instead.")]
    DateOnly AdjustForHolidaysAndWeekends(DateOnly date);

    /// <summary>
    ///   Adjusts the specified <paramref name="date" /> to ensure it is not a holiday or a weekend.
    /// </summary>
    /// <param name="date"> The date to adjust for. </param>
    /// <returns>
    ///   The specified <paramref name="date" /> if it`s a working day; otherwise, next working day.
    /// </returns>
    DateOnly AdjustToWorkingDay(DateOnly date);

    /// <summary>
    ///   Gets the next working day after specified <paramref name="date" />.
    /// </summary>
    /// <param name="date"> The date to check for. </param>
    /// <returns> The next working day. </returns>
    DateOnly GetNextWorkingDay(DateOnly date);

    /// <summary>
    ///   Determines whether the specified <paramref name="date" /> is a holiday.
    /// </summary>
    /// <param name="date"> The date to check for. </param>
    /// <returns>
    ///   <see langword="true" /> if the specified date is holiday; otherwise, <see langword="false" />.
    /// </returns>
    bool IsHoliday(DateOnly date);

    /// <summary>
    ///   Determines whether the specified <paramref name="date" />
    ///   is a weekend taking into account working weekends.
    /// </summary>
    /// <param name="date"> The date to check for. </param>
    /// <returns>
    ///   <see langword="true" /> if the specified date is a weekend; otherwise, <see langword="false" />.
    /// </returns>
    bool IsWeekend(DateOnly date);

    /// <summary>
    ///   Determines whether the specified <paramref name="date" />
    ///   is a working day taking into account working weekends and holidays.
    /// </summary>
    /// <param name="date"> The date to check for. </param>
    /// <returns>
    ///   <see langword="true" /> if the specified date is a working day; otherwise, <see langword="false" />.
    /// </returns>
    bool IsWorkingDay(DateOnly date);

    /// <summary>
    ///   Determines whether the specified <paramref name="date" /> is working weekend.
    /// </summary>
    /// <param name="date"> The date to check for. </param>
    /// <returns>
    ///   <see langword="true" /> if the specified date is working weekend; otherwise, <see langword="false" />.
    /// </returns>
    bool IsWorkingWeekend(DateOnly date);
}