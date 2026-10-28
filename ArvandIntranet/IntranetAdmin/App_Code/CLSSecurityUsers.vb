Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System
Imports System.Data

Public Class CLSSecurityUsersItem
    Public Property Division As New CLSPlantDivisionsItem
    Public Property User_id As Integer
    Public Property firstName As String
    Public Property LastName As String
    Public Property User_type As Boolean
    Public Property User_name As String
    Public Property User_password As String
    Public Property User_lock As Boolean
    Public Property Create_date As String
End Class

Public Class CLSSecurityUsers

    Public Function GetRecords() As List(Of CLSSecurityUsersItem)
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_USERS", cn) With {.CommandType = CommandType.StoredProcedure}

        Dim retlist As New List(Of CLSSecurityUsersItem)()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                Do While reader.Read()
                    Dim item As New CLSSecurityUsersItem()
                    item.Division.Division_id = Integer.Parse(reader("DIVISION_ID").ToString())
                    item.Division.Name_persian = reader("NAME_PERSIAN").ToString()
                    item.User_id = Integer.Parse(reader("User_id").ToString())
                    item.firstName = reader("FIRST_NAME").ToString()
                    item.LastName = reader("LAST_NAME").ToString()
                    item.User_type = Boolean.Parse(reader("User_type").ToString())
                    item.User_name = reader("User_name").ToString()
                    item.User_password = reader("User_password").ToString()
                    item.User_lock = Boolean.Parse(reader("User_lock").ToString())
                    item.Create_date = reader("Create_date").ToString()
                    retlist.Add(item)
                Loop
            End If
        Catch e1 As SqlException
        Catch e2 As Exception
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

    Public Function GetRecord(Optional ByVal UserId As Integer? = Nothing, Optional ByVal UserName As String = Nothing) As CLSSecurityUsersItem
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_USERS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@UserId", UserId)
        cmd.Parameters.AddWithValue("@UserName", UserName)
        Dim retField As New CLSSecurityUsersItem
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                reader.Read()
                retField.Division.Division_id = Integer.Parse(reader("DIVISION_ID").ToString())
                retField.Division.Name_persian = reader("NAME_PERSIAN").ToString()
                retField.User_id = Integer.Parse(reader("User_id").ToString())
                retField.firstName = reader("FIRST_NAME").ToString()
                retField.LastName = reader("LAST_NAME").ToString()
                retField.User_type = Boolean.Parse(reader("User_type").ToString())
                retField.User_name = reader("User_name").ToString()
                retField.User_password = reader("User_password").ToString()
                retField.User_lock = Boolean.Parse(reader("User_lock").ToString())
                retField.Create_date = reader("Create_date").ToString()
            End If
        Catch e1 As SqlException
        Catch e2 As Exception
        Finally
            If reader IsNot Nothing Then
                reader.Close()
            End If
            If cn.State <> ConnectionState.Closed Then
                cn.Close()
                cmd.Dispose()
            End If
        End Try
        Return retField
    End Function

    Public Function Insert(ByVal item As CLSSecurityUsersItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("INSERT_SECURITY_USERS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@DIVISION_ID", item.Division.Division_id)
        cmd.Parameters.AddWithValue("@FIRST_NAME", item.firstName)
        cmd.Parameters.AddWithValue("@LAST_NAME", item.LastName)
        cmd.Parameters.AddWithValue("@User_type", item.User_type)
        cmd.Parameters.AddWithValue("@User_name", item.User_name)
        cmd.Parameters.AddWithValue("@User_password", item.User_password)
        cmd.Parameters.AddWithValue("@User_lock", item.User_lock)
        cmd.Parameters.AddWithValue("@Create_date", item.Create_date)
        Dim rowEfect As Integer = 0
        Try
            cn.Open()
            rowEfect = cmd.ExecuteNonQuery()
        Catch e1 As SqlException
        Catch e2 As Exception
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
        Dim cmd As New SqlCommand("DELETE_SECURITY_USERS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@UserId", item)
        Dim rowEfect As Integer = 0
        Try
            cn.Open()
            rowEfect = cmd.ExecuteNonQuery()
        Catch e1 As SqlException
        Catch e2 As Exception
        Finally
            If cn.State <> ConnectionState.Closed Then
                cn.Close()
                cmd.Dispose()
            End If
        End Try
        Return rowEfect > 0
    End Function

    Public Function Update(ByVal item As CLSSecurityUsersItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("UPDATE_SECURITY_USERS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@User_id", item.User_id)
        cmd.Parameters.AddWithValue("@FIRST_NAME", item.firstName)
        cmd.Parameters.AddWithValue("@LAST_NAME", item.LastName)
        cmd.Parameters.AddWithValue("@User_type", item.User_type)
        cmd.Parameters.AddWithValue("@User_name", item.User_name)
        cmd.Parameters.AddWithValue("@User_password", item.User_password)
        cmd.Parameters.AddWithValue("@User_lock", item.User_lock)
        cmd.Parameters.AddWithValue("@Create_date", item.Create_date)
        Dim rowEfect As Integer = 0
        Try
            cn.Open()
            rowEfect = cmd.ExecuteNonQuery()
        Catch e1 As SqlException
        Catch e2 As Exception
        Finally
            If cn.State <> ConnectionState.Closed Then
                cn.Close()
                cmd.Dispose()
            End If
        End Try
        Return rowEfect > 0
    End Function

End Class