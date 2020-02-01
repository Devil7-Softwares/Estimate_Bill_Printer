Public Class frm_Export
    Dim items As List(Of PrintData)
    Dim DocType As DocumentType
    Dim FileName As String
    Dim PrintTax As Boolean = False

    Sub New(ByVal FileName As String, ByVal Items As List(Of PrintData), ByVal DocumentType As DocumentType, ByVal PrintTax As Boolean)
        InitializeComponent()
        Me.items = Items
        Me.DocType = DocumentType
        Me.FileName = FileName
        Me.PrintTax = PrintTax
    End Sub

    Sub UpdateStatus(ByVal Text As String)
        Me.Invoke(Sub()
                      Me.Progress.Description = Text
                  End Sub)
    End Sub

    Private Sub WorkerPDF_DoWork(sender As System.Object, e As System.ComponentModel.DoWorkEventArgs) Handles WorkerPDF.DoWork
        Try
            Using Printer As New PrintDocumentEx
                UpdateStatus("Preparing Printer...")
                Dim XPSPath As String = My.Computer.FileSystem.GetTempFileName
                Printer.Items = items
                Printer.PrintTaxDetails = PrintTax
                With Printer
                    .PrinterSettings.PrinterName = My.Settings.XPSPrinter
                    If My.Computer.FileSystem.FileExists(XPSPath) Then My.Computer.FileSystem.DeleteFile(XPSPath)
                    .DefaultPageSettings.PrinterSettings.PrintToFile = True
                    .DefaultPageSettings.PrinterSettings.PrintFileName = XPSPath
                    UpdateStatus("Printing Temporary XPS File...")
                    .Print()
                End With
                If My.Computer.FileSystem.FileExists(XPSPath) Then
                    UpdateStatus("Converting XPS to PDF...")
                    Using pdfXpsDoc As PdfSharp.Xps.XpsModel.XpsDocument = PdfSharp.Xps.XpsModel.XpsDocument.Open(XPSPath)
                        PdfSharp.Xps.XpsConverter.Convert(pdfXpsDoc, FileName, 0)
                    End Using
                    If MsgBox("File Successfully Exported. Do you want to open the file...?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Done") = MsgBoxResult.Yes Then
                        Try
                            Process.Start(FileName)
                        Catch ex As Exception

                        End Try
                    End If
                End If
            End Using
        Catch ex As Exception
            MsgBox("Error while exporting PDF." & vbNewLine & vbNewLine & "Additional Information:" & vbNewLine & vbNewLine & ex.Message & vbNewLine & ex.StackTrace, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly, "Error")
        End Try
    End Sub

    Enum DocumentType As Integer
        PDF = 0
    End Enum

    Private Sub frm_Export_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Text = If(DocType = DocumentType.PDF, "Export PDF", "Export")
    End Sub

    Private Sub frm_Export_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown
        If DocType = DocumentType.PDF Then
            WorkerPDF.RunWorkerAsync()
        End If
    End Sub

    Private Sub Worker_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles WorkerDOC.RunWorkerCompleted, WorkerPDF.RunWorkerCompleted
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
End Class