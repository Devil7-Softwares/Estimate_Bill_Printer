<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_OtherSettings
    Inherits XtraFormTemp

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.sw_AutoWatermark = New DevExpress.XtraEditors.ToggleSwitch()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.txt_TaxDetailsFormat = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.txt_GSTPercentage = New DevExpress.XtraEditors.SpinEdit()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.txt_PrinterName = New DevExpress.XtraEditors.TextEdit()
        CType(Me.sw_AutoWatermark.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_TaxDetailsFormat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_GSTPercentage.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txt_PrinterName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(12, 12)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(199, 13)
        Me.LabelControl1.TabIndex = 0
        Me.LabelControl1.Text = "Change Watermark According to Person :"
        '
        'sw_AutoWatermark
        '
        Me.sw_AutoWatermark.Location = New System.Drawing.Point(217, 7)
        Me.sw_AutoWatermark.Name = "sw_AutoWatermark"
        Me.sw_AutoWatermark.Properties.OffText = "Off"
        Me.sw_AutoWatermark.Properties.OnText = "On"
        Me.sw_AutoWatermark.Size = New System.Drawing.Size(95, 24)
        Me.sw_AutoWatermark.TabIndex = 1
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(12, 40)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(97, 13)
        Me.LabelControl2.TabIndex = 2
        Me.LabelControl2.Text = "Tax Details Format :"
        '
        'txt_TaxDetailsFormat
        '
        Me.txt_TaxDetailsFormat.Location = New System.Drawing.Point(115, 37)
        Me.txt_TaxDetailsFormat.Name = "txt_TaxDetailsFormat"
        Me.txt_TaxDetailsFormat.Size = New System.Drawing.Size(197, 20)
        Me.txt_TaxDetailsFormat.TabIndex = 3
        '
        'LabelControl3
        '
        Me.LabelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl3.Location = New System.Drawing.Point(115, 63)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(178, 113)
        Me.LabelControl3.TabIndex = 4
        Me.LabelControl3.Text = "{0} - Tab" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "{1} - Newline" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "{2} - Total Amount" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "{3} - GST Tax Amount Full" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "{4} - GS" & _
    "T Tax Amount Half" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "{5} - Rupees Symbol" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "{6} - GST Tax Percentage Full" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "{7} - GST" & _
    " Tax Percentage Half"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(25, 185)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(84, 13)
        Me.LabelControl4.TabIndex = 5
        Me.LabelControl4.Text = "GST Percentage :"
        '
        'txt_GSTPercentage
        '
        Me.txt_GSTPercentage.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.txt_GSTPercentage.Location = New System.Drawing.Point(115, 182)
        Me.txt_GSTPercentage.Name = "txt_GSTPercentage"
        Me.txt_GSTPercentage.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txt_GSTPercentage.Size = New System.Drawing.Size(197, 20)
        Me.txt_GSTPercentage.TabIndex = 6
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(19, 216)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(90, 13)
        Me.LabelControl5.TabIndex = 7
        Me.LabelControl5.Text = "XPS Printer Name :"
        '
        'txt_PrinterName
        '
        Me.txt_PrinterName.Location = New System.Drawing.Point(115, 213)
        Me.txt_PrinterName.Name = "txt_PrinterName"
        Me.txt_PrinterName.Size = New System.Drawing.Size(197, 20)
        Me.txt_PrinterName.TabIndex = 8
        '
        'frm_OtherSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(322, 245)
        Me.Controls.Add(Me.txt_PrinterName)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.txt_GSTPercentage)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.txt_TaxDetailsFormat)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.sw_AutoWatermark)
        Me.Controls.Add(Me.LabelControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frm_OtherSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Other Settings"
        CType(Me.sw_AutoWatermark.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_TaxDetailsFormat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_GSTPercentage.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txt_PrinterName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents sw_AutoWatermark As DevExpress.XtraEditors.ToggleSwitch
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txt_TaxDetailsFormat As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txt_GSTPercentage As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txt_PrinterName As DevExpress.XtraEditors.TextEdit
End Class
