<%@ Control Language="VB" AutoEventWireup="false" CodeFile="PortalHome.ascx.vb" Inherits="UserControls_PortalHome" %>
<div class="portal" data-portal data-assets="<%= ResolveUrl("~/Images/portal/") %>">
    <a class="portal-skip" href="#portal-main">رفتن به محتوای اصلی</a>
    <header class="portal-header">
        <a class="portal-brand" data-page="home" aria-label="پتروشیمی اروند؛ صفحه نخست">
            <span class="portal-brand-crop"><img class="portal-brand-image" src="<%= ResolveUrl("~/Images/portal/arvand-header.png") %>" alt="شرکت پتروشیمی اروند — Arvand Petrochemical Company" width="960" height="100" /></span>
        </a>
        <div class="portal-welcome">به اینترانت شرکت پتروشیمی اروند خوش آمدید.</div>
        <div class="portal-toolbar">
            <div class="portal-date"><i data-icon="calendar"></i><time data-clock></time></div>
            <div class="portal-search" role="search">
                <label class="portal-sr" for="portal-search">جستجو در سامانه‌ها، بخش‌ها، اخبار و ...</label>
                <input id="portal-search" type="search" placeholder="جستجو در سامانه‌ها، بخش‌ها، اخبار و ..." maxlength="200" />
                <button type="button" data-search aria-label="جستجو"><i data-icon="search"></i></button>
            </div>
            <div class="portal-tools">
                <button type="button" class="portal-tool" data-settings aria-label="تنظیمات"><i data-icon="settings"></i></button>
                <button type="button" class="portal-tool" data-open="announcements" aria-label="اطلاعیه‌ها"><i data-icon="bell"></i></button>
                <button type="button" class="portal-user" data-user aria-label="حساب کاربری"><i data-icon="user-circle"></i><span data-username></span><i data-icon="chevron-down"></i></button>
            </div>
            <button class="portal-mobile-menu portal-tool" type="button" data-toggle-menu aria-label="نمایش منو" aria-expanded="false" aria-controls="portal-navigation"><i data-icon="menu"></i></button>
        </div>
    </header>
    <div class="portal-layout">
        <aside class="portal-sidebar" id="portal-navigation" aria-label="منوی اصلی">
            <nav class="portal-nav" data-navigation></nav>
        </aside>
        <main class="portal-main" id="portal-main">
            <section class="portal-hero" aria-label="معرفی پتروشیمی اروند" aria-roledescription="اسلایدر">
                <img class="portal-hero-image" src="<%= ResolveUrl("~/UploadFiles/slider/01/01.jpg") %>" alt="نمای مجتمع پتروشیمی اروند در غروب" width="1160" height="324" fetchpriority="high" />
                <div class="portal-hero-shade"></div>
                <div class="portal-hero-copy" dir="rtl">
                    <span class="portal-eyebrow" lang="en" dir="ltr">ARVAND PETROCHEMICAL</span>
                    <h1>با هم برای فردای بهتر</h1>
                    <p>توسعه پایدار، ارزش‌آفرینی مداوم</p>
                    <a class="portal-about" data-page="about">درباره پتروشیمی اروند <i data-icon="arrow-left"></i></a>
                </div>
                <div class="portal-slide-controls"><button type="button" data-slide="-1" aria-label="اسلاید قبلی"><i data-icon="chevron-left"></i></button><button type="button" data-slide="1" aria-label="اسلاید بعدی"><i data-icon="chevron-right"></i></button></div>
                <div class="portal-slide-dots" role="group" aria-label="انتخاب اسلاید"><button type="button" data-slide-index="0" class="is-active" aria-label="اسلاید ۱" aria-pressed="true"></button><button type="button" data-slide-index="1" aria-label="اسلاید ۲" aria-pressed="false"></button><button type="button" data-slide-index="2" aria-label="اسلاید ۳" aria-pressed="false"></button></div>
            </section>
            <section class="portal-systems" aria-labelledby="portal-systems-heading">
                <div class="portal-section-heading">
                    <div><h2 id="portal-systems-heading">دسترسی سریع به سامانه‌های پرکاربرد</h2><p>سامانه‌های مهم و پرکاربرد سازمان در یک نگاه</p></div>
                    <button type="button" class="portal-gold-button" data-open="systems"><i data-icon="grid"></i>همه سامانه‌ها</button>
                </div>
                <div class="portal-system-grid" data-systems></div>
            </section>
            <div class="portal-information">
                <section class="portal-panel portal-files" aria-labelledby="portal-files-heading">
                    <header><h2 id="portal-files-heading">فایل‌های مورد نیاز</h2><button type="button" data-open="files">مشاهده همه<i data-icon="chevron-left"></i></button></header>
                    <div class="portal-file-list" data-files></div>
                </section>
                <section class="portal-panel portal-notices" aria-labelledby="portal-notices-heading">
                    <header><h2 id="portal-notices-heading">اطلاعیه‌های مهم</h2><button type="button" data-open="announcements">مشاهده همه<i data-icon="chevron-left"></i></button></header>
                    <div class="portal-notice-list" data-announcements></div>
                </section>
                <section class="portal-panel portal-news" aria-labelledby="portal-news-heading">
                    <header><h2 id="portal-news-heading">اخبار سازمانی</h2><a data-page="news">مشاهده همه<i data-icon="chevron-left"></i></a></header>
                    <div class="portal-news-list" data-news></div>
                </section>
            </div>
        </main>
    </div>
    <section class="portal-banners" aria-label="پیوندهای ویژه">
        <button type="button" class="portal-banner portal-banner-hse" data-feature="HSE"><i data-icon="shield-check"></i><span><strong>HSE</strong><small>ایمنی، اولویت همیشگی ما</small></span></button>
        <button type="button" class="portal-banner portal-banner-learning" data-feature="سامانه آموزش"><i data-icon="graduation"></i><span><strong>پرتال آموزش</strong><small>با هم یاد می‌گیریم</small></span></button>
        <button type="button" class="portal-banner portal-banner-culture" data-feature="فرهنگ سازمانی"><i data-icon="book"></i><span><strong>فرهنگ سازمانی</strong><small>ارزش‌ها و باورهای ما</small></span></button>
    </section>
    <footer class="portal-footer"><div class="portal-device-icons" aria-label="قابل استفاده در رایانه و تلفن همراه"><i data-icon="phone-device"></i><i data-icon="monitor"></i></div><nav aria-label="پیوندهای پابرگ"><a data-page="contact">تماس با ما</a><span aria-hidden="true">|</span><button type="button" data-directory>نقشه سایت</button><span aria-hidden="true">|</span><a data-page="about">درباره ما</a></nav></footer>
    <dialog class="portal-dialog" aria-labelledby="portal-dialog-title"><div class="portal-dialog-heading"><h2 id="portal-dialog-title"></h2><button type="button" data-close-dialog aria-label="بستن"><i data-icon="close"></i></button></div><div class="portal-dialog-body"></div></dialog>
    <script type="application/json" data-portal-data><asp:Literal ID="PortalData" runat="server" /></script>
</div>
