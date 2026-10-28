Imports System.Data.SqlClient

Partial Class Menu
    Inherits AdminBasePage
    Dim MenuObj As New CLSMenus
    Public Property PageSer As IPagesService
    Public Property _menuService As IMenuService
    Dim DivisionObj As New CLSPlantDivisions

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            Dim cnn As New SqlConnection(SiteHelper.GetConnectionString)
            Dim com As New SqlCommand("SELECT DISTINCT MENU_ID, NAME_PERSIAN FROM MENUS WHERE DIVISION_ID= @DIV_ID", cnn)
            com.Parameters.AddWithValue("@DIV_ID", _securityUser.DivisionId)
            Dim Da As New SqlDataAdapter(com)
            Dim ds As New Data.DataSet()
            Da.Fill(ds)
            drpMenu_parant.Items.Clear()
            drpMenu_parant.Items.Add("ندارد")
            drpMenu_parant.Items(0).Value = "ندارد"
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                drpMenu_parant.Items.Add(ds.Tables(0).Rows(i).Item(1).ToString())
                drpMenu_parant.Items(drpMenu_parant.Items.Count - 1).Value = ds.Tables(0).Rows(i).Item(0).ToString()
            Next

            HFPArentId.Value = 0

            BindGrid(HFPArentId.Value)

            Dim pages = PageSer.GetAllPagesByDivisionId(_securityUser.DivisionId).Where(Function(a) a.PageType = Danesh.ArvandIntranet.DomainClasses.Models.PageType.UserDefinePage Or a.PageFileName = "SelContact.aspx").OrderBy(Function(a) a.PageTitle).ToList()
            For Each a In pages
                If a.PageFileName = "SelContact.aspx" Then
                    lbxPage.Items.Add(New ListItem(a.PageTitle.ToFriendlyUrl, a.PageLink))
                Else
                    lbxPage.Items.Add(New ListItem(a.PageTitle.ToFriendlyUrl, "ShowPage/" & a.PageId & "/" & a.PageTitle.ToFriendlyUrl))
                End If
            Next
            AddSystemHistory("نمایش فرم منوها", 0)
        End If
    End Sub

    Sub BindGrid(ByVal ParentId As Integer)
        If ParentId = 0 Then
            gridview1.DataSource = _menuService.GetAllMenuByDivisionId(_securityUser.DivisionId)
            gridview1.DataBind()
        Else
            gridview1.DataSource = _menuService.GetAllMenuByDivisionId(_securityUser.DivisionId)
            gridview1.DataBind()
        End If
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Validate()
        If IsValid Then
            If ActionGrant("Insert") Then
                Dim item As New CLSMenusItem
                item.Active = True
                item.Division.Division_id = _securityUser.DivisionId
                item.Icon_status = 0
                item.Menu_icon_link = ""
                item.Link_active = chkActiveLink.Checked
                item.Menu_level = 1
                item.Menu_link_latin = ""
                item.Menu_link_persian = txtMenu_link_persian.Text
                item.Menu_no = 1
                item.Menu_order = txtMenu_order.Text
                If drpMenu_parant.SelectedValue <> "ندارد" Then
                    item.Menu_parant = drpMenu_parant.SelectedValue
                Else
                    item.Menu_parant = 0
                End If
                item.Name_latin = ""
                item.Name_persian = txtName_persian.Text
                item.Remark = ""
                item.Result_status = 1
                item.Show_status = 0
                item.Menu_icon_link = ""
                Dim rowEffect As Boolean = MenuObj.InsertMENUS(item)
                If (rowEffect) Then
                    AddSystemHistory("ایجاد منوی جدید", 1)
                    ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('عملیات با موفقیت انجام شد');", True)
                    Dim cnn As New SqlConnection(SiteHelper.GetConnectionString)
                    Dim com As New SqlCommand("SELECT DISTINCT MENU_ID, NAME_PERSIAN FROM MENUS WHERE DIVISION_ID= @DIV_ID", cnn)
                    com.Parameters.AddWithValue("@DIV_ID", _securityUser.DivisionId)
                    Dim Da As New SqlDataAdapter(com)
                    Dim ds As New Data.DataSet()
                    Da.Fill(ds)
                    drpMenu_parant.Items.Clear()
                    drpMenu_parant.Items.Add("ندارد")
                    drpMenu_parant.Items(0).Value = "ندارد"
                    For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                        drpMenu_parant.Items.Add(ds.Tables(0).Rows(i).Item(1).ToString())
                        drpMenu_parant.Items(drpMenu_parant.Items.Count - 1).Value = ds.Tables(0).Rows(i).Item(0).ToString()
                    Next
                    drpMenu_parant.SelectedValue = IIf(HFPArentId.Value = "0", "ندارد", HFPArentId.Value)
                    BindGrid(HFPArentId.Value)
                    clear()
                Else
                    ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('خطا در ثبت');", True)
                End If
            End If
        End If
    End Sub

    Private Sub clear()
        txtMenu_link_persian.Text = ""
        txtMenu_order.Text = ""
        txtName_persian.Text = ""

        gridview1.SelectedIndex = -1
        MenuId.Value = ""
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        drpMenu_parant.SelectedIndex = 0
        BindGrid(0)
        clear()
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If drpMenu_parant.SelectedValue = CLSHash.Decode(MenuId.Value.ToString()) Then
            ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('والد یک منو نمیتواند خود منو باشد');", True)
            Return
        End If
        If IsValid And MenuId.Value <> "" Then
            If ActionGrant("Update") Then
                Dim item As New CLSMenusItem
                item.Menu_id = CLSHash.Decode(MenuId.Value.ToString())
                item.Active = True
                item.Division.Division_id = _securityUser.DivisionId
                item.Icon_status = 0
                item.Menu_icon_link = ""
                item.Link_active = chkActiveLink.Checked
                item.Menu_level = 1
                item.Menu_link_latin = ""
                item.Menu_link_persian = txtMenu_link_persian.Text
                item.Menu_no = 1
                item.Menu_order = txtMenu_order.Text
                If drpMenu_parant.SelectedIndex <> 0 Then
                    item.Menu_parant = drpMenu_parant.SelectedValue
                Else
                    item.Menu_parant = 0
                End If
                item.Name_latin = ""
                item.Name_persian = txtName_persian.Text
                item.Remark = ""
                item.Result_status = 1
                item.Show_status = 0

                item.Menu_icon_link = ""
                Dim rowEffect As Integer = MenuObj.UpdateMENUS(item)
                If (rowEffect) Then
                    AddSystemHistory("ویرایش  منو", 2)
                    ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('عملیات با موفقیت انجام شد');", True)
                    drpMenu_parant.SelectedValue = IIf(HFPArentId.Value = "0", "ندارد", HFPArentId.Value)
                    BindGrid(HFPArentId.Value)
                    clear()
                Else
                    ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('خطا در عملیات');", True)
                End If
            End If

        Else
            ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('لطفا یک آیتم را انتخاب کنید');", True)
        End If
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridview1.RowCommand
        clear()
        If (e.CommandName = "del") Then
            If ActionGrant("Delete") Then
                Dim MeniId As Integer = Convert.ToInt32(CLSHash.Decode(e.CommandArgument.ToString))
                Dim rowEffect As Integer = MenuObj.DeleteMENUS(MeniId)
                If (rowEffect) Then
                    AddSystemHistory("حذف منو", 3)
                    ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('عملیات با موفقیت انجام شد');", True)
                    Dim cnn As New SqlConnection(SiteHelper.GetConnectionString)
                    Dim com As New SqlCommand("SELECT DISTINCT MENU_ID, NAME_PERSIAN FROM MENUS WHERE DIVISION_ID= @DIV_ID", cnn)
                    com.Parameters.AddWithValue("@DIV_ID", _securityUser.DivisionId)
                    Dim Da As New SqlDataAdapter(com)
                    Dim ds As New Data.DataSet()
                    Da.Fill(ds)
                    drpMenu_parant.Items.Clear()
                    drpMenu_parant.Items.Add("ندارد")
                    drpMenu_parant.Items(0).Value = "ندارد"
                    For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                        drpMenu_parant.Items.Add(ds.Tables(0).Rows(i).Item(1).ToString())
                        drpMenu_parant.Items(drpMenu_parant.Items.Count - 1).Value = ds.Tables(0).Rows(i).Item(0).ToString()
                    Next
                    drpMenu_parant.SelectedValue = IIf(HFPArentId.Value = "0", "ندارد", HFPArentId.Value)
                    BindGrid(HFPArentId.Value)
                    clear()
                Else
                    ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('خطا در عملیات');", True)
                End If
            End If
        ElseIf e.CommandName = "up" Then
            Dim SelectRowIndx As Integer = DirectCast(DirectCast(e.CommandSource, System.Web.UI.WebControls.ImageButton).DataItemContainer, System.Web.UI.WebControls.GridViewRow).RowIndex
            gridview1.SelectedIndex = SelectRowIndx
            Dim MyCls As CLSMenusItem = MenuObj.GetMENU(CLSHash.Decode(e.CommandArgument.ToString))

            txtMenu_link_persian.Text = MyCls.Menu_link_persian
            txtMenu_order.Text = MyCls.Menu_order
            If MyCls.Menu_parant = 0 Then
                drpMenu_parant.SelectedValue = "ندارد"
            Else
                drpMenu_parant.SelectedValue = MyCls.Menu_parant.ToString()
            End If
            txtName_persian.Text = MyCls.Name_persian
            chkActiveLink.Checked = MyCls.Link_active
            MenuId.Value = CLSHash.Encode(MyCls.Menu_id.ToString())
        End If
    End Sub

    Protected Sub drpMenu_parant_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles drpMenu_parant.SelectedIndexChanged

        If MenuId.Value = "" Then
            If drpMenu_parant.SelectedIndex > 0 Then
                HFPArentId.Value = drpMenu_parant.SelectedValue
                gridview1.DataSource = _menuService.GetAllMenuByDivisionIdParentId(_securityUser.DivisionId, drpMenu_parant.SelectedValue)
                gridview1.DataBind()
            Else
                HFPArentId.Value = 0
                gridview1.DataSource = _menuService.GetAllMenuByDivisionId(_securityUser.DivisionId)
                gridview1.DataBind()
            End If
        End If

    End Sub
End Class
