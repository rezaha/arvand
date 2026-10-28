Imports System.Runtime.CompilerServices

Namespace Danesh.ArvandIntranet.CommonLibrary

    Public Module PersianHelper
        <Extension()>
        Public Function GetPersianNumbers(ByRef s As String) As String
            Return s.Replace("0", "۰").Replace("1", "۱").Replace("2", "۲").Replace("3", "۳").Replace("4", "۴").Replace("5", "۵").Replace("6", "۶").Replace("7", "۷").Replace("8", "۸").Replace("9", "۹")
        End Function
    End Module

End Namespace
