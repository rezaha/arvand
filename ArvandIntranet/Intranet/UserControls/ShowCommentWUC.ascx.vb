
Partial Class UserControls_ShowCommentWUC
    Inherits BaseUserControl

    Dim OpinionObj As New CLSOpinions

    'Protected Sub Page_Load1(sender As Object, e As EventArgs) Handles Me.Load
    '    Reload()
    'End Sub

    Protected Function OpnionDate(ByVal OpinionDate As String) As String
        If SiteLanguage = "fa" Then
            Dim dateTimeHelper As New DateTimeHelper
            Return dateTimeHelper.LongPersianDate("13" & OpinionDate, PersianDateTimeFormat.DayOfWeekName_Day_MonthName_Year)
        ElseIf SiteLanguage = "en" Then
            Dim dateTimeHelper As New DateTimeHelper
            Return dateTimeHelper.LongLatinDate("13" & OpinionDate, LatinDateTimeFormat.Day_MonthName_Year)
        End If
        Return ""
    End Function

    Public Sub Reload()
        Dim newsId As Integer = Page.RouteData.Values("id").ToString
        Dim list As List(Of CLSOpinionsItem) = OpinionObj.GetOpinions("NEWS", newsId)
        If SiteLanguage.ToLower = "en" Then
            lblCommentCount.InnerText = list.Count & " Comment"
        Else
            lblCommentCount.InnerText = list.Count & " دیدگاه"
        End If
            Repeater1.DataSource = list
            Repeater1.DataBind()
    End Sub

End Class