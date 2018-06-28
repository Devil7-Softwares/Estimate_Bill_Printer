Imports System.Xml.Serialization

Public Class ServerSettings
    Private Shared ConfigFilePath As String = IO.Path.Combine(Application.StartupPath, "ServerSettings.config")
    Property DatabaseName As String
    Property ServerName As String
    Property Password As String
    Property UserName As String
    Property Port As String
    Public Shared Function Load() As ServerSettings
        Dim serializer As New XmlSerializer(GetType(ServerSettings))
        Dim deserialized As New ServerSettings
        Try
            Using file = System.IO.File.OpenRead(ConfigFilePath)
                deserialized = DirectCast(serializer.Deserialize(file), ServerSettings)
            End Using
        Catch ex As Exception

        End Try
        Return deserialized
    End Function
    Sub Save()
        Dim serializer As New XmlSerializer(GetType(ServerSettings))
        Dim ms As New IO.MemoryStream
        serializer.Serialize(ms, Me)
        My.Computer.FileSystem.WriteAllBytes(ConfigFilePath, ms.ToArray, False)
    End Sub
End Class
