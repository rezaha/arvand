Imports Microsoft.VisualBasic

Public Class CLS_BASE_MANAGERS
    Inherits System.Web.UI.Page

    Dim SecurityFormsGranted As New CLSSecurityFormsGranted
    Protected FormUserGrant As CLSSecurityFormsGrantedItem

    Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Dim UserDetail() As String = GetUserDetailsFromCookie()
       
        FormUserGrant = SecurityFormsGranted.GetGrantes(UserId:=UserDetail(0), FormName:=Get_Cur_Path, TabNo:="1")
        If FormUserGrant.SecurityUser Is Nothing Then
            Response.Redirect("~/SystemMng/SecurityPermission.aspx")
        End If
        If FormUserGrant.SecurityUser.User_id = 0 Then
            Response.Redirect("~/SystemMng/SecurityPermission.aspx")
        End If
    End Sub

    Protected Function ActionGrant(ByVal ActionName As String, ByVal TabNo As String) As Boolean
        Dim UserDetail() As String = GetUserDetailsFromCookie()
        Dim MyFormGrant As CLSSecurityFormsGrantedItem = SecurityFormsGranted.GetRecord(UserName:=UserDetail(1), FormName:=Get_Cur_Path, TabNo:=TabNo)
        If (ActionName = "Insert" And MyFormGrant.InsertRecord) Or (ActionName = "Update" And MyFormGrant.UpdateRecord) Or
            (ActionName = "Delete" And MyFormGrant.DeleteRecord) Or (ActionName = "Search" And MyFormGrant.SearchRecord) Or
            (ActionName = "Aprove" And MyFormGrant.ApproveAction) Or (ActionName = "Print" And MyFormGrant.PrintRecord) Or
            (ActionName = "EtcAction" And MyFormGrant.EtcAction) Or (ActionName = "Etc2Action" And MyFormGrant.Etc2Action) Then
            Return True
        Else
            ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('مجوز این عملیات را ندارید');", True)
            Return False
        End If
        Return False
    End Function

    Protected Function Get_Cur_Path() As String
        Dim App_Path As String = Request.ApplicationPath
        Dim CurPath As String = Request.Url.AbsolutePath
        If CurPath.IndexOf(App_Path) = 0 Then
            CurPath = CurPath.Substring(App_Path.Length + 1)
        Else
            CurPath = CurPath.Substring(1)
        End If
        Return CurPath
    End Function
    ''''''''''''''''''''''''''''''''''''''''''''''
    ''''''''Security Grant
    ''''''''''''''''''''''''''''''''''''''''''''''

    Private Function GetUserDetailsFromCookie() As String()
        Dim CookieName As String = FormsAuthentication.FormsCookieName
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

End Class
