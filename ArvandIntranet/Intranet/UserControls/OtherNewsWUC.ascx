<%@ Control Language="VB" AutoEventWireup="false" CodeFile="OtherNewsWUC.ascx.vb" Inherits="UserControls_OtherNewsWUC" %>

<div class="news_sidebar_title">
    <img src="~/Images/shownews/news_title_sidebar.png" runat="server" />
    <span>دیگر اخبار
    </span>
</div>
<ul class="sidebar_news" id="sidebar_ticker">
    <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
            <li>
                <a href='<%#SetNewsUrl(Container.DataItem)%>'>
                    <span class="sidebar_news_title"><%#SetNewsTitle(Container.DataItem)%></span>
                    <span class="sidebar_news_txt"><%#SetNewsSummary(Container.DataItem)%></span>
                </a>
            </li>
        </ItemTemplate>
    </asp:Repeater>
</ul>
