Imports Argotic.Syndication
Imports System.Globalization
Imports System.Data.Entity
Imports Danesh.ArvandIntranet.ServiceLayer.Interfaces
Imports Danesh.ArvandIntranet.DataLayer.Context
Imports Danesh.ArvandIntranet.DomainClasses.Models
Imports Danesh.ArvandIntranet.CommonLibrary

Namespace Danesh.ArvandIntranet.ServiceLayer.EFServices
    Public Class RSSService
        Implements IRSSService

        Private _siteAddress As String
        Private _siteTitle As String
        Private _siteDescription As String
        Private _RSSculture As CultureInfo

        Private _uow As IUnitOfWork
        Dim feed As RssFeed
        Dim newsService As INewsService
        Dim announcementService As IAnnouncementService

        Public Property SiteAddress As String Implements IRSSService.SiteAddress
            Get
                Return _siteAddress
            End Get
            Set(value As String)
                _siteAddress = value
            End Set
        End Property

        Public Property SiteTitle As String Implements IRSSService.SiteTitle
            Get
                Return _siteTitle
            End Get
            Set(value As String)
                _siteTitle = value
            End Set
        End Property

        Public Property SiteDescription As String Implements IRSSService.SiteDescription
            Get
                Return _siteDescription
            End Get
            Set(value As String)
                _siteDescription = value
            End Set
        End Property

        Public Property RSSculture As CultureInfo Implements IRSSService.RSSculture
            Get
                Return _RSSculture
            End Get
            Set(value As CultureInfo)
                _RSSculture = value
            End Set
        End Property

        Public Sub New(ByVal uow As IUnitOfWork)
            _uow = uow
            newsService = New NewsService(_uow)
            announcementService = New AnnouncementService(_uow)
        End Sub

        Private Sub SetRSSHeader()
            feed.Channel.Link = New Uri(SiteAddress)
            feed.Channel.Title = SiteTitle
            feed.Channel.Description = SiteDescription
            feed.Channel.Language = RSSculture
            feed.Channel.Webmaster = "Danesh Afzar Mahan"
            feed.Channel.Copyright = "All Right Reserved For Arvand Prtrochemical Company"
            feed.Channel.LastBuildDate = New Date(2012, 11, 20)
            feed.Channel.PublicationDate = New Date(2012, 11, 1)
        End Sub

        Public Function GenerateNewsRSSFeed(ByVal newsId As Integer, ByVal newsAddress As String) As XDocument Implements IRSSService.GenerateNewsRSSFeed
            feed = New RssFeed()
            SetRSSHeader()
            Dim dtHelper As New DateTimeHelper
            Dim newsItem As News = newsService.GetOneNews(newsId)
            If newsItem Is Nothing Then
                Throw New ApplicationException("news not found to show in rss")
            End If
            Dim item As New RssItem()
            item.Title = newsItem.TitlePersian
            item.Link = New Uri(newsAddress)
            item.Description = newsItem.SummaryPersian
            item.PublicationDate = Convert.ToDateTime(dtHelper.ConvertToLatinDate("13" & newsItem.NewsDate, LatinDateTime.YMD))
            feed.Channel.AddItem(item)

            'Using stream As New FileStream("CompactRssFeed.xml", FileMode.Create, FileAccess.Write)
            '    Dim settings As New SyndicationResourceSaveSettings()
            '    settings.MinimizeOutputSize = True
            '    settings.CharacterEncoding = Encoding.UTF8
            '    feed.Save(stream, settings)
            'End Using
            Return XDocument.Parse(feed.CreateNavigator().OuterXml.ToString())
        End Function

        Public Function GenerateAnnouncementRSSFeed(ByVal announcemenId As Integer, ByVal announcemenAddress As String) As XDocument Implements IRSSService.GenerateAnnouncementRSSFeed
            feed = New RssFeed()
            SetRSSHeader()
            Dim dtHelper As New DateTimeHelper
            Dim newsItem As News = announcementService.GetOneAnnouncement(announcemenId)
            If newsItem Is Nothing Then
                Throw New ApplicationException("Announcement not found to show in rss")
            End If
            Dim item As New RssItem()
            item.Title = newsItem.TitlePersian
            item.Link = New Uri(announcemenAddress)
            item.Description = newsItem.SummaryPersian
            item.PublicationDate = Convert.ToDateTime(dtHelper.ConvertToLatinDate("13" & newsItem.NewsDate, LatinDateTime.YMD))
            feed.Channel.AddItem(item)

            'Using stream As New FileStream("CompactRssFeed.xml", FileMode.Create, FileAccess.Write)
            '    Dim settings As New SyndicationResourceSaveSettings()
            '    settings.MinimizeOutputSize = True
            '    settings.CharacterEncoding = Encoding.UTF8
            '    feed.Save(stream, settings)
            'End Using
            Return XDocument.Parse(feed.CreateNavigator().OuterXml.ToString())
        End Function

    End Class
End Namespace


