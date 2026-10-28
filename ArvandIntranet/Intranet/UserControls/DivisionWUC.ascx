<%@ Control Language="VB" AutoEventWireup="false" CodeFile="DivisionWUC.ascx.vb" Inherits="UserControls_DivisionWUC" %>
<div class="webpart">
    <ul class="webpart_header">
        <li class="webpart_title">امور
        </li>
        <li>
            <img src="../../images/menu_header_corner.png" />
        </li>
    </ul>
    <!-- end of webpart_title ul !-->
    <ul class="links">
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <li>
                    <a href='<%#SetDivisionLink(Container.DataItem)%>'>
                        <span class="links_ico">
                            <img width="16" height="16" style="width:16px; height:16px;" src='<%#SetIconUrl(Container.DataItem)%>' />
                        </span>
                        <span class="links_text"><%# SetTitle(Container.DataItem)%>
                        </span>
                    </a>
                </li>
            </ItemTemplate>
        </asp:Repeater>
        <%--<li>
            <a href="#">
                <span class="links_ico">
                    <img src="../../images/section_item.png" />
                </span>

                <span class="links_text">واحد HSE
                </span>

            </a>
        </li>
        <li>
            <a href="#">
                <span class="links_ico">
                    <img src="../../images/section_item.png" />
                </span>

                <span class="links_text">واحد HSE
                </span>

            </a>
        </li>--%>
    </ul>
    <!-- end of links ul !-->
</div>
