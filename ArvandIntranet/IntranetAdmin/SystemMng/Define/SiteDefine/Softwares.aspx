<%@ Page Title="" Language="VB" MasterPageFile="~/SystemMng/MasterPage.master" AutoEventWireup="false" CodeFile="Softwares.aspx.vb" Inherits="SystemMng_Define_SiteDefine_Softwares" %>

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
            var textbox = $("#txtSoftwareSmallIcon");
            textbox.val("");
        }
        function AfterWindowsClose() {
        }
        //This function is called from a code declared on the Explorer.aspx page
        function OnFileSelected(fileSelected) {
            var textbox = $("#txtSoftwareSmallIcon");
            textbox.val(fileSelected);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc1:WindowWUC runat="server" ID="WindowWUC" />

    <table cellspacing="2" cellpadding="2" width="100%">
        <tr>
            <td class="tdInfoHeader" align="center" colspan="2">لینک های پر کاربرد
            </td>
        </tr>
        <tr>
            <td width="50%">
                <table cellspacing="0" cellpadding="0" width="100%">

                    <tr>
                        <td class="tdInfoItem Infotxt" style="width:90px;" align="center">آدرس لینک
                            <img id="Img2" src="~/Images/NotNull.png" alt="NotNull" runat="server" />
                        </td>
                        <td class="tdInfoItem"  align="right">
                            <asp:TextBox ID="txtSoftwareUrl" runat="server" style="text-align:left; direction:ltr;"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvSoftwareUrl" runat="server" ErrorMessage="لینک نرم افزار وارد نشده است "
                                Display="None" ControlToValidate="txtSoftwareUrl" Text="*" ValidationGroup="Document"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
            <td width="50%">
                <table cellspacing="0" cellpadding="0" width="100%">
                    <tr>
                        <td class="tdInfoItem Infotxt" style="width:90px" align="center">ترتیب در لیست
                            <img id="Img3" src="~/Images/NotNull.png" alt="NotNull" runat="server" />
                        </td>
                        <td class="tdInfoItem" align="right">
                            <asp:TextBox ID="txtSite_order" runat="server" CssClass="txtInfoLeft" onkeypress="return isNum(event);"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvSite_order" runat="server" ErrorMessage="ترتیب در لیست وارد نشده است "
                                Display="None" ControlToValidate="txtSite_order" Text="*" ValidationGroup="Document"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revSite_order" ControlToValidate="txtSite_order"
                                Text="*" ErrorMessage=" فرمت ترتیب در لیست صحیح نمی باشد " Display="None" ValidationExpression="(^([0-9]*|\d*\d{1}?\d*)$)"
                                runat="server" ValidationGroup="Document"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td width="50%">
                <table cellspacing="0" cellpadding="0" width="100%">
                    <tr>
                        <td class="tdInfoItem Infotxt" style="width:90px;" align="center">نام لینک
                            <img id="Img4" src="~/Images/NotNull.png" alt="NotNull" runat="server" />
                        </td>
                        <td class="tdInfoItem" align="right">
                            <asp:TextBox ID="txtSoftwareName" runat="server" CssClass="txtInfoRight"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvSoftwareName" runat="server" ErrorMessage="نام نرم افزار وارد نشده است "
                                Display="None" ControlToValidate="txtSoftwareName" Text="*" ValidationGroup="Document"></asp:RequiredFieldValidator>
                        </td>
                    </tr>

                </table>
            </td>
            <td width="50%">
                <table cellspacing="0" cellpadding="0" width="100%">
                    <tr>
                        <td class="tdInfoItem Infotxt" style="width:90px;" align="center">آیکون</td>
                        <td class="tdInfoItem" align="right">
                            <asp:TextBox ID="txtSoftwareSmallIcon" runat="server" CssClass="txtInfoLeft" OnClick="OpenFileExplorerDialog(); return false;" ClientIDMode="Static"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="آیکون کوچک وارد نشده است"
                                Display="None" ControlToValidate="txtSoftwareSmallIcon" Text="*" ValidationGroup="Document"></asp:RequiredFieldValidator>
                            <asp:Button ID="btnClearImageAddress" CssClass="act-orange" OnClientClick="ClearTextBox(); return false;"
                                Text="پاک کردن" runat="server" />
                            <%-- <asp:FileUpload ID="Persian_Logo" runat="server" Width="466px" CssClass="txtInfoLeft" />
                            &nbsp;&nbsp;
                            <asp:Image ID="imgPLogo" runat="server" Height="0px" Width="20px" />--%>
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
                            <asp:Button Text="اضافه" runat="server" ID="btnAdd" ValidationGroup="Document" CssClass="btn-act act-add" />
                        </td>
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
    <asp:HiddenField ID="hfldSoftwareId" runat="server" />
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
                        CommandName="up" CausesValidation="false" CommandArgument='<%#Eval("SoftwareId")%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="نام لینک" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Literal ID="litSoftwareName" runat="server" Text='<%#Eval("SoftwareName")%>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="آدرس لینک" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Literal ID="litSoftwareUrl" runat="server" Text='<%#Eval("SoftwareUrl")%>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ترتیب در لیست" ItemStyle-HorizontalAlign="Center"
                HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Literal ID="Site_order" runat="server" Text='<%#Eval("SortOrder")%>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="حذف" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:ImageButton ID="Image3" runat="server" ImageUrl="~/Images/icon-delete.gif" CommandName="del"
                        CausesValidation="false" CommandArgument='<%#Eval("SoftwareId")%>'
                        OnClientClick="return confirm('آیا دستور حذف را تایید می کنید؟');" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>


