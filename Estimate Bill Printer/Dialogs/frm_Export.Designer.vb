<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Export
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Export))
        Me.Progress = New DevExpress.XtraWaitForm.ProgressPanel()
        Me.WorkerPDF = New System.ComponentModel.BackgroundWorker()
        Me.WorkerDOC = New System.ComponentModel.BackgroundWorker()
        Me.SuspendLayout()
        '
        'Progress
        '
        Me.Progress.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.Progress.Appearance.Options.UseBackColor = True
        Me.Progress.BarAnimationElementThickness = 2
        Me.Progress.ContentAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.Progress.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Progress.Location = New System.Drawing.Point(0, 0)
        Me.Progress.Name = "Progress"
        Me.Progress.Size = New System.Drawing.Size(274, 50)
        Me.Progress.TabIndex = 0
        Me.Progress.Text = "ProgressPanel1"
        '
        'WorkerPDF
        '
        '
        'WorkerDOC
        '
        '
        'frm_Export
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(274, 50)
        Me.ControlBox = False
        Me.Controls.Add(Me.Progress)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_Export"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Export"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Progress As DevExpress.XtraWaitForm.ProgressPanel
    Friend WithEvents WorkerPDF As System.ComponentModel.BackgroundWorker
    Friend WithEvents WorkerDOC As System.ComponentModel.BackgroundWorker
End Class
