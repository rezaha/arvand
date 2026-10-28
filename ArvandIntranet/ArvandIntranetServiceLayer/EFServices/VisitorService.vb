Imports System.Data.Entity
Imports Danesh.ArvandIntranet.ServiceLayer.Interfaces
Imports Danesh.ArvandIntranet.DataLayer.Context
Imports Danesh.ArvandIntranet.DomainClasses.Models

Namespace Danesh.ArvandIntranet.ServiceLayer.EFServices

    Public Class VisitorService
        Implements IVisitorService

        Private _uow As IUnitOfWork
        Private _visitor As IDbSet(Of Visitor)

        Public Sub New()

        End Sub

        Public Sub New(ByVal uow As IUnitOfWork)
            _uow = uow
            _visitor = _uow.Set(Of Visitor)()
        End Sub

        Public Function AddVisitor(ByVal visitor As Visitor, ByVal err As Dictionary(Of String, String)) As Integer Implements IVisitorService.AddVisitor
            Dim rowEffect As Integer = 0
            _visitor.Add(visitor)
            rowEffect = _uow.SaveChanges()
            Return rowEffect
        End Function

        Public Function GetAllVisitorByDivisionId(ByVal divisionId As Integer) As IList(Of Visitor) Implements IVisitorService.GetAllVisitorByDivisionId
            Return _visitor.Where(Function(a) a.DivisionId = divisionId).ToList
        End Function

    End Class

End Namespace