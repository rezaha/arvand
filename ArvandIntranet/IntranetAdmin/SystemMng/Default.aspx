<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default"
    Title="پرتال دانش- شرکت دانش افزار ماهان" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="css/DefaultStyle.css" rel="stylesheet" type="text/css" />
    <link href="css/MainContainer.css" rel="stylesheet" type="text/css" />
    <link href="css/StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/rightmenu.js" type="text/javascript"></script>
</head>
<body dir="rtl">
    <form id="form1" runat="server">
        <table style="width: 100%; height: 100%;" id="MainContainer" cellpadding="0" cellspacing="0">
            <tr>
                <td colspan="3">
                    <div id="header">
                        <img src="images/header.png" alt="" />
                    </div>
                </td>
            </tr>
            <tr>
                <td id="tdRightmenu" style="width: 200px; height: 100%; vertical-align: top;">
                    <div id="Rightmenu" style="height: 100%;">
                        <div id="sidebar_title">
                            منوی کاربری
                        </div>
                        <div id="Div1">
                            <script src="Scripts/togglemenu.js" type="text/javascript"></script>
                            <ul class="menu">
                                <li><a href=".">
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <asp:Image ID="Image1" CssClass="homeico" runat="server" ImageUrl="Images/home_ico.png" />
                                            </td>
                                            <td>تعاریف
                                            </td>
                                        </tr>
                                    </table>
                                </a>
                                    <ul>
                                        <li><a href="Define/SiteDefine/UserWebPart" target="MainFrame">وب پارت کاربری</a></li>
                                        <li><a href="Define/SiteDefine/Menu" target="MainFrame">منو ها</a></li>
                                        <li><a href="Define/SiteDefine/dayword" target="MainFrame">سخن روز</a></li>
                                        <li><a href="Define/SiteDefine/SiteLink" target="MainFrame">لینک ها</a></li>
                                        
                                        <hr />
                                        <li><a href="Define/SiteDefine/PlantDivision" target="MainFrame">واحد ها</a></li>
                                    </ul>
                                </li>
                                <li><a href=".">
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <asp:Image ID="Image2" CssClass="homeico" runat="server" ImageUrl="Images/notebook.png" />
                                            </td>
                                            <td>مدیرت مطالب
                                            </td>
                                        </tr>
                                    </table>
                                </a>
                                    <ul>
                                        <li><a href="PageAction/DesignHomePage" target="MainFrame">صفحه اصلی</a></li>
                                        <li><a href="PageAction/LogicalPage" target="MainFrame">صفحه ها</a></li>
                                        <li><a href="PageAction/Newses" target="MainFrame">اخبار</a></li>
                                        <li><a href="PageAction/Notifications" target="MainFrame">اطلاعیه ها</a></li>
                                        <li><a href="PageAction/About" target="MainFrame">درباره ما</a></li>
                                        <li><a href="Define/SiteDefine/DefinePolls" target="MainFrame">نظر سنجی ها</a></li>
                                        <li><a href="SiteSettings" target="MainFrame">تنظیمات سایت</a></li>
                                    </ul>
                                </li>
                               
                                <li><a href=".">
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <asp:Image ID="Image4" CssClass="homeico" runat="server" ImageUrl="Images/home_ico.png" />
                                            </td>
                                            <td>سایر
                                            </td>
                                        </tr>
                                    </table>
                                </a>
                                    <ul>
                                        <li><a href="Other/FileManagers" target="MainFrame">بارگذاری فایل</a></li>
                                        <li><a href="Define/ShowHouseCooperative" target="MainFrame">درخواست های تعاونی مسکن</a></li>
                                        <li><a href="Other/Visitor" target="MainFrame">بازدیدکنندگان</a></li>
                                    </ul>
                                </li>
                                <li><a href=".">
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <asp:Image ID="Image5" CssClass="homeico" runat="server" ImageUrl="Images/home_ico.png" />
                                            </td>
                                            <td>مدیرت کاربران
                                            </td>
                                        </tr>
                                    </table>
                                </a>
                                    <ul>
                                        <li><a href="SecuritySystem/SecurityUser" target="MainFrame">مدیرت کاربران</a></li>
                                        <li><a href="SecuritySystem/SecurityFormsGranted" target="MainFrame">دسترسی به فرم
                                        ها</a></li>
                                        <li><a href="Logout">خروج از سیستم</a></li>
                                    </ul>
                                </li>
                            </ul>
                        </div>
                    </div>
                </td>
                <td valign="middle" id="toggle" style="height: 100%;">
                    <div id="divControl">
                        <img style="cursor: hand" alt="" src="Images/205587.png" onclick="return menu_close(this);"
                            id="CloseMenu" />
                        <img style="cursor: hand" alt="" src="Images/arrow_left.png" onclick="return menu_open(this);"
                            id="OpenMenu" />
                        <input type="hidden" id="MenuStatus" value="1" />
                    </div>
                </td>
                <td style="width: 100%; height: 100%;">
                    <iframe style="width: 100%; min-width: 1100px; height: 100%" id="MainFrame" src="Welcome"
                        frameborder="0" name="MainFrame"></iframe>
                </td>
            </tr>
            <%--  <tr>
            <td colspan="3">
                <div id="footer">
                </div>
            </td>
        </tr>--%>
        </table>
    </form>
</body>
</html>
