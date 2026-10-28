Imports Microsoft.VisualBasic
Imports StructureMap
Imports System.Threading
Imports System.Globalization

Public Class BaseUserControl
    Inherits System.Web.UI.UserControl

    Private _siteLanguage As String
    Private _siteLocation As String
    Private _plantDivisions As PlantDivisions
    Public Property _plantDivisionsService As IPlantDivisionsService

    Public Sub New()
        ObjectFactory.BuildUp(Me)
    End Sub


    Private Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        If Page.RouteData.Values("language") IsNot Nothing Then
            _siteLanguage = Page.RouteData.Values("language").ToString
        End If
    End Sub

    Public Property SiteLocation As String
        Get
            If Page.RouteData.Values("location") IsNot Nothing Then
                _siteLocation = Page.RouteData.Values("location").ToString.ToUpper
            Else
                _siteLocation = String.Empty
            End If
            Return _siteLocation
        End Get
        Set(value As String)
            _siteLocation = value
        End Set
    End Property

    Public Property SiteLanguage As String
        Get
            If Page.RouteData.Values("language") IsNot Nothing Then
                _siteLanguage = Page.RouteData.Values("language").ToString.ToLower
            Else
                _siteLanguage = String.Empty
            End If
            Return _siteLanguage
        End Get
        Set(value As String)
            _siteLanguage = value
        End Set
    End Property

    Public Property PlantDivisions As PlantDivisions
        Get
            If Page.RouteData.Values("divisionAbbr") IsNot Nothing Then
                If _plantDivisions Is Nothing Then
                    Dim plantDivisionName = Page.RouteData.Values("divisionAbbr").ToString.ToUpper
                    _plantDivisions = _plantDivisionsService.GetPlantDivisions(plantDivisionName)
                End If
            Else
                _siteLocation = String.Empty
            End If
            Return _plantDivisions
        End Get
        Set(value As PlantDivisions)
            _plantDivisions = value
        End Set
    End Property
End Class
