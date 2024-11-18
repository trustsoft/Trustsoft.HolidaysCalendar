// -------------------------Copyright © 2024 M.Sukhanov. All rights reserved.-------------------------
//  <copyright file="IHolidaysCalendar.cs" author="M.Sukhanov">
//      Copyright © 2024 M.Sukhanov. All rights reserved.
//  </copyright>
//  <date>09.11.2024</date>
// -------------------------Copyright © 2024 M.Sukhanov. All rights reserved.-------------------------

namespace Trustsoft.HolidaysCalendar.Contracts;

public interface IHolidaysCalendar
{
    /// <summary>
    ///   Adjusts the specified <paramref name="date" /> to ensure it is not a holiday or a weekend.
    /// </summary>
    /// <param name="date"> The date to adjust for. </param>
    /// <returns> The date adjusted for holidays and weekends. </returns>
    DateOnly AdjustForHolidaysAndWeekends(DateOnly date);

    /// <summary>
    ///   Gets the next working day after specified <paramref name="date" />.
    /// </summary>
    /// <param name="date"> The date to check for. </param>
    /// <returns> The next working day. </returns>
    DateOnly GetNextWorkingDay(DateOnly date);

    /// <summary>
    ///   Determines whether the specified <paramref name="date" /> is holiday.
    /// </summary>
    /// <param name="date"> The date to check for. </param>
    /// <returns> <c> true </c> if the specified date is holiday; otherwise, <c> false </c>. </returns>
    bool IsHoliday(DateOnly date);

    /// <summary>
    ///   Determines whether the specified <paramref name="date" /> is a weekend, taking into account working
    ///   weekends.
    /// </summary>
    /// <param name="date"> The date to check for. </param>
    /// <returns> <c> true </c> if the specified date is a weekend; otherwise, <c> false </c>. </returns>
    bool IsWeekend(DateOnly date);

    /// <summary>
    ///   Determines whether the specified <paramref name="date" /> is working weekend.
    /// </summary>
    /// <param name="date"> The date to check for. </param>
    /// <returns> <c> true </c> if the specified date is working weekend; otherwise, <c> false </c>. </returns>
    bool IsWorkingWeekend(DateOnly date);
}