<%@ Control Language="VB" AutoEventWireup="false" CodeFile="VisitorsWUC.ascx.vb" Inherits="UserControls_VisitorsWUC" %>
<div class="webpart glass-visitors">
    <ul class="webpart_header">
        <li class="webpart_title">آمار بازدیدکنندگان
        </li>
        <li>
            <img src="~/images/menu_header_corner.png"  runat="server"/>
        </li>
    </ul>
    <!-- end of webpart_title ul !-->
    <div class="visitor">
        <span style="margin-top: 10px;" class="visitor_ico">
            <img src="~/images/statistic.png" runat="server" />
        </span>
        <ul class="visitor_text">
            <li>امروز:
                                <span id="todayCount1" runat="server">273 بازدید
                                </span>
            </li>

        </ul>
    </div>
    <div class="weather_detail">
    </div>
    <ul class="weather_list">
        <li>امروز:
                             <span id="todayCount2" runat="server">234
                             </span>
        </li>
        <li>هفته جاری:
                             <span id="CurrentWeekCount" runat="server">545
                             </span>
        </li>
        <li class="current_prayer">ماه جاری:
                             <span id="CurrentMonthCount" runat="server">1356
                             </span>
        </li>
    </ul>
    <!-- end of weather_list !-->
    <ul class="weather_list">
        <li>دیروز:
                             <span id="yesterdayCount" runat="server">543
                             </span>
        </li>
        <li>هفته گذشته:
                             <span id="PastWeekCount" runat="server">13:45
                             </span>
        </li>
        <li>ماه گذشته:
                             <span id="PastMonthCount" runat="server">13:45
                             </span>
        </li>
    </ul>
    <!-- end of weather_list !-->

</div>
