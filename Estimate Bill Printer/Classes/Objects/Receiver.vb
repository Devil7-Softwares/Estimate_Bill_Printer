Public Class Receiver
    Sub New()
    End Sub
    Sub New(ByVal ID As Integer, ByVal Name As String, ByVal Address As String, ByVal State As String, ByVal StateCode As String, ByVal GSTIN As String)
        Me.ID = ID
        Me.Name = Name
        Me.Address = Address
        Me.GSTIN = GSTIN
        Me.State = State
        Me.StateCode = StateCode
    End Sub
    Property ID As Integer
    Property Name As String = ""
    Property Address As String = ""
    Property State As String = ""
    Property StateCode As String = ""
    Property GSTIN As String = ""
    Public Overrides Function ToString() As String
        Return Me.Name
    End Function
    Public Shared Function FromXML(ByVal XML As String) As Receiver
        Try
            Dim x As New Xml.Serialization.XmlSerializer(GetType(Receiver))
            Return x.Deserialize(New IO.MemoryStream(System.Text.Encoding.ASCII.GetBytes(XML)))
        Catch ex As Exception

        End Try
        Return Nothing
    End Function
    Public Function ToXML() As String
        Try
            Dim x As New Xml.Serialization.XmlSerializer(GetType(Receiver))
            Dim Stream As New IO.MemoryStream
            x.Serialize(Stream, Me)
            Return System.Text.Encoding.ASCII.GetString(Stream.ToArray)
        Catch ex As Exception

        End Try
        Return ""
    End Function
End Class