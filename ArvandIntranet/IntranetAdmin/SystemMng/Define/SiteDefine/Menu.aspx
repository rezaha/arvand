<%@ Page Title="" Language="VB" MasterPageFile="~/SystemMng/MasterPage.master" AutoEventWireup="false"
    CodeFile="Menu.aspx.vb" Inherits="Menu" ClientIDMode="Static" %>

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
        Root = "../../";
    </script>
    <script language="javascript" type="text/javascript">
        Root = "";

        function ImgBtnSelectPersianPage_onclick() {
            $('#Page_Div').slideDown('medium', 'swing');
        }


        function btnSelectPage_onclick() {
            var pageId = $("#lbxPage").val();
            var select = $("#lbxPage").find("option:selected").text();
            if (pageId != null) {
                $("#<%=txtMenu_link_persian.ClientId%>").val("ShowPage/" + pageId + "/" + select);
                $('#Page_Div').slideUp('fast', 'swing');
            }
        }

        function btnClearPage_onclick() {
            $('#<%=txtMenu_link_persian.ClientId%>').val("");
        }

        function btnExitPage_onclick() {
            $('#Page_Div').slideUp('fast', 'swing');
        }


        //////////////////////




    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="form_container">
        <tr>
            <td colspan="2" class="tdInfoHeader">منو ها
            </td>
        </tr>
        <tr>
          
            <td colspan="2">
                <table>
                    <tr>
                        <td>
                            <table class="form_item">
                                <tr>
                                    <td class="form_item_text">لینک فعال
                                    </td>
                                    <td class="form_item_ctrl">
                                        <asp:CheckBox ID="chkActiveLink" runat="server" Checked="True" Text="فعال" />
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
                <table>
                    <tr>
                        <td>
                            <table class="form_item">
                                <tr>
                                    <td class="form_item_text">ترتیب
                                    </td>
                                    <td class="form_item_ctrl">
                                        <asp:TextBox ID="txtMenu_order" runat="server" CssClass="txtInfoLeft" onkeypress="return isNum(event);"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvMenu_order" runat="server" ErrorMessage="ترتیب1 در لیست وارد نشده است "
                                            Display="None" ControlToValidate="txtMenu_order" Text="*" ValidationGroup="p"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revMenu_order" ControlToValidate="txtMenu_order"
                                            Text="*" ErrorMessage=" فرمت ترتیب1 در لیست صحیح نمی باشد " Display="None" ValidationExpression="(^([0-9]*|\d*\d{1}?\d*)$)"
                                            runat="server" ValidationGroup="p"></asp:RegularExpressionValidator>
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
                                    <td class="form_item_text">والد
                                    </td>
                                    <td class="form_item_ctrl">
                                        <asp:DropDownList ID="drpMenu_parant" runat="server" CssClass="drp" AppendDataBoundItems="true"
                                            AutoPostBack="True">
                                            <asp:ListItem Selected="True">ندارد</asp:ListItem>
                                        </asp:DropDownList>
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
                <table>
                    <tr>
                        <td>
                            <table class="form_item">
                                <tr>
                                    <td class="form_item_text">متن منو</td>
                                    <td class="form_item_ctrl">
                                        <asp:TextBox ID="txtName_persian" runat="server" CssClass="txtInfoRight"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvName_persian" runat="server" ErrorMessage="نام وارد نشده است "
                                            Display="None" ControlToValidate="txtName_persian" Text="*" ValidationGroup="p"></asp:RequiredFieldValidator>
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
                                    <td class="form_item_text">لینک منو
                                    </td>
                                    <td class="form_item_ctrl">
                                        <asp:TextBox ID="txtMenu_link_persian" runat="server" CssClass="txtInfoLeft leftEn"
                                            Width="80%"></asp:TextBox>
                                        <img src="~/Images/icon/Currency.png" runat="server" id="ImgBtnSelectPersianPage" onclick="return ImgBtnSelectPersianPage_onclick()" />
                                        <asp:RequiredFieldValidator ID="rfvMenu_link_persian" runat="server" ErrorMessage="لینک منو فارسیوارد نشده است "
                                            Display="None" ControlToValidate="txtMenu_link_persian" Text="*" ValidationGroup="p"></asp:RequiredFieldValidator>
                                        <div id="Page_Div" style="display: none; position: absolute; z-index: 200; left:20%; background-color: #fff;">
                                            <table class="select_item_menu">
                                                <tr>
                                                    <td>
                                                        <input id="btnSelectPage" class="select_item" type="button" value="انتخاب" onclick="return btnSelectPage_onclick()" />
                                                    </td>
                                                    <td>
                                                        <input id="btnClearPage" class="select_item" type="button" value="پاک کردن فیلد"
                                                            onclick="return btnClearPage_onclick()" />
                                                    </td>
                                                    <td>
                                                        <input id="btnExitPage" class="select_item" type="button" value="خروج" onclick="return btnExitPage_onclick()" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        <asp:ListBox CssClass="listbox_selectpage" ID="lbxPage" ClientIDMode="Static" runat="server" Height="300px" Width="200"></asp:ListBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>

    </table>


    <table cellspacing="0" cellpadding="0" width="100%">
        <tr>
            <td colspan="2" align="center">
                <table cellpadding="5px">
                    <tr>
                        <td>
                            <asp:Button Text="اضافه" runat="server" ID="btnAdd" ValidationGroup="p" CssClass="btn-act act-add" />
                        </td>
                        <td>
                            <asp:Button Text="ذخیره" runat="server" ID="btnSave" ValidationGroup="p" CssClass="btn-act act-add" />
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
    <asp:HiddenField ID="HFPArentId" runat="server" />
    <asp:HiddenField ID="MenuId" runat="server" />
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
                        CommandName="up" CausesValidation="false" CommandArgument='<%#CLSHash.Encode(Eval("MenuId"))%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="متن منو" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Literal ID="Name_persian" runat="server" Text='<%#Eval("NamePersian")%>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="ترتیب" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Literal ID="Order" runat="server" Text='<%#Eval("MenuOrder")%>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="لینک فعال؟" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%#Eval("LinkActive")%>' />
                    <%--<asp:Literal ID="Link_active" runat="server" Text='<%#Eval("Link_active")%>'></asp:Literal>--%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="لینک منو فارسی" ItemStyle-HorizontalAlign="Center"
                HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="leftEn">
                <ItemTemplate>
                    <asp:Literal ID="Menu_link_persian" runat="server" Text='<%#Eval("MenuLinkPersian")%>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="حذف" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:ImageButton ID="imgbtnDelete" runat="server" ImageUrl="~/Images/icon-delete.gif"
                        CommandName="del" CausesValidation="false" CommandArgument='<%#CLSHash.Encode(Eval("MenuId"))%>'
                        OnClientClick="return confirm('آیا دستور حذف را تایید می کنید؟');" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
