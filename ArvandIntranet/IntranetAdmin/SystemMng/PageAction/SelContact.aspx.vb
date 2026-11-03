Imports System.IO
Imports Danesh.ArvandIntranet.DataLayer.Context

Partial Class SystemMng_Define_SelContact
    Inherits AdminBasePage

    Dim contactObj As New CLSContacts

    Function GetShowStatus(ByVal StInt As Integer) As String

        Select Case StInt
            Case 0
                Return "هر دو زبان"
            Case 1
                Return "بخش فارسی"
            Case 2
                Return "بخش انگلیسی"
            Case Else
                Return "نا مشخص"
        End Select
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            BindRecord()
        End If
    End Sub

    Public Sub BindRecord()
        gridview1.PageIndex = GridViewPageIndex

        Using ctx As New ArvandIntranetContext
            gridview1.DataSource = ctx.CONTACT_US.Where(Function(a) a.CONTACT_TYPE = 2 And Not a.IS_DELETE And a.DIVISION_ID = _securityUser.DivisionId).OrderByDescending(Function(a) a.CONTACT_DATE).ThenByDescending(Function(a) a.CONTACT_TIME).ToList
            gridview1.DataBind()
        End Using
        ChangBkColor()
    End Sub

    Private Sub ChangBkColor()
        For i = 0 To gridview1.Rows.Count - 1
            Dim litIS_READ As Literal = gridview1.Rows(i).FindControl("litIS_READ")
            If litIS_READ.Text = "False" Then
                gridview1.Rows(i).BackColor = Drawing.Color.FromArgb(255, 200, 145)
                gridview1.Rows(i).Font.Italic = True
                gridview1.Rows(i).Font.Bold = True
            End If

        Next
    End Sub

    Protected Sub gridview1_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gridview1.PageIndexChanging
        GridViewPageIndex = e.NewPageIndex
        BindRecord()
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

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gridview1.RowCommand
        If (e.CommandName = "read") Then
            Dim contactId As Integer = Convert.ToInt32(CLSHash.Decode(e.CommandArgument.ToString))
            Dim rowEffect As Integer
            Using ctx As New ArvandIntranetContext
                Dim contactItem = ctx.CONTACT_US.First(Function(a) a.CONTACT_ID = contactId)
                contactItem.IS_READ = Not contactItem.IS_READ
                rowEffect = ctx.SaveChanges()
            End Using
            If (rowEffect) Then
                ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('عملیات با موفقیت انجام شد');", True)
                BindRecord()
            Else
                ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('خطا در عملیات');", True)
            End If

        ElseIf e.CommandName = "del" Then
            If Not ActionGrant("Delete") Then
                Return
            End If
            Dim contactId As Integer = Convert.ToInt32(CLSHash.Decode(e.CommandArgument.ToString))
            Dim rowEffect As Integer
            Using ctx As New ArvandIntranetContext
                Dim contactItem = ctx.CONTACT_US.First(Function(a) a.CONTACT_ID = contactId)
                contactItem.IS_DELETE = Not contactItem.IS_DELETE
                rowEffect = ctx.SaveChanges()
            End Using
            If (rowEffect) Then
                ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('عملیات با موفقیت انجام شد');", True)
                BindRecord()
            Else
                ScriptManager.RegisterClientScriptBlock(Me, GetType(String), "Error", "alert('خطا در عملیات');", True)
            End If

        End If
    End Sub
End Class
