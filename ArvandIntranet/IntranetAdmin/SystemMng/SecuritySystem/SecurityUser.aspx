<%@ Page Title="" Language="VB" MasterPageFile="~/SystemMng/MasterPage.master" AutoEventWireup="false"
    CodeFile="SecurityUser.aspx.vb" Inherits="SecurityUser" %>

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
    <table cellspacing="3" cellpadding="3" width="100%">
        <tr>
            <td class="tdInfoHeader" align="center" colspan="2">کاربران
            </td>
        </tr>
        <tr>
            <td width="50%">
                <table cellspacing="3" cellpadding="3" width="100%">
                    <tr>
                        <td class="tdInfoItem" align="center">نام
                        </td>
                        <td class="tdInfoItem">
                            <asp:TextBox ID="txtFirstName" runat="server" CssClass="txtInfoRight"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="نام وارد نشده است"
                                Display="None" ControlToValidate="txtFirstName" Text="*"
                                ValidationGroup="Document"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdInfoItem Infotxt" align="center">نام کاربری
                            <img id="Img1" src="~/Images/NotNull.png" alt="NotNull" runat="server" />
                        </td>
                        <td class="tdInfoItem" align="right">
                            <asp:TextBox ID="txtUser_name" runat="server" CssClass="txtInfoRight"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvUser_name" runat="server" ErrorMessage="نام کاربری وارد نشده است "
                                Display="None" ControlToValidate="txtUser_name" Text="*" ValidationGroup="Document"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdInfoItem" align="center">واحد
                        </td>
                        <td class="tdInfoItem" align="right">
                            <asp:DropDownList ID="drpPlantDivision" runat="server" CssClass="drp"
                                AutoPostBack="True">
                                <asp:ListItem Selected="True">انتخاب کنید</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="واحد انتخاب نشده است"
                                Display="None" ControlToValidate="drpPlantDivision" Text="*" InitialValue="انتخاب کنید"
                                ValidationGroup="Document"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
                <%--        <table >
                   
                </table>--%>
            </td>
            <td width="50%">
                <table cellspacing="3" cellpadding="3" width="100%">
                    <tr>
                        <td class="tdInfoItem" align="center">نام خانوادگی</td>
                        <td class="tdInfoItem" colspan="2">
                            <asp:TextBox ID="txtlastName" runat="server" CssClass="txtInfoRight"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="نام خانوادگی وارد نشده است"
                                Display="None" ControlToValidate="txtlastName" Text="*"
                                ValidationGroup="Document"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdInfoItem Infotxt" align="center">رمزعبور
                            <img id="Img2" src="~/Images/NotNull.png" alt="NotNull" runat="server" />
                        </td>
                        <td class="tdInfoItem" align="right">
                            <asp:TextBox ID="txtUser_password" runat="server" CssClass="txtInfoRight"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvUser_password" runat="server" ErrorMessage="رمزعبوروارد نشده است "
                                Display="None" ControlToValidate="txtUser_password" Text="*" ValidationGroup="Document"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdInfoItem Infotxt" align="center">قفل؟
                            <img src="~/Images/NotNull.png" alt="NotNull" runat="server" />
                        </td>
                        <td class="tdInfoItem" align="right">
                            <asp:CheckBox ID="chkActive" runat="server" Text="فعال" />
                            <asp:CheckBox ID="chkAdmin" runat="server" Text="مدیر باشد؟" />
                        &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td width="50%">
                <table cellspacing="0" cellpadding="0" width="100%">
                </table>
            </td>
            <td width="50%">
                <table cellspacing="0" cellpadding="0" width="100%">
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
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Document"
        CssClass="Error"></asp:ValidationSummary>
    <asp:HiddenField ID="UserId" runat="server" />
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
                        CommandName="up" CausesValidation="false" CommandArgument='<%#CLSHash.Encode(Eval("UserId"))%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="واحد" ItemStyle-HorizontalAlign="Center"
                HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Literal ID="litName_persian" runat="server" Text='<%#Eval("PlantDivision.NamePersian")%>'></asp:Literal>&nbsp;
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="نام و نام خانوادگی" ItemStyle-HorizontalAlign="Center"
                HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Literal ID="litFirstName" runat="server" Text='<%#Eval("FirstName")%>'></asp:Literal>&nbsp;
                    <asp:Literal ID="litLastName" runat="server" Text='<%#Eval("LastName")%>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="نام کاربری" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Literal ID="User_name" runat="server" Text='<%#Eval("UserName")%>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="حذف" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:ImageButton ID="imgbtnDelete" runat="server" ImageUrl="~/Images/icon-delete.gif"
                        CommandName="del" CausesValidation="false" CommandArgument='<%#CLSHash.Encode(Eval("UserId"))%>'
                        OnClientClick="return confirm('آیا دستور حذف را تایید می کنید؟');" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
