Imports System.IO

Partial Class SystemMng_UserControls_PanelWUC
    Inherits System.Web.UI.UserControl

    Dim str As String = "widget_child_"

    Public Sub SetValueMng(ByVal name As String, ByVal title As String, ByVal body As String, ByVal footer As String)
        widget_child.Attributes.Add("class", "widget movable ")
        SetValues(name, title, body, footer)
    End Sub

    Private Sub SetValues(ByVal name As String, ByVal title As String, ByVal body As String, ByVal footer As String)
        'ImgCircle.Src = "~/images/Widget/circle.png"
        lblTitleNews.Text = title
        lblBodyNews.Text = body
        lblFooterNews.Text = footer
        widget_child.ID = str & name
        name = String.Empty
    End Sub

End Class
