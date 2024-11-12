// -------------------------Copyright © 2024 M.Sukhanov. All rights reserved.-------------------------
//  <copyright file="HolidayDataTests.cs" author="M.Sukhanov">
//      Copyright © 2024 M.Sukhanov. All rights reserved.
//  </copyright>
//  <date>12.11.2024</date>
// -------------------------Copyright © 2024 M.Sukhanov. All rights reserved.-------------------------

namespace Trustsoft.HolidaysCalendar.Tests;

using Trustsoft.HolidaysCalendar.Contracts;

[TestClass]
public class HolidayDataTests
{
    [TestMethod]
    public void HolidayDataIsNullTest1()
    {
        IHolidaysData data = new HolidaysData([], null);

        Assert.IsTrue(data.IsEmpty);

        data = new HolidaysData(null, []);

        Assert.IsTrue(data.IsEmpty);

        data = new HolidaysData(null, null);

        Assert.IsTrue(data.IsEmpty);
    }

    [TestMethod]
    public void HolidayDataIsEmptyTest1()
    {
        var list1 = new List<DateOnly>();
        var list2 = new List<DateOnly>();

        IHolidaysData data = new HolidaysData(list1, list2);
        Assert.IsTrue(data.IsEmpty);
    }

    [TestMethod]
    public void HolidayDataIsNotEmptyTest1()
    {
        var list1 = new List<DateOnly>
        {
            new DateOnly(2024, 10, 10)
        };

        IHolidaysData data = new HolidaysData(list1, new List<DateOnly>());

        Assert.IsFalse(data.IsEmpty);
    }

    [TestMethod]
    public void HolidayDataIsNotEmptyTest2()
    {
        var list2 = new List<DateOnly>
        {
            new DateOnly(2024, 10, 10)
        };

        IHolidaysData data = new HolidaysData(new List<DateOnly>(), list2);

        Assert.IsFalse(data.IsEmpty);
    }
}