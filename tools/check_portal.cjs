/* Run after preview_portal.py and a local HTTP server. Requires Playwright and Chromium. */
const assert = require('node:assert/strict');
const fs = require('node:fs');
const path = require('node:path');
const { chromium } = require('playwright');
const base = process.env.PORTAL_PREVIEW_URL || 'http://127.0.0.1:8765';
const screenshots = process.env.PORTAL_SCREENSHOT_DIR || '/tmp/arvand-portal-checks';

(async () => {
    fs.mkdirSync(screenshots, { recursive: true });
    const browser = await chromium.launch({ executablePath: process.env.CHROMIUM_PATH || '/usr/bin/chromium', args: ['--no-sandbox'] });
    try {
        const page = await browser.newPage({ viewport: { width: 1428, height: 1304 }, deviceScaleFactor: 1 });
        const failures = [];
        page.on('pageerror', error => failures.push(error.message));
        page.on('response', response => { if (response.status() >= 400) failures.push(`${response.status()} ${response.url()}`); });
        await page.clock.setFixedTime(new Date('2026-10-10T11:00:00Z'));
        await page.route('**/fixture/**', route => route.fulfill({ contentType: 'text/html', body: '<title>Fixture destination</title>Fixture navigation' }));
        async function load() {
            await page.goto(base);
            await page.evaluate(() => document.fonts.ready);
            await page.evaluate(() => Promise.all([...document.images].map(img => img.decode().catch(() => {}))));
        }
        await load();
        assert.equal(await page.locator('.portal-brand-image').evaluate(img => img.complete && img.naturalWidth === 960 && new URL(img.src).pathname === '/Images/header.png'), true);
        assert.equal(await page.locator('.portal-wordmark,.portal-holding').count(), 0);
        assert.equal(await page.locator('[data-systems] .portal-system-card').count(), 18);
        assert.equal(await page.locator('.portal-nav-item').count(), 20);
        assert.equal(await page.locator('[data-files] a').count(), 6);
        assert.equal(await page.locator('[data-announcements] a').count(), 4);
        assert.equal(await page.locator('[data-news] a').count(), 4);
        assert.equal(await page.locator('[data-systems] a').first().innerText(), 'پارسه');
        const geometry = await page.evaluate(() => ({
            hero: document.querySelector('.portal-hero').getBoundingClientRect().toJSON(),
            cards: document.querySelector('[data-systems]').getBoundingClientRect().toJSON(),
            panels: document.querySelector('.portal-information').getBoundingClientRect().toJSON(),
            banners: document.querySelector('.portal-banners').getBoundingClientRect().toJSON(),
            width: document.documentElement.scrollWidth,
            height: document.documentElement.scrollHeight
        }));
        assert.equal(geometry.hero.height, 324);
        assert.equal(geometry.cards.y, 526);
        assert.equal(geometry.cards.height, 321);
        assert.equal(geometry.panels.y, 867);
        assert.equal(geometry.banners.y, 1167);
        assert.equal(geometry.width, 1428);
        assert.equal(geometry.height, 1305);
        await page.screenshot({ path: path.join(screenshots, 'portal-desktop.png'), fullPage: true });
        await page.locator('[data-open="systems"]').click();
        assert.equal(await page.locator('dialog[open] .portal-system-card').count(), 18);
        await page.keyboard.press('Escape');
        assert.equal(await page.locator('dialog[open]').count(), 0);
        assert.equal(await page.locator('[data-open="systems"]').evaluate(node => node === document.activeElement), true);
        const first = await page.locator('.portal-hero-image').getAttribute('src');
        await page.locator('[data-slide="1"]').click();
        assert.notEqual(await page.locator('.portal-hero-image').getAttribute('src'), first);
        assert.equal(await page.locator('[data-slide-index="1"]').getAttribute('aria-pressed'), 'true');
        await page.locator('[data-slide-index="0"]').click();
        assert.equal(await page.locator('.portal-hero-image').getAttribute('src'), first);
        await page.locator('[data-open="files"]').click();
        assert.equal(await page.locator('dialog[open] .portal-file-row').count(), 6);
        await page.locator('[data-close-dialog]').click();
        await page.locator('[data-directory]').click();
        assert.equal(await page.locator('dialog[open] .portal-directory-link').count(), 21);
        await page.keyboard.press('Escape');
        await page.locator('[data-settings]').click();
        assert.equal(await page.locator('dialog[open] .portal-directory-link').innerText(), 'واحد نمونه');
        await page.keyboard.press('Escape');
        await page.locator('#portal-search').fill('ایمنی و آموزش');
        await Promise.all([page.waitForURL('**/fixture/search?q=*'), page.locator('#portal-search').press('Enter')]);
        assert.equal(new URL(page.url()).searchParams.get('q'), 'ایمنی و آموزش');
        await load();
        await page.locator('[data-systems] a').first().click();
        assert.equal(new URL(page.url()).pathname, '/fixture/systems/0');
        await load();
        for (const width of [1024, 768, 390]) {
            await page.setViewportSize({ width, height: 844 });
            assert.equal(await page.evaluate(() => document.documentElement.scrollWidth <= innerWidth), true, `Horizontal overflow at ${width}`);
        }
        await page.locator('[data-toggle-menu]').click();
        assert.equal(await page.locator('[data-toggle-menu]').getAttribute('aria-expanded'), 'true');
        assert.equal(await page.locator('.portal-sidebar').isVisible(), true);
        await page.keyboard.press('Escape');
        assert.equal(await page.locator('.portal-sidebar').isVisible(), false);
        await page.screenshot({ path: path.join(screenshots, 'portal-mobile.png'), fullPage: true });
        // Exercise empty live datasets and untrusted strings with the same rendering code.
        await page.route(base + '/', async route => {
            const response = await route.fetch();
            let html = await response.text();
            html = html.replace(/(<script type="application\/json" data-portal-data>)([\s\S]*?)(<\/script>)/, (_, before, json, after) => {
                const data = JSON.parse(json);
                data.systems[0].url = 'javascript:window.portalInjected=true';
                data.news = [{ title: '<img src=x onerror=window.portalInjected=true>', summary: '', url: 'javascript:alert(1)', image: '' }];
                data.files = [];
                data.announcements = [];
                return before + JSON.stringify(data).replace(/</g, '\\u003c') + after;
            });
            await route.fulfill({ response, body: html });
        });
        await load();
        assert.equal(await page.locator('[data-systems] button').count(), 1);
        assert.equal(await page.locator('[data-news] img').count(), 0);
        assert.match(await page.locator('[data-news]').innerText(), /<img src=x/);
        assert.equal(await page.evaluate(() => window.portalInjected), undefined);
        assert.match(await page.locator('[data-files]').innerText(), /فایلی برای نمایش/);
        assert.match(await page.locator('[data-announcements]').innerText(), /اطلاعیه‌ای/);
        await page.locator('[data-systems] button').click();
        assert.match(await page.locator('dialog[open]').innerText(), /ثبت نشده/);
        assert.deepEqual(failures, []);
        console.log('PASS: reference geometry, 18 cards, panels, assets, dialogs, keyboard focus, slider, route/search navigation, 3 responsive widths, empty data and unsafe content/URL handling.');
        console.log(JSON.stringify(geometry));
        console.log('Screenshots: ' + screenshots);
    } finally {
        await browser.close();
    }
})().catch(error => { console.error(error); process.exitCode = 1; });
