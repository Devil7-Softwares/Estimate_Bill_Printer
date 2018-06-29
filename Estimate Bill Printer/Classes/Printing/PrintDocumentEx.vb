Public Class PrintDocumentEx
    Inherits Printing.PrintDocument
    Property Items As List(Of PrintData) = Nothing
    Property PrintTaxDetails As Boolean = False
    Private Sub PrintDocumentEx_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles Me.PrintPage
        Dim item = Items(0)
        If My.Settings.TextWatermark = True Then
            Dim out As Bitmap = My.Resources.Empty
            Dim grp As Graphics = Graphics.FromImage(out)
            If My.Settings.AutoWatermark Then
                Try
                    PrintWatermark(grp, item.Sender.WatermarkAngle, item.Sender.WatermarkText, New Font(item.Sender.WatermarkFontName, item.Sender.WatermarkFontSize), item.Sender.WatermarkColor, item.Sender.WatermarkOpacity, item.Sender.Location)
                Catch ex As Exception

                End Try
            Else
                Try
                    PrintWatermark(grp, My.Settings.Angle, My.Settings.WaterMarkText, My.Settings.Font, My.Settings.TextColor, My.Settings.TextOpacity, My.Settings.TextLocation)
                Catch ex As Exception

                End Try
            End If
            grp.Dispose()
            e.Graphics.DrawImage(out, e.PageBounds)
        End If
        If My.Settings.ImageWatermark = True Then
            Try
                If My.Computer.FileSystem.FileExists(My.Settings.WatermarkImage) Then
                    Dim b As Bitmap = Image.FromFile(My.Settings.WatermarkImage)
                    Dim o As Decimal = My.Settings.ImageOpacity / 100
                    Dim outimg As Image = SetOpacity(b, o)
                    e.Graphics.DrawImage(outimg, New Rectangle(My.Settings.ImageLocation, My.Settings.ImageSize))
                End If
            Catch ex As Exception

            End Try
        End If
        e.Graphics.DrawString(item.Sender.Heading, Heading.Font, Brushes.Black, New Rectangle(0, 56, e.PageBounds.Width, MeasureString(e.Graphics, Heading.Font).Height), Heading.StringFromat)
        e.Graphics.DrawRectangle(Pens.Black, New Rectangle(60, 90, e.PageBounds.Width - (2 * 60), 800)) 'A
        e.Graphics.DrawRectangle(Pens.Black, New Rectangle(75, 105, e.PageBounds.Width - (2 * 75), 110)) 'B
        e.Graphics.DrawLine(Pens.Black, New Point((75 + ((e.PageBounds.Width - (2 * 75)) * 0.44)), 105), New Point((75 + ((e.PageBounds.Width - (2 * 75)) * 0.44)), 215))
        e.Graphics.DrawString(item.Sender.Name, Bold.Font, Brushes.Black, New Point(80, 110))
        e.Graphics.DrawString(item.Sender.Address, Body.Font, Brushes.Black, New Rectangle(85, 135, 280, 50))
        If item.HasGSTIN Then
            e.Graphics.DrawString("GSTIN : " & item.Sender.GSTIN, Body.Font, Brushes.Black, New Point(85, 190))
        End If
        e.Graphics.DrawString("Serial No. : " & item.SerialNumber & vbNewLine & vbNewLine & vbNewLine & "Date : " & item.EstimateDate.ToString("dd-MM-yyyy"), Body.Font, Brushes.Black, New Point(380, 110))
        e.Graphics.DrawString("Details of Service Receiver : ", Bold.Font, Brushes.Black, New Point(80, 240))
        e.Graphics.DrawString(String.Format("{1}{0}{2}{0}{3}{0}{4}{0}GSTIN/Unique ID : {5}", vbNewLine, item.Receiver.Name, item.Receiver.Address, item.Receiver.State, item.Receiver.StateCode, item.Receiver.GSTIN), Body.Font, Brushes.Black, 80, 260)
        e.Graphics.DrawRectangle(Pens.Black, New Rectangle(75, 380, e.PageBounds.Width - (2 * 75), 300)) 'C

        e.Graphics.DrawRectangle(Pens.Black, New Rectangle(75, 380, 35, 240)) 'F
        e.Graphics.DrawString("Sr." & vbNewLine & "No.", Bold.Font, Brushes.Black, 78, 382)

        e.Graphics.DrawRectangle(Pens.Black, New Rectangle(75, 380, e.PageBounds.Width - (2 * 75), 45)) 'G
        e.Graphics.DrawString("Description of Services", Bold.Font, Brushes.Black, New Rectangle(75 + 35, 380, e.PageBounds.Width - (2 * 75) - 115 - 35, 45), New StringFormat With {.LineAlignment = StringAlignment.Far, .Alignment = StringAlignment.Center})

        e.Graphics.DrawRectangle(Pens.Black, New Rectangle(75 + e.PageBounds.Width - (2 * 75) - 115, 380, 115, 240)) 'H
        e.Graphics.DrawString("Fees", Bold.Font, Brushes.Black, New Rectangle(75 + e.PageBounds.Width - (2 * 75) - 115, 380, 115, 45), New StringFormat With {.LineAlignment = StringAlignment.Far, .Alignment = StringAlignment.Center})

        e.Graphics.DrawRectangle(Pens.Black, New Rectangle(75, 595, e.PageBounds.Width - (2 * 75), 25)) 'I
        e.Graphics.DrawString("Total", Bold.Font, Brushes.Black, New Rectangle(110, 595, e.PageBounds.Width - (2 * 75) - 115 - 35, 25), New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Near})

        e.Graphics.DrawRectangle(Pens.Black, New Rectangle(75, 620, e.PageBounds.Width - (2 * 75), 60)) 'E
        If item.HasGSTIN Then
            e.Graphics.DrawString("Notes:" & vbNewLine & "Tax invoice raised after the above services are rendered would be liable to GST @ " & My.Settings.GSTPercentage & "%", Body.Font, Brushes.Black, New Rectangle(75, 620, e.PageBounds.Width - (2 * 75), 60))
        End If

        Dim MaxWidth As Integer = e.PageBounds.Width - (2 * 75) - 115 - 35
        Dim CurrentY As Integer = 430
        Dim TotalAmount As Integer = 0
        For i As Integer = 0 To item.Services.Count - 1
            Dim Service As Service = item.Services(i)
            Dim Height As Integer = e.Graphics.MeasureString(Service.ServiceName, Body.Font, MaxWidth).Height + 5
            Dim SN As New Rectangle(75, CurrentY + 2, 35, Height)
            e.Graphics.DrawString(CStr(i + 1), Body.Font, Brushes.Black, SN, New StringFormat With {.LineAlignment = StringAlignment.Near, .Alignment = StringAlignment.Center})
            Dim Des As New Rectangle(110, CurrentY + 2, e.PageBounds.Width - (2 * 75) - 115 - 35, Height)
            e.Graphics.DrawString(Service.ServiceName, Body.Font, Brushes.Black, Des, Body.StringFromat)
            Dim Fees As New Rectangle(75 + e.PageBounds.Width - (2 * 75) - 115, CurrentY + 2, 115, Height)
            e.Graphics.DrawString(Service.Fees, Body.Font, Brushes.Black, Fees, Body.StringFromat)
            If i > 0 Then
                e.Graphics.DrawLine(Pens.Black, 75, CurrentY, e.PageBounds.Width - (1 * 75), CurrentY)
            End If
            CurrentY += Height
            TotalAmount += CInt(Service.Fees)
        Next
        Dim TotalRect As New Rectangle(75 + e.PageBounds.Width - (2 * 75) - 115, 595, 115, 25)
        e.Graphics.DrawString(TotalAmount, Body.Font, Brushes.Black, TotalRect)


        e.Graphics.DrawString("`. " & TotalAmount.ToString, New Font("Rupee Foradian", 12), Brushes.Black, 78, 683)
        e.Graphics.DrawString("Rupees " & AmountInWords(TotalAmount.ToString).Trim & " Only", Body.Font, Brushes.Black, 78, 705)
        e.Graphics.DrawRectangle(Pens.Black, New Rectangle(75, 680, e.PageBounds.Width - (2 * 75), 50)) 'D
        If Me.PrintTaxDetails Then
            If item.HasGSTIN Then
                Dim f As New Font("Rupee Foradian", 12)
                Dim tax As Integer = (TotalAmount * (My.Settings.GSTPercentage / 100))
                Dim s As String = String.Format(My.Settings.TaxDetails, vbTab, vbNewLine, TotalAmount, tax, (TotalAmount * ((My.Settings.GSTPercentage / 2) / 100)), "`")
                Dim si As Size = e.Graphics.MeasureString(s, f).ToSize
                si.Width += 50
                Dim rect As New Rectangle(New Point(60, 900), si)
                Dim total As String = "     Total            : `. " & TotalAmount + tax
                Dim TRECT As New Rectangle(60, 900 + si.Height, si.Width, e.Graphics.MeasureString(total, f).Height)
                e.Graphics.DrawRectangle(Pens.Black, rect)
                e.Graphics.DrawString(s, f, Brushes.Black, rect)
                e.Graphics.DrawRectangle(Pens.Black, TRECT)
                e.Graphics.DrawString(total, f, Brushes.Black, TRECT)
            End If
        End If
        e.Graphics.DrawString("Declaration :", Body.Font, Brushes.Black, New Rectangle(100, 750, 300, 190))
        e.Graphics.DrawString("Signature", Body.Font, Brushes.Black, New Rectangle(400, 750, 300, 190))
        Items.RemoveAt(0)
        If Items.Count = 0 Then
            e.HasMorePages = False
        Else
            e.HasMorePages = True
        End If
    End Sub
End Class
