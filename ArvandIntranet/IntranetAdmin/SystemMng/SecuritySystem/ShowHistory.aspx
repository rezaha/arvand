<%@ Page Title="" Language="VB" MasterPageFile="~/SystemMng/MasterPage.master" AutoEventWireup="false" CodeFile="ShowHistory.aspx.vb" Inherits="SystemMng.SecuritySystem.ShowHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <hr />
    <div id="grdCertificatesGradesContent">
        <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Office2010Blue">
        </telerik:RadAjaxLoadingPanel>
        <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" HorizontalAlign="NotSet" LoadingPanelID="RadAjaxLoadingPanel1">
            <telerik:RadGrid ID="grdHistories" runat="server" EnableEmbeddedSkins="True" Skin="Office2010Blue"
                AllowPaging="True" AllowSorting="True" CellSpacing="0" Culture="fa-IR" Width="99%" DataSourceID="ObjectDataSource1"
                GridLines="Horizontal" AutoGenerateColumns="False" PageSize="20"
                OnItemDataBound="grdHistories_ItemDataBound">
                <ClientSettings EnableRowHoverStyle="true">
                    <Resizing AllowColumnResize="true" AllowRowResize="true" ShowRowIndicatorColumn="False" />
                </ClientSettings>
                <MasterTableView Dir="RTL">
                    <Columns>
                        <telerik:GridBoundColumn DataField="PlantDivisions.NamePersian" HeaderText="نام واحد" AllowSorting="False"></telerik:GridBoundColumn>
                        <telerik:GridTemplateColumn AllowFiltering="false" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"
                            FooterStyle-HorizontalAlign="Center" HeaderText="نوع عملیات">
                            <ItemTemplate>
                                <%#ActionTypeName(Eval("ActionName").ToString)%>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="100px" />
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn DataField="LoginUserName" HeaderText="کاربر" AllowSorting="False"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ActionDate" HeaderText="تاریخ" AllowSorting="False"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ActionTime" HeaderText="ساعت" AllowSorting="False"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="OsUser" HeaderText="کاربر سیستم عامل" AllowSorting="False"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="OsName" HeaderText="سیستم عامل" AllowSorting="False"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="IpAddress" HeaderText="IP" AllowSorting="False"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="BrowserType" HeaderText="مرورگر" AllowSorting="False"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="FormName" HeaderText="توضیحات" AllowSorting="False"></telerik:GridBoundColumn>
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
            <telerik:RadDataPager ID="RadDataPager1" runat="server" PagedControlID="grdHistories"></telerik:RadDataPager>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" EnablePaging="True" SelectCountMethod="HistoriesCount"
                SelectMethod="GetHistories" EnableViewState="False" TypeName="SystemMng.SecuritySystem.ShowHistory"
                StartRowIndexParameterName="startIndex" SortParameterName="sortExpression" MaximumRowsParameterName="pageSize">
            </asp:ObjectDataSource>
        </telerik:RadAjaxPanel>
    </div>
</asp:Content>