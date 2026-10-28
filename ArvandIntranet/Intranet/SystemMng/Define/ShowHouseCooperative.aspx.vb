
Imports System.Drawing
Imports System.IO
Imports System.Net.Mime
Imports System.Reflection
Imports ArvandIntranetDomainClasses.Models
Imports Microsoft.Office.Interop.Excel
Imports OfficeOpenXml
Imports OfficeOpenXml.Style

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

    Public Function GetCoopertiveTypeName(ByVal coopertiveTypeId As Integer) As String
        Select Case coopertiveTypeId
            Case 1
                Return "جنوب"
            Case 2
                Return "شمال"
            Case Else
                Return "نامشخص"
        End Select
    End Function

    Protected Sub RadGrid1_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles radGridView.ItemCommand
        If e.CommandName = RadGrid.ExportToExcelCommandName Then

            Dim contactList = HouseCooperativeService.GetAllHouseCooperatives()

            Dim newFile As New FileInfo(HttpRuntime.AppDomainAppPath & "\App_Data\HouseList.xlsx")
            If newFile.Exists Then
                newFile.Delete() ' ensures we create a new workbook
                newFile = New FileInfo(HttpRuntime.AppDomainAppPath & "\App_Data\HouseList.xlsx")
            End If
            Using package As New ExcelPackage(newFile)
                Dim worksheet As ExcelWorksheet = package.Workbook.Worksheets.Add("درخواست های تعاونی مسکن")


                worksheet.Cells(1, 1).Value = "ردیف"
                worksheet.Cells(1, 2).Value = "تاریخ درخواست"
                worksheet.Cells(1, 3).Value = "نام"
                worksheet.Cells(1, 4).Value = "نام خانوادگی"
                worksheet.Cells(1, 5).Value = "نام پدر"
                worksheet.Cells(1, 6).Value = "کد ملی"
                worksheet.Cells(1, 7).Value = "نوع استخدام"
                worksheet.Cells(1, 8).Value = "محل کار"
                worksheet.Cells(1, 9).Value = "محل مورد تقاضای مسکن "
                worksheet.Cells(1, 10).Value = "شماره همراه"
                worksheet.Cells(1, 11).Value = "شماره محل کار"
                worksheet.Cells(1, 12).Value = "شماره پرسنلی"

                Dim row As Integer = 0
                For Each item As HouseCooperative In contactList
                    row += 1
                    worksheet.Cells(row + 1, 1).Value = row
                    worksheet.Cells(row + 1, 2).Value = GetPersianDate(item.RegisterTime)
                    worksheet.Cells(row + 1, 3).Value = item.FirstName
                    worksheet.Cells(row + 1, 4).Value = item.LastName
                    worksheet.Cells(row + 1, 5).Value = item.FatherName
                    worksheet.Cells(row + 1, 6).Value = item.NationalId
                    worksheet.Cells(row + 1, 7).Value = GetEmpTypeName(item.EmpType)
                    worksheet.Cells(row + 1, 8).Value = item.WorkLocation
                    worksheet.Cells(row + 1, 9).Value = GetCoopertiveTypeName(item.CooperativeLocation)
                    worksheet.Cells(row + 1, 10).Value = item.MobileNo
                    worksheet.Cells(row + 1, 11).Value = item.TelNo
                    worksheet.Cells(row + 1, 12).Value = item.PersonNo
                Next



                Using range = worksheet.Cells(1, 1, contactList.Count + 1, 10)
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid
                    range.Style.Fill.BackgroundColor.SetColor(Color.White)
                    range.Style.Font.Color.SetColor(Color.Black)
                    range.Style.Font.Name = "B Titr"
                    range.Style.Font.Size = 10
                    range.Style.VerticalAlignment = ExcelVerticalAlignment.Center
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center
                End Using


                ' Setting some document properties
                package.Workbook.Properties.Title = "لیست درخواست تعاونی مسکن "
                package.Workbook.Properties.Author = "پتروشیمی اروند"
                package.Workbook.Properties.Comments = "گزارش لیست درخواست تعاونی مسکن"
                ' set some extended property values
                package.Workbook.Properties.Company = "دانش افزار ماهان"
                ' set some custom property values
                package.Workbook.Properties.SetCustomPropertyValue("تولید شده توسط", "پتروشیمی اروند")
                ' save our new workbook and we are done!
                package.Save()


            End Using

            DownloadFile(HttpRuntime.AppDomainAppPath & "\App_Data\HouseList.xlsx", "HouseList")
        End If
    End Sub


    Public Sub DownloadFile(ByVal fileAddress As String, ByVal downloadFileName As String)
        Dim bytes As Byte() = File.ReadAllBytes(fileAddress)
        Dim contentType As String = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
        Response.ClearContent()
        Response.ClearHeaders()
        Response.ContentType = contentType
        Response.AddHeader("Content-Length", bytes.Length)
        Response.AddHeader("Content-Disposition", "attachment; filename=" & downloadFileName & "." & "xlsx")
        Response.TransmitFile(fileAddress)
        Response.End()
    End Sub

    Public Function GetPersianDate(ByVal enDate As DateTime) As String
        Dim dtHelper As New DateTimeHelper
        Return dtHelper.ConvertToPersianDate(enDate)
    End Function
End Class
