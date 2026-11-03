<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="SystemMng_Login"  MasterPageFile="~/MasterPages/Portal.master" %>
<asp:Content ID="PageBody" ContentPlaceHolderID="ContentPlaceHolder1" runat="server"><section class="portal-login"><p class="portal-kicker">پتروشیمی اروند</p><h1>ورود به مدیریت سامانه</h1>
    <div class="Login_bg">
        <div id="notification">
            <span class="userNote">پیام کاربری:</span>
            <asp:Label ID="Label1" runat="server">نام کاربری و کلمه عبور خود را وارد کنید</asp:Label>
        </div>
        <table cellpadding="2" cellspacing="2" class="login_table">
            <tr>
                <td class="login_title_ico">

                </td>
                <td class="login_title">
                    ورود کاربران
                </td>
            </tr>
            <tr>
                <td>
                    نام کاربری
                </td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtUserName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    کلمه عبور
                </td>
                <td>
                    <asp:TextBox CssClass="textbox" ID="txtPwd" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:CheckBox ID="chkRemember" runat="server" Text="مرا به خاطر بسپار" />
                </td>
            </tr>
            <tr>
                <td colspan="2" class="login_btn">
                    <asp:ImageButton ID="ImgBtnLogin" runat="server" ImageUrl="~/Images/portal/login.svg"
                        AlternateText="ورود به سامانه" CssClass="portal-login-submit" />
                </td>
            </tr>
            <tr>
                <td class="Login_error" colspan="2">
                    <asp:Label ID="lblError" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    </section></asp:Content>
