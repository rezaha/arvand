<%@ Control Language="VB" AutoEventWireup="false" CodeFile="HomePageGallery1.ascx.vb" Inherits="UserControls_HomePageGallery1" %>
<div class="pikachoose">

    <ul id="pikame" class="jcarousel-skin-pika">
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <li><a target="_blank" href='<%# "~/" + Eval("ImageAddress")%>' runat="server">
                    <img id="Img1" src='<%# "~/" + Eval("ImageAddress")%>' runat="server" />
                </a><span><%#GetDescription(Container.DataItem)%></span></li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
</div>
<!-- end of slideshow !-->
