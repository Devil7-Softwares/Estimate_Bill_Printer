Public Class frm_Sender
    Sub New(ByVal mode As DialogMode, Optional ByVal item As Sender = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.mode = mode
        Me.Item = item
    End Sub
    Dim mode As DialogMode
    Private Sub btn_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Property Item As Sender
    Dim ID As Integer = 0
    Private Sub btn_OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_OK.Click
        If mode = DialogMode.Add Then
            Me.Item = Database.Senders.Create(txt_Name.Text, txt_Address.Text, txt_GSTIN.Text, txt_WatermarkText.Text, txt_Angle_Text.Value, font_Text.SelectedItem.ToString, txt_Size.Value, color_Text.Color, txt_Opacity_Text.Value, txt_Heading.Text, New Point(loc_X_Text.Value, loc_Y_Text.Value), False)
            If Me.Item IsNot Nothing Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        Else
            Me.Item = Database.Senders.Edit(ID, txt_Name.Text, txt_Address.Text, txt_GSTIN.Text, txt_WatermarkText.Text, txt_Angle_Text.Value, font_Text.SelectedItem.ToString, txt_Size.Value, color_Text.Color, txt_Opacity_Text.Value, txt_Heading.Text, New Point(loc_X_Text.Value, loc_Y_Text.Value), False)
            If Me.Item IsNot Nothing Then
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        End If
    End Sub

    Private Sub frm_Sender_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Me.mode = DialogMode.Edit Then
                ID = Item.ID
                Me.txt_Address.Text = Item.Address
                Me.txt_Angle_Text.Value = Item.WatermarkAngle
                Me.txt_GSTIN.Text = Item.GSTIN
                Me.txt_Name.Text = Item.Name
                Me.txt_Opacity_Text.Value = Item.WatermarkOpacity
                Me.txt_Size.Value = Item.WatermarkFontSize
                color_Text.Color = Item.WatermarkColor
                Me.font_Text.SelectedItem = Item.WatermarkFontName
                loc_X_Text.Value = Item.Location.X
                loc_Y_Text.Value = Item.Location.Y
                txt_WatermarkText.Text = Item.WatermarkText
                txt_Heading.Text = Item.Heading
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class