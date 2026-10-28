<%@ Control Language="VB" AutoEventWireup="false" CodeFile="OtherAnnouncementsWUC.ascx.vb" Inherits="UserControls_OtherAnnouncementsWUC" %>
<div class="news_sidebar_title">
    <img id="Img1" src="~/Images/shownews/news_title_sidebar.png" runat="server" />
    <span>دیگر اطلاعیه ها
    </span>
</div>
<ul class="sidebar_news" id="sidebar_ticker">
    <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
            <li>
                <a href='<%#SetAnnouncementUrl(Container.DataItem)%>'>
                    <span class="sidebar_news_title"><%#SetAnnouncementTitle(Container.DataItem)%></span>
                    <span class="sidebar_news_txt"><%#SetAnnouncementSummary(Container.DataItem)%></span>
                </a>
            </li>
        </ItemTemplate>
    </asp:Repeater>
</ul>
