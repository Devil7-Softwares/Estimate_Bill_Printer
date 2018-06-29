Public Class frm_Main
    Dim ServicesList As New List(Of String)
    Dim SendersList As New List(Of Sender)
    Dim ReceiversList As New List(Of Receiver)

    Private Sub frm_Main_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        My.Settings.Skin = Me.GetSkin.Name
        My.Settings.WindowState = Me.WindowState
        My.Settings.Size = Me.Size
        My.Settings.Location = Me.Location
        My.Settings.Save()
    End Sub
    Private Sub frm_Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = My.Settings.WindowState
        Me.Size = My.Settings.Size
        Me.Location = My.Settings.Location
        If My.Settings.Skin <> "" Then
            Try
                Me.Theme.LookAndFeel.SkinName = My.Settings.Skin
            Catch ex As Exception

            End Try
        End If
        If Not Worker_Bills.IsBusy Then Worker_Bills.RunWorkerAsync()
    End Sub
    Private Sub Worker_Bills_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles Worker_Bills.DoWork
        Me.Invoke(Sub()
                      btn_Refresh.Enabled = False
                      ProgressPanel_Bills.Visible = True
                  End Sub)
        Dim Bills As New List(Of PrintData)
        Try
            Bills = Database.Entries.Fetch(False)
        Catch ex As Exception
            MsgBox("Unable to fetch bills from server." & vbNewLine & _
                   "Additional Information :" & vbNewLine & _
                   ex.Message & vbNewLine & vbNewLine & ex.StackTrace, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error")
        End Try
        Me.ReceiversList = Database.Receivers.Fetch(False)
        Me.SendersList = Database.Senders.Fetch(False)
        Me.ServicesList = Database.Services.Load(False)
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

    Private Sub btn_Add_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btn_Add.ItemClick
        Dim sa As String = "0000"
        Try
            Dim sno As Integer = 0
            Dim formatr As String = "0000"
            For Each i As PrintData In GridControl_Data.DataSource
                Try
                    If CInt(i.SerialNumber) > sno Then
                        sno = CInt(i.SerialNumber)
                        formatr = i.SerialNumber
                        For ino As Integer = 1 To 9
                            formatr = formatr.Replace(ino, 0)
                        Next
                    End If
                Catch ex As Exception

                End Try
            Next
            If sno > 0 Then
                sa = CInt(sno + 1).ToString(formatr)
            End If
        Catch ex As Exception

        End Try

        Dim d As New frm_Data(DialogMode.Add, ServicesList, ReceiversList, SendersList, Serial:=sa)
        If d.ShowDialog = Windows.Forms.DialogResult.OK Then
            If d.ServicesEdited Then
                Database.Services.Save(d.AllServices, True)
            End If
            Worker_Bills.RunWorkerAsync()
        End If
    End Sub

    Private Sub btn_Edit_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btn_Edit.ItemClick
        If GridView_Data.SelectedRowsCount = 1 Then
            Dim r = CType(GridView_Data.GetRow(GridView_Data.GetSelectedRows(0)), PrintData)
            Dim d As New frm_Data(DialogMode.Edit, ServicesList, ReceiversList, SendersList, r)
            If d.ShowDialog = Windows.Forms.DialogResult.OK Then
                If d.ServicesEdited Then
                    Database.Services.Save(d.AllServices, True)
                End If
            End If
            Worker_Bills.RunWorkerAsync()
        End If
    End Sub

    Private Sub btn_Senders_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btn_Senders.ItemClick
        Dim d As New frm_Senders
        d.ShowDialog()
    End Sub

    Private Sub btn_Remove_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btn_Remove.ItemClick
        If GridView_Data.SelectedRowsCount > 0 Then
            For Each i As Integer In GridView_Data.GetSelectedRows
                Dim r = CType(GridView_Data.GetRow(i), PrintData)
                If Database.Entries.Delete(r.ID) > 0 Then
                    CType(Me.GridControl_Data.DataSource, List(Of PrintData)).Remove(r)
                Else
                    MsgBox("Error on deleting entries", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error")
                    Exit For
                End If
            Next
            GridControl_Data.RefreshDataSource()
        End If
    End Sub

    Private Sub btn_Receivers_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btn_Receivers.ItemClick
        Dim d As New frm_Receivers
        d.ShowDialog()
    End Sub

    Private Sub btn_Services_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btn_Services.ItemClick
        Dim n As New frm_Services
        n.ShowDialog()
    End Sub

    Private Sub btn_WaterMarkSettings_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btn_WaterMarkSettings.ItemClick
        frm_WaterMark.ShowDialog()
    End Sub

    Private Sub btn_OtherSettings_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btn_OtherSettings.ItemClick
        Dim d As New frm_OtherSettings
        d.ShowDialog()
    End Sub

    Private Sub btn_Print_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btn_Print.ItemClick
        If GridView_Data.SelectedRowsCount > 0 Then
            Dim items As New List(Of PrintData)
            For Each i As Integer In GridView_Data.GetSelectedRows
                Dim r = CType(GridView_Data.GetRow(i), PrintData)
                items.Add(r)
            Next
            PrintDocumentEx1.Items = items
            PrintDocumentEx1.PrintTaxDetails = My.Computer.Keyboard.CtrlKeyDown
            If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                PrintDocumentEx1.PrinterSettings = PrintDialog1.PrinterSettings
                PrintDocumentEx1.Print()
            End If
        End If
    End Sub

    Private Sub btn_PrintPreview_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btn_PrintPreview.ItemClick
        If GridView_Data.SelectedRowsCount = 1 Then
            Dim items As New List(Of PrintData)
            Dim r = CType(GridView_Data.GetRow(GridView_Data.GetSelectedRows(0)), PrintData)
            items.Add(r)
            PrintDocumentEx1.Items = items
            PrintDocumentEx1.PrintTaxDetails = My.Computer.Keyboard.CtrlKeyDown
            Dim d As New PrintPreviewDialogEx(Me)
            d.Document = PrintDocumentEx1
            d.ShowDialog()
        End If
    End Sub

    Private Sub btn_PDF_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btn_PDF.ItemClick
        If GridView_Data.SelectedRowsCount > 0 Then
            Dim PrintTax As Boolean = My.Computer.Keyboard.CtrlKeyDown
            If SavePDF.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim items As New List(Of PrintData)
                For Each i As Integer In GridView_Data.GetSelectedRows
                    Dim r = CType(GridView_Data.GetRow(i), PrintData)
                    items.Add(r)
                Next
                Dim d As New frm_Export(SavePDF.FileName, items, frm_Export.DocumentType.PDF, PrintTax)
                d.ShowDialog()
            End If
        End If
    End Sub
    
End Class