Imports Microsoft.VisualBasic
Imports System.Reflection
Imports System.ComponentModel

Public Class Helpers
    Public Shared Function GetEnumDescription(ByVal value As [Enum]) As String
        Dim fi As FieldInfo = value.GetType().GetField(value.ToString())

        Dim attributes() As DescriptionAttribute = CType(fi.GetCustomAttributes(GetType(DescriptionAttribute), False), DescriptionAttribute())

        If attributes IsNot Nothing AndAlso attributes.Length > 0 Then
            Return attributes(0).Description
        Else
            Return value.ToString()
        End If
    End Function
End Class
