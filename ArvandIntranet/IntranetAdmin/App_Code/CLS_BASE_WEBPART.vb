Imports Microsoft.VisualBasic

Public Class CLS_BASE_WEBPART
    Inherits System.Web.UI.UserControl

    Public SiteLang As String

    Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Dim langCookie As HttpCookie = Request.Cookies("site-config")
        SiteLang = langCookie.Values("lang").ToLower
    End Sub
End Class
