Imports System.IO

Partial Class SystemMng_Define_SiteDefine_UserWebPart
    Inherits AdminBasePage

    Dim PartObj As New CLSWebparts

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        If Not IsPostBack Then
            'If FormUserGrant.InsertRecord Then
            '    btnAdd.Enabled = True
            'Else
            '    btnAdd.Enabled = False
            'End If

            'If FormUserGrant.UpdateRecord Then
            '    btnSave.Enabled = True
            'Else
            '    btnSave.Enabled = False
            'End If
            AddSystemHistory("مشاهده وب پارت", 0)
            gridview1.DataSource = PartObj.GetWEBPARTS(1, _securityUser.DivisionId)
            gridview1.DataBind()
            DialogSetting()
        End If
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If IsValid Then

            Dim item As New CLSWebpartsItem
            item.Division_id = _securityUser.DivisionId
            item.Active = True
            item.Description_latin = ""
            item.Description_persian = ""
            item.Header_latin = ""
            item.Header_persian = txtHeader_persian.Text
            item.Html_content_latin = ""
            item.Html_content_persian = txtHtml_content_persian.Content
            item.Name_latin = ""
            item.Name_persian = ""
            item.Remark = ""
            item.Webpart_group = 1
            item.Webpart_name = "UserWebpart"
            item.Webpart_no = 1
            item.WebPartType = 1
            item.WebpartMethod = ""
            item.WebPartParameters = ""
            item.WebPart_Address = ""
            Dim rowEffect As Boolean = PartObj.InsertWEBPARTS(item)
            If (rowEffect) Then
                AddSystemHistory("اضافه کردن وب پارت", 1)
                ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('عملیات با موفقیت انجام شد');", True)
                gridview1.DataSource = PartObj.GetWEBPARTS(1, _securityUser.DivisionId)
                gridview1.DataBind()
                clear()
            Else
                ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('خطا در ثبت');", True)
            End If

        End If
    End Sub

    Sub clear()


        txtHeader_persian.Text = ""

        txtHtml_content_persian.Content = ""
        gridview1.SelectedIndex = -1
        WebPartId.Value = ""
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridview1.RowCommand
        clear()
        If (e.CommandName = "del") Then


            Dim webPart_ID As Integer = Convert.ToInt32(CLSHash.Decode(e.CommandArgument.ToString))
            Dim rowEffect As Integer = PartObj.DeleteWEBPARTS(webPart_ID)
            If (rowEffect) Then
                AddSystemHistory("حذف وب پارت", 3)
                ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('عملیات با موفقیت انجام شد');", True)
                gridview1.DataSource = PartObj.GetWEBPARTS(1, _securityUser.DivisionId)
                gridview1.DataBind()
            Else
                ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('خطا در عملیات');", True)
            End If


        ElseIf e.CommandName = "up" Then

            Dim SelectRowIndx As Integer = DirectCast(DirectCast(e.CommandSource, System.Web.UI.WebControls.ImageButton).DataItemContainer, System.Web.UI.WebControls.GridViewRow).RowIndex
            gridview1.SelectedIndex = SelectRowIndx
            Dim MyCls As CLSWebpartsItem = PartObj.GetWEBPART(CLSHash.Decode(e.CommandArgument.ToString))
            WebPartId.Value = MyCls.Webpart_id

            txtHeader_persian.Text = MyCls.Header_persian

            txtHtml_content_persian.Content = MyCls.Html_content_persian
            WebPartId.Value = CLSHash.Encode(MyCls.Webpart_id.ToString())

        End If
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If IsValid And WebPartId.Value <> "" Then

            Dim feild As New CLSWebpartsItem
            feild.Webpart_id = CLSHash.Decode(WebPartId.Value.ToString())
            feild.Division_id = _securityUser.DivisionId
            feild.Active = True
            feild.Description_latin = ""
            feild.Description_persian = ""
            feild.Header_latin = ""
            feild.Header_persian = txtHeader_persian.Text
            feild.Html_content_latin = ""
            feild.Html_content_persian = txtHtml_content_persian.Content
            feild.Name_latin = ""
            feild.Name_persian = ""
            feild.Remark = ""
            feild.Webpart_group = 1
            feild.Webpart_name = "UserWebpart"
            feild.Webpart_no = 1
            feild.WebPartType = 1
            feild.WebpartMethod = ""
            feild.WebPartParameters = ""
            feild.WebPart_Address = ""
            Dim rowEffect As Integer = PartObj.UpdateWEBPARTS(feild)
            If (rowEffect) Then
                AddSystemHistory("ویرایش وب پارت", 2)
                ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('عملیات با موفقیت انجام شد');", True)
                gridview1.DataSource = PartObj.GetWEBPARTS(1, _securityUser.DivisionId)
                gridview1.DataBind()
                clear()
            Else
                ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('خطا در عملیات');", True)
            End If

        End If
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        clear()
    End Sub

    Protected Sub DialogSetting()
        Dim explorerPath = "~/UploadFiles/Division/" & _securityUser.PlantDivision.DivisionAbbr
        Dim paths(0) As String
        paths(0) = explorerPath
        If Not Directory.Exists(Server.MapPath(explorerPath)) Then
            Directory.CreateDirectory(Server.MapPath(explorerPath))
        End If
        txtHtml_content_persian.ImageManager.ViewPaths = paths
        txtHtml_content_persian.ImageManager.UploadPaths = paths
        txtHtml_content_persian.ImageManager.DeletePaths = paths
        txtHtml_content_persian.ImageManager.MaxUploadFileSize = (_maxVolume.MaxFileVolume * 1024)

        txtHtml_content_persian.DocumentManager.ViewPaths = paths
        txtHtml_content_persian.DocumentManager.UploadPaths = paths
        txtHtml_content_persian.DocumentManager.DeletePaths = paths
        txtHtml_content_persian.DocumentManager.MaxUploadFileSize = (_maxVolume.MaxFileVolume * 1024)
        'txtPage_Latin_Content.ImageManager.ViewMode.VisibleControls = GetVisibleControls()
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
