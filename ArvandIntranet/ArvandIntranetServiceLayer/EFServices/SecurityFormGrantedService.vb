Imports System.Data.Entity
Imports Danesh.ArvandIntranet.ServiceLayer.Interfaces
Imports Danesh.ArvandIntranet.DataLayer.Context
Imports Danesh.ArvandIntranet.DomainClasses.Models
Imports DaneshInvestmentDomainClasses.ViewModel

Namespace Danesh.ArvandIntranet.ServiceLayer.EFServices

    Public Class SecurityFormsGrantedService
        Implements ISecurityFormsGrantedService

        Private _uow As IUnitOfWork
        Private _securityFormsGranted As IDbSet(Of SecurityFormsGranted)

        Public Sub New(ByVal uow As IUnitOfWork)
            _uow = uow
            _securityFormsGranted = _uow.Set(Of SecurityFormsGranted)()
        End Sub

        Public Function AddSecurityFormsGranted(ByVal securityFormsGranted As SecurityFormsGranted, ByVal err As Dictionary(Of String, String)) As Integer Implements ISecurityFormsGrantedService.AddSecurityFormsGranted
            Dim rowEffect As Integer = 0
            _securityFormsGranted.Add(securityFormsGranted)
            rowEffect = _uow.SaveChanges()
            Return rowEffect
        End Function


        Public Sub EditSecurityFormsGranted(ByVal securityFormsGranted As SecurityFormsGranted, ByVal err As Dictionary(Of String, String)) Implements ISecurityFormsGrantedService.EditSecurityFormsGranted
            _uow.SaveChanges()
            Return
        End Sub


        Public Function RemoveSecurityFormsGranted(ByVal securityFormsGranted As SecurityFormsGranted, ByVal err As Dictionary(Of String, String)) As Integer Implements ISecurityFormsGrantedService.RemoveSecurityFormsGranted
            Dim rowEffect As Integer = 0
            _securityFormsGranted.Remove(securityFormsGranted)
            rowEffect = _uow.SaveChanges()
            Return rowEffect
        End Function


        Public Function SecurityFormsGrantedCount() As Integer Implements ISecurityFormsGrantedService.SecurityFormsGrantedCount
            Return _securityFormsGranted.Count()
        End Function


        Public Function GetOneSecurityFormsGranted(ByVal UserId As Integer, ByVal FormPermission As Integer) As SecurityFormsGranted Implements ISecurityFormsGrantedService.GetOneSecurityFormsGranted
            Return _securityFormsGranted.Include(Function(a) a.SecurityUser).Include(Function(a) a.SecurityForm).FirstOrDefault(Function(a) a.UserId = UserId AndAlso a.FormPermission = FormPermission)
        End Function

        Public Function GetOneSecurityFormsGrantedByFormName(ByVal UserId As Integer, ByVal FormName As String) As SecurityFormsGranted Implements ISecurityFormsGrantedService.GetOneSecurityFormsGrantedByFormName
            Return _securityFormsGranted.Include(Function(a) a.SecurityUser).Include(Function(a) a.SecurityForm).FirstOrDefault(Function(a) a.UserId = UserId And a.SecurityForm.FormTag = FormName)
        End Function


        Public Function GetSecurityFormsGranted(UserId As Integer) As IList(Of SecurityFormsGranted) Implements ISecurityFormsGrantedService.GetSecurityFormsGranted
            Return _securityFormsGranted.Include(Function(a) a.SecurityUser).Include(Function(a) a.SecurityForm).Where(Function(a) a.UserId = UserId).ToList()
        End Function

        Public Function AllSecurityFormsGranted() As IList(Of SecurityFormsGranted) Implements ISecurityFormsGrantedService.AllSecurityFormsGranted
            Return _securityFormsGranted.Include(Function(a) a.SecurityUser).Include(Function(a) a.SecurityForm).ToList()
        End Function
    End Class

End Namespace