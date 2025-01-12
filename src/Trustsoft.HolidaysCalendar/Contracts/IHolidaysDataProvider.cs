// -------------------------Copyright © 2024 M.Sukhanov. All rights reserved.-------------------------
//  <copyright file="IHolidaysDataProvider.cs" author="M.Sukhanov">
//      Copyright © 2024 M.Sukhanov. All rights reserved.
//  </copyright>
//  <date>09.11.2024</date>
// -------------------------Copyright © 2024 M.Sukhanov. All rights reserved.-------------------------

namespace Trustsoft.HolidaysCalendar.Contracts;

/// <summary>
///   Describes a holiday data provider.
/// </summary>
/// <seealso cref="IHolidaysCalendar" />
public interface IHolidaysDataProvider
{
    /// <summary>
    ///   Gets the holidays data for specified year.
    /// </summary>
    /// <param name="year"> The year to get holidays data for. </param>
    /// <returns>
    ///   The <see cref="IHolidaysData" /> object that contains
    ///   holidays data for specified <paramref name="year"/>.
    /// </returns>
    IHolidaysData GetHolidaysData(int year);
}