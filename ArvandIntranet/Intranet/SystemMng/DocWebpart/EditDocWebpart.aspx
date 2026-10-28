<%@ Page Title="" Language="VB" MasterPageFile="~/SystemMng/PopupMasterPage.master" AutoEventWireup="false" CodeFile="EditDocWebpart.aspx.vb" Inherits="SystemMng_DocWebpart_EditDocWebpart" %>


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


        function OpenFileExplorerDialog() {
            ShowForm('<%=GetRouteUrl("default-rout", New With {.pageName = "Explorer", .id = "0"})%>', null, null);
        }

        function ClearTextBox() {
            var textbox = $("#txt_FileAddress");
            textbox.val("");
        }
        function AfterWindowsClose() {
        }
        //This function is called from a code declared on the Explorer.aspx page
        function OnFileSelected(fileSelected) {
            var textbox = $("#txt_FileAddress");
            textbox.val(fileSelected);
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

        <table cellspacing="0" cellpadding="0" class="wizard_1">
            <tr>
                <td>
                    <table>
                        <tr>
                            <td>نام وب پارت</td>
                            <td>
                                <asp:Label ID="lblWebPartName" runat="server" Text="" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>

            </tr>
            <tr>
                <td class="tdInfoHeader" align="center" colspan="2">فایل</td>
            </tr>
            <tr>
                <td>
                    <table cellspacing="0" style="margin-top: 10px" cellpadding="0" width="100%">
                        <tr>
                            <td style="width: 90px" class="Infotxt">فایل
                            <img id="Img1" src="~/Images/NotNull.png" alt="NotNull" runat="server" />
                            </td>
                            <td class="tdInfoItem" align="right">
                                <asp:TextBox OnClick="OpenFileExplorerDialog(); return false;" ID="txt_FileAddress" runat="server" Width="200px" Text="" Style="margin-right:6px; text-align:left; direction:ltr;" CssClass="lef_en" ClientIDMode="Static"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="آدرس فایل وارد نشده است"
                                    Display="None" ControlToValidate="txt_FileAddress" Text="*" ValidationGroup="f"></asp:RequiredFieldValidator>
                                <asp:Button ID="btnClear" CssClass="act-orange" OnClientClick="ClearTextBox(); return false;"
                                    Text="پاک کردن" runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>

            </tr>
            <tr>
                <td>
                    <table class="form_table" cellspacing="0" cellpadding="5">
                        <tr>
                            <td style="width: 90px" class="Infotxt">عنوان فایل
                            <img id="Img2" src="~/Images/NotNull.png" alt="NotNull" runat="server" />
                            </td>
                            <td class="tdInfoItem" align="right">
                                <asp:TextBox ID="txtFileTitle" runat="server" Text="" Width="200px" ClientIDMode="Static"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvtxtFileTitle" runat="server" ErrorMessage="عنوان فایل وارد نشده است"
                                    Display="None" ControlToValidate="txtFileTitle" Text="*" ValidationGroup="f"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <asp:CheckBox ID="chkPublicGrant" Text="فایل عمومی" runat="server" Checked="false" />
                            </td>

                        </tr>

                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:ValidationSummary ID="ValidationSummary2" ValidationGroup="f" ForeColor="Red" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <table cellpadding="5px">
                        <tr>
                            <td>
                                <asp:Button Text="اضافه کردن فایل" runat="server" ID="btnAdd" ValidationGroup="f"
                                    CssClass="btn-act act-add" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>


        <telerik:RadGrid ID="gridview1" runat="server" AllowPaging="True" CssClass="popup_grid" AllowSorting="false" CellSpacing="0" Culture="fa-IR" GridLines="Horizontal" AutoGenerateColumns="False" Skin="Windows7" PageSize="20">
            <GroupingSettings CaseSensitive="False" />
            <ClientSettings EnableRowHoverStyle="true">
            </ClientSettings>
            <AlternatingItemStyle BackColor="#E7F2FE" />
            <MasterTableView AllowCustomPaging="true" CommandItemDisplay="None" Dir="RTL">
                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True"></RowIndicatorColumn>
                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True"></ExpandCollapseColumn>
                <Columns>
                    <telerik:GridTemplateColumn AllowFiltering="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center" HeaderText="مشاهده جزییات">
                        <ItemTemplate>
                            <telerik:RadButton ID="btnEdit" runat="server" CommandArgument='<%#Eval("DocId")%>'
                                CommandName="row-up" Width="15px" Height="14px"
                                Image-ImageUrl="~/Images/icon-pencil.gif" Text="مشاهده جزییات" ToolTip="مشاهده جزییات">
                            </telerik:RadButton>
                        </ItemTemplate>
                        <FooterStyle HorizontalAlign="Center" />
                        <HeaderStyle HorizontalAlign="Center" Width="50px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn DataField="DocTitle" HeaderText="نام فایل"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="DocUrl" HeaderText="آدرس فایل"></telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="مجوز عمومی">
                        <ItemTemplate>
                            <asp:Label ID="lblPublicGrant" runat="server" Text='<%#IIf(Eval("PublicGrant") = "True", "عمومی", "دسترسی محدود")%>'></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn AllowFiltering="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center" HeaderText="حذف">
                        <ItemTemplate>
                            <telerik:RadButton ID="btnRadConfirm" runat="server" CommandArgument='<%#Eval("DocId")%>'
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
            <uc1:WindowWUC runat="server" ID="WindowWUC" />

        <uc1:Confirm runat="server" ID="Confirm" />
    </telerik:RadAjaxPanel>
</asp:Content>

