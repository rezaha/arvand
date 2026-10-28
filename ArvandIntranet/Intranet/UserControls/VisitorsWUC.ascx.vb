Imports System.Globalization

Partial Class UserControls_VisitorsWUC
    Inherits BaseUserControl

    Dim ps As System.Globalization.PersianCalendar
    Dim VisitorObj As New CLSVisiotors
    Public Sub SetStatistic()

        Dim StartDate As Date = Nothing
        Dim EndDate As Date = Nothing

        StartDate = Date.Now
        EndDate = Date.Now

        todayCount1.InnerText = VisitorObj.GetVisitorCount(GetDateString(StartDate), GetDateString(EndDate), "fa").ToString()
        todayCount2.InnerText = todayCount1.InnerText

        StartDate = Date.Now.AddDays(-1)
        EndDate = Date.Now.AddDays(-1)

        yesterdayCount.InnerText = VisitorObj.GetVisitorCount(GetDateString(StartDate), GetDateString(EndDate), "fa").ToString()

        Dim WeekDay As Integer = ps.GetDayOfWeek(Date.Now)
        Select Case WeekDay
            Case 0
                WeekDay = 1
            Case 1
                WeekDay = 2
            Case 2
                WeekDay = 3
            Case 3
                WeekDay = 4
            Case 4
                WeekDay = 5
            Case 5
                WeekDay = 6
            Case 6
                WeekDay = 0
        End Select

        StartDate = Date.Now.AddDays(-1 * WeekDay)
        EndDate = Date.Now
        CurrentWeekCount.InnerText = VisitorObj.GetVisitorCount(GetDateString(StartDate), GetDateString(EndDate), "fa").ToString()

        StartDate = Date.Now.AddDays(-1 * (WeekDay + 7))
        EndDate = Date.Now.AddDays(-1 * WeekDay)
        PastWeekCount.InnerText = VisitorObj.GetVisitorCount(GetDateString(StartDate), GetDateString(EndDate), "fa").ToString()

        Dim DayOfMonth = ps.GetDayOfMonth(Date.Now)
        StartDate = Date.Now.AddDays(-1 * (DayOfMonth - 1))
        EndDate = Date.Now
        CurrentMonthCount.InnerText = VisitorObj.GetVisitorCount(GetDateString(StartDate), GetDateString(EndDate), "fa").ToString()

        StartDate = Date.Now.AddDays(-1 * (DayOfMonth - 1 + ps.GetDaysInMonth(ps.GetYear(Date.Now), ps.GetMonth(Date.Now))))
        EndDate = Date.Now.AddDays(-1 * (DayOfMonth))
        PastMonthCount.InnerText = VisitorObj.GetVisitorCount(GetDateString(StartDate), GetDateString(EndDate), "fa").ToString()

        'EndDate = Date.Now
        'lblTotal.Text = VisitorObj.GetVisitorCount("00/00/00", GetDateString(EndDate), "/default.aspx")
    End Sub

    Function GetDateString(ByVal DateTime As Date) As String
        Dim day As Integer = 0
        Dim Month As Integer = 0
        Dim Year As Integer = 0

        ps = New PersianCalendar()
        Year = ps.GetYear(DateTime)
        Month = ps.GetMonth(DateTime)
        day = ps.GetDayOfMonth(DateTime)

        Dim StringDate As String = ""
        StringDate &= Year.ToString().Substring(2)
        If Month.ToString().Length = 1 Then
            StringDate &= "/0" & Month.ToString()
        Else
            StringDate &= "/" & Month.ToString()
        End If

        If day.ToString().Length = 1 Then
            StringDate &= "/0" & day.ToString()
        Else
            StringDate &= "/" & day.ToString()
        End If
        Return StringDate
    End Function

End Class
