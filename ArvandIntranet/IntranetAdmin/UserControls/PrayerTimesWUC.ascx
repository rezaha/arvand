<%@ Control Language="VB" AutoEventWireup="false" CodeFile="PrayerTimesWUC.ascx.vb" Inherits="UserControls_PrayerTimesWUC" %>
<div class="webpart">

    <ul class="webpart_header">
        <li class="webpart_title">اوقات شرعی
        </li>
        <li>
            <img src="../../images/menu_header_corner.png" />
        </li>
    </ul>
    <div class="weather_detail">
        <asp:DropDownList ID="drpPrayerCity" CssClass="drp_style" runat="server" ClientIDMode="Static">
        </asp:DropDownList>
    </div>

    <!-- end of webpart_title ul !-->
    <div id="prayerContent">
    </div>
</div>
<script type="text/javascript">
    $(document).ready(function () {
        $('#drpPrayerCity').change(function () {
            loadPrayer()
        });
        loadPrayer();
    });

    function loadPrayer() {
        var prayerCity = $("#drpPrayerCity option:selected").val();
        //var preValue = $("#prayerContentTd").html();
        if (acceptLanguage == "en") {
            $("#prayerContent").html('<table class="loading"><tr><td>Loading...</td></tr><tr><td><img src="../../Images/loading.gif" alt="Loading..."/></td></tr></table>');
            $.ajax({
                //url: "../service/weather/" + city,
                url: "../../api/Service/prayer/" + acceptLanguage + "/" + prayerCity,
                type: "post",
                cash: false,
                data: null,
                // callback handler that will be called on success
                success: function (response) {
                    // log a message to the console
                    $("#prayerContent").html(response.toString());
                },
                // callback handler that will be called on error
                error: function (jqXHR, textStatus, errorThrown) {
                    // log the error to the console
                    $("#prayerContent").html("Service is not available.");
                },
                // callback handler that will be called on completion
                // which means, either on success or error
                complete: function () {
                    // enable the inputs
                }
            });
        }
        else {
            $("#prayerContent").html('<table class="loading"><tr><td>در حال بارگزاری اطلاعات</td></tr><tr><td><img src="../../Images/loading.gif" alt="در حال بارگزاری اطلاعات"/></td></tr></table>');
            $.ajax({
                //url: "../service/weather/" + city,
                url: "../../api/Service/prayer/" + acceptLanguage + "/" + prayerCity,
                type: "post",
                cash: false,
                data: null,
                // callback handler that will be called on success
                success: function (response) {
                    // log a message to the console
                    $("#prayerContent").html(response.toString());
                },
                // callback handler that will be called on error
                error: function (jqXHR, textStatus, errorThrown) {
                    // log the error to the console
                    $("#prayerContent").html("سرویس در دسترس نمی باشد.");
                },
                // callback handler that will be called on completion
                // which means, either on success or error
                complete: function () {
                    // enable the inputs
                }
            });
        }
    }
</script>

