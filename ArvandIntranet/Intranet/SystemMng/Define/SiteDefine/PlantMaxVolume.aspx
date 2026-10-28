<%@ Page Title="" Language="VB" MasterPageFile="~/SystemMng/MasterPage.master" AutoEventWireup="false" CodeFile="PlantMaxVolume.aspx.vb" Inherits="SystemMng_Define_SiteDefine_PlantMaxVolume" %>

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
            <td class="tdInfoHeader" align="center" colspan="3">حداکثر حجم آپلود واحد</td>
        </tr>
        <tr>
            <td>
                <div id="divTopShared">
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <table cellspacing="0" cellpadding="0" width="100%">
                    <tr>
                        <td>
                            <table cellspacing="0" cellpadding="0" width="100%">

                                <tr>
                                    <td class="tdInfoItem" align="right">کلیه مقادیر بر حسب کیلو بایت میباشد.
                                        <br />
                                        <br />

                                        <asp:GridView ID="grdMaxVolume" CssClass="user_divide" runat="server" AutoGenerateColumns="False">
                                            <Columns>
                                                <asp:BoundField DataField="NamePersian" HeaderText="نام واحد"></asp:BoundField>
                                                <asp:TemplateField HeaderText="حداکثر حجم">
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="hfDivisionId" runat="server" Value='<%#Eval("DivisionId")%>' />
                                                        <asp:TextBox ID="txtMaxDivisionVolume" Width="50" onFocus="this.select()" Style="text-align: left; direction: ltr;" onkeypress="return isNum(event);" MaxLength="7" lang="en" runat="server" ValidationGroup="itemST7"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="p" ControlToValidate="txtMaxDivisionVolume" Display="Dynamic" ForeColor="Red" runat="server" ToolTip="لطفا حجم را وارد نمایید." ErrorMessage="لطفا حجم را وارد نمایید.">*</asp:RequiredFieldValidator>
                                                        کیلوبایت
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </td>


                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="5px">
                                <tr>
                                    <td style="text-align: center;">
                                        <asp:Button Text="ذخیره" runat="server" Style="width: 100px; text-align: center;" ID="btnSave" ValidationGroup="p"
                                            CssClass="btn-act act-add" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>


</asp:Content>

