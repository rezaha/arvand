Imports System.Data.Entity

Namespace Danesh.ArvandIntranet.DataLayer.Context

    Public Interface IUnitOfWork
        Function [Set](Of TEntity As Class)() As IDbSet(Of TEntity)
        Function SaveChanges() As Integer
    End Interface

End Namespace