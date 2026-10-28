<%@ Page Title="" Language="VB" MasterPageFile="~/SystemMng/MasterPage.master" AutoEventWireup="false"
    CodeFile="MainGallery.aspx.vb" Inherits="SystemMng_Other_MainGallery" %>

<%@ Register Src="~/SystemMng/UserControls/WindowWUC.ascx" TagPrefix="uc1" TagName="WindowWUC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../../../Scripts/jquery-1.9.1.min.js" type="text/javascript"></script>

    <script type="text/javascript">

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
            ShowForm('<%=GetRouteUrl("default-rout", New With {.pageName = "Explorer", .id = 1})%>', 600, 600);
        }

        function ClearTextBox() {
            var textbox = $("#txtImageAddress");
            textbox.val("");
        }
        function AfterWindowsClose() {
        }
        //This function is called from a code declared on the Explorer.aspx page
        function OnFileSelected(fileSelected) {
            var textbox = $("#txtImageAddress");
            textbox.val(fileSelected);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc1:WindowWUC runat="server" ID="WindowWUC" />
    <table cellspacing="4" cellpadding="4" width="100%">
        <tr>
            <td class="tdInfoHeader" align="center" colspan="2">گالری تصاویر صفحه اصلی
            </td>
        </tr>
        <tr>
            <td>
                <table cellspacing="0" cellpadding="0" width="100%">
                    <tr>
                        <td class="tdInfoItem Infotxt" align="center">آلبوم
                            <img id="Img1" src="~/Images/NotNull.png" alt="NotNull" runat="server" />
                        </td>
                        <td class="tdInfoItem" align="right">
                            <asp:Label ID="lblAlbumName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdInfoItem Infotxt" align="center">آدرس عکس
                            <img id="Img2" src="~/Images/NotNull.png" alt="NotNull" runat="server" />
                        </td>
                        <td class="tdInfoItem" align="right">
                            <asp:TextBox ID="txtImageAddress" runat="server" style="width:300px; text-align:left; direction:ltr;" OnClick="OpenFileExplorerDialog(); return false;" ClientIDMode="Static"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvName_persian" runat="server" ErrorMessage="آدرس عکس وارد نشده است"
                                Display="None" ControlToValidate="txtImageAddress" Text="*" ValidationGroup="Document"></asp:RequiredFieldValidator>
                            <asp:Button ID="btnClearImageAddress" CssClass="act-orange" OnClientClick="ClearTextBox(); return false;"
                                Text="پاک کردن" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-top:10px;" class="tdInfoItem Infotxt" align="center">توضیح&nbsp; عکس</td>
                        <td style="padding-top:10px;" class="tdInfoItem" align="right">
                            <asp:TextBox ID="txtPerDes" runat="server" style="width:300px;" CssClass="txtInfoRight"></asp:TextBox>
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
                            <asp:Button Text="ویرایش" runat="server" ID="btnSave" ValidationGroup="Document"
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
    <asp:HiddenField ID="ImageId" runat="server" />
    <asp:HiddenField ID="hfldAlbumId" runat="server" />
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
                    <asp:ImageButton ID="Image3" runat="server" ImageUrl="~/Images/icon-pencil.gif" CommandName="up"
                        CausesValidation="false" CommandArgument='<%#CLSHash.Encode(Eval("ImageId")) %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="آلبوم" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Literal ID="AlbumId" runat="server" Text='<%#Eval("Album.AlbumId")%>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="آدرس عکس" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Literal ID="ImageAddress" runat="server" Text='<%#Eval("ImageAddress")%>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="توضیحات" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Literal ID="Remark" runat="server" Text='<%#Eval("Remark")%>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="حذف" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:ImageButton ID="Image31" runat="server" ImageUrl="~/Images/icon-delete.gif"
                        CommandName="del" CausesValidation="false" CommandArgument='<%#CLSHash.Encode(Eval("ImageId")) %>'
                        OnClientClick="return confirm('آیا دستور حذف را تایید می کنید؟');" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
