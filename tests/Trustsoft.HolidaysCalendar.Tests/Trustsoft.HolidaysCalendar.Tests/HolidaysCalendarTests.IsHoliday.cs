// -------------------------Copyright © 2024 M.Sukhanov. All rights reserved.-------------------------
//  <copyright file="HolidaysCalendarTests.IsHoliday.cs" author="M.Sukhanov">
//      Copyright © 2024 M.Sukhanov. All rights reserved.
//  </copyright>
//  <date>15.11.2024</date>
// -------------------------Copyright © 2024 M.Sukhanov. All rights reserved.-------------------------

namespace Trustsoft.HolidaysCalendar.Tests;

public partial class HolidaysCalendarTests
{
    [DataTestMethod]
    [DataRow("2024.01.01")]
    [DataRow("2024.01.02")]
    [DataRow("2024.01.03")]
    [DataRow("2024.01.04")]
    [DataRow("2024.01.05")]
    [DataRow("2024.01.06")]
    [DataRow("2024.01.07")]
    [DataRow("2024.01.08")]
    [DataRow("2024.02.23")]
    [DataRow("2024.03.08")]
    [DataRow("2024.05.01")]
    [DataRow("2024.05.09")]
    [DataRow("2024.06.12")]
    [DataRow("2024.11.04")]
    public void IsHoliday2024Test(string dateOnlyString)
    {
        var date = DateOnly.ParseExact(dateOnlyString, "yyyy.MM.dd");
        Assert.IsTrue(this.calendar.IsHoliday(date));
    }

    [DataTestMethod]
    [DataRow("2026.01.01")]
    [DataRow("2026.01.02")]
    [DataRow("2026.01.03")] // weekend
    [DataRow("2026.01.04")] // weekend
    [DataRow("2026.01.05")]
    [DataRow("2026.01.06")]
    [DataRow("2026.01.07")]
    [DataRow("2026.01.08")]
    [DataRow("2026.02.23")]
    [DataRow("2026.03.08")]
    [DataRow("2026.05.01")]
    [DataRow("2026.05.09")] // weekend
    [DataRow("2026.06.12")]
    [DataRow("2026.11.04")]
    public void IsHoliday2026Test(string dateOnlyString)
    {
        var date = DateOnly.ParseExact(dateOnlyString, "yyyy.MM.dd");
        Assert.IsTrue(this.calendar.IsHoliday(date));
    }

    [DataTestMethod]
    [DataRow("2027.01.01")]
    [DataRow("2027.01.02")] // weekend
    [DataRow("2027.01.03")] // weekend
    [DataRow("2027.01.04")]
    [DataRow("2027.01.05")]
    [DataRow("2027.01.06")]
    [DataRow("2027.01.07")]
    [DataRow("2027.01.08")]
    [DataRow("2027.02.23")]
    [DataRow("2027.03.08")]
    [DataRow("2027.05.01")] // weekend
    [DataRow("2027.05.09")] // weekend
    [DataRow("2027.06.12")]
    [DataRow("2027.11.04")]
    public void IsHoliday2027Test(string dateOnlyString)
    {
        var date = DateOnly.ParseExact(dateOnlyString, "yyyy.MM.dd");
        Assert.IsTrue(this.calendar.IsHoliday(date));
    }
}