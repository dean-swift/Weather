
' Sub class used in OpenMeteo API to hold each item of data returned

Imports WeatherApp.Interfaces

Public Class OpenMeteoWeather

    Implements IWeather

    Private _time As List(Of Date)
    Public Property Time As List(Of Date)
        Get
            Return _time
        End Get
        Set(value As List(Of Date))
            _time = value
        End Set
    End Property
    Public Property ForcastDate As List(Of Date) Implements IWeather.ForcastDate
        Get
            Return _time
        End Get
        Set(value As List(Of Date))
            _time = value
        End Set
    End Property



    Private _weather_code As List(Of Integer)
    Public Property Weather_code As List(Of Integer)
        Get
            Return _weather_code
        End Get
        Set(value As List(Of Integer))
            _weather_code = value
        End Set
    End Property
    Public Property WeatherCode As List(Of Integer) Implements IWeather.WeatherCode
        Get
            Return _weather_code
        End Get
        Set(value As List(Of Integer))
            _weather_code = value
        End Set
    End Property




    Private _temperature_2m_max As List(Of Decimal)
    Public Property Temperature_2m_max As List(Of Decimal)
        Get
            Return _temperature_2m_max
        End Get
        Set(value As List(Of Decimal))
            _temperature_2m_max = value
        End Set
    End Property
    Public Property Temperature2mMax As List(Of Decimal) Implements IWeather.Temperature2mMax
        Get
            Return _temperature_2m_max
        End Get
        Set(value As List(Of Decimal))
            _temperature_2m_max = value
        End Set
    End Property




    Private _temperature_2m_min As List(Of Decimal)
    Public Property Temperature_2m_min As List(Of Decimal)
        Get
            Return _temperature_2m_min
        End Get
        Set(value As List(Of Decimal))
            _temperature_2m_min = value
        End Set
    End Property
    Public Property Temperature2mMin As List(Of Decimal) Implements IWeather.Temperature2mMin
        Get
            Return _temperature_2m_min
        End Get
        Set(value As List(Of Decimal))
            _temperature_2m_min = value
        End Set
    End Property


End Class
