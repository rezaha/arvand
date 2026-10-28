Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System
Imports System.Data

Public Class CLSAlbumsItem
    Public Property AlbumId As Integer
    Public Property AlbumType As Integer
    Public Property AlbumNo As Integer
    Public Property AlbumImage As String
    Public Property PersianName As String
    Public Property LatinName As String
    Public Property Remark As String
End Class

Public Class CLSAlbums

    Public Function GetAlbums(Optional ByVal AlbumId As Integer? = Nothing, Optional ByVal AlbumType As Integer? = Nothing) As List(Of CLSAlbumsItem)
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_ALBUMS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@AlbumId", AlbumId)
        cmd.Parameters.AddWithValue("@AlbumType", AlbumType)
        Dim retlist As New List(Of CLSAlbumsItem)()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader
            If reader.HasRows Then
                Dim row As Integer = 1
                Do While reader.Read()
                    Dim item As New CLSAlbumsItem()
                    item.AlbumId = Convert.ToInt32(reader("ALBUM_ID").ToString)
                    item.AlbumNo = Convert.ToInt32(reader("ALBUM_NO").ToString())
                    item.AlbumType = reader("ALBUM_TYPE").ToString()
                    item.AlbumImage = reader("ALBUM_IMAGE").ToString()
                    item.LatinName = reader("LATIN_NAME").ToString()
                    item.PersianName = reader("PERSIAN_NAME").ToString()
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

    Public Function GetALBUM(Optional ByVal AlbumId As Integer? = Nothing, Optional ByVal AlbumType As Integer? = Nothing) As CLSAlbumsItem
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_ALBUMS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@AlbumId", AlbumId)
        cmd.Parameters.AddWithValue("@AlbumType", AlbumType)
        Dim item As New CLSAlbumsItem()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                Do While reader.Read()
                    item.AlbumId = Convert.ToInt32(reader("ALBUM_ID").ToString)
                    item.AlbumNo = Convert.ToInt32(reader("ALBUM_NO").ToString())
                    item.AlbumType = reader("ALBUM_TYPE").ToString()
                    item.AlbumImage = reader("ALBUM_IMAGE").ToString()
                    item.LatinName = reader("LATIN_NAME").ToString()
                    item.PersianName = reader("PERSIAN_NAME").ToString()
                    item.Remark = reader("REMARK").ToString()
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

    Public Function InsertALBUMS(ByVal item As CLSAlbumsItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("INSERT_ALBUMS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@AlbumType", item.AlbumType)
        cmd.Parameters.AddWithValue("@AlbumImage", item.AlbumImage)
        cmd.Parameters.AddWithValue("@AlbumNo", item.AlbumNo)
        cmd.Parameters.AddWithValue("@PersianName", item.PersianName)
        cmd.Parameters.AddWithValue("@LatinName", item.LatinName)
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

    Public Function DeleteALBUMS(ByVal item As Integer) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("DELETE_ALBUM", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@Album_id", item)
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

    Public Function UpdateALBUMS(ByVal item As CLSAlbumsItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("UPDATE_ALBUMS", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@AlbumType", item.AlbumType)
        cmd.Parameters.AddWithValue("@AlbumImage", item.AlbumImage)
        cmd.Parameters.AddWithValue("@AlbumId", item.AlbumId)
        cmd.Parameters.AddWithValue("@AlbumNo", item.AlbumNo)
        cmd.Parameters.AddWithValue("@PersianName", item.PersianName)
        cmd.Parameters.AddWithValue("@LatinName", item.LatinName)
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
