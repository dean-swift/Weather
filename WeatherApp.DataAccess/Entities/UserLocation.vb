Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("UserLocation")>
Partial Public Class UserLocation
    Public Sub New()
        WeatherForcasts = New HashSet(Of WeatherForcast)()
    End Sub

    <Key>
    Public Property UserLocationId As Integer

    Public Property Latitude As Decimal?

    Public Property Longitude As Decimal?

    <StringLength(255)>
    Public Property LocationName As String

    Public Overridable Property WeatherForcasts As ICollection(Of WeatherForcast)
End Class
