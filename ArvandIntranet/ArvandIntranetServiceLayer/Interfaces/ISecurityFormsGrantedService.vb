Imports Danesh.ArvandIntranet.DomainClasses.Models

Namespace Danesh.ArvandIntranet.ServiceLayer.Interfaces
    Public Interface ISecurityFormsGrantedService

        Function GetOneSecurityFormsGrantedByFormName(UserId As Integer, FormName As String) As SecurityFormsGranted
        Function GetSecurityFormsGranted(UserId As Integer) As IList(Of SecurityFormsGranted)

        Function AddSecurityFormsGranted(ByVal securityFormsGranted As SecurityFormsGranted, ByVal err As Dictionary(Of String, String)) As Integer
        Sub EditSecurityFormsGranted(ByVal securityFormsGranted As SecurityFormsGranted, ByVal err As Dictionary(Of String, String))
        Function RemoveSecurityFormsGranted(ByVal securityFormsGranted As SecurityFormsGranted, ByVal err As Dictionary(Of String, String)) As Integer
        Function SecurityFormsGrantedCount() As Integer
        Function GetOneSecurityFormsGranted(ByVal UserId As Integer, ByVal FormPermission As Integer) As SecurityFormsGranted
        Function AllSecurityFormsGranted() As IList(Of SecurityFormsGranted)
    End Interface
End Namespace