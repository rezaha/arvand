Imports DotNet.Highcharts
Imports DotNet.Highcharts.Enums
Imports DotNet.Highcharts.Helpers
Imports DotNet.Highcharts.Options

Public Class DrawChart

    Dim _chart As Highcharts

    Private ReadOnly _xAxis As New List(Of XAxis)
    Public Property YAxis As New YAxis
    Private ReadOnly _multiSeries As New List(Of Series)

    Public Property ChartName As String

    Public Sub SetXAxis(ByVal xAxis As XAxis)
        _xAxis.Add(xAxis)
    End Sub

    Public Sub SetXAxis(ByVal xAxis() As String, ByVal xAxisLable As XAxisLabels)
        _xAxis.Add(New XAxis With {.Categories = xAxis, .Labels = xAxisLable})
    End Sub

    Public Sub SetYAxis(Optional ByVal text As String = Nothing, Optional ByVal rotation As Integer? = Nothing, Optional ByVal min As Integer? = 0)
        Dim yAxisTitle As New YAxisTitle
        If text IsNot Nothing Then
            YAxisTitle.Text = text
        End If
        If rotation IsNot Nothing Then
            YAxisTitle.Rotation = rotation
        End If
        YAxis.Min = min
        YAxis.Title = YAxisTitle

    End Sub

    Public Sub SetXAxis(ByVal xAxis() As String, Optional ByVal enabled As Boolean = True, Optional ByVal formatter As String = Nothing, Optional ByVal staggerLines As Integer? = Nothing,
                             Optional ByVal stepValue As Integer? = Nothing, Optional ByVal rotation As Integer? = Nothing, Optional ByVal horizontalAligns As HorizontalAligns? = Nothing)
        Dim xAxisLable As New XAxisLabels
        xAxisLable.Enabled = Enabled
        If Rotation IsNot Nothing Then
            xAxisLable.Rotation = Rotation
        End If
        If Formatter IsNot Nothing Then
            xAxisLable.Formatter = Formatter
        End If
        If StaggerLines IsNot Nothing Then
            xAxisLable.StaggerLines = StaggerLines
        End If
        If StepValue IsNot Nothing Then
            xAxisLable.Step = StepValue
        End If
        If HorizontalAligns IsNot Nothing Then
            xAxisLable.Align = HorizontalAligns
        End If

        _xAxis.Add(New XAxis With {.Categories = xAxis, .Labels = xAxisLable})
    End Sub

    Public Sub AddSeries(ByVal series As Series)
        _multiSeries.Add(series)
    End Sub

    Public Property Title As String

    Public Property Width As Integer

    Public Property Height As Integer

    Public Property AllowZoom As Boolean

    Public Property AllowExport As Boolean

    Public Property ChartType As ChartTypes

    Public Property XAxisLable As XAxisLabels

    Public Property Subtitle As Subtitle

    Public Sub SetSubtitle(Optional ByVal text As String = Nothing, Optional ByVal align As HorizontalAligns = HorizontalAligns.Center, Optional ByVal verticalAlign As VerticalAligns = VerticalAligns.Top)
        subtitle = New Subtitle
        If text IsNot Nothing Then
            subtitle.Text = text
        End If
        subtitle.Align = Align
        subtitle.VerticalAlign = VerticalAlign
        subtitle.Y = -50
        'subtitle.X = 100
    End Sub

    Public Sub New()
        ChartType = New ChartTypes
        XAxisLable = New XAxisLabels
    End Sub

    Public Sub New(ByVal ChartName As String, ByVal xAxis() As String, ByVal series As List(Of Series), Optional ByVal Title As String = Nothing, Optional ByVal AllowZoom As Boolean = True,
                   Optional ByVal AllowExport As Boolean = True)
        Me.ChartName = ChartName
        If Title IsNot Nothing Then
            Me.Title = Title
        End If
        Me.AllowZoom = AllowZoom
        Me.AllowExport = AllowExport
        Me._multiSeries.AddRange(Series)
        ChartType = New ChartTypes
        XAxisLable = New XAxisLabels
    End Sub

    Public Sub CreateXAxisLable(Optional ByVal enabled As Boolean = True, Optional ByVal formatter As String = Nothing, Optional ByVal staggerLines As Integer? = Nothing,
                             Optional ByVal stepValue As Integer? = Nothing, Optional ByVal rotation As Integer? = Nothing, Optional ByVal horizontalAligns As HorizontalAligns? = Nothing)
        XAxisLable = New XAxisLabels()
        XAxisLable.Enabled = Enabled
        If Rotation IsNot Nothing Then
            XAxisLable.Rotation = Rotation
        End If
        If Formatter Is Nothing Then
            XAxisLable.Formatter = Formatter
        End If
        If StaggerLines IsNot Nothing Then
            XAxisLable.StaggerLines = StaggerLines
        End If
        If StepValue IsNot Nothing Then
            XAxisLable.Step = StepValue
        End If
        If HorizontalAligns IsNot Nothing Then
            XAxisLable.Align = HorizontalAligns
        End If
    End Sub

    Public Function FastCharts(ByVal xAxis() As String, ByVal series() As Series, Optional ByVal ChartName As String = Nothing, Optional ByVal Title As String = Nothing, Optional ByVal AllowZoom As Boolean = True,
                               Optional ByVal AllowExport As Boolean = True, Optional ByVal _chartType As ChartTypes = ChartTypes.Spline, Optional ByVal xAxisLable As XAxisLabels = Nothing) As String
        Dim chart As New DotNet.Highcharts.Highcharts(IIf(ChartName <> Nothing, ChartName, "chart"))

        chart.SetOptions(New GlobalOptions() With {.Lang = New DotNet.Highcharts.Helpers.Lang() With {.DownloadJPEG = "دانلود با فرمت JPEG", .DownloadPDF = "دانلود با فرمت PDF",
                                                                           .DownloadPNG = "دانلود با فرمت PNG", .DownloadSVG = "دانلود با فرمت SVG",
                                                                           .ExportButtonTitle = "خروجی", .PrintButtonTitle = "چاپ",
                                                                           .ResetZoom = "بازگشت به نمای اولیه", .ResetZoomTitle = "بازگشت به نمای اولیه سطح 1:1"}})
        If Title IsNot Nothing Then
            chart.SetTitle(New Title() With {.Text = Title})
        End If

        If AllowZoom Then
            chart.InitChart(New Chart() With {.DefaultSeriesType = _chartType, .ZoomType = Enums.ZoomTypes.Xy})
        End If
        If AllowExport Then
            chart.SetExporting(New Exporting() With {.Enabled = True})
        Else
            chart.SetExporting(New Exporting() With {.Enabled = False})
        End If

        chart.SetXAxis(New XAxis With {.Categories = XAxis, .Title = Nothing})
        If xAxisLable IsNot Nothing Then
            chart.SetXAxis(New XAxis With {.Categories = XAxis, .Labels = xAxisLable})
        Else
            chart.SetSeries(Series)
        End If
        'Dim chart As New DotNet.Highcharts.Highcharts("chart")
        'chart.InitChart(New Chart() With {.ZoomType = Enums.ZoomTypes.Xy})
        'chart.SetOptions(New GlobalOptions() With {.Lang = New Lang() With {.DownloadJPEG = "دانلود با فرمت JPEG", .DownloadPDF = "دانلود با فرمت PDF",
        '                                                                    .DownloadPNG = "دانلود با فرمت PNG", .DownloadSVG = "دانلود با فرمت SVG",
        '                                                                    .ExportButtonTitle = "خروجی", .PrintButtonTitle = "چاپ",
        '                                                                    .ResetZoom = "بازگشت به نمای اولیه", .ResetZoomTitle = "بازگشت به نمای اولیه سطح 1:1"}})
        'chart.SetExporting(New Exporting() With {.Enabled = True, .EnableImages = True})
        'chart.SetTitle(New Title() With {.Text = "گزارش تستی"})
        'chart.SetXAxis(New XAxis With {.Categories = {"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"}})
        'chart.SetSeries(New Series With {.Data = New Data(New Object() {29.9, 71.5, 106.4, 129.2, 144.0, 176.0, 135.6, 148.5, 216.4, 194.1, 95.6, 54.4})})

        Return chart.ToHtmlString
    End Function

    Public Function ToHtml() As String
        _chart = New Highcharts(IIf(ChartName <> Nothing, ChartName, "chart"))
        Dim chartOption As New Chart
        chartOption.Width = Width
        chartOption.Height = Height
        chartOption.DefaultSeriesType = ChartType
        chartOption.MarginBottom = 160
        If AllowZoom Then
            chartOption.ZoomType = ZoomTypes.X
        End If

        chartOption.MarginLeft = 70
        _chart.InitChart(chartOption)
        _chart.SetSubtitle(subtitle)
        _chart.SetTooltip(New Tooltip With
                    {
                        .Crosshairs = New Crosshairs(True),
                        .Shared = True
                    })
        Dim plotOption As New PlotOptions
        plotOption.Area = New PlotOptionsArea With
                            {
                                .LineWidth = 1,
                                .Marker = New PlotOptionsAreaMarker With
                                    {
                                        .Enabled = False,
                                        .States = New PlotOptionsAreaMarkerStates With
                                            {
                                                .Hover = New PlotOptionsAreaMarkerStatesHover With
                                                    {
                                                        .Enabled = True,
                                                        .Radius = 5
                                                    }
                                            }
                                    },
                                .Shadow = False,
                                .States = New PlotOptionsAreaStates With {.Hover = New PlotOptionsAreaStatesHover With {.LineWidth = 1}}
                            }

        _chart.SetYAxis(YAxis)
        _chart.SetPlotOptions(plotOption)
        _chart.SetOptions(New GlobalOptions() With {.Lang = New Helpers.Lang() With {.DownloadJPEG = "دانلود با فرمت JPEG", .DownloadPDF = "دانلود با فرمت PDF",
                                                                    .DownloadPNG = "دانلود با فرمت PNG", .DownloadSVG = "دانلود با فرمت SVG",
                                                                    .ExportButtonTitle = "خروجی", .PrintButtonTitle = "چاپ",
                                                                    .ResetZoom = "بازگشت به نمای اولیه", .ResetZoomTitle = "بازگشت به نمای اولیه سطح 1:1"}})
        If Title IsNot Nothing Then
            _chart.SetTitle(New Title() With {.Text = Title})
        End If


        If AllowExport Then
            _chart.SetExporting(New Exporting() With {.Enabled = True, .Url = "HighchartsExport.axd", .Filename = Guid.NewGuid.ToString, .Width = 900})
        Else
            _chart.SetExporting(New Exporting() With {.Enabled = False})
        End If

        _chart.SetXAxis(_xAxis.ToArray)
        _chart.SetSeries(_multiSeries.ToArray)

        Return _chart.ToHtmlString

    End Function

    Public Shared Function DoubleToPoint(ByVal values() As Decimal) As Data
        Dim points As New List(Of Point)
        For i As Integer = 0 To values.Length - 1
            points.Add(New Point() With {.Y = values(i)})
        Next
        Return New Data(points.ToArray)
    End Function

End Class
