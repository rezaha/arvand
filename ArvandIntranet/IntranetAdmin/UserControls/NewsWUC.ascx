<%@ Control Language="VB" AutoEventWireup="false" CodeFile="NewsWUC.ascx.vb" Inherits="UserControls_NewsWUC" %>
<%@ Register Src="~/UserControls/NewsContentWUC.ascx" TagPrefix="uc1" TagName="NewsContentWUC" %>


<div class="news">
    <ul class="main_title">
        <li class="main_title_text">آخرین خبرهای اروند
        </li>
        <li class="main_title_corner">
            <img src="../../Images/main_title_corner.png" />
        </li>
    </ul>
    <uc1:NewsContentWUC runat="server" id="NewsContentWUC" />
    <!--end of news item!-->
    <ul class="news_navigator">
        <li>
            <a href="#">
                <img src="../../Images/arrow_right.png" alt="مطالب بعدی" />
            </a>
        </li>
        <li>
            <span>1
            </span>
        </li>
        <li>
            <a href="#">
                <img src="../../Images/arrow_left.png" alt="arrow" />
            </a>
        </li>
    </ul>
</div>
