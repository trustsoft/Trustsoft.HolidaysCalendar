// -------------------------Copyright © 2024 M.Sukhanov. All rights reserved.-------------------------
//  <copyright file="HolidaysCalendarTests.cs" author="M.Sukhanov">
//      Copyright © 2024 M.Sukhanov. All rights reserved.
//  </copyright>
//  <date>12.11.2024</date>
// -------------------------Copyright © 2024 M.Sukhanov. All rights reserved.-------------------------

namespace Trustsoft.HolidaysCalendar.Tests;

using System.Diagnostics;

using Trustsoft.HolidaysCalendar.Tests.TestData;

[TestClass]
public partial class HolidaysCalendarTests
{
    [TestMethod]
    [DynamicData(nameof(GetTestData), DynamicDataSourceType.Method)]
    public void IsHolidayTest(TestDataItem dateItem)
    {
        var expected = dateItem.IsHoliday;
        var actual = calendar.IsHoliday(dateItem.Day);

        Debug.WriteLine($"IsHoliday test case for: {dateItem}");
        Debug.WriteLine($"Result: expected: {expected} actual: {actual}");
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DynamicData(nameof(GetTestData), DynamicDataSourceType.Method)]
    public void IsWeekendTest(TestDataItem dateItem)
    {
        var expected = dateItem.IsWeekend;
        var actual = calendar.IsWeekend(dateItem.Day);

        Debug.WriteLine($"IsWeekend test case for: {dateItem}");
        Debug.WriteLine($"Result: expected: {expected} actual: {actual}");
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DynamicData(nameof(GetTestData), DynamicDataSourceType.Method)]
    public void IsWorkingDayTest(TestDataItem dateItem)
    {
        var expected = dateItem.IsWorkingWeekend || !(dateItem.IsHoliday || dateItem.IsWeekend);
        var actual = calendar.IsWorkingDay(dateItem.Day);

        Debug.WriteLine($"IsWorkingDay test case for: {dateItem}");
        Debug.WriteLine($"Result: expected: {expected} actual: {actual}");
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DynamicData(nameof(GetTestData), DynamicDataSourceType.Method)]
    public void IsWorkingWeekendTest(TestDataItem dateItem)
    {
        var expected = dateItem.IsWorkingWeekend;
        var actual = calendar.IsWorkingWeekend(dateItem.Day);

        Debug.WriteLine($"IsWorkingWeekend test case for: {dateItem}");
        Debug.WriteLine($"Result: expected: {expected} actual: {actual}");
        Assert.AreEqual(expected, actual);
    }

    [DataTestMethod]
    [DynamicData(nameof(GetNextWorkingDayTestData), DynamicDataSourceType.Method)]
    public void GetNextWorkingDayTest(string dateOnlyString, string expectedString)
    {
        var date = DateOnly.ParseExact(dateOnlyString, "yyyy.MM.dd");
        var expected = DateOnly.ParseExact(expectedString, "yyyy.MM.dd");

        var actual = calendar.GetNextWorkingDay(date);
        Assert.AreEqual(expected, actual);
    }

    [DataTestMethod]
    [DynamicData(nameof(GetAdjustForHolidaysAndWeekendsTestData), DynamicDataSourceType.Method)]
    public void AdjustForHolidaysAndWeekends2024Test(string dateOnlyString, string expectedString)
    {
        var date = DateOnly.ParseExact(dateOnlyString, "yyyy.MM.dd");
        var expected = DateOnly.ParseExact(expectedString, "yyyy.MM.dd");

        var actual = calendar.AdjustToWorkingDay(date);
        Assert.AreEqual(actual, expected);
    }
}