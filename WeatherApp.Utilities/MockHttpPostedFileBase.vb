Imports System.IO
Imports System.Web

Public Class MockHttpPostedFileBase
    Inherits HttpPostedFileBase

    Private ReadOnly _stream As Stream
    Private ReadOnly _fileName As String
    Private ReadOnly _contentLength As Integer

    Public Sub New(stream As Stream, fileName As String)
        _stream = stream
        _fileName = fileName
        _contentLength = CInt(stream.Length)
    End Sub
    Public Overrides ReadOnly Property InputStream As Stream
        Get
            Return _stream
        End Get
    End Property
    Public Overrides ReadOnly Property FileName As String
        Get
            Return _fileName
        End Get
    End Property

    Public Overrides ReadOnly Property ContentLength As Integer
        Get
            Return _contentLength
        End Get
    End Property

    'Public Overrides Function Read(buffer As Byte(), offset As Integer, count As Integer) As Integer
    '    Return _stream.Read(buffer, offset, count)
    'End Function

    'Public Overrides Function Read(buffer As Byte(), offset As Long, count As Integer) As Integer
    '    Return _stream.Read(buffer, CInt(offset), count)
    'End Function

    'Public Overrides Function Read(buffer As Byte(), offset As Integer, count As Long) As Integer
    '    Return _stream.Read(buffer, offset, CInt(count))
    'End Function

    'Public Overrides Function Read(buffer As Byte(), offset As Long, count As Long) As Integer
    '    Return _stream.Read(buffer, CInt(offset), CInt(count))
    'End Function

    'Public Overrides Function ReadByte() As Integer
    '    Return _stream.ReadByte()
    'End Function

    'Public Overrides Function Seek(offset As Long, origin As SeekOrigin) As Long
    '    Return _stream.Seek(offset, origin)
    'End Function

    'Public Overrides Sub Close()
    '    _stream.Close()
    'End Sub

    'Protected Overrides Sub Dispose(disposing As Boolean)
    '    If disposing Then
    '        _stream.Dispose()
    '    End If
    '    MyBase.Dispose(disposing)
    'End Sub

    ' Add other members as needed...
End Class
