<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPages/MasterPage.master" AutoEventWireup="false" CodeFile="NewsArchive.aspx.vb" Inherits="NewsArchive" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="sidebar">
        <div class="sidebar_menu">
            <img id="Img1" src="~/images/sidebar/sidebar_title.png" runat="server" />
            <span runat="server" id="menuTitle" style="vertical-align: super"></span>
        </div>
        <div class="Hachure_border"></div>
        <ul class="sidebar_mainmenu">
            <li>
                <a href="<%=SetHomePageUrl()%>">
                    <img id="Img2" src="~/images/sidebar/sidebar_ico/home_sidebar_ico.png" runat="server" />
                    <span runat="server" id="homeLink" style="vertical-align: top; padding-right: 3px;"></span>
                </a>
            </li>

        </ul>

        <div class="Hachure_border"></div>


    </div>
    <div class="news_section">
        <div class="news_subject">
            <span style="margin-right: 15px;" runat="server" id="lblPageTitle"></span>
        </div>
        <div class="news_Hachure"></div>
        <div class="news_Summery">
            <div class="Archive_date">
                <table>
                    <tr>
                        <td style="color: #717171;" runat="server" id="td_TOP" meta:resourcekey="td_TOP"></td>
                        <td>
                            <asp:DropDownList ID="drpDay" CssClass="archive_drop" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="drpMonth" Width="180px" CssClass="archive_drop" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:DropDownList ID="drpYear" CssClass="archive_drop" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <a href="#" class="archive_search_btn">
                                <span class="search_text" runat="server" id="search_span" meta:resourcekey="search_span"></span>
                            </a>
                        </td>
                    </tr>
                </table>
            </div>

            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <div style="padding-top: 10px;" class="archive_item">
                        <div class="archive_thumb">
                            <img id="Img3" alt="" width="123" height="76" src='<%# "~/" & Eval("SmallPictureLink")%>' runat="server" meta:resourcekey="Img3"/>
                        </div>
                        <a href='<%#SetNewsUrl(Container.DataItem)%>' target="_blank" class="Archive_item_title"><%# SetNewTitle(Container.DataItem)%>
                        </a>
                        <span class="archive_item_date"><%# NewsDateConvert(Eval("NewsDate"))%>
                        </span>
                        <div class="archive_description">
                            <a href='<%#SetNewsUrl(Container.DataItem)%>' target="_blank"><%# SetNewsSummary(Container.DataItem)%>
                            </a>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>


            <ul class="news_nav">
                <li>
                    <a>
                        <img src="~/images/nav/right_arrow_nav.png" runat="server" />
                    </a>
                </li>
                <li class="nav_number">1</li>
                <li>
                    <a>
                        <img src="~/images/nav/left_arrow_nav.png" runat="server" />
                    </a>
                </li>
            </ul>
        </div>

    </div>
</asp:Content>
