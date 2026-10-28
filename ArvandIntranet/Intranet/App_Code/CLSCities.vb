Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System
Imports System.Data

Public Class CLSCitiesItem
    Public Property Province As New CLSProvincesItem
    Public Property City_id As Integer
    Public Property Name_persian As String
    Public Property Name_latin As String
    Public Property Remark As String
End Class

Public Class CLSCities
    Public Function GetCITIES(Optional ByVal ProvinceId As Integer = 0) As List(Of CLSCitiesItem)
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_CITIES", cn) With {.CommandType = CommandType.StoredProcedure}
        If ProvinceId <> 0 Then
            cmd.Parameters.AddWithValue("@ProvinceId", ProvinceId)
        End If
        Dim retlist As New List(Of CLSCitiesItem)()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                Do While reader.Read()
                    Dim item As New CLSCitiesItem()
                    item.Province.Province_id = Integer.Parse(reader("PROVINCE_ID").ToString())
                    item.Province.Name_persian = reader("PROVINCE_NAME").ToString()
                    item.Province.Name_latin = reader("PROVINCE_ENAME").ToString()
                    item.City_id = Integer.Parse(reader("CITY_ID").ToString())
                    item.Name_persian = reader("CITY_NAME").ToString()
                    item.Name_latin = reader("CITY_ENAME").ToString()
                    item.Remark = reader("REMARK").ToString()
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

    Public Function GetCITIE(ByVal CityId As Integer) As CLSCitiesItem
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_CITIES", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@CityID", CityId)
        Dim retField As New CLSCitiesItem()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                reader.Read()
                retField.Province.Province_id = Integer.Parse(reader("PROVINCE_ID").ToString())
                retField.Province.Country.Country_id = Integer.Parse(reader("COUNTRY_ID"))
                retField.Province.Name_persian = reader("PROVINCE_NAME").ToString()
                retField.Province.Name_latin = reader("PROVINCE_ENAME").ToString()
                retField.City_id = Integer.Parse(reader("CITY_ID").ToString())
                retField.Name_persian = reader("CITY_NAME").ToString()
                retField.Name_latin = reader("CITY_ENAME").ToString()
                retField.Remark = reader("REMARK").ToString()
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

    Public Function InsertCITIES(ByVal item As CLSCitiesItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("INSERT_CITIES", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@Province_id", item.Province.Province_id)
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
    Public Function DeleteCITIES(ByVal item As Integer) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("DELETE_CITIES", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@CityId", item)
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
    Public Function UpdateCITIES(ByVal item As CLSCitiesItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("UPDATE_CITIES", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@Province_id", item.Province.Province_id)
        cmd.Parameters.AddWithValue("@City_id", item.City_id)
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