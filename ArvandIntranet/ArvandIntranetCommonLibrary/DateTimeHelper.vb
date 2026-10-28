Imports Microsoft.VisualBasic
Imports System.ComponentModel
Imports System.Globalization
Imports System.Reflection

Namespace Danesh.ArvandIntranet.CommonLibrary
    Public Class DateTimeHelper

        Public Shared Function GetEnumDescription(ByVal value As [Enum]) As String
            ' Get the Description attribute value for the enum value
            Dim fi As FieldInfo = value.GetType.GetField(value.ToString)
            Dim attributes() As DescriptionAttribute = CType(fi.GetCustomAttributes(GetType(DescriptionAttribute), False), DescriptionAttribute())
            If (attributes.Length > 0) Then
                Return attributes(0).Description
            Else
                Return value.ToString
            End If
        End Function

        Dim persianCalendar As PersianCalendar

        Public Sub New()
            persianCalendar = New PersianCalendar
        End Sub

        Public Function ConvertToPersianDate(ByVal InputDate As DateTime) As String
            Dim year As String = persianCalendar.GetYear(New DateTime(InputDate.Year, InputDate.Month, InputDate.Day, New GregorianCalendar()))
            Dim month As String = Convert2Char(persianCalendar.GetMonth(New DateTime(InputDate.Year, InputDate.Month, InputDate.Day, New GregorianCalendar())))
            Dim day As String = Convert2Char(persianCalendar.GetDayOfMonth(New DateTime(InputDate.Year, InputDate.Month, InputDate.Day, New GregorianCalendar())))

            Return year & "/" & Convert2Char(month) & "/" & Convert2Char(day)
        End Function

        Public Function ConvertToLatinDate(ByVal persianDate As String, ByVal dateTimeFormat As LatinDateTime) As String

            Dim splits = persianDate.Split("/"c)
            Dim shamsiYear As Integer = Convert.ToInt32(splits(0))
            Dim shamsiMonth As Integer = Convert.ToInt32(splits(1))
            Dim shamsiDay As Integer = Convert.ToInt32(splits(2))

            Dim convertDate As Date = persianCalendar.ToDateTime(shamsiYear, shamsiMonth, shamsiDay, 0, 0, 0, 0)


            Dim year As String = convertDate.Year
            Dim month As String = convertDate.Month
            Dim day As String = convertDate.Day
            If dateTimeFormat = LatinDateTime.YMD Then
                Return year & "/" & Convert2Char(month) & "/" & Convert2Char(day)
            ElseIf dateTimeFormat = LatinDateTime.YDM Then
                Return year & "/" & Convert2Char(day) & "/" & Convert2Char(month)
            ElseIf dateTimeFormat = LatinDateTime.MDY Then
                Return Convert2Char(month) & "/" & Convert2Char(day) & "/" & year
            ElseIf dateTimeFormat = LatinDateTime.DMY Then
                Return Convert2Char(day) & "/" & Convert2Char(month) & "/" & year
            End If
            Return year & "/" & Convert2Char(month) & "/" & Convert2Char(day)
        End Function

        Public Function ConvertToLatinDate(ByVal InputDate As DateTime, ByVal dateTimeFormat As LatinDateTime) As String
            Dim year As String = InputDate.Year
            Dim month As String = InputDate.Month
            Dim day As String = InputDate.Day
            If dateTimeFormat = LatinDateTime.YMD Then
                Return year & "/" & Convert2Char(month) & "/" & Convert2Char(day)
            ElseIf dateTimeFormat = LatinDateTime.YDM Then
                Return year & "/" & Convert2Char(day) & "/" & Convert2Char(month)
            ElseIf dateTimeFormat = LatinDateTime.MDY Then
                Return Convert2Char(month) & "/" & Convert2Char(day) & "/" & year
            ElseIf dateTimeFormat = LatinDateTime.DMY Then
                Return Convert2Char(day) & "/" & Convert2Char(month) & "/" & year
            End If
            Return year & "/" & Convert2Char(month) & "/" & Convert2Char(day)
        End Function

        Public Function GetTime(ByVal InputDate As DateTime) As String
            'Dim time = InputDate.ToShortTimeString().Split(" ")(0).Trim.Split(":")
            Return Convert2Char(InputDate.Hour) & ":" & Convert2Char(InputDate.Minute)
        End Function

        Public Function GetFullTime(ByVal InputDate As DateTime) As String
            'Dim time = InputDate.ToShortTimeString().Split(" ")(0).Trim.Split(":")
            Return Convert2Char(InputDate.Hour) & ":" & Convert2Char(InputDate.Minute) & ":" & Convert2Char(InputDate.Second)
        End Function

        Public Function AddDay(ByVal InputDate As DateTime, ByVal Day As Integer) As DateTime
            InputDate = persianCalendar.AddDays(InputDate, Day)
            Return InputDate
        End Function

        Public Function AddPersianDay(ByVal InputDate As String, ByVal Day As Integer) As String
            Dim splits = InputDate.Split("/"c)
            Dim CurDateTime = Convert.ToDateTime(ConvertToLatinDate(InputDate, LatinDateTime.YMD))
            CurDateTime = AddDay(CurDateTime, Day)
            Return ConvertToPersianDate(CurDateTime)
        End Function

        Public Function AddHour(ByVal InputDate As DateTime, ByVal hour As Integer, Optional ByVal Is2400 As Boolean = False) As DateTime
            If Is2400 Then
                InputDate = persianCalendar.AddDays(InputDate, 1)
            End If
            InputDate = persianCalendar.AddHours(InputDate, hour)
            Return InputDate
        End Function

        Public Function AddMinute(ByVal InputDate As DateTime, ByVal minute As Integer) As DateTime
            InputDate = persianCalendar.AddMinutes(InputDate, minute)
            Return InputDate
        End Function

        Private Function Convert2Char(ByVal InputNum As Integer) As String
            If InputNum.ToString.Length = 1 Then
                Return "0" & InputNum.ToString
            End If
            Return InputNum.ToString
        End Function

        Public Function GetMonthName(ByVal PersianDate As String) As String
            PersianDate = ValidPersianDate(PersianDate)
            Dim splits = PersianDate.Split("/")
            Dim month As Integer = Convert.ToInt32(splits(1))
            If month = 1 Then
                Return "فروردین"
            ElseIf month = 2 Then
                Return "اردیبهشت"
            ElseIf month = 3 Then
                Return "خرداد"
            ElseIf month = 4 Then
                Return "تیر"
            ElseIf month = 5 Then
                Return "مرداد"
            ElseIf month = 6 Then
                Return "شهریور"
            ElseIf month = 7 Then
                Return "مهر"
            ElseIf month = 8 Then
                Return "آبان"
            ElseIf month = 9 Then
                Return "آذر"
            ElseIf month = 10 Then
                Return "دی"
            ElseIf month = 11 Then
                Return "بهمن"
            ElseIf month = 12 Then
                Return "اسفند"
            End If
            Return ""
        End Function

        Public Function GetFirstDayOfMonth(ByVal PersianDate As String) As String
            PersianDate = ValidPersianDate(PersianDate)
            Dim splits = PersianDate.Split("/")
            Dim month As Integer = Convert.ToInt32(splits(1))
            Dim year As Integer = Convert.ToInt32(splits(0))
            Return year & "/" & Convert2Char(month) & "/" & Convert2Char(1)
        End Function

        Public Function GetLastDayOfMonth(ByVal PersianDate As String) As String
            PersianDate = ValidPersianDate(PersianDate)
            Dim splits = PersianDate.Split("/")
            Dim day As Integer = 0
            Dim month As Integer = Convert.ToInt32(splits(1))
            Dim year As Integer = Convert.ToInt32(splits(0))
            If month <= 6 Then
                day = 31
            ElseIf month <= 11 Then
                day = 30
            ElseIf month = 12 Then
                If IsLeapYear(PersianDate) Then
                    day = 30
                Else
                    day = 29
                End If
            End If
            Return year & "/" & Convert2Char(month) & "/" & Convert2Char(day)
        End Function

        Public Function IsLeapYear(ByVal PersianDate As String) As Boolean
            Dim CurrentDate As Date = Convert.ToDateTime(ConvertToLatinDate(PersianDate, LatinDateTime.YMD))
            Return persianCalendar.IsLeapYear(CurrentDate.Year)
        End Function

        Private Function ValidPersianDate(ByVal PersianDate As String) As String
            Return PersianDate
        End Function

        Public Function FirstLastDayList(ByVal FromDate As String, ByVal ToDate As String) As List(Of FirstLastDay)
            Dim firstLastList As New List(Of FirstLastDay)
            Dim SplitFromDate = FromDate.Split("/")
            Dim SplitToDate = ToDate.Split("/")

            Dim FromYear As String = SplitFromDate(0)
            Dim FromMonth As String = SplitFromDate(1)

            Dim ToYear As String = SplitToDate(0)
            Dim ToMonth As String = SplitToDate(1)

            Dim selectDate As String = FromDate
            While selectDate <= ToDate
                Dim SplitSelectDate = selectDate.Split("/")
                Dim SelectYear As String = SplitSelectDate(0)
                Dim SelectMonth As String = SplitSelectDate(1)

                Dim FirstDay As String = GetFirstDayOfMonth(selectDate)

                If SelectYear = FromYear And SelectMonth = FromMonth Then
                    FirstDay = FromDate
                End If

                If firstLastList.FindIndex(Function(a) a.FirstDay = FirstDay) < 0 Then
                    Dim LastDay As String = GetLastDayOfMonth(selectDate)

                    If SelectYear = ToYear And SelectMonth = ToMonth Then
                        LastDay = ToDate
                    End If

                    firstLastList.Add(New FirstLastDay With {.FirstDay = FirstDay, .LastDay = LastDay})
                End If
                selectDate = AddPersianDay(selectDate, 1)
            End While
            Return firstLastList
        End Function

        Private Function IsEqualYearMonth(ByVal PersinDate1 As String, ByVal PersianDate2 As String) As Boolean

        End Function

        Public Function GetYear(ByVal PersianDate As String) As String
            Return PersianDate.Split("/")(0)
        End Function

        Public Function GetHours() As String()
            Return {"01:00", "02:00", "03:00", "04:00", "05:00", "06:00", "07:00", "08:00", "09:00", "10:00", "11:00", "12:00", "13:00", "14:00",
                    "15:00", "16:00", "17:00", "18:00", "19:00", "20:00", "21:00", "22:00", "23:00", "24:00"}
        End Function

        'Public Function GetLastHour(ByVal curTime As String) As String
        '    If curTime = "24:00" Then
        '        Return {"01:00", "02:00", "03:00", "04:00", "05:00", "06:00", "07:00", "08:00", "09:00", "10:00", "11:00", "12:00", "13:00", "14:00",
        '                "15:00", "16:00", "17:00", "18:00", "19:00", "20:00", "21:00", "22:00", "23:00", "24:00"}
        'End Function

        Public Function GetBeginHours(ByVal curTime As String) As String
            Dim hour As Integer = Convert.ToInt32(curTime.Substring(0, 2)) - 1
            Return Convert2Char(hour) & ":01"
        End Function

        Public Function LongPersianDate(ByVal persianDate As String, ByVal persianDateTimeFormat As PersianDateTimeFormat) As String
            Dim latinDate As Date = ConvertToLatinDate(persianDate, LatinDateTime.YMD)
            Dim DateSplit = persianDate.Split("/")
            Dim day1 = DateSplit(2)
            Dim Month1 As Integer = DateSplit(1)
            Dim Year1 As String = DateSplit(0)

            Dim year As Integer = persianCalendar.GetYear(New DateTime(latinDate.Year, latinDate.Month, latinDate.Day, New GregorianCalendar()))
            Dim month As Integer = persianCalendar.GetMonth(New DateTime(latinDate.Year, latinDate.Month, latinDate.Day, New GregorianCalendar()))
            Dim day As Integer = persianCalendar.GetDayOfMonth(New DateTime(latinDate.Year, latinDate.Month, latinDate.Day, New GregorianCalendar()))
            Dim dayOfWeek As Integer = persianCalendar.GetDayOfWeek(New DateTime(latinDate.Year, latinDate.Month, latinDate.Day, New GregorianCalendar()))
            If persianDateTimeFormat = persianDateTimeFormat.DayOfWeekName_Day_MonthName_Year Then
                Return DayOfWeekName(dayOfWeek) & " " & day & " " & PersianMonthName(month) & " " & year
                'Return day1 & " " & PersianMonthName(Month1) & " " & Year1
            ElseIf persianDateTimeFormat = persianDateTimeFormat.Day_MonthName_Year Then
                Return day & " " & PersianMonthName(Month1) & " " & year
            End If
            Return ""

        End Function

        Public Function LongLatinDate(ByVal persianDate As String, ByVal _latinDateTimeFormat As LatinDateTimeFormat) As String
            Dim latinDate As Date = ConvertToLatinDate(persianDate, LatinDateTime.YMD)
            Dim year As Integer = latinDate.Year
            Dim month As Integer = latinDate.Month
            Dim day As Integer = latinDate.Day
            'Dim dayOfWeek As Integer = latinDate.DayOfWeek
            If _latinDateTimeFormat = LatinDateTimeFormat.DayOfWeekName_Day_MonthName_Year Then
                Return latinDate.DayOfWeek.ToString & " " & day & " " & LatinMonthName(month) & " " & year
            ElseIf _latinDateTimeFormat = LatinDateTimeFormat.Day_MonthName_Year Then
                Return day & " " & LatinMonthName(month) & " " & year
            End If
            Return ""
        End Function

        Private Function PersianMonthName(ByVal MonthNo As Integer) As String
            If MonthNo = "1" Then
                Return "فروردین"
            ElseIf MonthNo = "2" Then
                Return "اردیبهشت"
            ElseIf MonthNo = "3" Then
                Return "خرداد"
            ElseIf MonthNo = "4" Then
                Return "تیر"
            ElseIf MonthNo = "5" Then
                Return "مرداد"
            ElseIf MonthNo = "6" Then
                Return "شهریور"
            ElseIf MonthNo = "7" Then
                Return "مهر"
            ElseIf MonthNo = "8" Then
                Return "آبان"
            ElseIf MonthNo = "9" Then
                Return "آذر"
            ElseIf MonthNo = "10" Then
                Return "دی"
            ElseIf MonthNo = "11" Then
                Return "بهمن"
            ElseIf MonthNo = "12" Then
                Return "اسفند"
            End If
            Return ""
        End Function

        Private Function LatinMonthName(ByVal MonthNo As Integer) As String
            If MonthNo = 1 Then
                Return "January"
            ElseIf MonthNo = 2 Then
                Return "February"
            ElseIf MonthNo = 3 Then
                Return "March"
            ElseIf MonthNo = 4 Then
                Return "April"
            ElseIf MonthNo = 5 Then
                Return "May"
            ElseIf MonthNo = 6 Then
                Return "June"
            ElseIf MonthNo = 7 Then
                Return "July"
            ElseIf MonthNo = 8 Then
                Return "August"
            ElseIf MonthNo = 9 Then
                Return "September"
            ElseIf MonthNo = 10 Then
                Return "October"
            ElseIf MonthNo = 11 Then
                Return "November"
            ElseIf MonthNo = 12 Then
                Return "December"
            End If
            Return ""
        End Function

        Private Function DayOfWeekName(ByVal dayOfWeek As Integer) As String
            If dayOfWeek = "6" Then
                Return "شنبه"
            ElseIf dayOfWeek = "0" Then
                Return "یکشنبه"
            ElseIf dayOfWeek = "1" Then
                Return "دوشنبه"
            ElseIf dayOfWeek = "2" Then
                Return "سه شنبه"
            ElseIf dayOfWeek = "3" Then
                Return "چهارشنبه"
            ElseIf dayOfWeek = "4" Then
                Return "پنج شنبه"
            ElseIf dayOfWeek = "5" Then
                Return "جمعه"
            End If
            Return ""
        End Function

    End Class
End Namespace
Public Enum PersianDateTimeFormat
    <Description("یکشنبه 12 اردیبهشت 1391")>
    DayOfWeekName_Day_MonthName_Year
    <Description("12 اردیبهست 1391")>
   Day_MonthName_Year
End Enum

Public Enum LatinDateTimeFormat
    <Description("یکشنبه 12 اردیبهشت 1391")>
    DayOfWeekName_Day_MonthName_Year
    <Description("12 اردیبهست 1391")>
   Day_MonthName_Year
End Enum

Public Structure FirstLastDay
    Public Property FirstDay As String
    Public Property LastDay As String
End Structure

Public Enum LatinDateTime
    YMD
    YDM
    MDY
    DMY
End Enum


