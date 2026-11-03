Option Infer On
Option Strict On
Imports System
Imports System.Web.UI

Public NotInheritable Class PortalMenuLinks
    Private Sub New()
    End Sub

    Public Shared Function Resolve(owner As Control, value As String) As String
        If String.IsNullOrWhiteSpace(value) OrElse value = "#" Then Return String.Empty
        value = value.Trim()
        If value.StartsWith("~/") Then Return PortalUrl.SafeUrl(owner.ResolveUrl(value))
        If value.StartsWith("/") Then Return PortalUrl.SafeUrl(value)
        Dim absolute As Uri = Nothing
        If Uri.TryCreate(value, UriKind.Absolute, absolute) Then Return PortalUrl.SafeUrl(value)
        Dim pageId As Integer
        If Integer.TryParse(value, pageId) Then
            Return owner.GetRouteUrl("default-rout", New With {.pageName = "ShowPage", .id = pageId})
        End If
        If value.StartsWith("SystemMng/", StringComparison.OrdinalIgnoreCase) Then Return owner.ResolveUrl("~/" & value)
        Dim parts = value.Split(New Char() {"/"c}, 3)
        Dim name = parts(0)
        If name.EndsWith(".aspx", StringComparison.OrdinalIgnoreCase) Then name = name.Substring(0, name.Length - 5)
        Return owner.GetRouteUrl("default-rout", New With {
            .pageName = name, .id = If(parts.Length > 1, parts(1), Nothing),
            .description = If(parts.Length > 2, parts(2), Nothing)})
    End Function
End Class
