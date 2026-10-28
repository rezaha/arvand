<%@ Control Language="VB" AutoEventWireup="false" CodeFile="PanelWUC.ascx.vb" Inherits="UserControls_PanelWUC" %>
<ul class="webpart_header">
    <li class="webpart_title"><span style="vertical-align: top;" id="title" runat="server"></span>
    </li>
    <li>
        <img src="../../images/menu_header_corner.png" />
    </li>
</ul>
<div class="webpart" id="widget_child" runat="server" clientidmode="Static">
    <table cellpadding="0" cellspacing="0" class="part_header">
        <tr>
            <td class="webpart_border"></td>
        </tr>
    </table>
    <div class="content-div">
        <div id="PosibleDiv" runat="server">
        </div>
        <p class="about_text" id="content" runat="server">
        </p>
    </div>
</div>
