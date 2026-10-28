
Partial Class MasterPage
    Inherits System.Web.UI.MasterPage
    Dim user As SecurityUsers
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        'Dim ArgTicket() As String = GetUserDetailsFromCookie()
        Dim _securityUserService As ISecurityUserService = StructureMap.ObjectFactory.GetInstance(Of ISecurityUserService)()
        user = _securityUserService.GetOneSecurityUserByUserName(getUserName)
        If user Is Nothing Then
            Response.RedirectToRoute("default-rout", New With {.pageName = "default"})
            Exit Sub
        End If
        lblUserName.InnerText = user.FirstName & " " & user.LastName
    End Sub

    'Private Function GetUserDetailsFromCookie() As String()
    '    Dim CookieName As String = FormsAuthentication.FormsCookieName
    '    Dim AuthCookie As HttpCookie = Context.Request.Cookies(CookieName)
    '    If AuthCookie Is DBNull.Value Then
    '        Response.Redirect("~/SystemMng/Logout.aspx")
    '    End If
    '    Dim AuthTicket As FormsAuthenticationTicket
    '    Try
    '        AuthTicket = FormsAuthentication.Decrypt(AuthCookie.Value)
    '        Dim nfr As String() = AuthTicket.UserData.Split("|")
    '        Return nfr
    '    Catch ex As Exception
    '        Response.Redirect("~/SystemMng/Logout.aspx")
    '    End Try
    '    If AuthTicket Is DBNull.Value Then
    '        Response.Redirect("~/SystemMng/Logout.aspx")
    '    End If
    '    Response.Redirect("~/SystemMng/Logout.aspx")
    'End Function


    Protected Function getUserName() As String
        Dim coo As HttpCookie = Request.Cookies("LoginCook")
        If coo Is Nothing Then
            Response.Redirect("~/defaul.aspx", True)
            Exit Function
        End If
        If coo.Value.Trim = "" Then
            Response.Redirect("~/defaul.aspx", True)
            Exit Function
        End If
        Return FormsAuthentication.Decrypt(coo.Value).UserData
    End Function

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        'lnkFileManager.HRef = GetRouteUrl("default-rout", New With {.pageName = "Explorer", .id = 5})
        Page.Header.DataBind()
        If user.DivisionId = 0 And user.UserAdmin = True Then
            plantLink.Visible = True
            lnkMaxVolume.Visible = True
            'SiteSetting.Visible = True
            lnkUserManagement.Visible = True
            lnkSecurityGrant.Visible = True
        Else
            plantLink.Visible = False
            lnkMaxVolume.Visible = False
            'SiteSetting.Visible = False
            lnkUserManagement.Visible = False
            lnkSecurityGrant.Visible = False
        End If
    End Sub

End Class

