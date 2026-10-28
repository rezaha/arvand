<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPages/MasterPage.master" AutoEventWireup="false" CodeFile="ShowPage.aspx.vb" Inherits="ShowPage" %>



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
            <li>
                <a href="<%=SetPrintNewsUrl()%>" target="_blank">
                    <img id="Img3" src="~/Images/shownews/shownews_print_ico.png" runat="server" />
                    <span>خروجی PDF صفحه</span>
                </a>
            </li>
             <li>
                <a href="<%=SetPrintWordUrl()%>" target="_blank">
                    <img id="Img4" src="~/Images/shownews/shownews_print_ico.png" runat="server" />
                    <span>خروجی Word صفحه</span>
                </a>
            </li>
        </ul>
    </div>
    <div class="shownews_wrap">
        <div class="shownews_title">
            <h2 runat="server" id="lblNewsTitle">
            </h2>
           
        </div>

        <div class="news_summary">

            <p runat="server" id="lblNewsSummary">
            </p>
            
        </div>
        <div class="news_complete" runat="server" id="lblNewsContent">
            <p>
            </p>
        </div>
    </div>
</asp:Content>
