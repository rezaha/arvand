
Partial Class SystemMng_DocWebpart_DocWebpartList
    Inherits AdminBasePage

    Public Property _docManagementService As IDocManagementService
    Public Property _docGrantService As IDocGrantService
    Public Property _webPartService As IWebPartService
    Public Property _pageWebPartService As IPageWebPartService


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            AddSystemHistory("نمایش مدیریت اسناد", 0)
            BindRecord()
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

    Public Sub BindRecord()
        gridview1.DataSource = _webPartService.GetWebPartsByType(_securityUser.DivisionId, 3)
        gridview1.DataBind()
    End Sub

    Protected Sub gridview1_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles gridview1.ItemCommand
        If e.CommandName = "row-del" Then
            Try


                Dim WebPartId As Integer = Int32.Parse(e.CommandArgument)

                Dim PageWebpart = _pageWebPartService.GetPageWebPartsByWebpartId(WebPartId)
                If PageWebpart.Count > 0 Then
                    ShowMessage(Content:="این ماژول بر روی صفحه قرار دارد و قابل حذف نیست")
                    Return
                End If

                Dim DocManagemants = _docManagementService.GetDocManagementsForWebpart(WebPartId)

                For Each Item In DocManagemants
                    _docGrantService.DeleteDocGrantByDocId(Item.DocId)
                Next

                _docManagementService.DeleteDocManagementByWebPartId(WebPartId)

                Dim WebPart = _webPartService.GetOneWebPart(WebPartId)

                Dim RowEffect As Integer = _webPartService.DeleteWebPart(WebPart)

                If RowEffect > 0 Then
                    AddSystemHistory("حذف مدیریت اسناد", 3)
                    ShowMessage(Content:="عملیات با موفقیت انجام شد")
                    BindRecord()
                Else
                    ShowMessage(Content:="بدون تغییرات")
                End If
            Catch ex As Exception
                ShowMessage(Content:="خطا در عملیات")
            End Try
        End If
    End Sub

    Protected Sub btnRebindGridView_Click(sender As Object, e As EventArgs) Handles btnRebindGridView.Click
        BindRecord()
    End Sub
End Class
