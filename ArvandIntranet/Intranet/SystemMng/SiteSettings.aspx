<%@ Page Title="" Language="VB" MasterPageFile="~/SystemMng/MasterPage.master" AutoEventWireup="false" CodeFile="SiteSettings.aspx.vb" Inherits="SystemMng_SiteSettings"
    ClientIDMode="Static" %>

<%@ Register Src="~/SystemMng/UserControls/WindowWUC.ascx" TagPrefix="uc1" TagName="WindowWUC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

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

        var selectItem;

        function OpenFileExplorerDialog() {
            selectItem = 1;
            ShowForm('<%=GetRouteUrl("default-rout", New With {.pageName = "Explorer", .id = "1"})%>', 600, 600);
        }

        function ClearTextBox() {
            var textbox = $("#txtPersianImageLink");
            textbox.val("");
        }

        function OpenFileExplorerDialog2() {
            selectItem = 2;
            ShowForm('<%=GetRouteUrl("default-rout", New With {.pageName = "Explorer", .id = "1"})%>', 600, 600);
        }

        function ClearTextBox2() {
            var textbox = $("#txtImageLink2");
            textbox.val("");
        }

        function AfterWindowsClose() {
        }
        //This function is called from a code declared on the Explorer.aspx page
        function OnFileSelected(fileSelected) {
            if (selectItem == 1) {
                var textbox = $("#txtPersianImageLink");
                textbox.val(fileSelected);
            } else {
                var textbox = $("#txtImageLink2");
                textbox.val(fileSelected);
            }
            
        }
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
    <uc1:WindowWUC runat="server" ID="WindowWUC" />

    <table cellspacing="3" cellpadding="3" width="100%">
        <tr>
            <td class="tdInfoHeader" align="center" colspan="2">تنظیمات سایت
            </td>
        </tr>
        <tr>
            <td class="tdInfoItem Infotxt" align="center">قسمت
                            <img id="Img1" src="~/Images/NotNull.png" alt="NotNull" runat="server" />
            </td>
            <td class="tdInfoItem" align="right">
                <asp:Label ID="lblDivisionName" runat="server" ForeColor="Red"></asp:Label><asp:HiddenField
                    ID="hfldDivisionId" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="tdInfoItem Infotxt" align="center">لینک هدر
            </td>
            <td class="tdInfoItem" align="right">
                <asp:TextBox ID="txtPersianImageLink" Width="300" runat="server" style="direction: ltr;text-align: left" OnClick="OpenFileExplorerDialog(); return false;" ClientIDMode="Static"></asp:TextBox>
                <asp:Button ID="btnClearImageAddress" CssClass="act-orange" OnClientClick="ClearTextBox(); return false;"
                    Text="پاک کردن" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="tdInfoItem Infotxt" align="center">لینک عکس جهت انتخاب واحد
            </td>
            <td class="tdInfoItem" align="right">
                <asp:TextBox ID="txtImageLink2" Width="300" runat="server" style="direction: ltr;text-align: left" OnClick="OpenFileExplorerDialog2(); return false;" ClientIDMode="Static"></asp:TextBox>
                <asp:Button ID="btnClearImageAddress2" CssClass="act-orange" OnClientClick="ClearTextBox2(); return false;"
                    Text="پاک کردن" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="tdInfoItem Infotxt" align="center">تم سایت
                            <img id="Img2" src="~/Images/NotNull.png" alt="NotNull" runat="server" />
            </td>
            <td class="tdInfoItem" align="right">
                <asp:DropDownList ID="drpThems" Style="font: 11px tahoma;" CssClass="drp" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="tdInfoItem Infotxt" align="center">اندازه صفحه
            </td>
            <td class="tdInfoItem" align="right">
                <asp:TextBox ID="txtPageSize" Width="100" runat="server" style="direction: ltr;text-align: left" onkeypress="return isNum(event);" ClientIDMode="Static"></asp:TextBox>
                (پیش فرض 960 میباشد)
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button Text="ذخیره" runat="server" ID="btnSave" ValidationGroup="p" Style="width: 100px; text-align: center;"
                    CssClass="btn-act act-add" />
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="p"
        CssClass="Error"></asp:ValidationSummary>
</asp:Content>


