<%@ Page Title="تعاونی مسکن" Language="VB" MasterPageFile="~/SystemMng/MasterPage.master" AutoEventWireup="false" CodeFile="ShowHouseCooperative.aspx.vb" Inherits="SiteMng_Define_ShowHouseCooperative" %>

<%@ Register Src="~/SystemMng/UserControls/Confirm.ascx" TagPrefix="uc1" TagName="Confirm" %>
<%@ Register Src="~/SystemMng/UserControls/WindowWUC.ascx" TagName="WindowWUC" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Office2010Blue">
    </telerik:RadAjaxLoadingPanel>


    <table>
        <tr>
            <td class="content_tb">درخواست های تعاونی مسکن
            </td>
        </tr>
    </table>
    <telerik:RadGrid ID="radGridView" runat="server" AllowFilteringByColumn="False" AllowPaging="True" AllowSorting="True" CellSpacing="0" Culture="fa-IR" GridLines="Horizontal" AutoGenerateColumns="False" Skin="Windows7" PageSize="5000">
        <GroupingSettings CaseSensitive="False" />
        <ClientSettings EnableRowHoverStyle="true">
        </ClientSettings>
        <AlternatingItemStyle BackColor="#E7F2FE" />
        <MasterTableView AllowCustomPaging="true" CommandItemDisplay="Top" Dir="RTL">
            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True"></RowIndicatorColumn>
            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True"></ExpandCollapseColumn>
            <Columns>
                <%--<telerik:GridTemplateColumn AllowFiltering="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center" HeaderText="ویرایش" UniqueName ="EditColumn">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/icon-pencil.gif" CommandName="row-select" AlternateText="مشاهده جزئیات" ToolTip="مشاهده جزئیات" CommandArgument='<%#Convert.ToString(Eval("CoId"))%>' /></ImageButton>
                        </ItemTemplate>
                        <FooterStyle HorizontalAlign="Center" />
                        <HeaderStyle HorizontalAlign="Center" Width="50px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </telerik:GridTemplateColumn>--%>
                <telerik:GridTemplateColumn HeaderText="تاریخ درخواست" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="chkActive" runat="server" Text='<%#GetPersianDate(Eval("RegisterTime"))%>'></asp:Label>
                    </ItemTemplate>
                    <FooterStyle HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </telerik:GridTemplateColumn>
                <telerik:GridBoundColumn DataField="FirstName" HeaderText="نام" SortExpression="FirstName"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="LastName" HeaderText="نام خانوادگی" SortExpression="LastName"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="FatherName" HeaderText="نام پدر" SortExpression="FatherName"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="NationalId" HeaderText="کد ملی" SortExpression="NationalId"></telerik:GridBoundColumn>
                <telerik:GridTemplateColumn HeaderText="نوع استخدام" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblEmpType" runat="server" Text='<%#GetEmpTypeName(Eval("EmpType"))%>'></asp:Label>
                    </ItemTemplate>
                    <FooterStyle HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="محل مورد تقاضای مسکن " HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblLocation" runat="server" Text='<%#GetCoopertiveTypeName(Eval("CooperativeLocation"))%>'></asp:Label>
                    </ItemTemplate>
                    <FooterStyle HorizontalAlign="Center" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </telerik:GridTemplateColumn>
                <telerik:GridBoundColumn DataField="WorkLocation" HeaderText="محل کار" SortExpression="NationalId"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="MobileNo" HeaderText="شماره همراه"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="TelNo" HeaderText="شماره محل کار"></telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="PersonNo" HeaderText="شماره پرسنلی" SortExpression="NationalId"></telerik:GridBoundColumn>
            </Columns>
            <CommandItemSettings ShowAddNewRecordButton="false" ShowExportToCsvButton="false" ShowExportToExcelButton="True" ShowExportToWordButton="false" />
            <EditFormSettings>
                <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
            </EditFormSettings>
        </MasterTableView><FilterMenu EnableImageSprites="False"></FilterMenu>
    </telerik:RadGrid>
    <%-- <telerik:RadDataPager ID="RadDataPager1" runat="server" PagedControlID="gridview1"></telerik:RadDataPager>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" EnablePaging="True" SelectCountMethod="GetHouseCooperativeCount" SelectMethod="GetHouseCooperative" TypeName="Danesh.ArvandIntranet.ServiceLayer.EFServices.HouseCooperativeService" EnableViewState="False" MaximumRowsParameterName="PageSize" StartRowIndexParameterName="StartIndex" SortParameterName="sortexpression"></asp:ObjectDataSource>--%>
</asp:Content>

