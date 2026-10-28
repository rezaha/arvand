<%@ Control Language="VB" AutoEventWireup="false" CodeFile="NewsContentWUC.ascx.vb" Inherits="UserControls_NewsContentWUC" %>

<asp:Repeater ID="Repeater1" runat="server">
    <ItemTemplate>
        <div class="news_item">
            <div class="thumbnail">
                <figure>
                    <a href='<%#SetNewsUrl(Container.DataItem)%>' target="_blank">
                        <img runat="server" src='<%# "~/" & Eval("SmallPictureLink")%>' width="175" height="117" />
                    </a>
                </figure>
                <span><%# NewsDateConvert(Eval("NewsDate"))%>
                </span>
            </div>
            <!-- end of Thumbnail !-->
            <div class="news_main">
                <h2>
                    <a href='<%#SetNewsUrl(Container.DataItem)%>' runat="server" target="_blank"><%#SetNewsTitle(Container.DataItem)%></a>
                </h2>
                <p>
                    <a href='<%#SetNewsUrl(Container.DataItem)%>' target="_blank">
                        <%#SetNewsSummary(Container.DataItem)%>
                    </a>
                </p>
            </div>
            <!-- end of news_main div !-->
            <a class="readmore" href='<%#SetNewsUrl(Container.DataItem)%>' target="_blank">
                <span class="readmore_ico">
                    <img runat="server" src="~/Images/links_ico.png" alt="ادامه مطلب" />
                </span>
                <span>ادامه مطلب
                </span>
            </a>
        </div>
    </ItemTemplate>
</asp:Repeater>





