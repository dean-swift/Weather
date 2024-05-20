Public Class WeatherForcastItemRepository
    Private ReadOnly _context As WeatherAppDbContext

    Public Sub New(context As WeatherAppDbContext)
        _context = context
    End Sub

    Public Sub Save(weatherForcastItem As WeatherForcastItem)
        _context.WeatherForcastItems.Add(weatherForcastItem)
        _context.SaveChanges()
    End Sub

    Public Function GetById(id As Integer) As WeatherForcastItem
        Return _context.WeatherForcastItems.Find(id)
    End Function

    Public Function GetAll() As List(Of WeatherForcastItem)
        Return _context.WeatherForcastItems.ToList()
    End Function

    Public Sub Delete(id As Integer)
        ' Locate the entity to delete
        Dim weatherForcastItemToDelete = _context.WeatherForcastItems.Find(id)

        ' Check if the entity exists
        If weatherForcastItemToDelete IsNot Nothing Then
            ' Mark the entity for deletion
            _context.WeatherForcastItems.Remove(weatherForcastItemToDelete)

            ' Save changes to the database
            _context.SaveChanges()
        End If

    End Sub

    Public Sub Update(weatherForcastItem As WeatherForcastItem)
        ' Locate the entity to update
        Dim weatherForcastItemToUpdate = _context.UserLocations.Find(weatherForcastItem.WeatherForcastItemId)

        ' Check if the entity exists
        If weatherForcastItemToUpdate IsNot Nothing Then
            ' Save changes to the database
            _context.SaveChanges()
        End If

    End Sub
End Class
