Imports Microsoft.VisualBasic
Imports StructureMap


Public Class BaseMasterPage
    Inherits System.Web.UI.MasterPage

    Public Sub New()
        ObjectFactory.BuildUp(Me)
    End Sub

    Private _plantDivisions As PlantDivisions
    Public Property _plantDivisionsService As IPlantDivisionsService

    Private _siteLanguage As String
    Private _siteLocation As String

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

    Public ReadOnly Property SiteLocation As String
        Get
            If Page.RouteData.Values("location") Is Nothing Then
                _siteLocation = Page.RouteData.Values("location").ToString.ToLower
            Else
                _siteLocation = String.Empty
            End If
            Return _siteLocation
        End Get
    End Property

    Public ReadOnly Property SiteLanguage As String
        Get
            If Page.RouteData.Values("language") IsNot Nothing Then
                _siteLanguage = Page.RouteData.Values("language").ToString.ToLower
            Else
                _siteLanguage = String.Empty
            End If
            Return _siteLanguage
        End Get
    End Property

End Class
