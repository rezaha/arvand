Imports System.Data.Entity
Imports Danesh.ArvandIntranet.ServiceLayer.Interfaces
Imports Danesh.ArvandIntranet.DataLayer.Context
Imports Danesh.ArvandIntranet.DomainClasses.Models

Namespace Danesh.ArvandIntranet.ServiceLayer.EFServices

    Public Class DocManagementService
        Implements IDocManagementService

        Private _uow As IUnitOfWork
        Private _docManagement As IDbSet(Of DocManagement)

        Public Sub New(ByVal uow As IUnitOfWork)
            _uow = uow
            _docManagement = _uow.Set(Of DocManagement)()
        End Sub

        Public Function GetOneDocManagement(ByVal docId As Integer) As DocManagement Implements IDocManagementService.GetOneDocManagement
            Return _docManagement.Find(docId)
        End Function

        Public Function GetDocManagementsForDivision(ByVal divisionId As Integer) As List(Of DocManagement) Implements IDocManagementService.GetDocManagementsForDivision
            Return _docManagement.Where(Function(a) a.Webpart.DivisionId = divisionId).ToList
        End Function

        Public Function AddDocManagement(ByVal docManagement As DocManagement) As Integer Implements IDocManagementService.AddDocManagement
            Dim rowEffect As Integer = 0
            _docManagement.Add(docManagement)
            rowEffect = _uow.SaveChanges()
            Return rowEffect
        End Function


        Public Function GetDocManagementsForWebpart(ByVal webpartId As Integer) As List(Of DocManagement) Implements IDocManagementService.GetDocManagementsForWebpart
            Return _docManagement.Where(Function(a) a.WebPartId = webpartId).ToList
        End Function

        Public Function AddDocManagements(ByVal docManagements As List(Of DocManagement)) As Integer Implements IDocManagementService.AddDocManagements
            Dim rowEffect As Integer = 0
            For Each item In docManagements
                If SearchByFileTitle(item.DocTitle) Then
                    _docManagement.Add(item)
                End If
            Next
            rowEffect = _uow.SaveChanges()
            Return rowEffect
        End Function

        Private Function SearchByFileTitle(ByVal DocTitle As String) As Boolean
            If _docManagement.Where(Function(a) a.DocTitle = DocTitle).ToList.Count = 0 Then
                Return True
            Else
                Return False
            End If
        End Function

        Public Function EditDocManagement(ByVal docManagement As DocManagement) As Integer Implements IDocManagementService.EditDocManagement
            Dim rowEffect As Integer = 0
            rowEffect = _uow.SaveChanges()
            Return rowEffect
        End Function

        Public Function DeleteDocManagement(ByVal docManagement As DocManagement) As Integer Implements IDocManagementService.DeleteDocManagement
            Dim rowEffect As Integer = 0
            _docManagement.Remove(docManagement)
            rowEffect = _uow.SaveChanges()
            Return rowEffect
        End Function

        Public Function DeleteDocManagementByWebPartId(ByVal webPartId As Integer) As Integer Implements IDocManagementService.DeleteDocManagementByWebPartId
            Dim rowEffect As Integer = 0

            Dim DocManagements = GetDocManagementsForWebpart(webPartId)

            For Each item In DocManagements
                _docManagement.Remove(item)
            Next
            rowEffect = _uow.SaveChanges()
            Return rowEffect
        End Function


        Public Function GetDocManagementBySearch(ByVal SearchParameter As String) As IList(Of DocManagement) Implements IDocManagementService.GetDocManagementBySearch
            Dim FileList As New List(Of DocManagement)

            If SearchParameter <> "" Then
                Dim SearchedFiles = _docManagement.Where(Function(a) a.Active And (a.PublicGrant = True))
                SearchedFiles = SearchedFiles.Where(Function(a) a.DocTitle.Contains(SearchParameter))
                Dim list = SearchedFiles.ToList()

                For Each item In list
                    FileList.Add(item)
                Next
            End If
            Return FileList
        End Function

    End Class




End Namespace