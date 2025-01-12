// -------------------------Copyright © 2024 M.Sukhanov. All rights reserved.-------------------------
//  <copyright file="HolidaysCalendarTests.Init.cs" author="M.Sukhanov">
//      Copyright © 2024 M.Sukhanov. All rights reserved.
//  </copyright>
//  <date>23.11.2024</date>
// -------------------------Copyright © 2024 M.Sukhanov. All rights reserved.-------------------------

namespace Trustsoft.HolidaysCalendar.Tests;

using Trustsoft.HolidaysCalendar.DataProviders;
using Trustsoft.HolidaysCalendar.Tests.TestData;

public partial class HolidaysCalendarTests
{
    // calendar instance to test
    private static HolidaysCalendar calendar = null!;

    // contains test data
    private static readonly List<TestDataItem> HolidayData = [];

    [ClassInitialize]
    public static void ClassInit(TestContext context)
    {
        var holidaysCalendar = new RussianHolidaysCalendar();
        calendar = holidaysCalendar;

        // add known holiday data
        HolidayData.AddRange(TestDataProvider.GetDataFor2021());
        HolidayData.AddRange(TestDataProvider.GetDataFor2022());
        HolidayData.AddRange(TestDataProvider.GetDataFor2023());
        HolidayData.AddRange(TestDataProvider.GetDataFor2024());
        HolidayData.AddRange(TestDataProvider.GetDataFor2025());

        var years = Enumerable.Range(DateTime.Today.Year + 2, 3).ToList();
        
        // add future years to test holiday data generation
        foreach (var year in years)
        {
            HolidayData.AddRange(TestDataProvider.GenerateDataForYear(year));
        }
    }

    [TestInitialize]
    public void InitializeTest()
    {
    }

    private static IEnumerable<object?[]> GetTestData()
    {
        foreach (var item in HolidayData)
        {
            yield return [item];
        }
    }

    private static IEnumerable<object?[]> GetNextWorkingDayTestData()
    {
        yield return ["2023.01.01", "2023.01.09"];
        yield return ["2023.01.02", "2023.01.09"];
        yield return ["2023.01.03", "2023.01.09"];
        yield return ["2023.01.04", "2023.01.09"];
        yield return ["2023.01.05", "2023.01.09"];
        yield return ["2023.01.06", "2023.01.09"];
        yield return ["2023.01.07", "2023.01.09"];
        yield return ["2023.01.08", "2023.01.09"];
        yield return ["2023.01.09", "2023.01.10"];
        yield return ["2023.02.23", "2023.02.27"];
        yield return ["2023.02.28", "2023.03.01"];
        yield return ["2023.03.07", "2023.03.09"];
        yield return ["2023.03.08", "2023.03.09"];
        yield return ["2023.05.01", "2023.05.02"];
        yield return ["2023.05.08", "2023.05.10"];
        yield return ["2023.05.09", "2023.05.10"];
        yield return ["2023.06.12", "2023.06.13"];
        yield return ["2023.11.03", "2023.11.07"];
        yield return ["2023.11.06", "2023.11.07"];

        yield return ["2024.01.01", "2024.01.09"];
        yield return ["2024.01.02", "2024.01.09"];
        yield return ["2024.01.03", "2024.01.09"];
        yield return ["2024.01.04", "2024.01.09"];
        yield return ["2024.01.05", "2024.01.09"];
        yield return ["2024.01.06", "2024.01.09"];
        yield return ["2024.01.07", "2024.01.09"];
        yield return ["2024.01.08", "2024.01.09"];
        yield return ["2024.01.09", "2024.01.10"];
        yield return ["2024.02.23", "2024.02.26"];
        yield return ["2024.02.29", "2024.03.01"];
        yield return ["2024.03.07", "2024.03.11"];
        yield return ["2024.03.08", "2024.03.11"];
        yield return ["2024.05.01", "2024.05.02"];
        yield return ["2024.05.08", "2024.05.13"];
        yield return ["2024.05.09", "2024.05.13"];
        yield return ["2024.06.12", "2024.06.13"];
        yield return ["2024.11.03", "2024.11.05"];
        yield return ["2024.11.06", "2024.11.07"];
    }

    private static IEnumerable<object?[]> GetAdjustForHolidaysAndWeekendsTestData()
    {
        yield return ["2024.01.01", "2024.01.09"];
        yield return ["2024.01.02", "2024.01.09"];
        yield return ["2024.01.03", "2024.01.09"];
        yield return ["2024.01.04", "2024.01.09"];
        yield return ["2024.01.05", "2024.01.09"];
        yield return ["2024.01.06", "2024.01.09"];
        yield return ["2024.01.07", "2024.01.09"];
        yield return ["2024.01.08", "2024.01.09"];
        yield return ["2024.02.23", "2024.02.26"];
        yield return ["2024.02.25", "2024.02.26"];
        yield return ["2024.04.29", "2024.05.02"];
        yield return ["2024.06.12", "2024.06.13"];
        yield return ["2024.11.04", "2024.11.05"];
    }
}