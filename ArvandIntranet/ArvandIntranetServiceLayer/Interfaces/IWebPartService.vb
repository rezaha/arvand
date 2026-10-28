Imports Danesh.ArvandIntranet.DomainClasses.Models

Namespace Danesh.ArvandIntranet.ServiceLayer.Interfaces

    Public Interface IWebPartService


        Function EditWebPart(WebPart As Webpart) As Integer

        Function GetMaxWebpartId() As Integer

        Function GetWebPartsByType(divisionId As Integer, TypeId As Integer) As List(Of Webpart)

        Function GetOneWebPart(ByVal webpartId As Integer) As Webpart
        Function GetWebParts(ByVal divisionId As Integer) As List(Of Webpart)
        Function AddWebPart(ByVal WebPart As Webpart) As Integer
        Function DeleteWebPart(ByVal WebPart As Webpart) As Integer
    End Interface

End Namespace