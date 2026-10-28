Imports System.IO
Imports System.Globalization
Imports System.Xml

Partial Class RSS
    Inherits BasePage

    Public Property newsService As INewsService
    Public Property announcementService As IAnnouncementService
    Public Property rssService As IRSSService

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim part As String = RouteData.Values("part").ToString().ToLower()
        Dim id As Integer = RouteData.Values("id").ToString().ToLower()
       
        rssService.SiteAddress = "http://www.arvandpvc.ir"
        rssService.RSSculture = New CultureInfo(SiteLanguage & "-" & SiteLocation)

        Dim RssResponse As XDocument
        If part = "news" Then
            Dim newsItem As Danesh.ArvandIntranet.DomainClasses.Models.News = newsService.GetOneNews(id)
            If newsItem Is Nothing Then
                Response.RedirectToRoute("default-rout", New With {.pageName = "default"})
            End If
            If SiteLanguage = "fa" Then
                rssService.SiteTitle = "پتروشیمی اروند"
                rssService.SiteDescription = "پتروشیمی اروند در زمینه تولید PVC"
                If newsItem.ShowStatus = 1 Then
                    Response.RedirectToRoute("default-rout", New With {.pageName = "default"})
                End If
                rssService.SiteTitle &= newsItem.TitlePersian
            ElseIf SiteLanguage = "en" Then
                If newsItem.ShowStatus = 0 Then
                    Response.RedirectToRoute("default-rout", New With {.pageName = "default"})
                End If
                rssService.SiteTitle &= newsItem.TitleLatin
            End If
            Dim url As String = GetRouteUrl("default-rout", New With {.pageName = "ShowNews", .id = newsItem.NewsId}) & "/" & newsItem.TitlePersian
            RssResponse = rssService.GenerateNewsRSSFeed(id, "http://www.arvandpvc.ir" & url)
        ElseIf part = "announcement" Then
            Dim newsItem As Danesh.ArvandIntranet.DomainClasses.Models.News = announcementService.GetOneAnnouncement(id)
            If newsItem Is Nothing Then
                Response.RedirectToRoute("default-rout", New With {.pageName = "default"})
            End If
            Dim url As String = String.Empty
            If SiteLanguage = "fa" Then
                rssService.SiteTitle = "پتروشیمی اروند"
                rssService.SiteDescription = "پتروشیمی اروند در زمینه تولید PVC"
                If newsItem.ShowStatus = 1 Then
                    Response.RedirectToRoute("default-rout", New With {.pageName = "default"})
                End If
                rssService.SiteTitle &= newsItem.TitlePersian
                url = GetRouteUrl("default-rout", New With {.pageName = "ShowNews", .id = newsItem.NewsId}) & "/" & newsItem.TitlePersian
            ElseIf SiteLanguage = "en" Then
                If newsItem.ShowStatus = 0 Then
                    Response.RedirectToRoute("default-rout", New With {.pageName = "default"})
                End If
                rssService.SiteTitle &= newsItem.TitleLatin
                url = GetRouteUrl("default-rout", New With {.pageName = "ShowNews", .id = newsItem.NewsId}) & "/" & newsItem.TitleLatin
            End If

            RssResponse = rssService.GenerateNewsRSSFeed(id, "http://www.arvandpvc.ir" & url)
        End If
        If RssResponse Is Nothing Then
            Response.RedirectToRoute("default-rout", New With {.pageName = "default"})
        End If
        'Dim feed As RssFeed = RssFeed.Create(New Uri("http://www.pwop.com/feed.aspx?show=dotnetrocks&filetype=master"))

        'Dim feed As New RssFeed()

        'Using stream As New FileStream("SimpleRssFeed.xml", FileMode.Open, FileAccess.Read)
        '    feed.Load(stream)
        'End Using

        'feed = New RssFeed()
        'Using stream As New FileStream("SimpleRssFeed.xml", FileMode.Open, FileAccess.Read)
        '    Dim settings As New XmlReaderSettings()
        '    settings.IgnoreComments = True
        '    settings.IgnoreWhitespace = True

        '    Using reader As XmlReader = XmlReader.Create(stream, settings)
        '        feed.Load(reader)
        '    End Using
        'End Using

        'feed = New RssFeed()
        'Using stream As New FileStream("SimpleRssFeed.xml", FileMode.Open, FileAccess.Read)
        '    feed.Load(New XPathDocument(stream))
        'End Using

        ' Need to modify the Response type  
        Response.Clear()
        Response.ContentType = "text/xml"

        Dim streamWriter As New StreamWriter(Response.OutputStream, Encoding.UTF8)

        ' Make the call here to get the feed an write it out to the stream  
        streamWriter.Write(RssResponse)
        streamWriter.Flush()

        Response.End()

    End Sub

    Public Function GenerateRSSFeed() As XDocument
        'Dim rssRepository = New RssFeed()
        'Dim items = newsService.GetTopNews(0, 1, "NewsDate ASC")

        'Dim rssFeed = New RssFeed("Main RSS Feed for DimeCasts.Net")
        'Dim rssChannel = New RssChannel(New Uri("http://www.dimecasts.net"), "Title", "Desc")

        'For Each item In items
        '    Dim rssItem = New RssItem With {.Author = "Your name here", .Title = item.TitlePersian, .Link = New Uri("http://www.google.com"), .Guid = New RssGuid(item.NewsNo), .Description = item.SummaryPersian, .PublicationDate = item.NewsTime}
        '    rssChannel.AddItem(rssItem)
        'Next item

        'rssFeed.Channel = rssChannel


        'Return XDocument.Parse(rssFeed.CreateNavigator().OuterXml.ToString())

        '    Dim feed As New RssFeed()

        '    feed.Channel.Link = New Uri("http://localhost")
        '    feed.Channel.Title = "Compact RSS Feed"
        '    feed.Channel.Description = "A minimal and non-indented RSS 2.0 syndication feed."

        '    Dim item As New RssItem()
        '    item.Title = "Simple RSS Item"
        '    item.Link = New Uri("http://localhost/items/SimpleRSSItem.aspx")
        '    item.Description = "A minimal RSS channel item."

        '    feed.Channel.AddItem(item)

        '    Using stream As New FileStream("CompactRssFeed.xml", FileMode.Create, FileAccess.Write)
        '        Dim settings As New SyndicationResourceSaveSettings()
        '        settings.MinimizeOutputSize = True
        '        settings.CharacterEncoding = Encoding.UTF8
        '        feed.Save(stream, settings)
        '    End Using
        '    Return XDocument.Parse(feed.CreateNavigator().OuterXml.ToString())
    End Function


End Class


'@using Argotic.Syndication
'@{
'    Layout = null;
'    var db = Database.Open("Books");
'    var url = "/Book/{0}";
'    var sql = "Select BookId, Title, Description, DatePublished From Books";
'    var books = db.Query(sql);

'    var feed = new RssFeed 
'                   { 
'                       Channel.Link = Functions.GetSiteUrl("~/argotic_rss"),
'                       Channel.Title = "Books News Feed",
'                       Channel.Description = "Latest additions to Books"
'                   };

'    foreach (var book in books)
'    {
'        var item = new RssItem
'                       {
'                           Title = book.Title,
'                           Link = Functions.GetSiteUrl(String.Format(url, book.BookId)),
'                           Description = book.Description,
'                           PublicationDate = book.DatePublished
'                       };
'        feed.Channel.AddItem(item);
'    }

'    Response.ContentType = "text/xml";
'    feed.Save(Response.OutputStream);
'}


'@using Argotic.Syndication
'@{
'    Layout = null;
'    var db = Database.Open("Books");
'    var url = "/Book/{0}";
'    var sql = "Select BookId, Title, Description, DatePublished From Books";
'    var books = db.Query(sql);

'    var feed = new AtomFeed
'                   {
'                       Id = new AtomId(Functions.GetSiteUrl()),
'                       Title = new AtomTextConstruct("Books News Feed"),
'                       UpdatedOn = DateTime.Now,
'                   };

'    feed.Authors.Add(new AtomPersonConstruct("Mikesdotnetting"));

'    var selfLink = new AtomLink
'                       {
'                           Relation = "self", 
'                           Uri = Functions.GetSiteUrl("~/argotic_atom")
'                       };
'    feed.Links.Add(selfLink);
'    foreach (var book in books)
'    {
'        var entry = new AtomEntry
'                        {
'                            Id = new AtomId(Functions.GetSiteUrl(String.Format(url, book.BookId))),
'                            Title = new AtomTextConstruct(book.Title),
'                            UpdatedOn = book.DatePublished,
'                            Summary = new AtomTextConstruct(book.Description)
'                        };

'        var alternateLink = new AtomLink
'                                {
'                                    Relation = "alternate",
'                                    Uri = Functions.GetSiteUrl(String.Format(url, book.BookId))
'                                };
'        entry.Links.Add(alternateLink);
'        feed.AddEntry(entry);
'    }
'    Response.ContentType = "application/atom+xml";
'    feed.Save(Response.OutputStream);
'}


'Mike - I am running into the following error using the GetSitURL function:

'Compiler Error Message: CS0120: An object reference is required for the non-static field, method, or property 'System.Web.WebPages.WebPageRenderingBase.Request.get'

'Source Error:
'Line 4: public static Uri GetSiteUrl(string url = "~/")
'Line 5: {
'Line 6: url = Request.Url.GetLeftPart(UriPartial.Authority) + VirtualPathUtility.ToAbsolute(url);
'Line 7: return new Uri(url);
'Line 8: }