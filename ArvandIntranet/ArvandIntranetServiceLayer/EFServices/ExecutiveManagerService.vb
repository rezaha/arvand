Imports System.Data.Entity
Imports Danesh.ArvandIntranet.ServiceLayer.Interfaces
Imports Danesh.ArvandIntranet.DataLayer.Context
Imports Danesh.ArvandIntranet.DomainClasses.Models

Namespace Danesh.ArvandIntranet.ServiceLayer.EFServices

    Public Class ExecutiveManagerService
        Implements IExecutiveManagerService

        Private _uow As IUnitOfWork
        Private _executiveManager As IDbSet(Of ExecutiveManagers)

        Public Sub New(ByVal uow As IUnitOfWork)
            _uow = uow
            _executiveManager = _uow.Set(Of ExecutiveManagers)()
        End Sub

        Public Function GetAllManagers(ByVal divisionId As Integer) As IList(Of ExecutiveManagers) Implements IExecutiveManagerService.GetAllManagers
            Return _executiveManager.Where(Function(a) a.DivisionId = divisionId).OrderBy(Function(a) a.ColNo).ThenBy(Function(a) a.RowNo).ToList
        End Function

        Public Function GetOneManager(ByVal managerId As Integer) As ExecutiveManagers Implements IExecutiveManagerService.GetOneManager
            Return _executiveManager.FirstOrDefault(Function(a) a.ManagerId = managerId)
        End Function

        Public Function AddManager(ByVal executiveManager As ExecutiveManagers, ByVal err As Dictionary(Of String, String)) As Integer Implements IExecutiveManagerService.AddManager
            Dim rowEffect As Integer = 0
            _executiveManager.Add(executiveManager)
            rowEffect = _uow.SaveChanges()
            Return rowEffect
        End Function

        Public Function EditManager(ByVal executiveManager As ExecutiveManagers, ByVal err As Dictionary(Of String, String)) As Integer Implements IExecutiveManagerService.EditManager
            Dim rowEffect As Integer = 0
            rowEffect = _uow.SaveChanges()
            Return rowEffect
        End Function

        Public Function RemoveManager(ByVal executiveManager As ExecutiveManagers, ByVal err As Dictionary(Of String, String)) As Integer Implements IExecutiveManagerService.RemoveManager
            Dim rowEffect As Integer = 0
            _executiveManager.Remove(executiveManager)
            rowEffect = _uow.SaveChanges()
            Return rowEffect
        End Function

    End Class

End Namespace

