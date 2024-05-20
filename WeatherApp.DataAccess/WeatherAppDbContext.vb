Imports System
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.Data.Entity
Imports System.Linq

Partial Public Class WeatherAppDbContext
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=WeatherAppData")
    End Sub

    Public Overridable Property UserLocations As DbSet(Of UserLocation)
    Public Overridable Property WeatherForcasts As DbSet(Of WeatherForcast)
    Public Overridable Property WeatherForcastItems As DbSet(Of WeatherForcastItem)

    Protected Overrides Sub OnModelCreating(ByVal modelBuilder As DbModelBuilder)
        modelBuilder.Entity(Of UserLocation)() _
            .Property(Function(e) e.Latitude) _
            .HasPrecision(18, 4)

        modelBuilder.Entity(Of UserLocation)() _
            .Property(Function(e) e.Longitude) _
            .HasPrecision(18, 4)

        modelBuilder.Entity(Of UserLocation)() _
            .Property(Function(e) e.LocationName) _
            .IsUnicode(False)

        modelBuilder.Entity(Of WeatherForcast)() _
            .Property(Function(e) e.Latitude) _
            .HasPrecision(18, 4)

        modelBuilder.Entity(Of WeatherForcast)() _
            .Property(Function(e) e.Longitude) _
            .HasPrecision(18, 4)

        modelBuilder.Entity(Of WeatherForcast)() _
            .Property(Function(e) e.GenerationtimeMs) _
            .HasPrecision(18, 0)

        modelBuilder.Entity(Of WeatherForcast)() _
            .Property(Function(e) e.WeatherUnitsDate) _
            .IsUnicode(False)

        modelBuilder.Entity(Of WeatherForcast)() _
            .Property(Function(e) e.WeatherUnitsWeatherCode) _
            .IsUnicode(False)

        modelBuilder.Entity(Of WeatherForcast)() _
            .Property(Function(e) e.WeatherUnitsTemperatureMax) _
            .IsUnicode(False)

        modelBuilder.Entity(Of WeatherForcast)() _
            .Property(Function(e) e.WeatherUnitsTemperatureMin) _
            .IsUnicode(False)

        modelBuilder.Entity(Of WeatherForcastItem)() _
            .Property(Function(e) e.WeatherCode) _
            .HasPrecision(18, 4)

        modelBuilder.Entity(Of WeatherForcastItem)() _
            .Property(Function(e) e.TemperatureMax) _
            .HasPrecision(18, 4)

        modelBuilder.Entity(Of WeatherForcastItem)() _
            .Property(Function(e) e.TemperatureMin) _
            .HasPrecision(18, 4)
    End Sub
End Class
