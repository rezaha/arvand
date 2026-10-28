
Partial Class SystemMng_Logout
    Inherits System.Web.UI.Page

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        'FormsAuthentication.SignOut()
        Dim coo As HttpCookie = Request.Cookies("LoginCook")
        coo.Value = ""
        Response.Cookies.Add(coo)
        Session.RemoveAll()
        Session.Abandon()
        Response.RedirectToRoute("default-rout", New With {.PageName = "default"})
    End Sub

End Class
