Imports System.Data.Entity
Imports Danesh.ArvandIntranet.ServiceLayer.Interfaces
Imports Danesh.ArvandIntranet.DataLayer.Context
Imports Danesh.ArvandIntranet.DomainClasses.Models

Namespace Danesh.ArvandIntranet.ServiceLayer.EFServices
   

    Public Class SecurityFormsService
        Implements ISecurityFormsService

        Private _uow As IUnitOfWork
        Private _securityForms As IDbSet(Of SecurityForms)

        Public Sub New(ByVal uow As IUnitOfWork)
            _uow = uow
            _securityForms = _uow.Set(Of SecurityForms)()
        End Sub



        Public Function AddSecurityForms(ByVal securityForms As SecurityForms, ByVal err As Dictionary(Of String, String)) As Integer Implements ISecurityFormsService.AddSecurityForms
            Dim rowEffect As Integer = 0
            _securityForms.Add(securityForms)
            rowEffect = _uow.SaveChanges()
            Return rowEffect
        End Function


        Public Sub EditSecurityForms(ByVal securityForms As SecurityForms, ByVal err As Dictionary(Of String, String)) Implements ISecurityFormsService.EditSecurityForms
            _uow.SaveChanges()
            Return
        End Sub


        Public Function RemoveSecurityForms(ByVal securityForms As SecurityForms, ByVal err As Dictionary(Of String, String)) As Integer Implements ISecurityFormsService.RemoveSecurityForms
            Dim rowEffect As Integer = 0
            _securityForms.Remove(securityForms)
            rowEffect = _uow.SaveChanges()
            Return rowEffect
        End Function


        Public Function SecurityFormsCount() As Integer Implements ISecurityFormsService.SecurityFormsCount
            Return _securityForms.Count()
        End Function


        Public Function GetOneSecurityForms(ByVal FormPermission As Integer) As SecurityForms Implements ISecurityFormsService.GetOneSecurityForms
            Return _securityForms.FirstOrDefault(Function(a) a.FormPermisionId = FormPermission)
        End Function


        Public Function AllSecurityForms() As IList(Of SecurityForms) Implements ISecurityFormsService.AllSecurityForms
            Return _securityForms.ToList()
        End Function




    End Class
End Namespace