Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System
Imports System.Data

Public Class CLSpollsItem
    Public Property Division As New CLSPlantDivisionsItem
    Public Property PollId As Integer
    Public Property PollNo As Integer
    Public Property PollName As String
    Public Property PollType As Integer
    Public Property Active As Boolean
    Public Property Remark As String
End Class

Public Class CLSpolls
    Public Function GetPolls() As List(Of CLSpollsItem)
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_POLLS", cn) With {.CommandType = CommandType.StoredProcedure}
        'cmd.Parameters.AddWithValue("", "")
        Dim retlist As New List(Of CLSpollsItem)()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                Do While reader.Read()
                    Dim item As New CLSpollsItem()
                    item.Active = Boolean.Parse(reader("ACTIVE").ToString())
                    item.Division.Division_id = reader("DIVISION_ID").ToString()
                    item.Division.Name_persian = reader("NAME_PERSIAN").ToString()
                    item.PollId = reader("POLL_ID").ToString()
                    item.PollName = reader("POLL_NAME").ToString()
                    item.PollNo = reader("POLL_NO").ToString()
                    item.PollType = reader("POLL_TYPE").ToString()
                    item.Remark = reader("REMARK").ToString()
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

    Public Function GetPolls(ByVal PollId As Integer) As CLSpollsItem
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_POLLS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@POLL_ID", PollId)
        Dim item As New CLSpollsItem()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                Do While reader.Read()
                    item.Active = Boolean.Parse(reader("ACTIVE").ToString())
                    item.Division.Division_id = reader("DIVISION_ID").ToString()
                    item.Division.Name_persian = reader("NAME_PERSIAN").ToString()
                    item.PollId = reader("POLL_ID").ToString()
                    item.PollName = reader("POLL_NAME").ToString()
                    item.PollNo = reader("POLL_NO").ToString()
                    item.PollType = reader("POLL_TYPE").ToString()
                    item.Remark = reader("REMARK").ToString()
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

    Public Function Insert(ByVal item As CLSpollsItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("INSERT_POLLS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@DIVISION_ID", item.Division.Division_id)
        cmd.Parameters.AddWithValue("@POLL_NO", item.PollNo)
        cmd.Parameters.AddWithValue("@POLL_NAME", item.PollName)
        cmd.Parameters.AddWithValue("@POLL_TYPE", item.PollType)
        cmd.Parameters.AddWithValue("@ACTIVE", item.Active)
        cmd.Parameters.AddWithValue("@REMARK", item.Remark)
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
    Public Function Delete(ByVal item As Integer) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("DELETE_POLLS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@POLL_ID", item)
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
    Public Function Update(ByVal item As CLSpollsItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("UPDATE_POLLS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@DIVISION_ID", item.Division.Division_id)
        cmd.Parameters.AddWithValue("@POLL_ID", item.PollId)
        cmd.Parameters.AddWithValue("@POLL_NO", item.PollNo)
        cmd.Parameters.AddWithValue("@POLL_NAME", item.PollName)
        cmd.Parameters.AddWithValue("@POLL_TYPE", item.PollType)
        cmd.Parameters.AddWithValue("@ACTIVE", item.Active)
        cmd.Parameters.AddWithValue("@REMARK", item.Remark)
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
