#!/usr/bin/env python3
"""Check that the working 8135 site retains the original site's route targets.

This checks deployed source coverage, not IIS/SQL execution or authorization.
"""
from pathlib import Path
import re

ROOT = Path(__file__).resolve().parents[1] / 'ArvandIntranet'
SOURCE = ROOT / 'Intranet'
TARGET = ROOT / 'IntranetAdmin'


def routes(site):
    text = '\n'.join(line for line in (site / 'Global.asax').read_text(encoding='utf-8-sig').splitlines()
                     if not line.lstrip().startswith("'"))
    page_routes = set(re.findall(r'routes\.(MapPageRoute)\(\s*"([^"]+)"\s*,\s*"([^"]+)"\s*,\s*"([^"]+)"', text))
    api_routes = {(kind, name, pattern, '') for kind, name, pattern in
                  re.findall(r'routes\.(MapHttpRoute)\(\s*"([^"]+)"\s*,\s*"([^"]+)"', text)}
    return page_routes | api_routes


def main():
    missing_routes = routes(SOURCE) - routes(TARGET)
    assert not missing_routes, f'Missing/changed route registrations: {missing_routes}'
    original_pages = list(SOURCE.rglob('*.aspx'))
    missing_pages = [str(p.relative_to(SOURCE)) for p in original_pages if not (TARGET / p.relative_to(SOURCE)).is_file()]
    assert not missing_pages, f'Missing original ASPX route targets: {missing_pages}'
    source_actions = set(re.findall(r'Public\s+(?:Shared\s+)?(?:Function|Sub)\s+(\w+)\s*\(',
                                   (SOURCE / 'App_Code/ServiceController.vb').read_text(encoding='utf-8-sig'), re.I))
    target_actions = set(re.findall(r'Public\s+(?:Shared\s+)?(?:Function|Sub)\s+(\w+)\s*\(',
                                   (TARGET / 'App_Code/ServiceController.vb').read_text(encoding='utf-8-sig'), re.I))
    assert source_actions <= target_actions, f'Missing API actions: {source_actions - target_actions}'
    handlers = list(SOURCE.glob('*.ashx'))
    assert all((TARGET / p.name).is_file() for p in handlers), 'Missing HTTP handler'
    root_pages = list(SOURCE.glob('*.aspx'))
    for source in root_pages:
        target = TARGET / source.name
        markup = target.read_text(encoding='utf-8-sig')
        for code in re.findall(r'CodeFile="([^"]+)"', markup, re.I):
            assert (target.parent / code).is_file(), f'Missing code-behind: {target.name}: {code}'
        for src in re.findall(r'<%@\s*Register\b[^%]*\bSrc="([^"]+)"', markup, re.I):
            path = TARGET / src[2:] if src.startswith('~/') else target.parent / src
            assert path.is_file(), f'Missing registered control: {target.name}: {src}'
    for page in ['Search', 'About', 'ContactUs', 'NewsArchive', 'ShowNews', 'ShowAnnouncements', 'Print', 'PrintWord', 'RSS', 'ShowPoll']:
        assert (TARGET / (page + '.aspx')).is_file(), page
    assert 'Portal.master' in (TARGET / 'default.aspx').read_text(encoding='utf-8-sig')
    assert 'PortalHome.ascx' in (TARGET / 'default.aspx').read_text(encoding='utf-8-sig')
    print(f'PASS: {len(routes(SOURCE))} route registrations, {len(original_pages)} original ASPX targets, '
          f'{len(root_pages)} root pages and {len(handlers)} handlers are present in the working site.')
    print(f'{len(source_actions)} original service actions, code-behind and registered controls resolve; '
          'confirmed homepage theme remains connected.')


if __name__ == '__main__':
    main()
