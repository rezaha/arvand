# اجرای پروژهٔ اصلی با قالب جدید

قالب جدید در خود سایت قبلی، یعنی `ArvandIntranet/Intranet` قرار دارد. صفحهٔ `default.aspx` از `MasterPages/Portal.master` و `UserControls/PortalHome.ascx` استفاده می‌کند. فایل `ArvandPreview.sln` صرفاً نمایش مستقل با اطلاعات آزمایشی است و برای اجرای سایت اصلی انتخاب نمی‌شود.

## دریافت تغییرات

در نسخهٔ cloneشده:

```powershell
cd 'C:\Users\AmirAli\Downloads\arvand-git'
git pull --ff-only origin main
.\Open-Arvand.cmd
```

اگر هنگام pull پیام تغییرات محلی دریافت کردید، آن فایل‌ها را حذف یا reset نکنید؛ به‌خصوص تنظیمات اتصال خود را نگه دارید و تعارض را بررسی کنید.

## تنظیم Visual Studio

۱. Visual Studio 2022 را با ابزار **ASP.NET and web development**، **.NET Framework 4.8 Developer/Targeting Pack** و **IIS Express** نصب کنید. SDK دات‌نت ۸ برای سایت اصلی لازم نیست.

۲. فایل `ArvandIntranet/ArvandIntranet.sln` را باز کنید. فایل `Open-Arvand.cmd` همین Solution را باز می‌کند.

۳. در Solution Explorer روی **Intranet** راست‌کلیک و **Set as StartUp Project** را انتخاب کنید. پروژه‌های کتابخانه‌ای قابل اجرا به‌تنهایی نیستند.

۴. Windows Authentication را برای سایت IIS Express فعال و Anonymous Authentication را غیرفعال کنید؛ این همان مدل احراز هویت فعلی سایت است.

۵. پایگاه دادهٔ توسعهٔ موجود سامانه را وصل کنید. نام‌های اتصال در `Intranet/Web.config` عبارت‌اند از `ConnectionString`، `ArvandIntranetContext` و `GPCsiteEntities`. مقادیر واقعی آن‌ها را متناسب با محیط خودتان تنظیم کنید؛ اطلاعات محرمانه را در GitHub ثبت نکنید. اگر پایگاه داده روی سرور سازمانی است، شبکه و دسترسی لازم نیز باید برقرار باشد.

۶. سایت `Intranet` را با Ctrl+F5 اجرا کنید. پورت فعلی آن در Solution برابر 4140 است. صفحهٔ نخست همان قالب جدید را با اطلاعات واقعی سرویس‌های قبلی بارگیری می‌کند.

پایگاه دادهٔ خالی کافی نیست: مسیرها، واحدها، صفحه‌ها و stored procedureها از دادهٔ قبلی خوانده می‌شوند. فایل پشتیبان و اسکریپت ساخت پایگاه داده در مخزن موجود نیست. تغییر قالب، مقادیر اتصال یا داده‌های سامانه را تغییر نمی‌دهد.

## اصلاحات بسته‌بندی سایت اصلی

- شش اسمبلی موردنیاز سایت اصلی که فقط در `IntranetAdmin/Bin` بودند، با همان بایت‌های موجود پروژه در `Intranet/Bin` نیز قرار گرفتند: `Telerik.Web.UI`، `Telerik.Web.UI.Skins`، `AjaxControlToolkit`، `NetNicCapchaPro`، `PersianToolsPack` و `System.Web.Http.WebHost`. اشاره‌گرهای قدیمی `.refresh` این شش فایل حذف شدند؛ اکنون فایل DLL واقعی داخل مخزن است.
- بخش Entity Framework سایت اصلی، binding redirect و SQL Server provider با اسمبلی موجود EF 6 هماهنگ شدند.
- اسمبلی `Microsoft.Web.Infrastructure` از بستهٔ موجود نسخهٔ `2.0.0` در `Intranet/Bin` قرار گرفت و در `packages.config` ثبت شد. binding redirect درخواست‌های نسخهٔ `1.0.0.0` از طرف `System.Web.Http.WebHost` را به اسمبلی `2.0.0.0` موجود هدایت می‌کند. بعد از دریافت این اصلاح، سایت IIS Express را متوقف و دوباره اجرا کنید تا شکست بارگذاری قبلی از حافظه پاک شود.
- تمام مقادیر اتصال موجود بدون تغییر حفظ شدند.

## نتیجهٔ بررسی و محدودیت‌ها

تمام ۶۶ فایل VB مشترک در `App_Code` همراه با کد صفحهٔ نخست و کنترل جدید، با اسمبلی‌های واقعی پروژه و reference assemblyهای Framework 4.8 در یک harness خارج از سایت کامپایل شدند. این بررسی، کامپایل کامل ASP.NET markup یا اجرای Windows/IIS نیست. آزمون‌های قبلی مرورگر برای قالب نیز موفق بوده‌اند.

اجرای کامل سایت روی سیستم کاربر به نسخه و تنظیمات Visual Studio، شبکه، پایگاه داده و احراز هویت وابسته است. خطاهای این بخش هنوز بدون متن خطای واقعی قابل تأیید نیستند.

یک وابستگی قدیمی و مستقل از قالب، در صفحهٔ مدیریتی `SystemMng/Define/ShowHouseCooperative.aspx.vb` باقی است: این صفحه از EPPlus و Excel Interop استفاده می‌کند و DLL آن‌ها در مخزن فعلی یافت نشد. این موضوع ممکن است Build کامل همهٔ صفحات را متوقف کند و نیازمند کتابخانه‌های نسخهٔ اصلی همان صفحه است؛ نسخهٔ دلخواه جدید یا مجوز ساختگی برای آن‌ها اضافه نشده است. اجرای صفحهٔ نخست و Build کامل همهٔ صفحات باید جداگانه بررسی شوند.
