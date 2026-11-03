<%@ Page Title="مجوز دهی فرم ها" Language="VB" MasterPageFile="~/SystemMng/MasterPage.master"
    AutoEventWireup="false" CodeFile="SecurityFormsGranted.aspx.vb" Inherits="SecurityFormsGranted" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .tsInfoTemp
        {
            width: 10%;
            height: 30px;
            background-color: #eaedf4;
            border: solid 1px #c1c1d2;
        }
        .tsInfoTempLeft
        {
            width: 90%;
            height: 30px;
            background-color: #eaedf4;
            border: solid 1px #c1c1d2;
        }
        .showAll
        {
        }
    </style>
  
    <script type="text/javascript">
        var checkBoxSelector = '#<%=gridview1.ClientID%> input[id*="chk_SHOW_FORM"]:checkbox';
        var checkBoxSelector2 = '#<%=gridview1.ClientID%> input[id*="chk_INSERT_RECORD"]:checkbox';
        var checkBoxSelector3 = '#<%=gridview1.ClientID%> input[id*="chk_UPDATE_RECORD"]:checkbox';
        var checkBoxSelector4 = '#<%=gridview1.ClientID%> input[id*="chk_DELETE_RECORD"]:checkbox';
        var checkBoxSelector5 = '#<%=gridview1.ClientID%> input[id*="chk_SEARCH_RECORD"]:checkbox';
        var checkBoxSelector6 = '#<%=gridview1.ClientID%> input[id*="chk_PRINT_RECORD"]:checkbox';
        var checkBoxSelector7 = '#<%=gridview1.ClientID%> input[id*="chk_APPROVE"]:checkbox';
        var checkBoxSelector8 = '#<%=gridview1.ClientID%> input[id*="chk_ETC_ACTION"]:checkbox';

        $(document).ready(function () {
            $('#chk_SHOW_FORM_ALL').live('click', function () {
                if ($('#chk_SHOW_FORM_ALL').attr('checked')) {
                    $(checkBoxSelector).not(":disabled").attr('checked', true);
                }
                else {
                    $(checkBoxSelector).attr('checked', false);
                }
            });
            ////////////1
            $('#chk_INSERT_RECORD_ALL').live('click', function () {
                if ($('#chk_INSERT_RECORD_ALL').attr('checked')) {
                    $(checkBoxSelector2).not(":disabled").attr('checked', true);
                }
                else {
                    $(checkBoxSelector2).attr('checked', false);
                }
            });
            //////////2
            $('#chk_UPDATE_RECORD_ALL').live('click', function () {
                if ($('#chk_UPDATE_RECORD_ALL').attr('checked')) {
                    $(checkBoxSelector3).not(":disabled").attr('checked', true);
                }
                else {
                    $(checkBoxSelector3).attr('checked', false);
                }
            });
            ////////////3
            $('#chk_DELETE_RECORD_ALL').live('click', function () {
                if ($('#chk_DELETE_RECORD_ALL').attr('checked')) {
                    $(checkBoxSelector4).not(":disabled").attr('checked', true);
                }
                else {
                    $(checkBoxSelector4).attr('checked', false);
                }
            });
            //////////4
            $('#chk_SEARCH_RECORD_ALL').live('click', function () {
                if ($('#chk_SEARCH_RECORD_ALL').attr('checked')) {
                    $(checkBoxSelector5).not(":disabled").attr('checked', true);
                }
                else {
                    $(checkBoxSelector5).attr('checked', false);
                }
            });
            ////////////5
            $('#chk_PRINT_RECORD_ALL').live('click', function () {
                if ($('#chk_PRINT_RECORD_ALL').attr('checked')) {
                    $(checkBoxSelector6).not(":disabled").attr('checked', true);
                }
                else {
                    $(checkBoxSelector6).attr('checked', false);
                }
            });
            //////////6
            $('#chk_APPROVE_ALL').live('click', function () {
                if ($('#chk_APPROVE_ALL').attr('checked')) {
                    $(checkBoxSelector7).not(":disabled").attr('checked', true);
                }
                else {
                    $(checkBoxSelector7).attr('checked', false);
                }
            });
            ////////////7
            $('#chk_ETC_ACTION_ALL').live('click', function () {
                if ($('#chk_ETC_ACTION_ALL').attr('checked')) {
                    $(checkBoxSelector8).not(":disabled").attr('checked', true);
                }
                else {
                    $(checkBoxSelector8).attr('checked', false);
                }
            });
            //////////8
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="DivBody">
                <table id="tblSecurityForms" class="tblInfo" cellspacing="0" cellpadding="2" width="100%">
                    <tbody>
                        <tr>
                            <td colspan="2" class="tdInfoHeader" id="tblheader">
                                مجوز دهی فرم ها
                            </td>
                        </tr>
                        <tr>
                            <td class="tdright">
                                <table class="tblInfo" id="Table1" cellspacing="0" cellpadding="2" width="100%">
                                    <tbody>
                                        <tr>
                                            <td class="tsInfoTemp">
                                                نام کاربر
                                            </td>
                                            <td class="tsInfoTempLeft">
                                                <asp:DropDownList ID="drpSecurityUser" runat="server" style="font-family:Tahoma;font-size:11px;" AutoPostBack="True">
                                                    <asp:ListItem>انتخاب کنید</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="drpSecurityUser"
                                                    Text="*" Display="None" ErrorMessage="نام کاربر انتخاب نشده است" ValidationGroup="Document"
                                                    InitialValue="انتخاب کنید"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="center">
                                                <table cellpadding="5px">
                                                    <tr>
                                                        <td>
                                                            <asp:Button Text="ذخیره تغییرات" runat="server" ID="btnSave" CssClass="btn-act act-add" ValidationGroup="Document" Width="150px"/>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <br />
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <table class="LoadAjax">
                            <tr>
                                <td>
                                    درحال پردازش اطلاعات ...
                                </td>
                            </tr>
                        </table>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <br />
                <div id="divError">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Document"
                        ForeColor="Red" />
                </div>
                <asp:HiddenField ID="hfldFormPermission" runat="server" />
                <asp:HiddenField ID="hfldUserId" runat="server" />
                &nbsp;
                <asp:GridView ID="gridview1" runat="server" Width="100%" AutoGenerateColumns="false" CssClass="grid"
                    ShowFooter="true" BorderColor="White" BorderStyle="Ridge" CellSpacing="1" BorderWidth="2px"
                    BackColor="White" CellPadding="3" GridLines="None" Font-Names="Tahoma" Font-Size="11px"
                    EmptyDataText="داده وجود ندارد...">
                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                    <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#9471DE" Font-Bold="true" ForeColor="White" />
                    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                    <HeaderStyle CssClass="grid" Font-Size="8px" />
                    <SelectedRowStyle BackColor="#DEDFDE" Font-Italic="false" ForeColor="Black" Font-Bold="false"
                        Font-Size="11px" />
                    <AlternatingRowStyle BackColor="AliceBlue" />
                    <Columns>
                        <asp:TemplateField HeaderText="دسترسی به فرم" HeaderStyle-HorizontalAlign="Center"
                            ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                            <HeaderTemplate>
                                <table>
                                    <tr>
                                        <td style="text-align: center;">
                                            نام فرم
                                            <br />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                            <br />
                                        </td>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbl_FORM_TITLE" runat="server" Text='<%#Eval("FormTitle") %>'></asp:Label>
                                <asp:Label ID="lbl_GRANT_ID" runat="server" Text='<%#Eval("FormPermisionId") %>' Visible="false"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="مجوز ها" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"
                            FooterStyle-HorizontalAlign="Right">
                            <HeaderTemplate>
                                <table>
                                    <tr>
                                        <td style="text-align: center;">
                                            مجوز ها
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table>
                                                <tr>
                                                    <td style="width: 100px; text-align:right;">
                                                        <asp:CheckBox ID="chk_SHOW_FORM_ALL" runat="server" Text="همه" ClientIDMode="Static" />
                                                    </td>
                                                    <td style="width: 100px; text-align:right;">
                                                        <asp:CheckBox ID="chk_INSERT_RECORD_ALL" runat="server" Text="همه" ClientIDMode="Static" />
                                                    </td>
                                                    <td style="width: 100px; text-align:right;">
                                                        <asp:CheckBox ID="chk_UPDATE_RECORD_ALL" runat="server" Text="همه" ClientIDMode="Static" />
                                                    </td>
                                                    <td style="width: 100px; text-align:right;">
                                                        <asp:CheckBox ID="chk_DELETE_RECORD_ALL" runat="server" Text="همه" ClientIDMode="Static" />
                                                    </td>
                                                    <td style="width: 100px; text-align:right;">
                                                        <asp:CheckBox ID="chk_SEARCH_RECORD_ALL" runat="server" Text="همه" ClientIDMode="Static" />
                                                    </td>
                                                    <td style="width: 100px; text-align:right;">
                                                        <asp:CheckBox ID="chk_PRINT_RECORD_ALL" runat="server" Text="همه" ClientIDMode="Static" />
                                                    </td>
                                                    <td style="width: 100px; text-align:right;">
                                                        <asp:CheckBox ID="chk_APPROVE_ALL" runat="server" Text="همه" ClientIDMode="Static" />
                                                    </td>
                                                    <td style="width: 100px; text-align:right;">
                                                        <asp:CheckBox ID="chk_ETC_ACTION_ALL" runat="server" Text="همه" ClientIDMode="Static" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <table>
                                    <tr>
                                        <td style="width: 100px;">
                                            <asp:CheckBox ID="chk_SHOW_FORM" runat="server" Text="نمایش" />
                                        </td>
                                        <td style="width: 100px;">
                                            <asp:CheckBox ID="chk_INSERT_RECORD" runat="server" Text="اضافه" Enabled='<%#Eval("InsertRecord ")%>' />
                                        </td>
                                        <td style="width: 100px;">
                                            <asp:CheckBox ID="chk_UPDATE_RECORD" runat="server" Text="ویرایش" Enabled='<%#Eval("UpdateRecord ")%>' />
                                        </td>
                                        <td style="width: 100px;">
                                            <asp:CheckBox ID="chk_DELETE_RECORD" runat="server" Text="حذف" Enabled='<%#Eval("DeleteRecord ")%>' />
                                        </td>
                                        <td style="width: 100px;">
                                            <asp:CheckBox ID="chk_SEARCH_RECORD" runat="server" Text="جستجو" Enabled='<%#Eval("SearchRecord") %>' />
                                        </td>
                                        <td style="width: 100px;">
                                            <asp:CheckBox ID="chk_PRINT_RECORD" runat="server" Text="چاپ" Enabled='<%#Eval("PrintRecord") %>' />
                                        </td>
                                        <td style="width: 100px;">
                                            <asp:CheckBox ID="chk_APPROVE" runat="server" Text="تایید" Enabled='<%#Eval("ApproveAction") %>' />
                                        </td>
                                        <td style="width: 100px;">
                                            <asp:CheckBox ID="chk_ETC_ACTION" runat="server" Text="دیگر مجوز ها" Enabled='<%#Eval("EtcAction ") %>' />
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
