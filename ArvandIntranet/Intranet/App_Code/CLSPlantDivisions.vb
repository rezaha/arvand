Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System
Imports System.Data

Public Class CLSPlantDivisionsItem
    Public Property Company As New CLSCompaniesItem
    'Public Property Plant As New CLSPlantsItem
    Public Property Division_id As Integer
    Public Property Name_persian As String
    Public Property Name_latin As String
    Public Property Division_abbr As String
    Public Property Division_order As Nullable(Of Integer)
    Public Property Html_contactus_persian As String
    Public Property Html_contactus_latin As String
    Public Property Header_status As Integer
    Public Property Header_image As Byte()
    Public Property Header_image_link As String
    Public Property Icon_status As Integer
    Public Property Division_icon As Byte()
    Public Property Division_icon_link As String
    Public Property Active As Boolean
End Class
Public Class CLSPlantDivisions
    Public Function GetPLANT_DIVISIONS() As List(Of CLSPlantDivisionsItem)
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_PLANT_DIVISIONS", cn) With {.CommandType = CommandType.StoredProcedure}
        'If PlantId <> 0 Then
        '    cmd.Parameters.AddWithValue("PlantId", PlantId)
        'End If
        'cmd.Parameters.AddWithValue("", "")
        Dim retlist As New List(Of CLSPlantDivisionsItem)()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                Do While reader.Read()
                    Dim item As New CLSPlantDivisionsItem()
                    item.Company.Co_id = Integer.Parse(reader("Co_id").ToString())
                    item.Company.Name_persian = reader("Name_persian").ToString()
                    'item.Plant.Plant_id = Integer.Parse(reader("Plant_id").ToString())
                    'item.Plant.Name_persian = reader("PLANT_NAME").ToString()
                    item.Division_id = Integer.Parse(reader("Division_id").ToString())
                    item.Name_persian = reader("Division_Name").ToString()
                    item.Name_latin = reader("Division_EName").ToString()
                    item.Division_abbr = reader("Division_abbr").ToString()
                    If reader("Division_order") IsNot DBNull.Value Then
                        item.Division_order = Integer.Parse(reader("Division_order").ToString())
                    Else
                        item.Division_order = CType(Nothing, Integer?)
                    End If
                    item.Html_contactus_persian = reader("Html_contactus_persian").ToString()
                    item.Html_contactus_latin = reader("Html_contactus_latin").ToString()
                    item.Header_status = Integer.Parse(reader("Header_status").ToString())
                    If reader("Header_image").ToString() <> "" Then
                        item.Header_image = reader("Header_image")
                    Else
                        item.Header_image = Nothing
                    End If

                    item.Header_image_link = reader("Header_image_link").ToString()
                    item.Icon_status = Integer.Parse(reader("Icon_status").ToString())
                    If reader("Division_icon").ToString() <> "" Then
                        item.Header_image = reader("Division_icon")
                    Else
                        item.Header_image = Nothing
                    End If
                    item.Division_icon_link = reader("Division_icon_link").ToString()
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

    Public Function GetPLANT_DIVISION(ByVal id As Integer) As CLSPlantDivisionsItem
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_PLANT_DIVISIONS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@DivisionId", id)
        Dim item As New CLSPlantDivisionsItem()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                Do While reader.Read()
                    item.Company.Co_id = Integer.Parse(reader("Co_id").ToString())
                    item.Company.Name_persian = reader("Name_persian").ToString()
                    'item.Plant.Plant_id = Integer.Parse(reader("Plant_id").ToString())
                    'item.Plant.Name_persian = reader("PLANT_NAME").ToString()
                    item.Division_id = Integer.Parse(reader("Division_id").ToString())
                    item.Name_persian = reader("Division_Name").ToString()
                    item.Name_latin = reader("Division_EName").ToString()
                    item.Division_abbr = reader("Division_abbr").ToString()
                    If reader("Division_order") IsNot DBNull.Value Then
                        item.Division_order = Integer.Parse(reader("Division_order").ToString())
                    Else
                        item.Division_order = CType(Nothing, Integer?)
                    End If
                    item.Html_contactus_persian = reader("Html_contactus_persian").ToString()
                    item.Html_contactus_latin = reader("Html_contactus_latin").ToString()
                    item.Header_status = Integer.Parse(reader("Header_status").ToString())
                    If reader("Header_image").ToString().Trim <> "" Then
                        item.Header_image = CType(reader("Header_image"), Byte())
                    Else
                        item.Header_image = Nothing
                    End If

                    item.Header_image_link = reader("Header_image_link").ToString()
                    item.Icon_status = Integer.Parse(reader("Icon_status").ToString())
                    If reader("Division_icon").ToString() <> "" Then
                        item.Division_icon = reader("Division_icon")
                    Else
                        item.Division_icon = Nothing
                    End If
                    item.Division_icon_link = reader("Division_icon_link").ToString()
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

    Public Function InsertPLANT_DIVISIONS(ByVal item As CLSPlantDivisionsItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("INSERT_PLANT_DIVISIONS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@Co_id", item.Company.Co_id)
        'cmd.Parameters.AddWithValue("@Plant_id", item.Plant.Plant_id)
        cmd.Parameters.AddWithValue("@Name_persian", item.Name_persian)
        cmd.Parameters.AddWithValue("@Name_latin", item.Name_latin)
        cmd.Parameters.AddWithValue("@Division_abbr", item.Division_abbr)
        cmd.Parameters.AddWithValue("@Division_order", item.Division_order)
        cmd.Parameters.AddWithValue("@Html_contactus_persian", item.Html_contactus_persian)
        cmd.Parameters.AddWithValue("@Html_contactus_latin", item.Html_contactus_latin)
        cmd.Parameters.AddWithValue("@Header_status", item.Header_status)
        cmd.Parameters.AddWithValue("@Header_image", item.Header_image)
        cmd.Parameters.AddWithValue("@Header_image_link", item.Header_image_link)
        cmd.Parameters.AddWithValue("@Icon_status", item.Icon_status)
        cmd.Parameters.AddWithValue("@Division_icon", item.Division_icon)
        cmd.Parameters.AddWithValue("@Division_icon_link", item.Division_icon_link)
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
    Public Function DeletePLANT_DIVISIONS(ByVal item As Integer) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("DELETE_PLANT_DIVISIONS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@DivisionId", item)
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

    Public Function UpdatePLANT_DIVISIONS(ByVal item As CLSPlantDivisionsItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("UPDATE_PLANT_DIVISIONS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@Co_id", item.Company.Co_id)
        'cmd.Parameters.AddWithValue("@Plant_id", item.Plant.Plant_id)
        cmd.Parameters.AddWithValue("@Division_id", item.Division_id)
        cmd.Parameters.AddWithValue("@Name_persian", item.Name_persian)
        cmd.Parameters.AddWithValue("@Name_latin", item.Name_latin)
        cmd.Parameters.AddWithValue("@Division_abbr", item.Division_abbr)
        cmd.Parameters.AddWithValue("@Division_order", item.Division_order)
        cmd.Parameters.AddWithValue("@Html_contactus_persian", item.Html_contactus_persian)
        cmd.Parameters.AddWithValue("@Html_contactus_latin", item.Html_contactus_latin)
        cmd.Parameters.AddWithValue("@Header_status", item.Header_status)
        cmd.Parameters.AddWithValue("@Header_image", item.Header_image)
        cmd.Parameters.AddWithValue("@Header_image_link", item.Header_image_link)
        cmd.Parameters.AddWithValue("@Icon_status", item.Icon_status)
        cmd.Parameters.AddWithValue("@Division_icon", item.Division_icon)
        cmd.Parameters.AddWithValue("@Division_icon_link", item.Division_icon_link)
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