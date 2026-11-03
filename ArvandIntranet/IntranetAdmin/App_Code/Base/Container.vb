Imports System.Reflection

Public Class Container
    Inherits BasePage

    Dim PageWebPartObj As New CLSPagesWebparts
    Public Property _pageWebPartService As IPageWebPartService
    Public Property _docGrantService As IDocGrantService

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.Header.DataBind()
        If _plantDivisionsService.AnyChild(PlantDivisions.DivisionId) Then
            LoadPlantSelector()
            Return
        End If
        Dim list As List(Of PageWebPart)
        If SiteLanguage = "fa" Then
            list = _pageWebPartService.GetPageWebParts(PlantDivisions.DivisionId, "Default.aspx")
        Else
            list = _pageWebPartService.GetPageWebParts(PlantDivisions.DivisionId, "Defaulten.aspx")
        End If

        Dim uControl As UserControl = LoadControl("~/UserControls/PanelWUC.ascx")

        Dim ucType As Type = uControl.GetType().BaseType
        Dim method As MethodInfo = ucType.GetMethod("SetValueVisitor")

        For Each item In list
            Dim _contentPlaceHolder As ContentPlaceHolder = PortalControls.Find(Page.Master, "ContentPlaceHolder1")
            If item.Webpart.WebpartType = 1 Then
                method = ucType.GetMethod("SetValueVisitor")

                If (method <> Nothing) Then
                    Dim parameters As Object
                    If SiteLanguage = "fa" Then
                        parameters = {item.Webpart.WebpartId.ToString, item.Webpart.HeaderPersian, item.Webpart.HtmlContentPersian, ""}
                    Else
                        parameters = {item.Webpart.WebpartId.ToString, item.Webpart.HeaderLatin, item.Webpart.HtmlContentLatin, ""}
                    End If
                    method.Invoke(uControl, parameters)
                End If

                Dim _placeHolder As PlaceHolder = _contentPlaceHolder.FindControl("PlaceHolder" & item.ColNo)
                If _placeHolder IsNot Nothing Then
                    _placeHolder.Controls.Add(uControl)
                End If
                'Select Case item.ColNo

                '    Case 1
                '        PlaceHolder1.Controls.Add(uControl)
                '    Case 2
                '        PlaceHolder2.Controls.Add(uControl)
                'End Select
            ElseIf item.Webpart.WebpartType = 2 Then

                Dim CustomeUControl As UserControl = LoadControl(item.Webpart.WebpartAddress)
                Dim UControlType As Type = CustomeUControl.GetType().BaseType

                Dim UCMethod As MethodInfo = UControlType.GetMethod(item.Webpart.WebpartMethod)
                If (UCMethod <> Nothing) Then
                    UCMethod.Invoke(CustomeUControl, Nothing)
                End If

                Dim _placeHolder As PlaceHolder = _contentPlaceHolder.FindControl("PlaceHolder" & item.ColNo)
                If _placeHolder IsNot Nothing Then
                    _placeHolder.Controls.Add(CustomeUControl)
                End If



                'Select Case item.ColNo
                '    Case 1
                '        PlaceHolder1.Controls.Add(CustomeUControl)
                '    Case 2
                '        PlaceHolder2.Controls.Add(CustomeUControl)
                'End Select
            ElseIf item.Webpart.WebpartType = 3 Then
                If item.Webpart.WebpartAddress.ToLower = "~/UserControls/DocManagementWUC.ascx".ToLower Then
                    'If User.Identity.IsAuthenticated Then
                    Dim CustomeUControl As UserControl = LoadControl(item.Webpart.WebpartAddress)
                    Dim ucType2 As Type = CustomeUControl.GetType().BaseType
                    Dim method2 As MethodInfo = ucType2.GetMethod("SetId")

                    If (method2 <> Nothing) Then
                        Dim parameters As Object
                        parameters = {item.Webpart.WebpartId.ToString}
                        method2.Invoke(CustomeUControl, parameters)
                    End If

                    Dim _placeHolder As PlaceHolder = _contentPlaceHolder.FindControl("PlaceHolder" & item.ColNo)
                    If _placeHolder IsNot Nothing Then
                        _placeHolder.Controls.Add(CustomeUControl)
                    End If
                    'End If
                End If
            End If
        Next

    End Sub

    Public Sub LoadPlantSelector()
        Dim divisionSelector As UserControl = LoadControl("~/UserControls/DivisionSelector.ascx")
        Dim contentPlaceHolder As ContentPlaceHolder = PortalControls.Find(Page.Master, "ContentPlaceHolder1")
        Dim placeHolder As PlaceHolder = contentPlaceHolder.FindControl("PlaceHolder2")
        If PlaceHolder IsNot Nothing Then
            PlaceHolder.Controls.Add(divisionSelector)
        End If
        Dim divisionWUC As UserControl = LoadControl("~/UserControls/DivisionWUC.ascx")
        Dim placeHolder1 As PlaceHolder = contentPlaceHolder.FindControl("PlaceHolder1")
        If placeHolder1 IsNot Nothing Then
            placeHolder1.Controls.Add(divisionWUC)
        End If
    End Sub
End Class
