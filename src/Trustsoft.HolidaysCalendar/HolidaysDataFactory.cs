// -------------------------Copyright © 2024 M.Sukhanov. All rights reserved.-------------------------
//  <copyright file="HolidaysDataFactory.cs" author="M.Sukhanov">
//      Copyright © 2024 M.Sukhanov. All rights reserved.
//  </copyright>
//  <date>22.11.2024</date>
// -------------------------Copyright © 2024 M.Sukhanov. All rights reserved.-------------------------

namespace Trustsoft.HolidaysCalendar;

using System.ComponentModel;

using Trustsoft.HolidaysCalendar.Contracts;

/// <summary>
///   Provides methods to create object that implements <see cref="IHolidaysData" />.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)]
public static class HolidaysDataFactory
{
    /// <summary>
    ///   Creates an implementation of <see cref="IHolidaysData" /> in an invalid state.
    /// </summary>
    /// <returns> The corresponding implementation of <see cref="IHolidaysData" />. </returns>
    public static IHolidaysData Invalid()
    {
        return new HolidaysData(holidays: [],
                                workingWeekends: [],
                                isValid: false);
    }

    /// <summary>
    ///   Creates an implementation of <see cref="IHolidaysData" /> with provided data and in a valid state.
    /// </summary>
    /// <returns> The corresponding implementation of <see cref="IHolidaysData" />. </returns>
    public static IHolidaysData Valid(IReadOnlyList<DateOnly>? holidays)
    {
        return Valid(holidays: holidays ?? [],
                     workingWeekends: []);
    }

    /// <summary>
    ///   Creates an implementation of <see cref="IHolidaysData" /> with provided data and in a valid state.
    /// </summary>
    /// <returns> The corresponding implementation of <see cref="IHolidaysData" />. </returns>
    public static IHolidaysData Valid(IReadOnlyList<DateOnly>? holidays, IReadOnlyList<DateOnly>? workingWeekends)
    {
        return new HolidaysData(holidays: holidays ?? [],
                                workingWeekends: workingWeekends ?? [],
                                isValid: true);
    }
}