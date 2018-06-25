Public Class frm_OtherSettings

    Private Sub sw_AutoWatermark_Toggled(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sw_AutoWatermark.Toggled
        My.Settings.AutoWatermark = sw_AutoWatermark.IsOn
        My.Settings.Save()
    End Sub

    Private Sub frm_OtherSettings_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        My.Settings.GSTPercentage = txt_GSTPercentage.Value
        My.Settings.TaxDetails = txt_TaxDetailsFormat.Text
        My.Settings.Save()
    End Sub

    Private Sub frm_OtherSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sw_AutoWatermark.IsOn = My.Settings.AutoWatermark
        txt_TaxDetailsFormat.Text = My.Settings.TaxDetails
        txt_GSTPercentage.Value = My.Settings.GSTPercentage
    End Sub
End Class
