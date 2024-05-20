Public Class WeatherForcastService
    Private ReadOnly _weatherForcastRepository As WeatherForcastRepository

    Public Sub New()
        Dim weatherAppDbContext As New WeatherAppDbContext
        _weatherForcastRepository = New WeatherForcastRepository(weatherAppDbContext)
    End Sub
    Public Sub New(weatherForcastRepository As WeatherForcastRepository)
        _weatherForcastRepository = weatherForcastRepository
    End Sub
    Public Sub SaveWeatherForcast(weatherForcast As WeatherForcast)
        ' Perform any business logic here
        If weatherForcast.WeatherForcastId = 0 Then
            _weatherForcastRepository.Save(weatherForcast)
        Else
            _weatherForcastRepository.Update(weatherForcast)
        End If
    End Sub

    Public Function GetWeatherForcastById(id As Integer) As WeatherForcast
        Return _weatherForcastRepository.GetById(id)
    End Function

    Public Function GetAllWeatherForcasts() As List(Of WeatherForcast)
        Return _weatherForcastRepository.GetAll()
    End Function
    Public Sub Delete(id As Integer)
        ' Perform any business logic here
        _weatherForcastRepository.Delete(id)
    End Sub
End Class
