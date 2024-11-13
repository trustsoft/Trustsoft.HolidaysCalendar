// -------------------------Copyright © 2024 M.Sukhanov. All rights reserved.-------------------------
//  <copyright file="XmlCalendarDataProvider.cs" author="M.Sukhanov">
//      Copyright © 2024 M.Sukhanov. All rights reserved.
//  </copyright>
//  <date>09.11.2024</date>
// -------------------------Copyright © 2024 M.Sukhanov. All rights reserved.-------------------------

namespace Trustsoft.HolidaysCalendar.DataProviders;

using System;
using System.Xml.Linq;
using Trustsoft.HolidaysCalendar.Contracts;

public class XmlCalendarDataProvider : IHolidaysDataProvider
{
    private const string BaseUrl = "http://xmlcalendar.ru/data/ru/{0}/calendar.xml";

    public IHolidaysData GetHolidaysData(int year)
    {
        string GetFirstAttributeValue(XElement element, string attributeName)
        {
            return element.Attributes(attributeName).FirstOrDefault()?.Value ?? string.Empty;
        }

        bool ParseDateAndType(XElement element, out DateOnly date, out int dayType)
        {
            var day = GetFirstAttributeValue(element, "d");
            var type = GetFirstAttributeValue(element, "t");
            date = default;
            dayType = 0;

            if (string.IsNullOrEmpty(day) || string.IsNullOrEmpty(day))
            {
                return false;
            }

            if (!int.TryParse(type, out dayType))
            {
                return false;
            }

            return DateOnly.TryParseExact($"{year}.{day}", "yyyy.MM.dd", out date);
        }

        var requestUri = string.Format(BaseUrl, year);
        using var httpClient = new HttpClient();
        httpClient.Timeout = TimeSpan.FromSeconds(60);
        var response = httpClient.GetStringAsync(requestUri).Result;
        using var reader = new StringReader(response);
        XDocument doc = XDocument.Load(reader);
        var days = doc.Descendants("day");

        var holidays = new List<DateOnly>();
        var workingWeekends = new List<DateOnly>();

        foreach (var element in days)
        {
            if (ParseDateAndType(element, out var date, out var dayType))
            {
                switch (dayType)
                {
                    // if holiday
                    case 1:
                        holidays.Add(date);
                        break;
                    // if working day, pre-holiday
                    //case 2:
                    //    break;
                    // if working weekend
                    case 3:
                        workingWeekends.Add(date);
                        break;
                }
            }
        }

        return new HolidaysData(holidays, workingWeekends);
    }
}