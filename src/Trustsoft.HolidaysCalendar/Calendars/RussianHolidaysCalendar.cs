// -------------------------Copyright © 2025 M.Sukhanov. All rights reserved.-------------------------
//  <copyright file="RussianHolidaysCalendar.cs" author="M.Sukhanov">
//      Copyright © 2025 M.Sukhanov. All rights reserved.
//  </copyright>
//  <date>12.01.2025</date>
// -------------------------Copyright © 2025 M.Sukhanov. All rights reserved.-------------------------

namespace Trustsoft.HolidaysCalendar;

using Trustsoft.HolidaysCalendar.Contracts;
using Trustsoft.HolidaysCalendar.DataProviders;

/// <summary>
///   Provides a set of functions to work with Russian holiday calendar.
/// </summary>
/// <seealso cref="IHolidaysCalendar" />
public class RussianHolidaysCalendar : HolidaysCalendar
{
    /// <summary>
    ///   Initializes a new instance of the <see cref="RussianHolidaysCalendar" /> class with
    ///   <see cref="RussianHolidaysDataProvider" /> as primary data provider and
    ///   <see cref="RussianHolidaysFallbackDataProvider" /> as fallback data provider,
    ///   used if primary data provider fails to provide data.
    /// </summary>
    public RussianHolidaysCalendar() :
            base(new RussianHolidaysDataProvider(), new RussianHolidaysFallbackDataProvider())
    {
    }
}