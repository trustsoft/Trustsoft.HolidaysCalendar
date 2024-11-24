// -------------------------Copyright © 2024 M.Sukhanov. All rights reserved.-------------------------
//  <copyright file="IFallbackDataProvider.cs" author="M.Sukhanov">
//      Copyright © 2024 M.Sukhanov. All rights reserved.
//  </copyright>
//  <date>15.11.2024</date>
// -------------------------Copyright © 2024 M.Sukhanov. All rights reserved.-------------------------

namespace Trustsoft.HolidaysCalendar.Contracts;

/// <summary>
///   Describes a fallback holiday data provider functionality.
///   Extends the <see cref="IHolidaysDataProvider" />.
/// </summary>
/// <seealso cref="IHolidaysDataProvider" />
public interface IFallbackDataProvider : IHolidaysDataProvider;