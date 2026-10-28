Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System
Imports System.Data

Public Class CLSPagesWebpartsItem
    Public Property Page_webpart As Integer
    Public Property Page As New CLSPagesItem
    Public Property Webpart As New CLSWebpartsItem
    Public Property Row_no As Integer
    Public Property Col_no As Integer
    Public Property Col_order As Integer
    Public Property Collapse_option As Boolean
    Public Property Move_option As Boolean
    Public Property Delete_option As Boolean
    Public Property Header_Visible As Boolean
    Public Property Remark As String
End Class
Public Class CLSPagesWebparts
    Public Function GetPAGES_WEBPARTS() As List(Of CLSPagesWebpartsItem)
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_PAGES_WEBPARTS", cn) With {.CommandType = CommandType.StoredProcedure}
        'cmd.Parameters.AddWithValue("", )
        Dim retlist As New List(Of CLSPagesWebpartsItem)()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                Do While reader.Read()
                    Dim item As New CLSPagesWebpartsItem()
                    item.Page_webpart = Integer.Parse(reader("Page_webpart").ToString())
                    item.Page.Page_id = Integer.Parse(reader("Page_id").ToString())
                    item.Webpart.Webpart_id = Integer.Parse(reader("Webpart_id").ToString())
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

    Public Function GetPAGES_WEBPARTS(ByVal id As Integer) As CLSPagesWebpartsItem
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_PAGES_WEBPARTS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@PageWebPart", id)
        Dim item As New CLSPagesWebpartsItem()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                Do While reader.Read()
                    item.Page_webpart = Integer.Parse(reader("Page_webpart").ToString())
                    item.Page.Page_id = Integer.Parse(reader("Page_id").ToString())
                    item.Webpart.Webpart_id = Integer.Parse(reader("Webpart_id").ToString())
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
                cn.Dispose()
            End If
        End Try
        Return item
    End Function

    Public Function InsertPAGES_WEBPARTS(ByVal item As CLSPagesWebpartsItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("INSERT_PAGES_WEBPARTS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@Page_id", item.Page.Page_id)
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

    Public Function DeletePAGES_WEBPARTS(ByVal item As Integer) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("DELETE_PAGES_WEBPART", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@PageWebPart", item)
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

    Public Function UpdatePAGES_WEBPARTS(ByVal item As CLSPagesWebpartsItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("UPDATE_PAGES_WEBPARTS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@Page_webpart", item.Page_webpart)
        cmd.Parameters.AddWithValue("@Page_id", item.Page.Page_id)
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

    Public Function GetWebPartPage(ByVal name As String) As List(Of CLSPagesWebpartsItem)
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_WebPartPage", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@pageName", name)
        Dim retList As New List(Of CLSPagesWebpartsItem)
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If (reader.HasRows) Then
                While (reader.Read)
                    Dim item As New CLSPagesWebpartsItem
                    item.Page.Page_id = Integer.Parse(reader.Item("PAGE_ID").ToString)
                    item.Page.Page_file_name = reader.Item("PAGE_FILE_NAME").ToString
                    item.Webpart.Webpart_id = Integer.Parse(reader.Item("WEBPART_ID").ToString)
                    item.Webpart.WebPartType = Integer.Parse(reader.Item("WEBPART_TYPE").ToString)
                    item.Webpart.Webpart_no = Integer.Parse(reader.Item("WEBPART_NO").ToString)
                    item.Webpart.Webpart_group = Integer.Parse(reader.Item("WEBPART_GROUP").ToString)
                    item.Webpart.Webpart_name = reader.Item("WEBPART_NAME").ToString
                    item.Webpart.Name_persian = reader.Item("NAME_PERSIAN").ToString
                    item.Webpart.Name_latin = reader.Item("NAME_LATIN").ToString
                    item.Webpart.Header_persian = reader.Item("HEADER_PERSIAN").ToString
                    item.Webpart.Header_latin = reader.Item("HEADER_LATIN").ToString
                    item.Webpart.Html_content_persian = reader.Item("HTML_CONTENT_PERSIAN").ToString
                    item.Webpart.Html_content_latin = reader.Item("HTML_CONTENT_LATIN").ToString
                    item.Webpart.Description_persian = reader.Item("DESCRIPTION_PERSIAN").ToString
                    item.Webpart.Description_latin = reader.Item("DESCRIPTION_LATIN").ToString

                    item.Webpart.WebPart_Address = reader.Item("WEBPART_ADDRESS").ToString
                    item.Webpart.WebpartMethod = reader.Item("WEBPART_METHOD").ToString
                    item.Webpart.WebPartParameters = reader.Item("WEBPART_PARAMETERS").ToString

                    item.Webpart.Active = Boolean.Parse(reader.Item("ACTIVE").ToString)
                    item.Webpart.Remark = reader.Item("REMARK").ToString
                    item.Row_no = Integer.Parse(reader("Row_no").ToString())
                    item.Col_no = Integer.Parse(reader("Col_no").ToString())
                    item.Col_order = Integer.Parse(reader("Col_order").ToString())
                    item.Collapse_option = Boolean.Parse(reader("Collapse_option").ToString())
                    item.Move_option = Boolean.Parse(reader("Move_option").ToString())
                    item.Delete_option = Boolean.Parse(reader("Delete_option").ToString())
                    item.Remark = reader("Remark").ToString()
                    retList.Add(item)
                End While
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
                cn.Dispose()
            End If
        End Try
        Return retList
    End Function
End Class
