<%@ Control Language="VB" AutoEventWireup="false" CodeFile="SoftwareSideBarWUC.ascx.vb" Inherits="UserControls_SoftwareSideBarWUC" %>
<div class="news_sidebar_title">
    <img src="~/Images/shownews/news_title_sidebar.png" runat="server" />
    <span>دسترسی سریع
    </span>
</div>
<ul class="user_menu">
    <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
            <li>
                <a href='<%#Eval("SoftwareUrl")%>' target="_blank">
                    <img src='<%#SetSmallImage(Container.DataItem)%>' runat="server"/>
                    <span><%#Eval("SoftwareName")%></span>
                </a>
            </li>
        </ItemTemplate>
    </asp:Repeater>
</ul>
