Imports ArvandIntranetDomainClasses.Models

Partial Class SystemMng_Define_SiteDefine_DefinePolls
    Inherits AdminBasePage

    Public Property PollsService As IPollService
    Public Property PlantDivisionsService As IPlantDivisionsService

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'For Each item In PlantDivisionsService.AllPlantDivision()
            '    drp_PlantDivision.Items.Add(New ListItem With {.Text = item.NamePersian, .Value = CType(item.DivisionId, String)})
            'Next
            GridViewDataBind()
            ClearControls()
            AddSystemHistory("نمایش نظرسنجی", 0)
        End If
    End Sub

    Protected Sub GridViewDataBind()
        gridview1.DataSource = PollsService.AllPolls()
        gridview1.DataBind()
    End Sub

    Protected Sub ClearControls()
        ViewState.Remove("PollId")

        txt_PollName.Text = ""
        chk_Active.Checked = True
    End Sub

    Private Sub ShowMessage(Optional ByVal messageTitle As String = "پیام سیستم", Optional ByVal content As String = "",
    Optional ByVal titleIcon As NotifyIcon = NotifyIcon.none, Optional ByVal contentIcon As NotifyIcon = NotifyIcon.none,
    Optional autoCloseDelay As Integer = 1000)
        NotifyMessage.Text = content
        NotifyMessage.Title = messageTitle
        NotifyMessage.TitleIcon = titleIcon.ToString
        NotifyMessage.ContentIcon = contentIcon.ToString
        NotifyMessage.AutoCloseDelay = autoCloseDelay
        NotifyMessage.Show()
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdd.Click
        Try
            Page.Validate()
            If IsValid Then
                Dim item As New Poll
                item.DivisionId = 0
                item.PollNo = 1
                item.PollName = txt_PollName.Text
                item.PollType = 1
                item.Active = chk_Active.Checked
                item.Remark = ""
                Dim err As New Dictionary(Of String, String)
                Dim result As Integer = PollsService.AddPolls(item, err)
                If result > 0 Then
                    AddSystemHistory("اضافه کردن نظر سنجی", 1)
                    ShowMessage(content:="عملیات اضافه کردن با موفقیت انجام شد", titleIcon:=NotifyIcon.info, contentIcon:=NotifyIcon.ok)
                    GridViewDataBind()
                    ClearControls()
                Else
                    Dim errString As String = err.Aggregate(String.Empty, Function(current, errItem) current & (errItem.Value & "<br />"))
                    ShowMessage(content:="خطا در عملیات.لطفا موارد زیر را اصلاح نمایید:<br />" & errString, titleIcon:=NotifyIcon.info, contentIcon:=NotifyIcon.warning)
                End If
            End If
        Catch ex As Exception
            Elmah.ErrorSignal.FromCurrentContext.Raise(ex)
            ShowMessage(content:="خطا در عملیات.", titleIcon:=NotifyIcon.warning, contentIcon:=NotifyIcon.warning)
        End Try
    End Sub

    Protected Sub btnEdit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        Try
            Page.Validate()
            If IsValid Then
                Dim pkeyPollId As Integer = CType(ViewState("PollId"), Integer)
                Dim item As Poll = PollsService.GetOnePolls(pkeyPollId)
                item.PollName = txt_PollName.Text
                item.DivisionId = 0
                item.Active = chk_Active.Checked
                Dim err As New Dictionary(Of String, String)
                PollsService.EditPolls(item, err)
                If err.Count = 0 Then
                    AddSystemHistory("ویرایش نظر سنجی", 2)
                    ShowMessage(content:="عملیات ویرایش با موفقیت انجام شد", titleIcon:=NotifyIcon.info, contentIcon:=NotifyIcon.ok)
                    GridViewDataBind()
                    ClearControls()
                Else
                    Dim errString As String = err.Aggregate(String.Empty, Function(current, errItem) current & (errItem.Value & "<br />"))
                    ShowMessage(content:="خطا در عملیات.لطفا موارد زیر را اصلاح نمایید:<br />" & errString, titleIcon:=NotifyIcon.info, contentIcon:=NotifyIcon.warning)
                End If
            Else
                ShowMessage(content:="لطفا یک ردیف را انتخاب کنید!", titleIcon:=NotifyIcon.info, contentIcon:=NotifyIcon.warning)
            End If
        Catch ex As Exception
            Elmah.ErrorSignal.FromCurrentContext.Raise(ex)
            ShowMessage(content:="خطا در عملیات.", titleIcon:=NotifyIcon.warning, contentIcon:=NotifyIcon.warning)
        End Try
    End Sub

    Protected Sub btnReload_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnClear.Click
        If IsValid Then
            GridViewDataBind()
            ClearControls()
        End If
    End Sub


    Protected Sub gridview1_ItemCommand(ByVal sender As Object, ByVal e As GridCommandEventArgs) Handles gridview1.ItemCommand
        If e.CommandName = "row-select" Then
            Dim pKeys() As String = e.CommandArgument.ToString().Split(CType("|", Char))
            Dim pkeyPollId As Integer = CType(pKeys(0), Integer)
            Try
                ViewState("PollId") = pKeys(0)
                Dim item As Poll = PollsService.GetOnePolls(pkeyPollId)
                txt_PollName.Text = item.PollName
                chk_Active.Checked = item.Active
            Catch ex As Exception
                Elmah.ErrorSignal.FromCurrentContext.Raise(ex)
                ShowMessage(content:="خطا در عملیات.", titleIcon:=NotifyIcon.warning, contentIcon:=NotifyIcon.warning)
            End Try
        ElseIf e.CommandName = "row-del" Then
            Dim pKeys() As String = e.CommandArgument.ToString().Split(CType("|", Char))
            Dim pkeyPollId As Integer = CType(pKeys(0), Integer)
            Try
                Dim item As Poll = PollsService.GetOnePolls(pkeyPollId)
                Dim err As New Dictionary(Of String, String)
                Dim result As Integer = PollsService.RemovePolls(item, err)
                If result > 0 Then
                    AddSystemHistory("حذف نظر سنجی", 3)
                    ShowMessage(content:="عملیات حذف کردن با موفقیت انجام شد", titleIcon:=NotifyIcon.info, contentIcon:=NotifyIcon.ok)
                    GridViewDataBind()
                    ClearControls()
                Else
                    ShowMessage(content:="به علت وجود رابطه عملیات امکانپذیر نمیباشد.", titleIcon:=NotifyIcon.warning, contentIcon:=NotifyIcon.warning)
                End If
            Catch ex As Exception
                Elmah.ErrorSignal.FromCurrentContext.Raise(ex)
                ShowMessage(content:="به علت وجود رابطه عملیات امکانپذیر نمیباشد.", titleIcon:=NotifyIcon.warning, contentIcon:=NotifyIcon.warning)
            End Try
        End If
    End Sub
End Class
