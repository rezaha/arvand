
Partial Class UserControls_NewsWUC
    Inherits BaseUserControl

    'Public Property newsService As INewsService

    Public Sub ShowNews()
        NewsContentWUC.ShowNews(0, 3, "NewsDate DESC")
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        ShowNews()
    End Sub

End Class
