Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports NetNicCapchaPro

Partial Class SecImage
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim c As New Capcha()

        Me.Response.Clear()

        Me.Response.ContentType = "image/jpeg"

        Dim Colorlist As New List(Of Color)()

        Colorlist.Add(Color.White)
        Colorlist.Add(Color.Silver)
        Colorlist.Add(Color.DarkBlue)
        Colorlist.Add(Color.GreenYellow)


        Dim OutChars As String = String.Empty

        OutChars = c.MakePic(120, 40, Color.LightGray, Brushes.Brown, 6, 14, "Arial", FontStyle.Bold, Capcha.OutPutType.NumericAlphabeticLower, Colorlist)

        c.Image.Save(Me.Response.OutputStream, ImageFormat.Jpeg)

        Session.Add("randomStr", OutChars)

        c.Dispose()
    End Sub
End Class
