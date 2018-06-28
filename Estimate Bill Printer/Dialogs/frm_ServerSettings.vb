Public Class frm_ServerSettings

    Private Sub btn_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Save.Click
        Try
            Settings.ServerName = Encryption.Encrypt(txt_ServerName.Text)
            Settings.Port = Encryption.Encrypt(txt_Port.Value)
            Settings.DatabaseName = Encryption.Encrypt(txt_DatabaseName.Text)
            Settings.UserName = Encryption.Encrypt(txt_UserName.Text)
            Settings.Password = Encryption.Encrypt(txt_Password.Text)
            Settings.Save()
            Me.DialogResult = Windows.Forms.DialogResult.OK
            MsgBox("Successfully saved Server Settings. Restart application to apply the changes.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Done")
            Me.Close()
        Catch ex As Exception
            MsgBox("Error on saving settings. Try running as administrator" & vbNewLine & vbNewLine & "Additional Information:" & vbNewLine & ex.Message & vbNewLine & ex.StackTrace, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub

    Private Sub frm_ServerSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txt_ServerName.Text = Encryption.Decrypt(Settings.ServerName)
        txt_Port.Value = CInt(Encryption.Decrypt(Settings.Port))
        txt_DatabaseName.Text = Encryption.Decrypt(Settings.DatabaseName)
        txt_UserName.Text = Encryption.Decrypt(Settings.UserName)
        txt_Password.Text = Encryption.Decrypt(Settings.Password)
    End Sub
End Class