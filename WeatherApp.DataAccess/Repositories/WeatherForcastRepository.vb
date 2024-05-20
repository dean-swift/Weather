Public Class WeatherForcastRepository
    Private ReadOnly _context As WeatherAppDbContext

    Public Sub New(context As WeatherAppDbContext)
        _context = context
    End Sub

    Public Sub Save(weatherForcast As WeatherForcast)
        _context.WeatherForcasts.Add(weatherForcast)
        _context.SaveChanges()
    End Sub

    Public Function GetById(id As Integer) As WeatherForcast
        Return _context.WeatherForcasts.Find(id)
    End Function

    Public Function GetAll() As List(Of WeatherForcast)
        Return _context.WeatherForcasts.ToList()
    End Function

    Public Sub Delete(id As Integer)
        ' Locate the entity to delete
        Dim weatherForcastToDelete = _context.WeatherForcasts.Find(id)

        ' Check if the entity exists
        If weatherForcastToDelete IsNot Nothing Then
            ' Mark the entity for deletion
            _context.WeatherForcasts.Remove(weatherForcastToDelete)

            ' Save changes to the database
            _context.SaveChanges()
        End If

    End Sub

    Public Sub Update(weatherForcast As WeatherForcast)
        ' Locate the entity to update
        Dim weatherForcastToUpdate = _context.UserLocations.Find(weatherForcast.WeatherForcastId)

        ' Check if the entity exists
        If weatherForcastToUpdate IsNot Nothing Then
            ' Save changes to the database
            _context.SaveChanges()
        End If

    End Sub
End Class
