Imports System.Web.Mvc
Imports WeatherApp.DataAccess
Imports WeatherApp.Models

Namespace Controllers
    Public Class WeatherForcastController
        Inherits Controller

        ' GET: WeatherForcast
        Function Index(id As Integer) As ActionResult

            Try
                ' Retrieve the requested location
                Dim userLocationService As New UserLocationService
                Dim userLocation = userLocationService.GetUserLocationById(id)

                ' Check result
                If userLocation Is Nothing Then
                    ' Record failure 
                    ViewBag.Error = "Unable to get location"

                    'Display the error
                    Return View()
                Else

                    ' Display the location
                    Return View(userLocation)
                End If

            Catch ex As Exception
                ' Record failure 
                ViewBag.Error = "Unable to get details for location: " & ex.Message

                ' Display the error
                Return View()
            End Try

        End Function

        Function UpdateWeather(locationId As Integer) As ActionResult
            Try
                ' Retrieve the requested location
                Dim userLocationService As New UserLocationService
                Dim userLocation = userLocationService.GetUserLocationById(locationId)

                ' Check result
                If userLocation Is Nothing Then
                    ' Record failure 
                    ViewBag.Error = "Unable to get location"

                    ' Display the error
                    Return View("Index")

                Else
                    ' Get address of the weather service
                    Dim urlForApi As String = ConfigurationManager.AppSettings("WeatherApiUrl")

                    ' Get the weather for this location
                    Dim locationWeather As New LocationWeather(userLocation)
                    locationWeather.GetWeatherForcastForLocation(urlForApi)

                    ' Refresh the data
                    userLocation = userLocationService.GetUserLocationById(locationId)

                    ' Display the data
                    Return View("Index", userLocation)

                End If

            Catch ex As Exception
                ' Record failure 
                ViewBag.Error = "Unable to get details for location: " & ex.Message

                ' Display the error
                Return View("Index")
            End Try

        End Function

    End Class
End Namespace