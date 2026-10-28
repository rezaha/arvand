<%@ Control Language="VB" AutoEventWireup="false" CodeFile="TopNewsTickerWUC.ascx.vb" Inherits="UserControls_TopNewsTickerWUC" %>

<table cellpadding="0" cellspacing="0" class="ticker_container">
    <tr>
        <td>
            <div>
                <ol id="sample" class="ticker">
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <li><a href='<%#SetNewsTickerUrl(Container.DataItem, "news")%>'><%# NewsTickerTitle(Container.DataItem)%></a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:Repeater ID="Repeater2" runat="server">
                        <ItemTemplate>
                            <li><a href='<%#SetNewsTickerUrl(Container.DataItem, "announcement")%>'><%# NewsTickerTitle(Container.DataItem)%></a></li>
                        </ItemTemplate>
                    </asp:Repeater>
                  
                </ol>
            </div>
        </td>
        <td style="width: 10px;">
            <img src="~/Images/ticker_arrow.png" runat="server" id="tickerArrowImage" alt="ticker arrow" meta:resourcekey="tickerArrowImage" /></td>
        <td style="width: 120px;" id="tickerHeader" runat="server" meta:resourcekey="tickerHeader"></td>
        <td valign="middle" style="width: 17px;">
            <img src="~/images/ticker_icon.png" runat="server" id="tickerIconImage" alt="ticker icon" />
        </td>
    </tr>
</table>
