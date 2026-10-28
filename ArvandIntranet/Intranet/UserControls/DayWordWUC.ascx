<%@ Control Language="VB" AutoEventWireup="false" CodeFile="DayWordWUC.ascx.vb" Inherits="UserControls_DayWordWUC" %>
<div class="webpart">
    <table cellpadding="0" cellspacing="0" class="part_header">
        <tr>
            <td class="webpart_text">
                <a>
                    <img id="Img1" src="~/images/webpart_ico/about_header_icon.png" runat="server" />
                    <span runat="server" id="WebpartHeader" style="vertical-align: top;" meta:resourcekey="WebpartHeader">
                    </span>
                </a>
            </td>
            <td class="webpart_border"></td>
        </tr>
    </table>
    <div class="content-div">
        <p class="about_text">
            <asp:Label ID="lblDayWordTitle" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblDayWordText" runat="server" Text=""></asp:Label>
        </p>
    </div>
</div>
