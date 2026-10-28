Imports System.Globalization
Namespace Danesh.ArvandIntranet.ServiceLayer.Interfaces
    Public Interface IRSSService

        Function GenerateAnnouncementRSSFeed(announcemenId As Integer, announcemenAddress As String) As XDocument

        Property SiteAddress As String
        Property SiteTitle As String
        Property SiteDescription As String
        Property RSSculture As CultureInfo
        Function GenerateNewsRSSFeed(ByVal newsId As Integer, ByVal newsAddress As String) As XDocument
    End Interface
End Namespace
