<%@ Page Title="" Language="VB" MasterPageFile="~/SystemMng/PopupMasterPage.master" AutoEventWireup="false" CodeFile="EditWebpart.aspx.vb" Inherits="SystemMng_DocWebpart_EditWebpart" %>

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
        <div style="direction: rtl; text-align: right; width: 100%;">
            <table>
                <tr>
                    <td>نام وب پارت
                    </td>
                    <td>
                        <asp:TextBox ID="txtWebPartName" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>

            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnSave" runat="server" Text="ذخیره" />
                    </td>
                </tr>
            </table>
        </div>
    </telerik:RadAjaxPanel>
</asp:Content>

