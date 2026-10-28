Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System
Imports System.Data

Public Class CLSWeatherItem
    Public Property Weather_id As Integer
    Public Property Weather_city As New CLSCitiesItem
    Public Property City_default As Boolean
    Public Property Show_type As Integer
    Public Property Weather_html As String
    Public Property Active As Boolean
    Public Property Remark As String
End Class

Public Class CLSWeather
    Public Function GetWEATHER() As List(Of CLSWeatherItem)
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_WEATHERS", cn) With {.CommandType = CommandType.StoredProcedure}
        'cmd.Parameters.AddWithValue("", "")
        Dim retlist As New List(Of CLSWeatherItem)()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                Do While reader.Read()
                    Dim item As New CLSWeatherItem()
                    item.Weather_id = Integer.Parse(reader("Weather_id").ToString())
                    item.Weather_city.City_id = Integer.Parse(reader("CITY_ID").ToString())
                    item.Weather_city.Name_persian = reader("CITY_ENAME").ToString()
                    item.City_default = Boolean.Parse(reader("City_default").ToString())
                    item.Show_type = Integer.Parse(reader("Show_type").ToString())
                    item.Weather_html = reader("Weather_html").ToString()
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
    Public Function GetWEATHER(ByVal id As Integer) As CLSWeatherItem
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_WEATHERS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@WeatherId", id)
        Dim item As New CLSWeatherItem()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                Do While reader.Read()
                    item.Weather_id = Integer.Parse(reader("Weather_id").ToString())
                    item.Weather_city.City_id = Integer.Parse(reader("CITY_ID").ToString())
                    item.Weather_city.Name_persian = reader("CITY_ENAME").ToString()
                    item.City_default = Boolean.Parse(reader("City_default").ToString())
                    item.Show_type = Integer.Parse(reader("Show_type").ToString())
                    item.Weather_html = reader("Weather_html").ToString()
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
    Public Function InsertWEATHER(ByVal item As CLSWeatherItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("INSERT_WEATHER", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@Weather_city", item.Weather_city.City_id)
        cmd.Parameters.AddWithValue("@City_default", item.City_default)
        cmd.Parameters.AddWithValue("@Show_type", item.Show_type)
        cmd.Parameters.AddWithValue("@Weather_html", item.Weather_html)
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
    Public Function DeleteWEATHER(ByVal item As Integer) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("DELETE_WEATHER", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@WeatherId", item)
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
    Public Function UpdateWEATHER(ByVal item As CLSWeatherItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("UPDATE_WEATHER", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@Weather_id", item.Weather_id)
        cmd.Parameters.AddWithValue("@Weather_city", item.Weather_city.City_id)
        cmd.Parameters.AddWithValue("@City_default", item.City_default)
        cmd.Parameters.AddWithValue("@Show_type", item.Show_type)
        cmd.Parameters.AddWithValue("@Weather_html", item.Weather_html)
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
End Class
