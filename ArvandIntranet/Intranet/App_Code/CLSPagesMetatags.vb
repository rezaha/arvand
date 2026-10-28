Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System
Imports System.Data

Public Class CLSPagesMetatagsItem
    Public Property Meta_no As Integer
    Public Property Part_type As String
    Public Property Part_id As Integer
    Public Property Meta_id As String
    Public Property Meta_name As String
    Public Property Meta_content As String
    Public Property Meta_httpequiv As String
    Public Property Meta_lang As String
    Public Property Meta_dir As String
    Public Property Meta_scheme As String
    Public Property Meta_xmllang As String
    Public Property Active As Boolean
End Class

Public Class CLSPagesMetatags

    Public Function GetPAGES_METATAGS(Optional ByVal PartType As String = "", Optional ByVal PartId As Integer = -1) As List(Of CLSPagesMetatagsItem)
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_PAGE_METATAGS", cn) With {.CommandType = CommandType.StoredProcedure}
        If PartType = "" Then
            cmd.Parameters.AddWithValue("@PARTTYPE", PartType)
        Else
            cmd.Parameters.AddWithValue("@PARTTYPE", PartType)
        End If
        If PartId = -1 Then
            cmd.Parameters.AddWithValue("@PARTID", PartId)
        Else
            cmd.Parameters.AddWithValue("@PARTID", PartId)
        End If
        Dim retlist As New List(Of CLSPagesMetatagsItem)()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                Do While reader.Read()
                    Dim item As New CLSPagesMetatagsItem()
                    item.Meta_no = Integer.Parse(reader("Meta_no").ToString())
                    item.Part_type = reader("Part_type").ToString()
                    item.Part_id = Integer.Parse(reader("Part_id").ToString())
                    item.Meta_id = reader("Meta_id").ToString()
                    item.Meta_name = reader("Meta_name").ToString()
                    item.Meta_content = reader("Meta_content").ToString()
                    item.Meta_httpequiv = reader("Meta_httpequiv").ToString()
                    item.Meta_lang = reader("Meta_lang").ToString()
                    item.Meta_dir = reader("Meta_dir").ToString()
                    item.Meta_scheme = reader("Meta_scheme").ToString()
                    item.Meta_xmllang = reader("Meta_xmllang").ToString()
                    item.Active = Boolean.Parse(reader("Active").ToString())
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

    Public Function GetPAGES_METATAG(ByVal id As Integer) As CLSPagesMetatagsItem
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_PAGE_METATAGS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@MetaNo", id)
        Dim item As New CLSPagesMetatagsItem()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                Do While reader.Read()
                    item.Meta_no = Integer.Parse(reader("Meta_no").ToString())
                    item.Part_type = reader("Part_type").ToString()
                    item.Part_id = Integer.Parse(reader("Part_id").ToString())
                    item.Meta_id = reader("Meta_id").ToString()
                    item.Meta_name = reader("Meta_name").ToString()
                    item.Meta_content = reader("Meta_content").ToString()
                    item.Meta_httpequiv = reader("Meta_httpequiv").ToString()
                    item.Meta_lang = reader("Meta_lang").ToString()
                    item.Meta_dir = reader("Meta_dir").ToString()
                    item.Meta_scheme = reader("Meta_scheme").ToString()
                    item.Meta_xmllang = reader("Meta_xmllang").ToString()
                    item.Active = Boolean.Parse(reader("Active").ToString())
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

    Public Function InsertPAGES_METATAGS(ByVal item As CLSPagesMetatagsItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("INSERT_PAGES_METATAGS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@Part_type", item.Part_type)
        cmd.Parameters.AddWithValue("@Part_id", item.Part_id)
        cmd.Parameters.AddWithValue("@Meta_id", item.Meta_id)
        cmd.Parameters.AddWithValue("@Meta_name", item.Meta_name)
        cmd.Parameters.AddWithValue("@Meta_content", item.Meta_content)
        cmd.Parameters.AddWithValue("@Meta_httpequiv", item.Meta_httpequiv)
        cmd.Parameters.AddWithValue("@Meta_lang", item.Meta_lang)
        cmd.Parameters.AddWithValue("@Meta_dir", item.Meta_dir)
        cmd.Parameters.AddWithValue("@Meta_scheme", item.Meta_scheme)
        cmd.Parameters.AddWithValue("@Meta_xmllang", item.Meta_xmllang)
        cmd.Parameters.AddWithValue("@Active", item.Active)
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

    Public Function DeletePAGES_METATAGS(ByVal item As Integer) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("DELETE_PAGE_METATAGS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@MetaNo", item)
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

    Public Function UpdatePAGES_METATAGS(ByVal item As CLSPagesMetatagsItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("UPDATE_PAGES_METATAGS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@Meta_no", item.Meta_no)
        cmd.Parameters.AddWithValue("@Part_type", item.Part_type)
        cmd.Parameters.AddWithValue("@Part_id", item.Part_id)
        cmd.Parameters.AddWithValue("@Meta_id", item.Meta_id)
        cmd.Parameters.AddWithValue("@Meta_name", item.Meta_name)
        cmd.Parameters.AddWithValue("@Meta_content", item.Meta_content)
        cmd.Parameters.AddWithValue("@Meta_httpequiv", item.Meta_httpequiv)
        cmd.Parameters.AddWithValue("@Meta_lang", item.Meta_lang)
        cmd.Parameters.AddWithValue("@Meta_dir", item.Meta_dir)
        cmd.Parameters.AddWithValue("@Meta_scheme", item.Meta_scheme)
        cmd.Parameters.AddWithValue("@Meta_xmllang", item.Meta_xmllang)
        cmd.Parameters.AddWithValue("@Active", item.Active)
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
