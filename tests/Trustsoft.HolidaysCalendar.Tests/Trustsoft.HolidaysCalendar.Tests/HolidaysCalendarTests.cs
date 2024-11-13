// -------------------------Copyright © 2024 M.Sukhanov. All rights reserved.-------------------------
//  <copyright file="HolidaysCalendarTests.cs" author="M.Sukhanov">
//      Copyright © 2024 M.Sukhanov. All rights reserved.
//  </copyright>
//  <date>12.11.2024</date>
// -------------------------Copyright © 2024 M.Sukhanov. All rights reserved.-------------------------

namespace Trustsoft.HolidaysCalendar.Tests;

using Trustsoft.HolidaysCalendar.Contracts;
using Trustsoft.HolidaysCalendar.DataProviders;

[TestClass]
public class HolidaysCalendarTests
{
    private IHolidaysCalendar calendar = null!;

    [TestInitialize]
    public void Initialize()
    {
        var dataProvider = new XmlCalendarDataProvider();
        var holidaysCalendar = new HolidaysCalendar(dataProvider);
        this.calendar = holidaysCalendar;
    }

    [TestMethod]
    public void CreationTest()
    {
        IHolidaysCalendar holidaysCalendar = new HolidaysCalendar(new XmlCalendarDataProvider());

        Assert.IsNotNull(holidaysCalendar);
    }

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
    public void IsHolidayTest(string dateOnlyString)
    {
        var date = DateOnly.ParseExact(dateOnlyString, "yyyy.MM.dd");
        Assert.IsTrue(this.calendar.IsHoliday(date));
    }

    [DataTestMethod]
    [DataRow("2024.01.09")]
    [DataRow("2024.01.10")]
    [DataRow("2024.02.22")]
    [DataRow("2024.03.07")]
    [DataRow("2024.04.27")]
    [DataRow("2024.05.02")]
    public void IsNotHolidayTest(string dateOnlyString)
    {
        var date = DateOnly.ParseExact(dateOnlyString, "yyyy.MM.dd");
        Assert.IsFalse(this.calendar.IsHoliday(date));
    }

    [DataTestMethod]
    [DataRow("2024.01.01", "2024.01.09")]
    [DataRow("2024.01.02", "2024.01.09")]
    [DataRow("2024.01.03", "2024.01.09")]
    [DataRow("2024.01.04", "2024.01.09")]
    [DataRow("2024.01.05", "2024.01.09")]
    [DataRow("2024.01.06", "2024.01.09")]
    [DataRow("2024.01.07", "2024.01.09")]
    [DataRow("2024.01.08", "2024.01.09")]
    [DataRow("2024.02.23", "2024.02.26")]
    [DataRow("2024.02.25", "2024.02.26")]
    [DataRow("2024.04.29", "2024.05.02")]
    [DataRow("2024.06.12", "2024.06.13")]
    [DataRow("2024.11.04", "2024.11.05")]
    public void AdjustForHolidaysTest(string dateOnlyString, string expectedString)
    {
        var date = DateOnly.ParseExact(dateOnlyString, "yyyy.MM.dd");
        var expected = DateOnly.ParseExact(expectedString, "yyyy.MM.dd");

        var actual = this.calendar.AdjustForHolidaysAndWeekends(date);
        Assert.AreEqual(actual, expected);
    }

    [DataTestMethod]
    [DataRow("2024.01.13")]
    public void IsWeekendTest(string dateOnlyString)
    {
        var date = DateOnly.ParseExact(dateOnlyString, "yyyy.MM.dd");
        Assert.IsTrue(this.calendar.IsWeekend(date));
    }

    [DataTestMethod]
    [DataRow("2024.02.23")]
    [DataRow("2024.04.27")]
    [DataRow("2024.12.28")]
    public void IsNotWeekendTest(string dateOnlyString)
    {
        var date = DateOnly.ParseExact(dateOnlyString, "yyyy.MM.dd");
        Assert.IsFalse(this.calendar.IsWeekend(date));
    }
}