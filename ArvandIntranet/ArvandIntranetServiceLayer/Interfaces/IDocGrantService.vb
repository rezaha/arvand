Imports Danesh.ArvandIntranet.DomainClasses.Models
Imports DaneshInvestmentDomainClasses.ViewModel

Namespace Danesh.ArvandIntranet.ServiceLayer.EFServices
    Public Interface IDocGrantService

        Function GetDocGrantByWebPartId(WebPartId As Integer) As List(Of UserCountByWebPart)


        Function DeleteDocGrantByDocId(docId As Integer) As Integer

        Function SearchDocWebpart(webpartId As Integer, userName As String) As IList(Of DocGrant)

        Function GetOneDocGrant(ByVal grantId As Integer) As DocGrant
        Function AddDocGrant(ByVal docManagement As DocGrant) As Integer
        Function EditDocGrant(ByVal docGrant As DocGrant) As Integer
        Function DeleteDocGrant(ByVal docGrant As DocGrant) As Integer

        Function GetDocGrantByDocIdUserName(DocId As Integer, UserName As String) As List(Of DocGrant)

        Function GetDocGrantByDocId(DocId As Integer) As List(Of DocGrant)
    End Interface
End Namespace