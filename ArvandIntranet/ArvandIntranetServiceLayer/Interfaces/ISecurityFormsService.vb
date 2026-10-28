Imports Danesh.ArvandIntranet.DomainClasses.Models

Namespace Danesh.ArvandIntranet.ServiceLayer.Interfaces

    Public Interface ISecurityFormsService
        Function AddSecurityForms(ByVal securityForms As SecurityForms, ByVal err As Dictionary(Of String, String)) As Integer
        Sub EditSecurityForms(ByVal securityForms As SecurityForms, ByVal err As Dictionary(Of String, String))
        Function RemoveSecurityForms(ByVal securityForms As SecurityForms, ByVal err As Dictionary(Of String, String)) As Integer
        Function SecurityFormsCount() As Integer
        Function GetOneSecurityForms(ByVal FormPermission As Integer) As SecurityForms
        Function AllSecurityForms() As IList(Of SecurityForms)
    End Interface
End Namespace