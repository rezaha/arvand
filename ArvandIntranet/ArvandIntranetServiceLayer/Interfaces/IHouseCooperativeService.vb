Imports Danesh.ArvandIntranet.DomainClasses.Models

Namespace Danesh.ArvandIntranet.ServiceLayer.Interfaces
    Public Interface IHouseCooperativeService

        Function EditHouseCooperative(houseCooperative As HouseCooperative, err As Dictionary(Of String, String)) As Integer

        Function AddHouseCooperative(ByVal houseCooperative As HouseCooperative, ByVal err As Dictionary(Of String, String)) As Integer
        Function DeleteHouseCooperative(ByVal houseCooperative As HouseCooperative, ByVal err As Dictionary(Of String, String)) As Integer
        Function GetOne(ByVal houseCooperativeId As Integer) As HouseCooperative
        Function GetOneByNationalId(ByVal nationalId As String) As HouseCooperative
        Function GetAllHouseCooperatives() As IList(Of HouseCooperative)
        Function GetHouseCooperativeCount() As Integer
        Function GetHouseCooperative(ByVal startIndex As Integer, ByVal pageSize As Integer, ByVal sortexpression As String) As IList(Of HouseCooperative)
    End Interface
End Namespace