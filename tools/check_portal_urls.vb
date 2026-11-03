Imports System

Module PortalUrlChecks
    Private count As Integer

    Sub Main()
        Check("/UploadFiles/News/sample.jpg", "/UploadFiles/News/sample.jpg")
        Check("/fa-IR/AR/ShowPage/12", "/fa-IR/AR/ShowPage/12")
        Check("/DownloadDoc.ashx?doc=3", "/DownloadDoc.ashx?doc=3")
        Check("https://example.com/app", "https://example.com/app")
        Check("http://intranet/app", "http://intranet/app")
        Check("news/image.jpg", "news/image.jpg")
        Check(" https://example.com/app ", "https://example.com/app")
        Check("javascript:alert(1)", "")
        Check("data:text/html,test", "")
        Check("file:///C:/private.txt", "")
        Check("//example.com/app", "")
        Check("/\example.com/app", "")
        Check("https://example.com" & ChrW(10) & "/app", "")
        Check("", "")
        Check(Nothing, "")
        CheckHeader("report.pdf", False, "attachment; filename=report.pdf")
        CheckHeader("report.pdf", True, "inline; filename=report.pdf")
        CheckHeader("گزارش.pdf", True, "inline; filename*=UTF-8''%DA%AF%D8%B2%D8%A7%D8%B1%D8%B4.pdf")
        CheckHeader("گزارش.pdf", False, "attachment; filename*=UTF-8''%DA%AF%D8%B2%D8%A7%D8%B1%D8%B4.pdf")
        Dim workbook = Arvand.Common.PortalWorkbook.Build(New String() {"نام", "کد ملی", "متن"},
            New String()() {New String() {"کاربر", "00123", "=1+1"}})
        Using stream As New System.IO.MemoryStream(workbook)
            Using archive As New System.IO.Compression.ZipArchive(stream, System.IO.Compression.ZipArchiveMode.Read)
                For Each part In New String() {"[Content_Types].xml", "_rels/.rels", "xl/workbook.xml", "xl/_rels/workbook.xml.rels", "xl/worksheets/sheet1.xml", "xl/styles.xml"}
                    If archive.GetEntry(part) Is Nothing Then Throw New Exception("Missing XLSX part")
                    count += 1
                Next
            End Using
        End Using
        Dim workbookPath = Environment.GetEnvironmentVariable("PORTAL_WORKBOOK_TEST_PATH")
        If Not String.IsNullOrEmpty(workbookPath) Then System.IO.File.WriteAllBytes(workbookPath, workbook)
        Console.WriteLine("PASS: " & count & " checks against production URL and download-header helpers.")
    End Sub

    Private Sub Check(value As String, expected As String)
        If PortalUrl.SafeUrl(value) <> expected Then
            Throw New Exception("Unexpected URL handling for check " & (count + 1))
        End If
        count += 1
    End Sub

    Private Sub CheckHeader(name As String, inline As Boolean, expected As String)
        If PortalDownloadHeaders.Build(name, inline) <> expected Then Throw New Exception("Download header mismatch")
        count += 1
    End Sub
End Module
