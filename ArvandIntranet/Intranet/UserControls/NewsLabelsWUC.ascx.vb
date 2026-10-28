
Partial Class UserControls_NewsLabelsWUC
    Inherits BaseUserControl

    Public Property newsService As INewsService

    Public Sub Reload(ByVal NewsId As Integer)
        Dim newsItem = newsService.GetOneNews(NewsId)
        For Each item In newsItem.NewsLabels.Split(",")
            newsLabels.InnerHtml &= "<li>" &
                "<a href=""#"">" &
                "<img src=""../../../../Images/shownews/tag_ico.png"" runat=""server"" />" &
                "<span>" & item &
                "</span>" &
                "</a>" &
                "</li>"
        Next
    End Sub

End Class
