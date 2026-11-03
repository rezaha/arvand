#!/usr/bin/env python3
"""Render the actual Web Forms home markup with explicit visual-review fixtures.

This is a static browser fixture, not an ASP.NET/SQL Server substitute.
Only public UI assets are copied: never serve the checkout's Web.config.
"""
import argparse
import json
import html
from pathlib import Path
import re
import shutil

REPOSITORY = Path(__file__).resolve().parents[1]
SITE = REPOSITORY / 'ArvandIntranet' / 'Intranet'


def fixture():
    return json.loads((REPOSITORY / 'tools/portal-fixture.json').read_text(encoding='utf-8'))


def news_body(data):
    """Use the real detail-page layout; substitute only database-bound controls."""
    source = (SITE / 'ShowNews.aspx').read_text(encoding='utf-8-sig')
    body = re.search(r'<asp:Content ID="Content2"[^>]*>(.*?)</asp:Content>', source, re.S)[1]
    sample = data['news'][0]
    for name, text in {'lblNewsTitle': sample['title'], 'lblNewsDate': 'نمونهٔ خبر برای بررسی طراحی',
                       'lblNewsSummary': sample['summary'], 'lblNewsContent': 'این متن نمونه فقط برای بررسی قالب صفحهٔ خبر است. اطلاعات واقعی خبر از پایگاه دادهٔ سامانه خوانده می‌شود.'}.items():
        body = re.sub(r'(<(?P<tag>\w+)\b[^>]*\bid="' + name + r'"[^>]*>).*?(</(?P=tag)>)',
                      lambda m: m[1] + html.escape(text) + m[3], body, flags=re.S)
    body = re.sub(r'<img\b[^>]*\bid="lblNewsLargeImage"[^>]*>', '<img src="/UploadFiles/slider/01/01.jpg" alt="تصویر نمونه خبر" />', body)
    body = re.sub(r'<uc\w+:[^>]+/>', '', body)
    body = re.sub(r'<%=Set\w+Url\(\)%>', '/fixture/news-action', body)
    return body


def page(data, body, home=False):
    payload = json.dumps(data, ensure_ascii=False).replace('<', r'\u003c').replace('>', r'\u003e').replace('&', r'\u0026')
    shell = (SITE / 'MasterPages/PortalShell.master').read_text(encoding='utf-8-sig')
    shell = re.sub(r'<asp:ContentPlaceHolder ID="PortalHead"[^>]+/>', '', shell)
    shell = re.sub(r'<asp:ContentPlaceHolder ID="PortalNavigation"[^>]*>(.*?)</asp:ContentPlaceHolder>', r'\1', shell, flags=re.S)
    shell = re.sub(r'<asp:ContentPlaceHolder ID="PortalMain"[^>]+/>', lambda _: '<div class="portal-content portal-auto-content">' + body + '</div>', shell)
    shell = re.sub(r'<asp:Literal\b[^>]+/>', lambda _: payload, shell)
    shell = shell.replace('<%= IsPortalHome.ToString().ToLowerInvariant() %>', str(home).lower())
    shell = re.sub(r'<%@.*?%>', '', shell, flags=re.S)
    shell = re.sub(r'<%(?:=|#) ResolveUrl\("~/(.*?)"\) %>', r'/\1', shell)
    shell = shell.replace('href="~/', 'href="/').replace('src="~/', 'src="/').replace(' runat="server"', '')
    assert '<%' not in shell and '<asp:' not in shell
    return shell


def render(output):
    marker = output / '.portal-preview-fixture'
    if output.exists() and any(output.iterdir()) and not marker.exists():
        raise SystemExit('Refusing to overwrite a non-preview directory')
    output.mkdir(parents=True, exist_ok=True)
    marker.touch()
    for directory in ('CSS', 'Scripts', 'Images/portal', 'fonts', 'UploadFiles/slider/01'):
        (output / directory).mkdir(parents=True, exist_ok=True)
    for name in ('CSS/portal.css', 'CSS/portal-content.css', 'Scripts/portal.js', 'Images/portal/icons.svg', 'Images/portal/arvand-header.png', 'fonts/BYekan.woff'):
        shutil.copyfile(SITE / name, output / name)
    shell = (SITE / 'MasterPages/PortalShell.master').read_text(encoding='utf-8-sig')
    for name in re.findall(r'ResolveUrl\("~/(Scripts/[^"?]+)(?:\?[^" ]*)?"\)', shell):
        shutil.copyfile(SITE / name, output / name)
    shutil.copytree(SITE / 'Images/shownews', output / 'Images/shownews', dirs_exist_ok=True)
    shutil.copytree(SITE / 'fonts/portal', output / 'fonts/portal', dirs_exist_ok=True)
    for image in (SITE / 'UploadFiles/slider/01').glob('*.jpg'):
        shutil.copyfile(image, output / 'UploadFiles/slider/01' / image.name)
    shutil.copyfile(SITE / 'favicon.ico', output / 'favicon.ico')
    body = (SITE / 'UserControls/PortalHome.ascx').read_text(encoding='utf-8-sig')
    data = fixture()
    (output / 'index.html').write_text(page(data, body, home=True), encoding='utf-8')
    (output / 'news.html').write_text(page(data, news_body(data)), encoding='utf-8')
    currency = (SITE / 'Currency.aspx').read_text(encoding='utf-8-sig')
    currency = re.search(r'<asp:Content ID="RateBody"[^>]*>(.*?)</asp:Content>', currency, re.S)[1]
    (output / 'currency.html').write_text(page(data, currency), encoding='utf-8')
    print(f'Visual fixture written to {output}; not a running ASP.NET application.')


if __name__ == '__main__':
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--site', choices=['Intranet', 'IntranetAdmin'], default='Intranet')
    parser.add_argument('--output', type=Path, default=Path('/tmp/arvand-portal-preview'))
    args = parser.parse_args()
    SITE = REPOSITORY / 'ArvandIntranet' / args.site
    render(args.output.resolve())
