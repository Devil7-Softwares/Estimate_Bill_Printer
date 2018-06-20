Public Class Service
    Sub New(ByVal ID As Integer, ByVal ServiceName As String, ByVal Fees As String)
        Me.ID = ID
        Me.ServiceName = ServiceName
        Me.Fees = Fees
    End Sub
    Property ID As Integer
    Property ServiceName As String
    Property Fees As String
    Public Shared Function FromXML(ByVal XML As String) As List(Of Service)
        Try
            Dim x As New Xml.Serialization.XmlSerializer(GetType(List(Of Service)))
            Return x.Deserialize(New IO.MemoryStream(System.Text.Encoding.ASCII.GetBytes(XML)))
        Catch ex As Exception

        End Try
        Return Nothing
    End Function
    Public Shared Function ToXML(ByVal List As List(Of Service)) As String
        Try
            Dim x As New Xml.Serialization.XmlSerializer(GetType(List(Of Service)))
            Dim Stream As New IO.MemoryStream
            x.Serialize(Stream, List)
            Return System.Text.Encoding.ASCII.GetString(Stream.ToArray)
        Catch ex As Exception

        End Try
        Return ""
    End Function
End Class