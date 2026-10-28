<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPages/MasterPage.master" AutoEventWireup="false" CodeFile="Search.aspx.vb" Inherits="Search" %>

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
            <h2 runat="server">مشاهده نتایج جستجو</h2>
        </div>
        <div class="news_Summery">
            <div class="Archive_date">
                <table>
                    <tr>
                        <td style="color: #717171;" runat="server" id="top_Td" meta:resourcekey="top_Td"></td>
                        <td>
                            <asp:TextBox ID="txtSearchText" CssClass="tenders_txtbox" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:LinkButton ID="lnkSearch" CssClass="archive_search_btn" runat="server" meta:resourcekey="lnkSearch"></asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </div>
            <asp:Label ID="lblResult" ForeColor="Red" runat="server" Text="" Visible="false" meta:resourcekey="lblResult"></asp:Label>
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                    <div style="padding-top: 10px;" class="archive_item">
                        <div class="archive_thumb">
                            <img id="Img3" alt="" width="123" height="76" src='<%# "~/" & Eval("PictureLink")%>' runat="server" meta:resourcekey="Img3" />
                        </div>
                        <a runat="server" href='<%#SetSearchUrl(Container.DataItem, Eval("ItemType"))%>' target="_blank" class="Archive_item_title"><%# Eval("Title")%>
                        </a>
                        <span class="archive_item_date"><%#Eval("DateString")%>
                        </span>
                        <div class="archive_description">
                            <a runat="server" href='<%#SetSearchUrl(Container.DataItem, Eval("ItemType"))%>' target="_blank"><%# Eval("Summary")%>
                            </a>
                        </div>
                        <div class="link_type"><%#Eval("Type")%></div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

        </div>


    </div>
</asp:Content>

