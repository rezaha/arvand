
Partial Class UserControls_DocManagementWUC
    Inherits BaseUserControl

    Public Property _docGrantService As IDocGrantService
    Public Property _docManagementService As IDocManagementService
    Public Property _webPartService As IWebPartService
    Dim _webPartId As Integer = 0

    Public Sub SetId(ByVal _webPartId As String)
        Me._webPartId = _webPartId
    End Sub

    Protected Function SetDownloadLink(ByVal _docManagement As DocManagement) As String
        Return "../../DownloadDoc.ashx?doc=" & _docManagement.DocId
    End Function

    Protected Function SetLinkText(ByVal _docManagement As DocManagement) As String
        Return _docManagement.DocTitle
    End Function

    Public Function WebpartTitle() As String
        Return _webPartService.GetOneWebPart(_webPartId).NamePersian
    End Function

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Page.User.Identity.IsAuthenticated Then
            Dim _docGrants As List(Of DocGrant) = _docGrantService.SearchDocWebpart(_webPartId, DomainUserService.GetDomainUserName(Page.User.Identity.Name))
            Dim _docManagement = _docManagementService.GetDocManagementsForWebpart(_webPartId)
            Dim _showDocs As New List(Of DocManagement)
            For Each item In _docManagement
                If item.PublicGrant Then
                    _showDocs.Add(item)
                Else
                    If _docGrants.Find(Function(a) a.DocId = item.DocId) IsNot Nothing Then
                        _showDocs.Add(item)
                    End If
                End If
            Next
            If _showDocs.Count = 0 Then
                Me.Visible = False
                Exit Sub
            End If
            Repeater1.DataSource = _showDocs
            Repeater1.DataBind()
        Else
            Dim _docManagement = _docManagementService.GetDocManagementsForWebpart(_webPartId)
            Dim _showDocs As New List(Of DocManagement)
            For Each item In _docManagement
                If item.PublicGrant Then
                    _showDocs.Add(item)
                Else
                    
                End If
            Next
            Repeater1.DataSource = _showDocs
            Repeater1.DataBind()
            ' Me.Visible = False
        End If
    End Sub

End Class
