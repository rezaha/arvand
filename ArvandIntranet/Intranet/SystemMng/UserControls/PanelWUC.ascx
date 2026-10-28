<%@ Control Language="VB" AutoEventWireup="false" CodeFile="PanelWUC.ascx.vb" Inherits="SystemMng_UserControls_PanelWUC" %>
<div id="widget_child" runat="server" clientidmode="Static">
    <div class="widget-header">
        <table class="box" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td class="webpart_title">
                </td>
                <td class="webpart_bg" valign="baseline">
                    <span class="title_bullet">» </span>
                    <asp:Label ID="lblTitleNews" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div class="widget-content">
        <asp:Label ID="lblBodyNews" runat="server" Text=""></asp:Label>
    </div>
    <div class="box-footer">
        <asp:Label ID="lblFooterNews" runat="server" Text=""></asp:Label>
    </div>
</div>
