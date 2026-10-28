Imports System.Data.SqlClient
Imports System.Data
Imports HtmlCleaner

Partial Class PhoneBook
    Inherits AdminBasePage

    Public Property PhoneBookService As IPhonebookService


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindRecord()
        End If
    End Sub

    Public Sub BindRecord()
        gridview1.DataSource = PhoneBookService.GetPhoneBooks()
        gridview1.DataBind()
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If IsValid Then
            If txtPhonebookName.Text = "" And txtPdoneBookPlant.Text = "" Then
                ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('حد اقل یکی از موارد نام مخاطب و واحد مخاطب الزامی است!');", True)
                Return
            End If

            Dim item As New Danesh.ArvandIntranet.DomainClasses.Models.Phonebook
            item.PhonebookEmail = txtPhoneBookEmail.Text
            item.PhonebookFax = txtPhoneBookFax.Text
            item.PhonebookName = txtPhonebookName.Text
            item.PhonebookPlant = txtPdoneBookPlant.Text
            item.PhonebookTel = txtPhonebookTel.Text
            item.Remark = txtRemark.Text

            Dim rowEffect As Integer = PhoneBookService.AddPhoneBook(item)

            If (rowEffect) Then
                ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('عملیات با موفقیت انجام شد');", True)
                BindRecord()
                clear()
            Else
                ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('خطا در ثبت');", True)
            End If

        End If
    End Sub

    Private Sub clear()
        txtPdoneBookPlant.Text = ""
        txtPhoneBookEmail.Text = ""
        txtPhoneBookFax.Text = ""
        txtPhonebookName.Text = ""
        txtPhonebookTel.Text = ""
        txtRemark.Text = ""
        gridview1.SelectedIndex = -1
        PhoneBookId.Value = ""
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        clear()
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If IsValid And PhoneBookId.Value <> "" Then

            Dim item = PhoneBookService.GetOnePlantDivisions(CLSHash.Decode(PhoneBookId.Value))
            item.PhonebookEmail = txtPhoneBookEmail.Text
            item.PhonebookFax = txtPhoneBookFax.Text
            item.PhonebookName = txtPhonebookName.Text
            item.PhonebookPlant = txtPdoneBookPlant.Text
            item.PhonebookTel = txtPhonebookTel.Text
            item.Remark = txtRemark.Text

            Dim rowEffect As Integer = PhoneBookService.UpdatePhoneBook()
            If (rowEffect) Then
                ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('عملیات با موفقیت انجام شد');", True)
                BindRecord()
                clear()
            Else
                ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('خطا در عملیات');", True)
            End If
        End If

    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridview1.RowCommand
        clear()
        If (e.CommandName = "del") Then
            Dim PhoneId As Integer = Convert.ToInt32(CLSHash.Decode(e.CommandArgument.ToString))
            Dim item = PhoneBookService.GetOnePlantDivisions(PhoneId)
            Dim rowEffect As Integer = PhoneBookService.DeletePhoneBook(item)
            If (rowEffect) Then
                ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('عملیات با موفقیت انجام شد');", True)
                BindRecord()
            Else
                ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('خطا در عملیات');", True)
            End If
        ElseIf e.CommandName = "up" Then
            Dim SelectRowIndx As Integer = DirectCast(DirectCast(e.CommandSource, System.Web.UI.WebControls.ImageButton).DataItemContainer, System.Web.UI.WebControls.GridViewRow).RowIndex
            gridview1.SelectedIndex = SelectRowIndx

            Dim PhoneId As Integer = Convert.ToInt32(CLSHash.Decode(e.CommandArgument.ToString))
            Dim item = PhoneBookService.GetOnePlantDivisions(PhoneId)

            txtPdoneBookPlant.Text = item.PhonebookPlant
            txtPhoneBookEmail.Text = item.PhonebookEmail
            txtPhoneBookFax.Text = item.PhonebookFax
            txtPhonebookName.Text = item.PhonebookName
            txtPhonebookTel.Text = item.PhonebookTel
            txtRemark.Text = item.Remark

            PhoneBookId.Value = CLSHash.Encode(item.PhonebookId.ToString())
        End If
    End Sub



    Private Function GetUserDetailsFromCookie() As String()
        Dim CookieName As String = FormsAuthentication.FormsCookieName
        Dim AuthCookie As HttpCookie = Context.Request.Cookies(CookieName)
        If AuthCookie Is DBNull.Value Then
            Response.Redirect("~/SystemMng/Logout.aspx")
        End If
        Dim AuthTicket As FormsAuthenticationTicket
        Try
            AuthTicket = FormsAuthentication.Decrypt(AuthCookie.Value)
            Dim nfr As String() = AuthTicket.UserData.Split("|")
            Return nfr
        Catch ex As Exception
            Response.Redirect("~/SystemMng/Logout.aspx")
        End Try
        If AuthTicket Is DBNull.Value Then
            Response.Redirect("~/SystemMng/Logout.aspx")
        End If
    End Function



    
End Class
