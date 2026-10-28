<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WeatherContentWUC.ascx.vb" Inherits="UserControls_WeatherContentWUC" %>
<asp:Panel ID="Panel1" runat="server">
    <div class="weather">
        <span class="weather_ico">
            <img id="imgWeatherIco" runat="server" src="../../images/weather_img.png" />
        </span>
        <ul class="weather_text">
            <li class="weather_Degree" id="lblTemperature1" runat="server">20درجه
            </li>
            <li class="weather_type" id="lblTemperature2" runat="server">20درجه
            </li>
        </ul>
    </div>
    <ul class="weather_list">
        <li>سرعت باد:
                             <span id="lblWindSpeed" runat="server">15 KM/h
                             </span>
        </li>
        <li>رطوبت:
                             <span id="lblHumidity" runat="server">37%
                             </span>
        </li>
    </ul>
    <!-- end of weather_list !-->
    <ul class="weather_list">
        <li>سمت باد:
                             <span id="lblWindDirection" runat="server">جنوب
                             </span>
        </li>
        <li>دید افقی:
                             <span id="lblHorizontalViewing" runat="server">نامشخص
                             </span>
        </li>
    </ul>
    <!-- end of weather_list !-->
    <p class="last_update" id="lblWeatherLastUpdate" runat="server">
        آخرین بروز رسانی : 1392 /01/19  ساعت: 11:30 
    </p>
</asp:Panel>
