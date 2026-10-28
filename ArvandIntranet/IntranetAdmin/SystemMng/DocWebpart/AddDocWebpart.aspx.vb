
Partial Class SystemMng_DocWebpart_AddDocWebpart
    Inherits AdminBasePage


    Public Property _webPartService As IWebPartService
    Public Property _docManagementService As IDocManagementService

    Protected Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Page.Validate("p")
        If IsValid() Then
            pnlWebpartName.Visible = False
            pnlFiles.Visible = True
            ViewState.Add("WebPartId", 0)
            ViewState.Add("DocId", 0)
        End If
    End Sub

    Private Sub ShowMessage(Optional ByVal Title As String = "پیام سیستم", Optional ByVal Content As String = "",
Optional ByVal TitleIcon As NotifyIcon = NotifyIcon.none, Optional ByVal ContentIcon As NotifyIcon = NotifyIcon.none)
        NotifyMessage.Text = Content
        NotifyMessage.Title = Title
        NotifyMessage.TitleIcon = TitleIcon.ToString
        NotifyMessage.ContentIcon = ContentIcon.ToString
        NotifyMessage.Show()
    End Sub

    Sub BindRecord()
        If Int32.Parse(ViewState("WebPartId")) <> 0 Then
            gridview1.DataSource = _docManagementService.GetDocManagementsForWebpart(Int32.Parse(ViewState("WebPartId")))
            gridview1.DataBind()
        End If
    End Sub

    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Int32.Parse(ViewState("DocId")) = 0 Then
            Try
                Dim Doc As New DocManagement
                Doc.PublicGrant = chkPublicGrant.Checked
                Doc.DocUrl = txt_FileAddress.Text
                Doc.DocTitle = txtFileTitle.Text
                If Int32.Parse(ViewState("WebPartId")) <> 0 Then
                    Doc.WebPartId = Int32.Parse(ViewState("WebPartId"))
                    Dim RowEffect As Integer = _docManagementService.AddDocManagement(Doc)

                    If RowEffect > 0 Then
                        AddSystemHistory("اضافه کردن سند جدید", 1)
                        ShowMessage(Content:="فایل با موفقیت اضافه شد")
                    Else
                        ShowMessage(Content:="خطا در عملیات")
                    End If
                Else
                    Dim WebpartNeme = "DocumentWebpart" & (_webPartService.GetMaxWebpartId() + 1).ToString()
                    Dim NewWebpart As New Danesh.ArvandIntranet.DomainClasses.Models.Webpart
                    NewWebpart.Active = True
                    NewWebpart.DescriptionLatin = ""
                    NewWebpart.DescriptionPersian = ""
                    NewWebpart.DivisionId = _securityUser.DivisionId
                    NewWebpart.HeaderLatin = ""
                    NewWebpart.HeaderPersian = txtHeader_persian.Text
                    NewWebpart.HtmlContentLatin = ""
                    NewWebpart.HtmlContentPersian = ""
                    NewWebpart.NameLatin = ""
                    NewWebpart.NamePersian = txtHeader_persian.Text
                    NewWebpart.Remark = ""
                    NewWebpart.WebpartAddress = "~/UserControls/DocManagementWUC.ascx"
                    NewWebpart.WebpartGroup = 2
                    NewWebpart.WebpartMethod = ""
                    NewWebpart.WebpartType = 3
                    NewWebpart.WebpartParametrs = ""
                    NewWebpart.WebpartNo = 1
                    NewWebpart.WebpartName = WebpartNeme
                    Dim RowEffect = _webPartService.AddWebPart(NewWebpart)
                    Doc.WebPartId = NewWebpart.WebpartId
                    ViewState("WebPartId") = NewWebpart.WebpartId
                    RowEffect = _docManagementService.AddDocManagement(Doc)
                    If RowEffect > 0 Then
                        AddSystemHistory("اضافه کردن سند جدید", 1)

                    Else
                        ShowMessage(Content:="خطا در عملیات")
                    End If
                End If
                BindRecord()
                Clear()
            Catch ex As Exception
                ShowMessage(Content:="خطا در عملیات")
            End Try
        Else
            Try
                Dim DocManagement = _docManagementService.GetOneDocManagement(Int32.Parse(ViewState("DocId")))
                DocManagement.DocTitle = txtFileTitle.Text
                DocManagement.DocUrl = txt_FileAddress.Text
                DocManagement.PublicGrant = chkPublicGrant.Checked

                Dim Rf As Integer = _docManagementService.EditDocManagement(DocManagement)
                If Rf > 0 Then
                    AddSystemHistory("ویرایش سند", 2)

                    ViewState("DocId") = 0
                    btnAdd.Text = "اضافه کردن فایل"
                    BindRecord()
                    Clear()
                Else
                    ShowMessage(Content:="بدون تغییرات")
                    ViewState("DocId") = 0
                    btnAdd.Text = "اضافه کردن فایل"
                    Clear()
                End If
            Catch ex As Exception
                ShowMessage(Content:="خطا در عملیات")
            End Try
        End If

    End Sub

    Sub Clear()
        txt_FileAddress.Text = ""
        txtFileTitle.Text = ""
        chkPublicGrant.Checked = False
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
        End If
    End Sub

    Protected Sub gridview1_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles gridview1.ItemCommand
        If e.CommandName = "row-del" Then
            Try
                Dim DocManagement = _docManagementService.GetOneDocManagement(e.CommandArgument)
                Dim rowEffect As Integer = _docManagementService.DeleteDocManagement(DocManagement)
                If rowEffect > 0 Then
                    ShowMessage(Content:="فایل با موفقیت حذف شد")
                    BindRecord()
                Else
                    ShowMessage(Content:="خطا در عملیات")
                End If
            Catch ex As Exception
                ShowMessage(Content:="خطا در عملیات")
            End Try
        ElseIf e.CommandName = "row-up" Then
            Dim DocManagement = _docManagementService.GetOneDocManagement(e.CommandArgument)
            txt_FileAddress.Text = DocManagement.DocUrl
            txtFileTitle.Text = DocManagement.DocTitle
            chkPublicGrant.Checked = DocManagement.PublicGrant
            ViewState("DocId") = DocManagement.DocId
            btnAdd.Text = "به روز رسانی"
        End If
    End Sub

End Class
