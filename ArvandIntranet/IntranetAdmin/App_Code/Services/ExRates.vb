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
            Dim request = DirectCast(System.Net.WebRequest.Create("http://www.bmi.ir/FA/RSS/RSSFeed.aspx?t=2&curt=0"), System.Net.HttpWebRequest)
            request.Timeout = 5000
            request.ReadWriteTimeout = 5000
            Dim settings As New XmlReaderSettings With {.DtdProcessing = DtdProcessing.Prohibit, .XmlResolver = Nothing}
            Using response = request.GetResponse(), stream = response.GetResponseStream(), reader = XmlReader.Create(stream, settings)
                doc.XmlResolver = Nothing
                doc.Load(reader)
            End Using
            'doc.Load(req.Request.PhysicalApplicationPath & "/ExRates.xml")
            list = New List(Of ExRatesFromBMIItem)()
            For Each node As XmlNode In doc.SelectNodes("//item")
                If node("title") Is Nothing OrElse node("description") Is Nothing Then Continue For
                Dim ExRates As New ExRatesFromBMIItem()
                ExRates.title = node("title").InnerText
                ExRates.description = node("description").InnerText
                ExRates.link = If(node("link") Is Nothing, String.Empty, node("link").InnerText)
                ExRates.author = If(node("author") Is Nothing, String.Empty, node("author").InnerText)
                ExRates.pubDate = If(node("pubDate") Is Nothing, String.Empty, node("pubDate").InnerText)
                list.Add(ExRates)
            Next node
            HttpContext.Current.Cache.Insert(ExRatesFromBMICache, list, Nothing, Date.Now.AddHours(5), TimeSpan.Zero)
        End If
        Return list
    End Function

End Class
