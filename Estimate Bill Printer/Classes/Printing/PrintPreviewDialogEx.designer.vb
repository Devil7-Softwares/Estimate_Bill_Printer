<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrintPreviewDialogEx
    Inherits DevExpress.XtraBars.Ribbon.RibbonForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PrintPreviewDialogEx))
        Me.RibbonControl = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.btn_Close = New DevExpress.XtraBars.BarButtonItem()
        Me.tb_Zoom = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemZoomTrackBar1 = New DevExpress.XtraEditors.Repository.RepositoryItemZoomTrackBar()
        Me.btn_100Percent = New DevExpress.XtraBars.BarButtonItem()
        Me.btn_FullPage = New DevExpress.XtraBars.BarButtonItem()
        Me.btn_PageWidth = New DevExpress.XtraBars.BarButtonItem()
        Me.btn_TwoPages = New DevExpress.XtraBars.BarButtonItem()
        Me.btn_First = New DevExpress.XtraBars.BarButtonItem()
        Me.btn_Back = New DevExpress.XtraBars.BarButtonItem()
        Me.btn_Next = New DevExpress.XtraBars.BarButtonItem()
        Me.btn_Last = New DevExpress.XtraBars.BarButtonItem()
        Me.txt_Page = New DevExpress.XtraBars.BarEditItem()
        Me.RepositoryItemSpinEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.lbl_PageCount = New DevExpress.XtraBars.BarStaticItem()
        Me.RibbonPage_Preview = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup3 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup4 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup2 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonStatusBar = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me._preview = New PrintPreviewControlEx
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemZoomTrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonControl
        '
        Me.RibbonControl.ExpandCollapseItem.Id = 0
        Me.RibbonControl.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl.ExpandCollapseItem, Me.btn_Close, Me.tb_Zoom, Me.btn_100Percent, Me.btn_FullPage, Me.btn_PageWidth, Me.btn_TwoPages, Me.btn_First, Me.btn_Back, Me.btn_Next, Me.btn_Last, Me.txt_Page, Me.lbl_PageCount})
        Me.RibbonControl.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl.MaxItemId = 14
        Me.RibbonControl.Name = "RibbonControl"
        Me.RibbonControl.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage_Preview})
        Me.RibbonControl.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemZoomTrackBar1, Me.RepositoryItemSpinEdit1})
        Me.RibbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl.ShowToolbarCustomizeItem = False
        Me.RibbonControl.Size = New System.Drawing.Size(960, 143)
        Me.RibbonControl.StatusBar = Me.RibbonStatusBar
        Me.RibbonControl.Toolbar.ShowCustomizeItem = False
        '
        'btn_Close
        '
        Me.btn_Close.Caption = "Close"
        Me.btn_Close.Id = 1
        Me.btn_Close.ImageOptions.Image = Global.D7Automation.My.Resources.Resources.Logout
        Me.btn_Close.ImageOptions.LargeImage = Global.D7Automation.My.Resources.Resources.Logout
        Me.btn_Close.Name = "btn_Close"
        '
        'tb_Zoom
        '
        Me.tb_Zoom.Caption = "Custom Zoom :"
        Me.tb_Zoom.Edit = Me.RepositoryItemZoomTrackBar1
        Me.tb_Zoom.EditWidth = 200
        Me.tb_Zoom.Id = 3
        Me.tb_Zoom.Name = "tb_Zoom"
        '
        'RepositoryItemZoomTrackBar1
        '
        Me.RepositoryItemZoomTrackBar1.Maximum = 500
        Me.RepositoryItemZoomTrackBar1.Minimum = 1
        Me.RepositoryItemZoomTrackBar1.Name = "RepositoryItemZoomTrackBar1"
        Me.RepositoryItemZoomTrackBar1.ShowValueToolTip = True
        '
        'btn_100Percent
        '
        Me.btn_100Percent.Caption = "100%"
        Me.btn_100Percent.Id = 4
        Me.btn_100Percent.ImageOptions.Image = Global.D7Automation.My.Resources.Resources.zoom_original
        Me.btn_100Percent.ImageOptions.LargeImage = Global.D7Automation.My.Resources.Resources.zoom_original
        Me.btn_100Percent.Name = "btn_100Percent"
        '
        'btn_FullPage
        '
        Me.btn_FullPage.Caption = "Full Page"
        Me.btn_FullPage.Id = 5
        Me.btn_FullPage.ImageOptions.Image = Global.D7Automation.My.Resources.Resources.full_page
        Me.btn_FullPage.Name = "btn_FullPage"
        '
        'btn_PageWidth
        '
        Me.btn_PageWidth.Caption = "Page Width"
        Me.btn_PageWidth.Id = 6
        Me.btn_PageWidth.ImageOptions.Image = Global.D7Automation.My.Resources.Resources.full_page_w
        Me.btn_PageWidth.Name = "btn_PageWidth"
        '
        'btn_TwoPages
        '
        Me.btn_TwoPages.Caption = "Two Pages"
        Me.btn_TwoPages.Id = 7
        Me.btn_TwoPages.ImageOptions.Image = Global.D7Automation.My.Resources.Resources.zoom_2page
        Me.btn_TwoPages.Name = "btn_TwoPages"
        '
        'btn_First
        '
        Me.btn_First.Caption = "First"
        Me.btn_First.Id = 8
        Me.btn_First.ImageOptions.Image = Global.D7Automation.My.Resources.Resources.First
        Me.btn_First.ImageOptions.LargeImage = Global.D7Automation.My.Resources.Resources.First
        Me.btn_First.Name = "btn_First"
        '
        'btn_Back
        '
        Me.btn_Back.Caption = "Back"
        Me.btn_Back.Id = 9
        Me.btn_Back.ImageOptions.Image = Global.D7Automation.My.Resources.Resources.Back
        Me.btn_Back.ImageOptions.LargeImage = Global.D7Automation.My.Resources.Resources.Back
        Me.btn_Back.Name = "btn_Back"
        '
        'btn_Next
        '
        Me.btn_Next.Caption = "Next"
        Me.btn_Next.Id = 10
        Me.btn_Next.ImageOptions.Image = Global.D7Automation.My.Resources.Resources._next
        Me.btn_Next.ImageOptions.LargeImage = Global.D7Automation.My.Resources.Resources._next
        Me.btn_Next.Name = "btn_Next"
        '
        'btn_Last
        '
        Me.btn_Last.Caption = "Last"
        Me.btn_Last.Id = 11
        Me.btn_Last.ImageOptions.Image = Global.D7Automation.My.Resources.Resources.Last
        Me.btn_Last.ImageOptions.LargeImage = Global.D7Automation.My.Resources.Resources.Last
        Me.btn_Last.Name = "btn_Last"
        '
        'txt_Page
        '
        Me.txt_Page.Caption = "Page :"
        Me.txt_Page.Edit = Me.RepositoryItemSpinEdit1
        Me.txt_Page.EditValue = 1
        Me.txt_Page.Id = 12
        Me.txt_Page.Name = "txt_Page"
        '
        'RepositoryItemSpinEdit1
        '
        Me.RepositoryItemSpinEdit1.AutoHeight = False
        Me.RepositoryItemSpinEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemSpinEdit1.MaxValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.RepositoryItemSpinEdit1.MinValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.RepositoryItemSpinEdit1.Name = "RepositoryItemSpinEdit1"
        '
        'lbl_PageCount
        '
        Me.lbl_PageCount.Caption = "-"
        Me.lbl_PageCount.Id = 13
        Me.lbl_PageCount.Name = "lbl_PageCount"
        '
        'RibbonPage_Preview
        '
        Me.RibbonPage_Preview.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup3, Me.RibbonPageGroup4, Me.RibbonPageGroup2})
        Me.RibbonPage_Preview.Name = "RibbonPage_Preview"
        Me.RibbonPage_Preview.Text = "Preview Settings"
        '
        'RibbonPageGroup3
        '
        Me.RibbonPageGroup3.ItemLinks.Add(Me.tb_Zoom)
        Me.RibbonPageGroup3.ItemLinks.Add(Me.btn_100Percent)
        Me.RibbonPageGroup3.ItemLinks.Add(Me.btn_FullPage)
        Me.RibbonPageGroup3.ItemLinks.Add(Me.btn_PageWidth)
        Me.RibbonPageGroup3.ItemLinks.Add(Me.btn_TwoPages)
        Me.RibbonPageGroup3.Name = "RibbonPageGroup3"
        Me.RibbonPageGroup3.Text = "Zoom"
        '
        'RibbonPageGroup4
        '
        Me.RibbonPageGroup4.ItemLinks.Add(Me.btn_First)
        Me.RibbonPageGroup4.ItemLinks.Add(Me.btn_Back)
        Me.RibbonPageGroup4.ItemLinks.Add(Me.btn_Next)
        Me.RibbonPageGroup4.ItemLinks.Add(Me.btn_Last)
        Me.RibbonPageGroup4.ItemLinks.Add(Me.txt_Page)
        Me.RibbonPageGroup4.Name = "RibbonPageGroup4"
        Me.RibbonPageGroup4.Text = "Navigation"
        '
        'RibbonPageGroup2
        '
        Me.RibbonPageGroup2.ItemLinks.Add(Me.btn_Close)
        Me.RibbonPageGroup2.Name = "RibbonPageGroup2"
        '
        'RibbonStatusBar
        '
        Me.RibbonStatusBar.ItemLinks.Add(Me.lbl_PageCount)
        Me.RibbonStatusBar.Location = New System.Drawing.Point(0, 418)
        Me.RibbonStatusBar.Name = "RibbonStatusBar"
        Me.RibbonStatusBar.Ribbon = Me.RibbonControl
        Me.RibbonStatusBar.Size = New System.Drawing.Size(960, 31)
        '
        '_preview
        '
        Me._preview.Dock = System.Windows.Forms.DockStyle.Fill
        Me._preview.Document = Nothing
        Me._preview.Location = New System.Drawing.Point(0, 143)
        Me._preview.Margin = New System.Windows.Forms.Padding(2)
        Me._preview.Name = "_preview"
        Me._preview.Size = New System.Drawing.Size(960, 275)
        Me._preview.TabIndex = 4
        '
        'PrintPreviewDialogEx
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(960, 449)
        Me.Controls.Add(Me._preview)
        Me.Controls.Add(Me.RibbonStatusBar)
        Me.Controls.Add(Me.RibbonControl)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(800, 450)
        Me.Name = "PrintPreviewDialogEx"
        Me.Ribbon = Me.RibbonControl
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.StatusBar = Me.RibbonStatusBar
        Me.Text = "Preview"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemZoomTrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RibbonControl As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents RibbonPage_Preview As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonStatusBar As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Friend WithEvents btn_Close As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup2 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents _preview As PrintPreviewControlEx
    Friend WithEvents tb_Zoom As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemZoomTrackBar1 As DevExpress.XtraEditors.Repository.RepositoryItemZoomTrackBar
    Friend WithEvents btn_100Percent As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btn_FullPage As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btn_PageWidth As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btn_TwoPages As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup3 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents btn_First As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btn_Back As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btn_Next As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btn_Last As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup4 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents txt_Page As DevExpress.XtraBars.BarEditItem
    Friend WithEvents RepositoryItemSpinEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents lbl_PageCount As DevExpress.XtraBars.BarStaticItem


End Class
