Imports System.Globalization
Imports Microsoft.VisualBasic

Public Class CLSShamsiDate
    Shared fary, farm, fard, fardw As String
    Shared far30 As New System.Globalization.PersianCalendar



    Public Shared Function LongDate(ByVal InputDate As Date) As String


        fary = far30.GetYear(InputDate)
        'fary = Right(fary, 2)
        farm = far30.GetMonth(InputDate)
        fard = far30.GetDayOfMonth(InputDate)
        fardw = far30.GetDayOfWeek(InputDate)

        If farm = "1" Then
            farm = "فروردین"
        End If
        If farm = "2" Then
            farm = "اردیبهشت"
        End If
        If farm = "3" Then
            farm = "خرداد"
        End If
        If farm = "4" Then
            farm = "تیر"
        End If
        If farm = "5" Then
            farm = "مرداد"
        End If
        If farm = "6" Then
            farm = "شهریور"
        End If
        If farm = "7" Then
            farm = "مهر"
        End If
        If farm = "8" Then
            farm = "آبان"
        End If
        If farm = "9" Then
            farm = "آذر"
        End If
        If farm = "10" Then
            farm = "دی"
        End If
        If farm = "11" Then
            farm = "بهمن"
        End If
        If farm = "12" Then
            farm = "اسفند"
        End If

        '-----
        If fardw = "6" Then
            fardw = "شنبه"
        End If
        If fardw = "0" Then
            fardw = "یکشنبه"
        End If
        If fardw = "1" Then
            fardw = "دوشنبه"
        End If
        If fardw = "2" Then
            fardw = "سه شنبه"
        End If
        If fardw = "3" Then
            fardw = "چهارشنبه"
        End If
        If fardw = "4" Then
            fardw = "پنج شنبه"
        End If
        If fardw = "5" Then
            fardw = "جمعه"
        End If
        Dim strRet As String = fardw + " , " + fard + " " + farm + " " + fary
        Return strRet

    End Function

    Public Shared Function GetDayWeekIndex(ByVal InputDate As Date) As Integer

        Select Case far30.GetDayOfWeek(InputDate)
            Case 6
                Return 1
            Case 7
                Return 2
            Case 1
                Return 3
            Case 2
                Return 4
            Case 3
                Return 5
            Case 4
                Return 6
            Case 5
                Return 7
        End Select

    End Function

    Public Shared Function GetDateNextSunday(ByVal InputDate As Date) As String

        Dim ExDay As Short
        ExDay = (7 - GetDayWeekIndex(InputDate)) + 1
        Return ShortDate(InputDate.AddDays(ExDay))

    End Function

    Public Shared Function ShortDate(ByVal InputDate As Date) As String
        fary = far30.GetYear(InputDate)
        'fary = Right(fary, 2)
        farm = IIf(far30.GetMonth(InputDate) < 10, "0" & far30.GetMonth(InputDate), far30.GetMonth(InputDate))
        fard = IIf(far30.GetDayOfMonth(InputDate) < 10, "0" & far30.GetDayOfMonth(InputDate), far30.GetDayOfMonth(InputDate))
        'far30.GetDayOfMonth(InputDate)
        fardw = far30.GetDayOfWeek(InputDate)
        Dim str As String = fary + "/" + farm + "/" + fard
        Return str
    End Function

    Public Shared Function MonthName(ByVal PersianDate As String) As String
        Dim CurMonth = PersianDate.Substring(5, 2)
        If CurMonth = 1 Then
            Return "فروردین"
        End If
        If CurMonth = 2 Then
            Return "اردیبهشت"
        End If
        If CurMonth = 3 Then
            Return "خرداد"
        End If
        If CurMonth = 4 Then
            Return "تیر"
        End If
        If CurMonth = 5 Then
            Return "مرداد"
        End If
        If CurMonth = 6 Then
            Return "شهریور"
        End If
        If CurMonth = 7 Then
            Return "مهر"
        End If
        If CurMonth = 8 Then
            Return "آبان"
        End If
        If CurMonth = 9 Then
            Return "آذر"
        End If
        If CurMonth = 10 Then
            Return "دی"
        End If
        If CurMonth = 11 Then
            Return "بهمن"
        End If
        If CurMonth = 12 Then
            Return "اسفند"
        End If
    End Function

    'Public Shared Function EndOfNextWeek(ByVal LatinDate As String) As String
    '    Dim DayOfWeekNumber As String = far30.GetDayOfWeek(LatinDate)
    '    If DayOfWeekNumber = 6 Then
    '        Return CLSDesignDate.FindNextWeek(LatinDate, 13)
    '    ElseIf DayOfWeekNumber = 0 Then
    '        Return CLSDesignDate.FindNextWeek(LatinDate, 12)
    '    ElseIf DayOfWeekNumber = 1 Then
    '        Return CLSDesignDate.FindNextWeek(LatinDate, 11)
    '    ElseIf DayOfWeekNumber = 2 Then
    '        Return CLSDesignDate.FindNextWeek(LatinDate, 10)
    '    ElseIf DayOfWeekNumber = 3 Then
    '        Return CLSDesignDate.FindNextWeek(LatinDate, 9)
    '    ElseIf DayOfWeekNumber = 4 Then
    '        Return CLSDesignDate.FindNextWeek(LatinDate, 8)
    '    ElseIf DayOfWeekNumber = 5 Then
    '        Return CLSDesignDate.FindNextWeek(LatinDate, 7)
    '    End If

    'End Function
    Public Shared Function LastDayOfMonth(ByVal InputDate As Date) As String
        Dim CurDate As String = ShortDate(InputDate)
        Dim CurYear = CurDate.Substring(0, 4)
        Dim CurMonth = CurDate.Substring(5, 2)
        Dim CurDay = CurDate.Substring(8, 2)
        If CurMonth < "07" Then
            CurDay = "31"
        ElseIf CurMonth > "06" And CurMonth < "12" Then
            CurDay = "30"
        ElseIf CurMonth = "12" Then
            If CurYear = "1391" Or CurYear = "1395" Or CurYear = "1399" Then
                CurDay = "30"
            Else
                CurDay = "29"
            End If
        End If
        Return CurYear & "/" & CurMonth & "/" & CurDay
    End Function

    Public Shared Function StartDayOfMonth(ByVal InputDate As Date) As String
        Dim CurDate As String = ShortDate(InputDate)
        Dim CurYear = CurDate.Substring(0, 4)
        Dim CurMonth = CurDate.Substring(5, 2)
        Dim CurDay = CurDate.Substring(8, 2)
        CurDay = "01"
        Return CurYear & "/" & CurMonth & "/" & CurDay
    End Function

    Public Shared Function LastDayOfNextMonth(ByVal InputDate As Date) As String
        Dim CurDate As String = ShortDate(InputDate)
        Dim CurYear = CurDate.Substring(0, 4)
        Dim CurMonth = CurDate.Substring(5, 2)
        Dim CurDay = CurDate.Substring(8, 2)
        If CurMonth = 12 Then
            CurMonth = "01"
            CurYear += 1
        Else
            CurMonth += 1
        End If
        If CurMonth < 7 Then
            CurDay = "31"
        ElseIf CurMonth > 6 And CurMonth < 12 Then
            CurDay = "30"
        ElseIf CurMonth = "12" Then
            If CurYear = "1391" Or CurYear = "1395" Or CurYear = "1399" Then
                CurDay = "30"
            Else
                CurDay = "29"
            End If
        End If
        Return CurYear & "/" & IIf(CurMonth.Length = 1, "0" & CurMonth, CurMonth) & "/" & CurDay
    End Function

    Public Shared Function StartDayOfNextMonth(ByVal InputDate As Date) As String
        Dim CurDate As String = ShortDate(InputDate)
        Dim CurYear = CurDate.Substring(0, 4)
        Dim CurMonth = CurDate.Substring(5, 2)
        Dim CurDay = CurDate.Substring(8, 2)
        If CurMonth = "12" Then
            CurMonth = "01"
            CurYear += 1
        Else
            CurMonth += 1
        End If
        CurDay = "01"
        Return CurYear & "/" & IIf(CurMonth.Length = 1, "0" & CurMonth, CurMonth) & "/" & CurDay
    End Function

    Public Shared Function ShortDatePersian(ByVal InputDate As Date) As String
        Dim PerCal As New PersianCalendar
        Dim Week As Integer = PerCal.GetDayOfWeek(InputDate)
        Dim WeekName As String = ""

        If Week = "0" Then
            WeekName = "یکشنبه"
        ElseIf Week = "1" Then
            WeekName = "دوشنبه"
        ElseIf Week = "2" Then
            WeekName = "سه شنبه"
        ElseIf Week = "3" Then
            WeekName = "چهارشنبه"
        ElseIf Week = "4" Then
            WeekName = "پنج شنبه"
        ElseIf Week = "5" Then
            WeekName = "جمعه"
        ElseIf Week = "6" Then
            WeekName = "شنبه"
        End If

        Dim DayMonth As Integer = PerCal.GetDayOfMonth(InputDate)


        Dim Month As Integer = PerCal.GetMonth(InputDate)
        Dim MonthName As String = ""

        If Month = "1" Then
            MonthName = "فروردین"
        ElseIf Month = "2" Then
            MonthName = "اردیبهشت"
        ElseIf Month = "3" Then
            MonthName = "خرداد"
        ElseIf Month = "4" Then
            MonthName = "تیر"
        ElseIf Month = "5" Then
            MonthName = "مرداد"
        ElseIf Month = "6" Then
            MonthName = "شهریور"
        ElseIf Month = "7" Then
            MonthName = "مهر"
        ElseIf Month = "8" Then
            MonthName = "آبان"
        ElseIf Month = "9" Then
            MonthName = "آذر"
        ElseIf Month = "10" Then
            MonthName = "دی"
        ElseIf Month = "11" Then
            MonthName = "بهمن"
        ElseIf Month = "12" Then
            MonthName = "اسفند"
        End If

        Return WeekName & " " & DayMonth & " " & MonthName & " " & PerCal.GetYear(InputDate)
    End Function

    Public Shared Function ShortDateLatin(ByVal InputDate As Date) As String

        Dim Week As Integer = InputDate.DayOfWeek
        Dim WeekName As String = ""


        If Week = "6" Then
            WeekName = "Saturday"
        ElseIf Week = "0" Then
            WeekName = "Sunday"
        ElseIf Week = "1" Then
            WeekName = "Monday"
        ElseIf Week = "2" Then
            WeekName = "Tuesday"
        ElseIf Week = "3" Then
            WeekName = "Wednesday"
        ElseIf Week = "4" Then
            WeekName = "Thursday"
        ElseIf Week = "5" Then
            WeekName = "Friday"
        End If


        Dim DayMonth As Integer = InputDate.Day


        Dim Month As Integer = InputDate.Month
        Dim MonthName As String = ""

        If Month = "1" Then
            MonthName = "January"
        ElseIf Month = "2" Then
            MonthName = "February"
        ElseIf Month = "3" Then
            MonthName = "March"
        ElseIf Month = "4" Then
            MonthName = "April"
        ElseIf Month = "5" Then
            MonthName = "May"
        ElseIf Month = "6" Then
            MonthName = "June"
        ElseIf Month = "7" Then
            MonthName = "July"
        ElseIf Month = "8" Then
            MonthName = "August"
        ElseIf Month = "9" Then
            MonthName = "September"
        ElseIf Month = "10" Then
            MonthName = "October"
        ElseIf Month = "11" Then
            MonthName = "November"
        ElseIf Month = "12" Then
            MonthName = "December"
        End If

        Return WeekName & " " & DayMonth & " " & MonthName & " " & InputDate.Year
    End Function

End Class
