Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System
Imports System.Data

Public Class CLSVisiotorsItem
    Public Property Visit_id As Integer
    Public Property Part_type As String
    Public Property Part_id As Integer
    Public Property User_type As Boolean
    Public Property User_id As Nullable(Of Integer)
    Public Property Visit_date As String
    Public Property Visit_time As String
    Public Property Visit_os As String
    Public Property Visit_ip As String
    Public Property Visit_browser As String
    Public Property Visit_computername As String
    Public Property Remark As String
End Class



Public Class CLSVisiotors

    Public Function GetVisitorCount(Optional ByVal SDate As String = "", Optional ByVal EDate As String = "", Optional ByVal PageName As String = "") As String
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GETVISITOR_COUNT", cn) With {.CommandType = CommandType.StoredProcedure}
        Dim reader As SqlDataReader = Nothing
        If SDate <> "" Then
            cmd.Parameters.AddWithValue("@SDate", SDate)
        End If
        If EDate <> "" Then
            cmd.Parameters.AddWithValue("@EDate", EDate)
        End If
        If PageName <> "" Then
            cmd.Parameters.AddWithValue("@FormName", PageName)
        End If
        cn.Open()
        reader = cmd.ExecuteReader()
        Dim count As Integer = 0
        If reader.Read() Then
            count = reader(0).ToString()
        End If
        cn.Close()
        Return count
    End Function

    Public Function GetVISITORS(ByVal StartDate As String, ByVal EndDate As String, ByVal FormName As String) As List(Of CLSVisiotorsItem)
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_VISITORS", cn) With {.CommandType = CommandType.StoredProcedure}
        If StartDate <> "" Then
            cmd.Parameters.AddWithValue("@SVisitDate", StartDate)
        End If

        If FormName <> "" Then
            cmd.Parameters.AddWithValue("@FormName", FormName)
        End If

        If EndDate <> "" Then
            cmd.Parameters.AddWithValue("@EVisitDate", EndDate)
        End If

        Dim retlist As New List(Of CLSVisiotorsItem)()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                Do While reader.Read()
                    Dim item As New CLSVisiotorsItem()
                    item.Visit_id = Integer.Parse(reader("Visit_id").ToString())
                    item.Part_type = reader("Part_type").ToString()
                    item.Part_id = Integer.Parse(reader("Part_id").ToString())
                    item.User_type = Boolean.Parse(reader("User_type").ToString())
                    If reader("User_id") IsNot DBNull.Value Then
                        item.User_id = Integer.Parse(reader("User_id").ToString())
                    Else
                        item.User_id = CType(Nothing, Integer?)
                    End If
                    item.Visit_date = reader("Visit_date").ToString()
                    item.Visit_time = reader("Visit_time").ToString()
                    item.Visit_os = reader("Visit_os").ToString()
                    item.Visit_ip = reader("Visit_ip").ToString()
                    item.Visit_browser = reader("Visit_browser").ToString()
                    item.Visit_computername = reader("Visit_computername").ToString()
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

    Public Function GetVISITORS(ByVal id As Integer) As CLSVisiotorsItem
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_VISITORS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@VisitId", id)
        Dim item As New CLSVisiotorsItem()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                Do While reader.Read()
                    item.Visit_id = Integer.Parse(reader("Visit_id").ToString())
                    item.Part_type = reader("Part_type").ToString()
                    item.Part_id = Integer.Parse(reader("Part_id").ToString())
                    item.User_type = Boolean.Parse(reader("User_type").ToString())
                    If reader("User_id") IsNot DBNull.Value Then
                        item.User_id = Integer.Parse(reader("User_id").ToString())
                    Else
                        item.User_id = CType(Nothing, Integer?)
                    End If
                    item.Visit_date = reader("Visit_date").ToString()
                    item.Visit_time = reader("Visit_time").ToString()
                    item.Visit_os = reader("Visit_os").ToString()
                    item.Visit_ip = reader("Visit_ip").ToString()
                    item.Visit_browser = reader("Visit_browser").ToString()
                    item.Visit_computername = reader("Visit_computername").ToString()
                    item.Remark = reader("Remark").ToString()
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

    Public Function InsertVISITORS(ByVal item As CLSVisiotorsItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("INSERT_VISITORS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@Part_type", "fa")
        cmd.Parameters.AddWithValue("@Part_id", item.Part_id)
        cmd.Parameters.AddWithValue("@User_type", item.User_type)
        cmd.Parameters.AddWithValue("@User_id", item.User_id)
        cmd.Parameters.AddWithValue("@Visit_date", item.Visit_date)
        cmd.Parameters.AddWithValue("@Visit_time", item.Visit_time)
        cmd.Parameters.AddWithValue("@Visit_os", item.Visit_os)
        cmd.Parameters.AddWithValue("@Visit_ip", item.Visit_ip)
        cmd.Parameters.AddWithValue("@Visit_browser", item.Visit_browser)
        cmd.Parameters.AddWithValue("@Visit_computername", item.Visit_computername)
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

    Public Function DeleteVISITORS(ByVal item As Integer) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("DELETE_VISITORS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@VisitId", item)
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

    Public Function UpdateVISITORS(ByVal item As CLSVisiotorsItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("UPDATE_VISITORS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@Visit_id", item.Visit_id)
        cmd.Parameters.AddWithValue("@Part_type", item.Part_type)
        cmd.Parameters.AddWithValue("@Part_id", item.Part_id)
        cmd.Parameters.AddWithValue("@User_type", item.User_type)
        cmd.Parameters.AddWithValue("@User_id", item.User_id)
        cmd.Parameters.AddWithValue("@Visit_date", item.Visit_date)
        cmd.Parameters.AddWithValue("@Visit_time", item.Visit_time)
        cmd.Parameters.AddWithValue("@Visit_os", item.Visit_os)
        cmd.Parameters.AddWithValue("@Visit_ip", item.Visit_ip)
        cmd.Parameters.AddWithValue("@Visit_browser", item.Visit_browser)
        cmd.Parameters.AddWithValue("@Visit_computername", item.Visit_computername)
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
