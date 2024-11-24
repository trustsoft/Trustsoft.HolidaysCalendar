// -------------------------Copyright © 2024 M.Sukhanov. All rights reserved.-------------------------
//  <copyright file="TestDataProvider.cs" author="M.Sukhanov">
//      Copyright © 2024 M.Sukhanov. All rights reserved.
//  </copyright>
//  <date>23.11.2024</date>
// -------------------------Copyright © 2024 M.Sukhanov. All rights reserved.-------------------------

namespace Trustsoft.HolidaysCalendar.Tests.TestData;

internal static class TestDataProvider
{
    private static readonly IReadOnlyList<HolidayData> HolidayDescriptions = GetHolidayDescriptions();

    private static IReadOnlyList<HolidayData> GetHolidayDescriptions()
    {
        return
        [
            // "New Year's Day" / "Новогодние праздники"
            new HolidayData(Month: 1, [1, 2, 3, 4, 5, 6, 8]),
            // "Orthodox Christmas Day" / "Рождество Христово"
            new HolidayData(Month: 1, [7]),
            // "Defender of the Fatherland Day" / "День защитника Отечества"
            new HolidayData(Month: 2, [23]),
            // "International Women's Day" / "Международный женский день"
            new HolidayData(Month: 3, [8]),
            // "Spring and Labor Day" / "Праздник Весны и Труда"
            new HolidayData(Month: 5, [1]),
            // "Victory Day" / "День Победы"
            new HolidayData(Month: 5, [9]),
            // "Russia Day" / "День России"
            new HolidayData(Month: 6, [12]),
            // "Unity Day" / "День народного единства"
            new HolidayData(Month: 11, [4]),
        ];
    }

    public static IEnumerable<TestDataItem> GenerateDataForYear(int year)
    {
        return from holiday in HolidayDescriptions
               from date in holiday.GetDatesForYear(year)
               select TestDataItem.Holiday(date, date.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday);
    }

    public static IEnumerable<TestDataItem> GetDataFor2021()
    {
        yield return TestDataItem.Holiday("2021.01.01");
        yield return TestDataItem.Holiday("2021.01.02");
        yield return TestDataItem.Holiday("2021.01.03");
        yield return TestDataItem.Holiday("2021.01.04");
        yield return TestDataItem.Holiday("2021.01.05");
        yield return TestDataItem.Holiday("2021.01.06");
        yield return TestDataItem.Holiday("2021.01.07");
        yield return TestDataItem.Holiday("2021.01.08");
        yield return TestDataItem.Weekend("2021.01.09");
        yield return TestDataItem.Weekend("2021.01.10");
        yield return TestDataItem.Working("2021.01.13");
        yield return TestDataItem.Working("2021.02.19");
        yield return TestDataItem.WorWeek("2021.02.20");
        yield return TestDataItem.Holiday("2021.02.22");
        yield return TestDataItem.Holiday("2021.02.23");
        yield return TestDataItem.Weekend("2021.03.07");
        yield return TestDataItem.Holiday("2021.03.08");
        yield return TestDataItem.Working("2021.04.30");
        yield return TestDataItem.Holiday("2021.05.01");
        yield return TestDataItem.Weekend("2021.05.02");
        yield return TestDataItem.Holiday("2021.05.03");
        yield return TestDataItem.Holiday("2021.05.04");
        yield return TestDataItem.Holiday("2021.05.05");
        yield return TestDataItem.Holiday("2021.05.06");
        yield return TestDataItem.Holiday("2021.05.07");
        yield return TestDataItem.Holiday("2021.05.09");
        yield return TestDataItem.Holiday("2021.05.10");
        yield return TestDataItem.Working("2021.05.28");
        yield return TestDataItem.Working("2021.06.11");
        yield return TestDataItem.Holiday("2021.06.12");
        yield return TestDataItem.Weekend("2021.06.13");
        yield return TestDataItem.Holiday("2021.06.14");
        yield return TestDataItem.Holiday("2021.10.30");
        yield return TestDataItem.Holiday("2021.10.31");
        yield return TestDataItem.Holiday("2021.11.01");
        yield return TestDataItem.Holiday("2021.11.02");
        yield return TestDataItem.Holiday("2021.11.03");
        yield return TestDataItem.Holiday("2021.11.04");
        yield return TestDataItem.Holiday("2021.11.05");
        yield return TestDataItem.Weekend("2021.11.07");
        yield return TestDataItem.Holiday("2021.12.31");
    }

    public static IEnumerable<TestDataItem> GetDataFor2022()
    {
        yield return TestDataItem.Holiday("2022.01.01");
        yield return TestDataItem.Holiday("2022.01.02");
        yield return TestDataItem.Holiday("2022.01.03");
        yield return TestDataItem.Holiday("2022.01.04");
        yield return TestDataItem.Holiday("2022.01.05");
        yield return TestDataItem.Holiday("2022.01.06");
        yield return TestDataItem.Holiday("2022.01.07");
        yield return TestDataItem.Holiday("2022.01.08");
        yield return TestDataItem.Weekend("2022.01.09");
        yield return TestDataItem.Working("2022.01.10");
        yield return TestDataItem.Working("2022.01.13");
        yield return TestDataItem.Working("2022.02.18");
        yield return TestDataItem.Working("2022.02.22");
        yield return TestDataItem.Holiday("2022.02.23");
        yield return TestDataItem.WorWeek("2022.03.05");
        yield return TestDataItem.Holiday("2022.03.07");
        yield return TestDataItem.Holiday("2022.03.08");
        yield return TestDataItem.Working("2022.03.30");
        yield return TestDataItem.Working("2022.04.27");
        yield return TestDataItem.Weekend("2022.04.30");
        yield return TestDataItem.Holiday("2022.05.01");
        yield return TestDataItem.Holiday("2022.05.02");
        yield return TestDataItem.Holiday("2022.05.03");
        yield return TestDataItem.Holiday("2022.05.09");
        yield return TestDataItem.Holiday("2022.05.10");
        yield return TestDataItem.Working("2022.05.25");
        yield return TestDataItem.Holiday("2022.06.12");
        yield return TestDataItem.Holiday("2022.06.13");
        yield return TestDataItem.Working("2022.11.03");
        yield return TestDataItem.Holiday("2022.11.04");
        yield return TestDataItem.Weekend("2022.12.31");
    }

    public static IEnumerable<TestDataItem> GetDataFor2023()
    {
        yield return TestDataItem.Holiday("2023.01.01");
        yield return TestDataItem.Holiday("2023.01.02");
        yield return TestDataItem.Holiday("2023.01.03");
        yield return TestDataItem.Holiday("2023.01.04");
        yield return TestDataItem.Holiday("2023.01.05");
        yield return TestDataItem.Holiday("2023.01.06");
        yield return TestDataItem.Holiday("2023.01.07");
        yield return TestDataItem.Holiday("2023.01.08");
        yield return TestDataItem.Working("2023.01.09");
        yield return TestDataItem.Working("2023.01.10");
        yield return TestDataItem.Weekend("2023.01.22");
        yield return TestDataItem.Working("2023.02.22");
        yield return TestDataItem.Holiday("2023.02.23");
        yield return TestDataItem.Holiday("2023.02.24");
        yield return TestDataItem.Working("2023.02.27");
        yield return TestDataItem.Working("2023.03.07");
        yield return TestDataItem.Holiday("2023.03.08");
        yield return TestDataItem.Weekend("2023.03.19");
        yield return TestDataItem.Working("2023.04.27");
        yield return TestDataItem.Holiday("2023.05.01");
        yield return TestDataItem.Working("2023.05.02");
        yield return TestDataItem.Holiday("2023.05.08");
        yield return TestDataItem.Holiday("2023.05.09");
        yield return TestDataItem.Working("2023.05.10");
        yield return TestDataItem.Weekend("2023.05.21");
        yield return TestDataItem.Working("2023.05.26");
        yield return TestDataItem.Holiday("2023.06.12");
        yield return TestDataItem.Weekend("2023.08.12");
        yield return TestDataItem.Working("2023.11.03");
        yield return TestDataItem.Holiday("2023.11.06");
        yield return TestDataItem.Working("2023.12.29");
        yield return TestDataItem.Weekend("2023.12.30");
        yield return TestDataItem.Weekend("2023.12.30");
    }

    public static IEnumerable<TestDataItem> GetDataFor2024()
    {
        yield return TestDataItem.Holiday("2024.01.01");
        yield return TestDataItem.Holiday("2024.01.02");
        yield return TestDataItem.Holiday("2024.01.03");
        yield return TestDataItem.Holiday("2024.01.04");
        yield return TestDataItem.Holiday("2024.01.05");
        yield return TestDataItem.Holiday("2024.01.06");
        yield return TestDataItem.Holiday("2024.01.07");
        yield return TestDataItem.Holiday("2024.01.08");
        yield return TestDataItem.Working("2024.01.09");
        yield return TestDataItem.Working("2024.01.10");
        yield return TestDataItem.Weekend("2024.01.13");
        yield return TestDataItem.Weekend("2024.02.18");
        yield return TestDataItem.Working("2024.02.22");
        yield return TestDataItem.Holiday("2024.02.23");
        yield return TestDataItem.Working("2024.03.07");
        yield return TestDataItem.Holiday("2024.03.08");
        yield return TestDataItem.Weekend("2024.03.30");
        yield return TestDataItem.WorWeek("2024.04.27");
        yield return TestDataItem.Weekend("2024.04.28");
        yield return TestDataItem.Holiday("2024.05.01");
        yield return TestDataItem.Working("2024.05.02");
        yield return TestDataItem.Holiday("2024.05.09");
        yield return TestDataItem.Holiday("2024.05.10");
        yield return TestDataItem.Weekend("2024.05.25");
        yield return TestDataItem.Holiday("2024.06.12");
        yield return TestDataItem.WorWeek("2024.11.02");
        yield return TestDataItem.Holiday("2024.11.04");
        yield return TestDataItem.WorWeek("2024.12.28");
        yield return TestDataItem.Weekend("2024.12.29");
        yield return TestDataItem.Holiday("2024.12.30");
        yield return TestDataItem.Holiday("2024.12.31");

        //[DataRow("2024.01.01", true)]
        //[DataRow("2024.01.02", true)]
        //[DataRow("2024.01.03", true)]
        //[DataRow("2024.01.04", true)]
        //[DataRow("2024.01.05", true)]
        //[DataRow("2024.01.06", true)]
        //[DataRow("2024.01.07", true)]
        //[DataRow("2024.01.08", true)]
        //[DataRow("2024.01.09", false)]
        //[DataRow("2024.01.10", false)]
        //[DataRow("2024.01.13", true)]
        //[DataRow("2024.02.18", false)]
        //[DataRow("2024.02.18", true)]
        //[DataRow("2024.02.22", false)]
        //[DataRow("2024.02.23", false)]
        //[DataRow("2024.02.23", false)]
        //[DataRow("2024.02.23", true)]
        //[DataRow("2024.03.07", false)]
        //[DataRow("2024.03.08", true)]
        //[DataRow("2024.03.30", false)]
        //[DataRow("2024.03.30", true)]
        //[DataRow("2024.04.27", false)]
        //[DataRow("2024.04.27", false)]
        //[DataRow("2024.04.27", true)]
        //[DataRow("2024.04.28", false)]
        //[DataRow("2024.04.28", true)]
        //[DataRow("2024.05.01", true)]
        //[DataRow("2024.05.02", false)]
        //[DataRow("2024.05.02", false)]
        //[DataRow("2024.05.02", false)]
        //[DataRow("2024.05.09", true)]
        //[DataRow("2024.05.25", false)]
        //[DataRow("2024.05.25", true)]
        //[DataRow("2024.06.12", true)]
        //[DataRow("2024.11.02", true)]
        //[DataRow("2024.11.04", true)]
        //[DataRow("2024.12.28", false)]
        //[DataRow("2024.12.28", true)]
    }

    public static IEnumerable<TestDataItem> GetDataFor2025()
    {
        yield return TestDataItem.Holiday("2025.01.01");
        yield return TestDataItem.Holiday("2025.01.02");
        yield return TestDataItem.Holiday("2025.01.03");
        yield return TestDataItem.Holiday("2025.01.04");
        yield return TestDataItem.Holiday("2025.01.05");
        yield return TestDataItem.Holiday("2025.01.06");
        yield return TestDataItem.Holiday("2025.01.07");
        yield return TestDataItem.Holiday("2025.01.08");
        yield return TestDataItem.Working("2025.01.09");
        yield return TestDataItem.Working("2025.01.10");
        yield return TestDataItem.Weekend("2025.02.22");
        yield return TestDataItem.Holiday("2025.02.23");
        yield return TestDataItem.Working("2025.03.07");
        yield return TestDataItem.Holiday("2025.03.08");
        yield return TestDataItem.Weekend("2025.04.27");
        yield return TestDataItem.Holiday("2025.05.01");
        yield return TestDataItem.Holiday("2025.05.02");
        yield return TestDataItem.Weekend("2025.05.03");
        yield return TestDataItem.Holiday("2025.05.08");
        yield return TestDataItem.Holiday("2025.05.09");
        yield return TestDataItem.Holiday("2025.06.12");
        yield return TestDataItem.Holiday("2025.06.13");
        yield return TestDataItem.Weekend("2025.10.04");
        yield return TestDataItem.WorWeek("2025.11.01");
        yield return TestDataItem.Holiday("2025.11.03");
        yield return TestDataItem.Holiday("2025.11.04");
        yield return TestDataItem.Weekend("2025.12.20");
        yield return TestDataItem.Holiday("2025.12.31");
    }
}