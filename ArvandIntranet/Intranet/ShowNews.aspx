<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPages/MasterPage.master"
    AutoEventWireup="false" CodeFile="ShowNews.aspx.vb" Inherits="ShowNews" %>

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
            <li>
                <a href="<%=SetPrintNewsUrl()%>">
                    <img src="~/Images/shownews/shownews_print_ico.png" runat="server" />
                    <span>نسخه چاپی</span>
                </a>
            </li>
            <li>
                <a href="<%=SetTextNewsUrl()%>">
                    <img src="~/Images/shownews/shownews_txt_ico.png" runat="server" />
                    <span>نسخه متنی</span>
                </a>
            </li>
            <li>
                <a href="<%=SetRssNewsUrl()%>">
                    <img src="~/Images/shownews/shownews_email_ico.png" runat="server" />
                    <span>فید خبر</span>
                </a>
            </li>
        </ul>
        <uc1:SoftwareSideBarWUC runat="server" ID="SoftwareSideBarWUC" />
        <uc2:OtherNewsWUC runat="server" ID="OtherNewsWUC" />

    </div>
    <!--end of shownews sidebar !-->
    <div class="shownews_wrap">
        <div class="shownews_title">
            <h2 runat="server" id="lblNewsTitle">کسب جايزه تنديس سيمين
            </h2>
            <span runat="server" id="lblNewsDate">در تاریخ:
                        13 اردیبهشت 1392
            </span>
        </div>

        <div class="news_summary">

            <p runat="server" id="lblNewsSummary">
                لورم ایپسوم متنی است که ساختگی برای طراحی و چاپ آن مورد است. صنعت چاپ زمانی لازم بود شرایطی شما باید فکر ثبت نام و طراحی، لازمه خروج می باشد. در ضمن قاعده همفکری ها جوابگوی سئوالات زیاد شاید باشد، آنچنان که لازم بود طراحی گرافیکی خوب بود. کتابهای زیادی شرایط سخت ، دشوار و کمی در سالهای دور لازم است. هدف از این نسخه فرهنگ پس از آن و دستاوردهای خوب شاید باشد. حروفچینی لازم در شرایط فعلی لازمه تکنولوژی بود که گذشته، حال و آینده را شامل گردد. سی و پنج درصد از طراحان در قرن پانزدهم میبایست 
            </p>
            <img src="Images/shownews/news_thumbnail.png" runat="server" id="lblNewsLargeImage" />
        </div>
        <div class="news_complete" runat="server" id="lblNewsContent">
            <p>
                لورم ایپسوم متنی است که ساختگی برای طراحی و چاپ آن مورد است. صنعت چاپ زمانی لازم بود شرایطی شما باید فکر ثبت نام و طراحی، لازمه خروج می باشد. در ضمن قاعده همفکری ها جوابگوی سئوالات زیاد شاید باشد، آنچنان که لازم بود طراحی گرافیکی خوب بود. کتابهای زیادی شرایط سخت ، دشوار و کمی در سالهای دور لازم است. هدف از این نسخه فرهنگ پس از آن و دستاوردهای خوب شاید باشد. حروفچینی لازم در شرایط فعلی لازمه تکنولوژی بود که گذشته، حال و آینده را شامل گردد. سی و پنج درصد از طراحان در قرن پانزدهم میبایست لورم ایپسوم متنی است که ساختگی برای طراحی و چاپ آن مورد است. صنعت چاپ زمانی لازم بود شرایطی شما باید فکر ثبت نام و طراحی، لازمه خروج می باشد. در ضمن قاعده همفکری ها جوابگوی سئوالات زیاد شاید باشد، آنچنان که لازم بود طراحی گرافیکی خوب بود. کتابهای زیادی شرایط سخت ، دشوار و کمی در سالهای دور لازم است. هدف از این نسخه فرهنگ پس از آن و دستاوردهای خوب شاید باشد. حروفچینی لازم در شرایط فعلی لازمه تکنولوژی بود که گذشته، حال و آینده را شامل گردد. سی و پنج درصد از طراحان در قرن پانزدهم میبایست لورم ایپسوم متنی است که ساختگی برای طراحی و چاپ آن مورد است. صنعت چاپ زمانی لازم بود شرایطی شما باید فکر ثبت نام و طراحی، لازمه خروج می باشد. در ضمن قاعده همفکری ها جوابگوی سئوالات زیاد شاید باشد، آنچنان که لازم بود طراحی گرافیکی خوب بود. کتابهای زیادی شرایط سخت ، دشوار و کمی در سالهای دور لازم است. هدف از این نسخه فرهنگ پس از آن و دستاوردهای خوب شاید باشد. حروفچینی لازم در شرایط فعلی لازمه تکنولوژی بود که گذشته، حال و آینده را شامل گردد. سی و پنج درصد از طراحان در قرن پانزدهم میبایست لورم ایپسوم متنی است که ساختگی برای طراحی و چاپ آن مورد است. صنعت چاپ زمانی لازم بود شرایطی شما باید فکر ثبت نام و طراحی، لازمه خروج می باشد. در ضمن قاعده همفکری ها جوابگوی سئوالات زیاد شاید باشد، آنچنان که لازم بود طراحی گرافیکی خوب بود. کتابهای زیادی شرایط سخت ، دشوار و کمی در سالهای دور لازم است. هدف از این نسخه فرهنگ پس از آن و دستاوردهای خوب شاید باشد. حروفچینی لازم در شرایط فعلی لازمه تکنولوژی بود که گذشته، حال و آینده را شامل گردد. سی و پنج درصد از طراحان در قرن پانزدهم میبایست 
            </p>
        </div>
        <uc3:NewsLabelsWUC runat="server" ID="NewsLabelsWUC" />
        <uc4:NewsCommentWUC runat="server" ID="NewsCommentWUC" />
        <!--end of comment item!-->


    </div>
</asp:Content>
