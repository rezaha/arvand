
Partial Class SystemMng_Login
    Inherits System.Web.UI.Page
    Dim SecurityObj As New CLSSecurityUsers


    Protected Sub ImgBtnLogin_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgBtnLogin.Click
        If ValidateUserType(txtUserName.Text, txtPwd.Text) Then
            Dim ClsUser As CLSSecurityUsersItem = SecurityObj.GetRecord(UserName:=txtUserName.Text)
            If ClsUser.User_name IsNot Nothing And ClsUser.User_password IsNot Nothing Then
                If ClsUser.User_name.ToLower = txtUserName.Text.Trim.ToLower And ClsUser.User_password = txtPwd.Text Then
                    If Not ClsUser.User_lock Then
                        Dim NFR As String = ClsUser.User_name
                        Dim tkt As New FormsAuthenticationTicket(1, "LoginCook", DateTime.Now(), DateTime.Now.AddDays(10), True, NFR)
                        Dim ck As New HttpCookie("LoginCook", FormsAuthentication.Encrypt(tkt))
                        ck.HttpOnly = False
                        ck.Secure = False
                        Dim UCk As New HttpCookie("SavedUserName", txtUserName.Text)
                        UCk.Path = FormsAuthentication.FormsCookiePath()
                        UCk.Expires = Now.AddDays(20)
                        Response.Cookies.Add(UCk)
                        'ck.Path = FormsAuthentication.FormsCookiePath()
                        Response.Cookies.Add(ck)
                        Response.RedirectToRoute("management", New With {.pageName = "Welcome"})
                        'Response.Redirect("~/SystemMng/Default")
                    Else
                        lblError.Text = "نام کاربری شما قفل شده است.مشکل را به مدیر سیستم ایمیل کنید."
                    End If
                Else
                    lblError.Text = "نام کاربری یا کلمه عبور اشتباه است."
                End If
            End If
        End If
    End Sub

    Private Function ValidateUserType(ByVal userName As String, ByVal passWord As String) As Boolean
        Dim lookupPassword As String = Nothing
        If ((userName Is Nothing)) Then
            lblError.Text = "تصدیق ورودی نام کاربری ناموفق"
            Return False
        End If
        If ((userName.Length = 0) Or (userName.Length > 15)) Then
            lblError.Text = "تصدیق ورودی نام کاربری ناموفق"
            Return False
        End If
        If (passWord Is Nothing) Then
            lblError.Text = "تصدیق ورودی کلمه عبور ناموفق"
            Return False
        End If
        If ((passWord.Length = 0) Or (passWord.Length > 25)) Then
            lblError.Text = "تصدیق ورودی کلمه عبور ناموفق"
            Return False
        End If
        Return True
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            txtPwd.Focus()
        Else
            txtUserName.Focus()
            Dim UserNameCk As HttpCookie = Context.Request.Cookies("SavedUserName")
            If UserNameCk Is Nothing Then
                txtUserName.Focus()
            Else
                txtUserName.Text = UserNameCk.Value()
                txtPwd.Focus()
            End If
        End If
    End Sub
End Class
