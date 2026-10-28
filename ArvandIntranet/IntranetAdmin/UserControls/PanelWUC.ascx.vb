
Partial Class UserControls_PanelWUC
    Inherits BaseUserControl

    Dim str As String = "widget_child_"

    Public Sub SetValueMng(ByVal name As String, ByVal title As String, ByVal body As String, ByVal footer As String)
        PosibleDiv.Visible = True
        widget_child.Attributes.Add("class", "widget movable ")
        SetValues(name, title, body, footer)
    End Sub

    Public Sub SetValueVisitor(ByVal name As String, ByVal title As String, ByVal body As String, ByVal footer As String)
        PosibleDiv.Visible = False
        SetValues(name, title, body, footer)
    End Sub

    Private Sub SetValues(ByVal name As String, ByVal title As String, ByVal body As String, ByVal footer As String)
        'ImgCircle.Src = "~/images/Widget/circle.png"
        Me.title.InnerHtml = title
        content.InnerHtml = body
        widget_child.ID = str & name
        name = String.Empty
    End Sub

End Class
