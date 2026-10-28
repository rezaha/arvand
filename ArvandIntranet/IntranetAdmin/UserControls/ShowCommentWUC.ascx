<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ShowCommentWUC.ascx.vb" Inherits="UserControls_ShowCommentWUC" %>
<div class="comments_title">
    <img src="~/images/news/comments_ico.png" runat="server" />
    <span style="vertical-align: top;" id="lblCommentCount" runat="server">
    </span>
</div>
<asp:Repeater ID="Repeater1" runat="server">
    <ItemTemplate>
        <table class="comment">
            <tr>
                <td valign="top" class="comment_thumbnail" rowspan="2">
                    <div class="comment_avatar">
                        <img id="Img1" src="~/images/news/comment_avatar.png" runat="server" />
                    </div>
                </td>
                <td>
                    <span class="comment_name"><%# Eval("OpinionName")%> :
                    </span>
                    <span class="comment_date"><%#OpnionDate(Eval("OpinionDate"))%>
                    </span>
                </td>
            </tr>
            <tr>
                <td class="comment_text"><%# Eval("OpinionContent")%> </td>
            </tr>
        </table>
    </ItemTemplate>
</asp:Repeater>

<%--<table class="comment">
    <tr>
        <td valign="top" class="comment_thumbnail" rowspan="2">
            <div class="comment_avatar">
                <img src="~/images/news/comment_avatar.png" runat="server" />
            </div>
        </td>
        <td>
            <span class="comment_name">دانش افزارماهان:
            </span>
            <span class="comment_date">12 اردیبهشت 1391
            </span>
        </td>
    </tr>
    <tr>
        <td class="comment_text">هدف از این نسخه فرهنگ پس از آن و دستاوردهای خوب شاید باشد. حروفچینی لازم در شرایط فعلی لازمه تکنولوژی بود که گذشته، حال و آینده را شامل گردد. سی و پنج درصد از طراحان در قرن پانزدهم میبایست پرینتر در ستون و سطر حروف لازم است، بلکه شناخت این ابزار گاه اساسا لورم ایپسوم متنی است که ساختگی ایپسوم متنی است که ساختگی </td>
    </tr>
</table>--%>
