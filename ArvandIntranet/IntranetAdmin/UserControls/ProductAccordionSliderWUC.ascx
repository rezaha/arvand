<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ProductAccordionSliderWUC.ascx.vb" Inherits="UserControls_ProductAccordionSliderWUC" %>
<div class="webpart">
    <ul class="webpart_header">
        <li class="webpart_title">محصولات
        </li>
        <li>
            <img src="~/images/menu_header_corner.png" runat="server" />
        </li>
    </ul>

    <!-- end of webpart_title ul !-->

    <ul class="product">
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <li>
                    <a runat="server" id="ReadMoreLnk" href='<%#SetReadMoreUrl(Container.DataItem)%>'>
                        <span class="product_title"><%#SetProductName(Container.DataItem)%></span>
                        <p>
                            <%#SetProductSummary(Container.DataItem)%>
                        </p>
                    </a>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>

</div>

