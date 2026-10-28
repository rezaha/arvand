Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System
Imports System.Data

Public Class CLSMasterPageWebpartsItem
    Public Property Masterpage_webpart As Integer
    Public Property Masterpage As New CLSMasterPagesItem
    Public Property Webpart As New CLSWebpartsItem
    Public Property Row_no As Integer
    Public Property Col_no As Integer
    Public Property Col_order As Integer
    Public Property Collapse_option As Boolean
    Public Property Move_option As Boolean
    Public Property Delete_option As Boolean
    Public Property Remark As String
End Class
Public Class CLSMasterPageWebparts
    Public Function GetMASTERPAGE_WEBPARTS() As List(Of CLSMasterPageWebpartsItem)
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_MASTERPAGE_WEBPART", cn) With {.CommandType = CommandType.StoredProcedure}
        'cmd.Parameters.AddWithValue("", "")
        Dim retlist As New List(Of CLSMasterPageWebpartsItem)()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                Do While reader.Read()
                    Dim item As New CLSMasterPageWebpartsItem()
                    item.Masterpage_webpart = Integer.Parse(reader("Masterpage_webpart").ToString())
                    item.Masterpage.Masterpage_id = Integer.Parse(reader("Masterpage_id").ToString())
                    item.Masterpage.Masterpage_title_persian = reader("MASTERPAGE_TITLE_PERSIAN").ToString()
                    item.Webpart.Webpart_id = Integer.Parse(reader("Webpart_id").ToString())
                    item.Webpart.Webpart_name = reader("WEBPART_NAME")
                    item.Row_no = Integer.Parse(reader("Row_no").ToString())
                    item.Col_no = Integer.Parse(reader("Col_no").ToString())
                    item.Col_order = Integer.Parse(reader("Col_order").ToString())
                    item.Collapse_option = Boolean.Parse(reader("Collapse_option").ToString())
                    item.Move_option = Boolean.Parse(reader("Move_option").ToString())
                    item.Delete_option = Boolean.Parse(reader("Delete_option").ToString())
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

    Public Function GetMASTERPAGE_WEBPARTS(ByVal id As Integer) As CLSMasterPageWebpartsItem
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_MASTERPAGE_WEBPART", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@MasterPageWebPart", id)
        Dim item As New CLSMasterPageWebpartsItem()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                Do While reader.Read()
                    item.Masterpage_webpart = Integer.Parse(reader("Masterpage_webpart").ToString())
                    item.Masterpage.Masterpage_id = Integer.Parse(reader("Masterpage_id").ToString())
                    item.Masterpage.Masterpage_title_persian = reader("MASTERPAGE_TITLE_PERSIAN").ToString()
                    item.Webpart.Webpart_id = Integer.Parse(reader("Webpart_id").ToString())
                    item.Webpart.Webpart_name = reader("WEBPART_NAME")
                    item.Row_no = Integer.Parse(reader("Row_no").ToString())
                    item.Col_no = Integer.Parse(reader("Col_no").ToString())
                    item.Col_order = Integer.Parse(reader("Col_order").ToString())
                    item.Collapse_option = Boolean.Parse(reader("Collapse_option").ToString())
                    item.Move_option = Boolean.Parse(reader("Move_option").ToString())
                    item.Delete_option = Boolean.Parse(reader("Delete_option").ToString())
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
    Public Function InsertMASTERPAGE_WEBPARTS(ByVal item As CLSMasterPageWebpartsItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("INSERT_MASTERPAGE_WEBPARTS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@Masterpage_id", item.Masterpage.Masterpage_id)
        cmd.Parameters.AddWithValue("@Webpart_id", item.Webpart.Webpart_id)
        cmd.Parameters.AddWithValue("@Row_no", item.Row_no)
        cmd.Parameters.AddWithValue("@Col_no", item.Col_no)
        cmd.Parameters.AddWithValue("@Col_order", item.Col_order)
        cmd.Parameters.AddWithValue("@Collapse_option", item.Collapse_option)
        cmd.Parameters.AddWithValue("@Move_option", item.Move_option)
        cmd.Parameters.AddWithValue("@Delete_option", item.Delete_option)
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
    Public Function DeleteMASTERPAGE_WEBPARTS(ByVal item As Integer) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("DELETE_MASTERPAGE_WEBPART", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@MasterPageWebPart", item)
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
    Public Function UpdateMASTERPAGE_WEBPARTS(ByVal item As CLSMasterPageWebpartsItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("UPDATE_MASTERPAGE_WEBPARTS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@Masterpage_webpart", item.Masterpage_webpart)
        cmd.Parameters.AddWithValue("@Masterpage_id", item.Masterpage.Masterpage_id)
        cmd.Parameters.AddWithValue("@Webpart_id", item.Webpart.Webpart_id)
        cmd.Parameters.AddWithValue("@Row_no", item.Row_no)
        cmd.Parameters.AddWithValue("@Col_no", item.Col_no)
        cmd.Parameters.AddWithValue("@Col_order", item.Col_order)
        cmd.Parameters.AddWithValue("@Collapse_option", item.Collapse_option)
        cmd.Parameters.AddWithValue("@Move_option", item.Move_option)
        cmd.Parameters.AddWithValue("@Delete_option", item.Delete_option)
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
