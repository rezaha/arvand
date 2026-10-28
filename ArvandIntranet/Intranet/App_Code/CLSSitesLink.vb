Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System
Imports System.Data

Public Class CLSSitesLinkItem
    Public Property Division As New CLSPlantDivisionsItem
    Public Property Site_id As Integer
    Public Property Site_group As Integer
    Public Property Show_status As Integer
    Public Property Title_persian As String
    Public Property Html_title_persian As String
    Public Property Title_latin As String
    Public Property Html_title_latin As String
    Public Property Site_link As String
    Public Property Site_order As Integer
    Public Property Site_link_delete As Boolean
    'Public Property Logo_persian() As Byte()
    'Public Property Logo_latin() As Byte()
    Public Property Logo_persian As String
    Public Property Logo_latin As String
    Public Property Remark As String
End Class

Public Class CLSSitesLink

    Public Function GetSITES_LINK() As List(Of CLSSitesLinkItem)
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_SITE_LINKS", cn) With {.CommandType = CommandType.StoredProcedure}
        'cmd.Parameters.AddWithValue("", "")
        Dim retlist As New List(Of CLSSitesLinkItem)()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                Do While reader.Read()
                    Dim item As New CLSSitesLinkItem()
                    item.Division.Company.Co_id = Integer.Parse(reader("CO_ID").ToString())
                    'item.Division.Plant.Plant_id = Integer.Parse(reader("PLANT_ID").ToString())
                    item.Division.Division_id = Integer.Parse(reader("Division_id").ToString())
                    item.Division.Name_persian = reader("DIVISION_NAME").ToString()
                    item.Division.Name_latin = reader("DIVISION_ENAME").ToString()
                    item.Site_id = Integer.Parse(reader("Site_id").ToString())
                    item.Site_group = Integer.Parse(reader("Site_group").ToString())
                    item.Show_status = Integer.Parse(reader("Show_status").ToString())
                    item.Title_persian = reader("Title_persian").ToString()
                    item.Html_title_persian = reader("Html_title_persian").ToString()
                    item.Title_latin = reader("Title_latin").ToString()
                    item.Html_title_latin = reader("Html_title_latin").ToString()
                    item.Site_link = reader("Site_link").ToString()
                    item.Site_order = Integer.Parse(reader("Site_order").ToString())
                    item.Site_link_delete = Boolean.Parse(reader("Site_link_delete").ToString())
                    'If reader("Logo_persian").ToString() <> "" Then
                    item.Logo_persian = reader("Logo_persian").ToString
                    'End If
                    'If reader("Logo_latin").ToString() <> "" Then
                    item.Logo_latin = reader("Logo_latin").ToString
                    'End If
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

    Public Function GetSITES_LINK(ByVal SiteID As Integer) As CLSSitesLinkItem
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_SITE_LINKS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@SiteID", SiteID)
        Dim retField As New CLSSitesLinkItem()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                'Dim row As Integer = 1
                reader.Read()
                retField.Division.Company.Co_id = Integer.Parse(reader("CO_ID").ToString())
                'retField.Division.Plant.Plant_id = Integer.Parse(reader("PLANT_ID").ToString())
                retField.Division.Division_id = Integer.Parse(reader("Division_id").ToString())
                retField.Division.Name_persian = reader("DIVISION_NAME").ToString()
                retField.Division.Name_latin = reader("DIVISION_ENAME").ToString()
                retField.Site_id = Integer.Parse(reader("Site_id").ToString())
                retField.Site_group = Integer.Parse(reader("Site_group").ToString())
                retField.Show_status = Integer.Parse(reader("Show_status").ToString())
                retField.Title_persian = reader("Title_persian").ToString()
                retField.Html_title_persian = reader("Html_title_persian").ToString()
                retField.Title_latin = reader("Title_latin").ToString()
                retField.Html_title_latin = reader("Html_title_latin").ToString()
                retField.Site_link = reader("Site_link").ToString()
                retField.Site_order = Integer.Parse(reader("Site_order").ToString())
                retField.Site_link_delete = Boolean.Parse(reader("Site_link_delete").ToString())
                'If reader("Logo_persian").ToString() <> "" Then
                retField.Logo_persian = reader("Logo_persian").ToString
                'End If
                'If reader("Logo_latin").ToString() <> "" Then
                retField.Logo_latin = reader("Logo_latin").ToString
                'End If
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

    Public Function InsertSITES_LINK(ByVal item As CLSSitesLinkItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("INSERT_SITES_LINK", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@Division_id", item.Division.Division_id)
        cmd.Parameters.AddWithValue("@Site_group", item.Site_group)
        cmd.Parameters.AddWithValue("@Show_status", item.Show_status)
        cmd.Parameters.AddWithValue("@Title_persian", item.Title_persian)
        cmd.Parameters.AddWithValue("@Html_title_persian", item.Html_title_persian)
        cmd.Parameters.AddWithValue("@Title_latin", item.Title_latin)
        cmd.Parameters.AddWithValue("@Html_title_latin", item.Html_title_latin)
        cmd.Parameters.AddWithValue("@Site_link", item.Site_link)
        cmd.Parameters.AddWithValue("@Site_order", item.Site_order)
        cmd.Parameters.AddWithValue("@Site_link_delete", item.Site_link_delete)
        cmd.Parameters.AddWithValue("@Logo_persian", item.Logo_persian)
        cmd.Parameters.AddWithValue("@Logo_latin", item.Logo_latin)
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

    Public Function DeleteSITES_LINK(ByVal item As Integer) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("DELETE_SITE_LINK", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@SiteId", item)
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

    Public Function UpdateSITES_LINK(ByVal item As CLSSitesLinkItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("UPDATE_SITES_LINK", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@Division_id", item.Division.Division_id)
        cmd.Parameters.AddWithValue("@Site_id", item.Site_id)
        cmd.Parameters.AddWithValue("@Site_group", item.Site_group)
        cmd.Parameters.AddWithValue("@Show_status", item.Show_status)
        cmd.Parameters.AddWithValue("@Title_persian", item.Title_persian)
        cmd.Parameters.AddWithValue("@Html_title_persian", item.Html_title_persian)
        cmd.Parameters.AddWithValue("@Title_latin", item.Title_latin)
        cmd.Parameters.AddWithValue("@Html_title_latin", item.Html_title_latin)
        cmd.Parameters.AddWithValue("@Site_link", item.Site_link)
        cmd.Parameters.AddWithValue("@Site_order", item.Site_order)
        cmd.Parameters.AddWithValue("@Site_link_delete", item.Site_link_delete)
        cmd.Parameters.AddWithValue("@Logo_persian", item.Logo_persian)
        cmd.Parameters.AddWithValue("@Logo_latin", item.Logo_latin)
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