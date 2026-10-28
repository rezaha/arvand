
Partial Class SecurityUser
    Inherits AdminBasePage
    Dim UserObj As New CLSSecurityUsers
    Dim PerObj As New CLSPersonnel
    Public Property _plantDivisionsService As IPlantDivisionsService

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Not IsPostBack Then
                If _securityUser.DivisionId <> 0 Or _securityUser.UserAdmin = False Then
                    ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('شما اجازه دسترسی به این بخش را ندارید');", True)
                    Response.RedirectToRoute("management", New With {.pageName = "Welcome"})
                Else
                    AddSystemHistory("نمایش لیست کاربران", 0)
                    For Each _division In _plantDivisionsService.AllPlantDivision
                        drpPlantDivision.Items.Add(New ListItem(_division.NamePersian, _division.DivisionId))
                    Next
                    If _securityUser.DivisionId <> 0 Then
                        drpPlantDivision.SelectedValue = _securityUser.DivisionId
                        drpPlantDivision.Enabled = False
                    End If
                    BindGrid()
                End If
            End If
        End If
    End Sub

    Sub BindGrid()
        If _securityUser.DivisionId <> 0 Then
            gridview1.DataSource = _securityUserService.GetAllSecurityUserByDivisionId(_securityUser.DivisionId)
            gridview1.DataBind()
        Else
            gridview1.DataSource = _securityUserService.GetAllSecurityUser()
            gridview1.DataBind()
        End If
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If IsValid Then
            Dim item As New CLSSecurityUsersItem

            item.Division.Division_id = drpPlantDivision.SelectedValue
            item.Create_date = CLSShamsiDate.ShortDate(Now).Substring(2)
            item.firstName = txtFirstName.Text
            item.LastName = txtlastName.Text
            item.User_lock = chkActive.Checked
            item.User_name = txtUser_name.Text
            item.User_password = txtUser_password.Text
            item.User_type = chkAdmin.Checked

            Dim rowEffect As Boolean = UserObj.Insert(item)

            If (rowEffect) Then
                AddSystemHistory("کاربر جدید", 1)
                ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('عملیات با موفقیت انجام شد');", True)
                BindGrid()
                clear()
            Else
                ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('خطا در ثبت');", True)
            End If
        End If
    End Sub

    Sub clear()
        txtFirstName.Text = ""
        txtlastName.Text = ""
        txtUser_name.Text = ""
        txtUser_password.Text = ""
        chkActive.Checked = False
        chkAdmin.Checked = False
        gridview1.SelectedIndex = -1
        UserId.Value = ""
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridview1.RowCommand
        clear()
        If (e.CommandName = "del") Then

            Dim userId As Integer = Convert.ToInt32(CLSHash.Decode(e.CommandArgument.ToString))
            Dim rowEffect As Integer = UserObj.Delete(userId)
            If (rowEffect) Then
                AddSystemHistory("حذف کاربر", 3)
                ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('عملیات با موفقیت انجام شد');", True)
                BindGrid()
            Else
                ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('خطا در عملیات');", True)
            End If


        ElseIf e.CommandName = "up" Then
            Dim SelectRowIndx As Integer = DirectCast(DirectCast(e.CommandSource, System.Web.UI.WebControls.ImageButton).DataItemContainer, System.Web.UI.WebControls.GridViewRow).RowIndex
            gridview1.SelectedIndex = SelectRowIndx
            Dim MyCls As CLSSecurityUsersItem = UserObj.GetRecord(CLSHash.Decode(e.CommandArgument.ToString))
            txtFirstName.Text = MyCls.firstName
            txtlastName.Text = MyCls.LastName
            txtUser_name.Text = MyCls.User_name
            txtUser_password.Text = MyCls.User_password
            chkActive.Checked = MyCls.User_lock
            chkAdmin.Checked = MyCls.User_type
            drpPlantDivision.SelectedValue = MyCls.Division.Division_id

            UserId.Value = CLSHash.Encode(MyCls.User_id.ToString())
        End If
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If IsValid And UserId.Value <> "" Then
            Dim feild As New CLSSecurityUsersItem
            feild.Division.Division_id = drpPlantDivision.SelectedValue
            feild.User_id = CLSHash.Decode(UserId.Value.ToString())
            feild.Create_date = CLSShamsiDate.ShortDate(Now).Substring(2)
            feild.firstName = txtFirstName.Text
            feild.LastName = txtlastName.Text
            feild.User_lock = chkActive.Checked
            feild.User_name = txtUser_name.Text
            feild.User_password = txtUser_password.Text
            feild.User_type = chkAdmin.Checked

            Dim rowEffect As Integer = UserObj.Update(feild)
            If (rowEffect) Then
                AddSystemHistory("ویرایش کاربر", 2)
                ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('عملیات با موفقیت انجام شد');", True)
                BindGrid()
                clear()
            Else
                ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('خطا در عملیات');", True)
            End If
        Else
        End If
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        clear()
    End Sub


End Class
