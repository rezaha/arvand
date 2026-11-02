Option Infer On
Option Strict On

Imports System
Imports System.Linq

Public NotInheritable Class PortalUrl
    Private Sub New()
    End Sub

    Public Shared Function SafeUrl(value As String) As String
        If String.IsNullOrWhiteSpace(value) Then Return String.Empty
        value = value.Trim()
        If value.StartsWith("//") OrElse value.Contains("\") OrElse value.Any(Function(c) Char.IsControl(c)) Then Return String.Empty
        'UriKind.Absolute also accepts rooted paths as file: URIs. These are
        'application-relative HTTP URLs, so keep them before checking schemes.
        If value.StartsWith("/") Then Return value
        Dim absolute As Uri = Nothing
        If Uri.TryCreate(value, UriKind.Absolute, absolute) Then
            If absolute.Scheme <> Uri.UriSchemeHttps AndAlso absolute.Scheme <> Uri.UriSchemeHttp Then Return String.Empty
        ElseIf value.Contains(":") Then
            Return String.Empty
        End If
        Return value
    End Function
End Class
