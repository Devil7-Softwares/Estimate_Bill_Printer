Public Class frm_ServerSettings

    Private Sub btn_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Save.Click
        My.Settings.Server = Encryption.Encrypt(txt_ServerName.Text)
        My.Settings.port = Encryption.Encrypt(txt_Port.Value)
        My.Settings.Database = Encryption.Encrypt(txt_DatabaseName.Text)
        My.Settings.Username = Encryption.Encrypt(txt_UserName.Text)
        My.Settings.Password = Encryption.Encrypt(txt_Password.Text)
        My.Settings.Save()
        Me.DialogResult = Windows.Forms.DialogResult.OK
        MsgBox("Successfully saved Server Settings. Restart application to apply the changes.", MsgBoxStyle.Information + MsgBoxStyle.OkOnly, "Done")
        Me.Close()
    End Sub

    Private Sub frm_ServerSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txt_ServerName.Text = Encryption.Decrypt(My.Settings.Server)
        txt_Port.Value = CInt(Encryption.Decrypt(My.Settings.port))
        txt_DatabaseName.Text = Encryption.Decrypt(My.Settings.Database)
        txt_UserName.Text = Encryption.Decrypt(My.Settings.Username)
        txt_Password.Text = Encryption.Decrypt(My.Settings.Password)
    End Sub
End Class