
' Sub class used in OpenMeteo API to store the units for each item of data returned

Imports WeatherApp.Interfaces

Public Class OpenMeteoWeatherUnits

    Implements IWeatherUnits

    Private _time As String
    Public Property Time As String Implements IWeatherUnits.Time
        Get
            Return _time
        End Get
        Set(value As String)
            _time = value
        End Set
    End Property

    Private _weather_code As String
    Public Property WeatherCode As String Implements IWeatherUnits.WeatherCode
        Get
            Return _weather_code
        End Get
        Set(value As String)
            _weather_code = value
        End Set
    End Property
    Public Property Weather_code As String
        Get
            Return _weather_code
        End Get
        Set(value As String)
            _weather_code = value
        End Set
    End Property

    Private _temperature_2m_max As String
    Public Property Temperature2mMax As String Implements IWeatherUnits.Temperature2mMax
        Get
            Return _temperature_2m_max
        End Get
        Set(value As String)
            _temperature_2m_max = value
        End Set
    End Property
    Public Property Temperature_2m_max As String
        Get
            Return _temperature_2m_max
        End Get
        Set(value As String)
            _temperature_2m_max = value
        End Set
    End Property

    Private _temperature_2m_min As String
    Public Property Temperature2mMin As String Implements IWeatherUnits.Temperature2mMin
        Get
            Return _temperature_2m_min
        End Get
        Set(value As String)
            _temperature_2m_min = value
        End Set
    End Property
    Public Property Temperature_2m_min As String
        Get
            Return _temperature_2m_min
        End Get
        Set(value As String)
            _temperature_2m_min = value
        End Set
    End Property
End Class
