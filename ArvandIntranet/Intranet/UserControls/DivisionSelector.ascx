<%@ Control Language="VB" AutoEventWireup="false" CodeFile="DivisionSelector.ascx.vb" Inherits="UserControls_DivisionSelector" %>
<div class="webpart">
    <ul class="webpart_header">
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    </ul>
    <ul class="links">
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <li style="width: 50%; float: right;">
                    <a href='<%#SetDivisionLink(Container.DataItem)%>' style="height: auto!important; padding: 10px; margin: 3px;">
                        <div style="text-align: center; width: 100%; margin: 5px; padding: 5px;">
                            <img src='<%#SetIconUrl(Container.DataItem)%>' runat="server" />
                        </div>
                        <div style="text-align: center; width: 100%; margin: 5px; padding: 5px; font-family: tahoma">
                            <%# SetTitle(Container.DataItem)%>
                        </div>
                    </a>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
</div>
