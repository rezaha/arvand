
Partial Class UserControls_SearchWUC
    Inherits BaseUserControl

    'Protected Sub imgBtnSearch_Click(sender As Object, e As ImageClickEventArgs) Handles imgBtnSearch.Click
    '    Dim url As String = String.Empty
    '    If SiteLanguage = "fa" Then
    '        url = GetRouteUrl("default-rout", New With {.pageName = "Search", .id = Nothing})
    '    ElseIf SiteLanguage = "en" Then
    '        url = GetRouteUrl("default-rout", New With {.pageName = "Search", .id = Nothing})
    '    End If
    '    Response.Redirect(url & "?q=" & Server.HtmlDecode(txtSearch.Text))
    'End Sub

    'Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
    '    If Not IsPostBack Then
    '        txtSearch.Attributes.Add("onkeypress", "return clickButton(event,'" + imgBtnSearch.ClientID + "')")
    '    End If
    'End Sub
End Class
