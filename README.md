# ![Logo](./docs/logo32.png) Trustsoft.HolidaysCalendar

Work with holidays calendar with ease.

[GitHub repository](https://github.com/trustsoft/Trustsoft.HolidaysCalendar "Visit GiHub Repository")\
![GitHub repo size](https://img.shields.io/github/repo-size/trustsoft/Trustsoft.HolidaysCalendar?style=flat&logo=github&color=steelblue "Repository size")
![GitHub license](https://img.shields.io/github/license/trustsoft/Trustsoft.HolidaysCalendar?style=flat&color=steelblue "Repository license")
![GitHub commit activity](https://img.shields.io/github/commit-activity/t/trustsoft/Trustsoft.HolidaysCalendar?style=flat&color=steelblue "Total commits")

[![C#](https://img.shields.io/badge/C%23-gray?style=flat&logo=csharp)](https://dotnet.microsoft.com/en-us/languages/csharp)
[![NET 6.0 - 9.0](https://img.shields.io/badge/NET-6.0_--_9.0-steelblue?style=flat)](https://learn.microsoft.com/en-us/dotnet/fundamentals/)

[![NuGet Stable Version (Trustsoft.HolidaysCalendar)](https://img.shields.io/nuget/v/Trustsoft.HolidaysCalendar.svg?label=nuget&color=steelblue)](https://www.nuget.org/packages/Trustsoft.HolidaysCalendar/latest)
[![NuGet Latest Version (Trustsoft.HolidaysCalendar)](https://img.shields.io/nuget/vpre/Trustsoft.HolidaysCalendar.svg?label=nuget-pre&color=peru)](https://www.nuget.org/packages/Trustsoft.HolidaysCalendar/absoluteLatest )
![NuGet Downloads](https://img.shields.io/nuget/dt/Trustsoft.HolidaysCalendar?color=steelblue)

Library for working with the holiday calendar.

Data providers:<br>
Out of the box, only Russian holiday calendar at [http://xmlcalendar.ru](http://xmlcalendar.ru) is supported.<br>
You can develop your own data provider.

## Getting Started
Install the [NuGet package](http://www.nuget.org/packages/Trustsoft.HolidaysCalendar).

## Usage:
```csharp
// create primary data provider
IHolidaysDataProvider dataProvider = new XmlCalendarDataProvider();

// create fallback data provider
IFallbackDataProvider fallbackDataProvider = new FallbackDataProvider();

// create holiday calendar with data providers
IHolidaysCalendar calendar = new HolidaysCalendar(dataProvider, fallbackDataProvider);
    
// day to check
DateOnly date = DateOnly.ParseExact("2024.10.12", "yyyy.MM.dd");

// checking
bool isHoliday = calendar.IsHoliday(date);

bool isWeekend = calendar.IsWeekend(date);

bool IsWorWeek = calendar.IsWorkingWeekend(date);
```

#### Contracts: ####

- `IHolidaysCalendar` - Describes a set of functions for working with holiday calendar.

- `IHolidaysDataProvider` - Describes a holiday data provider.

- `IFallbackDataProvider` - Describes a fallback holiday data provider.

- `IHolidaysData` - Describes a result of fetching data by data provider.



#### Implementations: ####

- `HolidaysCalendar` - `IHolidayCalendar` implementation.

- `HolidaysDataFactory` - Used to create object that implements `IHolidaysData`.

- `XmlCalendarDataProvider` - Russian holidays data provider.

- `FallbackDataProvider` - Russian holidays fallback data provider.