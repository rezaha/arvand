
Partial Class SystemMng_Define_SiteDefine_Softwares
    Inherits AdminBasePage

    Public Property _softwareService As ISoftwareService

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
            AddSystemHistory("نمایش لینک های پر کاربرد", 0)
            BindGridView()
        End If
    End Sub

    Public Sub BindGridView()
        gridview1.DataSource = _softwareService.GetAllSoftwares(_securityUser.DivisionId)
        gridview1.DataBind()
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If IsValid Then

            'Dim intLength_Persian As Integer
            'Dim arrContent_Persian As Byte()

            'Dim intLength_English As Integer
            'Dim arrContent_English As Byte()

            Dim item As New Software
            item.DivisionId = _securityUser.DivisionId
            item.Active = True
            item.SoftwareLargIcon = txtSoftwareSmallIcon.Text
            item.SoftwareName = txtSoftwareName.Text
            item.SoftwareSmallIcon = txtSoftwareSmallIcon.Text
            item.SoftwareUrl = txtSoftwareUrl.Text
            item.SortOrder = txtSite_order.Text

            Dim rowEffect As Integer = _softwareService.AddSoftware(item, New Dictionary(Of String, String))

            If (rowEffect) > 0 Then
                AddSystemHistory("اضافه کردن لینک های پر کاربرد", 1)
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

        hfldSoftwareId.Value = ""
        txtSoftwareName.Text = ""
        txtSoftwareSmallIcon.Text = ""
        txtSoftwareUrl.Text = ""
        txtSite_order.Text = ""
        gridview1.SelectedIndex = -1
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        clear()
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If IsValid And hfldSoftwareId.Value <> "" Then

            Dim softwareId As Integer = hfldSoftwareId.Value.ToString()
            Dim item As Software = _softwareService.GetOneSoftwares(softwareId)
            item.Active = True
            item.SoftwareLargIcon = txtSoftwareSmallIcon.Text
            item.SoftwareName = txtSoftwareName.Text
            item.SoftwareSmallIcon = txtSoftwareSmallIcon.Text
            item.SoftwareUrl = txtSoftwareUrl.Text
            item.SortOrder = txtSite_order.Text

            Dim rowEffect As Integer = _softwareService.EditSoftware(item, New Dictionary(Of String, String))
            If (rowEffect) >= 0 Then
                AddSystemHistory("ویرایش لینک های پر کاربرد", 2)
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
            Dim softwareId As Integer = e.CommandArgument.ToString
            Dim item As Software = _softwareService.GetOneSoftwares(softwareId)
            Dim rowEffect As Integer = _softwareService.RemoveSoftware(item, New Dictionary(Of String, String))
            If (rowEffect) Then
                AddSystemHistory("حذف لینک های پر کاربرد", 3)
                ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('عملیات با موفقیت انجام شد');", True)
                BindGridView()
            Else
                ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('خطا در عملیات');", True)
            End If

        ElseIf e.CommandName = "up" Then
            Dim SelectRowIndx As Integer = DirectCast(DirectCast(e.CommandSource, System.Web.UI.WebControls.ImageButton).DataItemContainer, System.Web.UI.WebControls.GridViewRow).RowIndex
            gridview1.SelectedIndex = SelectRowIndx
            Dim softwareId As Integer = e.CommandArgument.ToString
            Dim item As Software = _softwareService.GetOneSoftwares(softwareId)


            txtSoftwareName.Text = item.SoftwareName
            txtSoftwareSmallIcon.Text = item.SoftwareSmallIcon
            txtSoftwareUrl.Text = item.SoftwareUrl
            txtSite_order.Text = item.SortOrder
            hfldSoftwareId.Value = item.SoftwareId.ToString()
        End If
    End Sub



End Class
