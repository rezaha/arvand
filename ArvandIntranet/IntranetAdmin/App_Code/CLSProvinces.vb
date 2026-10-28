Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System
Imports System.Data

Public Class CLSProvincesItem
    Public Property Country As New CLSCountriesItem
    Public Property Province_id() As Integer
    Public Property Name_persian() As String
    Public Property Name_latin() As String
    Public Property Remark() As String
End Class
Public Class CLSProvinces
    Public Function GetPROVINCES(Optional ByVal CountryId As Integer = 0) As List(Of CLSProvincesItem)
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_PROVINCE", cn) With {.CommandType = CommandType.StoredProcedure}

        If CountryId <> 0 Then
            cmd.Parameters.AddWithValue("@CountryId", CountryId)
        End If
        Dim retlist As New List(Of CLSProvincesItem)()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                Do While reader.Read()
                    Dim item As New CLSProvincesItem()
                    item.Country.Country_id = Integer.Parse(reader("COUNTRY_ID").ToString())
                    item.Country.Name_persian = reader("NAME_PERSIAN").ToString()
                    item.Country.Name_latin = reader("NAME_LATIN").ToString()
                    item.Province_id = Integer.Parse(reader("PROVINCE_ID").ToString())
                    item.Name_persian = reader("PROVINCE_NAME").ToString()
                    item.Name_latin = reader("PROVINCE_ENAME").ToString()
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

    Public Function GetPROVINCE(ByVal ProvinceId As Integer) As CLSProvincesItem
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_PROVINCE", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@ProvinceId", ProvinceId)
        Dim retField As New CLSProvincesItem
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                reader.Read()
                retField.Country.Country_id = Integer.Parse(reader("COUNTRY_ID").ToString())
                retField.Country.Name_persian = reader("NAME_PERSIAN").ToString()
                retField.Country.Name_latin = reader("NAME_LATIN").ToString()
                retField.Province_id = Integer.Parse(reader("PROVINCE_ID").ToString())
                retField.Name_persian = reader("PROVINCE_NAME").ToString()
                retField.Name_latin = reader("PROVINCE_ENAME").ToString()
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

    Public Function InsertPROVINCES(ByVal item As CLSProvincesItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("INSERT_PROVINCES", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@Country_id", item.Country.Country_id)
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
    Public Function DeletePROVINCES(ByVal item As Integer) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("DELETE_PROVINCES", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@ProvinceId", item)
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
    Public Function UpdatePROVINCES(ByVal item As CLSProvincesItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("UPDATE_PROVINCES", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@Country_id", item.Country.Country_id)
        cmd.Parameters.AddWithValue("@Province_id", item.Province_id)
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