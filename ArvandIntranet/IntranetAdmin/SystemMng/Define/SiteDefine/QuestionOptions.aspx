<%@ Page Title="گزینه های نظرسنجی" Language="VB" MasterPageFile="~/SystemMng/PopupMasterPage.master" AutoEventWireup="false" CodeFile="QuestionOptions.aspx.vb" Inherits="SiteMng_Define_QuestionOptions" %>

<%@ Register Src="~/SystemMng/UserControls/Confirm.ascx" TagPrefix="uc1" TagName="Confirm" %>
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
        <table style="width: 70%;" class="table_style">
            <tr>
                <td class="font_define" colspan="2">
                    <h2 class="blueheader">تعریف گزینه های سوال:
                        <asp:Label ID="lblQuestionName" runat="server" ForeColor="Red" Text=""></asp:Label>
                    </h2>
                </td>
            </tr>
            <tr>
                <td>کد گزینه
                </td>
                <td>
                    <asp:TextBox ID="txt_OptionNo" runat="server" Text="" CssClass=""></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_OptionNo" runat="server" ControlToValidate="txt_OptionNo" Text="*" Display="Dynamic" ErrorMessage="کد گزینه وارد نشده است" ValidationGroup="item" ForeColor="Red"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="rev_txt_OptionNo" runat="server" ControlToValidate="txt_OptionNo" Text="*" Display="Dynamic" ErrorMessage="فرمت  txt_OptionNo صحیح نمی باشد" ValidationGroup="item" ForeColor="Red" ValidationExpression="(^([0-9]*|\d*\d{1}?\d*)$)"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>متن گزینه
                </td>
                <td>

                    <asp:TextBox ID="txt_OptionText" runat="server" Text="" CssClass=""></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_OptionText" runat="server" ControlToValidate="txt_OptionText" Text="*" Display="Dynamic" ErrorMessage="متن گزینه وارد نشده است" ValidationGroup="item" ForeColor="Red"></asp:RequiredFieldValidator>

                </td>
            </tr>
            <tr>
                <td>فعال
                </td>
                <td>
                    <asp:CheckBox ID="chk_Active" runat="server" Text="فعال" CssClass="" Checked="true"></asp:CheckBox>
                </td>
            </tr>
        </table>
        <table cellpadding="5" cellspacing="5" class="tbl-action">
          <tr>
                <td>
                    <asp:Button Text="اضافه" runat="server" ID="btnAdd" ValidationGroup="item"
                        CssClass="btn-act act-add" />
                </td>
                <td>
                    <asp:Button Text="ذخیره تغییرات" runat="server" ID="btnSave" ValidationGroup="item"
                        CssClass="btn-act act-add" />
                </td>
                <td>
                    <asp:Button Text="لغو" runat="server" ID="btnClear" CssClass="btn-act act-add" />
                </td>
            </tr>
        </table>

        <div id="divError">
            <asp:ValidationSummary ID="vsDocument" runat="server" ValidationGroup="item" ForeColor="Red" ShowMessageBox="true" />
        </div>

        <telerik:RadGrid ID="gridview1" runat="server" AllowFilteringByColumn="false" AllowPaging="false" AllowSorting="false" CellSpacing="0" Culture="fa-IR" GridLines="Horizontal" AutoGenerateColumns="False" Skin="Windows7" PageSize="20">
            <GroupingSettings CaseSensitive="False" />
            <ClientSettings EnableRowHoverStyle="true">
                <Resizing AllowColumnResize="true" AllowRowResize="false" ShowRowIndicatorColumn="false" />
            </ClientSettings>
            <AlternatingItemStyle BackColor="#E7F2FE" />
            <MasterTableView AllowCustomPaging="false" CommandItemDisplay="none" Dir="RTL">
                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="false"></RowIndicatorColumn>
                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="false"></ExpandCollapseColumn>
                <Columns>
                    <telerik:GridTemplateColumn AllowFiltering="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center" HeaderText="انتخاب">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/icon-pencil.gif" CommandName="row-select" AlternateText="انتخاب" ToolTip="انتخاب" CommandArgument='<%#Convert.ToString(Eval("OptionId"))%>' /></ImageButton>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="50px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn DataField="OptionNo" HeaderText="کد گزینه"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="OptionText" HeaderText="متن گزینه" SortExpression="OptionText"></telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn AllowFiltering="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center" HeaderText="فعال">
                        <ItemTemplate>
                            <asp:CheckBox ID="chk_Active" runat="server" Text='<%#IIf(Eval("Active"), "فعال", "غیر فعال") %>' Checked='<%#Eval("Active") %>'></asp:CheckBox>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn AllowFiltering="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center" HeaderText="حذف">
                        <ItemTemplate>
                            <telerik:RadButton ID="btnRadConfirm" runat="server" CommandArgument='<%#Convert.ToString(Eval("OptionId"))%>' CommandName="row-del" OnClientClicking="RadConfirm" Width="15px" Height="14px" Image-ImageUrl="~/Images/icon-delete.gif" Text="حذف" ToolTip="حذف"></telerik:RadButton>
                        </ItemTemplate>
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
        <uc1:Confirm ID="Confirm1" runat="server" />

    </telerik:RadAjaxPanel>
</asp:Content>

