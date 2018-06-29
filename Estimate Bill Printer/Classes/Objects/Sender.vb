Imports System.ComponentModel
Public Class Sender
    Sub New(ByVal ID As Integer, ByVal Name As String, ByVal Address As String, ByVal GSTIN As String, ByVal WatermarkText As String, ByVal WatermarkAngle As Integer, ByVal WatermarkFontName As String, ByVal WatermarkFontSize As Single, ByVal WatermarkColor As Color, ByVal WatermarkOpacity As Integer, ByVal Heading As String, ByVal Location As Point)
        Me.ID = ID
        Me.Name = Name
        Me.Address = Address
        Me.GSTIN = GSTIN
        Me.WatermarkText = WatermarkText
        Me.WatermarkAngle = WatermarkAngle
        Me.WatermarkFontName = WatermarkFontName
        Me.WatermarkFontSize = WatermarkFontSize
        Me.WatermarkColor = WatermarkColor
        Me.WatermarkOpacity = WatermarkOpacity
        Me.Heading = Heading
        Me.Location = Location
    End Sub
    Sub New()
    End Sub
    Property ID As Integer
    Property Name As String = ""
    Property Address As String = ""
    Property GSTIN As String = ""
    <Browsable(False)> _
    Property WatermarkText As String = ""
    <Browsable(False)> _
    Property WatermarkAngle As Integer = 0
    <Browsable(False)> _
    Property WatermarkFontName As String = "Microsoft Sans Serif"
    <Browsable(False)> _
    Property WatermarkFontSize As Single = 95.25
    <Browsable(False)> _
    Property WatermarkColor As Color = Color.Black
    <Browsable(False)> _
    Property WatermarkOpacity As Integer = 100
    Property Heading As String = ""
    <Browsable(False)> _
    Property Location As New Point(0, 0)
    Public Overrides Function ToString() As String
        Return Me.Name
    End Function
    Public Shared Function FromXML(ByVal XML As String) As Sender
        Try
            Dim x As New Xml.Serialization.XmlSerializer(GetType(Sender))
            Return x.Deserialize(New IO.MemoryStream(System.Text.Encoding.ASCII.GetBytes(XML)))
        Catch ex As Exception

        End Try
        Return Nothing
    End Function
    Public Function ToXML() As String
        Try
            Dim x As New Xml.Serialization.XmlSerializer(GetType(Sender))
            Dim Stream As New IO.MemoryStream
            x.Serialize(Stream, Me)
            Return System.Text.Encoding.ASCII.GetString(Stream.ToArray)
        Catch ex As Exception

        End Try
        Return ""
    End Function
End Class

