Public Class frm_Senders

    Private Sub frm_Senders_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GridControl_Senders.DataSource = Database.Senders.Fetch(False)
    End Sub
    Function Details() As List(Of Sender)
        Return CType(GridControl_Senders.DataSource, List(Of Sender))
    End Function
    Private Sub brn_Add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles brn_Add.Click
        Dim d As New frm_Sender(DialogMode.Add)
        If d.ShowDialog = Windows.Forms.DialogResult.OK Then
            Details.Add(d.Item)
            GridControl_Senders.RefreshDataSource()
        End If
    End Sub

    Private Sub brn_Edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles brn_Edit.Click
        If GridView_Senders.SelectedRowsCount = 1 Then
            Dim r = GridView_Senders.GetRow(GridView_Senders.GetSelectedRows(0))
            Dim index As Integer = Details.IndexOf(r)
            Dim n As New frm_Sender(DialogMode.Edit, r)
            If n.ShowDialog = Windows.Forms.DialogResult.OK Then
                Details.Remove(r)
                Details.Insert(index, n.Item)
            End If
        End If
    End Sub

    Private Sub btn_Remove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Remove.Click
        Try
            If GridView_Senders.SelectedRowsCount > 0 Then
                For Each i As Integer In GridView_Senders.GetSelectedRows
                    Dim r = GridView_Senders.GetRow(i)
                    Details.Remove(r)
                Next
                GridControl_Senders.RefreshDataSource()
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class