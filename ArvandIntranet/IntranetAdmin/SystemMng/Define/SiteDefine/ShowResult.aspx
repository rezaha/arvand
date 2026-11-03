<%@ Page Title="نظرسنجی" Language="VB" MasterPageFile="~/SystemMng/PopupMasterPage.master" AutoEventWireup="false" CodeFile="ShowResult.aspx.vb" Inherits="SystemMng_Define_SiteDefine_ShowResult" %>


<%@ Register Src="~/SystemMng/UserControls/Confirm.ascx" TagPrefix="uc1" TagName="Confirm" %>
<%@ Register Src="~/SystemMng/UserControls/WindowWUC.ascx" TagName="WindowWUC" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src='<%# ResolveUrl("~/SystemMng/Scripts/Highcharts-3.0.1/js/highcharts.js") %>'></script>
    <script src='<%# ResolveUrl("~/SystemMng/Scripts/Highcharts-3.0.1/js/modules/exporting.js") %>'></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Office2010Blue">
    </telerik:RadAjaxLoadingPanel>
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" HorizontalAlign="NotSet" LoadingPanelID="RadAjaxLoadingPanel1">
        <telerik:RadNotification ID="NotifyMessage" runat="server" VisibleOnPageLoad="false"
            Width="400" Height="100" Animation="Fade" EnableRoundedCorners="true" Position="Center"
            EnableShadow="true" Title="پیام سیستم" Text="" Style="z-index: 35000" AutoCloseDelay="5000"
            Skin="Office2010Blue" CloseButtonToolTip="خروج">
        </telerik:RadNotification>
        <div id="divError">
            <asp:ValidationSummary ID="vsDocument" runat="server" ValidationGroup="item" ForeColor="Red" ShowMessageBox="true" />
        </div>

        <table style="width: 98%;">
            <tr>
                <td class="blueheader">نتایج
                </td>
            </tr>
            <tr>
                <td style="color: red; font-size:x-large">
                    <asp:Literal ID="ltrChart" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>


        <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
            <script type="text/javascript">
                function RowDblClick(sender, eventArgs) {
                    myUrl = "PollsQuestionsList?pid=" + eventArgs.getDataKeyValue("PollId");
                    ShowForm(myUrl, 1070, 700);
                }

                function AfterWindowsClose() {

                }
            </script>
        </telerik:RadCodeBlock>
        <uc1:Confirm ID="Confirm1" runat="server" />
        <uc2:WindowWUC ID="WindowWUC1" runat="server" />
    </telerik:RadAjaxPanel>
</asp:Content>

