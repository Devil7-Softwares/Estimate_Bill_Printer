<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Senders
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Senders))
        Me.GridControl_Senders = New DevExpress.XtraGrid.GridControl()
        Me.GridView_Senders = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.btn_Remove = New DevExpress.XtraEditors.SimpleButton()
        Me.brn_Edit = New DevExpress.XtraEditors.SimpleButton()
        Me.brn_Add = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.GridControl_Senders, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView_Senders, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GridControl_Senders
        '
        Me.GridControl_Senders.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl_Senders.Location = New System.Drawing.Point(0, 32)
        Me.GridControl_Senders.MainView = Me.GridView_Senders
        Me.GridControl_Senders.Name = "GridControl_Senders"
        Me.GridControl_Senders.Size = New System.Drawing.Size(514, 319)
        Me.GridControl_Senders.TabIndex = 0
        Me.GridControl_Senders.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView_Senders})
        '
        'GridView_Senders
        '
        Me.GridView_Senders.GridControl = Me.GridControl_Senders
        Me.GridView_Senders.Name = "GridView_Senders"
        Me.GridView_Senders.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView_Senders.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView_Senders.OptionsBehavior.Editable = False
        Me.GridView_Senders.OptionsSelection.MultiSelect = True
        Me.GridView_Senders.OptionsView.ShowGroupPanel = False
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.btn_Remove)
        Me.PanelControl1.Controls.Add(Me.brn_Edit)
        Me.PanelControl1.Controls.Add(Me.brn_Add)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(514, 32)
        Me.PanelControl1.TabIndex = 1
        '
        'btn_Remove
        '
        Me.btn_Remove.Dock = System.Windows.Forms.DockStyle.Left
        Me.btn_Remove.Location = New System.Drawing.Point(152, 2)
        Me.btn_Remove.Name = "btn_Remove"
        Me.btn_Remove.Size = New System.Drawing.Size(75, 28)
        Me.btn_Remove.TabIndex = 2
        Me.btn_Remove.Text = "Remove"
        '
        'brn_Edit
        '
        Me.brn_Edit.Dock = System.Windows.Forms.DockStyle.Left
        Me.brn_Edit.Location = New System.Drawing.Point(77, 2)
        Me.brn_Edit.Name = "brn_Edit"
        Me.brn_Edit.Size = New System.Drawing.Size(75, 28)
        Me.brn_Edit.TabIndex = 1
        Me.brn_Edit.Text = "Edit"
        '
        'brn_Add
        '
        Me.brn_Add.Dock = System.Windows.Forms.DockStyle.Left
        Me.brn_Add.Location = New System.Drawing.Point(2, 2)
        Me.brn_Add.Name = "brn_Add"
        Me.brn_Add.Size = New System.Drawing.Size(75, 28)
        Me.brn_Add.TabIndex = 0
        Me.brn_Add.Text = "Add"
        '
        'frm_Senders
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(514, 351)
        Me.Controls.Add(Me.GridControl_Senders)
        Me.Controls.Add(Me.PanelControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.Name = "frm_Senders"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Senders"
        CType(Me.GridControl_Senders, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView_Senders, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GridControl_Senders As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView_Senders As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents btn_Remove As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents brn_Edit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents brn_Add As DevExpress.XtraEditors.SimpleButton
End Class
