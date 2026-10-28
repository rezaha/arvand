<%@ Page Title="" Language="VB" MasterPageFile="~/SystemMng/MasterPage.master" AutoEventWireup="false" CodeFile="DocWebpartList.aspx.vb" Inherits="SystemMng_DocWebpart_DocWebpartList" %>

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
        <table cellspacing="3" cellpadding="3" width="100%">
            <tr>
                <td class="tdInfoHeader" align="center" colspan="2">وب پارت های با دسترسی محدود
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <table cellpadding="5px">
                        <tr>
                            <td>
                                <asp:Button Text="اضافه کردن وب پارت" runat="server" ID="btnAdd" ValidationGroup="Document"
                                    CssClass="btn-act act-add" OnClientClick="ShowForm('AddDocWebpart',750,500);return false;" />
                            </td>

                            <td>
                                <asp:Button ID="btnRebindGridView" runat="server" Text="" Style="display: none;" />
                            </td>
                        </tr>
                    </table>
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
            <MasterTableView AllowCustomPaging="true" CommandItemDisplay="None" Dir="RTL" ClientDataKeyNames="WebpartId">
                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True"></RowIndicatorColumn>
                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True"></ExpandCollapseColumn>
                <Columns>
                    <telerik:GridBoundColumn DataField="NamePersian" HeaderText="عنوان وب پارت"></telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn AllowFiltering="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center" HeaderText="حذف">
                        <ItemTemplate>
                            <telerik:RadButton ID="btnRadConfirm" runat="server" CommandArgument='<%#Eval("WebpartId")%>'
                                CommandName="row-del" OnClientClicking="RadConfirm" Width="15px" Height="14px"
                                Image-ImageUrl="~/Images/icon-delete.gif" Text="حذف رکورد" ToolTip="حذف رکورد">
                            </telerik:RadButton>
                        </ItemTemplate>
                        <FooterStyle HorizontalAlign="Center" />
                        <HeaderStyle HorizontalAlign="Center" Width="50px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </telerik:GridTemplateColumn>
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
                <telerik:RadMenuItem Value="EditWebpart" Text="ویرایش وب پارت" />
                <telerik:RadMenuItem Value="EditFiles" Text="ویرایش فایل ها" />
                <telerik:RadMenuItem Value="SingleGrant" Text="مجوز دهی به فایل" />
                <telerik:RadMenuItem Value="GroupGrant" Text="مجوز دهی گروهی فایل ها" />
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
                    var WebpartId = selectedRow.getDataKeyValue("WebpartId");
                    refreshType = "EditCurrentDocument";
                    if (item.get_value() == "SingleGrant") {
                        ShowForm("WebPartFileList/" + WebpartId, 750, 550);
                    }
                    if (item.get_value() == "EditWebpart") {
                        ShowForm("EditWebpart/" + WebpartId, 500, 300);
                    }
                    if (item.get_value() == "EditFiles") {
                        ShowForm("EditDocWebpart/" + WebpartId, 750, 500);
                    }
                    if (item.get_value() == "GroupGrant") {
                        ShowForm("EditGroupDocGrant/" + WebpartId, 750, 500);
                    }
                }

                function AfterWindowsClose() {
                    document.getElementById("<%= btnRebindGridView.ClientID%>").click();
                }

            </script>
            <uc1:Confirm runat="server" ID="Confirm" />
            <uc1:WindowWUC runat="server" ID="WindowWUC" />
        </telerik:RadCodeBlock>
    </telerik:RadAjaxPanel>

</asp:Content>


