
Partial Class SystemMng_PopupMasterPage
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.Header.DataBind()
    End Sub

End Class

