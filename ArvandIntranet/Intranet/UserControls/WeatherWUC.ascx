<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WeatherWUC.ascx.vb" Inherits="UserControls_WeatherWUC" %>
<div class="webpart">
    <ul class="webpart_header">
        <li class="webpart_title">آب و هوا
        </li>
        <li>
            <img src="../../images/menu_header_corner.png" />
        </li>
    </ul>
    <!-- end of webpart_title ul !-->

    <div class="weather_detail">
        <asp:DropDownList ID="drpWeatherCity" CssClass="drp_style" runat="server" ClientIDMode="Static">
        </asp:DropDownList>
    </div>
    <div id="watherContent">
    </div>
</div>

<script type="text/javascript">
    $(document).ready(function () {
        $('#drpWeatherCity').change(function () {
            loadWather()
        });
        loadWather();
    });
    function loadWather() {
        var weatherCity = $("#drpWeatherCity option:selected").val();

        if (acceptLanguage == "en") {
            $("#watherContent").html('<table class="loading"><tr><td>Loading...</td></tr><tr><td><img src="../../Images/loading.gif" alt="Loading..."/></td></tr></table>');
            $.ajax({
                //url: "../service/weather/" + city,
                url: "../../api/Service/weather/" + acceptLanguage + "/" + weatherCity,
                type: "post",
                cash: false,
                data: null,
                // callback handler that will be called on success
                success: function (response) {
                    // log a message to the console
                    $("#watherContent").html(response.toString());
                },
                // callback handler that will be called on error
                error: function (jqXHR, textStatus, errorThrown) {
                    // log the error to the console
                    $("#weatherContent").html("Service is not available.");
                },
                // callback handler that will be called on completion
                // which means, either on success or error
                complete: function () {
                    // enable the inputs
                }
            });
        }
        else {
            $("#watherContent").html('<table class="loading"><tr><td>در حال بارگزاری اطلاعات</td></tr><tr><td><img src="../../Images/loading.gif" alt="در حال بارگزاری اطلاعات"/></td></tr></table>');
            $.ajax({
                //url: "../service/weather/" + city,
                url: "../../api/Service/weather/" + acceptLanguage + "/" + weatherCity,
                type: "post",
                cash: false,
                data: null,
                // callback handler that will be called on success
                success: function (response) {
                    // log a message to the console
                    $("#watherContent").html(response.toString());
                },
                // callback handler that will be called on error
                error: function (jqXHR, textStatus, errorThrown) {
                    // log the error to the console
                    $("#weatherContent").html("سرویس در دسترس نمی باشد.");
                },
                // callback handler that will be called on completion
                // which means, either on success or error
                complete: function () {
                    // enable the inputs
                }
            });
        }
        //var preValue = $("#prayerContentTd").html();

    }
</script>

