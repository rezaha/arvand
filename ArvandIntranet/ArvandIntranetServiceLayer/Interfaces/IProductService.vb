Imports Danesh.ArvandIntranet.DomainClasses.Models

Namespace Danesh.ArvandIntranet.ServiceLayer.Interfaces

    Public Interface IProductService

        Function GetAllProductByDivisionId(divisionId As Integer) As IList(Of Products)

        Function GetProductBySearchLatin(SearchParameter As String) As IList(Of Products)

        Function GetProductBySearch(SearchParameter As String) As IList(Of Products)

        Function DeleteProduct(Product As Products) As Integer

        Function UpdateProducts() As Integer



        Function AddProducts(Location As Products) As Integer

        Function GetOneProduct(productId As Integer) As Products

        Function GetProducts(ByVal startIndex As Integer, ByVal PageSize As Integer, ByVal sortexpression As String) As IList(Of Products)
        Function AllProducts(Optional ByVal sortexpression As String = Nothing) As IList(Of Products)
    End Interface

End Namespace