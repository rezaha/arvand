Imports Microsoft.VisualBasic
Imports System.Reflection
Imports System.IO

Public Class UserControlHelper

    Public Shared Function RenderUserControl(ByVal path As String, ByVal properties As List(Of KeyValuePair(Of String, Object))) As String
        Dim pageHolder As New System.Web.UI.Page()

        Dim viewControl As UserControl = CType(pageHolder.LoadControl(path), UserControl)

        Dim viewControlType As Type = viewControl.GetType()

        For Each pair In properties
            Dim [property] As PropertyInfo = viewControlType.GetProperty(pair.Key)

            If [property] IsNot Nothing Then
                [property].SetValue(viewControl, pair.Value, Nothing)
            Else
                Throw New NotImplementedException(String.Format("UserControl: {0} does not have a public {1} property.", path, pair.Key))
            End If
        Next pair

        pageHolder.Controls.Add(viewControl)
        Dim output As New StringWriter()
        HttpContext.Current.Server.Execute(pageHolder, output, False)
        Return output.ToString()
    End Function

    Public Shared Function GetUserControl(ByVal path As String, ByVal properties As List(Of KeyValuePair(Of String, Object))) As UserControl
        Dim pageHolder As New System.Web.UI.Page()

        Dim viewControl As UserControl = CType(pageHolder.LoadControl(path), UserControl)

        Dim viewControlType As Type = viewControl.GetType()

        For Each pair In properties
            Dim [property] As PropertyInfo = viewControlType.GetProperty(pair.Key)

            If [property] IsNot Nothing Then
                [property].SetValue(viewControl, pair.Value, Nothing)
            Else
                Throw New NotImplementedException(String.Format("UserControl: {0} does not have a public {1} property.", path, pair.Key))
            End If
        Next pair

        Return viewControl
    End Function

End Class
