
Partial Class SecurityFormsGranted
    Inherits AdminBasePage

    Public Property _securityFormsService As ISecurityFormsService


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Not IsPostBack Then
                AddSystemHistory("نمایش دسترسی ها", 0)
                If _securityUser.DivisionId <> 0 Or _securityUser.UserAdmin = False Then
                    ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('شما اجازه دسترسی به این بخش را ندارید');", True)
                    Response.RedirectToRoute("management", New With {.pageName = "Welcome"})
                Else
                    If _securityUser.DivisionId <> 0 Then
                        For Each b In _securityUserService.GetAllSecurityUser().Where(Function(a) a.UserAdmin = False And a.DivisionId = _securityUser.DivisionId)
                            drpSecurityUser.Items.Add(New ListItem With {.Text = b.FirstName & " " & b.LastName & " - " & b.UserName, .Value = b.UserId})
                        Next
                        BindRecords()
                    Else
                        For Each b In _securityUserService.GetAllSecurityUser().Where(Function(a) a.UserAdmin = False)
                            drpSecurityUser.Items.Add(New ListItem With {.Text = b.FirstName & " " & b.LastName & " - " & b.UserName, .Value = b.UserId})
                        Next
                        BindRecords()
                    End If
                End If
            End If
        End If
    End Sub

    Sub BindRecords()
        gridview1.DataSource = _securityFormsService.AllSecurityForms()
        gridview1.DataBind()

        If drpSecurityUser.SelectedIndex > 0 Then
            For Each row As GridViewRow In gridview1.Rows
                Dim lblFormPer As Label = row.FindControl("lbl_GRANT_ID")
                Dim SecFormGrant = _securityFormsGrantedService.GetOneSecurityFormsGranted(Int32.Parse(drpSecurityUser.SelectedValue), Int32.Parse(lblFormPer.Text))
                If SecFormGrant IsNot Nothing Then

                    Dim chk_Show_RECORD As CheckBox = row.FindControl("chk_SHOW_FORM")
                    chk_Show_RECORD.Checked = True

                    Dim chk_INSERT_RECORD As CheckBox = row.FindControl("chk_INSERT_RECORD")
                    chk_INSERT_RECORD.Checked = SecFormGrant.InsertRecord


                    Dim chk_UPDATE_RECORD As CheckBox = row.FindControl("chk_UPDATE_RECORD")
                    chk_UPDATE_RECORD.Checked = SecFormGrant.UpdateRecord


                    Dim chk_DELETE_RECORD As CheckBox = row.FindControl("chk_DELETE_RECORD")
                    chk_DELETE_RECORD.Checked = SecFormGrant.DeleteRecord


                    Dim chk_SEARCH_RECORD As CheckBox = row.FindControl("chk_SEARCH_RECORD")
                    chk_SEARCH_RECORD.Checked = SecFormGrant.SearchRecord


                    Dim chk_PRINT_RECORD As CheckBox = row.FindControl("chk_PRINT_RECORD")
                    chk_PRINT_RECORD.Checked = SecFormGrant.PrintRecord

                    Dim chk_Approve_RECORD As CheckBox = row.FindControl("chk_APPROVE")
                    chk_Approve_RECORD.Checked = SecFormGrant.ApproveAction

                    Dim chk_ETC_ACTION As CheckBox = row.FindControl("chk_ETC_ACTION")
                    chk_ETC_ACTION.Checked = SecFormGrant.EtcAction
                End If
            Next
        End If

    End Sub



    Protected Sub drpSecurityUser_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles drpSecurityUser.SelectedIndexChanged
        BindRecords()
    End Sub

    Protected Sub btnSave_Click(sender As Object, e As System.EventArgs) Handles btnSave.Click
        Dim RowEffect As Integer = 0
        For Each row As GridViewRow In gridview1.Rows
            Dim lblFormPer As Label = row.FindControl("lbl_GRANT_ID")
            Dim chk_Show_RECORD As CheckBox = row.FindControl("chk_SHOW_FORM")
            Dim chk_INSERT_RECORD As CheckBox = row.FindControl("chk_INSERT_RECORD")
            Dim chk_UPDATE_RECORD As CheckBox = row.FindControl("chk_UPDATE_RECORD")
            Dim chk_DELETE_RECORD As CheckBox = row.FindControl("chk_DELETE_RECORD")
            Dim chk_SEARCH_RECORD As CheckBox = row.FindControl("chk_SEARCH_RECORD")
            Dim chk_PRINT_RECORD As CheckBox = row.FindControl("chk_PRINT_RECORD")
            Dim chk_Approve_RECORD As CheckBox = row.FindControl("chk_APPROVE")
            Dim chk_ETC_ACTION As CheckBox = row.FindControl("chk_ETC_ACTION")
            Dim SecFormGrant = _securityFormsGrantedService.GetOneSecurityFormsGranted(Integer.Parse(drpSecurityUser.SelectedValue), Integer.Parse(lblFormPer.Text))
            If SecFormGrant IsNot Nothing Then
                If chk_Show_RECORD.Checked = True Then
                    SecFormGrant.UserId = drpSecurityUser.SelectedValue
                    SecFormGrant.FormPermission = lblFormPer.Text
                    SecFormGrant.InsertRecord = False
                    If chk_INSERT_RECORD.Checked Then
                        SecFormGrant.InsertRecord = True
                    End If
                    SecFormGrant.DeleteRecord = False
                    If chk_DELETE_RECORD.Checked Then
                        SecFormGrant.DeleteRecord = True
                    End If
                    SecFormGrant.UpdateRecord = False
                    If chk_UPDATE_RECORD.Checked Then
                        SecFormGrant.UpdateRecord = True
                    End If
                    SecFormGrant.SearchRecord = False
                    If chk_SEARCH_RECORD.Checked Then
                        SecFormGrant.SearchRecord = True
                    End If
                    SecFormGrant.PrintRecord = False
                    If chk_PRINT_RECORD.Checked Then
                        SecFormGrant.PrintRecord = True
                    End If
                    SecFormGrant.ApproveAction = False
                    If chk_Approve_RECORD.Checked Then
                        SecFormGrant.ApproveAction = True
                    End If
                    SecFormGrant.EtcAction = False
                    If chk_ETC_ACTION.Checked Then
                        SecFormGrant.EtcAction = True
                    End If
                    _securityFormsGrantedService.EditSecurityFormsGranted(SecFormGrant, New Dictionary(Of String, String))
                Else
                    _securityFormsGrantedService.RemoveSecurityFormsGranted(SecFormGrant, New Dictionary(Of String, String))
                End If
            Else
                If chk_Show_RECORD.Checked = True Then
                    Dim feild As New Danesh.ArvandIntranet.DomainClasses.Models.SecurityFormsGranted
                    feild.UserId = drpSecurityUser.SelectedValue
                    feild.FormPermission = lblFormPer.Text
                    feild.InsertRecord = False
                    If chk_INSERT_RECORD.Checked Then
                        feild.InsertRecord = True
                    End If
                    feild.DeleteRecord = False
                    If chk_DELETE_RECORD.Checked Then
                        feild.DeleteRecord = True
                    End If
                    feild.UpdateRecord = False
                    If chk_UPDATE_RECORD.Checked Then
                        feild.UpdateRecord = True
                    End If
                    feild.SearchRecord = False
                    If chk_SEARCH_RECORD.Checked Then
                        feild.SearchRecord = True
                    End If
                    feild.PrintRecord = False
                    If chk_PRINT_RECORD.Checked Then
                        feild.PrintRecord = True
                    End If
                    feild.ApproveAction = False
                    If chk_Approve_RECORD.Checked Then
                        feild.ApproveAction = True
                    End If
                    feild.EtcAction = False
                    If chk_ETC_ACTION.Checked Then
                        feild.EtcAction = True
                    End If

                    RowEffect += _securityFormsGrantedService.AddSecurityFormsGranted(feild, New Dictionary(Of String, String))
                Else
                    '''''''''''''''''''''''''''''''''''''
                End If
            End If
        Next
        AddSystemHistory("ویرایش دسترسی ها", 2)
        ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('عملیات به روز رسانی مجوز ها با موفقیت انجام شد...');", True)
        BindRecords()
    End Sub
End Class
