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
    return json.loads((REPOSITORY / 'tools/portal-fixture.json').read_text(encoding='utf-8'))


def render(output):
    marker = output / '.portal-preview-fixture'
    if output.exists() and any(output.iterdir()) and not marker.exists():
        raise SystemExit('Refusing to overwrite a non-preview directory')
    output.mkdir(parents=True, exist_ok=True)
    marker.touch()
    for directory in ('CSS', 'Scripts', 'Images/portal', 'fonts', 'UploadFiles/slider/01'):
        (output / directory).mkdir(parents=True, exist_ok=True)
    for name in ('CSS/portal.css', 'Scripts/portal.js', 'Images/portal/icons.svg', 'Images/portal/arvand-header.png', 'fonts/BYekan.woff'):
        shutil.copyfile(SITE / name, output / name)
    shutil.copytree(SITE / 'fonts/portal', output / 'fonts/portal', dirs_exist_ok=True)
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
    parser.add_argument('--site', choices=['Intranet', 'IntranetAdmin'], default='Intranet')
    parser.add_argument('--output', type=Path, default=Path('/tmp/arvand-portal-preview'))
    args = parser.parse_args()
    SITE = REPOSITORY / 'ArvandIntranet' / args.site
    render(args.output.resolve())
