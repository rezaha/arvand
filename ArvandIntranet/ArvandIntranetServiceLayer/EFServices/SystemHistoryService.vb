Imports Danesh.ArvandIntranet.DataLayer.Context
Imports System.Data.Entity
Imports Danesh.ArvandIntranet.DomainClasses.Models

Public Class SystemHistoryService
    Implements ISystemHistoryService

    Private _uow As IUnitOfWork
    Private _systemHistory As IDbSet(Of SystemHistory)

    Public Sub New(uow As IUnitOfWork)
        _uow = uow
        _systemHistory = _uow.[Set](Of SystemHistory)()
    End Sub

    Public Function AddSystemHistory(systemHistory As SystemHistory, err As Dictionary(Of String, String)) As Integer Implements ISystemHistoryService.AddSystemHistory
        Dim rowEffect As Integer = 0
        _systemHistory.Add(systemHistory)
        rowEffect = _uow.SaveChanges()
        Return rowEffect
    End Function

    Public Sub EditSystemHistory(systemHistory As SystemHistory, err As Dictionary(Of String, String)) Implements ISystemHistoryService.EditSystemHistory
        _uow.SaveChanges()
        Return
    End Sub

    Public Function RemoveSystemHistory(systemHistory As SystemHistory, err As Dictionary(Of String, String)) As Integer Implements ISystemHistoryService.RemoveSystemHistory
        Dim rowEffect As Integer = 0
        _systemHistory.Remove(systemHistory)
        rowEffect = _uow.SaveChanges()
        Return rowEffect
    End Function

    Public Function SystemHistoryCount() As Integer Implements ISystemHistoryService.SystemHistoryCount
        Return _systemHistory.Count()
    End Function

    Public Function GetOneSystemHistory(LoginId As Integer) As SystemHistory Implements ISystemHistoryService.GetOneSystemHistory
        Return _systemHistory.FirstOrDefault(Function(a) a.HistoryId = LoginId)
    End Function

    Public Function AllSystemHistory() As IList(Of SystemHistory) Implements ISystemHistoryService.AllSystemHistory
        Return _systemHistory.ToList()
    End Function

    Public Function GetSystemHistory(startIndex As Integer, PageSize As Integer, sortexpression As String) As IList(Of SystemHistory) Implements ISystemHistoryService.GetSystemHistory
        If sortexpression = String.Empty Then
            sortexpression = "LoginId Des"
        End If

        Dim SortColumnName As String = sortexpression.Split(" "c)(0)
        Dim SortDirection As String = sortexpression.Split(" "c)(1)
        Dim systemHistoryQuery = _systemHistory.AsQueryable()
        Select Case SortColumnName
            Case "LoginId"
                systemHistoryQuery = (If((SortDirection.ToLower() = "asc"), systemHistoryQuery.OrderBy(Function(a) a.HistoryId), systemHistoryQuery.OrderByDescending(Function(a) a.HistoryId)))
                Exit Select
            Case "FormName"
                systemHistoryQuery = (If((SortDirection.ToLower() = "asc"), systemHistoryQuery.OrderBy(Function(a) a.FormName), systemHistoryQuery.OrderByDescending(Function(a) a.FormName)))
                Exit Select
            Case "ActionName"
                systemHistoryQuery = (If((SortDirection.ToLower() = "asc"), systemHistoryQuery.OrderBy(Function(a) a.ActionName), systemHistoryQuery.OrderByDescending(Function(a) a.ActionName)))
                Exit Select
            Case "LoginUserId"
                systemHistoryQuery = (If((SortDirection.ToLower() = "asc"), systemHistoryQuery.OrderBy(Function(a) a.LoginUserId), systemHistoryQuery.OrderByDescending(Function(a) a.LoginUserId)))
                Exit Select
            Case "LoginUserName"
                systemHistoryQuery = (If((SortDirection.ToLower() = "asc"), systemHistoryQuery.OrderBy(Function(a) a.LoginUserName), systemHistoryQuery.OrderByDescending(Function(a) a.LoginUserName)))
                Exit Select
            Case "ActionDate"
                systemHistoryQuery = (If((SortDirection.ToLower() = "asc"), systemHistoryQuery.OrderBy(Function(a) a.ActionDate), systemHistoryQuery.OrderByDescending(Function(a) a.ActionDate)))
                Exit Select
            Case "ActionTime"
                systemHistoryQuery = (If((SortDirection.ToLower() = "asc"), systemHistoryQuery.OrderBy(Function(a) a.ActionTime), systemHistoryQuery.OrderByDescending(Function(a) a.ActionTime)))
                Exit Select
            Case "OsUser"
                systemHistoryQuery = (If((SortDirection.ToLower() = "asc"), systemHistoryQuery.OrderBy(Function(a) a.OsUser), systemHistoryQuery.OrderByDescending(Function(a) a.OsUser)))
                Exit Select
            Case "OsName"
                systemHistoryQuery = (If((SortDirection.ToLower() = "asc"), systemHistoryQuery.OrderBy(Function(a) a.OsName), systemHistoryQuery.OrderByDescending(Function(a) a.OsName)))
                Exit Select
            Case "IpAddress"
                systemHistoryQuery = (If((SortDirection.ToLower() = "asc"), systemHistoryQuery.OrderBy(Function(a) a.IpAddress), systemHistoryQuery.OrderByDescending(Function(a) a.IpAddress)))
                Exit Select
            Case "BrowserType"
                systemHistoryQuery = (If((SortDirection.ToLower() = "asc"), systemHistoryQuery.OrderBy(Function(a) a.BrowserType), systemHistoryQuery.OrderByDescending(Function(a) a.BrowserType)))
                Exit Select
            Case "PreLog"
                systemHistoryQuery = (If((SortDirection.ToLower() = "asc"), systemHistoryQuery.OrderBy(Function(a) a.ParentHistoryId), systemHistoryQuery.OrderByDescending(Function(a) a.ParentHistoryId)))
                Exit Select
            Case "Remark"
                systemHistoryQuery = (If((SortDirection.ToLower() = "asc"), systemHistoryQuery.OrderBy(Function(a) a.Remark), systemHistoryQuery.OrderByDescending(Function(a) a.Remark)))
                Exit Select
            Case "XmlDate"
                systemHistoryQuery = (If((SortDirection.ToLower() = "asc"), systemHistoryQuery.OrderBy(Function(a) a.XmlDate), systemHistoryQuery.OrderByDescending(Function(a) a.XmlDate)))
                Exit Select
        End Select
        Return systemHistoryQuery.Skip(startIndex).Take(PageSize).ToList()
    End Function
End Class

