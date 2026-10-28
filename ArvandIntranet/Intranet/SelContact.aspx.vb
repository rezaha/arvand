Imports System.Globalization
Imports System.IO
Imports System.Reflection
Imports Danesh.ArvandIntranet.DataLayer.Context
Imports PersianCaptchaHandler

Partial Class SelContact
    Inherits BasePage

    Dim contactObj As New CLSContacts

    Public Property companyService As ICompanyService
    Public Property PlantDivisionService As IPlantDivisionsService

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init

    End Sub
    'Dim PartObj As New CLSWebparts

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'Dim company = companyService.GetOne(0)
            Dim PlantDivision = PlantDivisionService.GetOnePlantDivisions(PlantDivisions.DivisionId)
            Title = "ارتباط با " + PlantDivision.NamePersian
            CotactTextTitle.InnerHtml = "ارتباط با " + PlantDivision.NamePersian
            Using ctx As New ArvandIntranetContext
                Dim webpart = ctx.WEBPARTS.FirstOrDefault(Function(a) a.WebpartName.ToLower() = "contactinfo" And a.DivisionId = PlantDivision.DivisionId)
                If webpart IsNot Nothing Then
                    If SiteLanguage.ToLower = "en" Then
                        SelContactInfo.InnerHtml = webpart.HtmlContentLatin
                    Else
                        SelContactInfo.InnerHtml = webpart.HtmlContentPersian
                    End If
                End If
            End Using
            'If SiteLanguage.ToLower = "en" Then
            '    lblAddress.Text = company.AddressLatin
            'Else
            '    lblAddress.Text = company.AddressPersian
            'End If

            'lblRayaName.Text = company.EmailAddress
            'lblTel.Text = company.TelNo
            If SiteLanguage.ToLower = "en" Then
                imgCaptchaText.ImageUrl = GetRouteUrl("default-rout", New With {.pageName = "SecImage"})

            Else
                SetCaptcha()
            End If

        End If
    End Sub


    Public Function SetHomePageUrl() As String
        Dim url As String = GetRouteUrl("default-rout", New With {.pageName = "default"})
        Return url
    End Function

    Private Function GetCaptcha() As String
        Try
            Dim farsiAlphabatic = NumberToString.ConvertIntNumberToFarsiAlphabatic(txtCaptcha.Text)

            Dim encryptedString = HttpUtility.UrlEncode(Encryptor.Encrypt(farsiAlphabatic))

            Return encryptedString
        Catch ex As Exception
            If SiteLanguage.ToLower = "en" Then
                lblMsg.Text = "Security code is not entered correctly"
                Return "Error"
            Else
                lblMsg.Text = "کد امنیتی به طور صحیح وارد نشده است"
                Return "خطا"
            End If

        End Try

    End Function

    Private Sub SetCaptcha()
        txtCaptcha.Text = String.Empty
        'lblMessage.Text = txtCaptcha.Text

        Dim newNumber = RandomGenerator.Next(100, 999)

        Dim farsiAlphabatic = NumberToString.ConvertIntNumberToFarsiAlphabatic(newNumber.ToString())

        hfCaptchaText.Value = HttpUtility.UrlEncode(Encryptor.Encrypt(farsiAlphabatic))

        txtCaptcha.Text = String.Empty

        imgCaptchaText.ImageUrl = "/captcha/?text=" & hfCaptchaText.Value

    End Sub

    Protected Sub btnRefreshCaptcha_Click(sender As Object, e As ImageClickEventArgs) Handles btnRefreshCaptcha.Click
        If SiteLanguage.ToLower = "en" Then
            imgCaptchaText.ImageUrl = GetRouteUrl("default-rout", New With {.pageName = "SecImage"})
        Else
            SetCaptcha()
        End If
    End Sub


    Private Function ValidateUserInputForLogin() As Boolean
        If Not Utils.IsNumber(txtCaptcha.Text) Then
            If SiteLanguage.ToLower = "en" Then
                lblMsg.Text = "Security code is not entered correctly"

            Else
                lblMsg.Text = "تصویر امنیتی را بطور صحیح وارد نکرده اید"
            End If

            Return False
        End If

        Dim strGetCaptcha = GetCaptcha()

        Dim strDecodedVAlue = hfCaptchaText.Value

        If strDecodedVAlue <> strGetCaptcha Then

            If SiteLanguage.ToLower = "en" Then
                lblMsg.Text = "Security code is not entered correctly"
            Else
                lblMsg.Text = "کلمه امنیتی اشتباه است"
            End If
            SetCaptcha()
            Return False
        End If
        Return True
    End Function


    Protected Sub lnkBtnSend_Click(sender As Object, e As EventArgs) Handles lnkBtnSend.Click
        lblMsg.Text = ""

        If txtName.Text = "" Then
            If SiteLanguage.ToLower = "en" Then
                lblMsg.Text = "Please Inter Name"
            Else
                lblMsg.Text = "لطفا نام وارد شود"
            End If
            If SiteLanguage.ToLower = "fa" Then
                SetCaptcha()
            End If
            Return
        End If

        If txtEmail.Text = "" Then

            If SiteLanguage.ToLower = "en" Then
                lblMsg.Text = "Please enter the e-mai is"
            Else
                lblMsg.Text = "لطفا ایمیل وارد شود"
            End If
            If SiteLanguage.ToLower = "fa" Then
                SetCaptcha()
            End If
            Return
        End If

        If txtBody.Text = "" Then

            If SiteLanguage.ToLower = "en" Then
                lblMsg.Text = "Please enter the text"
            Else
                lblMsg.Text = "لطفا متن وارد شود"
            End If
            If SiteLanguage.ToLower = "fa" Then
                SetCaptcha()
            End If
            Return
        End If

        If txtCaptcha.Text = "" Then

            If SiteLanguage.ToLower = "en" Then
                lblMsg.Text = "Enter Security Code"
            Else
                lblMsg.Text = "کد امنیتی وارد شود"
            End If
            If SiteLanguage.ToLower = "fa" Then
                SetCaptcha()
            End If
            Return
        End If

        If SiteLanguage.ToLower = "en" Then
            If Session("randomStr").ToString().ToLower() = txtCaptcha.Text.ToLower() Then
            Else
                lblMsg.Text = "Captcha Code Is Incorrect"
                Return
            End If
        Else
            If Not ValidateUserInputForLogin() Then
                Return
            End If
        End If

        Dim PlantDivision = PlantDivisionService.GetOnePlantDivisions(PlantDivisions.DivisionId)

        Dim Contact As New CLSContectsItem
        Contact.ContactDate = CLSShamsiDate.ShortDate(Now)
        Contact.ContactEmail = txtEmail.Text
        Contact.ContactName = txtName.Text
        Contact.ContactSubject = ""
        Contact.ContactText = txtBody.Text
        Contact.ContactType = 2
        Contact.Division.Division_id = PlantDivision.DivisionId
        Contact.IsDelete = False
        Contact.IsRead = False
        Contact.ContactTime = GtTime(Now)
        Dim RowEffect As Integer = contactObj.Insert(Contact)
        If RowEffect Then
            If SiteLanguage.ToLower = "en" Then
                lblMsg.Text = "Your request has been successfully recorded."
            Else
                lblMsg.Text = "درخواست شما با موفقیت ثبت شد."
            End If


            Cleare()
        Else
            If SiteLanguage.ToLower = "en" Then
                lblMsg.Text = ""
            Else
                lblMsg.Text = "Error Message"
            End If


        End If
    End Sub

    Function GtTime(ByVal DateT As Date) As String
        Dim Hour As String = DateT.Hour
        Dim Minute As String = DateT.Minute

        If Hour.Length = 1 Then
            Hour = "0" & Hour
        End If

        If Minute.Length = 1 Then
            Minute = "0" & Minute
        End If

        Return Hour & ":" & Minute

    End Function

    Sub Cleare()
        txtCaptcha.Text = ""
        txtName.Text = ""
        txtBody.Text = ""
        txtEmail.Text = ""
    End Sub

    Protected Sub lnkBtnResend_Click(sender As Object, e As EventArgs) Handles lnkBtnResend.Click
        Cleare()
    End Sub

    Protected Sub Page_LoadComplete1(sender As Object, e As EventArgs) Handles Me.LoadComplete
        'Page.Title = GetGlobalResourceObject("SharedResource", "pageName_Contact_SELL")
    End Sub

End Class
