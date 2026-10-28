Imports Danesh.ArvandIntranet.DomainClasses.Models

Namespace Danesh.ArvandIntranet.ServiceLayer.Interfaces

    Public Interface ISecurityUserService

        Function EditSecurityUser(securityUser As SecurityUsers) As Integer

        Function GetAllSecurityUser() As IList(Of SecurityUsers)

        Function GetAllSecurityUserByDivisionId(divisionId As Integer) As IList(Of SecurityUsers)

        Function GetOneSecurityUserByUserName(ByVal userName As String) As SecurityUsers
        Function GetOneSecurityUser(ByVal userId As Integer) As SecurityUsers
        Function AddSecurityUser(ByVal securityUser As SecurityUsers) As Integer
        Function DeleteSecurityUser(ByVal securityUser As SecurityUsers) As Integer
    End Interface

End Namespace