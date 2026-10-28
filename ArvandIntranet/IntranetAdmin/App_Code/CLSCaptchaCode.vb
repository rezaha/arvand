Imports System.Drawing.Text
Imports System.Drawing.Imaging
Imports System.Security.Cryptography
Imports System.Drawing

Public Class CLSCaptchaCode
    Public Function CreateSalt() As String
        Dim rnd As New Random
        Return rnd.Next(10000, 99999)
    End Function


    Public Function CreateImage(ByVal path As String, ByVal height As Integer, ByVal width As Integer) As String
        Dim r As New Random
        Dim salt As String = CreateSalt()
        Dim bmp As New Bitmap(width, height, PixelFormat.Format24bppRgb)
        Dim g As Graphics = Graphics.FromImage(bmp)
        g.TextRenderingHint = TextRenderingHint.AntiAlias
        g.Clear(Color.White)
        Dim mymat As New System.Drawing.Drawing2D.Matrix
        Dim i As Integer
        For i = 0 To Len(salt) - 1
            mymat.Reset()
            mymat.RotateAt(r.Next(-30, 0), New PointF(width * (0.12 * i), height * 0.5))
            g.Transform = mymat
            g.DrawString(salt.Chars(i), New Font("Comic Sans MS", 10, FontStyle.Italic), Brushes.Black, width * (0.12 * i), height * 0.5)
            g.ResetTransform()
        Next
        bmp.Save(path, ImageFormat.Gif)
        g.Dispose()
        bmp.Dispose()
        g.Dispose()
        bmp.Dispose()
        Return salt
    End Function
End Class
