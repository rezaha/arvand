Imports System.Drawing.Imaging
Imports Microsoft.VisualBasic

Public Class CLSImageResize

    Public Function Resize(ByVal fileName As String, ByVal height As Integer, ByVal width As Integer) As String
        Try
            Dim filePath As String = HttpContext.Current.Server.MapPath("~/")
            Dim imageUrl As String = fileName
            Dim imageHeight As Integer = Convert.ToInt32(50)
            Dim imageWidth As Integer = Convert.ToInt32(50)
            If imageUrl.IndexOf("/") >= 0 OrElse imageUrl.IndexOf("\") >= 0 Then
                Return ""
            End If
            imageUrl = "pics/" & imageUrl

            Dim fullSizeImg As System.Drawing.Image = System.Drawing.Image.FromFile(filePath & imageUrl)
            'Server.MapPath(imageUrl)
            Dim dummyCallBack As New System.Drawing.Image.GetThumbnailImageAbort(AddressOf ThumbnailCallback)
            Dim thumbNailImg As System.Drawing.Image = fullSizeImg.GetThumbnailImage(imageWidth, imageHeight, dummyCallBack, IntPtr.Zero)
            Dim MyDate As Date = Date.Now
            Dim MyString As String = MyDate.ToString("ddMMyyhhmmss") & ".png"
            thumbNailImg.Save(filePath & "pics\" & MyString, ImageFormat.Png)
            thumbNailImg.Dispose()

        Catch ex As Exception
        End Try

        Return ""
    End Function

    Public Function ThumbnailCallback() As Boolean
        Return False
    End Function

    'Public Function Resize(ByVal ThisImage As Image, ByVal height As Integer, ByVal width As Integer) As Image
    '    Try
    '        Dim filePath As String = HttpContext.Current.Server.MapPath("~/")
    '        Dim imageUrl As String = fileName
    '        Dim imageHeight As Integer = Convert.ToInt32(50)
    '        Dim imageWidth As Integer = Convert.ToInt32(50)
    '        If imageUrl.IndexOf("/") >= 0 OrElse imageUrl.IndexOf("\") >= 0 Then
    '            Exit Function
    '        End If
    '        imageUrl = "pics/" & imageUrl

    '        Dim fullSizeImg As System.Drawing.Image = System.Drawing.Image.FromFile(filePath & imageUrl)
    '        'Server.MapPath(imageUrl)
    '        Dim dummyCallBack As New System.Drawing.Image.GetThumbnailImageAbort(AddressOf ThumbnailCallback)
    '        Dim thumbNailImg As System.Drawing.Image = fullSizeImg.GetThumbnailImage(imageWidth, imageHeight, dummyCallBack, IntPtr.Zero)
    '        Dim MyDate As Date = Date.Now
    '        Dim MyString As String = MyDate.ToString("ddMMyyhhmmss") & ".png"
    '        thumbNailImg.Save(filePath & "pics\" & MyString, ImageFormat.Png)
    '        thumbNailImg.Dispose()

    '    Catch ex As Exception

    '    End Try

    'End Function


End Class
