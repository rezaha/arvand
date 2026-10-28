Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System
Imports System.Data

Public Class CLSStatisticsItem
    Public Property Statistic_id As Integer
    Public Property Part_type As String
    Public Property Part_id As Integer
    Public Property Counter_today As Integer
    Public Property Counter_yesterday As Integer
    Public Property Counter_cweek As Integer
    Public Property Counter_lweek As Integer
    Public Property Counter_cmonth As Integer
    Public Property Counter_lmonth As Integer
    Public Property Counter_total As Integer
    Public Property Counter_cuser As Integer
    Public Property Counter_cguest As Integer
    Public Property Counter_user As Integer
    Public Property Counter_guest As Integer
End Class

Public Class CLSStatistics
    Public Function GetSTATISTICS() As List(Of CLSStatisticsItem)
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_STATISTICS", cn) With {.CommandType = CommandType.StoredProcedure}
        Dim retlist As New List(Of CLSStatisticsItem)()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                Do While reader.Read()
                    Dim item As New CLSStatisticsItem()
                    item.Statistic_id = Integer.Parse(reader("Statistic_id").ToString())
                    item.Part_type = reader("Part_type").ToString()
                    item.Part_id = Integer.Parse(reader("Part_id").ToString())
                    item.Counter_today = Integer.Parse(reader("Counter_today").ToString())
                    item.Counter_yesterday = Integer.Parse(reader("Counter_yesterday").ToString())
                    item.Counter_cweek = Integer.Parse(reader("Counter_cweek").ToString())
                    item.Counter_lweek = Integer.Parse(reader("Counter_lweek").ToString())
                    item.Counter_cmonth = Integer.Parse(reader("Counter_cmonth").ToString())
                    item.Counter_lmonth = Integer.Parse(reader("Counter_lmonth").ToString())
                    item.Counter_total = Integer.Parse(reader("Counter_total").ToString())
                    item.Counter_cuser = Integer.Parse(reader("Counter_cuser").ToString())
                    item.Counter_cguest = Integer.Parse(reader("Counter_cguest").ToString())
                    item.Counter_user = Integer.Parse(reader("Counter_user").ToString())
                    item.Counter_guest = Integer.Parse(reader("Counter_guest").ToString())
                    retlist.Add(item)
                Loop
            End If
        Catch e1 As SqlException
            Throw
        Catch e2 As Exception
            Throw
        Finally
            If reader IsNot Nothing Then
                reader.Close()
            End If
            If cn.State <> ConnectionState.Closed Then
                cn.Close()
                cmd.Dispose()
            End If
        End Try
        Return retlist
    End Function
    Public Function GetSTATISTICS(ByVal id As Integer) As CLSStatisticsItem
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_STATISTICS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@@StatisticId", id)
        Dim item As New CLSStatisticsItem()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                Do While reader.Read()
                    item.Statistic_id = Integer.Parse(reader("Statistic_id").ToString())
                    item.Part_type = reader("Part_type").ToString()
                    item.Part_id = Integer.Parse(reader("Part_id").ToString())
                    item.Counter_today = Integer.Parse(reader("Counter_today").ToString())
                    item.Counter_yesterday = Integer.Parse(reader("Counter_yesterday").ToString())
                    item.Counter_cweek = Integer.Parse(reader("Counter_cweek").ToString())
                    item.Counter_lweek = Integer.Parse(reader("Counter_lweek").ToString())
                    item.Counter_cmonth = Integer.Parse(reader("Counter_cmonth").ToString())
                    item.Counter_lmonth = Integer.Parse(reader("Counter_lmonth").ToString())
                    item.Counter_total = Integer.Parse(reader("Counter_total").ToString())
                    item.Counter_cuser = Integer.Parse(reader("Counter_cuser").ToString())
                    item.Counter_cguest = Integer.Parse(reader("Counter_cguest").ToString())
                    item.Counter_user = Integer.Parse(reader("Counter_user").ToString())
                    item.Counter_guest = Integer.Parse(reader("Counter_guest").ToString())
                Loop
            End If
        Catch e1 As SqlException
            Throw
        Catch e2 As Exception
            Throw
        Finally
            If reader IsNot Nothing Then
                reader.Close()
            End If
            If cn.State <> ConnectionState.Closed Then
                cn.Close()
                cmd.Dispose()
            End If
        End Try
        Return item
    End Function
    Public Function InsertSTATISTICS(ByVal item As CLSStatisticsItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("INSERT_STATISTICS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@Part_type", item.Part_type)
        cmd.Parameters.AddWithValue("@Part_id", item.Part_id)
        cmd.Parameters.AddWithValue("@Counter_today", item.Counter_today)
        cmd.Parameters.AddWithValue("@Counter_yesterday", item.Counter_yesterday)
        cmd.Parameters.AddWithValue("@Counter_cweek", item.Counter_cweek)
        cmd.Parameters.AddWithValue("@Counter_lweek", item.Counter_lweek)
        cmd.Parameters.AddWithValue("@Counter_cmonth", item.Counter_cmonth)
        cmd.Parameters.AddWithValue("@Counter_lmonth", item.Counter_lmonth)
        cmd.Parameters.AddWithValue("@Counter_total", item.Counter_total)
        cmd.Parameters.AddWithValue("@Counter_cuser", item.Counter_cuser)
        cmd.Parameters.AddWithValue("@Counter_cguest", item.Counter_cguest)
        cmd.Parameters.AddWithValue("@Counter_user", item.Counter_user)
        cmd.Parameters.AddWithValue("@Counter_guest", item.Counter_guest)
        Dim rowEfect As Integer = 0
        Try
            cn.Open()
            rowEfect = cmd.ExecuteNonQuery()
        Catch e1 As SqlException
            Throw
        Catch e2 As Exception
            Throw
        Finally
            If cn.State <> ConnectionState.Closed Then
                cn.Close()
                cmd.Dispose()
            End If
        End Try
        Return rowEfect > 0
    End Function
    Public Function DeleteSTATISTICS(ByVal item As Integer) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("DELETE_STATISTICS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@StatistId", item)
        Dim rowEfect As Integer = 0
        Try
            cn.Open()
            rowEfect = cmd.ExecuteNonQuery()
        Catch e1 As SqlException
            Throw
        Catch e2 As Exception
            Throw
        Finally
            If cn.State <> ConnectionState.Closed Then
                cn.Close()
                cmd.Dispose()
            End If
        End Try
        Return rowEfect > 0
    End Function
    Public Function UpdateSTATISTICS(ByVal item As CLSStatisticsItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("UPDATE_STATISTICS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@Statistic_id", item.Statistic_id)
        cmd.Parameters.AddWithValue("@Part_type", item.Part_type)
        cmd.Parameters.AddWithValue("@Part_id", item.Part_id)
        cmd.Parameters.AddWithValue("@Counter_today", item.Counter_today)
        cmd.Parameters.AddWithValue("@Counter_yesterday", item.Counter_yesterday)
        cmd.Parameters.AddWithValue("@Counter_cweek", item.Counter_cweek)
        cmd.Parameters.AddWithValue("@Counter_lweek", item.Counter_lweek)
        cmd.Parameters.AddWithValue("@Counter_cmonth", item.Counter_cmonth)
        cmd.Parameters.AddWithValue("@Counter_lmonth", item.Counter_lmonth)
        cmd.Parameters.AddWithValue("@Counter_total", item.Counter_total)
        cmd.Parameters.AddWithValue("@Counter_cuser", item.Counter_cuser)
        cmd.Parameters.AddWithValue("@Counter_cguest", item.Counter_cguest)
        cmd.Parameters.AddWithValue("@Counter_user", item.Counter_user)
        cmd.Parameters.AddWithValue("@Counter_guest", item.Counter_guest)
        Dim rowEfect As Integer = 0
        Try
            cn.Open()
            rowEfect = cmd.ExecuteNonQuery()
        Catch e1 As SqlException
            Throw
        Catch e2 As Exception
            Throw
        Finally
            If cn.State <> ConnectionState.Closed Then
                cn.Close()
                cmd.Dispose()
            End If
        End Try
        Return rowEfect > 0
    End Function
End Class
