<%@ Page Title="" Language="VB" MasterPageFile="~/SystemMng/MasterPage.master" AutoEventWireup="false"
    CodeFile="Albums.aspx.vb" Inherits="SystemMng_Albums" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<script src="../js/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../Script/CallBackScript.js" type="text/javascript"></script>
    <script src="../js/FilaManagerScript.js" type="text/javascript"></script>
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
    <div id="FileList-div" style="left: 20%; direction: ltr;">
        <table style="width: 500px; direction: ltr;">
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblAddress" runat="server" ClientIDMode="Static"></asp:Label>
                </td>
            </tr>
            <tr>
                <td id="TdImgPreview" style="height: 50px;" colspan="2">
                </td>
            </tr>
            <tr>
                <td>
                    <input id="btnSelectDir" type="button" value="انتخاب پوشه" onclick="return SelectDir();" />
                </td>
                <td>
                    <input id="btnExit" type="button" value="خروج" onclick="return document.getElementById('FileList-div').style.display = 'none';" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:ListBox ID="ListBoxDirs" ClientIDMode="Static" runat="server" Height="250px"
                        Width="250px" ondblclick="return ListBoxDirsdblclick();"></asp:ListBox>
                </td>
                <td>
                    <asp:ListBox ID="ListBoxFiles" ClientIDMode="Static" runat="server" Height="250px"
                        Width="290px" ondblclick="return ListBoxFilesdblclick();" onchange="return PreviewImg();">
                    </asp:ListBox>
                </td>
            </tr>
        </table>
    </div>
    <table cellspacing="0" cellpadding="0" width="100%">
        <tr>
            <td class="tdInfoHeader" align="center" colspan="2">
                آلبوم های عکس
            </td>
        </tr>
        <tr>
            <td width="50%">
                <table cellspacing="0" cellpadding="0" width="100%">
                    <tr>
                        <td class="tdInfoItem Infotxt" align="center">
                            تصویر آلبوم
                            <img id="Img4" src="~/Images/NotNull.png" alt="NotNull" runat="server" />
                        </td>
                        <td class="tdInfoItem" align="right">
                            <asp:TextBox ID="txtAlbumImage" runat="server" CssClass="txtInfoLeft" onfocus="return selectFile(this,1);"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="تصویر آلبوم وارد نشده است"
                                Display="None" ControlToValidate="txtAlbumImage" Text="*" ValidationGroup="Document"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdInfoItem Infotxt" align="center">
                            نام فارسی آلبوم
                            <img id="Img1" src="~/Images/NotNull.png" alt="NotNull" runat="server" />
                        </td>
                        <td class="tdInfoItem" align="right">
                            <asp:TextBox ID="txtName_persian" runat="server" CssClass="txtInfoRight"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvName_persian" runat="server" ErrorMessage="نام فارسی آلبوم وارد نشده است"
                                Display="None" ControlToValidate="txtName_persian" Text="*" ValidationGroup="Document"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdInfoItem Infotxt" align="center">
                            نام لاتین آلبوم
                            <img id="Img2" src="~/Images/NotNull.png" alt="NotNull" runat="server" />
                        </td>
                        <td class="tdInfoItem" align="right">
                            <asp:TextBox ID="txtName_latin" runat="server" CssClass="txtInfoLeft"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvName_latin" runat="server" ErrorMessage="نام لاتین آلبوم وارد نشده است"
                                Display="None" ControlToValidate="txtName_latin" Text="*" ValidationGroup="Document"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="50%">
                <table cellspacing="0" cellpadding="0" width="100%">
                    <tr>
                        <td class="tdInfoItem Infotxt" align="center">
                            شماره آلیوم
                            <img id="Img3" src="~/Images/NotNull.png" alt="NotNull" runat="server" />
                        </td>
                        <td class="tdInfoItem" align="right">
                            <asp:TextBox ID="txtAlbumNo" runat="server" CssClass="txtInfoRight" onkeypress="return isNum(event);"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvName_persian0" runat="server" ErrorMessage="شماره آلبوم وارد نشده است"
                                Display="None" ControlToValidate="txtAlbumNo" Text="*" ValidationGroup="Document"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdInfoItem Infotxt" align="center">
                            توضیحات
                        </td>
                        <td class="tdInfoItem" align="right">
                            <asp:TextBox ID="txtRemark" runat="server" CssClass="txtInfoRight"></asp:TextBox>
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
                                CssClass="btn-act act-edit" />
                        </td>
                        <td>
                            <asp:Button Text="لغو" runat="server" ID="btnClear" CssClass="btn-act act-clear" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="AlbumId" runat="server" />
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
                        CommandName="up" CausesValidation="false" CommandArgument='<%#CLSHash.Encode(Eval("AlbumId")) %>' /></ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="شماره آلبوم" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Literal ID="Name_persian" runat="server" Text='<%#Eval("AlbumNo")%>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="نام فارسی آلبوم" ItemStyle-HorizontalAlign="Center"
                HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Literal ID="Name_latin" runat="server" Text='<%#Eval("PersianName")%>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="نام لاتین آلبوم" ItemStyle-HorizontalAlign="Center"
                HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Literal ID="Remark" runat="server" Text='<%#Eval("LatinName")%>'></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="حذف" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:ImageButton ID="Image3" runat="server" ImageUrl="~/Images/icon-pencil.gif" CommandName="del"
                        CausesValidation="false" CommandArgument='<%#CLSHash.Encode(Eval("AlbumId")) %>'
                        OnClientClick="return confirm('آیا دستور حذف را تایید می کنید؟');" /></ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="تصاویر گالری" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <a href='AlbumImages.aspx?album=<%# DataBinder.Eval(Container.DataItem, "AlbumId") %>'>
                        تصاویر گالری</a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
