<%@ Page Title="" Language="VB" MasterPageFile="~/SystemMng/MasterPage.master" AutoEventWireup="false"
    CodeFile="LogicalPage.aspx.vb" Inherits="SystemMng_Define_SiteDefine_LogicalPage" %>

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
            <td class="tdInfoHeader" align="center" colspan="2">صفحه ها
            </td>
        </tr>
        <tr>
            <td>
                <table class="form_container">
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <table class="form_item">
                                            <tr>
                                                <td class="form_item_text">نام صفحه
                                                </td>
                                                <td class="form_item_ctrl">
                                                    <asp:TextBox ID="txtPage_file_name" runat="server" CssClass="txtInfoLeft"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvPage_file_name" runat="server" ErrorMessage="نام صفحه وارد نشده است "
                                                        Display="None" ControlToValidate="txtPage_file_name" Text="*" ValidationGroup="p"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <table class="form_item">
                                            <tr>
                                                <td class="form_item_text">عنوان صفحه
                                                </td>
                                                <td class="form_item_ctrl">
                                                    <asp:TextBox ID="txtPage_title" runat="server" CssClass="txtInfoRight"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvPage_title" runat="server" ErrorMessage="عنوان صفحه وارد نشده است "
                                                        Display="None" ControlToValidate="txtPage_title" Text="*" ValidationGroup="p"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <table class="form_container">
                                <tr>
                                    <td>
                                        <table>
                                            <tr>
                                                <td>
                                                    <table class="form_item">
                                                        <tr>
                                                            <td class="form_item_text">فعال؟
                                                            </td>
                                                            <td class="form_item_ctrl">
                                                                <asp:CheckBox ID="chkActive" runat="server" Checked="True" Text="فعال" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td>
                                        <table>
                                            <tr>
                                                <td>
                                                    <table class="form_item">
                                                        <tr>
                                                            <td class="form_item_text"></td>
                                                            <td class="form_item_ctrl"></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>

                            </table>

                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <table cellspacing="0" cellpadding="0" width="100%">
                                <tr>
                                    <td width="100%">
                                        <table cellspacing="0" cellpadding="0" width="100%">
                                            <tr>
                                                <td class="tdInfoItem Infotxt" align="right" style="width: 120px;">خلاصه صفحه</td>
                                            </tr>
                                            <tr>

                                                <td class="tdInfoItem" align="right">
                                                    <asp:TextBox ID="txtSummary" Width="100%" Height="150px" runat="server" Font-Names="Tahoma" Font-Size="11px" TextMode="MultiLine"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvPage_Persian_Content" runat="server" ErrorMessage="خلاصه صفحه وارد نشده است"
                                                        Display="None" ControlToValidate="txtSummary" Text="*" ValidationGroup="p"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <table cellspacing="0" cellpadding="0" width="100%">
                                <tr>
                                    <td width="100%">
                                        <table cellspacing="0" cellpadding="0" width="100%">
                                            <tr>
                                                <td class="tdInfoItem Infotxt" align="right" style="width: 120px;">محتوای صفحه
                                                </td>
                                            </tr>
                                            <tr>

                                                <td class="tdInfoItem" align="right">
                                                    <telerik:RadEditor runat="server" ID="txtPage_Latin_Content" Language="fa-IR" SkinID="DefaultSetOfTools" Height="700px"
                                                        DialogsCssFile="../Css/Editor/RadEditor_Dialogs_RTL.css"
                                                        ContentAreaCssFile="../Css/Editor/EditorContentArea_RTL.css"
                                                        ToolsFile="EditorToolsFileLimited.xml" DialogHandlerUrl="~/Telerik.Web.UI.DialogHandler.axd">
                                                        <ImageManager EnableAsyncUpload="true"></ImageManager>
                                                        <DocumentManager EnableAsyncUpload="true"></DocumentManager>
                                                    </telerik:RadEditor>

                                                    <asp:RequiredFieldValidator ID="rfvPage_Latin_Content" runat="server" ErrorMessage="محتوای صفحه وارد نشده است"
                                                        Display="None" ControlToValidate="txtPage_Latin_Content" Text="*" ValidationGroup="p"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                        </table>
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
                                        <asp:Button Text="اضافه" runat="server" ID="btnAdd" ValidationGroup="p" CssClass="btn-act act-add" />
                                    </td>
                                    <td>
                                        <asp:Button Text="ذخیره" runat="server" ID="btnSave" ValidationGroup="p"
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
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="ValidationSummary1" ShowMessageBox="true" ShowSummary="false" runat="server" ValidationGroup="p"
        CssClass="Error"></asp:ValidationSummary>
    <asp:HiddenField ID="PageId" runat="server" />
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
                        CommandName="up" CausesValidation="false" CommandArgument='<%#CLSHash.Encode(Eval("PageId"))%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="نام صفحه" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Literal ID="Page_file_name" runat="server" Text='<%#Eval("PageFileName")%>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="عنوان فارسی صفحه" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Literal ID="Page_title" runat="server" Text='<%#Eval("PageTitle")%>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="حذف" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:ImageButton ID="imgbtnDelete" runat="server" ImageUrl="~/Images/icon-delete.gif"
                        CommandName="del" CausesValidation="false" CommandArgument='<%#CLSHash.Encode(Eval("PageId")) %>'
                        OnClientClick="return confirm('آیا دستور حذف را تایید می کنید؟');" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
