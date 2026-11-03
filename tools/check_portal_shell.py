#!/usr/bin/env python3
"""Audit that every HTML route reaches the shared shell, with valid content slots."""
from pathlib import Path
import re

ROOT = Path(__file__).resolve().parents[1] / 'ArvandIntranet'
DATA_ENDPOINTS = {'RSS.aspx', 'SecImage.aspx'}

for site in (ROOT / 'Intranet', ROOT / 'IntranetAdmin'):
    count = 0
    for page in site.rglob('*.aspx'):
        if page.name in DATA_ENDPOINTS:
            continue
        current = page
        seen = set()
        while current.name != 'PortalShell.master':
            assert current not in seen, f'Master cycle: {current}'
            seen.add(current)
            markup = current.read_text(encoding='utf-8-sig')
            directive = re.search(r'<%@\s*(?:Page|Master)\b(.*?)%>', markup, re.S)[1]
            master = re.search(r'MasterPageFile="([^"]+)"', directive)
            assert master, f'HTML route still has a standalone layout: {current}'
            parent = site / master[1][2:]
            assert parent.is_file(), parent
            parent_markup = parent.read_text(encoding='utf-8-sig')
            slots = set(re.findall(r'<asp:ContentPlaceHolder\b[^>]*\bID="([^"]+)"', parent_markup))
            used = set(re.findall(r'ContentPlaceHolderID="([^"]+)"', markup, re.I))
            assert used <= slots, f'Unknown content slots in {current}: {used - slots}'
            assert not re.search(r'<(?:html|body|form)\b', markup, re.I), f'Duplicate document/form: {current}'
            assert not re.search(r'<link[^>]+(?:StyleSheet|DefaultStyle|LoginStyle|DesignStyle|PopupBoxStyle)\.css', markup, re.I), current
            current = parent
        count += 1
    shell = (site / 'MasterPages/PortalShell.master').read_text()
    assert len(re.findall(r'<form\b', shell, re.I)) == 1
    for asset in ('CSS/portal.css', 'CSS/portal-content.css', 'Scripts/portal.js', 'Scripts/portal-legacy.js'):
        assert (site / asset).is_file(), asset
    base = (site / 'App_Code/BasePage.vb').read_text()
    assert 'IO.Path.GetFileName(AppRelativeVirtualPath)' in base
    assert 'MasterPageFile = "~/MasterPages/Portal.master"' in base
    assert 'Theme = String.Empty' in base
    print(f'PASS {site.name}: {count} HTML pages reach PortalShell, content slots resolve, one server form, no legacy layout styles.')

for name in ('MasterPages/PortalShell.master', 'MasterPages/PortalShell.master.vb', 'CSS/portal-content.css', 'Scripts/portal.js'):
    assert (ROOT / 'Intranet' / name).read_bytes() == (ROOT / 'IntranetAdmin' / name).read_bytes(), name
print('PASS: public shell, data binding, typography and client behaviour are identical in both sites.')
