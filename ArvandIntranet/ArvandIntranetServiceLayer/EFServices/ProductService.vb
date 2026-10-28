Imports System.Data.Entity
Imports Danesh.ArvandIntranet.ServiceLayer.Interfaces
Imports Danesh.ArvandIntranet.DataLayer.Context
Imports Danesh.ArvandIntranet.DomainClasses.Models
Imports Danesh.ArvandIntranet.CommonLibrary

Namespace Danesh.ArvandIntranet.ServiceLayer.EFServices

    Public Class ProductService
        Implements IProductService

        Private _uow As IUnitOfWork
        Private _product As IDbSet(Of Products)

        Public Sub New()

        End Sub

        Public Sub New(ByVal uow As IUnitOfWork)
            _uow = uow
            _product = _uow.Set(Of Products)()
        End Sub

        Public Function GetProducts(ByVal startIndex As Integer, ByVal PageSize As Integer, ByVal sortexpression As String) As IList(Of Products) Implements IProductService.GetProducts
            If sortexpression = String.Empty Then
                sortexpression = "ProductId ASC"
            End If

            Dim SortColumnName As String = sortexpression.Split(" ")(0)
            Dim SortDirection As String = sortexpression.Split(" ")(1)

            Dim product = _product.AsQueryable
            Select Case SortColumnName
                Case "ProductId"
                    product = IIf(SortDirection.ToLower = "asc", product.OrderBy(Function(a) a.ProductId), product.OrderByDescending(Function(a) a.ProductId))
                Case "ProductNo"
                    product = IIf(SortDirection.ToLower = "asc", product.OrderBy(Function(a) a.ProductNo), product.OrderByDescending(Function(a) a.ProductNo))
                Case "Remark"
                    product = IIf(SortDirection.ToLower = "asc", product.OrderBy(Function(a) a.Remark), product.OrderByDescending(Function(a) a.Remark))
            End Select

            Return product.Skip(startIndex).Take(PageSize).ToList
        End Function

        Public Function GetOneProduct(ByVal productId As Integer) As Products Implements IProductService.GetOneProduct
            Return _product.Find(productId)
        End Function

        Public Function AllProducts(Optional ByVal sortexpression As String = Nothing) As IList(Of Products) Implements IProductService.AllProducts
            If sortexpression = String.Empty Then
                sortexpression = "ProductId ASC"
            End If

            Dim SortColumnName As String = sortexpression.Split(" ")(0)
            Dim SortDirection As String = sortexpression.Split(" ")(1)

            Dim Product = _product.AsQueryable
            Select Case SortColumnName
                Case "ProductId"
                    Product = IIf(SortDirection.ToLower = "asc", Product.OrderBy(Function(a) a.ProductId), Product.OrderByDescending(Function(a) a.ProductId))
                Case "ProductNo"
                    Product = IIf(SortDirection.ToLower = "asc", Product.OrderBy(Function(a) a.ProductNo), Product.OrderByDescending(Function(a) a.ProductNo))
                Case "Remark"
                    Product = IIf(SortDirection.ToLower = "asc", Product.OrderBy(Function(a) a.Remark), Product.OrderByDescending(Function(a) a.Remark))
            End Select

            Return _product.ToList
        End Function

        Public Function AddProducts(ByVal Product As Products) As Integer Implements IProductService.AddProducts
            Dim rowEffect As Integer = 0
            _product.Add(Product)
            rowEffect = _uow.SaveChanges()
            Return rowEffect
        End Function

        Public Function UpdateProducts() As Integer Implements IProductService.UpdateProducts
            Dim rowEffect As Integer = 0
            rowEffect = _uow.SaveChanges()
            Return rowEffect
        End Function

        Public Function DeleteProduct(ByVal Product As Products) As Integer Implements IProductService.DeleteProduct
            Dim rowEffect As Integer = 0
            _product.Remove(Product)
            rowEffect = _uow.SaveChanges()
            Return rowEffect
        End Function

        Public Function GetProductBySearch(ByVal SearchParameter As String) As IList(Of Products) Implements IProductService.GetProductBySearch
            Dim ProductList As New List(Of Products)
            If SearchParameter <> "" Then
                Dim SearchedProduct = _product.AsQueryable()
                SearchedProduct = SearchedProduct.Where(Function(a) a.NamePersian.Contains(SearchParameter) Or a.SummaryPersian.Contains(SearchParameter) Or a.DescriptionPersian.Contains(SearchParameter))
                Dim list = SearchedProduct.ToList()

                For Each item In list
                    If item.DescriptionPersian.StripHTML.ToLower().Contains(SearchParameter.ToLower()) Or item.NamePersian.ToLower().Contains(SearchParameter.ToLower()) Or item.SummaryPersian.ToLower().Contains(SearchParameter.ToLower()) Then
                        ProductList.Add(item)
                    End If
                Next
            End If
            Return ProductList
        End Function

        Public Function GetProductBySearchLatin(ByVal SearchParameter As String) As IList(Of Products) Implements IProductService.GetProductBySearchLatin
            Dim ProductList As New List(Of Products)
            If SearchParameter <> "" Then
                Dim SearchedProduct = _product.AsQueryable()
                SearchedProduct = SearchedProduct.Where(Function(a) a.NameLatin.Contains(SearchParameter) Or a.SummaryLatin.Contains(SearchParameter) Or a.DescriptionLatin.Contains(SearchParameter))
                Dim list = SearchedProduct.ToList()

                For Each item In list
                    If item.DescriptionLatin.StripHTML.ToLower().Contains(SearchParameter.ToLower()) Or item.NameLatin.ToLower().Contains(SearchParameter.ToLower()) Or item.SummaryLatin.ToLower().Contains(SearchParameter.ToLower()) Then
                        ProductList.Add(item)
                    End If
                Next
            End If
            Return ProductList
        End Function

        Public Function GetAllProductByDivisionId(ByVal divisionId As Integer) As IList(Of Products) Implements IProductService.GetAllProductByDivisionId
            Return _product.Where(Function(a) a.DivisionId = divisionId).ToList
        End Function

    End Class

End Namespace