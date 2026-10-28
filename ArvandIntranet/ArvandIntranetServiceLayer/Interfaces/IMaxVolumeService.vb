Imports Danesh.ArvandIntranet.DomainClasses.Models

Namespace Danesh.ArvandIntranet.ServiceLayer.Interfaces

    Public Interface IMaxVolumeService

        Function GetMaxVolumeByDivisionId(Divisionid As Integer) As MaxVolume

        Function AddMaxVolume(ByVal album As MaxVolume, ByVal err As Dictionary(Of String, String)) As Integer
        Function EditMaxVolume(ByVal maxVolume As MaxVolume, ByVal err As Dictionary(Of String, String)) As Integer
        Function AllMaxVolumes() As IList(Of MaxVolume)
    End Interface

End Namespace