
Partial Class SystemMng_Define_SiteDefine_PlantDivision
    Inherits AdminBasePage

    Public Property _plantDivisionsService As IPlantDivisionsService
    Public Property _webPartService As IWebPartService
    Public Property _pagesService As IPagesService


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            AddSystemHistory("نمایش واحد ها", 0)
            If _securityUser.DivisionId <> 0 Or _securityUser.UserAdmin = False Then
                ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('شما اجازه دسترسی به این بخش را ندارید');", True)
                Response.RedirectToRoute("management", New With {.pageName = "Welcome"})
            Else
                BindRecord()
            End If
        End If
    End Sub

    Sub BindRecord()
        gridview1.DataSource = _plantDivisionsService.AllPlantDivision()
        gridview1.DataBind()
    End Sub

  

    Private Sub clear()

        txtOrder.Text = ""
        txtPersianName.Text = ""
        txtDivisionLogo.Text = ""
        HFDivisionId.Value = ""
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        clear()
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If IsValid And HFDivisionId.Value <> "" Then


            Dim item = _plantDivisionsService.GetOnePlantDivisions(CLSHash.Decode(HFDivisionId.Value))


            item.ActiveLatinSite = True
            item.CoId = 0

            item.DivisionIcon = Nothing
            item.DivisionIconLink = Nothing
            item.DivisionOrder = txtOrder.Text
            item.HeaderImage = Nothing
            item.HeaderImageLatinLink = ""
            item.DivisionIconLink = txtDivisionLogo.Text
            item.HeaderStatus = 2
            item.HtmlContactusLatin = ""
            item.HtmlContactusLatinSummary = ""
            item.HtmlContactusPersian = ""
            item.HtmlContactusPersianSummary = ""
            item.IconStatus = 2
            item.NameLatin = ""
            item.NamePersian = txtPersianName.Text

            Dim rowEffect As Boolean = _plantDivisionsService.UpdatePlantDivisions(item)

            If (rowEffect) Then
                AddSystemHistory("ویرایش واحد", 2)
                ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('عملیات با موفقیت انجام شد');", True)
                BindRecord()
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

            Dim DivisionId As Integer = Convert.ToInt32(CLSHash.Decode(e.CommandArgument.ToString))
            Dim DelItem = _plantDivisionsService.GetOnePlantDivisions(DivisionId)
            Dim rowEffect As Integer = _plantDivisionsService.DeletePlantDivision(DelItem)
            If (rowEffect) Then
                AddSystemHistory("حذف واحد", 3)
                ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('عملیات با موفقیت انجام شد');", True)
                BindRecord()
            Else
                ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('خطا در عملیات');", True)
            End If

        ElseIf e.CommandName = "up" Then
            Dim SelectRowIndx As Integer = DirectCast(DirectCast(e.CommandSource, System.Web.UI.WebControls.ImageButton).DataItemContainer, System.Web.UI.WebControls.GridViewRow).RowIndex
            gridview1.SelectedIndex = SelectRowIndx

            Dim DivisionId As Integer = Convert.ToInt32(CLSHash.Decode(e.CommandArgument.ToString))
            Dim UpItem = _plantDivisionsService.GetOnePlantDivisions(DivisionId)

            txtDivisionLogo.Text = UpItem.DivisionIconLink
            txtOrder.Text = UpItem.DivisionOrder
            txtPersianName.Text = UpItem.NamePersian

            HFDivisionId.Value = CLSHash.Encode(UpItem.DivisionId.ToString())
        End If
    End Sub


End Class
