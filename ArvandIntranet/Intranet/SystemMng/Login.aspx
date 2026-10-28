<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="SystemMng_Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="css/LoginStyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="Login_bg">
        <div id="notification">
            <span class="userNote">پیام کاربری:</span>
            <asp:Label ID="Label1" runat="server">نام کاربری و کلمه عبور خود را وارد کنید</asp:Label>
        </div>
        <table cellpadding="2" cellspacing="2" class="login_table">
            <tr>
                <td class="login_title_ico">
                    <img id="Img1" src="~/SystemMng/Images/LoginImg/user_login.png" runat="server" alt="" />
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
                    <asp:ImageButton ID="ImgBtnLogin" runat="server" ImageUrl="~/SystemMng/Images/LoginImg/login_btn.png"
                        AlternateText="" />
                </td>
            </tr>
            <tr>
                <td class="Login_error" colspan="2">
                    <asp:Label ID="lblError" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
