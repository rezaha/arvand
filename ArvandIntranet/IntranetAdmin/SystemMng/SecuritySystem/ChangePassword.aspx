<%@ Page Title="" Language="VB" MasterPageFile="~/SystemMng/MasterPage.master" AutoEventWireup="false" CodeFile="ChangePassword.aspx.vb" Inherits="SystemMng_SecuritySystem_ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
                                    <td>کلمه عبور قبلی
                                    </td>
                                    <td class="tdInfoItem" align="right">
                                        <asp:TextBox ID="txtOldPassword" lang="en" runat="server" Text="" TextMode="Password" Style="width: 200px;"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="txtOldPassword" Text="*" Display="Dynamic" ErrorMessage="کلمه عبور قبلی وارد نشده است" ValidationGroup="Doc" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>کلمه عبور جدید
                                    </td>
                                    <td class="tdInfoItem" align="right">
                                        <asp:TextBox ID="txtNewPassword" lang="en" runat="server" Text="" TextMode="Password" Style="width: 200px;"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNewPassword" Text="*" Display="Dynamic" ErrorMessage="کلمه عبور جدید وارد نشده است" ValidationGroup="Doc" ForeColor="Red"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>تکرار کلمه عبور جدیر
                                    </td>
                                    <td class="tdInfoItem" align="right">
                                        <asp:TextBox ID="txtReNewPassword" lang="en" runat="server" Text="" TextMode="Password" Style="width: 200px;"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtReNewPassword" Text="*" Display="Dynamic" ErrorMessage="تکرار کلمه عبور جدید وارد نشده است" ValidationGroup="Doc" ForeColor="Red"></asp:RequiredFieldValidator>
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
                                        <asp:Button Text="تغییر کلمه عبور" runat="server" Style="width: 100px; text-align: center;" ID="btnSave" ValidationGroup="Doc"
                                            CssClass="btn-act act-add" />
                                         <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="Doc" runat="server" ShowMessageBox="true" ShowSummary="false" />
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

