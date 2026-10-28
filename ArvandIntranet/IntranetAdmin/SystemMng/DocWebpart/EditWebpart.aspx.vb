
Partial Class SystemMng_DocWebpart_EditWebpart
    Inherits AdminBasePage

    Public Property _docManagementService As IDocManagementService
    Public Property _webPartService As IWebPartService

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If RouteData.Values("id") IsNot Nothing Then
                Dim WebPartId = Convert.ToInt32(RouteData.Values("id"))
                txtWebPartName.Text = _webPartService.GetOneWebPart(WebPartId).NamePersian
                ViewState.Add("WebpartId", WebPartId)
            End If
        End If
    End Sub

   
    Protected Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If txtWebPartName.Text = "" Then
            ShowMessage(Content:="لطفا نام وب پارت وارد شود")
            Return
        End If
        Dim RowEffect As Integer = 0
        Dim webPart = _webPartService.GetOneWebPart(ViewState("WebpartId"))
        webPart.NamePersian = txtWebPartName.Text
        webPart.HeaderPersian = txtWebPartName.Text
        RowEffect = _webPartService.EditWebPart(webPart)
        If RowEffect > 0 Then
            ShowMessage(Content:="عملیات با موفقیت انجام شد")
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "close", "setTimeout(""ClosePopupWindow()"", 2000);", True)
        Else
            ShowMessage(Content:="بدون تغییرات")
        End If
    End Sub

    Private Sub ShowMessage(Optional ByVal Title As String = "پیام سیستم", Optional ByVal Content As String = "",
    Optional ByVal TitleIcon As NotifyIcon = NotifyIcon.none, Optional ByVal ContentIcon As NotifyIcon = NotifyIcon.none)
        NotifyMessage.Text = Content
        NotifyMessage.Title = Title
        NotifyMessage.TitleIcon = TitleIcon.ToString
        NotifyMessage.ContentIcon = ContentIcon.ToString
        NotifyMessage.Show()
    End Sub
End Class
