
Partial Class UserControls_PersuasiveWUC
    Inherits BaseUserControl

    Public Property persuasiveService As IPersuasiveService

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim persuasive = persuasiveService.GetTopPersuasive()
        If persuasive IsNot Nothing Then
            If SiteLanguage.ToLower = "en" Then
                PersuasiveConetnt.InnerHtml = persuasiveService.GetTopPersuasive().HtmlSummaryLatin
            Else
                PersuasiveConetnt.InnerHtml = persuasiveService.GetTopPersuasive().HtmlSummaryPersian
            End If
        End If
    End Sub

End Class
