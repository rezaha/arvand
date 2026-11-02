#!/usr/bin/env python3
"""Render the actual Web Forms home markup with explicit visual-review fixtures.

This is a static browser fixture, not an ASP.NET/SQL Server substitute.
Only public UI assets are copied: never serve the checkout's Web.config.
"""
import argparse
import json
from pathlib import Path
import re
import shutil

REPOSITORY = Path(__file__).resolve().parents[1]
SITE = REPOSITORY / 'ArvandIntranet' / 'Intranet'


def fixture():
    titles = ['پارسه', 'سیستم جامع بازرگانی', 'سامانه کمیسیون معاملات', 'راهکاران',
              'نظام پیشنهادات و بهره‌وری', 'سامانه جامع حراست', 'Help Desk',
              'سیستم حقوق و دستمزد (رسمی)', 'سامانه آموزش', 'سیستم کتابخانه',
              'نرم افزار استاندارد', 'AriaORMS', 'AriaLIMS', 'BSC',
              'سامانه جامع برنامه‌ریزی', 'سامانه جامع حقوقی هلدینگ', 'آمانو ۶', 'سامانه جامع HSE']
    menus = ['صفحه نخست', 'مدیریت دانش', 'شماره داخلی مدیران', 'امور', 'مدیریت',
             'روابط عمومی', 'برنامه‌ریزی راهبردی', 'حراست', 'حسابرسی داخلی', 'HSE',
             'امور حقوقی و پیمان‌ها', 'امور اداری', 'امور مالی', 'امور بازرگانی',
             'پژوهش و فناوری', 'معماری فرایندها', 'بهره‌برداری', 'تعمیرات', 'خدمات فنی', 'امور بازرسی']
    news_titles = ['بازدید مدیرعامل از واحد', 'راه‌اندازی واحد جدید', 'برگزاری دوره آموزشی HSE', 'نشست هم‌اندیشی کارکنان']
    file_titles = ['دستورالعمل‌ها و فرم‌های اداری', 'مستندات HSE', 'فرم‌های منابع انسانی',
                   'فرم‌های مالی و بازرگانی', 'استانداردها و رویه‌های اجرایی', 'راهنمای سامانه‌ها']
    notices = [('اطلاعیه فناوری اطلاعات', 'محدودیت دسترسی برخی سامانه‌ها در تاریخ ...'),
               ('اطلاعیه منابع انسانی', 'زمان‌بندی دریافت فیش حقوقی مهرماه'),
               ('اطلاعیه HSE', 'برگزاری مانور ایمنی در واحدهای عملیاتی'),
               ('اطلاعیه آموزش', 'ثبت‌نام دوره‌های تخصصی نیمه دوم سال')]
    return {
        'user': 'sajad aryaeimehr',
        'divisions': [{'title': 'واحد نمونه', 'url': '/fixture/divisions/1'}],
        'systems': [{'title': title, 'url': f'/fixture/systems/{i}'} for i, title in enumerate(titles)],
        'menus': [{'id': i + 1, 'parent': 0, 'title': title, 'url': f'/fixture/menus/{i}'} for i, title in enumerate(menus)],
        'news': [{'title': title, 'summary': '', 'url': f'/fixture/news/{i}',
                  'image': f'/UploadFiles/slider/01/0{[1, 2, 4, 3][i]}.jpg'} for i, title in enumerate(news_titles)],
        'announcements': [{'title': title, 'summary': summary, 'url': f'/fixture/announcements/{i}'} for i, (title, summary) in enumerate(notices)],
        'files': [{'title': title, 'url': f'/fixture/files/{i}'} for i, title in enumerate(file_titles)],
        'pages': {name: '/fixture/' + name for name in ('home', 'about', 'contact', 'news', 'search')},
        'slides': [{'image': f'/UploadFiles/slider/01/{name}.jpg', 'alt': alt} for name, alt in
                   [('01', 'نمای مجتمع پتروشیمی اروند در غروب'), ('03', 'نمای شب مجتمع پتروشیمی اروند'), ('04', 'واحدهای تولید پتروشیمی اروند')]],
    }


def render(output):
    marker = output / '.portal-preview-fixture'
    if output.exists() and any(output.iterdir()) and not marker.exists():
        raise SystemExit('Refusing to overwrite a non-preview directory')
    output.mkdir(parents=True, exist_ok=True)
    marker.touch()
    for directory in ('CSS', 'Scripts', 'Images/portal', 'fonts', 'UploadFiles/slider/01'):
        (output / directory).mkdir(parents=True, exist_ok=True)
    for name in ('CSS/portal.css', 'Scripts/portal.js', 'Images/portal/icons.svg', 'Images/header.png', 'fonts/BYekan.woff'):
        shutil.copyfile(SITE / name, output / name)
    for image in (SITE / 'UploadFiles/slider/01').glob('*.jpg'):
        shutil.copyfile(image, output / 'UploadFiles/slider/01' / image.name)
    shutil.copyfile(SITE / 'favicon.ico', output / 'favicon.ico')
    body = (SITE / 'UserControls/PortalHome.ascx').read_text(encoding='utf-8-sig')
    payload = json.dumps(fixture(), ensure_ascii=False).replace('<', r'\u003c').replace('>', r'\u003e').replace('&', r'\u0026')
    body = re.sub(r'<asp:Literal\b[^>]+/>', lambda _: payload, body)
    page = (SITE / 'MasterPages/Portal.master').read_text(encoding='utf-8-sig')
    page = re.sub(r'<asp:ContentPlaceHolder ID="head"[^>]+/>', '', page)
    page = re.sub(r'<asp:ContentPlaceHolder ID="ContentPlaceHolder1"[^>]+/>', lambda _: body, page)
    page = re.sub(r'<%@.*?%>', '', page, flags=re.S)
    page = re.sub(r'<%= ResolveUrl\("~/(.*?)"\) %>', r'/\1', page)
    page = page.replace('href="~/', 'href="/').replace(' runat="server"', '')
    assert '<%' not in page and '<asp:' not in page
    (output / 'index.html').write_text(page, encoding='utf-8')
    print(f'Visual fixture written to {output}; not a running ASP.NET application.')


if __name__ == '__main__':
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--output', type=Path, default=Path('/tmp/arvand-portal-preview'))
    args = parser.parse_args()
    render(args.output.resolve())
