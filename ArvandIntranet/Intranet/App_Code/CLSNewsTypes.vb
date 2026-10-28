Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System
Imports System.Data

Public Class CLSNewsTypesItem
    Public Property Type_id As Integer
    Public Property Type_no As Integer
    Public Property Name_persian As String
    Public Property Name_latin As String
    Public Property Remark As String
End Class

Public Class CLSNewsTypes
    Public Function GetNEWS_TYPES() As List(Of CLSNewsTypesItem)
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_NEWS_TYPES", cn) With {.CommandType = CommandType.StoredProcedure}
        'cmd.Parameters.AddWithValue("", "")
        Dim retlist As New List(Of CLSNewsTypesItem)()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                Do While reader.Read()
                    Dim item As New CLSNewsTypesItem()
                    item.Type_id = Integer.Parse(reader("Type_id").ToString())
                    item.Type_no = Integer.Parse(reader("Type_no").ToString())
                    item.Name_persian = reader("Name_persian").ToString()
                    item.Name_latin = reader("Name_latin").ToString()
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

    Public Function GetNEWS_TYPES(ByVal typeId As Integer) As CLSNewsTypesItem
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_NEWS_TYPES", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@TypeId", typeId)
        Dim retField As New CLSNewsTypesItem
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                reader.Read()
                retField.Type_id = Integer.Parse(reader("Type_id").ToString())
                retField.Type_no = Integer.Parse(reader("Type_no").ToString())
                retField.Name_persian = reader("Name_persian").ToString()
                retField.Name_latin = reader("Name_latin").ToString()
                retField.Remark = reader("Remark").ToString()
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
        Return retField
    End Function

    Public Function InsertNEWS_TYPES(ByVal item As CLSNewsTypesItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("INSERT_NEWS_TYPES", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@Type_no", item.Type_no)
        cmd.Parameters.AddWithValue("@Name_persian", item.Name_persian)
        cmd.Parameters.AddWithValue("@Name_latin", item.Name_latin)
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
    Public Function DeleteNEWS_TYPES(ByVal item As Integer) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("DELETE_NEWS_TYPES", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@TypeId", item)
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
    Public Function UpdateNEWS_TYPES(ByVal item As CLSNewsTypesItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("UPDATE_NEWS_TYPES", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@Type_id", item.Type_id)
        cmd.Parameters.AddWithValue("@Type_no", item.Type_no)
        cmd.Parameters.AddWithValue("@Name_persian", item.Name_persian)
        cmd.Parameters.AddWithValue("@Name_latin", item.Name_latin)
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