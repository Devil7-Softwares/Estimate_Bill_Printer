Public Class frm_WaterMark
    Dim PrintDetails As New PrintData(0, New Sender, "0001", Today, New Receiver, New List(Of Service))
    Sub DrawAll()
        Dim r As New Random
        PrintDetails.Sender.Address = "111, Test Street, Test Road, Test District - 111111"
        PrintDetails.EstimateDate = Today
        PrintDetails.Sender.GSTIN = "111111AER774477A"
        PrintDetails.Sender.Name = "Name Of Sender"
        PrintDetails.Receiver = New Receiver(0, "Name of Receiver", "222, Test Street, Test Road, Test District - 222222", "Test State", "33", "222222AER774477A")
        PrintDetails.SerialNumber = "9999"
        PrintDetails.Services = New List(Of Service)
        PrintDetails.Services.AddRange({New Service("Test Service 1 Just for Test :-)", r.Next(1000, 10000)), New Service("Test Service 2 Again Just for Test :-)", r.Next(1000, 10000))})

        Dim out As Bitmap = My.Resources.Empty
        Dim grp As Graphics = Graphics.FromImage(out)
        If sw_Image.IsOn Then
            Try
                Dim b As Bitmap = Image.FromFile(WatermarkImage)
                Dim o As Decimal = txt_Opacity_Image.Value / 100
                Dim outimg As Image = SetOpacity(b, o)
                grp.DrawImage(outimg, loc_X_Image.Value, loc_Y_Image.Value, size_Width_Image.Value, size_Height_Image.Value)
            Catch ex As Exception

            End Try
        End If
        grp.DrawString("Estimation for Services to be Rendered", Heading.Font, Brushes.Black, New Rectangle(0, 56, out.Size.Width, MeasureString(grp, Heading.Font).Height), Heading.StringFromat)
        grp.DrawRectangle(Pens.Black, New Rectangle(60, 90, out.Size.Width - (2 * 60), 800)) 'A
        grp.DrawRectangle(Pens.Black, New Rectangle(75, 105, out.Size.Width - (2 * 75), 110)) 'B
        grp.DrawLine(Pens.Black, New Point((75 + ((out.Size.Width - (2 * 75)) * 0.44)), 105), New Point((75 + ((out.Size.Width - (2 * 75)) * 0.44)), 215))
        grp.DrawString(PrintDetails.Sender.Name, Bold.Font, Brushes.Black, New Point(80, 110))
        grp.DrawString(PrintDetails.Sender.Address, Body.Font, Brushes.Black, New Rectangle(85, 135, 280, 50))
        If PrintDetails.HasGSTIN Then
            grp.DrawString("GSTIN : " & PrintDetails.Sender.GSTIN, Body.Font, Brushes.Black, New Point(85, 190))
        End If
        grp.DrawString("Serial No. : " & PrintDetails.SerialNumber & vbNewLine & vbNewLine & vbNewLine & "Date : " & PrintDetails.EstimateDate, Body.Font, Brushes.Black, New Point(380, 110))
        grp.DrawString("Details of Service Receiver : ", Bold.Font, Brushes.Black, New Point(80, 240))
        grp.DrawString(String.Format("{1}{0}{2}{0}{3}{0}{4}{0}GSTIN/Unique ID : {5}", vbNewLine, PrintDetails.Receiver.Name, PrintDetails.Receiver.Address, PrintDetails.Receiver.State, PrintDetails.Receiver.StateCode, PrintDetails.Receiver.GSTIN), Body.Font, Brushes.Black, 80, 260)
        grp.DrawRectangle(Pens.Black, New Rectangle(75, 380, out.Size.Width - (2 * 75), 300)) 'C

        grp.DrawRectangle(Pens.Black, New Rectangle(75, 380, 35, 190)) 'F
        grp.DrawString("Sr." & vbNewLine & "No.", Bold.Font, Brushes.Black, 78, 382)

        grp.DrawRectangle(Pens.Black, New Rectangle(75, 380, out.Size.Width - (2 * 75), 45)) 'G
        grp.DrawString("Description of Services to be Rendered", Bold.Font, Brushes.Black, New Rectangle(75 + 35, 380, out.Size.Width - (2 * 75) - 115 - 35, 45), New StringFormat With {.LineAlignment = StringAlignment.Far, .Alignment = StringAlignment.Center})

        grp.DrawRectangle(Pens.Black, New Rectangle(75 + out.Size.Width - (2 * 75) - 115, 380, 115, 190)) 'H
        grp.DrawString("Estimated Fees", Bold.Font, Brushes.Black, New Rectangle(75 + out.Size.Width - (2 * 75) - 115, 380, 115, 45), New StringFormat With {.LineAlignment = StringAlignment.Far, .Alignment = StringAlignment.Center})

        grp.DrawRectangle(Pens.Black, New Rectangle(75, 545, out.Size.Width - (2 * 75), 25)) 'I
        grp.DrawString("Total", Bold.Font, Brushes.Black, New Rectangle(110, 545, out.Size.Width - (2 * 75) - 115 - 35, 25), New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Near})

        grp.DrawRectangle(Pens.Black, New Rectangle(75, 570, out.Size.Width - (2 * 75), 60)) 'E
        grp.DrawString("Notes:" & vbNewLine & "Tax invoice raised after the above services are rendered would be liable to GST @ 18%", Body.Font, Brushes.Black, New Rectangle(75, 570, out.Size.Width - (2 * 75), 60))


        Dim MaxWidth As Integer = out.Size.Width - (2 * 75) - 115 - 35
        Dim CurrentY As Integer = 430
        Dim TotalAmount As Integer = 0
        For i As Integer = 0 To PrintDetails.Services.Count - 1
            Dim Service As Service = PrintDetails.Services(i)
            Dim Height As Integer = grp.MeasureString(Service.ServiceName, Body.Font, MaxWidth).Height + 5
            Dim SN As New Rectangle(75, CurrentY + 2, 35, Height)
            grp.DrawString(CStr(i + 1), Body.Font, Brushes.Black, SN, New StringFormat With {.LineAlignment = StringAlignment.Near, .Alignment = StringAlignment.Center})
            Dim Des As New Rectangle(110, CurrentY + 2, out.Size.Width - (2 * 75) - 115 - 35, Height)
            grp.DrawString(Service.ServiceName, Body.Font, Brushes.Black, Des, Body.StringFromat)
            Dim Fees As New Rectangle(75 + out.Size.Width - (2 * 75) - 115, CurrentY + 2, 115, Height)
            grp.DrawString(Service.Fees, Body.Font, Brushes.Black, Fees, Body.StringFromat)
            If i > 0 Then
                grp.DrawLine(Pens.Black, 75, CurrentY, out.Size.Width - (1 * 75), CurrentY)
            End If
            CurrentY += Height
            TotalAmount += CInt(Service.Fees)
        Next
        Dim TotalRect As New Rectangle(75 + out.Size.Width - (2 * 75) - 115, 545, 115, 25)
        grp.DrawString(TotalAmount, Body.Font, Brushes.Black, TotalRect)


        grp.DrawString("`. " & TotalAmount.ToString, New Font("Rupee Foradian", 12), Brushes.Black, 78, 633)
        grp.DrawString("Rupees " & AmountInWords(TotalAmount.ToString).Trim & " Only", Body.Font, Brushes.Black, 78, 655)
        grp.DrawRectangle(Pens.Black, New Rectangle(75, 630, out.Size.Width - (2 * 75), 50)) 'D

        grp.DrawString("Declaration :", Body.Font, Brushes.Black, New Rectangle(100, 700, 300, 190))
        grp.DrawString(String.Format("Signature{0}{0}{0}Name of the Signatory{0}{0}{0}Designation/Status", vbNewLine), Body.Font, Brushes.Black, New Rectangle(400, 700, 300, 190))
        If sw_Text.IsOn Then
            Try
                PrintWatermark(grp, txt_Angle_Text.Value, txt_WatermarkText.Text, New Font(font_Text.SelectedItem.ToString, txt_Size.Value), color_Text.Color, txt_Opacity_Text.Value, New Point(loc_X_Text.Value, loc_Y_Text.Value))
            Catch ex As Exception

            End Try
        End If
        grp.Dispose()
        PictureBox1.Image = out
    End Sub
    Function WatermarkImage() As String
        Return IO.Path.Combine(Application.StartupPath, My.Settings.WatermarkImagekey & ".wmg")
    End Function
    Private Sub btn_Browse_Image_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Browse_Image.Click
        If OpenImage.ShowDialog = Windows.Forms.DialogResult.OK Then
            My.Settings.WatermarkImagekey = "W" & (New Random).Next(100000, 999999)
            My.Settings.Save()
            My.Computer.FileSystem.CopyFile(OpenImage.FileName, WatermarkImage)
            DrawAll()
        End If
    End Sub

    Private Sub frm_WaterMark_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        My.Settings.Angle = txt_Angle_Text.Value
        Try
            My.Settings.Font = New Font(font_Text.SelectedItem.ToString, txt_Size.Value)
        Catch ex As Exception

        End Try
        My.Settings.ImageLocation = New Point(loc_X_Image.Value, loc_Y_Image.Value)
        My.Settings.ImageOpacity = txt_Opacity_Image.Value
        My.Settings.ImageSize = New Size(size_Width_Image.Value, size_Height_Image.Value)
        My.Settings.ImageWatermark = sw_Image.IsOn
        My.Settings.TextColor = color_Text.Color
        My.Settings.TextLocation = New Point(loc_X_Text.Value, loc_Y_Text.Value)
        My.Settings.TextOpacity = txt_Opacity_Text.Value
        My.Settings.TextWatermark = sw_Text.IsOn
        My.Settings.WaterMarkText = txt_WatermarkText.Text
        My.Settings.Save()
    End Sub

    Private Sub frm_WaterMark_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txt_Angle_Text.Value = My.Settings.Angle
        font_Text.SelectedItem = My.Settings.Font.FontFamily.Name
        txt_Size.Value = My.Settings.Font.Size
        loc_X_Image.Value = My.Settings.ImageLocation.X
        loc_Y_Image.Value = My.Settings.ImageLocation.Y
        txt_Opacity_Image.Value = My.Settings.ImageOpacity
        size_Width_Image.Value = My.Settings.ImageSize.Width
        size_Height_Image.Value = My.Settings.ImageSize.Height
        sw_Image.IsOn = My.Settings.ImageWatermark
        color_Text.Color = My.Settings.TextColor
        loc_X_Text.Value = My.Settings.TextLocation.X
        loc_Y_Text.Value = My.Settings.TextLocation.Y
        txt_Opacity_Text.Value = My.Settings.TextOpacity
        sw_Text.IsOn = My.Settings.TextWatermark

        txt_WatermarkText.Text = My.Settings.WaterMarkText
    End Sub

    Private Sub sw_Image_Toggled(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sw_Image.Toggled
        If sw_Image.IsOn Then
            Try
                DrawAll()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub sw_Text_Toggled(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sw_Text.Toggled
        If sw_Text.IsOn Then
            Try
                DrawAll()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub size_Width_Image_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles size_Width_Image.EditValueChanged
        Try
            DrawAll()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub size_Height_Image_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles size_Height_Image.EditValueChanged
        Try
            DrawAll()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub loc_X_Image_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles loc_X_Image.EditValueChanged
        Try
            DrawAll()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub loc_Y_Image_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles loc_Y_Image.EditValueChanged
        Try
            DrawAll()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_Opacity_Image_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Opacity_Image.EditValueChanged
        Try
            DrawAll()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_WatermarkText_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_WatermarkText.EditValueChanged
        Try
            DrawAll()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub font_Text_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles font_Text.SelectedIndexChanged
        Try
            DrawAll()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub loc_X_Text_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles loc_X_Text.EditValueChanged
        'Try
        DrawAll()
        ' Catch ex As Exception
        '
        '  End Try
    End Sub

    Private Sub loc_Y_Text_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles loc_Y_Text.EditValueChanged
        Try
            DrawAll()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_Angle_Text_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Angle_Text.EditValueChanged
        Try
            DrawAll()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txt_Opacity_Text_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_Opacity_Text.EditValueChanged
        Try
            DrawAll()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub color_Text_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles color_Text.EditValueChanged
        Try
            DrawAll()
        Catch ex As Exception

        End Try
    End Sub
End Class