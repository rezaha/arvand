<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPages/MasterPage.master" AutoEventWireup="false" CodeFile="ShowAnnouncements.aspx.vb" Inherits="ShowAnnouncements" %>

<%@ Register Src="~/UserControls/SoftwareSideBarWUC.ascx" TagPrefix="uc1" TagName="SoftwareSideBarWUC" %>
<%@ Register Src="~/UserControls/OtherAnnouncementsWUC.ascx" TagPrefix="uc2" TagName="OtherAnnouncementsWUC" %>

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
                <a href="<%=SetPrintAnnouncementUrl()%>">
                    <img id="Img3" src="~/Images/shownews/shownews_print_ico.png" runat="server" />
                    <span>نسخه چاپی</span>
                </a>
            </li>
            <li>
                <a href="<%=SetTextAnnouncementUrl()%>">
                    <img id="Img4" src="~/Images/shownews/shownews_txt_ico.png" runat="server" />
                    <span>نسخه متنی</span>
                </a>
            </li>
            <li>
                <a href="<%=SetRssAnnouncementUrl()%>">
                    <img src="~/Images/shownews/shownews_email_ico.png" runat="server" />
                    <span>فید اطلاعیه</span>
                </a>
            </li>
        </ul>
        <uc1:SoftwareSideBarWUC runat="server" ID="SoftwareSideBarWUC" />
        <uc2:OtherAnnouncementsWUC runat="server" ID="OtherAnnouncementsWUC" />

    </div>
    <!--end of shownews sidebar !-->
    <div class="shownews_wrap">
        <div class="shownews_title">
            <h2 runat="server" id="lblAnnouncementTitle">کسب جايزه تنديس سيمين
            </h2>
            <span runat="server" id="lblAnnouncementDate">در تاریخ:
                        13 اردیبهشت 1392
            </span>
        </div>

        <div class="news_summary">

            <p runat="server" id="lblAnnouncementSummary">
                لورم ایپسوم متنی است که ساختگی برای طراحی و چاپ آن مورد است. صنعت چاپ زمانی لازم بود شرایطی شما باید فکر ثبت نام و طراحی، لازمه خروج می باشد. در ضمن قاعده همفکری ها جوابگوی سئوالات زیاد شاید باشد، آنچنان که لازم بود طراحی گرافیکی خوب بود. کتابهای زیادی شرایط سخت ، دشوار و کمی در سالهای دور لازم است. هدف از این نسخه فرهنگ پس از آن و دستاوردهای خوب شاید باشد. حروفچینی لازم در شرایط فعلی لازمه تکنولوژی بود که گذشته، حال و آینده را شامل گردد. سی و پنج درصد از طراحان در قرن پانزدهم میبایست
            </p>
            <img src="Images/shownews/news_thumbnail.png" runat="server" id="lblNewsLargeImage" />
        </div>
        <div class="news_complete" runat="server" id="lblAnnouncementContent">
            <p>
                لورم ایپسوم متنی است که ساختگی برای طراحی و چاپ آن مورد است. صنعت چاپ زمانی لازم بود شرایطی شما باید فکر ثبت نام و طراحی، لازمه خروج می باشد. در ضمن قاعده همفکری ها جوابگوی سئوالات زیاد شاید باشد، آنچنان که لازم بود طراحی گرافیکی خوب بود. کتابهای زیادی شرایط سخت ، دشوار و کمی در سالهای دور لازم است. هدف از این نسخه فرهنگ پس از آن و دستاوردهای خوب شاید باشد. حروفچینی لازم در شرایط فعلی لازمه تکنولوژی بود که گذشته، حال و آینده را شامل گردد. سی و پنج درصد از طراحان در قرن پانزدهم میبایست لورم ایپسوم متنی است که ساختگی برای طراحی و چاپ آن مورد است. صنعت چاپ زمانی لازم بود شرایطی شما باید فکر ثبت نام و طراحی، لازمه خروج می باشد. در ضمن قاعده همفکری ها جوابگوی سئوالات زیاد شاید باشد، آنچنان که لازم بود طراحی گرافیکی خوب بود. کتابهای زیادی شرایط سخت ، دشوار و کمی در سالهای دور لازم است. هدف از این نسخه فرهنگ پس از آن و دستاوردهای خوب شاید باشد. حروفچینی لازم در شرایط فعلی لازمه تکنولوژی بود که گذشته، حال و آینده را شامل گردد. سی و پنج درصد از طراحان در قرن پانزدهم میبایست لورم ایپسوم متنی است که ساختگی برای طراحی و چاپ آن مورد است. صنعت چاپ زمانی لازم بود شرایطی شما باید فکر ثبت نام و طراحی، لازمه خروج می باشد. در ضمن قاعده همفکری ها جوابگوی سئوالات زیاد شاید باشد، آنچنان که لازم بود طراحی گرافیکی خوب بود. کتابهای زیادی شرایط سخت ، دشوار و کمی در سالهای دور لازم است. هدف از این نسخه فرهنگ پس از آن و دستاوردهای خوب شاید باشد. حروفچینی لازم در شرایط فعلی لازمه تکنولوژی بود که گذشته، حال و آینده را شامل گردد. سی و پنج درصد از طراحان در قرن پانزدهم میبایست لورم ایپسوم متنی است که ساختگی برای طراحی و چاپ آن مورد است. صنعت چاپ زمانی لازم بود شرایطی شما باید فکر ثبت نام و طراحی، لازمه خروج می باشد. در ضمن قاعده همفکری ها جوابگوی سئوالات زیاد شاید باشد، آنچنان که لازم بود طراحی گرافیکی خوب بود. کتابهای زیادی شرایط سخت ، دشوار و کمی در سالهای دور لازم است. هدف از این نسخه فرهنگ پس از آن و دستاوردهای خوب شاید باشد. حروفچینی لازم در شرایط فعلی لازمه تکنولوژی بود که گذشته، حال و آینده را شامل گردد. سی و پنج درصد از طراحان در قرن پانزدهم میبایست
            </p>
        </div>
        <!--end of comment item!-->


    </div>
</asp:Content>
