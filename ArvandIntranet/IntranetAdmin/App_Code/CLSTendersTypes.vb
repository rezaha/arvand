Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System
Imports System.Data

Public Class CLSTendersTypesItem
    Public Property TypeID As Integer
    Public Property TypeName As String
    Public Property Remark As String
End Class

Public Class CLSTendersTypes
    Public Function GetTendersTypes() As List(Of CLSTendersTypesItem)
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_TENDERS_TYPE", cn) With {.CommandType = CommandType.StoredProcedure}

        Dim retlist As New List(Of CLSTendersTypesItem)()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                Do While reader.Read()
                    Dim item As New CLSTendersTypesItem()
                    item.TypeID = Integer.Parse(reader.Item("TYPE_ID").ToString())
                    item.TypeName = reader.Item("TYPE_NAME").ToString()
                    item.Remark = reader.Item("REMARK").ToString()
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

    Public Function GetTendersTypes(ByVal TypesId As Integer) As CLSTendersTypesItem
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_TENDERS_TYPE", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@TypeId", TypesId)
        Dim retField As New CLSTendersTypesItem
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                reader.Read()
                retField.TypeID = Integer.Parse(reader.Item("TYPE_ID").ToString())
                retField.TypeName = reader.Item("TYPE_NAME").ToString()
                retField.Remark = reader.Item("REMARK").ToString()
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

    Public Function InsertTendersTypes(ByVal item As CLSTendersTypesItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("INSERT_TENDERS_TYPE", cn) With {.CommandType = CommandType.StoredProcedure}

        cmd.Parameters.AddWithValue("@TypeName", item.TypeName)
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
    Public Function DeleteTendersTypes(ByVal item As Integer) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("DELETE_TRENDS_TYPES", cn) With {.CommandType = CommandType.StoredProcedure}
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
    Public Function UpdateTendersTypes(ByVal item As CLSTendersTypesItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("UPDATE_TENDERS_TYPE", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@TypeId", item.TypeID)
        cmd.Parameters.AddWithValue("@TypeName", item.TypeName)
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
