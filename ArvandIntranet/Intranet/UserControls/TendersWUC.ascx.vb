
Partial Class UserControls_TendersWUC
    Inherits BaseUserControl

    Dim TenderObj As New CLSTenders

    'Public Sub SetTenders()

    '    lblText.Text = " <table cellpadding=""0"" cellspacing=""0"" class=""Tender""> "
    '    lblText.Text &= " <tr class=""tender_header""> "
    '    lblText.Text &= " <td class=""tender_title_name""> <img src=""../images/tender/tender_title.png"" /> <span class=""tender_title"">عنوان</span> </td> "
    '    lblText.Text &= " <td> <img src=""../images/tender/tender_date.png""/> <span class=""tender_title"">مهلت دریافت سند</span> </td> "
    '    lblText.Text &= " <td> <img src=""../images/tender/tender_type.png""/> <span class=""tender_title"">نوع</span> </td> </tr> "

    '    For Each item In TenderObj.GetTENDERS(TopCount:=4)
    '        lblText.Text &= " <tr> "
    '        lblText.Text &= "<td><a href=""TenderDetails?TendID=" & item.Tender_id & """ target=""_blank""> " & item.Tender_title & " </a> </td>"
    '        lblText.Text &= "<td style=""text-align:center"">" & item.Sell_to_date & "</td>"
    '        lblText.Text &= "<td>" & item.Tender_type.TypeName & "</td>"
    '        lblText.Text &= "</tr>"
    '    Next

    '    lblText.Text &= " </table>"
    'End Sub


    Public Function SetTenderTitle(ByVal DataItem As CLSTendersItem) As String
        Return DataItem.Tender_title
    End Function

    Public Function SetTenderDateTime(ByVal DataItem As CLSTendersItem) As String
        Return DataItem.Sell_to_date
    End Function

    Public Function SetTenderURL(ByVal DataItem As CLSTendersItem) As String
        Dim url As String = String.Empty
        If SiteLanguage = "fa" Then
            url = GetRouteUrl("default-rout", New With {.pageName = "TenderDetails", .id = DataItem.Tender_id}) & "/" & Server.HtmlDecode(DataItem.Tender_title.Trim.ToFriendlyUrl())
        ElseIf SiteLanguage = "en" Then
            url = GetRouteUrl("default-rout", New With {.pageName = "TenderDetails", .id = DataItem.Tender_id}) & "/" & Server.HtmlDecode(DataItem.Tender_title.Trim.ToFriendlyUrl())
        End If
        Return url
    End Function

    Public Function SetTenderType(ByVal DataItem As CLSTendersItem) As String
        Return DataItem.Tender_type.TypeName
    End Function

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Repeater1.DataSource = TenderObj.GetTENDERS(TopCount:=4)
        Repeater1.DataBind()
    End Sub

End Class
