<%@ Page Title="نظرسنجی" Language="VB" MasterPageFile="~/SystemMng/MasterPage.master" AutoEventWireup="false" CodeFile="PollsAnswers.aspx.vb" Inherits="SystemMng_Define_SiteDefine_PollsAnswers" %>


<%@ Register Src="~/SystemMng/UserControls/Confirm.ascx" TagPrefix="uc1" TagName="Confirm" %>
<%@ Register Src="~/SystemMng/UserControls/WindowWUC.ascx" TagName="WindowWUC" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
                <td class="blueheader">نظر سنجی های موجود.
                </td>
            </tr>
            <tr>
                <td class="font_define">برای مشاهده نتایج نظر سنجی بر روی هر نظر سنجی دابل کلیک نمایید. </td>
            </tr>
        </table>
        <telerik:RadGrid ID="gridview1" runat="server" AllowFilteringByColumn="false" AllowPaging="false" AllowSorting="false" CellSpacing="0" Culture="fa-IR" GridLines="Horizontal" AutoGenerateColumns="False" Skin="Windows7" PageSize="20">
            <GroupingSettings CaseSensitive="False" />
            <ClientSettings EnableRowHoverStyle="true">
                <Resizing AllowColumnResize="false" AllowRowResize="false" ShowRowIndicatorColumn="false" />
            </ClientSettings>
            <AlternatingItemStyle BackColor="#E7F2FE" />
            <MasterTableView AllowCustomPaging="false" CommandItemDisplay="None" Dir="RTL" DataKeyNames="PollId" ClientDataKeyNames="PollId">
                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="false"></RowIndicatorColumn>
                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="false"></ExpandCollapseColumn>
                <Columns>
                    <telerik:GridBoundColumn DataField="PollName" HeaderText="عنوان نظر سنجی"></telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn AllowFiltering="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center" HeaderText="فعال">
                        <ItemTemplate>
                            <asp:CheckBox ID="chk_Active" runat="server" Text='<%#IIf(Eval("Active"), "فعال", "غیر فعال") %>' Checked='<%#Eval("Active") %>'></asp:CheckBox>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                </Columns>
                <CommandItemSettings ShowAddNewRecordButton="false" ShowExportToCsvButton="false" ShowExportToExcelButton="false" ShowExportToWordButton="false" />
                <EditFormSettings>
                    <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                </EditFormSettings>
            </MasterTableView><FilterMenu EnableImageSprites="False"></FilterMenu>
            <ClientSettings>
                <Selecting AllowRowSelect="true" />
                <ClientEvents OnRowDblClick="RowDblClick" />
            </ClientSettings>
        </telerik:RadGrid>

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

