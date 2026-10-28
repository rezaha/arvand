
Partial Class SystemMng_SiteSettings
    Inherits AdminBasePage

    Public Property _plantDivisionsService As IPlantDivisionsService
    Public Property _themeService As IThemeService

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not IsPostBack Then
            AddSystemHistory("نمایش تنظیمات سایت", 0)
            Dim _plantDivisions = _plantDivisionsService.GetOnePlantDivisions(_securityUser.DivisionId)
            lblDivisionName.Text = _plantDivisions.NamePersian
            txtPersianImageLink.Text = _plantDivisions.HeaderImagePersianLink
            txtImageLink2.Text = _plantDivisions.HeaderImageLatinLink
            For Each item In _themeService.GetAllThemes
                drpThems.Items.Add(New ListItem(item.THEME_NAME, item.THEME_ID))
            Next
            drpThems.SelectedValue = _plantDivisions.ThemeId
            If _plantDivisions.PageSize.HasValue Then
                txtPageSize.Text = _plantDivisions.PageSize
            End If
        End If

    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If IsValid Then
            Dim _plantDivisions As Danesh.ArvandIntranet.DomainClasses.Models.PlantDivisions = _plantDivisionsService.GetOnePlantDivisions(_securityUser.DivisionId)
            _plantDivisions.HeaderImageLatinLink = txtImageLink2.Text
            _plantDivisions.HeaderImagePersianLink = txtPersianImageLink.Text
            _plantDivisions.ActiveLatinSite = True
            _plantDivisions.ThemeId = drpThems.SelectedValue
            If String.IsNullOrEmpty(txtPageSize.Text.Trim()) Then
                _plantDivisions.PageSize = Nothing
            Else
                Dim pageSize = Convert.ToInt32(txtPageSize.Text)
                If (pageSize < 960) Or (1280 < pageSize) Then
                    ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('خطا.اندازه صفحه بین 960 تا 1280 میتواند باشد.');", True)
                    Return
                End If
                _plantDivisions.PageSize = pageSize
            End If
            Dim result As Integer = _plantDivisionsService.UpdatePlantDivisions(_plantDivisions)
            If result >= 0 Then
                AddSystemHistory("ویرایش تنظیمات سایت", 2)
                ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('عملیات با موفقیت انجام شد');", True)
            Else
                ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('خطا در ثبت');", True)
            End If
        End If
    End Sub
End Class
