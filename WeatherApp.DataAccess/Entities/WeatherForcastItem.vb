Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity.Spatial

<Table("WeatherForcastItem")>
Partial Public Class WeatherForcastItem
    <Key>
    Public Property WeatherForcastItemId As Integer

    Public Property WeatherForcastId As Integer

    <Column(TypeName:="date")>
    Public Property WeatherItemDate As Date?

    Public Property WeatherCode As Decimal?

    Public Property TemperatureMax As Decimal?

    Public Property TemperatureMin As Decimal?

    Public Overridable Property WeatherForcast As WeatherForcast
End Class
