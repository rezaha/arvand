<%@ Control Language="VB" AutoEventWireup="false" CodeFile="PortalHome.ascx.vb" Inherits="UserControls_PortalHome" %>
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
                <div class="portal-priority-systems" data-priority-systems role="group" aria-label="دسترسی مستقیم به سامانه‌های اصلی"></div>
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
