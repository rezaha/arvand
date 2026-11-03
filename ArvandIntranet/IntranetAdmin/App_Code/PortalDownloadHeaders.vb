Option Infer On
Option Strict On
Imports Arvand.Common

Public NotInheritable Class PortalDownloadHeaders
    Private Sub New()
    End Sub

    Public Shared Function Build(fileName As String, inline As Boolean) As String
        Dim value = ContentDispositionUtil.GetHeaderValue(fileName)
        If inline Then Return "inline" & value.Substring("attachment".Length)
        Return value
    End Function
End Class
