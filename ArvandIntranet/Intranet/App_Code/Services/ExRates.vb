Imports Microsoft.VisualBasic
Imports System.Xml

Public Class ExRatesFromBMIItem
    Public Property title As String
    Public Property description As String
    Public Property link As String
    Public Property author As String
    Public Property pubDate As String
End Class

Public Class ExRates

    Private Const ExRatesFromBMICache As String = "ExRatesFromBMICache"

    Public Function GetExRatesFromBMI() As List(Of ExRatesFromBMIItem)
        Dim list As List(Of ExRatesFromBMIItem) = TryCast(HttpContext.Current.Cache(ExRatesFromBMICache), List(Of ExRatesFromBMIItem))
        If list Is Nothing Then
            Dim doc As New XmlDocument()
            doc.Load("http://www.bmi.ir/FA/RSS/RSSFeed.aspx?t=2&curt=0")
            'doc.Load(req.Request.PhysicalApplicationPath & "/ExRates.xml")
            list = New List(Of ExRatesFromBMIItem)()
            For Each node As XmlNode In doc.SelectNodes("//item")
                Dim ExRates As New ExRatesFromBMIItem()
                ExRates.title = node("title").InnerText
                ExRates.description = node("description").InnerText
                ExRates.link = node("link").InnerText
                ExRates.author = node("author").InnerText
                ExRates.pubDate = node("pubDate").InnerText
                list.Add(ExRates)
            Next node
            HttpContext.Current.Cache.Insert(ExRatesFromBMICache, list, Nothing, Date.Now.AddHours(5), TimeSpan.Zero)
        End If
        Return list
    End Function

End Class
