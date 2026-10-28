Imports Microsoft.VisualBasic
Imports System.Net
Imports System.Net.Sockets

Public Class SystemTracking

    Public Shared Function UserIPLocal() As String
        Dim ip As IPHostEntry = Dns.GetHostEntry(Dns.GetHostName())
        Dim IPaddr() As IPAddress = ip.AddressList

        Dim ipAddress As String = "127.0.0.1"
        For i As Integer = 0 To IPaddr.Length - 1
            If IPaddr(i).AddressFamily = AddressFamily.InterNetwork Then
                If Not IPaddr(i).Equals("127.0.0.1") Then
                    ipAddress = IPaddr(i).ToString
                    Exit For
                End If
            End If
        Next i
        Return ipAddress
    End Function

    Public Shared Function UserIPDns() As String
        Dim strUserHostAddress As String = String.Empty
        Try
            Dim currentRequest As HttpRequest = HttpContext.Current.Request
            Dim ipAddress As String = currentRequest.ServerVariables("HTTP_X_FORWARDED_FOR")

            If ipAddress Is Nothing OrElse ipAddress.ToLower() = "unknown" Then
                ipAddress = currentRequest.ServerVariables("REMOTE_ADDR")
            End If

            Return ipAddress
        Catch ex As Exception

            Throw ex
        End Try

        Return (strUserHostAddress)
    End Function

    Public Shared Function UserBrowser() As String
        Dim strBrowserName As String = String.Empty
        Dim strBrowserVersion As String = String.Empty
        Dim strResult As String = String.Empty
        Try
            Dim Browse As System.Web.HttpBrowserCapabilities = System.Web.HttpContext.Current.Request.Browser
            strBrowserName = Browse.Browser
            strBrowserVersion = Browse.Version
            strResult = strBrowserName & " " & strBrowserVersion
        Catch ex As Exception
            Throw ex
        End Try
        Return (strResult)
    End Function

    Public Shared Function UserOs() As String
        Dim strResult As String = String.Empty
        Try
            Dim myBrowser As System.Web.HttpBrowserCapabilities = System.Web.HttpContext.Current.Request.Browser
            strResult = myBrowser.Platform
        Catch ex As Exception
            Throw ex
        End Try
        Return (strResult)
    End Function

    Public Shared Function UserMachineName() As String
        Dim strResult As String = String.Empty
        Try
            strResult = System.Net.Dns.GetHostName()
        Catch ex As Exception
            Throw ex
        End Try
        Return (strResult)
    End Function

End Class
