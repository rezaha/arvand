Imports System.Drawing
Imports System.Globalization
Imports ArvandIntranetDomainClasses.Models

Partial Class RegisterHouseCooperative
    Inherits BasePage

    Public Property HouseCooperativeService As IHouseCooperativeService

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim items As Array
            items = System.Enum.GetValues(GetType(EmployType))

            For Each item In items
                drpEmpType.Items.Add(New ListItem With {.Text = DateTimeHelper.GetEnumDescription(item), .Value = CType(item, Int32)})
            Next

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
            If oldItem IsNot Nothing Then
                lblMessage.ForeColor = Color.Red
                lblMessage.Text = "درخواست شما قبلا ثبت شده است. "
                Return
            End If

            Dim item As New HouseCooperative
            item.NationalId = txtNationalId.Text
            item.EmpType = drpEmpType.SelectedValue
            item.CooperativeLocation = drpCooperativeLocation.SelectedValue
            item.FirstName = txtFirstName.Text
            item.LastName = txtlastName.Text
            item.RegisterTime = DateTime.Now
            item.FatherName = txtFatherName.Text
            item.PersonNo = txtPersonNo.Text
            item.WorkLocation = txtWorkLocation.Text
            item.TelNo = txtTelNo.Text
            item.MobileNo = txtMobileNo.Text

            Dim rowEffect As Integer = HouseCooperativeService.AddHouseCooperative(item, New Dictionary(Of String, String))

            If rowEffect > 0 Then
                lblMessage.ForeColor = Color.Green
                lblMessage.Text = "درخواست شما با موفقیت ثبت شد"
                Cleare()
            End If
        End If


    End Sub

    Sub BindLists()
        txtNationalId.Text = ""
        txtFatherName.Text = ""
        txtFirstName.Text = ""
        txtPersonNo.Text = ""
        txtMobileNo.Text = ""
        txtTelNo.Text = ""
        txtWorkLocation.Text = ""
        txtlastName.Text = ""
        drpEmpType.SelectedIndex = 0
        drpCooperativeLocation.SelectedIndex = 0
    End Sub

    Public Function SetHomePageUrl() As String
        Dim url As String = GetRouteUrl("default-rout", New With {.pageName = "default"})
        Return url
    End Function


    Protected Sub lnkCleare_Click(sender As Object, e As EventArgs) Handles lnkCleare.Click
        Cleare()
    End Sub

    Sub Cleare()
        BindLists()
    End Sub

    Protected Sub lnkEdit_Click(sender As Object, e As EventArgs) Handles lnkEdit.Click
        Response.Redirect("EditHouseCooperative")
    End Sub
End Class
