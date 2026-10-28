Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System
Imports System.Data

Public Class CLSPagesItem
    Public Property Division As New CLSPlantDivisionsItem
    Public Property Page_id As Integer
    Public Property Page_no As Integer
    Public Property Page_Type As Integer
    Public Property Masterpage As New CLSMasterPagesItem
    Public Property Page_file_name As String
    Public Property Page_title As String
    Public Property Page_link As String
    Public Property Page_Summary As String
    Public Property Page_Content As String
    Public Property Page_delete As Boolean
    Public Property Active As Boolean
    Public Property Remark As String
End Class

Public Class CLSPages

    Public Function GetPAGES(Optional ByVal PageType As Integer = 0) As List(Of CLSPagesItem)
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_PAGES", cn) With {.CommandType = CommandType.StoredProcedure}
        If PageType <> 0 Then
            cmd.Parameters.AddWithValue("@PageType", PageType)
        End If

        Dim retlist As New List(Of CLSPagesItem)()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                Do While reader.Read()
                    Dim item As New CLSPagesItem()
                    item.Division.Company.Co_id = Integer.Parse(reader("CO_ID").ToString())
                    'item.Division.Plant.Plant_id = Integer.Parse(reader("PLANT_ID").ToString())
                    item.Division.Division_id = Integer.Parse(reader("Division_id").ToString())
                    item.Division.Name_persian = reader("DIVISION_NAME").ToString()
                    item.Page_id = Integer.Parse(reader("Page_id").ToString())
                    item.Page_no = Integer.Parse(reader("Page_no").ToString())
                    item.Page_Type = Integer.Parse(reader("Page_Type").ToString())
                    item.Masterpage.Masterpage_id = Integer.Parse(reader("Masterpage_id").ToString())
                    item.Page_file_name = reader("Page_file_name").ToString()
                    item.Page_title = reader("Page_title").ToString()
                    item.Page_link = reader("Page_link").ToString()
                    item.Page_Summary = reader("PAGE_CONTENT").ToString
                    item.Page_delete = Boolean.Parse(reader("Page_delete").ToString())
                    item.Active = Boolean.Parse(reader("Active").ToString())
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

    Public Function GetPAGE(ByVal id As Integer) As CLSPagesItem
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_PAGES", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@PageId", id)
        Dim item As New CLSPagesItem()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                Do While reader.Read()
                    item.Division.Company.Co_id = Integer.Parse(reader("CO_ID").ToString())
                    'item.Division.Plant.Plant_id = Integer.Parse(reader("PLANT_ID").ToString())
                    item.Division.Division_id = Integer.Parse(reader("Division_id").ToString())
                    item.Division.Name_persian = reader("DIVISION_NAME").ToString()
                    item.Page_id = Integer.Parse(reader("Page_id").ToString())
                    item.Page_no = Integer.Parse(reader("Page_no").ToString())
                    item.Page_Type = Integer.Parse(reader("Page_Type").ToString())
                    item.Masterpage.Masterpage_id = Integer.Parse(reader("Masterpage_id").ToString())
                    item.Page_file_name = reader("Page_file_name").ToString()
                    item.Page_title = reader("Page_title").ToString()
                    item.Page_link = reader("Page_link").ToString()
                    item.Page_Summary = reader("PAGE_PERSIAN_CONTENT").ToString
                    item.Page_Content = reader("PAGE_LATIN_CONTENT").ToString
                    item.Page_delete = Boolean.Parse(reader("Page_delete").ToString())
                    item.Active = Boolean.Parse(reader("Active").ToString())
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

    Public Function InsertPAGES(ByVal item As CLSPagesItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("INSERT_PAGES", cn) With {.CommandType = CommandType.StoredProcedure}

        cmd.Parameters.AddWithValue("@Division_id", item.Division.Division_id)
        cmd.Parameters.AddWithValue("@Page_no", item.Page_no)
        cmd.Parameters.AddWithValue("@Page_Type", item.Page_Type)
        cmd.Parameters.AddWithValue("@Masterpage_id", item.Masterpage.Masterpage_id)
        cmd.Parameters.AddWithValue("@Page_file_name", item.Page_file_name)
        cmd.Parameters.AddWithValue("@Page_title", item.Page_title)
        cmd.Parameters.AddWithValue("@Page_link", item.Page_link)
        cmd.Parameters.AddWithValue("@PAGE_PERSIAN_CONTENT", item.Page_Summary)
        cmd.Parameters.AddWithValue("@PAGE_LATIN_CONTENT", item.Page_Content)
        cmd.Parameters.AddWithValue("@Page_delete", item.Page_delete)
        cmd.Parameters.AddWithValue("@Active", item.Active)
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

    Public Function DeletePAGES(ByVal item As Integer) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("DELETE_PAGES", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@PageId", item)
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

    Public Function UpdatePAGES(ByVal item As CLSPagesItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("UPDATE_PAGES", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@Division_id", item.Division.Division_id)
        cmd.Parameters.AddWithValue("@Page_id", item.Page_id)
        cmd.Parameters.AddWithValue("@Page_no", item.Page_no)
        cmd.Parameters.AddWithValue("@Page_Type", item.Page_Type)
        cmd.Parameters.AddWithValue("@Masterpage_id", item.Masterpage.Masterpage_id)
        cmd.Parameters.AddWithValue("@Page_file_name", item.Page_file_name)
        cmd.Parameters.AddWithValue("@Page_title", item.Page_title)
        cmd.Parameters.AddWithValue("@Page_link", item.Page_link)
        cmd.Parameters.AddWithValue("@PAGE_PERSIAN_CONTENT", item.Page_Summary)
        cmd.Parameters.AddWithValue("@PAGE_LATIN_CONTENT", item.Page_Content)
        cmd.Parameters.AddWithValue("@Page_delete", item.Page_delete)
        cmd.Parameters.AddWithValue("@Active", item.Active)
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

    Public Function GetPageDetails(ByVal name As String) As CLSPagesItem
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_MASTERPAGE_PAGENAME", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@PageName", name)
        Dim item As New CLSPagesItem()
        'Dim masterLink As String = String.Empty
        Dim reader As SqlDataReader = Nothing

        Try
            cn.Open()
            ' masterLink = cmd.ExecuteScalar().ToString
            reader = cmd.ExecuteReader()
            If (reader.HasRows) Then
                If reader.Read Then
                    item.Page_id = Integer.Parse(reader("Page_id").ToString())
                    item.Page_no = Integer.Parse(reader("Page_no").ToString())
                    item.Page_Type = Integer.Parse(reader("Page_Type").ToString())
                    item.Page_file_name = reader("Page_file_name").ToString()
                    item.Page_title = reader("Page_title").ToString()
                    item.Page_link = reader("Page_link").ToString()
                    item.Page_delete = Boolean.Parse(reader("Page_delete").ToString())
                    item.Active = Boolean.Parse(reader("Active").ToString())
                    item.Remark = reader("Remark").ToString()
                    item.Masterpage.Masterpage_link = reader("MASTERPAGE_LINK").ToString
                    item.Page_Summary = reader("PAGE_CONTENT").ToString
                    'item.Page_Latin_Content = reader("PAGE_LATIN_CONTENT").ToString
                    item.Division.Name_persian = reader("NAME_PERSIAN").ToString
                    item.Division.Name_latin = reader("NAME_LATIN").ToString
                    item.Division.Division_id = reader("DIVISION_ID").ToString
                    item.Division.Company.Co_id = reader("CO_ID").ToString
                    item.Division.Company.Name_persian = reader("CO_NAME_PERSIAN").ToString
                    item.Division.Company.Name_latin = reader("CO_NAME_LATIN").ToString
                End If
            End If
        Catch e1 As SqlException
            '  lv() 'Throw
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

End Class
