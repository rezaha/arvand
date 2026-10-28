<%@ Control Language="VB" AutoEventWireup="false" CodeFile="AnnouncementsWUC.ascx.vb" Inherits="UserControls_AnnouncementsWUC" %>
<%@ Register Src="~/UserControls/AnnouncementsContentWUC.ascx" TagPrefix="uc1" TagName="AnnouncementsContentWUC" %>

<div class="annonce">
    <ul class="main_title">
        <li class="main_title_text">اطلاعیه ها
        </li>
        <li class="main_title_corner">
            <img src="../../Images/main_title_corner.png" />
        </li>
    </ul>
    <uc1:AnnouncementsContentWUC runat="server" ID="AnnouncementsContentWUC" />
</div>
