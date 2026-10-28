
Partial Class UserControls_PrayerTimesWUC
    Inherits BaseUserControl

    Dim CityObj As New CLSCities

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim List As List(Of CLSCitiesItem) = CityObj.GetCITIES()
        For Each item In List
            Dim li As New ListItem
            li.Text = item.Name_persian
            li.Value = item.City_id
            drpPrayerCity.Items.Add(li)
        Next

    End Sub
End Class
