<%@ Page Title="" Language="VB" MasterPageFile="~/SystemMng/MasterPage.master" AutoEventWireup="false"
    CodeFile="Visitor.aspx.vb" Inherits="SystemMng_Visitor" %>

<%@ Register Assembly="JQControls" Namespace="JQControls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function isNum(e) {
            var keycode;
            if (window.event) keycode = window.event.keyCode;
            else if (e) keycode = e.which;
            if (keycode > 31 && (keycode < 48 || keycode > 57))
                return false;
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:JQLoader ID="JQLoader1" runat="server">
    </cc1:JQLoader>
    <table cellspacing="0" cellpadding="0" width="100%">
        <tr>
            <td class="tdInfoHeader" align="center" colspan="2">بازدیدکنندگان سایت
            </td>
        </tr>
        <tr>
            <td width="50%">
                <table cellspacing="0" cellpadding="0" width="100%">
                    <tr>
                        <td class="tdInfoItem Infotxt" align="center">از تاریخ</td>
                        <td class="tdInfoItem" align="right">&nbsp;
                            <cc1:JQDatePicker ID="txtFromDate" DateFormat="YMD" runat="server" CssClass="txtInfoLeft leftEn"
                                Regional="fa"></cc1:JQDatePicker>
                            <asp:RequiredFieldValidator ID="rfvVisit_date" runat="server" ControlToValidate="txtFromDate"
                                Display="None" ErrorMessage="از تاریخ وارد نشده است" Text="*"
                                ValidationGroup="p"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="50%">
                <table cellspacing="0" cellpadding="0" width="100%">
                    <tr>
                        <td class="tdInfoItem Infotxt" align="center">تا تاریخ</td>
                        <td class="tdInfoItem" align="right">&nbsp;
                            <cc1:JQDatePicker ID="txtToDate" DateFormat="YMD" runat="server" CssClass="txtInfoLeft leftEn"
                                Regional="fa"></cc1:JQDatePicker>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtToDate"
                                Display="None" ErrorMessage="تا تاریخ وارد نشده است" Text="*"
                                ValidationGroup="p"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <table cellpadding="5px">
                    <tr>
                        <td>
                            <asp:Button Text="جستجو" runat="server" ID="btnSearch"
                                CssClass="btn-act act-clear" ValidationGroup="P" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="Document"
        CssClass="Error"></asp:ValidationSummary>
    <asp:GridView ID="gridview1" runat="server" CssClass="grid" GridLines="None" AutoGenerateColumns="False"
        EmptyDataText="داده وجود ندارد..." ShowFooter="false" BackColor="White" BorderColor="White"
        BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1"
        AllowPaging="True" PageSize="20">
        <RowStyle CssClass="row" />
        <AlternatingRowStyle CssClass="altrow" />
        <SelectedRowStyle CssClass="selectedrow" />
        <Columns>
            <asp:TemplateField HeaderText="ویرایش" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:ImageButton ID="Image31" runat="server" ImageUrl="~/Images/icon-pencil.gif"
                        CommandName="up" CausesValidation="false" CommandArgument='<%#CLSHash.Encode(Eval("VisitId"))%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="نام بخش" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Literal ID="Part_type" runat="server" Text='<%#Eval("PartType")%>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="تاریخ مشاهده" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Literal ID="Visit_date" runat="server" Text='<%#Eval("VisitDate")%>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ساعت مشاهده" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Literal ID="Visit_time" runat="server" Text='<%#Eval("VisitTime")%>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="نوع سیستم عامل" ItemStyle-HorizontalAlign="Center"
                HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Literal ID="Visit_os" runat="server" Text='<%#Eval("VisitOs")%>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="آی پی" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Literal ID="Visit_ip" runat="server" Text='<%#Eval("VisitIp")%>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="نوع مرورگر" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Literal ID="Visit_browser" runat="server" Text='<%#Eval("VisitBrowser")%>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="نام کامپیوتر" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Literal ID="Visit_computername" runat="server" Text='<%#Eval("VisitComputername")%>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="حذف" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:ImageButton ID="Image3" runat="server" ImageUrl="~/Images/icon-pencil.gif" CommandName="del"
                        CausesValidation="false" CommandArgument='<%#CLSHash.Encode(Eval("VisitId"))%>'
                        OnClientClick="return confirm('آیا دستور حذف را تایید می کنید؟');" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
