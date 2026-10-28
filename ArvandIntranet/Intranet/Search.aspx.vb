
Partial Class Search
    Inherits BasePage

    Public Property PageService As IPagesService
    Public Property _docManagementService As IDocManagementService

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Request.QueryString("q") IsNot Nothing Then
                Dim SearchP As String = Request.QueryString("q").ToString
                txtSearchText.Text = SearchP
                SetSearch(SearchP)
            End If

        End If
    End Sub


    Sub SetSearch(ByVal SearchParameter As String)

        lblResult.Visible = False
        If SearchParameter <> "" Then
            Dim SearchResult As New List(Of SearchClassItems)

            Dim PItems = PageService.GetPageBySearch(SearchParameter)
            Dim FItem = _docManagementService.GetDocManagementBySearch(SearchParameter)

            For Each item In PItems
                Dim SearchItem As New SearchClassItems
                SearchItem.ItemId = item.PageId
                SearchItem.ItemType = 3
                SearchItem.DateString = ""
                SearchItem.PictureLink = "UploadFiles/Web-page.png"
                SearchItem.Summary = item.PageSummary
                SearchItem.Title = item.PageTitle
                SearchItem.Type = "یافته شده در صفحات کاربری"
                SearchResult.Add(SearchItem)
            Next

            For Each item In FItem
                Dim SearchItem As New SearchClassItems
                SearchItem.ItemId = item.DocId
                SearchItem.ItemType = 2
                SearchItem.DateString = ""
                SearchItem.PictureLink = "UploadFiles/Web-page.png"
                SearchItem.Summary = item.DocTitle
                SearchItem.Title = item.DocTitle
                SearchItem.Type = "یافته شده در فایل ها"
                SearchResult.Add(SearchItem)
            Next

            If SearchResult.Count > 0 Then
                Repeater1.DataSource = SearchResult
                Repeater1.DataBind()
            Else
                lblResult.Visible = True
            End If
        Else
            'ScriptManager.RegisterClientScriptBlock(Me, Me.GetType(), "1", "alert('لطفا متن مورد نظر برای جستجو وارد شود')", True)
        End If
    End Sub

    Public Function SetHomePageUrl() As String
        Dim url As String = GetRouteUrl("default-rout", New With {.pageName = "default"})
        Return url
    End Function

    Protected Function SetSearchUrl(ByVal DataItem As SearchClassItems, ByVal Type As Integer) As String
        Dim url As String = String.Empty
        Select Case Type
            Case 2
                url = "~/DownloadDoc.ashx?doc=" & DataItem.ItemId
            Case 3
                url = GetRouteUrl("default-rout", New With {.pageName = "ShowPage", .id = DataItem.ItemId}) & "/" & Server.HtmlDecode(DataItem.Title.Trim.ToFriendlyUrl())
        End Select
        Return url
    End Function

    Protected Function NewsDateConvert(ByVal NewsDate As String) As String
        'یکشنبه 12 اردیبهشت 1391
        Dim dateTimeHelper As New DateTimeHelper
        Return dateTimeHelper.LongPersianDate("13" & NewsDate, PersianDateTimeFormat.DayOfWeekName_Day_MonthName_Year)
    End Function

    Protected Sub lnkSearch_Click(sender As Object, e As EventArgs) Handles lnkSearch.Click
        Dim url As String = String.Empty
        If SiteLanguage = "fa" Then
            url = GetRouteUrl("default-rout", New With {.pageName = "Search", .id = Nothing})
        ElseIf SiteLanguage = "en" Then
            url = GetRouteUrl("default-rout", New With {.pageName = "Search", .id = Nothing})
        End If
        Response.Redirect(url & "?q=" & Server.HtmlDecode(txtSearchText.Text.ToAsciText()))
    End Sub
End Class
