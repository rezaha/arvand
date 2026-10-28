<%@ Page Title="سوالات نظرسنجی" Language="VB" MasterPageFile="~/SystemMng/PopupMasterPage.master" AutoEventWireup="false" CodeFile="PollsQuestions.aspx.vb" Inherits="SiteMng_Define_PollsQuestions" %>

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

        <table width="80%" cellpadding="4px;" class="table_style">
            <tr>
                <td class="item_title" colspan="2">
                  <div class="blueheader">
                        سوالات نظر سنجی: <asp:Label ID="lblPoolName" ForeColor ="Red" runat="server" Text=""></asp:Label>
                  </div>
                </td>
            </tr>
            <tr>
                <td style="text-indent:10px;" class="item_title">کد سوال
                </td>
                <td class="item_txt">
                    <asp:TextBox ID="txt_QuestionNo" runat="server" Text="" CssClass=""></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_QuestionNo" runat="server" ControlToValidate="txt_QuestionNo" Text="*" Display="Dynamic" ErrorMessage="کد سوال وارد نشده است" ValidationGroup="item" ForeColor="Red"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="rev_txt_QuestionNo" runat="server" ControlToValidate="txt_QuestionNo" Text="*" Display="Dynamic" ErrorMessage="فرمت  txt_QuestionNo صحیح نمی باشد" ValidationGroup="item" ForeColor="Red" ValidationExpression="(^([0-9]*|\d*\d{1}?\d*)$)"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td  style="text-indent:10px;"  class="item_title">متن سوال
                </td>
                <td class="item_txt">
                    <asp:TextBox ID="txt_QuestionDescription" runat="server" Text="" CssClass=""></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv_QuestionDescription" runat="server" ControlToValidate="txt_QuestionDescription" Text="*" Display="Dynamic" ErrorMessage="متن سوال وارد نشده است" ValidationGroup="item" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td  style="text-indent:10px;"  class="item_title">نوع پاسخ
                </td>
                <td class="item_txt">
                    <asp:DropDownList style="width:250px" ID="drpAnswerType" runat="server">
                        <asp:ListItem Text="انتخاب کنید" Value="انتخاب کنید">
                        </asp:ListItem>
                       <%-- <asp:ListItem Text="چند گزینه ای  چند پاسخه" Value="1">
                        </asp:ListItem>--%>
                        <asp:ListItem Text="چند گزینه ای تک پاسخه" Value="2">
                        </asp:ListItem>
                         <asp:ListItem Text="تشریحی" Value="3">
                        </asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfv_AnswerType" runat="server" ControlToValidate="drpAnswerType" Text="*" InitialValue="انتخاب کنید" Display="Dynamic" ErrorMessage="نوع سوال انتخاب نشده است" ValidationGroup="item" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            
        </table>
       <table cellpadding="5" cellspacing="5" style="margin: auto; width: 30%;" class="tbl-action">
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
        <table>
            <tr>
                <td class="content_tb">
                    برای تعیین گزینه های هر سوال بر روی آن سوال دابل کلیک کنید.
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
                    <telerik:GridTemplateColumn AllowFiltering="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center" HeaderText="انتخاب">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/icon-pencil.gif" CommandName="row-select" AlternateText="انتخاب" ToolTip="انتخاب" CommandArgument='<%#Convert.ToString(Eval("QuestionId"))%>' /></ImageButton>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="50px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn DataField="QuestionNo" HeaderText="کد سوال"></telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="QuestionDescription" HeaderText="متن سوال" ></telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn HeaderText="نوع پاسخ">
                        <ItemTemplate>
                            <asp:Label ID="lblAnswerType" runat="server" Text='<%#GetAnswerTypeText(Eval("AnswerType"))%>'></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn AllowFiltering="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center" HeaderText="حذف">
                        <ItemTemplate>
                            <telerik:RadButton ID="btnRadConfirm" runat="server" CommandArgument='<%#Convert.ToString(Eval("QuestionId"))%>' CommandName="row-del" OnClientClicking="RadConfirm" Width="15px" Height="14px" Image-ImageUrl="~/Images/icon-delete.gif" Text="حذف" ToolTip="حذف"></telerik:RadButton>
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
            <ClientSettings>
                <Selecting AllowRowSelect="true" />
                <ClientEvents OnRowDblClick="RowDblClick" />
            </ClientSettings>
        </telerik:RadGrid>

        <telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
            <script type="text/javascript">
                function RowDblClick(sender, eventArgs) {
                    myUrl = "QuestionOptions?qid=" + eventArgs.getDataKeyValue("QuestionId");
                    ShowForm(myUrl, null, null);
                }

                function AfterWindowsClose() {
                    // document.getElementById("<%=btnClear.ClientID%>").click();
                }

            </script>
        </telerik:RadCodeBlock>
        <uc1:Confirm ID="Confirm1" runat="server" />
        <uc2:WindowWUC ID="WindowWUC1" runat="server" />
    </telerik:RadAjaxPanel>
</asp:Content>

