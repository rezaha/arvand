<%@ Control Language="VB" AutoEventWireup="false" CodeFile="CompanySpecificationsWUC.ascx.vb" Inherits="UserControls_CompanySpecificationsWUC" %>
<div class="webpart">
    <table cellpadding="0" cellspacing="0" class="part_header">
        <tr>

            <td class="webpart_text">
                <a>
                    <img src="~/images/webpart_ico/company_Specifications_h.png" runat="server" />
                    <span runat="server" id="WebpartHeader" style="vertical-align: top;" meta:resourcekey="WebpartHeader">
                    </span>
                </a>
            </td>
            <td class="webpart_border"></td>
        </tr>
    </table>
    <div class="content-div">
        <table class="company_info">
            <tr>
                <td>
                    <img src="~/images/tiny_ico/company_tiny_ico.png" runat="server" />
                    <asp:Label ID="lblComapnyNameTitle" runat="server" CssClass="company_info_span_title" meta:resourcekey="lblComapnyNameTitle"></asp:Label>
                    <asp:Label ID="lblComapnyName" runat="server" CssClass="company_info_span"></asp:Label>
                </td>

            </tr>
            <%--<tr>
                <td>
                    <img src="~/images/tiny_ico/Establishment_tiny_ico.png" runat="server" />
                    <asp:Label ID="lblEstablishYearTitle" runat="server" CssClass="company_info_span_title">سال تاسیس:</asp:Label>
                    <asp:Label ID="lblEstablishYear" runat="server" CssClass="company_info_span"></asp:Label>
                </td>
            </tr>--%>
            <tr>
                <td>
                    <img src="~/images/tiny_ico/Operation_tiny_ico.png" runat="server" />
                    <asp:Label ID="lblOperationYearTitle" runat="server" CssClass="company_info_span_title" meta:resourcekey="lblOperationYearTitle"></asp:Label>
                    <asp:Label ID="lblOperationYear" runat="server" CssClass="company_info_span"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <img src="~/images/tiny_ico/ceo_tiny_ico.png" runat="server" />
                    <asp:Label ID="lblManagerNameTitle" runat="server" CssClass="company_info_span_title" meta:resourcekey="lblManagerNameTitle"></asp:Label>
                    <asp:Label ID="lblManagerName" runat="server" CssClass="company_info_span"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <img src="~/images/tiny_ico/tel_tiny_ico.png" runat="server" />
                    <asp:Label ID="lblTelNoTitle" runat="server" CssClass="company_info_span_title" meta:resourcekey="lblTelNoTitle"></asp:Label>
                    <asp:Label ID="lblTelNo" runat="server" CssClass="company_info_span"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <img src="~/images/tiny_ico/fax_tiny_ico.png" runat="server" />
                    <asp:Label ID="lblFaxNoTitle" runat="server" CssClass="company_info_span_title" meta:resourcekey="lblFaxNoTitle"></asp:Label>
                    <asp:Label ID="lblFaxNo" runat="server" CssClass="company_info_span"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <img src="~/images/tiny_ico/email_tiny_ico.png" runat="server" />
                    <asp:Label ID="lblEmailAddressTitle" runat="server" CssClass="company_info_span_title" meta:resourcekey="lblEmailAddressTitle"></asp:Label>
                    <asp:Label ID="lblEmailAddress" runat="server" CssClass="company_info_span"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <img src="~/images/tiny_ico/address_tiny_ico.png" runat="server" />
                    <asp:Label ID="lblAddressTitle" runat="server" CssClass="company_info_span_title" meta:resourcekey="lblAddressTitle"></asp:Label>
                    <asp:Label ID="lblAddress" runat="server" CssClass="company_info_span"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</div>

