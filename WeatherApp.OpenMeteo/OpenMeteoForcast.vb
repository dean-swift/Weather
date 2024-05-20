
' Sub class used in OpenMeteo API to hold the overall forcast entry that is returned

Imports Newtonsoft.Json
Imports System.Net
Imports System.Net.Http
Imports System.Threading
Imports WeatherApp.Interfaces


Public Class OpenMeteoForcast

    Implements IForcast

    Private _latitude As Decimal
    Public Property Latitude As Decimal Implements IForcast.Latitude
        Get
            Return _latitude
        End Get
        Set(value As Decimal)
            _latitude = value
        End Set
    End Property

    Private _longitude As Decimal
    Public Property Longitude As Decimal Implements IForcast.Longitude
        Get
            Return _longitude
        End Get
        Set(value As Decimal)
            _longitude = value
        End Set
    End Property


    Private _generationtime_ms As Decimal
    Public Property Generationtime_ms As Decimal
        Get
            Return _generationtime_ms
        End Get
        Set(value As Decimal)
            _generationtime_ms = value
        End Set
    End Property
    Public Property GenerationTimeMs As Decimal Implements IForcast.GenerationTimeMs
        Get
            Return _generationtime_ms
        End Get
        Set(value As Decimal)
            _generationtime_ms = value
        End Set
    End Property


    Private _utc_offset_seconds As Integer
    Public Property Utc_offset_seconds As Integer
        Get
            Return _utc_offset_seconds
        End Get
        Set(value As Integer)
            _utc_offset_seconds = value
        End Set
    End Property
    Public Property UtcOffsetSeconds As Integer Implements IForcast.UtcOffsetSeconds
        Get
            Return _utc_offset_seconds
        End Get
        Set(value As Integer)
            _utc_offset_seconds = value
        End Set
    End Property


    Private _timezone As String
    Public Property Timezone As String Implements IForcast.Timezone
        Get
            Return _timezone
        End Get
        Set(value As String)
            _timezone = value
        End Set
    End Property



    Private _timezone_abbreviation As String
    Public Property Timezone_abbreviation As String
        Get
            Return _timezone_abbreviation
        End Get
        Set(value As String)
            _timezone_abbreviation = value
        End Set
    End Property
    Public Property TimezoneAbbreviation As String Implements IForcast.TimezoneAbbreviation
        Get
            Return _timezone_abbreviation
        End Get
        Set(value As String)
            _timezone_abbreviation = value
        End Set
    End Property




    Private _elevation As Decimal
    Public Property Elevation As Decimal Implements IForcast.Elevation
        Get
            Return _elevation
        End Get
        Set(value As Decimal)
            _elevation = value
        End Set
    End Property


    Private _daily_units As New OpenMeteoWeatherUnits
    Public Property Daily_units As OpenMeteoWeatherUnits
        Get
            Return _daily_units
        End Get
        Set(value As OpenMeteoWeatherUnits)
            _daily_units = value
        End Set
    End Property


    Private _daily As New OpenMeteoWeather
    Public Property Daily As OpenMeteoWeather
        Get
            Return _daily
        End Get
        Set(value As OpenMeteoWeather)
            _daily = value
        End Set
    End Property


    'API call to get a weather forcast
    Public Function GetWeatherForcast(urlForApi As String, latitude As Decimal, longitude As Decimal) As IForcast Implements IForcast.GetWeatherForcast

        ' URL of the JSON API
        Dim apiUrl As String = String.Concat(urlForApi, "?latitude=", latitude, "&longitude=", longitude, "&daily=weather_code,temperature_2m_max,temperature_2m_min&timezone=auto")

        Dim weatherForcast As New OpenMeteoForcast

        ' Create an instance of HttpClient
        Using client As New HttpClient()
            ' Send a GET request to the API
            Dim response As HttpResponseMessage = client.GetAsync(apiUrl).Result

            ' Check if the request was successful
            If response.IsSuccessStatusCode Then
                ' Read the response content as a string
                Dim jsonString As String = response.Content.ReadAsStringAsync().Result

                ' Deserialize the JSON string into an object
                weatherForcast = JsonConvert.DeserializeObject(Of OpenMeteoForcast)(jsonString)
            Else
                ' Print error message if request fails
                'Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}")
            End If
        End Using

        Return weatherForcast

    End Function


End Class



