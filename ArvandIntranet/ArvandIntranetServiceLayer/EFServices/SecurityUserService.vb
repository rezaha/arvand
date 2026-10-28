Imports System.Data.Entity
Imports Danesh.ArvandIntranet.ServiceLayer.Interfaces
Imports Danesh.ArvandIntranet.DataLayer.Context
Imports Danesh.ArvandIntranet.DomainClasses.Models

Namespace Danesh.ArvandIntranet.ServiceLayer.EFServices

    Public Class SecurityUserService
        Implements ISecurityUserService

        Private _uow As IUnitOfWork
        Private _securityUser As IDbSet(Of SecurityUsers)

        Public Sub New()

        End Sub

        Public Sub New(ByVal uow As IUnitOfWork)
            _uow = uow
            _securityUser = _uow.Set(Of SecurityUsers)()
        End Sub

        Public Function GetOneSecurityUser(ByVal userId As Integer) As SecurityUsers Implements ISecurityUserService.GetOneSecurityUser
            Return _securityUser.Find(userId)
        End Function

        Public Function GetOneSecurityUserByUserName(ByVal userName As String) As SecurityUsers Implements ISecurityUserService.GetOneSecurityUserByUserName
            Return _securityUser.FirstOrDefault(Function(a) a.UserName.ToLower = userName.ToLower)
        End Function

        Public Function AddSecurityUser(ByVal securityUser As SecurityUsers) As Integer Implements ISecurityUserService.AddSecurityUser
            Dim rowEffect As Integer = 0
            _securityUser.Add(securityUser)
            rowEffect = _uow.SaveChanges()
            Return rowEffect
        End Function

        Public Function EditSecurityUser(ByVal securityUser As SecurityUsers) As Integer Implements ISecurityUserService.EditSecurityUser
            Dim rowEffect As Integer = 0
            rowEffect = _uow.SaveChanges()
            Return rowEffect
        End Function

        Public Function DeleteSecurityUser(ByVal securityUser As SecurityUsers) As Integer Implements ISecurityUserService.DeleteSecurityUser
            Dim rowEffect As Integer = 0
            _securityUser.Remove(securityUser)
            rowEffect = _uow.SaveChanges()
            Return rowEffect
        End Function

        Public Function GetAllSecurityUserByDivisionId(ByVal divisionId As Integer) As IList(Of SecurityUsers) Implements ISecurityUserService.GetAllSecurityUserByDivisionId
            Return _securityUser.Where(Function(a) a.DivisionId = divisionId).ToList
        End Function

        Public Function GetAllSecurityUser() As IList(Of SecurityUsers) Implements ISecurityUserService.GetAllSecurityUser
            Return _securityUser.ToList
        End Function

    End Class

End Namespace