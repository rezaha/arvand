
Partial Class SystemMng_DocWebpart_EditDocGrant
    Inherits AdminBasePage

    Public Property _docManagementService As IDocManagementService
    Public Property _docGrantService As IDocGrantService

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If RouteData.Values("id") IsNot Nothing Then
                Dim DocId = Convert.ToInt32(RouteData.Values("id"))
                Dim DocumentFile = _docManagementService.GetOneDocManagement(DocId)
                lblFileName.Text = DocumentFile.DocTitle
                ViewState.Add("DocId", DocumentFile.DocId)
                BindList()
            End If
        End If
    End Sub

    Sub BindList()
        lstUserNames.Items.Clear()
        For Each Item In _docGrantService.GetDocGrantByDocId(ViewState("DocId"))
            lstUserNames.Items.Add(New ListItem With {.Text = Item.UserDomain, .Value = Item.UserDomain})
        Next
    End Sub

    Private Sub ShowMessage(Optional ByVal Title As String = "پیام سیستم", Optional ByVal Content As String = "",
    Optional ByVal TitleIcon As NotifyIcon = NotifyIcon.none, Optional ByVal ContentIcon As NotifyIcon = NotifyIcon.none)
        NotifyMessage.Text = Content
        NotifyMessage.Title = Title
        NotifyMessage.TitleIcon = TitleIcon.ToString
        NotifyMessage.ContentIcon = ContentIcon.ToString
        NotifyMessage.Show()
    End Sub

    Protected Sub btnAddUser_Click(sender As Object, e As EventArgs) Handles btnAddUser.Click
        Try
            If txtDomainUserName.Text = "" Then
                ShowMessage(Content:="لطفا نام کاربر وارد شود")
                Return
            End If
            Dim DocGrant As New DocGrant
            DocGrant.DocId = ViewState("DocId")
            DocGrant.UserDomain = txtDomainUserName.Text
            Dim RowEffect As Integer = _docGrantService.AddDocGrant(DocGrant)
            If RowEffect > 0 Then
                txtDomainUserName.Text = ""
                BindList()
            Else
                ShowMessage(Content:="خطا در عملیات")
            End If
        Catch ex As Exception
            ShowMessage(Content:="خطا در عملیات")
        End Try
    End Sub

    Protected Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If lstUserNames.SelectedItem IsNot Nothing Then
            Dim DocGrant = _docGrantService.GetDocGrantByDocIdUserName(ViewState("DocId"), lstUserNames.SelectedItem.Value).FirstOrDefault()
            If DocGrant IsNot Nothing Then
                Dim RowEffect As Integer = _docGrantService.DeleteDocGrant(DocGrant)
                If RowEffect > 0 Then
                    BindList()
                End If
            End If
        End If
    End Sub
End Class
