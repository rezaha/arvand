<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPages/MasterPage.master"
    AutoEventWireup="false" CodeFile="SelContact.aspx.vb" Inherits="SelContact" %>

<%@ Register Src="~/UserControls/SoftwareSideBarWUC.ascx" TagPrefix="uc1" TagName="SoftwareSideBarWUC" %>
<%@ Register Src="~/UserControls/OtherNewsWUC.ascx" TagPrefix="uc2" TagName="OtherNewsWUC" %>
<%@ Register Src="~/UserControls/NewsLabelsWUC.ascx" TagPrefix="uc3" TagName="NewsLabelsWUC" %>
<%@ Register Src="~/UserControls/NewsCommentWUC.ascx" TagPrefix="uc4" TagName="NewsCommentWUC" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="shownews_sidebar">
        <div class="news_sidebar_title">
            <img src="~/Images/shownews/news_title_sidebar.png" runat="server" />
            <span>منوی کاربری
            </span>
        </div>
        <ul class="user_menu">
            <li>
                <a href="<%=SetHomePageUrl()%>">
                    <img src="~/Images/shownews/homepage_ico.png" runat="server" />
                    <span>صفحه نخست</span>
                </a>
            </li>
        </ul>
        <uc1:SoftwareSideBarWUC runat="server" ID="SoftwareSideBarWUC" />
        <uc2:OtherNewsWUC runat="server" ID="OtherNewsWUC" />

    </div>
    <!--end of shownews sidebar !-->
    <div class="shownews_wrap">
        
        <div class="addcomments">
            <h2>
                <img src="~/Images/shownews/comments.png" runat="server" />
                <span id="CotactTextTitle" runat="server">
                </span>
            </h2>
            <div class="addcomments_detail">
                <span>نام شما
                </span>
                <p>
                    <asp:TextBox CssClass="textbox" ID="txtName" runat="server"></asp:TextBox>
                </p>
                <span>آدرس ایمیل
                </span>
                <p>
                    <asp:TextBox CssClass="textbox" ID="txtEmail" runat="server"></asp:TextBox>
                </p>
                <span>شرح
                </span>
                <p>
                    <asp:TextBox CssClass="textbox" ID="txtBody" runat="server" TextMode="MultiLine" Height="100"></asp:TextBox>
                </p>
                <span>کد امنیتی
                </span>
                <p>
                    <asp:Image ID="imgCaptchaText" runat="server" AlternateText="CaptchaImage" />
                    <asp:ImageButton ID="btnRefreshCaptcha" runat="server" ImageUrl="~/images/icon/refresh.png"
                                     OnClick="btnRefreshCaptcha_Click" Style="width: 15px" />
                    <asp:HiddenField ID="hfCaptchaText" runat="server" />
                </p>
                <span>متن تصویر
                </span>
                <p>
                    <asp:TextBox CssClass="textbox" ID="txtCaptcha" runat="server" AutoCompleteType="None"></asp:TextBox>
                </p>
                <p>
                    <asp:LinkButton ID="lnkBtnSend" CssClass="btn comment_btn" runat="server" Text="ارسال"></asp:LinkButton>
                    <asp:LinkButton ID="lnkBtnResend" CssClass="btn comment_btn" runat="server" Text="دوباره نویسی" ></asp:LinkButton>
                    <br />
                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red" Text=""></asp:Label>
                </p>
            </div>
        </div>

        <div class="contact_info_title" style="vertical-align: top;display: none">
            <span runat="server" id="CONTACT_TD" meta:resourcekey="CONTACT_TD" class="txtemail"></span>
        </div>
        <table class="contact_info" style="display: none">
            <tr>
                <td id="SelContactInfo" runat="server"></td>
            </tr>
        </table>
       
        <!--end of comment item!-->


    </div>
</asp:Content>
