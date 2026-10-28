
Imports ArvandIntranetDomainClasses.Models

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
End Class
