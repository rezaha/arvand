
Partial Class SystemMng_DocWebpart_WebPartFileList
    Inherits AdminBasePage

    Public Property _docManagementService As IDocManagementService
    Public Property _webPartService As IWebPartService

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If RouteData.Values("id") IsNot Nothing Then
                Dim WebPartId = Convert.ToInt32(RouteData.Values("id"))
                lblWebPartName.Text = _webPartService.GetOneWebPart(WebPartId).NamePersian
                ViewState.Add("WebpartId", WebPartId)
            End If

            BindGrid()

        End If
    End Sub

    Sub BindGrid()
        gridview1.DataSource = _docManagementService.GetDocManagementsForWebpart(ViewState("WebpartId")).Where(Function(a) a.PublicGrant = False)
        gridview1.DataBind()
    End Sub
End Class
