// -------------------------Copyright © 2024 M.Sukhanov. All rights reserved.-------------------------
//  <copyright file="XmlCalendarDataProvider.cs" author="M.Sukhanov">
//      Copyright © 2024 M.Sukhanov. All rights reserved.
//  </copyright>
//  <date>09.11.2024</date>
// -------------------------Copyright © 2024 M.Sukhanov. All rights reserved.-------------------------

namespace Trustsoft.HolidaysCalendar.DataProviders;

using System;
using System.Net.Http;
using System.Xml.Linq;

using Trustsoft.HolidaysCalendar.Contracts;

/// <summary>
///   Russian holidays data provider for <see cref="IHolidaysCalendar" /> implementation.
///   Implements the <see cref="IHolidaysDataProvider" />.
/// </summary>
/// <remarks> This provider fetches data from 'http://xmlcalendar.ru'. </remarks>
/// <seealso cref="IHolidaysDataProvider" />
public class XmlCalendarDataProvider : IHolidaysDataProvider
{
    private const string BaseUrl = "http://xmlcalendar.ru/data/ru/{0}/calendar.xml";

    private const string DayAttributeName = "d";

    private const string TypeAttributeName = "t";

    private const string DayXElementName = "day";

    /// <summary>
    ///   Gets the holidays data for specified year.
    /// </summary>
    /// <param name="year"> The year to get holidays data for. </param>
    /// <returns>
    ///   The <see cref="IHolidaysData" /> object that contains a result of
    ///   fetching holidays data for specified <paramref name="year"/>.
    /// </returns>
    public IHolidaysData GetHolidaysData(int year)
    {
        string GetFirstAttributeValue(XElement element, string attributeName)
        {
            return element.Attribute(attributeName)?.Value ?? string.Empty;
        }

        bool ParseDateAndType(XElement element, out DateOnly date, out int dayType)
        {
            var day = GetFirstAttributeValue(element, DayAttributeName);
            var type = GetFirstAttributeValue(element, TypeAttributeName);

            if (string.IsNullOrEmpty(day) ||
                string.IsNullOrEmpty(type) ||
                !int.TryParse(type, out dayType))
            {
                date = default;
                dayType = 0;
                return false;
            }

            return DateOnly.TryParseExact($"{year}.{day}", "yyyy.MM.dd", out date);
        }

        var requestUri = string.Format(BaseUrl, year);

        if (!requestUri.LoadDataFromUrl(out XDocument? doc) || doc is null)
        {
            return HolidaysDataFactory.Invalid();
        }

        var days = doc.Descendants(DayXElementName);

        var holidays = new List<DateOnly>();
        var workingWeekends = new List<DateOnly>();

        foreach (XElement element in days)
        {
            if (ParseDateAndType(element, out DateOnly date, out var dayType))
            {
                switch (dayType)
                {
                    // if holiday
                    case 1:
                        holidays.Add(date);
                        break;

                    // if working day, pre-holiday
                    case 2:
                        if (date.DayOfWeek is DayOfWeek.Sunday or DayOfWeek.Saturday)
                        {
                            workingWeekends.Add(date);
                        }

                        break;

                    // if working weekend
                    case 3:
                        workingWeekends.Add(date);
                        break;
                }
            }
        }

        return HolidaysDataFactory.Valid(holidays, workingWeekends);
    }
}

internal static class Extensions
{
    private static bool GetStringFromUrl(this string requestUri, out string response)
    {
        try
        {
            using var client = new HttpClient();

            client.Timeout = TimeSpan.FromSeconds(60);
            response = client.GetStringAsync(requestUri).Result;

            return true;
        }
        catch
        {
            response = string.Empty;
            return false;
        }
    }

    private static bool IsUrlExists(this string uri)
    {
        try
        {
            using var client = new HttpClient();

            //Do only Head request to avoid download full content
            var requestMessage = new HttpRequestMessage(HttpMethod.Head, uri);
            HttpResponseMessage response = client.SendAsync(requestMessage).Result;

            // if we have a SuccessStatusCode so url exists and available 
            return response.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }

    internal static bool LoadDataFromUrl(this string requestUri, out XDocument? doc)
    {
        doc = null;

        if (!requestUri.IsUrlExists())
        {
            return false;
        }

        if (!requestUri.GetStringFromUrl(out string response))
        {
            return false;
        }

        using var reader = new StringReader(response);

        doc = XDocument.Load(reader);

        return true;
    }
}