Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System
Imports System.Data

Public Class CLSCompaniesItem
    Public Property Co_id As Integer
    Public Property Name_persian As String
    Public Property Name_latin As String
    Public Property Co_abbr As String
    Public Property Co_type As New CLSCompanyTypesItem
    Public Property Co_order As Integer
    Public Property Manager_name As String
    Public Property Co_city As New CLSCitiesItem
    Public Property Economical_code As Nullable(Of Int64)
    Public Property Address_persian As String
    Public Property Address_latin As String
    Public Property Tel_no As String
    Public Property Fax_no As String
    Public Property Email_address As String
    Public Property Active As Boolean
    Public Property Remark As String
    Public Property Co_symbol As Byte()
End Class


Public Class CLSCompanies
    Public Function GetCOMPANIES() As List(Of CLSCompaniesItem)
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_COMPANIES", cn) With {.CommandType = CommandType.StoredProcedure}
        'cmd.Parameters.AddWithValue("", "")
        Dim retlist As New List(Of CLSCompaniesItem)()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                Do While reader.Read()
                    Dim item As New CLSCompaniesItem()
                    item.Co_id = Integer.Parse(reader("Co_id").ToString())
                    item.Name_persian = reader("Name_persian").ToString()
                    item.Name_latin = reader("Name_latin").ToString()
                    item.Co_abbr = reader("Co_abbr").ToString()
                    item.Co_type.Co_type_id = Integer.Parse(reader("CO_TYPE_ID").ToString())
                    item.Co_type.Co_type_des = reader("CO_TYPE_DES").ToString()
                    item.Co_order = Integer.Parse(reader("Co_order").ToString())
                    item.Manager_name = reader("Manager_name").ToString()
                    item.Co_city.City_id = Integer.Parse(reader("CITY_ID").ToString())
                    item.Co_city.Province.Province_id = Integer.Parse(reader("PROVINCE_ID").ToString())
                    item.Co_city.Name_persian = reader("CITY_NAME").ToString()
                    item.Co_city.Name_latin = reader("CITY_ENAME").ToString()
                    If reader("Economical_code") IsNot DBNull.Value Then
                        item.Economical_code = Int64.Parse(reader("Economical_code").ToString())
                    Else
                        item.Economical_code = CType(Nothing, Int64?)
                    End If
                    item.Address_persian = reader("Address_persian").ToString()
                    item.Address_latin = reader("Address_latin").ToString()
                    item.Tel_no = reader("Tel_no").ToString()
                    item.Fax_no = reader("Fax_no").ToString()
                    item.Email_address = reader("Email_address").ToString()
                    item.Active = Boolean.Parse(reader("Active").ToString())
                    item.Remark = reader("Remark").ToString()
                    If reader("DIVISION_SYMBOL").ToString() <> "" Then
                        item.Co_symbol = reader("DIVISION_SYMBOL")
                    End If
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

    Public Function GetCOMPANIES(ByVal CompanyId As Integer) As CLSCompaniesItem
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_COMPANIES", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@CoId", CompanyId)
        Dim retField As New CLSCompaniesItem
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                reader.Read()
                retField.Co_id = Integer.Parse(reader("Co_id").ToString())
                retField.Name_persian = reader("Name_persian").ToString()
                retField.Name_latin = reader("Name_latin").ToString()
                retField.Co_abbr = reader("Co_abbr").ToString()
                retField.Co_type.Co_type_id = Integer.Parse(reader("CO_TYPE_ID").ToString())
                retField.Co_type.Co_type_des = reader("CO_TYPE_DES").ToString()
                retField.Co_order = Integer.Parse(reader("Co_order").ToString())
                retField.Manager_name = reader("Manager_name").ToString()
                retField.Co_city.City_id = Integer.Parse(reader("CITY_ID").ToString())
                retField.Co_city.Province.Province_id = Integer.Parse(reader("PROVINCE_ID").ToString())
                retField.Co_city.Name_persian = reader("CITY_NAME").ToString()
                retField.Co_city.Name_latin = reader("CITY_ENAME").ToString()
                If reader("Economical_code") IsNot DBNull.Value Then
                    retField.Economical_code = Int64.Parse(reader("Economical_code").ToString())
                Else
                    retField.Economical_code = Nothing
                End If
                retField.Address_persian = reader("Address_persian").ToString()
                retField.Address_latin = reader("Address_latin").ToString()
                retField.Tel_no = reader("Tel_no").ToString()
                retField.Fax_no = reader("Fax_no").ToString()
                retField.Email_address = reader("Email_address").ToString()
                retField.Active = Boolean.Parse(reader("Active").ToString())
                retField.Remark = reader("Remark").ToString()
                If reader("DIVISION_SYMBOL").ToString() <> "" Then
                    retField.Co_symbol = reader("DIVISION_SYMBOL")
                End If
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


    Public Function InsertCOMPANIES(ByVal item As CLSCompaniesItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("INSERT_COMPANIES", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@Name_persian", item.Name_persian)
        cmd.Parameters.AddWithValue("@Name_latin", item.Name_latin)
        cmd.Parameters.AddWithValue("@Co_abbr", item.Co_abbr)
        cmd.Parameters.AddWithValue("@Co_type", item.Co_type.Co_type_id)
        cmd.Parameters.AddWithValue("@Co_order", item.Co_order)
        cmd.Parameters.AddWithValue("@Manager_name", item.Manager_name)
        cmd.Parameters.AddWithValue("@Co_city", item.Co_city.City_id)
        cmd.Parameters.AddWithValue("@Economical_code", item.Economical_code)
        cmd.Parameters.AddWithValue("@Address_persian", item.Address_persian)
        cmd.Parameters.AddWithValue("@Address_latin", item.Address_latin)
        cmd.Parameters.AddWithValue("@Tel_no", item.Tel_no)
        cmd.Parameters.AddWithValue("@Fax_no", item.Fax_no)
        cmd.Parameters.AddWithValue("@Email_address", item.Email_address)
        cmd.Parameters.AddWithValue("@Active", item.Active)
        cmd.Parameters.AddWithValue("@Remark", item.Remark)
        cmd.Parameters.AddWithValue("@Symbol_status", 1)
        cmd.Parameters.AddWithValue("@Division_symbol", item.Co_symbol)
        cmd.Parameters.AddWithValue("@Division_symbol_link", "")
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
    Public Function DeleteCOMPANIES(ByVal item As Integer) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("DELETE_COMPANIES", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@CoId", item)
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
    Public Function UpdateCOMPANIES(ByVal item As CLSCompaniesItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("UPDATE_COMPANIES", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@Co_id", item.Co_id)
        cmd.Parameters.AddWithValue("@Name_persian", item.Name_persian)
        cmd.Parameters.AddWithValue("@Name_latin", item.Name_latin)
        cmd.Parameters.AddWithValue("@Co_abbr", item.Co_abbr)
        cmd.Parameters.AddWithValue("@Co_type", item.Co_type.Co_type_id)
        cmd.Parameters.AddWithValue("@Co_order", item.Co_order)
        cmd.Parameters.AddWithValue("@Manager_name", item.Manager_name)
        cmd.Parameters.AddWithValue("@Co_city", item.Co_city.City_id)
        cmd.Parameters.AddWithValue("@Economical_code", item.Economical_code)
        cmd.Parameters.AddWithValue("@Address_persian", item.Address_persian)
        cmd.Parameters.AddWithValue("@Address_latin", item.Address_latin)
        cmd.Parameters.AddWithValue("@Tel_no", item.Tel_no)
        cmd.Parameters.AddWithValue("@Fax_no", item.Fax_no)
        cmd.Parameters.AddWithValue("@Email_address", item.Email_address)
        cmd.Parameters.AddWithValue("@Active", item.Active)
        cmd.Parameters.AddWithValue("@Remark", item.Remark)
        cmd.Parameters.AddWithValue("@Symbol_status", 1)
        cmd.Parameters.AddWithValue("@Division_symbol", item.Co_symbol)
        cmd.Parameters.AddWithValue("@Division_symbol_link", "")
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