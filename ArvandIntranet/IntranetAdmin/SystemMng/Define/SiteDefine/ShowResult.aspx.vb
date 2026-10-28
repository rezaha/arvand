Imports Danesh.ArvandIntranet.DomainClasses.ViewModel
Imports DotNet.Highcharts.Options


Partial Class SystemMng_Define_SiteDefine_ShowResult
    Inherits AdminBasePage

    Public Property PollsService As IPollService
    Public Property PlantDivisionsService As IPlantDivisionsService
    Public Property PollsQuestionsService As IPollQuestionsService


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim questionId As Integer = Convert.ToInt32(Request.QueryString("qid"))
            Dim questionItem = PollsQuestionsService.GetOnePollsQuestions(questionId)
            If questionItem.AnswerType <> 3 Then
                PollsQuestionsService.GetQuestionChart(questionId)
                DrawChartFunction(PollsQuestionsService.GetQuestionChart(questionId), questionItem.QuestionDescription)
            Else
                Dim rowCount As Integer = 0
                For Each item In PollsQuestionsService.GetQuestionAnswerText(questionId)
                    rowCount += 1
                    ltrChart.Text &= rowCount & "- " &  item & "<br \\>"
                Next
            End If
            ViewState.Add("QUESTION_ID", questionId)
        End If
    End Sub

    Private Sub DrawChartFunction(ByVal chartItems As List(Of QuestionAnswerChartModel), ByVal questionTitle As String)


        Dim chart As New DrawChart
        chart.Title = questionTitle
        chart.AllowExport = false
        chart.AllowZoom = True
        chart.ChartType = 4
        chart.Width = 800
        chart.Height = 500
        chart.CreateXAxisLable(True, rotation:=-45, formatter:="", staggerLines:=0, stepValue:=1, horizontalAligns:=DotNet.Highcharts.Enums.HorizontalAligns.Right)
        chart.SetYAxis("تعداد", 0)
        chart.SetSubtitle("")

        Dim series As New List(Of PointXY)
        For Each item In chartItems
            series.Add(New PointXY With {.X = item.OptionText, .Y = item.AnswerCount})
        Next
        Dim x As New List(Of String)
        Dim y As New List(Of Decimal)

        For Each sItem In series
            x.Add(sItem.X)
            y.Add(sItem.Y)
        Next
        chart.AddSeries(New Series With {.Name = "نتیجه", .Data = DrawChart.DoubleToPoint(y.ToArray)})
        chart.SetXAxis(x.ToArray, chart.XAxisLable)
        ltrChart.Text = chart.ToHtml
        'For Each radComboItem In drpFields.CheckedItems

        '    If radComboItem.Checked Then
        '        Dim fieldName As String = radComboItem.Text
        '        If fieldName = "EXPORT_TOTAL_WH" Then
        '            series = CountersDataSumDailyCharts.SumDaily15Min_EXPORT_TOTAL_WH(counterId, fromDate, toDate)
        '        ElseIf fieldName = "IMPORT_TOTAL_WH" Then
        '            series = CountersDataSumDailyCharts.SumDaily15Min_IMPORT_TOTAL_WH(counterId, fromDate, toDate)
        '        ElseIf fieldName = "EXPORT_TOTAL_VARH" Then
        '            series = CountersDataSumDailyCharts.SumDaily15Min_EXPORT_TOTAL_VARH(counterId, fromDate, toDate)
        '        ElseIf fieldName = "IMPORT_TOTAL_VARH" Then
        '            series = CountersDataSumDailyCharts.SumDaily15Min_IMPORT_TOTAL_VARH(counterId, fromDate, toDate)
        '        ElseIf fieldName = "CURRENT_ENERGY_EXP_WH" Then
        '            series = CountersDataSumDailyCharts.SumDaily15Min_CURRENT_ENERGY_EXP_WH(counterId, fromDate, toDate)
        '        ElseIf fieldName = "CURRENT_ENERGY_IMP_WH" Then
        '            series = CountersDataSumDailyCharts.SumDaily15Min_CURRENT_ENERGY_IMP_WH(counterId, fromDate, toDate)
        '        ElseIf fieldName = "CURRENT_ENERGY_EXP_VARH" Then
        '            series = CountersDataSumDailyCharts.SumDaily15Min_CURRENT_ENERGY_EXP_VARH(counterId, fromDate, toDate)
        '        ElseIf fieldName = "CURRENT_ENERGY_IMP_VARH" Then
        '            series = CountersDataSumDailyCharts.SumDaily15Min_CURRENT_ENERGY_IMP_VARH(counterId, fromDate, toDate)
        '        ElseIf fieldName = "EXPORT_DEMAND_TOTAL_W" Then
        '            series = CountersDataSumDailyCharts.SumDaily15Min_EXPORT_DEMAND_TOTAL_W(counterId, fromDate, toDate)
        '        ElseIf fieldName = "IMPORT_DEMAND_TOTAL_W" Then
        '            series = CountersDataSumDailyCharts.SumDaily15Min_IMPORT_DEMAND_TOTAL_W(counterId, fromDate, toDate)
        '        ElseIf fieldName = "EXPORT_DEMAND_TOTAL_VAR" Then
        '            series = CountersDataSumDailyCharts.SumDaily15Min_EXPORT_DEMAND_TOTAL_VAR(counterId, fromDate, toDate)
        '        ElseIf fieldName = "IMPORT_DEMAND_TOTAL_VAR" Then
        '            series = CountersDataSumDailyCharts.SumDaily15Min_IMPORT_DEMAND_TOTAL_VAR(counterId, fromDate, toDate)
        '        ElseIf fieldName = "AVG_VOLTAGE_PHA" Then
        '            series = CountersDataSumDailyCharts.SumDaily15Min_AVG_VOLTAGE_PHA(counterId, fromDate, toDate)
        '        ElseIf fieldName = "AVG_VOLTAGE_PHB" Then
        '            series = CountersDataSumDailyCharts.SumDaily15Min_AVG_VOLTAGE_PHB(counterId, fromDate, toDate)
        '        ElseIf fieldName = "AVG_VOLTAGE_PHC" Then
        '            series = CountersDataSumDailyCharts.SumDaily15Min_AVG_VOLTAGE_PHC(counterId, fromDate, toDate)
        '        ElseIf fieldName = "AVG_CURRENT_PHA" Then
        '            series = CountersDataSumDailyCharts.SumDaily15Min_AVG_CURRENT_PHA(counterId, fromDate, toDate)
        '        ElseIf fieldName = "AVG_CURRENT_PHB" Then
        '            series = CountersDataSumDailyCharts.SumDaily15Min_AVG_CURRENT_PHB(counterId, fromDate, toDate)
        '        ElseIf fieldName = "AVG_CURRENT_PHC" Then
        '            series = CountersDataSumDailyCharts.SumDaily15Min_AVG_CURRENT_PHC(counterId, fromDate, toDate)
        '        ElseIf fieldName = "AVG_FREQUENCY" Then
        '            series = CountersDataSumDailyCharts.SumDaily15Min_AVG_FREQUENCY(counterId, fromDate, toDate)
        '        End If



        '    End If
        'Next


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

End Class
