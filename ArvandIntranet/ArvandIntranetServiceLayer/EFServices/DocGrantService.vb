Imports System.Data.Entity
Imports Danesh.ArvandIntranet.ServiceLayer.Interfaces
Imports Danesh.ArvandIntranet.DataLayer.Context
Imports Danesh.ArvandIntranet.DomainClasses.Models
Imports DaneshInvestmentDomainClasses.ViewModel

Namespace Danesh.ArvandIntranet.ServiceLayer.EFServices

    Public Class DocGrantService
        Implements IDocGrantService

        Private _uow As IUnitOfWork
        Private _docGrant As IDbSet(Of DocGrant)

        Public Sub New(ByVal uow As IUnitOfWork)
            _uow = uow
            _docGrant = _uow.Set(Of DocGrant)()
        End Sub

        Public Function GetOneDocGrant(ByVal grantId As Integer) As DocGrant Implements IDocGrantService.GetOneDocGrant
            Return _docGrant.Find(grantId)
        End Function

        'Public Function GetDocManagementsForDivision(ByVal divisionId As Integer) As List(Of DocGrant)
        '    Return _docGrant.Where(Function(a) a.Webpart.DivisionId = divisionId).ToList
        'End Function

        Public Function AddDocGrant(ByVal docGrant As DocGrant) As Integer Implements IDocGrantService.AddDocGrant
            Dim rowEffect As Integer = 0
            _docGrant.Add(docGrant)
            rowEffect = _uow.SaveChanges()
            Return rowEffect
        End Function


        Public Function GetDocGrantByDocId(ByVal DocId As Integer) As List(Of DocGrant) Implements IDocGrantService.GetDocGrantByDocId
            Return _docGrant.Where(Function(a) a.DocId = DocId).ToList()
        End Function

        Public Function GetDocGrantByWebPartId(ByVal WebPartId As Integer) As List(Of UserCountByWebPart) Implements IDocGrantService.GetDocGrantByWebPartId
            Dim list = _docGrant.Include(Function(a) a.DocManagement).Where(Function(a) a.DocManagement.WebPartId = WebPartId And a.DocManagement.PublicGrant = False).GroupBy(Function(a) a.UserDomain).Select(Function(g) New UserCountByWebPart With {.UserName = g.Key, .Count = g.Count()}).ToList()
            Return list
        End Function

        Public Function GetDocGrantByDocIdUserName(ByVal DocId As Integer, ByVal UserName As String) As List(Of DocGrant) Implements IDocGrantService.GetDocGrantByDocIdUserName
            Return _docGrant.Where(Function(a) a.DocId = DocId And a.UserDomain.ToLower() = UserName.ToLower()).ToList()
        End Function

        'Public Function AddDocManagements(ByVal docManagements As List(Of DocGrant)) As Integer
        '    Dim rowEffect As Integer = 0
        '    For Each item In docManagements
        '        _docGrant.Add(item)
        '    Next

        '    rowEffect = _uow.SaveChanges()
        '    Return rowEffect
        'End Function

        Public Function EditDocGrant(ByVal docGrant As DocGrant) As Integer Implements IDocGrantService.EditDocGrant
            Dim rowEffect As Integer = 0
            rowEffect = _uow.SaveChanges()
            Return rowEffect
        End Function

        Public Function DeleteDocGrant(ByVal docGrant As DocGrant) As Integer Implements IDocGrantService.DeleteDocGrant
            Dim rowEffect As Integer = 0
            _docGrant.Remove(docGrant)
            rowEffect = _uow.SaveChanges()
            Return rowEffect
        End Function

        Public Function DeleteDocGrantByDocId(ByVal docId As Integer) As Integer Implements IDocGrantService.DeleteDocGrantByDocId
            Dim DocGrants = GetDocGrantByDocId(docId)
            For Each Item In DocGrants
                _docGrant.Remove(Item)
            Next
            Dim rowEffect As Integer = 0
            rowEffect = _uow.SaveChanges()
            Return rowEffect
        End Function

        'new add
        Public Function SearchDocWebpart(ByVal webpartId As Integer, ByVal userName As String) As IList(Of DocGrant) Implements IDocGrantService.SearchDocWebpart
            Return _docGrant.Where(Function(a) a.UserDomain.ToLower = userName.ToLower And a.DocManagement.WebPartId = webpartId).ToList
        End Function

    End Class

End Namespace