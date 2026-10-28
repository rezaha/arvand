
Partial Class UserControls_WeatherWUC
    Inherits BaseUserControl

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim weather = WeatherService.Ins
        If SiteLanguage.ToLower = "en" Then
            For Each item In weather.Cities
                drpWeatherCity.Items.Add(New ListItem With {.Value = item.cityId, .Text = item.city})
            Next
        Else
            For Each item In weather.Cities
                drpWeatherCity.Items.Add(New ListItem With {.Value = item.cityId, .Text = item.persianCity})
            Next
        End If
        drpWeatherCity.SelectedValue = 30
    End Sub

End Class
