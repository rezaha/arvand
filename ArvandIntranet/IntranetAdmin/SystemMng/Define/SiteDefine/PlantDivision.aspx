<%@ Page Title="" Language="VB" MasterPageFile="~/SystemMng/MasterPage.master" AutoEventWireup="false" CodeFile="PlantDivision.aspx.vb" Inherits="SystemMng_Define_SiteDefine_PlantDivision" %>

<%@ Register Src="~/SystemMng/UserControls/WindowWUC.ascx" TagPrefix="uc1" TagName="WindowWUC" %>


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

        function ClosePopupWindow() {
            var oWnd = GetRadWindow();
            oWnd.close();
            return false;
        }
        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow)
                oWindow = window.radWindow;
            else if (window.frameElement.radWindow)
                oWindow = window.frameElement.radWindow;
            return oWindow;
        }


        function OpenFileExplorerDialog() {
            ShowForm('<%=GetRouteUrl("default-rout", New With {.pageName = "Explorer", .id = "1"})%>', 600, 600);
        }

        function ClearTextBox() {
            var textbox = $("#txtDivisionLogo");
            textbox.val("");
        }
        function AfterWindowsClose() {
        }
        //This function is called from a code declared on the Explorer.aspx page
        function OnFileSelected(fileSelected) {
            var textbox = $("#txtDivisionLogo");
            textbox.val(fileSelected);
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <table cellspacing="0" style="margin-top:10px;" cellpadding="0" width="100%">
        <tr>
            <td class="tdInfoHeader" align="center" colspan="2">واحد ها
            </td>
        </tr>
        <tr>
            <td width="50%">
                <table cellspacing="3" cellpadding="3" width="100%">
                    <tr>
                        <td class="tdInfoItem Infotxt"  align="center">نام واحد<img id="Img1" src="~/Images/NotNull.png" alt="NotNull" runat="server" />
                        </td>
                        <td class="tdInfoItem" align="right">
                            <asp:TextBox ID="txtPersianName" runat="server" CssClass="txtInfoRight"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="نام فارسی وارد نشده است "
                                Display="None" ControlToValidate="txtPersianName" Text="*" ValidationGroup="Document"></asp:RequiredFieldValidator>
                        </td>
                    </tr>

                </table>
            </td>
            <td width="50%">
                <table cellspacing="0" cellpadding="0" width="100%">
                    <tr>
                        <td class="tdInfoItem Infotxt" align="center">ترتیب در لیست
                            <img id="Img4" src="~/Images/NotNull.png" alt="NotNull" runat="server" />
                        </td>
                        <td class="tdInfoItem" align="right">
                            <asp:TextBox ID="txtOrder" runat="server" CssClass="txtInfoLeft" onkeypress="return isNum(event);"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvSite_order" runat="server" ErrorMessage="ترتیب در لیست وارد نشده است "
                                Display="None" ControlToValidate="txtOrder" Text="*" ValidationGroup="Document"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revSite_order" ControlToValidate="txtOrder"
                                Text="*" ErrorMessage=" فرمت ترتیب در لیست صحیح نمی باشد " Display="None" ValidationExpression="(^([0-9]*|\d*\d{1}?\d*)$)"
                                runat="server" ValidationGroup="Document"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table cellspacing="4" cellpadding="4" style="margin-top:15px;" width="100%">
                    <tr>
                        <td style="width:9%" align="center">لوگو واحد</td>
                        <td class="tdInfoItem" align="right">
                            <asp:TextBox ID="txtDivisionLogo" runat="server" style="width:80%; direction:ltr; text-align:left;" OnClick="OpenFileExplorerDialog(); return false;" ClientIDMode="Static"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="آیکون کوچک وارد نشده است"
                                Display="None" ControlToValidate="txtDivisionLogo" Text="*" ValidationGroup="Document"></asp:RequiredFieldValidator>
                            <asp:Button ID="btnClearImageAddress" CssClass="act-orange" OnClientClick="ClearTextBox(); return false;"
                                Text="پاک کردن" runat="server" />
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
                            <asp:Button Text="ذخیره" runat="server" ID="btnSave" ValidationGroup="Document" CssClass="btn-act act-add" />
                        </td>
                        <td>
                            <asp:Button Text="لغو" runat="server" ID="btnClear" CssClass="btn-act act-add" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="HFDivisionId" runat="server" />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Document"
        CssClass="Error"></asp:ValidationSummary>
    <asp:GridView ID="gridview1" runat="server" CssClass="grid" GridLines="None" AutoGenerateColumns="False"
        EmptyDataText="داده وجود ندارد..." ShowFooter="false" BackColor="White" BorderColor="White"
        BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1">
        <RowStyle CssClass="row" />
        <AlternatingRowStyle CssClass="altrow" />
        <SelectedRowStyle CssClass="selectedrow" />
        <Columns>
            <asp:TemplateField HeaderText="ویرایش" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:ImageButton ID="Image31" runat="server" ImageUrl="~/Images/icon-pencil.gif"
                        CommandName="up" CausesValidation="false" CommandArgument='<%#CLSHash.Encode(Eval("DivisionId"))%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="نام فارسی" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Literal ID="Division_id" runat="server" Text='<%#Eval("NamePersian")%>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ترتیب در لیست" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Literal ID="Site_link" runat="server" Text='<%#Eval("DivisionOrder")%>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="حذف" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:ImageButton ID="Image3" runat="server" ImageUrl="~/Images/icon-delete.gif" CommandName="del"
                        CausesValidation="false" CommandArgument='<%#CLSHash.Encode(Eval("DivisionId"))%>'
                        OnClientClick="return confirm('آیا دستور حذف را تایید می کنید؟');" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <uc1:WindowWUC runat="server" ID="WindowWUC" />
</asp:Content>
