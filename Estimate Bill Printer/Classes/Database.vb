Imports MySql.Data.MySqlClient

Module Database
    Public DatabaseName As String = Encryption.Decrypt(My.Settings.Database)
    Private connection As MySqlConnection
    Function GetConnection() As MySqlConnection
        If connection Is Nothing Then
            connection = New MySqlConnection(String.Format("server={0};port={1}; user id={2}; password={3}; database={4}; pooling=true", Encryption.Decrypt(My.Settings.Server), If(Encryption.Decrypt(My.Settings.Port) = "", 3306, Encryption.Decrypt(My.Settings.Port)), Encryption.Decrypt(My.Settings.Username), Encryption.Decrypt(My.Settings.Password), Encryption.Decrypt(My.Settings.Database)))
        End If
        Return connection
    End Function
    Public Class Entries
        Public Shared TableName As String = "bills"
        Public Shared Function Fetch(ByVal CloseConnection As Boolean) As List(Of PrintData)
            Dim r As New List(Of PrintData)
            Try
                Dim conn As MySqlConnection = GetConnection()
                If (conn.State = ConnectionState.Closed) Then
                    conn.Open()
                End If
                Using cmd As New MySqlCommand("SELECT *  FROM " & TableName, conn)
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
                MsgBox("Error while loading bills" & vbNewLine & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Error")
            End Try
            Return r
        End Function
        Public Shared Function Create(ByVal Sender As Sender, ByVal SerialNumber As String, ByVal EstimateDate As Date, ByVal Receiver As Receiver, ByVal Services As List(Of Service), ByVal CloseConnection As Boolean) As PrintData
            Try
                Dim Connection As MySqlConnection = GetConnection()
                If Connection.State = ConnectionState.Closed Then Connection.Open()

                Dim CommandText As String = String.Format("INSERT INTO `{0}`.`{1}` (`Serial`,`Estimate Date`,`Sender`,`Service`,`Receiver`) VALUES (@Serial,@EstimateDate,@Sender,@Service,@Receiver);SELECT LAST_INSERT_ID();", DatabaseName, TableName)

                Using Command As New MySqlCommand(CommandText, Connection)
                    Command.Parameters.AddWithValue("@Serial", SerialNumber)
                    Command.Parameters.AddWithValue("@EstimateDate", EstimateDate)
                    Command.Parameters.AddWithValue("@Sender", Sender.ToXML)
                    Command.Parameters.AddWithValue("@Service", Service.ToXML(Services))
                    Command.Parameters.AddWithValue("@Receiver", Receiver.ToXML)

                    Dim ID As Integer = Command.ExecuteScalar
                    If ID > 0 Then
                        Return New PrintData(ID, Sender, SerialNumber, EstimateDate, Receiver, Services)
                    Else
                        MsgBox("Unknown error on creating bill.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Error")
                    End If
                End Using
            Catch ex As Exception
                MsgBox("Error while creating bill." & vbNewLine & vbNewLine & "Additional Information:" & ex.Message & vbNewLine & vbNewLine & ex.StackTrace, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Error")
            End Try
            Return Nothing
        End Function
        Public Shared Function Delete(ByVal ID As Integer) As Integer
            Try
                Dim Connection As MySqlConnection = GetConnection()
                If Connection.State = ConnectionState.Closed Then Connection.Open()

                Dim CommandText As String = String.Format("DELETE FROM `{0}`.`{1}` WHERE ID={2};", DatabaseName, TableName, ID)

                Using Command As New MySqlCommand(CommandText, Connection)
                    Return Command.ExecuteNonQuery
                End Using
            Catch ex As Exception
                MsgBox("Error while deleting bill." & vbNewLine & vbNewLine & "Additional Information:" & ex.Message & vbNewLine & vbNewLine & ex.StackTrace, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Error")
            End Try
            Return 0
        End Function
    End Class
    Public Class Senders
        Public Shared TableName As String = "senders"
        Public Shared Function Fetch(ByVal CloseConnection As Boolean) As List(Of Sender)
            Dim r As New List(Of Sender)
            Try
                Dim conn As MySqlConnection = GetConnection()
                If (conn.State = ConnectionState.Closed) Then
                    conn.Open()
                End If
                Using cmd As New MySqlCommand("SELECT *  FROM " & TableName, conn)
                    Using dr As MySqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            Dim ID As Integer = dr.Item("ID")
                            Dim Name As String = dr.Item("Name").ToString
                            Dim Address As String = dr.Item("Address").ToString
                            Dim GSTIN As String = dr.Item("GSTIN").ToString
                            Dim WatermarkText As String = dr.Item("WatermarkText").ToString
                            Dim WatermarkAngle As String = dr.Item("WatermarkAngle").ToString
                            Dim WatermarkFontName As String = dr.Item("WatermarkFontName").ToString
                            Dim WatermarkFontSize As String = dr.Item("WatermarkFontSize").ToString
                            Dim WatermarkColor As Color = Color.FromArgb(dr.Item("WatermarkColor").ToString)
                            Dim WatermarkOpacity As String = dr.Item("WatermarkOpacity").ToString
                            Dim Heading As String = dr.Item("Heading").ToString
                            Dim Location As Point = New Point(dr.Item("Location").ToString.Split(",")(0), dr.Item("Location").ToString.Split(",")(1))

                            
                            r.Add(New Sender(ID, Name, Address, GSTIN, WatermarkText, WatermarkAngle, WatermarkFontName, WatermarkFontSize, WatermarkColor, WatermarkOpacity, Heading, Location))
                        End While
                    End Using
                End Using
                If CloseConnection Then conn.Close()
            Catch ex As Exception
                MsgBox("Error while loading courses" & vbNewLine & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Error")
            End Try
            Return r
        End Function
        Public Shared Function Create(ByVal Name As String, ByVal Address As String, ByVal GSTIN As String, ByVal WatermarkText As String, ByVal WatermarkAngle As Integer, ByVal WatermarkFontName As String, ByVal WatermarkFontSize As Single, ByVal WatermarkColor As Color, ByVal WatermarkOpacity As Integer, ByVal Heading As String, ByVal Location As Point, ByVal CloseConnection As Boolean) As Sender
            Try
                Dim Connection As MySqlConnection = GetConnection()
                If Connection.State = ConnectionState.Closed Then Connection.Open()

                Dim CommandText As String = String.Format("INSERT INTO `{0}`.`{1}` (`Name`, `Address`, `GSTIN`, `WatermarkText`, `WatermarkAngle`, `WatermarkFontName`, `WatermarkFontSize`, `WatermarkColor`, `WatermarkOpacity`, `Heading`, `Location`) VALUES (@Name, @Address, @GSTIN, @WatermarkText, @WatermarkAngle, @WatermarkFontName, @WatermarkFontSize, @WatermarkColor, @WatermarkOpacity, @Heading, @Location);SELECT LAST_INSERT_ID();", DatabaseName, TableName)

                Using Command As New MySqlCommand(CommandText, Connection)
                    Command.Parameters.AddWithValue("@Name", Name)
                    Command.Parameters.AddWithValue("@Address", Address)
                    Command.Parameters.AddWithValue("@GSTIN", GSTIN)
                    Command.Parameters.AddWithValue("@WatermarkText", WatermarkText)
                    Command.Parameters.AddWithValue("@WatermarkAngle", WatermarkAngle)
                    Command.Parameters.AddWithValue("@WatermarkFontName", WatermarkFontName)
                    Command.Parameters.AddWithValue("@WatermarkFontSize", WatermarkFontSize)
                    Command.Parameters.AddWithValue("@WatermarkColor", WatermarkColor.ToArgb)
                    Command.Parameters.AddWithValue("@WatermarkOpacity", WatermarkOpacity)
                    Command.Parameters.AddWithValue("@Heading", Heading)
                    Command.Parameters.AddWithValue("@Location", Location.X & "," & Location.Y)

                    Dim Result As Integer = Command.ExecuteScalar
                    If Result > 0 Then
                        Return New Sender(Result, Name, Address, GSTIN, WatermarkText, WatermarkAngle, WatermarkFontName, WatermarkFontSize, WatermarkColor, WatermarkOpacity, Heading, Location)
                    Else
                        MsgBox("Unknown error on creating sender.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Error")
                    End If
                End Using
            Catch ex As Exception
                MsgBox("Error while creating sender." & vbNewLine & vbNewLine & "Additional Information:" & ex.Message & vbNewLine & vbNewLine & ex.StackTrace, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Error")
            End Try
            Return Nothing
        End Function
        Public Shared Function Edit(ByVal ID As Integer, ByVal Name As String, ByVal Address As String, ByVal GSTIN As String, ByVal WatermarkText As String, ByVal WatermarkAngle As Integer, ByVal WatermarkFontName As String, ByVal WatermarkFontSize As Single, ByVal WatermarkColor As Color, ByVal WatermarkOpacity As Integer, ByVal Heading As String, ByVal Location As Point, ByVal CloseConnection As Boolean) As Sender
            Try
                Dim Connection As MySqlConnection = GetConnection()
                If Connection.State = ConnectionState.Closed Then Connection.Open()

                Dim CommandText As String = String.Format("UPDATE `{0}`.`{1}` SET `Name`=@Name, `Address`= @Address, `GSTIN`= @GSTIN, `WatermarkText`= @WatermarkText, `WatermarkAngle`= @WatermarkAngle, `WatermarkFontName`= @WatermarkFontName, `WatermarkFontSize`= @WatermarkFontSize, `WatermarkColor`= @WatermarkColor, `WatermarkOpacity`= @WatermarkOpacity, `Heading`= @Heading, `Location`= @Location WHERE ID={2};", DatabaseName, TableName, ID)

                Using Command As New MySqlCommand(CommandText, Connection)
                    Command.Parameters.AddWithValue("@Name", Name)
                    Command.Parameters.AddWithValue("@Address", Address)
                    Command.Parameters.AddWithValue("@GSTIN", GSTIN)
                    Command.Parameters.AddWithValue("@WatermarkText", WatermarkText)
                    Command.Parameters.AddWithValue("@WatermarkAngle", WatermarkAngle)
                    Command.Parameters.AddWithValue("@WatermarkFontName", WatermarkFontName)
                    Command.Parameters.AddWithValue("@WatermarkFontSize", WatermarkFontSize)
                    Command.Parameters.AddWithValue("@WatermarkColor", WatermarkColor.ToArgb)
                    Command.Parameters.AddWithValue("@WatermarkOpacity", WatermarkOpacity)
                    Command.Parameters.AddWithValue("@Heading", Heading)
                    Command.Parameters.AddWithValue("@Location", Location.X & "," & Location.Y)

                    Dim Result As Integer = Command.ExecuteNonQuery
                    If Result > 0 Then
                        Return New Sender(Result, Name, Address, GSTIN, WatermarkText, WatermarkAngle, WatermarkFontName, WatermarkFontSize, WatermarkColor, WatermarkOpacity, Heading, Location)
                    Else
                        MsgBox("Unknown error on editing sender.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Error")
                    End If
                End Using
            Catch ex As Exception
                MsgBox("Error while editing sender." & vbNewLine & vbNewLine & "Additional Information:" & ex.Message & vbNewLine & vbNewLine & ex.StackTrace, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Error")
            End Try
            Return Nothing
        End Function
        Public Shared Function Delete(ByVal ID As Integer) As Integer
            Try
                Dim Connection As MySqlConnection = GetConnection()
                If Connection.State = ConnectionState.Closed Then Connection.Open()

                Dim CommandText As String = String.Format("DELETE FROM `{0}`.`{1}` WHERE ID={2};", DatabaseName, TableName, ID)

                Using Command As New MySqlCommand(CommandText, Connection)
                    Return Command.ExecuteNonQuery
                End Using
            Catch ex As Exception
                MsgBox("Error while deleting sender." & vbNewLine & vbNewLine & "Additional Information:" & ex.Message & vbNewLine & vbNewLine & ex.StackTrace, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Error")
            End Try
            Return 0
        End Function
    End Class
    Public Class Receivers
        Public Shared TableName As String = "receivers"
        Public Shared Function Fetch(ByVal CloseConnection As Boolean) As List(Of Receiver)
            Dim r As New List(Of Receiver)
            Try
                Dim conn As MySqlConnection = GetConnection()
                If (conn.State = ConnectionState.Closed) Then
                    conn.Open()
                End If
                Using cmd As New MySqlCommand("SELECT *  FROM " & TableName, conn)
                    Using dr As MySqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            Dim ID As Integer = dr.Item("ID")
                            Dim Name As String = dr.Item("Name").ToString
                            Dim Address As String = dr.Item("Address").ToString
                            Dim State As String = dr.Item("State").ToString
                            Dim Statecode As String = dr.Item("StateCode").ToString
                            Dim GSTIN As String = dr.Item("GSTIN").ToString
                            r.Add(New Receiver(ID, Name, Address, State, StateCode, GSTIN))
                        End While
                    End Using
                End Using
                If CloseConnection Then conn.Close()
            Catch ex As Exception
                MsgBox("Error while loading bills" & vbNewLine & ex.Message, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Error")
            End Try
            Return r
        End Function
        Public Shared Function Create(ByVal Name As String, ByVal Address As String, ByVal State As String, ByVal StateCode As String, ByVal GSTIN As String, ByVal CloseConnection As Boolean) As Receiver
            Try
                Dim Connection As MySqlConnection = GetConnection()
                If Connection.State = ConnectionState.Closed Then Connection.Open()

                Dim CommandText As String = String.Format("INSERT INTO `{0}`.`{1}` (`Name`,`Address`,`State`,`StateCode`,`GSTIN`) VALUES (@Name,@Address,@State,@StateCode,@GSTIN);SELECT LAST_INSERT_ID();", DatabaseName, TableName)

                Using Command As New MySqlCommand(CommandText, Connection)
                    Command.Parameters.AddWithValue("@Name", Name)
                    Command.Parameters.AddWithValue("@Address", Address)
                    Command.Parameters.AddWithValue("@State", State)
                    Command.Parameters.AddWithValue("@StateCode", StateCode)
                    Command.Parameters.AddWithValue("@GSTIN", GSTIN)
                    Dim Result As Integer = Command.ExecuteScalar
                    If Result > 0 Then
                        Return New Receiver(Result, Name, Address, State, StateCode, GSTIN)
                    Else
                        MsgBox("Unknown error on creating receiver.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Error")
                    End If
                End Using
            Catch ex As Exception
                MsgBox("Error while creating receiver." & vbNewLine & vbNewLine & "Additional Information:" & ex.Message & vbNewLine & vbNewLine & ex.StackTrace, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Error")
            End Try
            Return Nothing
        End Function
        Public Shared Function Edit(ByVal ID As Integer, ByVal Name As String, ByVal Address As String, ByVal State As String, ByVal StateCode As String, ByVal GSTIN As String, ByVal CloseConnection As Boolean) As Receiver
            Try
                Dim Connection As MySqlConnection = GetConnection()
                If Connection.State = ConnectionState.Closed Then Connection.Open()

                Dim CommandText As String = String.Format("UPDATE `{0}`.`{1}` SET `Name`=@Name,`Address`=@Address,`State`=@State,`StateCode`=@StateCode,`GSTIN`=@GSTIN WHERE ID={2};", DatabaseName, TableName, ID)

                Using Command As New MySqlCommand(CommandText, Connection)
                    Command.Parameters.AddWithValue("@Name", Name)
                    Command.Parameters.AddWithValue("@Address", Address)
                    Command.Parameters.AddWithValue("@State", State)
                    Command.Parameters.AddWithValue("@StateCode", StateCode)
                    Command.Parameters.AddWithValue("@GSTIN", GSTIN)
                    Dim Result As Integer = Command.ExecuteNonQuery
                    If Result > 0 Then
                        Return New Receiver(Result, Name, Address, State, StateCode, GSTIN)
                    Else
                        MsgBox("Unknown error on editing receiver.", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Error")
                    End If
                End Using
            Catch ex As Exception
                MsgBox("Error while creating receiver." & vbNewLine & vbNewLine & "Additional Information:" & ex.Message & vbNewLine & vbNewLine & ex.StackTrace, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Error")
            End Try
            Return Nothing
        End Function
        Public Shared Function Delete(ByVal ID As Integer) As Integer
            Try
                Dim Connection As MySqlConnection = GetConnection()
                If Connection.State = ConnectionState.Closed Then Connection.Open()

                Dim CommandText As String = String.Format("DELETE FROM `{0}`.`{1}` WHERE ID={2};", DatabaseName, TableName, ID)

                Using Command As New MySqlCommand(CommandText, Connection)
                    Return Command.ExecuteNonQuery
                End Using
            Catch ex As Exception
                MsgBox("Error while deleting receiver." & vbNewLine & vbNewLine & "Additional Information:" & ex.Message & vbNewLine & vbNewLine & ex.StackTrace, MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Error")
            End Try
            Return 0
        End Function
    End Class
    Public Class Services
        Shared TableName As String = "variables"
        Shared IDName As String = "services"
        Public Shared Function Save(ByVal Services As List(Of String), ByVal CloseConnection As Boolean) As Integer
            Dim Connection As MySqlConnection = GetConnection()
            Try
                If Connection.State = ConnectionState.Closed Then Connection.Open()

                Dim CommandText As String = String.Format("UPDATE `{0}`.`{1}` SET `Data` = @Data WHERE `Name` = ""Services"";", DatabaseName, TableName)

                Using Command As New MySqlCommand(CommandText, Connection)
                    Dim s As String = ""
                    For Each i As String In Services
                        s &= i & vbNewLine
                    Next
                    Command.Parameters.AddWithValue("@Data", s)
                    Return Command.ExecuteNonQuery
                End Using
            Catch ex As Exception
                MsgBox("Error while saving services." & vbNewLine & vbNewLine & "Additional Information :" & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.StackTrace, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error")
            Finally
                If closeconnection Then Connection.Close()
            End Try
            Return 0
        End Function
        Public Shared Function Load(ByVal CloseConnection As Boolean) As List(Of String)
            Dim r As New List(Of String)
            Dim Connection As MySqlConnection = GetConnection()
            Try
                If Connection.State = ConnectionState.Closed Then Connection.Open()

                Dim CommandText As String = String.Format("SELECT `{1}`.`Data` FROM `{0}`.`{1}` WHERE `{1}`.`Name` = @Name;", DatabaseName, TableName)
                Using Command As New MySqlCommand(CommandText, Connection)
                    Command.Parameters.AddWithValue("@Name", IDName)
                    Dim s As String = Command.ExecuteScalar.ToString.Trim
                    If s <> "" Then
                        Dim Lines As String() = s.Split(vbNewLine)
                        For Each i As String In Lines
                            r.Add(i.Trim)
                        Next
                    End If
                End Using
            Catch ex As Exception
                MsgBox("Error while saving services." & vbNewLine & vbNewLine & "Additional Information :" & vbNewLine & vbNewLine & ex.Message & vbNewLine & vbNewLine & ex.StackTrace, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error")
            End Try
            If CloseConnection Then Connection.Close()
            Return r
        End Function
    End Class
End Module
