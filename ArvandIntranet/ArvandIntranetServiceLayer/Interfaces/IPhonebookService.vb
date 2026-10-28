Imports Danesh.ArvandIntranet.DomainClasses.Models

Namespace Danesh.ArvandIntranet.ServiceLayer.Interfaces

    Public Interface IPhonebookService

        Function GetAllPhoneBooksByDivisionId(divisionId As Integer) As IList(Of Phonebook)

        Function UpdatePhoneBook() As Integer
        Function DeletePhoneBook(ByVal PhoneBookItem As Phonebook) As Integer
        Function AddPhoneBook(ByVal PhoneBookItem As Phonebook) As Integer
        Function GetPhoneBooks() As IList(Of Phonebook)
        Function GetOnePlantDivisions(Optional ByVal PhonebookId As Integer? = Nothing) As Phonebook
    End Interface

End Namespace