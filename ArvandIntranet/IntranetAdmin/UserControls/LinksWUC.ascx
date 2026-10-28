<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LinksWUC.ascx.vb" Inherits="UserControls_LinksWUC" %>

<div class="webpart">
    <ul class="webpart_header">
        <li class="webpart_title">پیوندها
        </li>
        <li>
            <img src="~/images/menu_header_corner.png" runat="server" />
        </li>
    </ul>
    <ul class="thumb_link">
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <li>
                    <a title='<%# SetTitle(Container.DataItem)%>' class="tooltip" href='<%# Eval("SiteLink")%>'>
                        <img src='<%# "~/" + SetLogo(Container.DataItem)%>' alt='<%# SetTitle(Container.DataItem)%>' runat="server" width="37" height="33" />
                    </a>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
</div>
<script type="text/javascript">
    $(function () {
        $('.tooltip').poshytip({
            className: 'tip-yellowsimple',
            showTimeout: 1,
            alignTo: 'target',
            alignX: 'center',
            alignY: 'bottom',
            slide: false,
            fade: false,
            offsetY: 5,
        });
    });
</script>

