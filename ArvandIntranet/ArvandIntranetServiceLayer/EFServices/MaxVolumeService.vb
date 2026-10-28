Imports System.Data.Entity
Imports Danesh.ArvandIntranet.ServiceLayer.Interfaces
Imports Danesh.ArvandIntranet.DataLayer.Context
Imports Danesh.ArvandIntranet.DomainClasses.Models

Namespace Danesh.ArvandIntranet.ServiceLayer.EFServices

    Public Class MaxVolumeService
        Implements IMaxVolumeService

        Private _uow As IUnitOfWork
        Private _maxVolume As IDbSet(Of MaxVolume)

        Public Sub New()

        End Sub


        Public Sub New(ByVal uow As IUnitOfWork)
            _uow = uow
            _maxVolume = _uow.Set(Of MaxVolume)()
        End Sub

        Public Function AllMaxVolumes() As IList(Of MaxVolume) Implements IMaxVolumeService.AllMaxVolumes
            Return _maxVolume.Include(Function(a) a.PlantDivision).ToList()
        End Function


        Public Function GetMaxVolumeByDivisionId(ByVal Divisionid As Integer) As MaxVolume Implements IMaxVolumeService.GetMaxVolumeByDivisionId
            Return _maxVolume.FirstOrDefault(Function(a) a.DivisionId = Divisionid)
        End Function


        Public Function AddMaxVolume(ByVal album As MaxVolume, ByVal err As Dictionary(Of String, String)) As Integer Implements IMaxVolumeService.AddMaxVolume
            Dim rowEffect As Integer = 0
            _maxVolume.Add(album)
            rowEffect = _uow.SaveChanges()
            Return rowEffect
        End Function

        Public Function EditMaxVolume(ByVal maxVolume As MaxVolume, ByVal err As Dictionary(Of String, String)) As Integer Implements IMaxVolumeService.EditMaxVolume
            Dim rowEffect As Integer = 0
            rowEffect = _uow.SaveChanges()
            Return rowEffect
        End Function


    End Class
End Namespace
