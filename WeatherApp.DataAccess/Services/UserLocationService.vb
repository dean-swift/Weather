Public Class UserLocationService
    Private ReadOnly _userLocationRepository As UserLocationRepository

    Public Sub New()
        Dim weatherAppDbContext As New WeatherAppDbContext
        _userLocationRepository = New UserLocationRepository(weatherAppDbContext)
    End Sub
    Public Sub New(userLocationRepository As UserLocationRepository)
        _userLocationRepository = userLocationRepository
    End Sub
    Public Sub SaveUserLocation(userLocation As UserLocation)
        ' Perform any business logic here
        If userLocation.UserLocationId = 0 Then
            _userLocationRepository.Save(userLocation)
        Else
            _userLocationRepository.Update(userLocation)
        End If
    End Sub

    Public Function GetUserLocationById(id As Integer) As UserLocation
        Return _userLocationRepository.GetById(id)
    End Function

    Public Function GetAllUserLocations() As List(Of UserLocation)
        Return _userLocationRepository.GetAll()
    End Function
    Public Sub Delete(id As Integer)
        ' Perform any business logic here
        _userLocationRepository.Delete(id)
    End Sub
End Class
