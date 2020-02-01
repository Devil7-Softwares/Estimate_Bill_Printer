Public Class frm_Senders

    Private Sub frm_Senders_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Worker.IsBusy Then Worker.RunWorkerAsync()
    End Sub

    Function Details() As List(Of Sender)
        Return CType(GridControl_Senders.DataSource, List(Of Sender))
    End Function

    Private Sub btn_Refresh_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btn_Refresh.ItemClick
        If Not Worker.IsBusy Then Worker.RunWorkerAsync()
    End Sub

    Private Sub btn_Add_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btn_Add.ItemClick
        Dim d As New frm_Sender(DialogMode.Add)
        If d.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            Details.Add(d.Item)
            GridControl_Senders.RefreshDataSource()
        End If
    End Sub

    Private Sub btn_Edit_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btn_Edit.ItemClick
        If GridView_Senders.SelectedRowsCount = 1 Then
            Dim r = GridView_Senders.GetRow(GridView_Senders.GetSelectedRows(0))
            Dim index As Integer = Details.IndexOf(r)
            Dim n As New frm_Sender(DialogMode.Edit, r)
            If n.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                Details.Remove(r)
                Details.Insert(index, n.Item)
            End If
        End If
    End Sub

    Private Sub btn_Remove_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btn_Remove.ItemClick
        Try
            If GridView_Senders.SelectedRowsCount > 0 Then
                For Each i As Integer In GridView_Senders.GetSelectedRows
                    Dim r As Sender = GridView_Senders.GetRow(i)
                    If Database.Senders.Delete(r.ID) > 0 Then
                        Details.Remove(r)
                    Else
                        MsgBox("Error in deleting sender.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error")
                    End If
                Next
                GridControl_Senders.RefreshDataSource()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Worker_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Worker.DoWork
        Me.Invoke(Sub()
                      ProgressPanel_Loading.Visible = True
                      btn_Refresh.Enabled = False
                      btn_Add.Enabled = False
                      btn_Edit.Enabled = False
                      btn_Remove.Enabled = False
                  End Sub)
        Dim List As List(Of Sender) = Database.Senders.Fetch(False)
        Me.Invoke(Sub()
                      GridControl_Senders.DataSource = List
                  End Sub)
        Me.Invoke(Sub()
                      ProgressPanel_Loading.Visible = False
                      btn_Refresh.Enabled = True
                      btn_Add.Enabled = True
                      btn_Edit.Enabled = True
                      btn_Remove.Enabled = True
                  End Sub)
    End Sub

    Private Sub ProgressPanel_Loading_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProgressPanel_Loading.Click

    End Sub
End Class