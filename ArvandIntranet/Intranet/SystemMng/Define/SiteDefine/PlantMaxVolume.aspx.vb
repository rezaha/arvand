
Partial Class SystemMng_Define_SiteDefine_PlantMaxVolume
    Inherits AdminBasePage

    Public Property _plantDivisionsService As IPlantDivisionsService

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            AddSystemHistory("نمایش حداکثر حجم فایل واحد", 0)
            If _securityUser.DivisionId <> 0 Or _securityUser.UserAdmin = False Then
                ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('شما اجازه دسترسی به این بخش را ندارید');", True)
                Response.RedirectToRoute("management", New With {.pageName = "Welcome"})
            Else
                grdMaxVolume.DataSource = _plantDivisionsService.AllPlantDivision()
                grdMaxVolume.DataBind()
                BindGridData()
            End If
        End If
    End Sub

    Sub BindGridData()
        Dim MaxValuesItems = _maxVolumeService.AllMaxVolumes()
        For Each row As GridViewRow In grdMaxVolume.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim hfDivisionId As HiddenField = row.FindControl("hfDivisionId")
                Dim txtMaxDivisionVolume As TextBox = row.FindControl("txtMaxDivisionVolume")
                Dim DivisionId As Integer = Convert.ToInt32(hfDivisionId.Value)
                Dim maxValueItem = MaxValuesItems.FirstOrDefault(Function(a) a.DivisionId = DivisionId)
                If maxValueItem IsNot Nothing Then
                    If maxValueItem.MaxFileVolume > 0 Then
                        txtMaxDivisionVolume.Text = maxValueItem.MaxFileVolume
                    Else
                        txtMaxDivisionVolume.Text = ""
                    End If
                Else
                    txtMaxDivisionVolume.Text = ""
                End If
            End If
        Next
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        For Each row As GridViewRow In grdMaxVolume.Rows
            If row.RowType = DataControlRowType.DataRow Then
                Dim hfDivisionId As HiddenField = row.FindControl("hfDivisionId")
                Dim txtMaxDivisionVolume As TextBox = row.FindControl("txtMaxDivisionVolume")
                Dim DivisionId As Integer = Convert.ToInt32(hfDivisionId.Value)
                Dim maxValueItem = _maxVolumeService.GetMaxVolumeByDivisionId(DivisionId)

                Dim Err As New Dictionary(Of String, String)
                If maxValueItem IsNot Nothing Then
                    maxValueItem.MaxFileVolume = Convert.ToInt32(txtMaxDivisionVolume.Text)
                    _maxVolumeService.EditMaxVolume(maxValueItem, Err)
                Else
                    Dim NewItem As New MaxVolume
                    NewItem.DivisionId = DivisionId
                    NewItem.MaxFileVolume = Convert.ToInt32(txtMaxDivisionVolume.Text)
                    _maxVolumeService.AddMaxVolume(NewItem, Err)
                End If
            End If
        Next
        BindGridData()
        AddSystemHistory("ویرایش حداکثر حجم فایل واحد", 2)
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "1", "alert('عملیات با موفقیت انجام شد.')", True)
    End Sub
End Class
