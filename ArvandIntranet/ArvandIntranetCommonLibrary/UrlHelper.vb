Imports System.Runtime.CompilerServices
Imports System.Text
Imports System.Globalization

Namespace Danesh.ArvandIntranet.CommonLibrary

    Public Module UrlHelper

        <Extension()>
        Public Function ToFriendlyUrl(ByRef UrlToEncode As String) As String
            If UrlToEncode Is Nothing Then
                Return ""
            End If

            Const maxlen As Integer = 80
            Dim len As Integer = UrlToEncode.Length
            Dim prevdash As Boolean = False
            Dim sb = New StringBuilder(len)
            Dim c As Char

            For i As Integer = 0 To len - 1
                c = UrlToEncode.Chars(i)
                If (c >= "a"c AndAlso c <= "z"c) OrElse (c >= "0"c AndAlso c <= "9"c) OrElse (Char.GetUnicodeCategory(c) = UnicodeCategory.OtherLetter) Then
                    sb.Append(c)
                    prevdash = False
                ElseIf c >= "A"c AndAlso c <= "Z"c Then
                    ' tricky way to convert to lowercase
                    sb.Append(ChrW(AscW(c) Or 32))
                    prevdash = False
                ElseIf c = " "c OrElse c = ","c OrElse c = "."c OrElse c = "/"c OrElse c = "\"c OrElse c = "-"c OrElse c = "_"c OrElse c = "="c Then
                    If (Not prevdash) AndAlso sb.Length > 0 Then
                        sb.Append("-"c)
                        prevdash = True
                    End If
                ElseIf AscW(c) >= 128 Then
                    Dim prevlen As Integer = sb.Length
                    sb.Append(RemapInternationalCharToAscii(c))
                    If prevlen <> sb.Length Then
                        prevdash = False
                    End If
                Else
                    If i < len - 1 Then
                        sb.Append("-")
                    End If
                End If
                If i = maxlen Then
                    Exit For
                End If
            Next i

            If prevdash Then
                Return sb.ToString().ToLower.Substring(0, sb.Length - 1)
            Else
                Return sb.ToString().ToLower
            End If

        End Function

        <Extension()>
        Public Function RemapInternationalCharToAscii(ByVal c As Char) As String
            Dim s As String = c.ToString().ToLowerInvariant()
            If "àåáâäãåą".Contains(s) Then
                Return "a"
            ElseIf "èéêëę".Contains(s) Then
                Return "e"
            ElseIf "ìíîïı".Contains(s) Then
                Return "i"
            ElseIf "òóôõöøőð".Contains(s) Then
                Return "o"
            ElseIf "ùúûüŭů".Contains(s) Then
                Return "u"
            ElseIf "çćčĉ".Contains(s) Then
                Return "c"
            ElseIf "żźž".Contains(s) Then
                Return "z"
            ElseIf "śşšŝ".Contains(s) Then
                Return "s"
            ElseIf "ñń".Contains(s) Then
                Return "n"
            ElseIf "ýÿ".Contains(s) Then
                Return "y"
            ElseIf "ğĝ".Contains(s) Then
                Return "g"
            ElseIf c = "ř"c Then
                Return "r"
            ElseIf c = "ł"c Then
                Return "l"
            ElseIf c = "đ"c Then
                Return "d"
            ElseIf c = "ß"c Then
                Return "ss"
            ElseIf c = "Þ"c Then
                Return "th"
            ElseIf c = "ĥ"c Then
                Return "h"
            ElseIf c = "ĵ"c Then
                Return "j"
            Else
                Return ""
            End If
        End Function

        <Extension()>
        Public Function ToAsciText(ByRef UrlToEncode As String) As String
            If UrlToEncode Is Nothing Then
                Return ""
            End If

            Const maxlen As Integer = 80
            Dim len As Integer = UrlToEncode.Length
            Dim prevdash As Boolean = False
            Dim sb = New StringBuilder(len)
            Dim c As Char

            For i As Integer = 0 To len - 1
                c = UrlToEncode.Chars(i)
                If (c >= "a"c AndAlso c <= "z"c) OrElse (c >= "0"c AndAlso c <= "9"c) OrElse (Char.GetUnicodeCategory(c) = UnicodeCategory.OtherLetter) Then
                    sb.Append(c)
                    prevdash = False
                ElseIf c >= "A"c AndAlso c <= "Z"c Then
                    ' tricky way to convert to lowercase
                    sb.Append(ChrW(AscW(c) Or 32))
                    prevdash = False


                ElseIf AscW(c) >= 128 Then
                    Dim prevlen As Integer = sb.Length
                    sb.Append(RemapInternationalCharToAscii(c))
                    If prevlen <> sb.Length Then
                        prevdash = False
                    End If
                Else
                    If i < len - 1 Then
                        sb.Append(" ")
                    End If
                End If
                If i = maxlen Then
                    Exit For
                End If
            Next i

            If prevdash Then
                Return sb.ToString().ToLower.Substring(0, sb.Length - 1)
            Else
                Return sb.ToString().ToLower
            End If

        End Function

    End Module

End Namespace

