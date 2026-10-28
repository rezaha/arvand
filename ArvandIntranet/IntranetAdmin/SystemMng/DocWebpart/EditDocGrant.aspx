<%@ Page Title="" Language="VB" MasterPageFile="~/SystemMng/PopupMasterPage.master" AutoEventWireup="false" CodeFile="EditDocGrant.aspx.vb" Inherits="SystemMng_DocWebpart_EditDocGrant" %>

<%@ Register Src="~/SystemMng/UserControls/WindowWUC.ascx" TagPrefix="uc1" TagName="WindowWUC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript">
        function ClosePopupWindow() {
            //window.parent.document.getElementById("HiddenFieldParent").value = WorkOrderId + "|" + WorkId;
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
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Office2010Blue">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" HorizontalAlign="NotSet" LoadingPanelID="RadAjaxLoadingPanel1">
        <telerik:RadNotification ID="NotifyMessage" runat="server" VisibleOnPageLoad="false"
            Width="400" Height="100" Animation="Fade" EnableRoundedCorners="true" Position="Center"
            EnableShadow="true" Title="پیام سیستم" Text="" Style="z-index: 35000" AutoCloseDelay="2000"
            Skin="Sitefinity" CloseButtonToolTip="خروج">
        </telerik:RadNotification>
        <div class="user_permision">
            <table class="permistion_inner">
                <tr>
                    <td class="sharing_file_name" colspan="2">نام فایل
                    <asp:Label ID="lblFileName" runat="server" Text="" ForeColor="Red"></asp:Label>

                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td>نام دامین کاربر
                    </td>
                    <td>
                        <asp:TextBox ID="txtDomainUserName" runat="server"></asp:TextBox>
                        <asp:Button ID="btnAddUser" CssClass="act-blue" runat="server" Text="افزودن کاربر به لیست" />
                    </td>
                </tr>

                <tr>
                    <td>لیست کاربران
                    </td>
                    <td>
                        <asp:ListBox ID="lstUserNames" CssClass="permistion_list" Width="298px" Height="300px" runat="server"></asp:ListBox>
                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnDelete" CssClass="act-orange" runat="server" Text="حذف از لیست کاربران" />
                    </td>
                </tr>
            </table>

            <table>
                <tr>
                    <td></td>
                </tr>
            </table>
        </div>
        <uc1:WindowWUC runat="server" ID="WindowWUC" />

    </telerik:RadAjaxPanel>
</asp:Content>

