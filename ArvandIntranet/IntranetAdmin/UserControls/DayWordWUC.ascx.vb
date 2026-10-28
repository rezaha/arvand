
Partial Class UserControls_DayWordWUC
    Inherits BaseUserControl
    Dim ObjNews As New CLSNews

    Public Sub SetDayWord()
        Dim TopDayWord = ObjNews.GetDayWord(PlantDivisions.DivisionId)
        If TopDayWord.Count > 0 Then
            If SiteLanguage.ToLower = "en" Then
                lblDayWordTitle.Text = TopDayWord(0).Title_latin
                lblDayWordText.Text = TopDayWord(0).Html_content_latin
            Else
                lblDayWordTitle.Text = TopDayWord(0).Title_persian
                lblDayWordText.Text = TopDayWord(0).Html_content_persian
            End If
        End If
    End Sub
End Class
