<%@ Page Title="بخش‌های سازمانی" Language="VB" MasterPageFile="~/MasterPages/MasterPage.master" AutoEventWireup="false" CodeFile="PortalWidgets.aspx.vb" Inherits="PortalWidgets" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server" />
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="sidebar"><asp:PlaceHolder ID="PlaceHolder1" runat="server" /></div>
    <div class="main"><asp:PlaceHolder ID="PlaceHolder2" runat="server" /></div>
</asp:Content>
