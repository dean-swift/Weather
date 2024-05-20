Imports System.Web.Mvc
Imports WeatherApp.DataAccess
Imports WeatherApp.Interfaces
Imports WeatherApp.Models
Imports WeatherApp.OpenMeteo

'Namespace Controllers
Public Class UserLocationController
    Inherits Controller


    ' GET: For all UserLocations
    Function Index() As ActionResult

        ' Get stored locations
        Dim UserLocationService As New UserLocationService
        Dim savedUserLocations = UserLocationService.GetAllUserLocations()

        ' Check for results
        If savedUserLocations Is Nothing AndAlso savedUserLocations.Count() = 0 Then

            ' Record failure 
            ViewBag.Error = "Unable to get locations"

            'Display the error
            Return View()
        Else

            'Return View(displayUserLocations)
            Return View(savedUserLocations)
        End If


    End Function


    ' Upload and process the file
    <HttpPost>
    Function UploadFile(file As HttpPostedFileBase) As ActionResult

        ' Create a collection of location classes
        Dim userLocationService As New UserLocationService

        Try
            ' Validate that a file was selected And Not empty
            If file IsNot Nothing AndAlso file.ContentLength > 0 Then

                ' Establish a generic data utility class
                Dim dataRow As New Utilities.CSVData

                ' Get the content from the passed file
                Dim uploadedData As New List(Of Utilities.CSVData)
                uploadedData = dataRow.GetDataListFromCSV(file)

                Dim locationUploadCount As Integer

                ' Loop through the content to process
                For Each dataRow In uploadedData

                    ' Do some validation, could do more
                    If IsNumeric(dataRow.ColumnArray(0)) AndAlso IsNumeric(dataRow.ColumnArray(1)) Then

                        ' Convert to Location class
                        Dim userLocation As New UserLocation With {
                            .Latitude = dataRow.ColumnArray(0),
                            .Longitude = dataRow.ColumnArray(1),
                            .LocationName = dataRow.ColumnArray(2)
                        }

                        ' Save the location
                        userLocationService.SaveUserLocation(userLocation)

                        ' Update the counter
                        locationUploadCount += 1
                    End If
                Next

                If locationUploadCount = 0 Then
                    ' No valid locations
                    ViewBag.Error = "No valid locations in the selected file"
                Else
                    ViewBag.Message = locationUploadCount & " location(s) uploaded"
                End If

            Else
                ' No file or data in file
                ViewBag.Error = "No valid file provided"
            End If
        Catch ex As Exception
            ViewBag.Error = "Error reading the CSV file: " & ex.Message
        End Try


        ' Get the saved locations
        Dim userLocations = userLocationService.GetAllUserLocations()

        ' Display the page with the locations
        Return View("Index", userLocations)

    End Function

    ' To remove a UserLocation
    Function Delete(id As Integer) As ActionResult

        Dim UserLocationService As New UserLocationService
        Try
            ' Remove the location
            UserLocationService.Delete(id)
        Catch ex As Exception
            ViewBag.Error = "Error deleting the location: " & ex.Message
        End Try

        Dim userLocations = UserLocationService.GetAllUserLocations()
        Return View("Index", userLocations)

    End Function


End Class
'End Namespace