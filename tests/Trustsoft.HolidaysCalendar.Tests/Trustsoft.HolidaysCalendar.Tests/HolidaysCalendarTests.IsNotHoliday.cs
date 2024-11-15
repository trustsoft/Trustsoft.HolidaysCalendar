// -------------------------Copyright © 2024 M.Sukhanov. All rights reserved.-------------------------
//  <copyright file="HolidaysCalendarTests.IsNotHoliday.cs" author="M.Sukhanov">
//      Copyright © 2024 M.Sukhanov. All rights reserved.
//  </copyright>
//  <date>15.11.2024</date>
// -------------------------Copyright © 2024 M.Sukhanov. All rights reserved.-------------------------

namespace Trustsoft.HolidaysCalendar.Tests;

public partial class HolidaysCalendarTests
{
    [DataTestMethod]
    [DataRow("2024.01.09")]
    [DataRow("2024.01.10")]
    [DataRow("2024.02.22")]
    [DataRow("2024.03.07")]
    [DataRow("2024.04.27")]
    [DataRow("2024.05.02")]
    public void IsNotHoliday2024Test(string dateOnlyString)
    {
        var date = DateOnly.ParseExact(dateOnlyString, "yyyy.MM.dd");
        Assert.IsFalse(this.calendar.IsHoliday(date));
    }

    [DataTestMethod]
    [DataRow("2026.01.09")]
    [DataRow("2026.01.10")]
    [DataRow("2026.02.22")]
    [DataRow("2026.03.07")]
    [DataRow("2026.04.27")]
    [DataRow("2026.05.02")]
    public void IsNotHoliday2026Test(string dateOnlyString)
    {
        var date = DateOnly.ParseExact(dateOnlyString, "yyyy.MM.dd");
        Assert.IsFalse(this.calendar.IsHoliday(date));
    }

    [DataTestMethod]
    [DataRow("2027.01.09")]
    [DataRow("2027.01.10")]
    [DataRow("2027.02.22")]
    [DataRow("2027.03.07")]
    [DataRow("2027.04.27")]
    [DataRow("2027.05.02")]
    public void IsNotHoliday2027Test(string dateOnlyString)
    {
        var date = DateOnly.ParseExact(dateOnlyString, "yyyy.MM.dd");
        Assert.IsFalse(this.calendar.IsHoliday(date));
    }
}