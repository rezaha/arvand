Imports System.Data.Entity
Imports Danesh.ArvandIntranet.ServiceLayer.Interfaces
Imports Danesh.ArvandIntranet.DataLayer.Context
Imports Danesh.ArvandIntranet.DomainClasses.Models

Namespace Danesh.ArvandIntranet.ServiceLayer.EFServices
    Public Class ContactService
        Implements IContactService

        Private _uow As IUnitOfWork
        Private _contact As IDbSet(Of Contact)

        Public Sub New(ByVal uow As IUnitOfWork)
            _uow = uow
            _contact = _uow.Set(Of Contact)()
        End Sub

        Public Function GetAllContactByDivisionId(ByVal divisionId As Integer) As IList(Of Contact) Implements IContactService.GetAllContactByDivisionId
            Return _contact.Where(Function(a) a.DIVISION_ID = divisionId).ToList
        End Function

    End Class

End Namespace

