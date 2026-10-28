Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System
Imports System.Data

Public Class CLSMasterPagesItem
    Public Property Masterpage_id As Integer
    Public Property Masterpage_no As Integer
    Public Property Masterpage_file_name As String
    Public Property Masterpage_link As String
    Public Property Masterpage_title_persian As String
    Public Property Masterpage_title_latin As String
    Public Property Content_div_name As String
    Public Property Masterpage_parent As Nullable(Of Integer)
    Public Property Masterpage_group As Integer
    Public Property Remark As String
End Class
Public Class CLSMasterPages

    Public Function GetMASTERPAGES() As List(Of CLSMasterPagesItem)
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_MASTERPAGES", cn) With {.CommandType = CommandType.StoredProcedure}
        'cmd.Parameters.AddWithValue("", "")
        Dim retlist As New List(Of CLSMasterPagesItem)()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                Do While reader.Read()
                    Dim item As New CLSMasterPagesItem()
                    item.Masterpage_id = Integer.Parse(reader("Masterpage_id").ToString())
                    item.Masterpage_no = Integer.Parse(reader("Masterpage_no").ToString())
                    item.Masterpage_file_name = reader("Masterpage_file_name").ToString()
                    item.Masterpage_link = reader("Masterpage_link").ToString()
                    item.Masterpage_title_persian = reader("Masterpage_title_persian").ToString()
                    item.Masterpage_title_latin = reader("Masterpage_title_latin").ToString()
                    item.Content_div_name = reader("Content_div_name").ToString()
                    If reader("Masterpage_parent") IsNot DBNull.Value Then
                        item.Masterpage_parent = Integer.Parse(reader("Masterpage_parent").ToString())
                    Else
                        item.Masterpage_parent = CType(Nothing, Integer?)
                    End If
                    item.Masterpage_group = Integer.Parse(reader("Masterpage_group").ToString())
                    item.Remark = reader("Remark").ToString()
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

    Public Function GetMASTERPAGE(Optional ByVal id As Integer = -1, Optional ByVal MasterName As String = "") As CLSMasterPagesItem
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_MASTERPAGES", cn) With {.CommandType = CommandType.StoredProcedure}

        If id = -1 Then
            cmd.Parameters.AddWithValue("@MasterPageId", DBNull.Value)
        Else
            cmd.Parameters.AddWithValue("@MasterPageId", id)
        End If
        If MasterName = "" Then
            cmd.Parameters.AddWithValue("@MasterPageFileName", DBNull.Value)
        Else
            cmd.Parameters.AddWithValue("@MasterPageFileName", MasterName)
        End If
        Dim item As New CLSMasterPagesItem()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.Read Then
                Dim row As Integer = 1
                'Do While reader.Read()
                item.Masterpage_id = Integer.Parse(reader("Masterpage_id").ToString())
                item.Masterpage_no = Integer.Parse(reader("Masterpage_no").ToString())
                item.Masterpage_file_name = reader("Masterpage_file_name").ToString()
                item.Masterpage_link = reader("Masterpage_link").ToString()
                item.Masterpage_title_persian = reader("Masterpage_title_persian").ToString()
                item.Masterpage_title_latin = reader("Masterpage_title_latin").ToString()
                item.Content_div_name = reader("Content_div_name").ToString()
                If reader("Masterpage_parent") IsNot DBNull.Value Then
                    item.Masterpage_parent = Integer.Parse(reader("Masterpage_parent").ToString())
                Else
                    item.Masterpage_parent = Nothing
                End If
                item.Masterpage_group = Integer.Parse(reader("Masterpage_group").ToString())
                item.Remark = reader("Remark").ToString()
                'Loop
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
    Public Function InsertMASTERPAGES(ByVal item As CLSMasterPagesItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("INSERT_MASTERPAGES", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@Masterpage_no", item.Masterpage_no)
        cmd.Parameters.AddWithValue("@Masterpage_file_name", item.Masterpage_file_name)
        cmd.Parameters.AddWithValue("@Masterpage_link", item.Masterpage_link)
        cmd.Parameters.AddWithValue("@Masterpage_title_persian", item.Masterpage_title_persian)
        cmd.Parameters.AddWithValue("@Masterpage_title_latin", item.Masterpage_title_latin)
        cmd.Parameters.AddWithValue("@Content_div_name", item.Content_div_name)
        cmd.Parameters.AddWithValue("@Masterpage_parent", item.Masterpage_parent)
        cmd.Parameters.AddWithValue("@Masterpage_group", item.Masterpage_group)
        cmd.Parameters.AddWithValue("@Remark", item.Remark)
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

    Public Function DeleteMASTERPAGES(ByVal item As Integer) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("DELETE_MasterPages", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@MasterPageId", item)
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
    Public Function UpdateMASTERPAGES(ByVal item As CLSMasterPagesItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("UPDATE_MASTERPAGES", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@Masterpage_id", item.Masterpage_id)
        cmd.Parameters.AddWithValue("@Masterpage_no", item.Masterpage_no)
        cmd.Parameters.AddWithValue("@Masterpage_file_name", item.Masterpage_file_name)
        cmd.Parameters.AddWithValue("@Masterpage_link", item.Masterpage_link)
        cmd.Parameters.AddWithValue("@Masterpage_title_persian", item.Masterpage_title_persian)
        cmd.Parameters.AddWithValue("@Masterpage_title_latin", item.Masterpage_title_latin)
        cmd.Parameters.AddWithValue("@Content_div_name", item.Content_div_name)
        cmd.Parameters.AddWithValue("@Masterpage_parent", item.Masterpage_parent)
        cmd.Parameters.AddWithValue("@Masterpage_group", item.Masterpage_group)
        cmd.Parameters.AddWithValue("@Remark", item.Remark)
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