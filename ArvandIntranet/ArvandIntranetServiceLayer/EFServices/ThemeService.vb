Imports System.Data.Entity
Imports Danesh.ArvandIntranet.ServiceLayer.Interfaces
Imports Danesh.ArvandIntranet.DataLayer.Context
Imports Danesh.ArvandIntranet.DomainClasses.Models
Imports Danesh.ArvandIntranet.CommonLibrary

Namespace Danesh.ArvandIntranet.ServiceLayer.EFServices

    Public Class ThemeService
        Implements IThemeService

        Private _uow As IUnitOfWork
        Private _Theme As IDbSet(Of Theme)

        Public Sub New(ByVal uow As IUnitOfWork)
            _uow = uow
            _Theme = _uow.Set(Of Theme)()
        End Sub

        Public Function GetAllThemes() As IList(Of Theme) Implements IThemeService.GetAllThemes
            Return _Theme.ToList
        End Function

    End Class

End Namespace

