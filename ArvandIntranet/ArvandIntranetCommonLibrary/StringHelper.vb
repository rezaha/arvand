Imports System.ComponentModel
Imports System.Reflection
Imports System.Runtime.CompilerServices
Imports System.Text.RegularExpressions

Namespace Danesh.ArvandIntranet.CommonLibrary

    Public Module StringHelper
        <Extension()>
        Public Function StripHTML(ByRef StringText As String) As String
            If StringText IsNot Nothing Then
                Dim s As String = Regex.Replace(StringText, "<(.|\n)*?>", String.Empty)
                s = s.Replace("&nbsp;", " ")
                s = Regex.Replace(s, "\s+", " ")
                s = Regex.Replace(s, "\n+", vbLf)
                Return s
            End If
            Return ""
        End Function


    End Module



End Namespace

