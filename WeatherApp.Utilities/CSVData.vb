Imports System.Web
Imports Microsoft.VisualBasic.FileIO

Public Class CSVData

    ' Internal arrag of strings used for processing
    Private _columnArray As String()
    Public Property ColumnArray() As String()
        Get
            Return _columnArray
        End Get
        Set(ByVal value As String())
            _columnArray = value
        End Set
    End Property

    'Default constructor
    Public Sub New()
        ' Initialise to a single instance
        ReDim _columnArray(0)
    End Sub

    'Function to process a provided file and return a collection of CSVData classes, 1 per row in the file
    Public Function GetDataListFromCSV(file As HttpPostedFileBase) As List(Of CSVData)

        ' Establish internal list
        Dim dataList As New List(Of CSVData)

        Try

            ' Set up the file stream
            Using csvReader As New TextFieldParser(file.InputStream)
                csvReader.TextFieldType = FieldType.Delimited
                csvReader.SetDelimiters(",")

                ' Loop through the file
                While Not csvReader.EndOfData
                    ' Read a line
                    Dim fields As String() = csvReader.ReadFields()

                    ' Initialise a new data class
                    Dim data As New CSVData

                    For currentField As Integer = 0 To fields.Count - 1
                        ' Extend array size if needed
                        ReDim Preserve data.ColumnArray(currentField)
                        ' Copy out the field value to the class
                        data.ColumnArray(currentField) = fields(currentField)
                    Next



                    'Does this need any validation since it is a generic function??



                    ' Add new class to the collection
                    dataList.Add(data)
                End While
            End Using

        Catch ex As Exception

        End Try

        'Output the result
        Return dataList

    End Function
End Class
