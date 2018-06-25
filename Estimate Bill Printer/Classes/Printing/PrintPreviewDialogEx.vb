Imports System.ComponentModel
Imports System.Drawing.Printing

Public Class PrintPreviewDialogEx

    ' ** fields
    Private _doc As PrintDocument

    ' ** ctors
    Public Sub New()
        Me.New(Nothing)
    End Sub

    Public Sub New(ByVal parentForm As Control)
        Me.components = Nothing
        Me.InitializeComponent()
        If (Not parentForm Is Nothing) Then
            MyBase.Size = parentForm.Size
        End If
    End Sub

    ' ** overrides
    Protected Overrides Sub OnFormClosing(ByVal e As FormClosingEventArgs)
        MyBase.OnFormClosing(e)
        If Not (Not Me._preview.IsRendering OrElse e.Cancel) Then
            Me._preview.Cancel()
        End If
    End Sub

    Protected Overrides Sub OnShown(ByVal e As EventArgs)
        MyBase.OnShown(e)
        Me._preview.Document = Me.Document
    End Sub

    ' ** properties
    Public Property Document() As PrintDocument
        Get
            Return Me._doc
        End Get
        Set(ByVal value As PrintDocument)
            If (Not Me._doc Is Nothing) Then
                RemoveHandler Me._doc.BeginPrint, New PrintEventHandler(AddressOf Me._doc_BeginPrint)
                RemoveHandler Me._doc.EndPrint, New PrintEventHandler(AddressOf Me._doc_EndPrint)
            End If
            Me._doc = value
            If (Not Me._doc Is Nothing) Then
                AddHandler Me._doc.BeginPrint, New PrintEventHandler(AddressOf Me._doc_BeginPrint)
                AddHandler Me._doc.EndPrint, New PrintEventHandler(AddressOf Me._doc_EndPrint)
            End If
            If MyBase.Visible Then
                Me._preview.Document = Me.Document
            End If
        End Set
    End Property

    

    Private Sub _doc_BeginPrint(ByVal sender As Object, ByVal e As PrintEventArgs)
        Me.btn_Close.Caption = "&Cancel"
    End Sub

    Private Sub _doc_EndPrint(ByVal sender As Object, ByVal e As PrintEventArgs)
        Me.btn_Close.Caption = "&Close"
    End Sub
    Dim pagecount As Integer
    Private Sub _preview_PageCountChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _preview.PageCountChanged
        MyBase.Update()
        Application.DoEvents()
        Me.pagecount = Me._preview.PageCount
        Me.RepositoryItemSpinEdit1.MaxValue = pagecount
    End Sub

    Private Sub _preview_StartPageChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _preview.StartPageChanged
        Me.lbl_PageCount.Caption = String.Format("{0} of {1}", Me._preview.StartPage + 1, pagecount)
        Me.txt_Page.EditValue = Me._preview.StartPage + 1
    End Sub

    Private Sub btn_Close_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btn_Close.ItemClick
        If Me._preview.IsRendering Then
            Me._preview.Cancel()
        Else
            MyBase.Close()
        End If
    End Sub


    Private Sub btn_100Percent_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btn_100Percent.ItemClick
        Me._preview.ZoomMode = ZoomMode.ActualSize
    End Sub

    Private Sub btn_FullPage_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btn_FullPage.ItemClick
        Me._preview.ZoomMode = ZoomMode.FullPage
    End Sub

    Private Sub btn_PageWidth_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btn_PageWidth.ItemClick
        Me._preview.ZoomMode = ZoomMode.PageWidth
    End Sub

    Private Sub btn_TwoPages_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btn_TwoPages.ItemClick
        Me._preview.ZoomMode = ZoomMode.TwoPages
    End Sub

    Private Sub tb_Zoom_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tb_Zoom.EditValueChanged
        Try
            Dim v As Decimal = tb_Zoom.EditValue / 100
            Me._preview.Zoom = v
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_First_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btn_First.ItemClick
        Try
            Me._preview.StartPage = 0
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_Back_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btn_Back.ItemClick
        Try
            Me._preview.StartPage -= 1
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_Next_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btn_Next.ItemClick
        Try
            Me._preview.StartPage += 1
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btn_Last_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles btn_Last.ItemClick
        Me._preview.StartPage = (Me._preview.PageCount - 1)
    End Sub

    Private Sub txt_Page_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles txt_Page.ItemClick
        Try
            Me._preview.StartPage = txt_Page.EditValue - 1
        Catch ex As Exception

        End Try
    End Sub

End Class