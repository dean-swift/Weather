Imports System.Runtime.Remoting.Contexts

Public Class UserLocationRepository
    Private ReadOnly _context As WeatherAppDbContext

    Public Sub New(context As WeatherAppDbContext)
        _context = context
    End Sub

    Public Sub Save(userLocation As UserLocation)
        _context.UserLocations.Add(userLocation)
        _context.SaveChanges()
    End Sub

    Public Function GetById(id As Integer) As UserLocation
        Return _context.UserLocations.Find(id)
    End Function

    Public Function GetAll() As List(Of UserLocation)
        Return _context.UserLocations.ToList()
    End Function

    Public Sub Delete(id As Integer)
        ' Locate the entity to delete
        Dim userLocationToDelete = _context.UserLocations.Find(id)

        ' Check if the entity exists
        If userLocationToDelete IsNot Nothing Then
            ' Mark the entity for deletion
            _context.UserLocations.Remove(userLocationToDelete)

            ' Save changes to the database
            _context.SaveChanges()
        End If

    End Sub

    Public Sub Update(userLocation As UserLocation)
        ' Locate the entity to update
        Dim userLocationToUpdate = _context.UserLocations.Find(userLocation.UserLocationId)

        ' Check if the entity exists
        If userLocationToUpdate IsNot Nothing Then
            ' Save changes to the database
            _context.SaveChanges()
        End If

    End Sub
End Class
