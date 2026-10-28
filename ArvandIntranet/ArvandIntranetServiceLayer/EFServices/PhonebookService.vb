Imports System.Data.Entity
Imports Danesh.ArvandIntranet.ServiceLayer.Interfaces
Imports Danesh.ArvandIntranet.DataLayer.Context
Imports Danesh.ArvandIntranet.DomainClasses.Models

Namespace Danesh.ArvandIntranet.ServiceLayer.EFServices

    Public Class PhonebookService
        Implements IPhonebookService

        Private _uow As IUnitOfWork
        Private _Phonebook As IDbSet(Of Phonebook)

        Public Sub New()

        End Sub

        Public Sub New(ByVal uow As IUnitOfWork)
            _uow = uow
            _Phonebook = _uow.Set(Of Phonebook)()
        End Sub

        Public Function UpdatePhoneBook() As Integer Implements IPhonebookService.UpdatePhoneBook
            Dim rowEffect As Integer = 0
            rowEffect = _uow.SaveChanges()
            Return rowEffect
        End Function

        Public Function DeletePhoneBook(ByVal PhoneBookItem As Phonebook) As Integer Implements IPhonebookService.DeletePhoneBook
            Dim rowEffect As Integer = 0
            _Phonebook.Remove(PhoneBookItem)
            rowEffect = _uow.SaveChanges()
            Return rowEffect
        End Function

        Public Function AddPhoneBook(ByVal PhoneBookItem As Phonebook) As Integer Implements IPhonebookService.AddPhoneBook
            Dim rowEffect As Integer = 0
            _Phonebook.Add(PhoneBookItem)
            rowEffect = _uow.SaveChanges()
            Return rowEffect
        End Function

        Public Function GetPhoneBooks() As IList(Of Phonebook) Implements IPhonebookService.GetPhoneBooks
            Dim PhoneBookItems = _Phonebook.AsQueryable
            Dim PhoneBooksList = PhoneBookItems.ToList()
            Return PhoneBooksList
        End Function

        Public Function GetOnePlantDivisions(Optional ByVal PhonebookId As Integer? = Nothing) As Phonebook Implements IPhonebookService.GetOnePlantDivisions
            Return _Phonebook.FirstOrDefault(Function(a) a.PhonebookId = PhonebookId)
        End Function

        Public Function GetAllPhoneBooksByDivisionId(ByVal divisionId As Integer) As IList(Of Phonebook) Implements IPhonebookService.GetAllPhoneBooksByDivisionId
            Return _Phonebook.Where(Function(a) a.DivisionId = divisionId).ToList
        End Function

    End Class

End Namespace