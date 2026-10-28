
Partial Class UserControls_PrayerTimesContentWUC
    Inherits BaseUserControl


    Public Property _cityId As Integer
    Public Property prayerTimeService As IPrayerTimeService

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim CurTime As String = String.Format("{0:D2}", Now.Hour) & ":" & String.Format("{0:D2}", Now.Minute)


        If SiteLanguage.ToLower = "en" Then

        Else

            Dim dt = New DateTimeHelper

            Dim prayer = prayerTimeService.GetOnePrayerTimes(CityId:=_cityId, PrayerDate:=dt.ConvertToPersianDate(DateTime.Now).Substring(2))

            'اذان صبح
            If Not (CurTime > prayer.MaghribPrayer And CurTime <= prayer.MidNight) Then
                If CurTime < prayer.MorningPrayer Then
                    MorningText.Attributes.Add("class", "current_prayer")
                    CurrentPrayerText.InnerHtml = "اذان صبح"
                    CurrentPrayerText.InnerHtml &= "<span>" & prayer.MorningPrayer & " </span>"
                    CurrentPrayerIco.Src = "../images/prayer_ico.png"
                Else
                End If
            Else
            End If
            MorningTime.InnerText = prayer.MorningPrayer

            'طلوع آفتاب
            If CurTime > prayer.MorningPrayer And CurTime <= prayer.Sunrise Then
                SunriseText.Attributes.Add("class", "current_prayer")
                CurrentPrayerText.InnerHtml = "طلوع آفتاب"
                CurrentPrayerText.InnerHtml &= "<span>" & prayer.Sunrise & " </span>"
                CurrentPrayerIco.Src = "../images/prayer_ico.png"
            Else
            End If
            SunriseTime.InnerHtml = prayer.Sunrise

            'اذان ظهر
            If CurTime > prayer.Sunrise And CurTime <= prayer.NoonPrayer Then
                NoonPrayerText.Attributes.Add("class", "current_prayer")
                CurrentPrayerText.InnerHtml = "اذان ظهر:"
                CurrentPrayerText.InnerHtml &= "<span>" & prayer.NoonPrayer & " </span>"
                CurrentPrayerIco.Src = "../images/prayer_ico.png"
            Else
            End If
            NoonPrayerTime.InnerHtml = prayer.NoonPrayer

            'غروب خورشید
            If CurTime > prayer.NoonPrayer And CurTime <= prayer.Sunset Then
                SunsetText.Attributes.Add("class", "current_prayer")
                CurrentPrayerText.InnerHtml = "غروب خورشید:"
                CurrentPrayerText.InnerHtml &= "<span>" & prayer.Sunset & " </span>"
                CurrentPrayerIco.Src = "../images/prayer_ico.png"
            Else
            End If
            SunsetTime.InnerHtml = prayer.Sunset

            'اذان مغرب
            If CurTime > prayer.Sunset And CurTime <= prayer.MaghribPrayer Then
                MaghribPrayerText.Attributes.Add("class", "current_prayer")
                CurrentPrayerText.InnerHtml = "اذان مغرب:"
                CurrentPrayerText.InnerHtml &= "<span>" & prayer.MaghribPrayer & " </span>"
                CurrentPrayerIco.Src = "../images/prayer_ico.png"
            Else
            End If
            MaghribPrayerTime.InnerHtml = prayer.MaghribPrayer

            'نیمه شب
            If CurTime > prayer.MaghribPrayer And CurTime <= prayer.MidNight Then
                MidNightText.Attributes.Add("class", "current_prayer")
                CurrentPrayerText.InnerHtml = "نیمه شب:"
                CurrentPrayerText.InnerHtml &= "<span>" & prayer.MidNight & " </span>"
                CurrentPrayerIco.Src = "../images/prayer_ico.png"
            Else
            End If
            MidNightTime.InnerHtml = prayer.MidNight
        End If

        ''''''''''''''''
    End Sub

End Class
