Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("WeatherForcast")>
Partial Public Class WeatherForcast
    Public Sub New()
        WeatherForcastItems = New HashSet(Of WeatherForcastItem)()
    End Sub
    <Key>
    Public Property WeatherForcastId As Integer

    Public Property UserLocationId As Integer

    Public Property Latitude As Decimal?

    Public Property Longitude As Decimal?

    Public Property GenerationtimeMs As Decimal?

    <StringLength(255)>
    Public Property WeatherUnitsDate As String

    <StringLength(255)>
    Public Property WeatherUnitsWeatherCode As String

    <StringLength(255)>
    Public Property WeatherUnitsTemperatureMax As String

    <StringLength(255)>
    Public Property WeatherUnitsTemperatureMin As String

    Public Property ForcastDate As Date?

    Public Overridable Property UserLocation As UserLocation

    Public Overridable Property WeatherForcastItems As ICollection(Of WeatherForcastItem)
End Class
