Public Class WeatherForcastItemService
    Private ReadOnly _weatherForcastItemRepository As WeatherForcastItemRepository

    Public Sub New()
        Dim weatherAppDbContext As New WeatherAppDbContext
        _weatherForcastItemRepository = New WeatherForcastItemRepository(weatherAppDbContext)
    End Sub
    Public Sub New(weatherForcastItemRepository As WeatherForcastItemRepository)
        _weatherForcastItemRepository = weatherForcastItemRepository
    End Sub
    Public Sub SaveWeatherForcastItem(weatherForcastItem As WeatherForcastItem)
        ' Perform any business logic here
        If weatherForcastItem.WeatherForcastItemId = 0 Then
            _weatherForcastItemRepository.Save(weatherForcastItem)
        Else
            _weatherForcastItemRepository.Update(weatherForcastItem)
        End If
    End Sub

    Public Function GetWeatherForcastItemById(id As Integer) As WeatherForcastItem
        Return _weatherForcastItemRepository.GetById(id)
    End Function

    Public Function GetAllWeatherForcastItems() As List(Of WeatherForcastItem)
        Return _weatherForcastItemRepository.GetAll()
    End Function
    Public Sub Delete(id As Integer)
        ' Perform any business logic here
        _weatherForcastItemRepository.Delete(id)
    End Sub
End Class
