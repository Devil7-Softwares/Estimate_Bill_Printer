<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Main
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Main))
        Me.RibbonControl = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.btn_Add = New DevExpress.XtraBars.BarButtonItem()
        Me.btn_Remove = New DevExpress.XtraBars.BarButtonItem()
        Me.btn_Edit = New DevExpress.XtraBars.BarButtonItem()
        Me.btn_Print = New DevExpress.XtraBars.BarButtonItem()
        Me.btn_PrintPreview = New DevExpress.XtraBars.BarButtonItem()
        Me.btn_Senders = New DevExpress.XtraBars.BarButtonItem()
        Me.btn_Receivers = New DevExpress.XtraBars.BarButtonItem()
        Me.btn_WaterMarkSettings = New DevExpress.XtraBars.BarButtonItem()
        Me.SkinRibbonGalleryBarItem1 = New DevExpress.XtraBars.SkinRibbonGalleryBarItem()
        Me.btn_OtherSettings = New DevExpress.XtraBars.BarButtonItem()
        Me.btn_Services = New DevExpress.XtraBars.BarButtonItem()
        Me.btn_ServerSettings = New DevExpress.XtraBars.BarButtonItem()
        Me.btn_Refresh = New DevExpress.XtraBars.BarButtonItem()
        Me.rp_Home = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup_Items = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup_Printing = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPage_Settings = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup2 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonStatusBar = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.GridControl_Data = New DevExpress.XtraGrid.GridControl()
        Me.GridView_Data = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.Theme = New DevExpress.LookAndFeel.DefaultLookAndFeel(Me.components)
        Me.ProgressPanel_Bills = New DevExpress.XtraWaitForm.ProgressPanel()
        Me.Worker_Bills = New System.ComponentModel.BackgroundWorker()
        Me.PrintDocumentEx1 = New D7Automation.PrintDocumentEx()
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl_Data, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView_Data, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonControl
        '
        Me.RibbonControl.ExpandCollapseItem.Id = 0
        Me.RibbonControl.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl.ExpandCollapseItem, Me.btn_Add, Me.btn_Remove, Me.btn_Edit, Me.btn_Print, Me.btn_PrintPreview, Me.btn_Senders, Me.btn_Receivers, Me.btn_WaterMarkSettings, Me.SkinRibbonGalleryBarItem1, Me.btn_OtherSettings, Me.btn_Services, Me.btn_ServerSettings, Me.btn_Refresh})
        Me.RibbonControl.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl.MaxItemId = 14
        Me.RibbonControl.Name = "RibbonControl"
        Me.RibbonControl.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.rp_Home, Me.RibbonPage_Settings})
        Me.RibbonControl.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl.ShowToolbarCustomizeItem = False
        Me.RibbonControl.Size = New System.Drawing.Size(521, 143)
        Me.RibbonControl.StatusBar = Me.RibbonStatusBar
        Me.RibbonControl.Toolbar.ShowCustomizeItem = False
        '
        'btn_Add
        '
        Me.btn_Add.Caption = "Add"
        Me.btn_Add.Id = 1
        Me.btn_Add.ImageOptions.Image = Global.D7Automation.My.Resources.Resources.Contacts_Add
        Me.btn_Add.ImageOptions.LargeImage = Global.D7Automation.My.Resources.Resources.Contacts_Add
        Me.btn_Add.Name = "btn_Add"
        '
        'btn_Remove
        '
        Me.btn_Remove.Caption = "Remove"
        Me.btn_Remove.Id = 2
        Me.btn_Remove.ImageOptions.Image = Global.D7Automation.My.Resources.Resources.Contacts_Remove
        Me.btn_Remove.ImageOptions.LargeImage = Global.D7Automation.My.Resources.Resources.Contacts_Remove
        Me.btn_Remove.Name = "btn_Remove"
        '
        'btn_Edit
        '
        Me.btn_Edit.Caption = "Edit"
        Me.btn_Edit.Id = 3
        Me.btn_Edit.ImageOptions.Image = Global.D7Automation.My.Resources.Resources.Contacts_edit
        Me.btn_Edit.ImageOptions.LargeImage = Global.D7Automation.My.Resources.Resources.Contacts_edit
        Me.btn_Edit.Name = "btn_Edit"
        '
        'btn_Print
        '
        Me.btn_Print.Caption = "Print"
        Me.btn_Print.Id = 4
        Me.btn_Print.ImageOptions.Image = Global.D7Automation.My.Resources.Resources.Print
        Me.btn_Print.ImageOptions.LargeImage = Global.D7Automation.My.Resources.Resources.Print
        Me.btn_Print.Name = "btn_Print"
        '
        'btn_PrintPreview
        '
        Me.btn_PrintPreview.Caption = "Print Preview"
        Me.btn_PrintPreview.Id = 5
        Me.btn_PrintPreview.ImageOptions.Image = Global.D7Automation.My.Resources.Resources.report
        Me.btn_PrintPreview.ImageOptions.LargeImage = Global.D7Automation.My.Resources.Resources.report
        Me.btn_PrintPreview.Name = "btn_PrintPreview"
        '
        'btn_Senders
        '
        Me.btn_Senders.Caption = "Senders"
        Me.btn_Senders.Id = 6
        Me.btn_Senders.ImageOptions.Image = Global.D7Automation.My.Resources.Resources.man
        Me.btn_Senders.ImageOptions.LargeImage = Global.D7Automation.My.Resources.Resources.man
        Me.btn_Senders.Name = "btn_Senders"
        '
        'btn_Receivers
        '
        Me.btn_Receivers.Caption = "Receivers"
        Me.btn_Receivers.Id = 7
        Me.btn_Receivers.ImageOptions.Image = Global.D7Automation.My.Resources.Resources.contact
        Me.btn_Receivers.ImageOptions.LargeImage = Global.D7Automation.My.Resources.Resources.contact
        Me.btn_Receivers.Name = "btn_Receivers"
        '
        'btn_WaterMarkSettings
        '
        Me.btn_WaterMarkSettings.Caption = "Watermark Settings"
        Me.btn_WaterMarkSettings.Id = 8
        Me.btn_WaterMarkSettings.ImageOptions.Image = Global.D7Automation.My.Resources.Resources.watermark
        Me.btn_WaterMarkSettings.ImageOptions.LargeImage = Global.D7Automation.My.Resources.Resources.watermark
        Me.btn_WaterMarkSettings.Name = "btn_WaterMarkSettings"
        '
        'SkinRibbonGalleryBarItem1
        '
        Me.SkinRibbonGalleryBarItem1.Caption = "SkinRibbonGalleryBarItem1"
        Me.SkinRibbonGalleryBarItem1.Id = 9
        Me.SkinRibbonGalleryBarItem1.Name = "SkinRibbonGalleryBarItem1"
        '
        'btn_OtherSettings
        '
        Me.btn_OtherSettings.Caption = "Other Settings"
        Me.btn_OtherSettings.Id = 10
        Me.btn_OtherSettings.ImageOptions.Image = Global.D7Automation.My.Resources.Resources.settings
        Me.btn_OtherSettings.ImageOptions.LargeImage = Global.D7Automation.My.Resources.Resources.settings
        Me.btn_OtherSettings.Name = "btn_OtherSettings"
        '
        'btn_Services
        '
        Me.btn_Services.Caption = "Services"
        Me.btn_Services.Id = 11
        Me.btn_Services.ImageOptions.Image = Global.D7Automation.My.Resources.Resources.services
        Me.btn_Services.ImageOptions.LargeImage = Global.D7Automation.My.Resources.Resources.services
        Me.btn_Services.Name = "btn_Services"
        '
        'btn_ServerSettings
        '
        Me.btn_ServerSettings.Caption = "Server Settings"
        Me.btn_ServerSettings.Id = 12
        Me.btn_ServerSettings.ImageOptions.Image = Global.D7Automation.My.Resources.Resources.server
        Me.btn_ServerSettings.ImageOptions.LargeImage = Global.D7Automation.My.Resources.Resources.server
        Me.btn_ServerSettings.Name = "btn_ServerSettings"
        '
        'btn_Refresh
        '
        Me.btn_Refresh.Caption = "Refresh"
        Me.btn_Refresh.Id = 13
        Me.btn_Refresh.ImageOptions.Image = Global.D7Automation.My.Resources.Resources.refresh
        Me.btn_Refresh.ImageOptions.LargeImage = Global.D7Automation.My.Resources.Resources.refresh
        Me.btn_Refresh.Name = "btn_Refresh"
        '
        'rp_Home
        '
        Me.rp_Home.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup_Items, Me.RibbonPageGroup_Printing})
        Me.rp_Home.Name = "rp_Home"
        Me.rp_Home.Text = "Home"
        '
        'RibbonPageGroup_Items
        '
        Me.RibbonPageGroup_Items.ItemLinks.Add(Me.btn_Refresh)
        Me.RibbonPageGroup_Items.ItemLinks.Add(Me.btn_Add, True)
        Me.RibbonPageGroup_Items.ItemLinks.Add(Me.btn_Edit)
        Me.RibbonPageGroup_Items.ItemLinks.Add(Me.btn_Remove)
        Me.RibbonPageGroup_Items.Name = "RibbonPageGroup_Items"
        Me.RibbonPageGroup_Items.Text = "Items"
        '
        'RibbonPageGroup_Printing
        '
        Me.RibbonPageGroup_Printing.ItemLinks.Add(Me.btn_Print)
        Me.RibbonPageGroup_Printing.ItemLinks.Add(Me.btn_PrintPreview)
        Me.RibbonPageGroup_Printing.Name = "RibbonPageGroup_Printing"
        Me.RibbonPageGroup_Printing.Text = "Printing"
        '
        'RibbonPage_Settings
        '
        Me.RibbonPage_Settings.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup1, Me.RibbonPageGroup2})
        Me.RibbonPage_Settings.Name = "RibbonPage_Settings"
        Me.RibbonPage_Settings.Text = "Settings"
        '
        'RibbonPageGroup1
        '
        Me.RibbonPageGroup1.ItemLinks.Add(Me.btn_Senders)
        Me.RibbonPageGroup1.ItemLinks.Add(Me.btn_Receivers)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        Me.RibbonPageGroup1.Text = "Persons"
        '
        'RibbonPageGroup2
        '
        Me.RibbonPageGroup2.ItemLinks.Add(Me.btn_Services)
        Me.RibbonPageGroup2.ItemLinks.Add(Me.btn_WaterMarkSettings)
        Me.RibbonPageGroup2.ItemLinks.Add(Me.btn_ServerSettings)
        Me.RibbonPageGroup2.ItemLinks.Add(Me.btn_OtherSettings)
        Me.RibbonPageGroup2.ItemLinks.Add(Me.SkinRibbonGalleryBarItem1)
        Me.RibbonPageGroup2.Name = "RibbonPageGroup2"
        Me.RibbonPageGroup2.Text = "Others"
        '
        'RibbonStatusBar
        '
        Me.RibbonStatusBar.Location = New System.Drawing.Point(0, 418)
        Me.RibbonStatusBar.Name = "RibbonStatusBar"
        Me.RibbonStatusBar.Ribbon = Me.RibbonControl
        Me.RibbonStatusBar.Size = New System.Drawing.Size(521, 31)
        '
        'GridControl_Data
        '
        Me.GridControl_Data.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl_Data.Location = New System.Drawing.Point(0, 143)
        Me.GridControl_Data.MainView = Me.GridView_Data
        Me.GridControl_Data.MenuManager = Me.RibbonControl
        Me.GridControl_Data.Name = "GridControl_Data"
        Me.GridControl_Data.Size = New System.Drawing.Size(521, 275)
        Me.GridControl_Data.TabIndex = 2
        Me.GridControl_Data.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView_Data})
        '
        'GridView_Data
        '
        Me.GridView_Data.GridControl = Me.GridControl_Data
        Me.GridView_Data.Name = "GridView_Data"
        Me.GridView_Data.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView_Data.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView_Data.OptionsBehavior.Editable = False
        Me.GridView_Data.OptionsSelection.MultiSelect = True
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'ProgressPanel_Bills
        '
        Me.ProgressPanel_Bills.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.ProgressPanel_Bills.Appearance.Options.UseBackColor = True
        Me.ProgressPanel_Bills.BarAnimationElementThickness = 2
        Me.ProgressPanel_Bills.ContentAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.ProgressPanel_Bills.Description = "Fetching Data from Server..."
        Me.ProgressPanel_Bills.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ProgressPanel_Bills.Location = New System.Drawing.Point(0, 143)
        Me.ProgressPanel_Bills.Name = "ProgressPanel_Bills"
        Me.ProgressPanel_Bills.Size = New System.Drawing.Size(521, 275)
        Me.ProgressPanel_Bills.TabIndex = 5
        '
        'Worker_Bills
        '
        '
        'PrintDocumentEx1
        '
        Me.PrintDocumentEx1.DocumentName = "Estimate Bill"
        Me.PrintDocumentEx1.Items = Nothing
        Me.PrintDocumentEx1.PrintTaxDetails = False
        '
        'frm_Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(521, 449)
        Me.Controls.Add(Me.ProgressPanel_Bills)
        Me.Controls.Add(Me.GridControl_Data)
        Me.Controls.Add(Me.RibbonStatusBar)
        Me.Controls.Add(Me.RibbonControl)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(531, 450)
        Me.Name = "frm_Main"
        Me.Ribbon = Me.RibbonControl
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.StatusBar = Me.RibbonStatusBar
        Me.Text = "Devil7 - Estimate Bill Printer"
        CType(Me.RibbonControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl_Data, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView_Data, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RibbonControl As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents rp_Home As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup_Items As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents RibbonStatusBar As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Friend WithEvents GridControl_Data As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView_Data As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btn_Add As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btn_Remove As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btn_Edit As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup_Printing As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents btn_Print As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btn_PrintPreview As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents btn_Senders As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btn_Receivers As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPage_Settings As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents btn_WaterMarkSettings As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents RibbonPageGroup2 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents SkinRibbonGalleryBarItem1 As DevExpress.XtraBars.SkinRibbonGalleryBarItem
    Friend WithEvents Theme As DevExpress.LookAndFeel.DefaultLookAndFeel
    Friend WithEvents btn_OtherSettings As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btn_Services As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents btn_ServerSettings As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ProgressPanel_Bills As DevExpress.XtraWaitForm.ProgressPanel
    Friend WithEvents Worker_Bills As System.ComponentModel.BackgroundWorker
    Friend WithEvents btn_Refresh As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents PrintDocumentEx1 As D7Automation.PrintDocumentEx


End Class
