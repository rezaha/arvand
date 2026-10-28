Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data

Public Class CLSPrayerTimeItem
    Public Property PrayerId As Integer
    Public Property City As New CLSCitiesItem
    Public Property PrayerDate As String
    Public Property MorningPrayer As String
    Public Property Sunrise As String
    Public Property NoonPrayer As String
    Public Property Sunset As String
    Public Property MaghribPrayer As String
    Public Property Midnight As String
    Public Property Remark As String
End Class

Public Class CLSPrayerTime

    Public Function GetRecords(Optional ByVal PrayerId As Integer? = Nothing, Optional ByVal CityId As Integer? = Nothing,
                                      Optional ByVal ProvinceId As Integer? = Nothing, Optional ByVal PrayerDate As String = Nothing) As List(Of CLSPrayerTimeItem)
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_PRAYER_TIME", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@PRAYER_ID", PrayerId)
        cmd.Parameters.AddWithValue("@CITY_ID", CityId)
        cmd.Parameters.AddWithValue("@PROVINCE_ID", ProvinceId)
        cmd.Parameters.AddWithValue("@PRAYER_DATE", PrayerDate)
        Dim retlist As New List(Of CLSPrayerTimeItem)()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Do While reader.Read()
                    Dim item As New CLSPrayerTimeItem()
                    item.PrayerId = reader("PRAYER_ID").ToString()
                    item.City.City_id = reader("CITY_ID").ToString()
                    item.City.Name_persian = reader("CITY_PERSIAN").ToString()
                    item.PrayerDate = reader("PRAYER_DATE").ToString()
                    item.MorningPrayer = reader("MORNING_PRAYER").ToString()
                    item.Sunrise = reader("SUNRISE").ToString()
                    item.NoonPrayer = reader("NOON_PRAYER").ToString()
                    item.Sunset = reader("SUNSET").ToString()
                    item.MaghribPrayer = reader("MAGHRIB_PRAYER").ToString()
                    item.Midnight = reader("MIDNIGHT").ToString()
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

    Public Function GetRecord(Optional ByVal PrayerId As Integer? = Nothing, Optional ByVal CityId As Integer? = Nothing,
                                      Optional ByVal ProvinceId As Integer? = Nothing, Optional ByVal PrayerDate As String = Nothing) As CLSPrayerTimeItem
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_PRAYER_TIME", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@PRAYER_ID", PrayerId)
        cmd.Parameters.AddWithValue("@CITY_ID", CityId)
        cmd.Parameters.AddWithValue("@PROVINCE_ID", ProvinceId)
        cmd.Parameters.AddWithValue("@PRAYER_DATE", PrayerDate)
        Dim item As New CLSPrayerTimeItem()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                reader.Read()
                item.PrayerId = reader("PRAYER_ID").ToString()
                item.City.City_id = reader("CITY_ID").ToString()
                item.City.Name_persian = reader("CITY_PERSIAN").ToString()
                item.PrayerDate = reader("PRAYER_DATE").ToString()
                item.MorningPrayer = reader("MORNING_PRAYER").ToString()
                item.Sunrise = reader("SUNRISE").ToString()
                item.NoonPrayer = reader("NOON_PRAYER").ToString()
                item.Sunset = reader("SUNSET").ToString()
                item.MaghribPrayer = reader("MAGHRIB_PRAYER").ToString()
                item.Midnight = reader("MIDNIGHT").ToString()
                item.Remark = reader("Remark").ToString()
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

    Public Function Insert(ByVal item As CLSPrayerTimeItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("INSERT_PRAYER_TIME", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@CITY_ID", item.City.City_id)
        cmd.Parameters.AddWithValue("@MAGHRIB_PRAYER", item.MaghribPrayer)
        cmd.Parameters.AddWithValue("@MIDNIGHT", item.Midnight)
        cmd.Parameters.AddWithValue("@MORNING_PRAYER", item.MorningPrayer)
        cmd.Parameters.AddWithValue("@NOON_PRAYER", item.NoonPrayer)
        cmd.Parameters.AddWithValue("@PRAYER_DATE", item.PrayerDate)
        cmd.Parameters.AddWithValue("@SUNRISE", item.Sunrise)
        cmd.Parameters.AddWithValue("@SUNSET", item.Sunset)
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

    Public Function Delete(ByVal item As CLSPrayerTimeItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("DELETE_PRAYER_TIME", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@PRAYER_ID", item.PrayerId)
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

    Public Function Update(ByVal item As CLSPrayerTimeItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("UPDATE_PRAYER_TIME", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@CITY_ID", item.City.City_id)
        cmd.Parameters.AddWithValue("@MAGHRIB_PRAYER", item.MaghribPrayer)
        cmd.Parameters.AddWithValue("@MIDNIGHT", item.Midnight)
        cmd.Parameters.AddWithValue("@MORNING_PRAYER", item.MorningPrayer)
        cmd.Parameters.AddWithValue("@NOON_PRAYER", item.NoonPrayer)
        cmd.Parameters.AddWithValue("@PRAYER_DATE", item.PrayerDate)
        cmd.Parameters.AddWithValue("@PRAYER_ID", item.PrayerId)
        cmd.Parameters.AddWithValue("@SUNRISE", item.Sunrise)
        cmd.Parameters.AddWithValue("@SUNSET", item.Sunset)
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
