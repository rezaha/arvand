Imports System
Imports System.Collections.Generic
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports iTextSharp.text
Imports iTextSharp.text.html
Imports iTextSharp.text.pdf
Imports iTextSharp.text.html.simpleparser
Imports System.IO
Imports System.util
Imports System.Net
Imports System.Xml

Partial Class Print
    Inherits BasePage
    Dim pagetitle As String = ""
    Public Property PageSer As IPagesService
    Dim part As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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


        Text2PDF(PrintText)


    End Sub

    Protected Sub Page_LoadComplete1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        If Not IsPostBack Then
            Title = pagetitle
        End If
    End Sub

    Protected Sub Text2PDF(ByVal PDFText As String)
       
        Dim reader As New StringReader(PDFText)


        Dim document As New Document(PageSize.A4)
        Dim parser As New HTMLWorker(document)
        Dim PDF_FileName As String = Server.MapPath("~") & "/App_Data/PDF_File.pdf"
        PdfWriter.GetInstance(document, New FileStream(PDF_FileName, FileMode.Create))
        document.Open()
        Dim arialuniTff As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "TAHOMA.TTF")
        iTextSharp.text.FontFactory.Register(arialuniTff)
        Dim ST As New iTextSharp.text.html.simpleparser.StyleSheet()
        ST.LoadTagStyle(HtmlTags.BODY, HtmlTags.FACE, "Tahoma")
        ST.LoadTagStyle(HtmlTags.BODY, HtmlTags.ENCODING, BaseFont.IDENTITY_H)
        Dim list As List(Of IElement) = HTMLWorker.ParseToList(New StringReader(PDFText), ST)
        FontFactory.Register("c:\windows\fonts\bzar.ttf")
        Dim bZar As Font = FontFactory.GetFont("b zar", BaseFont.IDENTITY_H)
        FontFactory.Register("c:\windows\fonts\tahoma.ttf")
        Dim tahoma As Font = FontFactory.GetFont("tahoma", BaseFont.IDENTITY_H)

        Dim fontSelector As New FontSelector()
        If bZar.Familyname <> "unknown" Then
            fontSelector.AddFont(bZar)
        End If
        If tahoma.Familyname <> "unknown" Then
            fontSelector.AddFont(tahoma)
        End If
        For k As Integer = 0 To list.Count - 1
            Dim table As New PdfPTable(1)
            table.RunDirection = PdfWriter.RUN_DIRECTION_RTL
            Dim els = CType(list(k), IElement)
            For Each el As Chunk In els.Chunks					
                Dim cell = New PdfPCell With {.RunDirection = PdfWriter.RUN_DIRECTION_RTL, .Border = 0}
                cell.Phrase = fontSelector.Process(el.Content)
             
                table.AddCell(cell)

            Next el

            document.Add(table)
        Next k

        document.Close()
        DownLoadPdf(PDF_FileName)
    End Sub

    Private Sub DownLoadPdf(ByVal PDF_FileName As String)
        Dim client As New WebClient()
        Dim buffer() As Byte = client.DownloadData(PDF_FileName)
        Response.ContentType = "application/pdf"
        Response.AddHeader("content-length", buffer.Length.ToString())
        Response.BinaryWrite(buffer)
    End Sub
End Class
