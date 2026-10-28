Imports System.IO

Partial Class SystemMng_Define_About
    Inherits AdminBasePage

    Public Property PlantDivisionService As IPlantDivisionsService

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load


        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not IsPostBack Then
            Dim PlantDivision = PlantDivisionService.GetOnePlantDivisions(_securityUser.DivisionId)
            txtHtml_content_persian_summary.Content = PlantDivision.HtmlContactusPersianSummary
            txtHtml_content_persian.Content = PlantDivision.HtmlContactusPersian
            DialogSetting()
            AddSystemHistory("نمایش پیغام فوری", 0)
        End If
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim PlantDivision = PlantDivisionService.GetOnePlantDivisions(_securityUser.DivisionId)
        PlantDivision.HtmlContactusLatin = ""
        PlantDivision.HtmlContactusPersian = txtHtml_content_persian.Content
        PlantDivision.HtmlContactusLatinSummary = ""
        PlantDivision.HtmlContactusPersianSummary = txtHtml_content_persian_summary.Content
        Dim eff = PlantDivisionService.UpdatePlantDivisions(PlantDivision)
        If eff > 0 Then
            AddSystemHistory("ویرایش پیغام فوری", 2)
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType, "2", "alert('عملیات با موفقیت انجام شد')", True)
        Else
            ScriptManager.RegisterClientScriptBlock(Me, Me.GetType, "2", "alert('خطا در عملیات')", True)
        End If
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


        txtHtml_content_persian_summary.ImageManager.ViewPaths = paths
        txtHtml_content_persian_summary.ImageManager.UploadPaths = paths
        txtHtml_content_persian_summary.ImageManager.DeletePaths = paths
        txtHtml_content_persian_summary.ImageManager.MaxUploadFileSize = (_maxVolume.MaxFileVolume * 1024)

        txtHtml_content_persian_summary.DocumentManager.ViewPaths = paths
        txtHtml_content_persian_summary.DocumentManager.UploadPaths = paths
        txtHtml_content_persian_summary.DocumentManager.DeletePaths = paths
        txtHtml_content_persian_summary.DocumentManager.MaxUploadFileSize = (_maxVolume.MaxFileVolume * 1024)
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
