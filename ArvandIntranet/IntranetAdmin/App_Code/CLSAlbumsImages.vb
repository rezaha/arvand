Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System
Imports System.Data

Public Class CLSAlbumsImagesItem
    Public Property Album As New CLSAlbumsItem
    Public Property ImageId As Integer
    Public Property ImageAddress As String
    Public Property PersianDes As String
    Public Property LatinDes As String
    Public Property Remark As String
End Class

Public Class CLSAlbumsImages

    Public Function GetAlbumImages(Optional ByVal AlbumId As Integer? = Nothing, Optional ByVal AlbumType As Integer? = Nothing) As List(Of CLSAlbumsImagesItem)
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_ALBUMS_IMAGES", cn) With {.CommandType = CommandType.StoredProcedure}

        cmd.Parameters.AddWithValue("@AlbumId", AlbumId)
        cmd.Parameters.AddWithValue("@AlbumType", AlbumType)
        Dim retlist As New List(Of CLSAlbumsImagesItem)()
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                Do While reader.Read()
                    Dim item As New CLSAlbumsImagesItem()
                    item.ImageId = Convert.ToInt32(reader("IMAGE_ID").ToString())
                    item.Album.AlbumId = Convert.ToInt32(reader("ALBUM_ID").ToString())
                    item.Album.AlbumNo = Convert.ToInt32(reader("ALBUM_NO").ToString())
                    item.Album.LatinName = reader("LATIN_NAME").ToString()
                    item.Album.PersianName = reader("PERSIAN_NAME").ToString()
                    item.ImageAddress = reader("IMAGE_ADDRESS").ToString()
                    item.LatinDes = reader("LATIN_DESCRIPTION").ToString()
                    item.PersianDes = reader("PERSIAN_DESCRIPTION").ToString()
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

    Public Function GetAlbumImage(ByVal ImageId As Integer) As CLSAlbumsImagesItem
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("GET_ALBUMS_IMAGES", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@ImageId", ImageId)
        Dim retField As New CLSAlbumsImagesItem
        Dim reader As SqlDataReader = Nothing
        Try
            cn.Open()
            reader = cmd.ExecuteReader()
            If reader.HasRows Then
                Dim row As Integer = 1
                reader.Read()
                retField.ImageId = Convert.ToInt32(reader("IMAGE_ID").ToString())
                retField.Album.AlbumId = Convert.ToInt32(reader("ALBUM_ID").ToString())
                retField.Album.AlbumNo = Convert.ToInt32(reader("ALBUM_NO").ToString())
                retField.Album.LatinName = reader("PERSIAN_NAME").ToString()
                retField.Album.PersianName = reader("LATIN_NAME").ToString()
                retField.ImageAddress = reader("IMAGE_ADDRESS").ToString()
                retField.LatinDes = reader("LATIN_DESCRIPTION").ToString()
                retField.PersianDes = reader("PERSIAN_DESCRIPTION").ToString()
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

    Public Function InsertAlbumImage(ByVal item As CLSAlbumsImagesItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("INSERT_ALBUMS_IMAGES", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@ALBUM_ID", item.Album.AlbumId)
        cmd.Parameters.AddWithValue("@IMAGE_ADDRESS", item.ImageAddress)
        cmd.Parameters.AddWithValue("@PERSIAN_DESCRIPTION", item.PersianDes)
        cmd.Parameters.AddWithValue("@LATIN_DESCRIPTION", item.LatinDes)
        cmd.Parameters.AddWithValue("@REMARK", item.Remark)
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

    Public Function DeleteAlbumImages(ByVal item As Integer) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("DELETE_ALBUMS_IMAGE", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@ImageId", item)
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

    Public Function UpdateAlbumImages(ByVal item As CLSAlbumsImagesItem) As Boolean
        Dim cn As New SqlConnection(SiteHelper.GetConnectionString)
        Dim cmd As New SqlCommand("UPDATE_ALBUMS_IMAGES", cn) With {.CommandType = CommandType.StoredProcedure}
        cmd.Parameters.AddWithValue("@IMAGE_ID", item.ImageId)
        cmd.Parameters.AddWithValue("@ALBUM_ID", item.Album.AlbumId)
        cmd.Parameters.AddWithValue("@IMAGE_ADDRESS", item.ImageAddress)
        cmd.Parameters.AddWithValue("@PERSIAN_DESCRIPTION", item.PersianDes)
        cmd.Parameters.AddWithValue("@LATIN_DESCRIPTION", item.LatinDes)
        cmd.Parameters.AddWithValue("@REMARK", item.Remark)
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
