
Partial Class _default
    Inherits BasePage

    Protected Overrides Sub OnPreInit(e As EventArgs)
        MyBase.OnPreInit(e)
        'Keep routing, culture, visitor tracking and metadata from BasePage, but
        'do not let the database-selected legacy master/theme replace this layout.
        MasterPageFile = "~/MasterPages/Portal.master"
        Theme = String.Empty
    End Sub

End Class
