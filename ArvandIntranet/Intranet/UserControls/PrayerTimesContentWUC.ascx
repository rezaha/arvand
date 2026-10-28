<%@ Control Language="VB" AutoEventWireup="false" CodeFile="PrayerTimesContentWUC.ascx.vb" Inherits="UserControls_PrayerTimesContentWUC" %>
<div class="prayer">
    <span class="prayer_ico">
        <img id="CurrentPrayerIco" runat="server" />
    </span>
    <ul class="prayer_text">
        <li id="CurrentPrayerText" runat="server">اذان ظهر:
        </li>

    </ul>
</div>
<ul class="weather_list">
    <li id="MorningText" runat="server">اذان صبح:
                             <span id="MorningTime" runat="server">13:45
                             </span>
    </li>
    <li id="SunriseText" runat="server">طلوع آفتاب:
                             <span id="SunriseTime" runat="server">13:45
                             </span>
    </li>
    <li id="NoonPrayerText" runat="server">اذان ظهر:
                             <span id="NoonPrayerTime" runat="server">13:45
                             </span>
    </li>
</ul>
<!-- end of weather_list !-->
<ul class="weather_list">
    <li id="SunsetText" runat="server">غروب خورشید:
                             <span id="SunsetTime" runat="server">13:45
                             </span>
    </li>
    <li id="MaghribPrayerText" runat="server">اذان مغرب:
                             <span id="MaghribPrayerTime" runat="server">13:45
                             </span>
    </li>
    <li id="MidNightText" runat="server">نیمه شب:
                             <span id="MidNightTime" runat="server">13:45
                             </span>
    </li>
</ul>
<!-- end of weather_list !-->
