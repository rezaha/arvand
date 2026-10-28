<%@ Control Language="VB" AutoEventWireup="false" CodeFile="TendersWUC.ascx.vb" Inherits="UserControls_TendersWUC" %>
<div class="webpart">
    <table cellpadding="0" cellspacing="0" class="part_header">
        <tr>

            <td class="webpart_text">
                <a href="tenders">
                    <img src="~/images/webpart_ico/annonce_h.png" runat="server" />
                    <span style="vertical-align: top;">مزایده / مناقصه
                    </span>
                </a>
            </td>
            <td class="webpart_border"></td>
        </tr>
    </table>

    <div class="content-div">
        <%--<asp:Label ID="lblText" runat="server" Text=""></asp:Label>--%>
        <table cellpadding="0" cellspacing="0" class="Tender">
            <tr class="tender_header">
                <td class="tender_title_name">
                    <img src="~/images/tender/tender_title.png" runat="server" />
                    <span class="tender_title">عنوان</span>
                </td>
                <td>
                    <img src="~/images/tender/tender_date.png"  runat="server"/>
                    <span class="tender_title">مهلت دریافت سند</span>
                </td>
                <td>
                    <img src="~/images/tender/tender_type.png" runat="server" />
                    <span class="tender_title">نوع</span>
                </td>
            </tr>
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><a href='<%#SetTenderURL(Container.DataItem)%>' target="_blank"><%# SetTenderTitle(Container.DataItem)%></a></td>
                        <td><%# SetTenderDateTime(Container.DataItem)%></td>
                        <td><%# SetTenderType(Container.DataItem)%></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>

        </table>
        <a class="all_tenders" href="tenders">آرشیو مزایده ها و مناقصه ها</a>
    </div>

</div>
