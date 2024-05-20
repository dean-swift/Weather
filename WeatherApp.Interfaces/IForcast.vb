Public Interface IForcast

    Function GetWeatherForcast(urlForApi As String, latitude As Decimal, longitude As Decimal) As IForcast

    Property Latitude As Decimal
    Property Longitude As Decimal
    Property GenerationTimeMs As Decimal
    Property UtcOffsetSeconds As Integer
    Property Timezone As String
    Property TimezoneAbbreviation As String
    Property Elevation As Decimal

End Interface
