Imports System.IO
Imports System.Reflection

Partial Class SystemMng_Home_DesignHomePage
    Inherits AdminBasePage

  
    Public Property _pageWebPartService As IPageWebPartService
    Public Property _webPartService As IWebPartService

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
    
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        AddSystemHistory("طراحی صفحه اصلی", 0)

        Dim list = _pageWebPartService.GetPageWebParts(_securityUser.DivisionId, "Default.aspx")

        Dim listWebPart = _webPartService.GetWebParts(_securityUser.DivisionId)

        Dim uControl As UserControl = LoadControl("~/SystemMng/UserControls/PanelWUC.ascx")

        Dim ucType As Type = uControl.GetType().BaseType
        Dim method As MethodInfo = ucType.GetMethod("SetValueMng")

        Dim sw0 As New StringWriter
        Dim htw0 As HtmlTextWriter = New HtmlTextWriter(sw0)
        Dim sw1 As New StringWriter
        Dim htw1 As HtmlTextWriter = New HtmlTextWriter(sw1)

        Dim sw2 As New StringWriter
        Dim htw2 As HtmlTextWriter = New HtmlTextWriter(sw2)

        Dim sw3 As New StringWriter
        Dim htw3 As HtmlTextWriter = New HtmlTextWriter(sw3)

        For Each item In listWebPart
            If list.FirstOrDefault(Function(a) a.WebpartId = item.WebpartId) Is Nothing Then
                method = ucType.GetMethod("SetValueMng")
                If (method <> Nothing) Then
                    Dim parameters As Object = {item.WebpartId.ToString, item.HeaderPersian, item.DescriptionPersian, ""}
                    method.Invoke(uControl, parameters)
                End If
                method = ucType.GetMethod("CapabilityMng")
                If method <> Nothing Then
                    Dim parameters As Object = {"True", "True", "True", "True"}
                    method.Invoke(uControl, parameters)
                End If
                uControl.RenderControl(htw0)
            End If
        Next

        htw0.Close()
        widget_place_0.InnerHtml &= sw0.ToString()

        For Each item In list
            method = ucType.GetMethod("SetValueMng")
            If (method <> Nothing) Then
                Dim parameters As Object = {item.Webpart.WebpartId.ToString, item.Webpart.HeaderPersian, item.Webpart.DescriptionPersian, ""}
                method.Invoke(uControl, parameters)
            End If
            method = ucType.GetMethod("CapabilityMng")
            If method <> Nothing Then
                Dim parameters As Object = {item.MoveOption.ToString, item.CollapseOption.ToString, item.DeleteOption.ToString, item.HeaderVisible.ToString}
                method.Invoke(uControl, parameters)
            End If
            Select Case item.ColNo
                Case 1
                    uControl.RenderControl(htw1)
                Case 2
                    uControl.RenderControl(htw2)
                Case 3
                    uControl.RenderControl(htw3)
            End Select
        Next

        htw1.Close()
        htw2.Close()
        htw3.Close()

        widget_place_1.InnerHtml = sw1.ToString()
        widget_place_2.InnerHtml = sw2.ToString()

    End Sub

End Class
