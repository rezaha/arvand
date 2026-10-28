<%@ Control Language="VB" AutoEventWireup="false" CodeFile="OtherProductWUC.ascx.vb" Inherits="UserControls_OtherProductWUC" %>
<ul id="slide">
    <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
            <li>
                <a href='<%#SetProductUrl(Container.DataItem)%>'><%#SetProductTitle(Container.DataItem)%>
                </a>
                <p>
                    <%#SetProductSummary(Container.DataItem)%>
                </p>
            </li>
        </ItemTemplate>
    </asp:Repeater>
</ul>