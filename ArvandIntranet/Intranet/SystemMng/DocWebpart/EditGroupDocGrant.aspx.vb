
Partial Class SystemMng_DocWebpart_EditGroupDocGrant
    Inherits AdminBasePage

    Public Property _webPartService As IWebPartService
    Public Property _docManagementService As IDocManagementService
    Public Property _docGrantService As IDocGrantService

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If RouteData.Values("id") IsNot Nothing Then
                Dim WebPartId = Convert.ToInt32(RouteData.Values("id"))
                lblWebPartName.Text = _webPartService.GetOneWebPart(WebPartId).NamePersian
                ViewState.Add("WebpartId", WebPartId)
                BindList()
            End If
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

    Sub BindList()
        Dim WebPartDocument = _docManagementService.GetDocManagementsForWebpart(ViewState("WebpartId")).Where(Function(a) a.PublicGrant = False)
        Dim DocGrantList = _docGrantService.GetDocGrantByWebPartId(ViewState("WebpartId"))
        lstUserNames.Items.Clear()
        For Each item In DocGrantList
            If item.Count = WebPartDocument.Count Then
                lstUserNames.Items.Add(New ListItem With {.Text = item.UserName, .Value = item.UserName})
            End If
        Next
    End Sub


    Protected Sub btnAddUser_Click(sender As Object, e As EventArgs) Handles btnAddUser.Click
        Try
            If txtDomainUserName.Text = "" Then
                ShowMessage(Content:="لطفا نام کاربر وارد شود")
                Return
            End If

            Dim WebPartDocument = _docManagementService.GetDocManagementsForWebpart(ViewState("WebpartId")).Where(Function(a) a.PublicGrant = False)
            Dim RowEffect As Integer = 0
            For Each item In WebPartDocument
                Dim FindDocGrant = _docGrantService.GetDocGrantByDocIdUserName(item.DocId, txtDomainUserName.Text.ToLower())
                If FindDocGrant.Count = 0 Then
                    Dim DocGrant As New DocGrant
                    DocGrant.UserDomain = txtDomainUserName.Text
                    DocGrant.DocId = item.DocId
                    RowEffect += _docGrantService.AddDocGrant(DocGrant)
                End If
            Next

            If RowEffect > 0 Then
                txtDomainUserName.Text = ""
                BindList()
            Else
                ShowMessage(Content:="فایلی یافت نشد")
            End If
        Catch ex As Exception
            ShowMessage(Content:="خطا در عملیات")
        End Try
    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If lstUserNames.SelectedItem IsNot Nothing Then
            Dim WebPartDocument = _docManagementService.GetDocManagementsForWebpart(ViewState("WebpartId")).Where(Function(a) a.PublicGrant = False)
            For Each item In WebPartDocument
                Dim DocGrant = _docGrantService.GetDocGrantByDocIdUserName(item.DocId, lstUserNames.SelectedItem.Value).FirstOrDefault()
                If DocGrant IsNot Nothing Then
                    Dim RowEffect As Integer = _docGrantService.DeleteDocGrant(DocGrant)
                End If
            Next
            BindList()
        End If
    End Sub
End Class
