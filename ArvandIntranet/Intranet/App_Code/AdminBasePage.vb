Imports Microsoft.VisualBasic
Imports StructureMap
Imports System.Threading
Imports System.Globalization

Public Class AdminBasePage
    Inherits System.Web.UI.Page

    Protected CurUrl As String
    Dim PageObj As New CLSPages
    Dim pageCls As CLSPagesItem
    Public Property SystemHistoryService As ISystemHistoryService

    Private _siteLanguage As String
    Private _siteLocation As String
    Protected _securityUser As SecurityUsers
    Protected _maxVolume As MaxVolume
    Public Property _securityUserService As ISecurityUserService
    Public Property _maxVolumeService As IMaxVolumeService
    Public Property _securityFormsGrantedService As ISecurityFormsGrantedService

    Public Sub New()
        ObjectFactory.BuildUp(Me)
        _securityUser = _securityUserService.GetOneSecurityUserByUserName(getUserName)
        _maxVolume = _maxVolumeService.GetMaxVolumeByDivisionId(_securityUser.DivisionId)
    End Sub

    Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        'Dim UserDetail() As String = GetUserDetailsFromCookie()

        CurUrl = Request.AppRelativeCurrentExecutionFilePath
        If _securityUser.UserAdmin = False And CurUrl.ToLower() <> "~/SystemMng/SecuritySystem/ChangePassword".ToLower() Then
            Dim FormUserGrant = _securityFormsGrantedService.GetOneSecurityFormsGrantedByFormName(_securityUser.UserId, CurUrl)
            If FormUserGrant Is Nothing Then
                Response.RedirectToRoute("management", New With {.pageName = "SecurityPermission"})
            End If
        End If
    End Sub

    Public Property SiteLocation As String
        Get
            If RouteData.Values("location") IsNot Nothing Then
                _siteLocation = RouteData.Values("location").ToString.ToUpper
            Else
                _siteLocation = String.Empty
            End If
            Return _siteLocation
        End Get
        Set(value As String)
            _siteLocation = value
        End Set
    End Property

    Public Property SiteLanguage As String
        Get
            If RouteData.Values("language") IsNot Nothing Then
                _siteLanguage = RouteData.Values("language").ToString.ToLower
            Else
                _siteLanguage = String.Empty
            End If
            Return _siteLanguage
        End Get
        Set(value As String)
            _siteLanguage = value
        End Set
    End Property

    Protected Function ActionGrant(ByVal ActionName As String) As Boolean
        ' Dim UserDetail() As String = GetUserDetailsFromCookie()
        If _securityUser.UserAdmin = False Then
            Dim MyFormGrant As Danesh.ArvandIntranet.DomainClasses.Models.SecurityFormsGranted = _securityFormsGrantedService.GetOneSecurityFormsGrantedByFormName(_securityUser.UserId, CurUrl)
            If (ActionName = "Insert" And MyFormGrant.InsertRecord) Or (ActionName = "Update" And MyFormGrant.UpdateRecord) Or
                (ActionName = "Delete" And MyFormGrant.DeleteRecord) Or (ActionName = "Search" And MyFormGrant.SearchRecord) Or
                (ActionName = "Aprove" And MyFormGrant.ApproveAction) Or (ActionName = "Print" And MyFormGrant.PrintRecord) Or
                (ActionName = "EtcAction" And MyFormGrant.EtcAction) Or (ActionName = "Etc2Action" And MyFormGrant.EtcAction2) Then
                Return True
            Else
                ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('مجوز این عملیات را ندارید');", True)
                Return False
            End If
        Else
            Return True
        End If
        Return False
    End Function

    ''''''''''''''''''''''''''''''''''''''''''''''
    ''''''''Security Grant
    ''''''''''''''''''''''''''''''''''''''''''''''

    Protected Function GetUserDetailsFromCookie() As String()
        Dim CookieName As String = "LoginCook"
        Dim AuthCookie As HttpCookie = Context.Request.Cookies(CookieName)
        If AuthCookie Is DBNull.Value Then
            Response.Redirect("~/Logout.aspx")
        End If
        Dim AuthTicket As FormsAuthenticationTicket
        Try
            AuthTicket = FormsAuthentication.Decrypt(AuthCookie.Value)
            Dim nfr As String() = AuthTicket.UserData.Split("|")
            Return nfr
        Catch ex As Exception
            Response.Redirect("~/Logout.aspx")
        End Try
        If AuthTicket Is DBNull.Value Then
            Response.Redirect("~/Logout.aspx")
        End If
        Response.Redirect("~/Logout.aspx")

    End Function

    Protected Function getUserName() As String
        Dim coo As HttpCookie = Context.Request.Cookies("LoginCook")
        If coo Is Nothing Then
            Context.Response.Redirect("~/defaul.aspx", True)
            Exit Function
        End If
        If coo.Value.Trim = "" Then
            Context.Response.Redirect("~/defaul.aspx", True)
            Exit Function
        End If
        Return FormsAuthentication.Decrypt(coo.Value).UserData
    End Function

    Protected Overrides Sub InitializeCulture()
        Me.Culture = "fa-IR"
        Me.UICulture = "fa-IR"
        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("fa-IR")
        Thread.CurrentThread.CurrentUICulture = New CultureInfo("fa-IR")
    End Sub

    Public Sub AddSystemHistory(ByVal formName As String, ByVal actionName As Integer)
        Dim item As New SystemHistory
        item.ActionDate = New DateTimeHelper().ConvertToPersianDate(DateTime.Now)
        item.ActionTime = New DateTimeHelper().GetFullTime(DateTime.Now)
        item.ActionName = CType(actionName, String)
        item.BrowserType = SystemTracking.UserBrowser
        item.FormName = formName
        item.TableName = ""
        item.IpAddress = SystemTracking.UserIPDns
        item.LoginUserId = _securityUser.UserId
        item.LoginUserName = _securityUser.UserName
        item.DivisionId = _securityUser.DivisionId
        item.OsName = SystemTracking.UserOs
        item.OsUser = SystemTracking.UserMachineName
        item.Remark = ""
        SystemHistoryService.AddSystemHistory(item, New Dictionary(Of String, String))
    End Sub

End Class

Public Enum NotifyIcon
    info
    delete
    deny
    edit
    ok
    warning
    none
End Enum