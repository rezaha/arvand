<%@ Control Language="VB" AutoEventWireup="false" CodeFile="OtherPagesWUC.ascx.vb" Inherits="UserControls_OtherPagesWUC" %>
<ul id="slide">
    <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
            <li>
                <a href='<%#SetPageUrl(Container.DataItem)%>'><%#SetPageTitle(Container.DataItem)%>
                </a>
                <p>
                    <%#SetPageSummary(Container.DataItem)%>
                </p>
            </li>
        </ItemTemplate>
    </asp:Repeater>
</ul>
