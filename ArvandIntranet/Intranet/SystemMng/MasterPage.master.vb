Imports StructureMap

Partial Class MasterPage
    Inherits System.Web.UI.MasterPage
    Dim user As SecurityUsers
    Public Property _securityUserService As ISecurityUserService
    Public Property _securityFormsGrantedService As ISecurityFormsGrantedService
    Public Sub New()
        ObjectFactory.BuildUp(Me)
    End Sub
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
        Dim securityUser = _securityUserService.GetOneSecurityUserByUserName(getUserName)
        Dim FormUserGrants = _securityFormsGrantedService.GetSecurityFormsGranted(securityUser.UserId)

        If securityUser.UserAdmin Or FormUserGrants.Any(Function(a) a.SecurityForm.FormTag.ToLower() = "~/SystemMng/PageAction/DesignHomePage".ToLower()) Then
            DesignHomePage.Visible = True
        Else
            DesignHomePage.Visible = False
        End If
        If securityUser.UserAdmin Or FormUserGrants.Any(Function(a) a.SecurityForm.FormTag.ToLower() = "~/SystemMng/PageAction/LogicalPage".ToLower()) Then
            LogicalPage.Visible = True
        Else
            LogicalPage.Visible = False
        End If
        If securityUser.UserAdmin Or FormUserGrants.Any(Function(a) a.SecurityForm.FormTag.ToLower() = "~/SystemMng/Define/SiteDefine/DefinePolls".ToLower()) Then
            DefinePolls.Visible = True
        Else
            DefinePolls.Visible = False
        End If
        If securityUser.UserAdmin Or FormUserGrants.Any(Function(a) a.SecurityForm.FormTag.ToLower() = "~/SystemMng/Define/SiteDefine/PollsAnswers".ToLower()) Then
            PollsAnswers.Visible = True
        Else
            PollsAnswers.Visible = False
        End If
        If securityUser.UserAdmin Or FormUserGrants.Any(Function(a) a.SecurityForm.FormTag.ToLower() = "~/SystemMng/Define/SiteDefine/UserWebPart".ToLower()) Then
            UserWebPart.Visible = True
        Else
            UserWebPart.Visible = False
        End If
        If securityUser.UserAdmin Or FormUserGrants.Any(Function(a) a.SecurityForm.FormTag.ToLower() = "~/SystemMng/Define/SiteDefine/Menu".ToLower()) Then
            Menu.Visible = True
        Else
            Menu.Visible = False
        End If
        If securityUser.UserAdmin Or FormUserGrants.Any(Function(a) a.SecurityForm.FormTag.ToLower() = "~/SystemMng/PageAction/Albums/MainGallery".ToLower()) Then
            MainGallery.Visible = True
        Else
            MainGallery.Visible = False
        End If
        If securityUser.UserAdmin Or FormUserGrants.Any(Function(a) a.SecurityForm.FormTag.ToLower() = "~/SystemMng/Define/SiteDefine/SiteLink".ToLower()) Then
            SiteLink.Visible = True
        Else
            SiteLink.Visible = False
        End If
        If securityUser.UserAdmin Or FormUserGrants.Any(Function(a) a.SecurityForm.FormTag.ToLower() = "~/SystemMng/Define/SiteDefine/Softwares".ToLower()) Then
            Softwares.Visible = True
        Else
            Softwares.Visible = False
        End If
        If securityUser.UserAdmin Or FormUserGrants.Any(Function(a) a.SecurityForm.FormTag.ToLower() = "~/SystemMng/PageAction/About".ToLower()) Then
            About.Visible = True
        Else
            About.Visible = False
        End If
        If securityUser.UserAdmin Or FormUserGrants.Any(Function(a) a.SecurityForm.FormTag.ToLower() = "~/SystemMng/SiteSettings".ToLower()) Then
            SiteSettings.Visible = True
        Else
            SiteSettings.Visible = False
        End If
        If securityUser.UserAdmin Or FormUserGrants.Any(Function(a) a.SecurityForm.FormTag.ToLower() = "~/SystemMng/Define/SiteDefine/PlantMaxVolume".ToLower()) Then
            PlantMaxVolume.Visible = True
        Else
            PlantMaxVolume.Visible = False
        End If
        If securityUser.UserAdmin Or FormUserGrants.Any(Function(a) a.SecurityForm.FormTag.ToLower() = "~/SystemMng/DocWebpart/DocWebpartList".ToLower()) Then
            DocWebpartList.Visible = True
        Else
            DocWebpartList.Visible = False
        End If
        If securityUser.UserAdmin Or FormUserGrants.Any(Function(a) a.SecurityForm.FormTag.ToLower() = "~/SystemMng/SecuritySystem/SecurityUser".ToLower()) Then
            SecurityUserLink.Visible = True
        Else
            SecurityUserLink.Visible = False
        End If
        If securityUser.UserAdmin Or FormUserGrants.Any(Function(a) a.SecurityForm.FormTag.ToLower() = "~/SystemMng/SecuritySystem/SecurityFormsGranted".ToLower()) Then
            SecurityFormsGranted.Visible = True
        Else
            SecurityFormsGranted.Visible = False
        End If
        If securityUser.UserAdmin Or FormUserGrants.Any(Function(a) a.SecurityForm.FormTag.ToLower() = "~/SystemMng/SecuritySystem/ShowHistory".ToLower()) Then
            ShowHistory.Visible = True
        Else
            ShowHistory.Visible = False
        End If
        If securityUser.UserAdmin Or FormUserGrants.Any(Function(a) a.SecurityForm.FormTag.ToLower() = "~/SystemMng/Define/ShowHouseCooperative".ToLower()) Then
            ShowHouseCooperative.Visible = True
        Else
            ShowHouseCooperative.Visible = False
        End If
        If securityUser.UserAdmin Or FormUserGrants.Any(Function(a) a.SecurityForm.FormTag.ToLower() = "~/SystemMng/PageAction/SelContact".ToLower()) Then
            SelContact.Visible = True
        Else
            SelContact.Visible = False
        End If

        If user.DivisionId = 0 And user.UserAdmin = True Then
            PlantDivision.Visible = True
            lnkMaxVolume.Visible = True
            'SiteSetting.Visible = True
            lnkUserManagement.Visible = True
            lnkSecurityGrant.Visible = True
        Else
            PlantDivision.Visible = False
            lnkMaxVolume.Visible = False
            'SiteSetting.Visible = False
            lnkUserManagement.Visible = False
            lnkSecurityGrant.Visible = False
        End If
    End Sub

End Class

