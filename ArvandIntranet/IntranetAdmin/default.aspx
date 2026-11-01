<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPages/MasterPage.master" AutoEventWireup="false" CodeFile="default.aspx.vb" Inherits="_default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="<%# ResolveClientUrl("~/Styles/glass-home.css?v=7") %>" />
    <script defer="defer" src="<%# ResolveClientUrl("~/Scripts/glass-home.js?v=7") %>"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="sidebar">
        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
    </div>
    <div class="main">
        <section class="glass-notices" aria-labelledby="glass-notices-title">
            <div class="glass-section-heading">
                <h2 id="glass-notices-title">اطلاعیه‌ها در یک نگاه</h2>
            </div>
            <div class="glass-notice-grid">
                <article class="glass-notice-card glass-notice-urgent">
                    <span class="glass-notice-category">نمونهٔ فوری · فناوری اطلاعات</span>
                    <h3>نمونه: نگهداری دوره‌ای سامانه‌ها</h3>
                    <p>این متن صرفاً برای بررسی ظاهر اطلاعیهٔ فوری است و بیانگر قطعی واقعی سامانه‌ها نیست.</p>
                </article>
                <article class="glass-notice-card">
                    <span class="glass-notice-category">نمونه · آموزش</span>
                    <h3>نمونه: معرفی دوره‌های آموزشی</h3>
                    <p>عنوان و توضیح دوره‌ها پس از اتصال به محتوای تأییدشدهٔ سازمان در این بخش نمایش داده می‌شوند.</p>
                </article>
                <article class="glass-notice-card">
                    <span class="glass-notice-category">نمونه · منابع انسانی</span>
                    <h3>نمونه: راهنمای خدمات کارکنان</h3>
                    <p>این کارت آزمایشی برای بررسی خوانایی، فاصله‌گذاری و نمایش در تلفن همراه است.</p>
                </article>
            </div>
        </section>
        <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
    </div>
</asp:Content>