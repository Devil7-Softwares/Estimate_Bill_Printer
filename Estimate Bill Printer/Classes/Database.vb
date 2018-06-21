Imports MySql.Data.MySqlClient

Module Database
    Private connection As MySqlConnection
    Function GetConnection() As MySqlConnection
        If connection Is Nothing Then
            connection = New MySqlConnection(String.Format("server={0};port={1}; user id={2}; password={3}; database={4}; pooling=true", Encryption.Decrypt(My.Settings.Server), If(Encryption.Decrypt(My.Settings.Port) = "", 3306, Encryption.Decrypt(My.Settings.Port)), Encryption.Decrypt(My.Settings.Username), Encryption.Decrypt(My.Settings.Password), Encryption.Decrypt(My.Settings.Database)))
        End If
        Return connection
    End Function

#Region "Entries"
    Private BillsTable As String = "bills"
    Function GetEntries(ByVal CloseConnection As Boolean) As List(Of PrintData)
        Dim r As New List(Of PrintData)
        Try
            Dim conn As MySqlConnection = GetConnection()
            If (conn.State = ConnectionState.Closed) Then
                conn.Open()
            End If
            Using cmd As New MySqlCommand("SELECT *  FROM " & BillsTable, conn)
                Using dr As MySqlDataReader = cmd.ExecuteReader
                    While dr.Read
                        Dim ID As Integer = dr.Item("ID")
                        Dim SerialNumber As String = dr.Item("Serial").ToString
                        Dim EstimateDate As Date = dr.Item("Estimate Date")
                        Dim Sender As Sender = Sender.FromXML(dr.Item("Sender").ToString)
                        Dim Services As List(Of Service) = Service.FromXML(dr.Item("Service").ToString)
                        Dim Receiver As Receiver = Receiver.FromXML(dr.Item("Receiver").ToString)
                        r.Add(New PrintData(ID, Sender, SerialNumber, EstimateDate, Receiver, Services))
                    End While
                End Using
            End Using
            If CloseConnection Then conn.Close()
        Catch ex As Exception
            MsgBox("Error while loading courses" & vbNewLine & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Error")
        End Try
        Return r
    End Function
#End Region
End Module
