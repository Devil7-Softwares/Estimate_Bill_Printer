Public Class frm_Receivers
    Private Sub frm_Receivers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Worker.IsBusy Then Worker.RunWorkerAsync()
    End Sub

    Function Details() As List(Of Receiver)
        Return CType(GridControl_Receivers.DataSource, List(Of Receiver))
    End Function

    Private Sub btn_Add_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btn_Add.ItemClick
        Dim d As New frm_Receiver(DialogMode.Add)
        If d.ShowDialog = Windows.Forms.DialogResult.OK Then
            Details.Add(d.Item)
            GridControl_Receivers.RefreshDataSource()
        End If
    End Sub

    Private Sub btn_Edit_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btn_Edit.ItemClick
        Try
            If GridView_Receivers.SelectedRowsCount = 1 Then
                Dim r = GridView_Receivers.GetRow(GridView_Receivers.GetSelectedRows(0))
                Dim index As Integer = Details.IndexOf(r)
                Dim n As New frm_Receiver(DialogMode.Edit, r)
                If n.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Details.Remove(r)
                    Details.Insert(index, n.Item)
                    GridControl_Receivers.RefreshDataSource()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_Remove_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btn_Remove.ItemClick
        Try
            If GridView_Receivers.SelectedRowsCount > 0 Then
                For Each i As Integer In GridView_Receivers.GetSelectedRows
                    Dim r As Receiver = GridView_Receivers.GetRow(i)
                    If Database.Receivers.Delete(r.ID) > 0 Then
                        Details.Remove(r)
                    Else
                        MsgBox("Error in deleting receiver.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error")
                        Exit For
                    End If
                Next
                GridControl_Receivers.RefreshDataSource()
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
        Dim List As List(Of Receiver) = Database.Receivers.Fetch(False)
        Me.Invoke(Sub()
                      GridControl_Receivers.DataSource = List
                  End Sub)
        Me.Invoke(Sub()
                      ProgressPanel_Loading.Visible = False
                      btn_Refresh.Enabled = True
                      btn_Add.Enabled = True
                      btn_Edit.Enabled = True
                      btn_Remove.Enabled = True
                  End Sub)
    End Sub

    Private Sub btn_Refresh_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btn_Refresh.ItemClick
        If Not Worker.IsBusy Then Worker.RunWorkerAsync()
    End Sub
End Class