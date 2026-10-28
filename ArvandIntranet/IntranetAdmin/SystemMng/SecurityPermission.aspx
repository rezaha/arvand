<%@ Page Title="" Language="VB" MasterPageFile="~/SystemMng/MasterPage.master" AutoEventWireup="false"
    CodeFile="SecurityPermission.aspx.vb" Inherits="SystemMng_SecurityPermission" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <meta http-equiv="refresh" content="3;URL=Welcome" />
    <meta http-equiv="Page-Exit" content="revealTrans(Duration=1.0,Transition=23)" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <asp:Label ID="lblMessage" runat="server" Text="شما مجوز ورود به این صفحه را ندارید.پس از چند ثانیه به صفحه نخست هدایت می شوید."
        ForeColor="#990000" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small"></asp:Label>
</asp:Content>
