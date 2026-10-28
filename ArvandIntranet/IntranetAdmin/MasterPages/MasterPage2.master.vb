
Partial Class MasterPages_MasterPage2
    Inherits BaseMasterPage

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Page.Header.DataBind()
    End Sub
End Class

