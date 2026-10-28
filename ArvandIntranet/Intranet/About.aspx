<%@ Page Title="پیغام فوری" Language="VB" MasterPageFile="~/MasterPages/MasterPage.master" AutoEventWireup="false" CodeFile="About.aspx.vb" Inherits="About" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="shownews_sidebar">
        <div class="news_sidebar_title">
            <img id="Img1" src="~/Images/shownews/news_title_sidebar.png" runat="server" />
            <span>منوی کاربری
            </span>
        </div>
        <ul class="user_menu">
            <li>
                <a href="<%=SetHomePageUrl()%>">
                    <img id="Img2" src="~/Images/shownews/homepage_ico.png" runat="server" />
                    <span>صفحه نخست</span>
                </a>
            </li>
        </ul>
    </div>
    <div class="shownews_wrap">
        <div class="shownews_title">
            <h2 runat="server" id="lblNewsTitle"></h2>
        </div>
        <div class="about_complete" runat="server" id="lblNewsSummary">
            <p>
            </p>
        </div>
        <br />
        <div class="about_complete" runat="server" id="lblNewsContent">
            <p>
            </p>
        </div>
    </div>
</asp:Content>
