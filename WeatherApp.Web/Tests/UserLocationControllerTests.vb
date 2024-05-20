Imports System.IO
Imports System.Web.Mvc
Imports WeatherApp.DataAccess
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class UserLocationControllerTests
    <TestMethod()> Public Sub Index()
        ' Arrange
        Dim controller As New UserLocationController()

        ' Act
        Dim result As ViewResult = DirectCast(controller.Index(), ViewResult)

        ' Assert
        Assert.IsNotNull(result)
        ' Check we have a list of locations passed back to the view
        If result.Model IsNot Nothing AndAlso TypeOf result.Model Is List(Of UserLocation) Then
            ' Check the first location has an ID
            Dim locationList As List(Of UserLocation) = DirectCast(result.Model, List(Of UserLocation))
            Assert.IsTrue(locationList(0).UserLocationId > 0)
        Else
            ' Unexpected result type
            Assert.Fail("Unexpected result type returned")
        End If
    End Sub

    <TestMethod()> Public Sub Delete()
        ' Arrange
        Dim controller As New UserLocationController()
        Dim userLocationId As Integer = 28

        ' Act
        Dim result As ViewResult = DirectCast(controller.Delete(userLocationId), ViewResult)

        ' Assert
        Assert.IsNotNull(result)
        'Dim viewResult As ViewResult = DirectCast(result, ViewResult)
        Assert.AreEqual("Index", result.ViewName)
    End Sub

    <TestMethod()> Public Sub UploadFile_NoFile()
        ' Arrange
        Dim controller As New UserLocationController()

        ' Act
        Dim result As ActionResult = controller.UploadFile(Nothing)

        ' Assert
        If TypeOf result Is RedirectToRouteResult Then
            ' Assert for RedirectToRouteResult
            Dim redirectToActionResult As RedirectToRouteResult = DirectCast(result, RedirectToRouteResult)
            Assert.AreEqual("Index", redirectToActionResult.RouteValues("action"))
        ElseIf TypeOf result Is ViewResult Then
            ' Assert for ViewResult
            Dim viewResult As ViewResult = DirectCast(result, ViewResult)
            Assert.AreEqual("Index", viewResult.ViewName)
        Else
            ' Unexpected result type
            Assert.Fail("Unexpected result type returned")
        End If
    End Sub

    <TestMethod()> Public Sub UploadFile_FileWithHeadings()
        ' Arrange

        ' Need to mock upload of a file that has headings to be ignored
        Dim relativePath As String = "MockData\Location.csv"
        Dim filePath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath)

        ' Have added a new mockHttpPostedFileBase class to simulate the upload
        Dim stream As New FileStream(filePath, FileMode.Open)
        Dim mockHttpPostedFileBase As New Utilities.MockHttpPostedFileBase(stream, "data.csv")

        Dim controller As New UserLocationController()

        ' Act
        Dim result As ActionResult = controller.UploadFile(mockHttpPostedFileBase)

        ' Assert
        If TypeOf result Is RedirectToRouteResult Then
            ' Assert for RedirectToRouteResult
            Dim redirectToActionResult As RedirectToRouteResult = DirectCast(result, RedirectToRouteResult)
            Assert.AreEqual("Index", redirectToActionResult.RouteValues("action"))
        ElseIf TypeOf result Is ViewResult Then
            ' Assert for ViewResult
            Dim viewResult As ViewResult = DirectCast(result, ViewResult)
            Assert.AreEqual("Index", viewResult.ViewName)
        Else
            ' Unexpected result type
            Assert.Fail("Unexpected result type returned")
        End If
    End Sub

    <TestMethod()> Public Sub UploadFile_FileWithoutHeadings()
        ' Arrange

        ' Need to mock upload of a file that has no headings to ignore
        Dim relativePath As String = "MockData\Location-NoTitle.csv"
        Dim filePath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath)

        ' Have added a new mockHttpPostedFileBase class to simulate the upload
        Dim stream As New FileStream(filePath, FileMode.Open)
        Dim mockHttpPostedFileBase As New Utilities.MockHttpPostedFileBase(stream, "data.csv")

        Dim controller As New UserLocationController()

        ' Act
        Dim result As ActionResult = controller.UploadFile(mockHttpPostedFileBase)

        ' Assert
        If TypeOf result Is RedirectToRouteResult Then
            ' Assert for RedirectToRouteResult
            Dim redirectToActionResult As RedirectToRouteResult = DirectCast(result, RedirectToRouteResult)
            Assert.AreEqual("Index", redirectToActionResult.RouteValues("action"))
        ElseIf TypeOf result Is ViewResult Then
            ' Assert for ViewResult
            Dim viewResult As ViewResult = DirectCast(result, ViewResult)
            Assert.AreEqual("Index", viewResult.ViewName)
        Else
            ' Unexpected result type
            Assert.Fail("Unexpected result type returned")
        End If
    End Sub
    <TestMethod()> Public Sub UploadFile_FileWithoutData()
        ' Arrange

        ' Need to mock upload of a file that has no headings to ignore
        Dim relativePath As String = "MockData\Location-NoData.csv"
        Dim filePath As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath)

        ' Have added a new mockHttpPostedFileBase class to simulate the upload
        Dim stream As New FileStream(filePath, FileMode.Open)
        Dim mockHttpPostedFileBase As New Utilities.MockHttpPostedFileBase(stream, "data.csv")

        Dim controller As New UserLocationController()

        ' Act
        Dim result As ActionResult = controller.UploadFile(mockHttpPostedFileBase)

        ' Assert
        Dim viewResult As ViewResult = DirectCast(result, ViewResult)
        Assert.AreEqual("Index", viewResult.ViewName)

    End Sub

End Class
