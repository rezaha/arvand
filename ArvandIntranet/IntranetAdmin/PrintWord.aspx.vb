
Partial Class PrintWord
    Inherits BasePage

    Dim pagetitle As String = ""
    Public Property PageSer As IPagesService
    Dim part As String

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        part = RouteData.Values("part").ToString().ToLower()
        Dim id As Integer = RouteData.Values("id").ToString().ToLower()
        Dim PageItem = PageSer.GetOnePage(id)
        pagetitle = PageItem.PageTitle
        Page.Title = pagetitle
        Dim PrintText As String = ""
        PrintText &= "<html>"
        PrintText &= "<head>"
        PrintText &= "<title></title>"
        PrintText &= "</head>"
        PrintText &= "<body>"
        PrintText &= "<div class=""shownews_title"">"
        PrintText &= "<h2>"
        PrintText &= PageItem.PageTitle
        PrintText &= "</h2>"
        PrintText &= "<div class=""news_summary"">"
        PrintText &= "<p>"
        PrintText &= PageItem.PageSummary
        PrintText &= "</p></div>"
        PrintText &= "<div class=""news_complete"">"
        PrintText &= PageItem.PageContent
        PrintText &= "<p></p></div>"
        PrintText &= "</body>"
        PrintText &= "</html>"

        Response.Buffer = True
        Response.ContentType = "application/vnd.ms-word"
        Response.AddHeader("Content-Disposition", "attachment; filename = Document.doc")
        Response.Write(PrintText)

    End Sub

    Protected Sub Page_LoadComplete1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            Title = pagetitle
        End If
    End Sub

End Class
