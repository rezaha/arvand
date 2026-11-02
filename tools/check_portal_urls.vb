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
        Console.WriteLine("PASS: " & count & " checks against the production PortalUrl helper.")
    End Sub

    Private Sub Check(value As String, expected As String)
        If PortalUrl.SafeUrl(value) <> expected Then
            Throw New Exception("Unexpected URL handling for check " & (count + 1))
        End If
        count += 1
    End Sub
End Module
