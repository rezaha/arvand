
Partial Class UserControls_AnnouncementsWUC
    Inherits BaseUserControl


    Public Sub ShowAnnouncements()
        AnnouncementsContentWUC.ShowAnnouncements(0, 3, "NewsDate DESC")
    End Sub

End Class
