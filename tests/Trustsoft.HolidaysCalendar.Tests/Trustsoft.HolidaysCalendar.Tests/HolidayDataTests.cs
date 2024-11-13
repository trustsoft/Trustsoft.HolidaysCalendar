// -------------------------Copyright © 2024 M.Sukhanov. All rights reserved.-------------------------
//  <copyright file="HolidayDataTests.cs" author="M.Sukhanov">
//      Copyright © 2024 M.Sukhanov. All rights reserved.
//  </copyright>
//  <date>12.11.2024</date>
// -------------------------Copyright © 2024 M.Sukhanov. All rights reserved.-------------------------

namespace Trustsoft.HolidaysCalendar.Tests;

[TestClass]
public class HolidayDataTests
{
    [TestMethod]
    public void CreationTest1()
    {
        var holidaysData = new HolidaysData(new List<DateOnly>(), new List<DateOnly>());

        Assert.IsNotNull(holidaysData);
        Assert.IsNotNull(holidaysData.Holidays);
        Assert.IsNotNull(holidaysData.WorkingWeekends);
    }

    [TestMethod]
    public void CreationTest2()
    {
        var holidaysData = new HolidaysData(null, new List<DateOnly>());

        Assert.IsNotNull(holidaysData);
        Assert.IsNotNull(holidaysData.Holidays);
        Assert.IsNotNull(holidaysData.WorkingWeekends);
    }

    [TestMethod]
    public void CreationTest3()
    {
        var holidaysData = new HolidaysData(new List<DateOnly>(), null);

        Assert.IsNotNull(holidaysData);
        Assert.IsNotNull(holidaysData.Holidays);
        Assert.IsNotNull(holidaysData.WorkingWeekends);
    }

    [TestMethod]
    public void CreationTest4()
    {
        var holidaysData = new HolidaysData(null, null);

        Assert.IsNotNull(holidaysData);
        Assert.IsNotNull(holidaysData.Holidays);
        Assert.IsNotNull(holidaysData.WorkingWeekends);
    }
}