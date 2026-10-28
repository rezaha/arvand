<%@ Page Title="" Language="VB" MasterPageFile="~/SystemMng/MasterPage.master" AutoEventWireup="false"
    CodeFile="UserWebPart.aspx.vb" Inherits="SystemMng_Define_SiteDefine_UserWebPart" %>

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
    <table cellspacing="0" cellpadding="0" width="100%">
        <tr>
            <td class="tdInfoHeader" align="center" colspan="2">وب پارت کاربری</td>
        </tr>
        <tr>
            <td colspan="2">
                <table cellspacing="0" cellpadding="0" width="100%">
                    <tr>
                        <td>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="tdInfoItem Infotxt" align="center">عنوان وب پارت
                            <img id="Img7" src="~/Images/NotNull.png" alt="NotNull" runat="server" />
                        </td>
                        <td class="tdInfoItem" align="right">
                            <asp:TextBox ID="txtHeader_persian" runat="server" CssClass="txtInfoRight"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvHeader_persian" runat="server" ErrorMessage="عنوان فارسی وارد نشده است"
                                Display="None" ControlToValidate="txtHeader_persian" Text="*" ValidationGroup="p"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table cellspacing="0" cellpadding="0" width="100%">
                    <tr>
                                             <td class="tdInfoItem Infotxt" align="right">متن وب پارت
                            <img id="Img8" src="~/Images/NotNull.png" alt="NotNull" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td class="tdInfoItem" align="right">
                            <telerik:RadEditor runat="server" ID="txtHtml_content_persian" Language="fa-IR" SkinID="DefaultSetOfTools" Height="700px"
                                DialogsCssFile="../Css/Editor/RadEditor_Dialogs_RTL.css"
                                ContentAreaCssFile="../Css/Editor/EditorContentArea_RTL.css"
                                ToolsFile="EditorToolsFileLimited.xml" DialogHandlerUrl="~/Telerik.Web.UI.DialogHandler.axd">
                                <ImageManager EnableAsyncUpload="true"></ImageManager>
                                <DocumentManager EnableAsyncUpload="true"></DocumentManager>
                            </telerik:RadEditor>
                            <asp:RequiredFieldValidator ID="rfvHtml_content_persian" runat="server" ErrorMessage="متن فارسی وارد نشده است"
                                Display="None" ControlToValidate="txtHtml_content_persian" Text="*" ValidationGroup="p"></asp:RequiredFieldValidator>
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
                            <asp:Button Text="اضافه" runat="server" ID="btnAdd" ValidationGroup="p"
                                CssClass="btn-act act-add" />
                        </td>
                        <td>
                            <asp:Button Text="ذخیره تغییرات" runat="server" ID="btnSave" ValidationGroup="p"
                                CssClass="btn-act act-add" />
                        </td>
                        <td>
                            <asp:Button Text="لغو" runat="server" ID="btnClear" CssClass="btn-act act-add" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="p"
        CssClass="Error"></asp:ValidationSummary>
    <asp:HiddenField ID="WebPartId" runat="server" />
    <asp:GridView ID="gridview1" runat="server" CssClass="grid" GridLines="None" AutoGenerateColumns="False"
        EmptyDataText="داده وجود ندارد..." ShowFooter="false" BackColor="White" BorderColor="White"
        BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1">
        <RowStyle CssClass="row" />
        <AlternatingRowStyle CssClass="altrow" />
        <SelectedRowStyle CssClass="selectedrow" />
        <Columns>
            <asp:TemplateField HeaderText="ویرایش" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:ImageButton ID="imgbtnEdit" runat="server" ImageUrl="~/Images/icon-pencil.gif"
                        CommandName="up" CausesValidation="false" CommandArgument='<%#CLSHash.Encode(Eval("Webpart_id"))%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="عنوان" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Literal ID="Header_persian" runat="server" Text='<%#Eval("Header_persian")%>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="فعال" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:CheckBox runat="server" Enabled="false" Checked='<%#Eval("Active")%>'></asp:CheckBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="حذف" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:ImageButton ID="imgbtnDelete" runat="server" ImageUrl="~/Images/icon-delete.gif"
                        CommandName="del" CausesValidation="false" CommandArgument='<%#CLSHash.Encode(Eval("Webpart_id")) %>'
                        OnClientClick="return confirm('آیا دستور حذف را تایید می کنید؟');" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
