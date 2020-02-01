Public Class frm_Receiver
    Dim Mode As DialogMode
    Property Item As Receiver
    Dim ID As Integer = 0
    Sub New(ByVal Mode As DialogMode, Optional ByVal Item As Receiver = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Mode = Mode
        Me.Item = Item
    End Sub
    Private Sub frm_Receiver_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.cmb_State.SelectedIndex = cmb_State.Properties.Items.IndexOf("Tamil Nadu")
        Catch ex As Exception

        End Try
        If Mode = DialogMode.Edit Then
            Me.ID = Item.ID
            Me.txt_Name.Text = Item.Name
            Me.txt_Address.Text = Item.Address
            Me.txt_StateCode.Text = Item.StateCode
            Try
                Me.cmb_State.SelectedIndex = cmb_State.Properties.Items.IndexOf(Item.State)
            Catch ex As Exception

            End Try
            Me.txt_GSTIN.Text = Item.GSTIN
        End If

    End Sub

    Private Sub cmb_State_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_State.SelectedIndexChanged
        Try
            txt_StateCode.Text = (cmb_State.SelectedIndex + 1).ToString("00")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Cancel.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btn_Ok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Ok.Click
        If Mode = DialogMode.Add Then
            Me.Item = Database.Receivers.Create(txt_Name.Text, txt_Address.Text, cmb_State.SelectedItem.ToString, txt_StateCode.Text, txt_GSTIN.Text, False)
            If Item IsNot Nothing Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        Else
            Me.Item = Database.Receivers.Edit(ID, txt_Name.Text, txt_Address.Text, cmb_State.SelectedItem.ToString, txt_StateCode.Text, txt_GSTIN.Text, False)
            If Item IsNot Nothing Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        End If
    End Sub
End Class