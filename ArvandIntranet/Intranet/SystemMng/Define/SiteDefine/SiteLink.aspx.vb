
Partial Class SiteLink
    Inherits AdminBasePage

    Dim SiteLinkObj As New CLSSitesLink
    Dim PlantDivisionObj As New CLSPlantDivisions
    Public Property _sitesLinkService As ISitesLinkService

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
            AddSystemHistory("نمایش پیوند های سایت", 0)
            BindGridView()
        End If
    End Sub

    Public Sub BindGridView()
        gridview1.DataSource = _sitesLinkService.GetAllSiteLinkByDivisionId(_securityUser.DivisionId)
        gridview1.DataBind()
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If IsValid Then

            'Dim intLength_Persian As Integer
            'Dim arrContent_Persian As Byte()

            'Dim intLength_English As Integer
            'Dim arrContent_English As Byte()

            Dim item As New CLSSitesLinkItem
            item.Division.Division_id = _securityUser.DivisionId
            item.Site_group = 1
            item.Show_status = 0
            item.Title_persian = txtTitle_persian.Text
            item.Html_title_persian = ""
            item.Html_title_latin = ""
            item.Title_latin = ""
            item.Site_link = txtSite_link.Text
            item.Site_order = txtSite_order.Text
            item.Site_link_delete = chkActive.Checked
            item.Logo_persian = txtLogo_persian.Text.Trim
            item.Logo_latin = ""
            item.Remark = ""

            Dim rowEffect As Boolean = SiteLinkObj.InsertSITES_LINK(item)

            If (rowEffect) Then
                AddSystemHistory("اضافه کردن پیوند جدید", 1)
                ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('عملیات با موفقیت انجام شد');", True)
                BindGridView()
                clear()
            Else
                ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('خطا در ثبت');", True)
            End If

        End If
    End Sub

    Private Sub clear()
        'rblShow_status.SelectedValue = 0
        txtSite_link.Text = ""
        txtSite_order.Text = ""
        txtTitle_persian.Text = ""
        gridview1.SelectedIndex = -1
        SiteId.Value = ""
        txtLogo_persian.Text = ""
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        clear()
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If IsValid And SiteId.Value <> "" Then

            Dim item As New CLSSitesLinkItem
            item.Site_id = CLSHash.Decode(SiteId.Value.ToString())
            item.Division.Division_id = _securityUser.DivisionId
            item.Site_group = 1
            item.Show_status = 0
            item.Title_persian = txtTitle_persian.Text
            item.Title_persian = txtTitle_persian.Text
            item.Title_latin = ""
            item.Html_title_persian = ""
            item.Html_title_latin = ""
            item.Site_link = txtSite_link.Text
            item.Site_order = txtSite_order.Text
            item.Site_link_delete = chkActive.Checked


            item.Logo_persian = txtLogo_persian.Text.Trim
            item.Logo_latin = ""

            item.Remark = ""


            Dim rowEffect As Integer = SiteLinkObj.UpdateSITES_LINK(item)
            If (rowEffect) Then
                AddSystemHistory("ویرایش پیوند", 2)
                ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('عملیات با موفقیت انجام شد');", True)
                BindGridView()
                clear()
            Else
                ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('خطا در عملیات');", True)
            End If

        Else
            ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('لطفا یک آیتم را انتخاب کنید');", True)
        End If
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridview1.RowCommand
        clear()
        If (e.CommandName = "del") Then

            Dim CityId As Integer = Convert.ToInt32(CLSHash.Decode(e.CommandArgument.ToString))
            Dim rowEffect As Integer = SiteLinkObj.DeleteSITES_LINK(CityId)
            If (rowEffect) Then
                AddSystemHistory("حذف پیوند", 3)
                ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('عملیات با موفقیت انجام شد');", True)
                BindGridView()
            Else
                ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('خطا در عملیات');", True)
            End If

        ElseIf e.CommandName = "up" Then
            Dim SelectRowIndx As Integer = DirectCast(DirectCast(e.CommandSource, System.Web.UI.WebControls.ImageButton).DataItemContainer, System.Web.UI.WebControls.GridViewRow).RowIndex
            gridview1.SelectedIndex = SelectRowIndx
            Dim MyCls As CLSSitesLinkItem = SiteLinkObj.GetSITES_LINK(CLSHash.Decode(e.CommandArgument.ToString))

            txtSite_link.Text = MyCls.Site_link
            txtSite_order.Text = MyCls.Site_order
            txtTitle_persian.Text = MyCls.Title_persian
            txtLogo_persian.Text = MyCls.Logo_persian

            SiteId.Value = CLSHash.Encode(MyCls.Site_id.ToString())
        End If
    End Sub



End Class
