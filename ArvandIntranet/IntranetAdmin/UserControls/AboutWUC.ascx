<%@ Control Language="VB" AutoEventWireup="false" CodeFile="AboutWUC.ascx.vb" Inherits="UserControls_AboutWUC" %>
<div class="software_list glass-urgent">
    <ul class="main_title">
        <li class="main_title_text">پیغام فوری
        </li>
        <li class="main_title_corner">
            <img id="Img1" src="~/Images/main_title_corner.png" runat="server" />
        </li>
    </ul>
    <div id="lblAboutSummary" runat="server" class="about-min ">
    </div>
    <a runat="server" id="moreLnk" href='<%#SetAboutUrl()%>' target="_blank" class="about-min-more">ادامه مطلب</a>
    <div>&nbsp;</div>
</div>
<style type="text/css">
    .about-min {
        font: 11px tahoma;
        line-height: 18px;
        padding: 10px;
        width:600px;
    }
    .about-min-more {
        text-align: left;
        background: #6a6a6a;
        color: #fff;
        font-family: BYekan,tahoma;
        font-size: 14px;
        border-radius: 2px;
        -moz-border-radius: 2px;
        -webkit-border-radius: 2px;
        margin-bottom: 10px;
         padding: 10px;
         float:left;
         display:inline-block;
         clear:both;
    }
</style>

