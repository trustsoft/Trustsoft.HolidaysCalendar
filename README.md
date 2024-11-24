## Extendable library to work with holidays calendary with ease. ##
## Расширяемая библиотека для работы с (производственным) календарём праздников.<br> ##

[GitHub repository](https://github.com/trustsoft/Trustsoft.HolidaysCalendar "Visit GiHub Repository")<br>

Library for working with the holiday calendar.

Data providers:<br>
Out of the box, only Russian holiday calendar at [http://xmlcalendar.ru](http://xmlcalendar.ru) is supported.<br>
You can develop your own data provider.

Провайдеры данных:<br>
Из коробки поддерживается только календарь праздников России http://xmlcalendar.ru.<br>
Вы можете разработать свой провайдер данных.

Usage:
-----------------------------------------------------------------------------------
	
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


#### Contracts: ####

- IHolidaysCalendar - Describes a set of functions for working with holiday calendar.

- IHolidaysDataProvider - Describes a holiday data provider.

- IFallbackDataProvider - Describes a fallback holiday data provider.

- IHolidaysData - Describes a result of fetching data by data provider.



#### Implementations: ####

- HolidaysCalendar - `IHolidayCalendar` implementation.

- HolidaysDataFactory - Used to create object that implements `IHolidaysData`.

- XmlCalendarDataProvider - Russian holidays data provider.

- FallbackDataProvider - Russian holidays fallback data provider.