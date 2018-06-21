Public Class frm_Main

    Private Sub frm_Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Worker_Bills.IsBusy Then Worker_Bills.RunWorkerAsync()
    End Sub
    Private Sub Worker_Bills_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Worker_Bills.DoWork
        Me.Invoke(Sub()
                      btn_Refresh.Enabled = False
                      ProgressPanel_Bills.Visible = True
                  End Sub)
        Dim Bills As New List(Of PrintData)
        Try
            Bills = Database.GetEntries(False)
        Catch ex As Exception
            MsgBox("Unable to fetch bills from server." & vbNewLine & _
                   "Additional Information :" & vbNewLine & _
                   ex.Message & vbNewLine & vbNewLine & ex.StackTrace, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error")
        End Try
        Try
            Me.Invoke(Sub()
                          GridControl_Data.DataSource = Bills
                      End Sub)
        Catch ex As Exception

        End Try
        Me.Invoke(Sub()
                      btn_Refresh.Enabled = True
                      ProgressPanel_Bills.Visible = False
                  End Sub)
    End Sub

    Private Sub btn_Refresh_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btn_Refresh.ItemClick
        If Not Worker_Bills.IsBusy Then Worker_Bills.RunWorkerAsync()
    End Sub

    Private Sub btn_ServerSettings_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btn_ServerSettings.ItemClick
        Dim d As New frm_ServerSettings
        d.ShowDialog()
    End Sub
End Class