Imports System.Web.Mvc
Imports WeatherApp.DataAccess
Imports WeatherApp.Web.Controllers
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class WeatherForcastControllerTests
    <TestMethod()> Public Sub Index()
        ' Arrange
        Dim controller As New WeatherForcastController()
        Dim userLocationId As Integer = 1

        ' Act
        Dim result As ViewResult = DirectCast(controller.Index(userLocationId), ViewResult)

        ' Assert
        Assert.IsNotNull(result)
    End Sub
    <TestMethod()> Public Sub UpdateWeather()
        ' Arrange
        Dim controller As New WeatherForcastController()
        Dim userLocationId As Integer = 1

        ' Act
        Dim result As ViewResult = DirectCast(controller.UpdateWeather(userLocationId), ViewResult)

        ' Assert
        Assert.IsNotNull(result)
        ' Check we have a location passed back to the view
        If result.Model IsNot Nothing AndAlso TypeOf result.Model Is UserLocation Then
            ' Check it is the requested UserLocation
            Dim userLocation As UserLocation = DirectCast(result.Model, UserLocation)
            Assert.AreEqual(userLocationId, userLocation.UserLocationId)
        Else
            ' Unexpected result type
            Assert.Fail("Unexpected result type returned")
        End If

    End Sub
End Class
