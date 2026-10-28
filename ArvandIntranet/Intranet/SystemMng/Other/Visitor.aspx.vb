Imports System.Globalization

Partial Class SystemMng_Visitor
    Inherits AdminBasePage

    Dim VisitorObj As New CLSVisiotors
    Public Property _visitorService As IVisitorService
    Dim ps As New PersianCalendar

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txtToDate.Text = GetDateString(Now)
            txtFromDate.Text = GetDateString(Date.Now.AddMonths(-1))
            BindRecord(txtFromDate.Text, txtToDate.Text)
        End If
    End Sub

    Sub BindRecord(ByVal Sdate As String, ByVal EDate As String)
        gridview1.PageIndex = GridViewPageIndex
        gridview1.DataSource = _visitorService.GetAllVisitorByDivisionId(_securityUser.DivisionId)
        gridview1.DataBind()
    End Sub


    Protected Sub gridview1_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridview1.PageIndexChanging
        GridViewPageIndex = e.NewPageIndex
        BindRecord(txtFromDate.Text, txtToDate.Text)
    End Sub

    Public Property GridViewPageIndex() As Integer
        Get
            If ViewState("PageIndex") Is Nothing Then
                ViewState("PageIndex") = 0
            End If

            Return DirectCast(ViewState("PageIndex"), Integer)
        End Get
        Set(ByVal value As Integer)
            ViewState("PageIndex") = value
        End Set
    End Property


    Function GetDateString(ByVal DateTime As Date) As String
        Dim day As Integer = 0
        Dim Month As Integer = 0
        Dim Year As Integer = 0

        ps = New PersianCalendar()
        Year = ps.GetYear(DateTime)
        Month = ps.GetMonth(DateTime)
        day = ps.GetDayOfMonth(DateTime)

        Dim StringDate As String = ""
        StringDate &= Year.ToString()
        If Month.ToString().Length = 1 Then
            StringDate &= "/0" & Month.ToString()
        Else
            StringDate &= "/" & Month.ToString()
        End If

        If day.ToString().Length = 1 Then
            StringDate &= "/0" & day.ToString()
        Else
            StringDate &= "/" & day.ToString()
        End If
        Return StringDate
    End Function

    Protected Sub btnSearch_Click(sender As Object, e As System.EventArgs) Handles btnSearch.Click
        BindRecord(txtFromDate.Text, txtToDate.Text)
    End Sub


    'Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
    '    If IsValid Then
    '        If ActionGrant("Insert", "1") Then
    '            Dim item As New CLSVisiotorsItem
    '            item.Part_id = txtPart_id.Text
    '            item.Part_type = txtPart_type.Text
    '            item.Remark = txtRemark.Text
    '            item.User_id = txtUser_id.Text
    '            item.User_type = chkAdmin.Checked
    '            item.Visit_browser = txtVisit_browser.Text
    '            item.Visit_computername = txtVisit_computername.Text
    '            item.Visit_date = txtVisit_date.Text.Substring(2)
    '            item.Visit_ip = txtVisit_ip.Text
    '            item.Visit_os = txtVisit_os.Text
    '            item.Visit_time = txtVisi_Time.Text

    '            Dim rowEffect As Boolean = VisitorObj.InsertVISITORS(item)

    '            If (rowEffect) Then
    '                ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('عملیات با موفقیت انجام شد');", True)
    '                gridview1.DataSource = VisitorObj.GetVISITORS()
    '                gridview1.DataBind()
    '                clear()
    '            Else
    '                ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('خطا در ثبت');", True)
    '            End If
    '        End If
    '    End If
    'End Sub

    'Sub clear()
    '    txtPart_id.Text = ""
    '    txtPart_type.Text = ""
    '    txtRemark.Text = ""
    '    txtUser_id.Text = ""
    '    txtVisi_Time.Text = ""
    '    txtVisit_browser.Text = ""
    '    chkAdmin.Checked = False
    '    txtVisit_computername.Text = ""
    '    txtVisit_date.Text = ""
    '    txtVisit_ip.Text = ""
    '    txtVisit_os.Text = ""
    '    VisitId.Value = ""
    '    gridview1.SelectedIndex = -1
    'End Sub

    'Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridview1.RowCommand
    '    clear()
    '    If (e.CommandName = "del") Then
    '        If ActionGrant("Delete", "1") Then
    '            Dim VisitId As Integer = Convert.ToInt32(CLSHash.Decode(e.CommandArgument.ToString))
    '            Dim rowEffect As Integer = VisitorObj.DeleteVISITORS(VisitId)
    '            If (rowEffect) Then
    '                ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('عملیات با موفقیت انجام شد');", True)
    '                gridview1.DataSource = VisitorObj.GetVISITORS()
    '                gridview1.DataBind()
    '            Else
    '                ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('خطا در عملیات');", True)
    '            End If
    '        End If
    '    ElseIf e.CommandName = "up" Then
    '        Dim SelectRowIndx As Integer = DirectCast(DirectCast(e.CommandSource, System.Web.UI.WebControls.ImageButton).DataItemContainer, System.Web.UI.WebControls.GridViewRow).RowIndex
    '        gridview1.SelectedIndex = SelectRowIndx
    '        Dim MyCls As CLSVisiotorsItem = VisitorObj.GetVISITORS(CLSHash.Decode(e.CommandArgument.ToString))
    '        txtPart_id.Text = MyCls.Part_id
    '        txtPart_type.Text = MyCls.Part_type
    '        txtRemark.Text = MyCls.Remark
    '        txtUser_id.Text = MyCls.User_id
    '        txtVisi_Time.Text = MyCls.Visit_time
    '        txtVisit_browser.Text = MyCls.Visit_browser
    '        txtVisit_computername.Text = MyCls.Visit_computername
    '        txtVisit_date.Text = MyCls.Visit_date
    '        txtVisit_ip.Text = MyCls.Visit_ip
    '        txtVisit_os.Text = MyCls.Visit_os
    '        chkAdmin.Checked = MyCls.User_type
    '        VisitId.Value = CLSHash.Encode(MyCls.Visit_id.ToString())
    '    End If
    'End Sub

    'Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
    '    If IsValid And VisitId.Value <> "" Then
    '        If ActionGrant("Update", "1") Then
    '            Dim feild As New CLSVisiotorsItem
    '            feild.Visit_id = CLSHash.Decode(VisitId.Value.ToString())
    '            feild.Part_id = txtPart_id.Text
    '            feild.Part_type = txtPart_type.Text
    '            feild.Remark = txtRemark.Text
    '            feild.User_id = txtUser_id.Text
    '            feild.User_type = chkAdmin.Checked
    '            feild.Visit_browser = txtVisit_browser.Text
    '            feild.Visit_computername = txtVisit_computername.Text
    '            feild.Visit_date = txtVisit_date.Text.Substring(2)
    '            feild.Visit_ip = txtVisit_ip.Text
    '            feild.Visit_os = txtVisit_os.Text
    '            feild.Visit_time = txtVisi_Time.Text
    '            Dim rowEffect As Integer = VisitorObj.UpdateVISITORS(feild)
    '            If (rowEffect) Then
    '                ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('عملیات با موفقیت انجام شد');", True)
    '                gridview1.DataSource = VisitorObj.GetVISITORS()
    '                gridview1.DataBind()
    '                clear()
    '            Else
    '                ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('خطا در عملیات');", True)
    '            End If
    '        End If
    '    Else
    '        ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('لطفا یک آیتم را انتخاب کنید');", True)
    '    End If
    'End Sub

    'Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
    '    clear()
    'End Sub

   
End Class
