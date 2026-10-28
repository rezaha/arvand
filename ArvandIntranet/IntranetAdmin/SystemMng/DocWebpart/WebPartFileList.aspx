<%@ Page Title="" Language="VB" MasterPageFile="~/SystemMng/PopupMasterPage.master" AutoEventWireup="false" CodeFile="WebPartFileList.aspx.vb" Inherits="SystemMng_DocWebpart_WebPartFileList" %>


<%@ Register Src="~/SystemMng/UserControls/WindowWUC.ascx" TagPrefix="uc1" TagName="WindowWUC" %>

<%@ Register Src="~/SystemMng/UserControls/Confirm.ascx" TagPrefix="uc1" TagName="Confirm" %>

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
        <table cellspacing="0" cellpadding="0" width="100%">
            <tr>
                <td class="tdInfoHeader" align="center" colspan="2">فایل های موجود در وب پارت</td>
            </tr>
            <tr>
                <td style="padding-top: 20px;"></td>
            </tr>
            <tr>
                <td>نام وب پارت</td>
                <td>
                    <asp:Label ID="lblWebPartName" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td>
            </tr>

        </table>
        <telerik:RadGrid ID="gridview1" runat="server" AllowPaging="True" AllowSorting="True" CellSpacing="0" Culture="fa-IR" GridLines="Horizontal" AutoGenerateColumns="False" Skin="Windows7" PageSize="20">
            <GroupingSettings CaseSensitive="False" />
            <ClientSettings EnableRowHoverStyle="true">
                <ClientEvents OnRowContextMenu="gridView1_RowContextMenu"></ClientEvents>
                <Selecting AllowRowSelect="true" />
            </ClientSettings>
            <AlternatingItemStyle BackColor="#E7F2FE" />
            <MasterTableView AllowCustomPaging="true" CommandItemDisplay="None" Dir="RTL" ClientDataKeyNames="DocId">
                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True"></RowIndicatorColumn>
                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True"></ExpandCollapseColumn>
                <Columns>
                    <telerik:GridBoundColumn DataField="DocTitle" HeaderText="نام فایل" HeaderStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                </Columns>
                <CommandItemSettings ShowAddNewRecordButton="false" ShowExportToCsvButton="false" ShowExportToExcelButton="false" ShowExportToWordButton="false" />
                <EditFormSettings>
                    <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                </EditFormSettings>
            </MasterTableView><FilterMenu EnableImageSprites="False"></FilterMenu>
        </telerik:RadGrid>

        <telerik:RadContextMenu ID="GridView1ContextMenu" runat="server"
            EnableRoundedCorners="true" EnableShadows="true" OnClientItemClicked="CurrentWebPart_ClientContextMenuItemClicked">
            <Items>
                <telerik:RadMenuItem Value="DocGrant" Text="مجوز فایل ها" />
            </Items>
        </telerik:RadContextMenu>
        <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
            <script type="text/javascript">
                function gridView1_RowContextMenu(sender, eventArgs) {//for show context menu
                    var menu = $find("<%=GridView1ContextMenu.ClientID%>");
                    var evt = eventArgs.get_domEvent();
                    if (evt.target.tagName == "INPUT" || evt.target.tagName == "A") {
                        return;
                    }
                    var index = eventArgs.get_itemIndexHierarchical();
                    //document.getElementById("radGridClickedRowIndex").value = index;
                    sender.get_masterTableView().selectItem(sender.get_masterTableView().get_dataItems()[index].get_element(), true);
                    menu.show(evt);
                    evt.cancelBubble = true;
                    evt.returnValue = false;
                    if (evt.stopPropagation) {
                        evt.stopPropagation();
                        evt.preventDefault();
                    }
                }

                function CurrentWebPart_ClientContextMenuItemClicked(sender, eventArgs) {//for select item context menu
                    var item = eventArgs.get_item();
                    var grid = $find("<%=gridview1.ClientID%>");
                    var MasterTable = grid.get_masterTableView();
                    var selectedItems = MasterTable.get_selectedItems();
                    var row = selectedItems[0];
                    var index = row.get_itemIndexHierarchical();
                    var selectedRow = $find("<%= gridview1.MasterTableView.ClientID%>").get_dataItems()[index];
                    var DocumentId = selectedRow.getDataKeyValue("DocId");
                    refreshType = "EditCurrentDocument";
                    if (item.get_value() == "DocGrant") {
                        ShowForm("../EditDocGrant/" + DocumentId, null, null);
                    }
                }

                function AfterWindowsClose() {
                }

            </script>
            <uc1:WindowWUC runat="server" ID="WindowWUC" />
            <uc1:Confirm runat="server" ID="Confirm" />
        </telerik:RadCodeBlock>
    </telerik:RadAjaxPanel>

</asp:Content>


