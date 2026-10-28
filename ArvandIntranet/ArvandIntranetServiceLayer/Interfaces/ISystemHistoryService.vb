Imports Danesh.ArvandIntranet.DomainClasses.Models

Public interface ISystemHistoryService
    Function AddSystemHistory(systemHistory As SystemHistory, err As Dictionary(Of String, String)) As Integer
    Sub EditSystemHistory(systemHistory As SystemHistory, err As Dictionary(Of String, String))
    Function RemoveSystemHistory(systemHistory As SystemHistory, err As Dictionary(Of String, String)) As Integer
    Function SystemHistoryCount() As Integer
    Function GetOneSystemHistory(LoginId As Integer) As SystemHistory
    Function AllSystemHistory() As IList(Of SystemHistory)
    Function GetSystemHistory(startIndex As Integer, PageSize As Integer, sortexpression As String) As IList(Of SystemHistory)
end interface