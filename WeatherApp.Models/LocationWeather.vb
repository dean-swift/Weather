Imports WeatherApp.DataAccess
Imports WeatherApp.OpenMeteo

Public Class LocationWeather


    ' Properties

    Private _userLocation As UserLocation
    Public Property UserLocation() As UserLocation
        Get
            Return _userLocation
        End Get
        Set(ByVal value As UserLocation)
            _userLocation = value
        End Set
    End Property


    ' Constructor

    Public Sub New(userLocation As UserLocation)
        _userLocation = userLocation
    End Sub


    ' Function to save a weather forcast for the location
    Public Function GetWeatherForcastForLocation(weatherApiUrl As String) As Boolean
        Try

            ' Establish a Weather Service
            Dim meteoForcast As New OpenMeteoForcast

            ' Get the weather for this location
            meteoForcast = meteoForcast.GetWeatherForcast(weatherApiUrl, _userLocation.Latitude, _userLocation.Longitude)


            'Build a forcast
            Dim locationWeather As New WeatherForcast With {
                .UserLocationId = _userLocation.UserLocationId,
                .Latitude = meteoForcast.Latitude,
                .Longitude = meteoForcast.Longitude,
                .ForcastDate = DateTime.Now,
                .GenerationtimeMs = meteoForcast.Generationtime_ms,
                .WeatherUnitsDate = meteoForcast.Daily_units.Time,
                .WeatherUnitsWeatherCode = meteoForcast.Daily_units.WeatherCode,
                .WeatherUnitsTemperatureMax = meteoForcast.Daily_units.Temperature2mMax,
                .WeatherUnitsTemperatureMin = meteoForcast.Daily_units.Temperature2mMin
            }

            ' Save the forcast
            Dim weatherForcastService As New WeatherForcastService
            weatherForcastService.SaveWeatherForcast(locationWeather)

            ' Build a collection of forcast items

            Dim countForcasts As Integer
            For countForcasts = 0 To meteoForcast.Daily.Time.Count - 1

                Dim locationWeatherItem As New WeatherForcastItem With {
                    .WeatherForcastId = locationWeather.WeatherForcastId,
                    .WeatherItemDate = meteoForcast.Daily.Time(countForcasts),
                    .WeatherCode = meteoForcast.Daily.WeatherCode(countForcasts),
                    .TemperatureMax = meteoForcast.Daily.Temperature_2m_max(countForcasts),
                    .TemperatureMin = meteoForcast.Daily.Temperature_2m_min(countForcasts)
                }
                'Save the item
                Dim weatherForcastItemService As New WeatherForcastItemService
                weatherForcastItemService.SaveWeatherForcastItem(locationWeatherItem)
            Next

            'Show success
            Return True

        Catch ex As Exception
            'Show failure
            Return False
        End Try
    End Function
End Class
