Imports System.IO

Partial Class SystemMng_Define_SiteDefine_LogicalPage
    Inherits AdminBasePage

    Public Property _pagesService As IPagesService
    Dim PlantDivisionObj As New CLSPlantDivisions
    'Dim PlantObj As New CLSPlants
    Dim compObj As New CLSCompanies

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not IsPostBack Then
            BindGridview()
            DialogSetting()
            AddSystemHistory("نمایش مدیریت صفحات وب", 0)
        End If
    End Sub

    Sub BindGridview()
        gridview1.DataSource = _pagesService.GetLogicalPageByDivision(_securityUser.DivisionId)
        gridview1.DataBind()
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If IsValid Then

            Dim item As New Danesh.ArvandIntranet.DomainClasses.Models.Page

            item.Active = chkActive.Checked
            item.DivisionId = _securityUser.DivisionId
            item.MasterPageId = 2
            item.PageDelete = False
            item.PageFileName = txtPage_file_name.Text
            item.PageLink = ""
            item.PageNo = 1
            item.PageTitle = txtPage_title.Text
            item.PageSummary = txtSummary.Text
            item.PageContent = txtPage_Latin_Content.Content

            item.PageType = 1

            Dim rowEffect = _pagesService.AddPage(item)

            If (rowEffect > 0) Then
                AddSystemHistory("اضافه کردن صفحه جدید", 1)
                ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('عملیات با موفقیت انجام شد');", True)
                BindGridview()
                clear()
            Else
                ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('خطا در ثبت');", True)
            End If
        End If


    End Sub

    Private Sub clear()
        txtPage_file_name.Text = ""
        txtPage_Latin_Content.Content = ""
        txtSummary.Text = ""
        txtPage_title.Text = ""
        chkActive.Checked = True
        gridview1.SelectedIndex = -1
        PageId.Value = ""
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        clear()
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If IsValid And PageId.Value <> "" Then

            Dim Page_Id As Integer = CLSHash.Decode(PageId.Value)

            Dim item = _pagesService.GetOnePage(Page_Id)

            item.Active = chkActive.Checked
            item.DivisionId = _securityUser.DivisionId
            item.MasterPageId = 2
            item.PageDelete = False
            item.PageFileName = txtPage_file_name.Text
            item.PageLink = ""
            item.PageNo = 1
            item.PageTitle = txtPage_title.Text
            item.PageSummary = txtSummary.Text
            item.PageContent = txtPage_Latin_Content.Content

            item.PageType = 1

            Dim rowEffect = _pagesService.UpdatePage()

            If (rowEffect = 1) Then
                AddSystemHistory("ویرایش صفحه", 2)
                ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('عملیات با موفقیت انجام شد');", True)
                BindGridview()
                clear()
            Else
                ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('خطا در ثبت');", True)
            End If
        Else
            ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('لطفا یک آیتم را انتخاب کنید');", True)
        End If

    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridview1.RowCommand
        clear()
        If (e.CommandName = "del") Then

            Dim Page_Id As Integer = Convert.ToInt32(CLSHash.Decode(e.CommandArgument.ToString))
            Dim DelPage = _pagesService.GetOnePage(Page_Id)
            Dim rowEffect As Integer = _pagesService.DeletePage(DelPage)
            If (rowEffect) Then
                AddSystemHistory("حذف صفحه", 3)
                ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('عملیات با موفقیت انجام شد');", True)
                BindGridview()
            Else
                ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('خطا در عملیات');", True)
            End If

        ElseIf e.CommandName = "up" Then
            Dim SelectRowIndx As Integer = DirectCast(DirectCast(e.CommandSource, System.Web.UI.WebControls.ImageButton).DataItemContainer, System.Web.UI.WebControls.GridViewRow).RowIndex
            gridview1.SelectedIndex = SelectRowIndx

            Dim Page_Id As Integer = CLSHash.Decode(e.CommandArgument.ToString)
            Dim MyCls = _pagesService.GetOnePage(Page_Id)
            txtPage_file_name.Text = MyCls.PageFileName
            txtPage_title.Text = MyCls.PageTitle
            chkActive.Checked = MyCls.Active
            txtPage_Latin_Content.Content = MyCls.PageContent
            txtSummary.Text = MyCls.PageSummary
            PageId.Value = CLSHash.Encode(MyCls.PageId.ToString())

        End If
    End Sub

    Protected Sub DialogSetting()
        Dim explorerPath = "~/UploadFiles/Division/" & _securityUser.PlantDivision.DivisionAbbr
        Dim paths(0) As String
        paths(0) = explorerPath
        If Not Directory.Exists(Server.MapPath(explorerPath)) Then
            Directory.CreateDirectory(Server.MapPath(explorerPath))
        End If
        txtPage_Latin_Content.ImageManager.ViewPaths = paths
        txtPage_Latin_Content.ImageManager.UploadPaths = paths
        txtPage_Latin_Content.ImageManager.DeletePaths = paths
        txtPage_Latin_Content.ImageManager.MaxUploadFileSize = (_maxVolume.MaxFileVolume * 1024)

        txtPage_Latin_Content.DocumentManager.ViewPaths = paths
        txtPage_Latin_Content.DocumentManager.UploadPaths = paths
        txtPage_Latin_Content.DocumentManager.DeletePaths = paths
        txtPage_Latin_Content.DocumentManager.MaxUploadFileSize = (_maxVolume.MaxFileVolume * 1024)
        ' txtPage_Latin_Content.ImageManager.ViewMode.VisibleControls = GetVisibleControls()
    End Sub

    Protected Function GetVisibleControls() As Telerik.Web.UI.FileExplorer.FileExplorerControls
        Dim explorerControls As Telerik.Web.UI.FileExplorer.FileExplorerControls = 0
        'explorerControls = explorerControls Or Telerik.Web.UI.FileExplorer.FileExplorerControls.AddressBox
        explorerControls = explorerControls Or Telerik.Web.UI.FileExplorer.FileExplorerControls.Grid
        explorerControls = explorerControls Or Telerik.Web.UI.FileExplorer.FileExplorerControls.Toolbar
        explorerControls = explorerControls Or Telerik.Web.UI.FileExplorer.FileExplorerControls.TreeView
        explorerControls = explorerControls Or Telerik.Web.UI.FileExplorer.FileExplorerControls.ContextMenus
        Return explorerControls

    End Function

End Class
