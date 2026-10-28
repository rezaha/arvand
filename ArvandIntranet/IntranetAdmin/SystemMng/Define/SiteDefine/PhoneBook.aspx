<%@ Page Title="" Language="VB" MasterPageFile="~/SystemMng/MasterPage.master" AutoEventWireup="false"
    CodeFile="PhoneBook.aspx.vb" Inherits="PhoneBook" %>

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
        Root = "../";
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

  
    <table cellspacing="0" cellpadding="0" width="100%">
        <tr>
            <td class="tdInfoHeader" align="center" colspan="2">دفترچه تلفن</td>
        </tr>

        <tr style="padding-top: 10px">
            <td colspan="3">
                <table style="width: 100%">
                    <tr>
                        <td width="50%">
                            <table cellspacing="0" cellpadding="0" width="100%">
                                <tr>
                                    <td style="width: 50%">
                                        <table cellspacing="0" cellpadding="0" width="100%">

                                            <tr>
                                                <td class="tdInfoItem Infotxt" align="center">نام مخاطب *
                                                </td>
                                                <td class="tdInfoItem" align="right">
                                                    <asp:TextBox ID="txtPhonebookName" runat="server" CssClass="txtInfoRight"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdInfoItem Infotxt" align="center">واحد مخاطب&nbsp; *</td>
                                                <td class="tdInfoItem" align="right">
                                                    <asp:TextBox ID="txtPdoneBookPlant" runat="server" CssClass="txtInfoRight"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdInfoItem Infotxt" align="center">شماره تماس
                                        <img id="Img3" src="~/Images/NotNull.png" alt="NotNull" runat="server" />
                                                </td>
                                                <td class="tdInfoItem" align="right">
                                                    <asp:TextBox ID="txtPhonebookTel" runat="server" CssClass="txtInfoRight"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="شماره تماس وارد نشده است"
                                                        Display="None" ControlToValidate="txtPhonebookTel" Text="*" ValidationGroup="p"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>


                                </tr>
                            </table>
                        </td>
                        <td width="50%">
                            <table cellspacing="0" cellpadding="0" width="100%">
                                <tr>
                                    <td style="width: 50%">
                                        <table cellspacing="0" cellpadding="0" width="100%">

                                            <tr>
                                                <td class="tdInfoItem Infotxt" align="center">شماره فکس&nbsp;
                                                </td>
                                                <td class="tdInfoItem" align="right">
                                                    <asp:TextBox ID="txtPhoneBookFax" runat="server" CssClass="txtInfoRight"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdInfoItem Infotxt" align="center">آدرس ایمیل&nbsp;
                                                </td>
                                                <td class="tdInfoItem" align="right">
                                                    <asp:TextBox ID="txtPhoneBookEmail" runat="server" CssClass="txtInfoRight"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdInfoItem Infotxt" align="center">توضیحات&nbsp;
                                                </td>
                                                <td class="tdInfoItem" align="right">
                                                    <asp:TextBox ID="txtRemark" runat="server" CssClass="txtInfoRight"></asp:TextBox>
                                                </td>
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
            <td colspan="3" align="center">
                <table cellpadding="5px">
                    <tr>
                        <td>
                            <asp:Button Text="اضافه" runat="server" ID="btnAdd" ValidationGroup="p" CssClass="btn-act act-add" />
                        </td>
                        <td>
                            <asp:Button Text="ذخیره" runat="server" ID="btnSave" ValidationGroup="p" CssClass="btn-act act-edit" />
                        </td>
                        <td>
                            <asp:Button Text="لغو" runat="server" ID="btnClear" CssClass="btn-act act-clear" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="p"
        CssClass="Error"></asp:ValidationSummary>
    <asp:HiddenField ID="PhoneBookId" runat="server" />
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
                        CommandName="up" CausesValidation="false" CommandArgument='<%#CLSHash.Encode(Eval("PhonebookId"))%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="نام مخاطب" ItemStyle-HorizontalAlign="Center"
                HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Literal ID="Name" runat="server" Text='<%#Eval("PhonebookName")%>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="واحد مخاطب" ItemStyle-HorizontalAlign="Center"
                HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Literal ID="Plant" runat="server" Text='<%#Eval("PhonebookPlant")%>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="شماره تماس" ItemStyle-HorizontalAlign="Center"
                HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Literal ID="TelNo" runat="server" Text='<%#Eval("PhonebookTel")%>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="حذف" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:ImageButton ID="imgbtnDelete" runat="server" ImageUrl="~/Images/icon-delete.gif"
                        CommandName="del" CausesValidation="false" CommandArgument='<%#CLSHash.Encode(Eval("PhonebookId")) %>'
                        OnClientClick="return confirm('آیا دستور حذف را تایید می کنید؟');" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
