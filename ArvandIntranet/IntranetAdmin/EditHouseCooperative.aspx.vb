Imports System.Drawing
Imports System.Globalization
Imports ArvandIntranetDomainClasses.Models

Partial Class EditHouseCooperative
    Inherits BasePage

    Public Property HouseCooperativeService As IHouseCooperativeService

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then

            Dim items2 As Array
            items2 = System.Enum.GetValues(GetType(CooperativeLocation))

            For Each item2 In items2
                drpCooperativeLocation.Items.Add(New ListItem With {.Text = DateTimeHelper.GetEnumDescription(item2), .Value = CType(item2, Int32)})
            Next
        End If
    End Sub

    Protected Sub lnkAccept_Click(sender As Object, e As EventArgs) Handles lnkAccept.Click
        Validate()
        If IsValid Then
            Dim oldItem = HouseCooperativeService.GetOneByNationalId(txtNationalId.Text)
            oldItem.MobileNo = txtMobileNo.Text
            oldItem.TelNo = txtTelNo.Text
            oldItem.CooperativeLocation = drpCooperativeLocation.SelectedValue

            Dim rowEffect As Integer = HouseCooperativeService.EditHouseCooperative(oldItem, New Dictionary(Of String, String))

            If rowEffect > 0 Then
                lblMessage.ForeColor = Color.Green
                lblMessage.Text = "درخواست شما با موفقیت ویرایش شد"
            Else
                lblMessage.ForeColor = Color.Red
                lblMessage.Text = "درخواست تغییری نکرد"
            End If

        End If


    End Sub



    Public Function SetHomePageUrl() As String
        Dim url As String = GetRouteUrl("default-rout", New With {.pageName = "default"})
        Return url
    End Function

    Protected Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim oldItem = HouseCooperativeService.GetOneByNationalId(txtNationalId.Text)
        If oldItem IsNot Nothing Then
            txtMobileNo.Text = oldItem.MobileNo
            txtTelNo.Text = oldItem.TelNo
            drpCooperativeLocation.SelectedValue = oldItem.CooperativeLocation
            lnkAccept.Visible = True
            lblMessage.ForeColor = Color.Green
            lblMessage.Text = "درخواست شما یافت شد. جهت ویرایش درخواست پس از اعمال تغییرات بر روی کلید تایید کلیک کنید. "
        Else
            lblMessage.ForeColor = Color.Red
            lblMessage.Text = "درخواست شما ثبت نشده است. "
        End If
    End Sub

    Protected Sub btnReturn_Click(sender As Object, e As EventArgs) Handles btnReturn.Click
        Response.Redirect("RegisterHouseCooperative")
    End Sub
End Class
