/* Visual integration checks for the actual news markup and shared shell. */
const assert = require('node:assert/strict');
const fs = require('node:fs');
const { chromium } = require('playwright');
const base = process.env.PORTAL_PREVIEW_URL || 'http://127.0.0.1:8774';
const output = process.env.PORTAL_SCREENSHOT_DIR || '/tmp/arvand-portal-checks';
(async () => {
    fs.mkdirSync(output, {recursive: true});
    const browser = await chromium.launch({executablePath: '/usr/bin/chromium', args: ['--no-sandbox']});
    try {
        const page = await browser.newPage({viewport: {width: 1428, height: 1100}});
        page.setDefaultTimeout(10000);
        page.setDefaultNavigationTimeout(10000);
        const errors = [];
        page.on('pageerror', e => errors.push(e.message));
        page.on('response', r => {if (r.status() >= 400) errors.push(`${r.status()} ${r.url()}`);});
        let unavailable = false;
        await page.route('**/api/Service/PortalRates/**', route => route.fulfill({contentType: 'application/json', body: JSON.stringify({available: !unavailable, items: unavailable ? [] : [
            {title: 'دلار آمریکا (نمونهٔ آزمون)', value: '1,234', date: 'دادهٔ آزمایشی'},
            {title: 'یورو (نمونهٔ آزمون)', value: '2,345', date: 'دادهٔ آزمایشی'}
        ]})}));
        await page.goto(base + '/news.html');
        await page.evaluate(() => document.fonts.ready);
        assert.equal(await page.locator('.portal-header').count(), 1);
        assert.equal(await page.locator('.portal-sidebar').count(), 1);
        assert.equal(await page.locator('.portal-footer').count(), 1);
        assert.equal(await page.locator('.portal-hero').count(), 0);
        assert.equal(await page.locator('.portal-nav-item').count(), 26);
        await page.waitForFunction(() => document.querySelector('[data-rates-list]').children.length === 2);
        assert.equal(await page.locator('.shownews_wrap').evaluate(n => getComputedStyle(n).fontFamily.includes('PortalSans')), true);
        const article = await page.locator('.shownews_wrap').boundingBox();
        const aside = await page.locator('.shownews_sidebar').boundingBox();
        assert.ok(article.x + article.width < aside.x || aside.x + aside.width < article.x, 'Article and its actions must not overlap');
        const photo = await page.locator('.news_summary img').boundingBox();
        assert.ok(photo.width <= article.width && photo.height <= 430);
        await page.screenshot({path: `${output}/portal-news.png`, fullPage: true});
        for (const width of [1024, 760, 390]) {
            await page.setViewportSize({width, height: 950});
            assert.equal(await page.evaluate(() => document.documentElement.scrollWidth <= innerWidth), true, `News overflow at ${width}`);
        }
        await page.screenshot({path: `${output}/portal-news-mobile.png`, fullPage: true});
        await page.setViewportSize({width: 1428, height: 1100});
        await page.goto(base + '/currency.html');
        await page.waitForFunction(() => document.querySelectorAll('.portal-rates-table .portal-rate-row').length === 2);
        assert.equal(await page.locator('form').count(), 1);
        assert.match(await page.locator('.portal-rates-table').innerText(), /1,234/);
        unavailable = true;
        await page.locator('.portal-rates-page [data-rates-refresh]').click();
        await page.waitForFunction(() => document.querySelectorAll('.portal-rate-row').length === 0);
        assert.match(await page.locator('.portal-rates-page [data-rates-status]').innerText(), /در دسترس نیست/);
        assert.equal(await page.locator('.portal-rates-page [data-rates-refresh]').isEnabled(), true);
        // Cards and navigation stay present even without any configured links.
        await page.route(base + '/', async route => {
            const response = await route.fetch();
            const html = (await response.text()).replace(/(<script type="application\/json" data-portal-data>)([\s\S]*?)(<\/script>)/, (_, a, json, z) => {
                const data = JSON.parse(json); data.systems = []; data.menus = [];
                return a + JSON.stringify(data).replace(/</g, '\\u003c') + z;
            });
            await route.fulfill({response, body: html});
        });
        await page.goto(base);
        assert.equal(await page.locator('[data-systems] button').count(), 18);
        assert.equal(await page.locator('.portal-nav-item').count(), 26);
        await page.locator('[data-systems] button').first().click();
        assert.match(await page.locator('dialog[open]').innerText(), /ثبت نشده/);
        assert.deepEqual(errors, []);
        console.log('PASS: shared news shell, real article layout, no script errors, 4 viewport widths, rates success/unavailability, and 18 unlinked cards.');
    } finally {await browser.close();}
})().catch(error => {console.error(error); process.exitCode = 1;});
