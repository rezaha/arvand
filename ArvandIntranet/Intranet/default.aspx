<%@ Page Title="اینترانت پتروشیمی اروند" Language="VB" MasterPageFile="~/MasterPages/Portal.master" AutoEventWireup="false" CodeFile="default.aspx.vb" Inherits="_default" %>
<%@ Register Src="~/UserControls/PortalHome.ascx" TagPrefix="portal" TagName="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <portal:Home ID="PortalHome" runat="server" />
</asp:Content>
