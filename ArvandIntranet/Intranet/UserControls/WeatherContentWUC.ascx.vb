Imports System.IO

Partial Class UserControls_WeatherContentWUC
    Inherits BaseUserControl

    Public Property _cityId As Integer

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Dim weatherItem = WeatherService.Ins.GetWeatherStationsInfo(SiteLanguage, _cityId)
            Dim weatjerIconName As String = Path.GetFileNameWithoutExtension(weatherItem.WeatherIcon)
            Dim eeatherIconAddress As String = "../Images/weather_ico/" & weatjerIconName & ".png"
            imgWeatherIco.Src = eeatherIconAddress
            lblWindSpeed.InnerHtml = weatherItem.WindSpeed

            lblWindDirection.InnerHtml = Helpers.GetEnumDescription(weatherItem.WindDirection)

            lblHumidity.InnerHtml = weatherItem.RelativeHumidity
           
            Dim VisKm As String = "نا مشخص"
            If weatherItem.VisibilityKM <> "N/A" Then
                VisKm = weatherItem.VisibilityKM & " کیلو متر"
            End If
            lblHorizontalViewing.InnerHtml = VisKm
            lblTemperature1.InnerHtml = weatherItem.StrWeatherStatus
            lblTemperature2.InnerHtml = weatherItem.Temperature & " درجه"
            lblWeatherLastUpdate.InnerHtml = "آخرین بروز رسانی : " & weatherItem.LastUpdateDate & "  ساعت: " & weatherItem.LastUpdateTime
        Catch ex As Exception
            Panel1.Controls.Clear()
            Dim txt As New Label
            txt.Text = "<div style=""font-family:tahoma; font-size:11px;"">"
            txt.Text &= "سرویس در دسترس نمیباشد"
            txt.Text &= "</div>"
            Panel1.Controls.Add(txt)
        End Try
    End Sub

End Class
