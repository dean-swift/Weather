Public Interface IWeather
    Property ForcastDate() As List(Of Date)
    Property WeatherCode() As List(Of Integer)
    Property Temperature2mMax() As List(Of Decimal)
    Property Temperature2mMin() As List(Of Decimal)

End Interface
