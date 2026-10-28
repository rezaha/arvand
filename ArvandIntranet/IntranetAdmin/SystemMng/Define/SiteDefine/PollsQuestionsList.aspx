<%@ Page Title="سوالات نظرسنجی" Language="VB" MasterPageFile="~/SystemMng/PopupMasterPage.master" AutoEventWireup="false" CodeFile="PollsQuestionsList.aspx.vb" Inherits="SiteMng_Define_PollsQuestionsList" %>

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
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblPoolName" runat="server" ForeColor="red" Text=""></asp:Label>
                </td>
            </tr>
        </table>
        <div id="divError">
            <asp:ValidationSummary ID="vsDocument" runat="server" ValidationGroup="item" ForeColor="Red" ShowMessageBox="true" />
        </div>
        <table>
            <tr>
                <td class="content_tb">برای مشاهده نتایج هر سوال بر روی آن سوال دابل کلیک نمایید.
                </td>
            </tr>
        </table>
        <telerik:RadGrid ID="gridview1" runat="server" AllowFilteringByColumn="false" AllowPaging="false" AllowSorting="false" CellSpacing="0" Culture="fa-IR" GridLines="Horizontal" AutoGenerateColumns="False" Skin="Windows7" PageSize="20">
            <GroupingSettings CaseSensitive="False" />
            <ClientSettings EnableRowHoverStyle="true">
                <Resizing AllowColumnResize="false" AllowRowResize="false" ShowRowIndicatorColumn="true" />
            </ClientSettings>
            <AlternatingItemStyle BackColor="#E7F2FE" />
            <MasterTableView AllowCustomPaging="true" CommandItemDisplay="None" Dir="RTL" DataKeyNames="QuestionId" ClientDataKeyNames="QuestionId">
                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="false"></RowIndicatorColumn>
                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="false"></ExpandCollapseColumn>
                <Columns>
                    <telerik:GridBoundColumn DataField="QuestionNo" HeaderText="کد سوال"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="QuestionDescription" HeaderText="متن سوال"></telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn HeaderText="نوع پاسخ">
                        <ItemTemplate>
                            <asp:Label ID="lblAnswerType" runat="server" Text='<%#GetAnswerTypeText(Eval("AnswerType"))%>'></asp:Label>
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
                    myUrl = "ShowResult?qid=" + eventArgs.getDataKeyValue("QuestionId");
                    ShowForm(myUrl, null, null);
                }
                function AfterWindowsClose() {

                }
            </script>
        </telerik:RadCodeBlock>
        <uc1:Confirm ID="Confirm1" runat="server" />
        <uc2:WindowWUC ID="WindowWUC1" runat="server" />
    </telerik:RadAjaxPanel>
</asp:Content>

