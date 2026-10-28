<%@ Control Language="VB" AutoEventWireup="false" CodeFile="WriteCommentWUC.ascx.vb" Inherits="UserControls_WriteCommentWUC" ClientIDMode="Static" %>
<div class="comments_title">
    <img src="~/Images/news/send_comment.png" runat="server" />
    <span runat="server" id ="TopDivID" style="vertical-align: top;" meta:resourcekey="TopDivID">
    </span>
</div>
<div class="send_comment">
    <table class="sendComment_tb">
        <tr>
            <td runat="server" id="NameTD" style="text-align: left;" meta:resourcekey="NameTD"></td>
            <td>
                <p>
                    <label runat="server" id="lblName" for="txtCommentName" meta:resourcekey="lblName"></label><br />
                    <asp:TextBox ID="txtCommentName" runat="server" CssClass="comment_txt"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Static" Text="*"
                        ControlToValidate="txtCommentName" runat="server" ErrorMessage="" ValidationGroup="Opions" meta:resourcekey="RequiredFieldValidator1"></asp:RequiredFieldValidator>
                    <%--<input type="text" class="comment_txt" name="name" value="" id="name" />--%>
                </p>
            </td>
        </tr>
        <tr>
            <td runat="server" id="EmailTD" style="text-align: left;" meta:resourcekey="EmailTD"></td>
            <td>
                <p>
                    <label runat="server" id="lblEmail" for="txtEmail" meta:resourcekey="lblEmail"></label><br />
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="comment_txt"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" Display="Static"
                        runat="server" ControlToValidate="txtEmail" ErrorMessage=""
                        ValidationGroup="Opions" Text="*" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" meta:resourcekey="RegularExpressionValidator1"></asp:RegularExpressionValidator >
                    <%--<input class="comment_txt" type="text" name="email" value="" id="email">--%>
                </p>
            </td>
        </tr>
        <tr>
            <td runat="server" id="CommentTd" valign="top" style="text-align: left; margin-left: 8px;" meta:resourcekey="CommentTd"></td>
            <td>
                <p>
                    <label runat="server" id="lblComment" for="txtCommentContent" meta:resourcekey="lblComment"></label><br />
                    <asp:TextBox ID="txtCommentContent" runat="server" CssClass="comment_Explain" TextMode="MultiLine" Height="200" Width="335"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Static" Text="*"
                        ControlToValidate="txtCommentContent" runat="server" ErrorMessage=""
                        ValidationGroup="Opions" meta:resourcekey="RequiredFieldValidator3"></asp:RequiredFieldValidator>
                    <%--<textarea cols="30" rows="10" class="comment_Explain" name="website" id="website"></textarea>--%>
                </p>
            </td>
        </tr>
        <tr>
            <td></td>
            <td valign="top">
                <asp:LinkButton ID="lbtnInsertComment" runat="server" CssClass="comment_btn" ValidationGroup="Opions">
                    <img id="Img1" src="~/images/news/add_comment.png" runat="server" />
                    <span runat="server" id="btnSend" style="vertical-align: super" meta:resourcekey="btnSend">
                    </span>
                </asp:LinkButton>
                <asp:LinkButton ID="lblRewriteComment" runat="server" CssClass="comment_btn" ValidationGroup="Opions">
                    <img id="Img2" src="~/images/news/rewrite_ico.png" runat="server" />
                    <span runat="server" id="btnRewrit" style="vertical-align: top" meta:resourcekey="btnRewrit">
                    </span>
                </asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="true"
                    ShowSummary="false" ValidationGroup="Opions" />
            </td>
        </tr>
    </table>
</div>
