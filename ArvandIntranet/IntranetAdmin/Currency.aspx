<%@ Page Language="VB" MasterPageFile="~/MasterPages/Portal.master" Title="نرخ ارز" Inherits="BasePage" %>
<asp:Content ID="RateHead" ContentPlaceHolderID="head" runat="server" />
<asp:Content ID="RateBody" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="portal-rates-page" data-rates>
        <div class="portal-content-heading"><div><p class="portal-kicker">اطلاعات اقتصادی</p><h1>نرخ ارز</h1><p>نرخ‌های اعلام‌شده در منبع ارزی سامانه</p></div><button type="button" class="portal-gold-button" data-rates-refresh>تازه‌سازی نرخ‌ها</button></div>
        <div class="portal-rates-table" data-rates-list></div><p data-rates-status role="status">در حال دریافت نرخ‌ها…</p>
        <p class="portal-rate-source">منبع: بانک ملی ایران؛ زمان و واحد قیمت مطابق اطلاعات منبع است.</p>
    </section>
</asp:Content>
