
Imports Danesh.ArvandIntranet.DomainClasses.Models

Partial Class SiteMng_Define_ShowHouseCooperative
    Inherits AdminBasePage

    Public Property HouseCooperativeService As IHouseCooperativeService

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            GridViewDataBind()
        End If
    End Sub

    Protected Sub GridViewDataBind()
        radGridView.DataSource = HouseCooperativeService.GetAllHouseCooperatives()
        radGridView.DataBind()
    End Sub

    Protected Sub ExportExcel_Click(sender As Object, e As EventArgs)
        If Not ActionGrant("Print") Then Return
        Dim records As New List(Of String())
        Dim row As Integer = 0
        Dim dates As New DateTimeHelper
        For Each item In HouseCooperativeService.GetAllHouseCooperatives()
            row += 1
            records.Add(New String() {row.ToString(), dates.ConvertToPersianDate(item.RegisterTime), item.FirstName,
                item.LastName, item.FatherName, item.NationalId, GetEmpTypeName(item.EmpType), item.WorkLocation,
                GetCoopertiveTypeName(item.CooperativeLocation), item.MobileNo, item.TelNo, item.PersonNo.ToString()})
        Next
        Dim headers = New String() {"ردیف", "تاریخ درخواست", "نام", "نام خانوادگی", "نام پدر", "کد ملی",
            "نوع استخدام", "محل کار", "محل تعاونی", "شماره همراه", "شماره محل کار", "شماره پرسنلی"}
        Dim bytes = Arvand.Common.PortalWorkbook.Build(headers, records)
        Response.Clear()
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
        Response.AppendHeader("Content-Disposition", PortalDownloadHeaders.Build("HouseList.xlsx", False))
        Response.BinaryWrite(bytes)
        Response.End()
    End Sub

    Public Function GetCoopertiveTypeName(value As Integer) As String
        Select Case value
            Case 1 : Return "جنوب"
            Case 2 : Return "شمال"
            Case Else : Return "نامشخص"
        End Select
    End Function

    Public Function GetEmpTypeName(ByVal empId As Integer) As String
        Select Case empId
            Case 1
                Return "رسمی"
            Case 2
                Return "مدیت معین"
            Case 3
                Return "مدت موقت"
            Case 4
                Return "پیمانی"
            Case 5
                Return "پیمانکار"
            Case Else
                Return "نامشخص"
        End Select
    End Function
End Class
