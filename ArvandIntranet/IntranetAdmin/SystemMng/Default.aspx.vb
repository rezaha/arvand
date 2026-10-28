
Partial Class _Default
    Inherits AdminBasePage

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        'Dim ArgTicket() As String = GetUserDetailsFromCookie()
        
    End Sub

    'Private Function GetUserDetailsFromCookie() As String()
    '    Dim CookieName As String = FormsAuthentication.FormsCookieName
    '    Dim AuthCookie As HttpCookie = Context.Request.Cookies(CookieName)
    '    If AuthCookie Is DBNull.Value Then
    '        Response.Redirect("~/Logout.aspx")
    '    End If
    '    Dim AuthTicket As FormsAuthenticationTicket
    '    Try
    '        AuthTicket = FormsAuthentication.Decrypt(AuthCookie.Value)
    '        Dim nfr As String() = AuthTicket.UserData.Split("|")
    '        Return nfr
    '    Catch ex As Exception
    '        Response.Redirect("~/Logout.aspx")
    '    End Try
    '    If AuthTicket Is DBNull.Value Then
    '        Response.Redirect("~/Logout.aspx")
    '    End If
    '    Response.Redirect("~/Logout.aspx")
    'End Function


End Class
