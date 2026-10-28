<%@ Control Language="VB" AutoEventWireup="false" CodeFile="NewsCommentWUC.ascx.vb" Inherits="UserControls_NewsCommentWUC" %>

<div class="comments">

    <h2>
        <img src="~/Images/shownews/comments.png"  runat="server"/>
        <span>دیدگاه های کاربران
        </span>
    </h2>
    <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
            <div class="comment_item">
                <div class="comment_avatar">
                    <img src="~/Images/shownews/comments_avatar.png" runat="server" />
                </div>
                <!-- end of comment_avatar !-->
                <div class="comment_title">
                    <p>
                        <a href="#"><%# Eval("OpinionName")%>
                        </a>
                        <span><%#OpnionDate(Eval("OpinionDate"))%>
                        </span>

                    </p>
                    <p class="comment_txt">
                        <%# Eval("OpinionContent")%>
                    </p>

                </div>
                <a class="reply_btn" href="#">
                    <img src="~/Images/shownews/reply_ico.png" runat="server" />
                </a>
            </div>
        </ItemTemplate>
    </asp:Repeater>

    <div class="addcomments">
        <h2>
            <img src="~/Images/shownews/comments.png" runat="server" />
            <span>افزودن دیدگاه
            </span>
        </h2>
        <div class="addcomments_detail">
            <span>نام شما
            </span>
            <p>
                <asp:TextBox CssClass="textbox" ID="TextBox1" runat="server"></asp:TextBox>
            </p>
            <span>آدرس ایمیل
            </span>
            <p>
                <asp:TextBox CssClass="textbox" ID="TextBox2" runat="server"></asp:TextBox>
            </p>
            <span>متن دیدگاه
            </span>
            <p>
                <asp:TextBox CssClass="textbox" Style="height: 70px" ID="TextBox3" TextMode="MultiLine" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Button ID="Button1" CssClass="comment_btn" runat="server" Text="ارسال" />
            </p>
        </div>
    </div>
</div>
