(function () {
    'use strict';
    var root = document.querySelector('[data-portal]');
    if (!root) return;
    var data = JSON.parse(root.querySelector('[data-portal-data]').textContent);
    var sprite = root.getAttribute('data-assets') + 'icons.svg';
    var dialog = root.querySelector('dialog');
    var dialogBody = dialog.querySelector('.portal-dialog-body');
    var dialogTitle = dialog.querySelector('h2');
    var returnFocus;
    var systems = [
        ['پارسه', 'coins'], ['سیستم جامع\nبازرگانی', 'cart'], ['سامانه کمیسیون\nمعاملات', 'file'],
        ['راهکاران', 'chart'], ['نظام پیشنهادات\nو بهره‌وری', 'bulb'], ['سامانه جامع\nحراست', 'shield-check'],
        ['Help Desk', 'headphones'], ['سیستم حقوق و\nدستمزد (رسمی)', 'users'], ['سامانه آموزش', 'graduation'],
        ['سیستم کتابخانه', 'books'], ['نرم افزار\nاستاندارد', 'book'], ['AriaORMS', 'form'],
        ['AriaLIMS', 'flask'], ['BSC', 'bars'], ['سامانه جامع\nبرنامه‌ریزی', 'calendar'],
        ['سامانه جامع\nحقوقی هلدینگ', 'gavel'], ['آمانو ۶', 'clock'], ['سامانه جامع\nHSE', 'leaf']
    ];
    var navigation = [
        ['صفحه نخست', 'home', 'home'], ['مدیریت دانش', 'bulb'], ['شماره داخلی مدیران', 'phone'],
        ['امور', 'grid'], ['مدیریت', 'users'], ['روابط عمومی', 'megaphone'], ['برنامه‌ریزی راهبردی', 'chart'],
        ['حراست', 'shield-check'], ['حسابرسی داخلی', 'file-search'], ['HSE', 'leaf'],
        ['امور حقوقی و پیمان‌ها', 'scale'], ['امور اداری', 'building'], ['امور مالی', 'wallet'],
        ['امور بازرگانی', 'cart'], ['پژوهش و فناوری', 'flask'], ['معماری فرایندها', 'layers'],
        ['بهره‌برداری', 'settings'], ['تعمیرات', 'wrench'], ['خدمات فنی', 'tools'], ['امور بازرسی', 'clipboard']
    ];

    function normalized(value) {
        return (value || '').replace(/ي/g, 'ی').replace(/ك/g, 'ک').replace(/۶/g, '6').replace(/[\s‌ـ()]/g, '').toLowerCase();
    }
    function safeUrl(value) {
        value = (value || '').trim();
        if (!value || /[\u0000-\u001f\u007f\\]/.test(value) || /^\/\//.test(value)) return '';
        try {
            var url = new URL(value, document.baseURI);
            return /^(https?:)$/.test(url.protocol) ? url.href : '';
        } catch (e) { return ''; }
    }
    function element(tag, className, text) {
        var node = document.createElement(tag);
        if (className) node.className = className;
        if (text !== undefined) node.textContent = text;
        return node;
    }
    function icon(name) {
        var holder = element('i');
        holder.setAttribute('data-icon', name);
        return holder;
    }
    function hydrateIcons(container) {
        container.querySelectorAll('i[data-icon]:not([data-ready])').forEach(function (holder) {
            var svg = document.createElementNS('http://www.w3.org/2000/svg', 'svg');
            var use = document.createElementNS('http://www.w3.org/2000/svg', 'use');
            svg.setAttribute('aria-hidden', 'true');
            svg.setAttribute('viewBox', '0 0 24 24');
            use.setAttribute('href', sprite + '#' + holder.getAttribute('data-icon'));
            svg.appendChild(use);
            holder.appendChild(svg);
            holder.setAttribute('data-ready', 'true');
        });
    }
    function find(items, title) {
        return items.find(function (item) { return normalized(item.title) === normalized(title); });
    }
    function empty(container, message) { container.appendChild(element('p', 'portal-empty', message)); }
    function openDialog(title, render) {
        if (!dialog.open) returnFocus = document.activeElement;
        dialogTitle.textContent = title;
        dialogBody.replaceChildren();
        render(dialogBody);
        hydrateIcons(dialogBody);
        dialog.showModal();
    }
    function unavailable(title) {
        openDialog(title.replace(/\n/g, ' '), function (body) {
            empty(body, 'پیوند این بخش هنوز در سامانه ثبت نشده است.');
        });
    }
    function action(className, title, url, onMissing) {
        var href = safeUrl(url);
        var node = element(href ? 'a' : 'button', className);
        if (href) {
            node.href = href;
            if (new URL(href).origin !== location.origin) {
                node.target = '_blank';
                node.rel = 'noopener noreferrer';
            }
        } else {
            node.type = 'button';
            node.addEventListener('click', onMissing || function () { unavailable(title); });
        }
        return node;
    }
    function systemCard(title, glyph, url) {
        var node = action('portal-system-card', title, url);
        node.appendChild(icon(glyph));
        node.appendChild(element('span', '', title));
        return node;
    }
    function renderPrioritySystems() {
        var container = root.querySelector('[data-priority-systems]');
        var priorities = [
            {title: 'اتوماسیون برید', icon: 'file', aliases: ['اتوماسیون برید', 'اتوماسیون اداری برید'], matches: function (title) { return /برید/.test(title); }},
            {title: 'سیستم مدیریت فناوری اطلاعات', icon: 'monitor', aliases: ['سیستم مدیریت فناوری اطلاعات', 'سامانه مدیریت فناوری اطلاعات', 'ITSM'], matches: function (title) { return /مدیریت.*فناوری.*اطلاعات/.test(title); }}
        ];
        priorities.forEach(function (priority) {
            var configured;
            priority.aliases.some(function (alias) {
                configured = find(data.systems, alias);
                return !!configured;
            });
            if (!configured) configured = data.systems.find(function (item) { return priority.matches(normalized(item.title)); });
            var card = action('portal-priority-card', priority.title, configured && configured.url);
            card.appendChild(icon(priority.icon));
            var text = element('span');
            text.appendChild(element('strong', '', priority.title));
            text.appendChild(element('small', '', 'ورود به سامانه'));
            card.appendChild(text);
            card.appendChild(icon('arrow-left'));
            container.appendChild(card);
        });
    }
    function renderFiles(container, items) {
        items.forEach(function (item) {
            var row = action('portal-file-row', item.title, item.url);
            row.appendChild(icon('download'));
            row.appendChild(element('span', 'portal-file-title', item.title));
            row.appendChild(icon('file'));
            container.appendChild(row);
        });
        if (!items.length) empty(container, 'فایلی برای نمایش در دسترس نیست.');
    }
    function renderNotices(container, items) {
        items.forEach(function (item) {
            var row = action('portal-notice', item.title, item.url, function () { showArticle(item); });
            row.appendChild(icon('alert'));
            var copy = element('span');
            copy.appendChild(element('strong', '', item.title));
            copy.appendChild(element('p', '', item.summary));
            row.appendChild(copy);
            container.appendChild(row);
        });
        if (!items.length) empty(container, 'اطلاعیه‌ای برای نمایش وجود ندارد.');
    }
    function renderNews(container, items) {
        items.forEach(function (item) {
            var row = action('portal-news-row', item.title, item.url, function () { showArticle(item); });
            row.appendChild(icon('chevron-left'));
            row.appendChild(element('span', '', item.title));
            var media = element('span', 'portal-news-media');
            media.setAttribute('aria-hidden', 'true');
            if (safeUrl(item.image)) {
                var image = element('img');
                image.src = safeUrl(item.image);
                image.alt = '';
                image.width = 84;
                image.height = 45;
                image.loading = 'lazy';
                image.addEventListener('error', function () {
                    image.remove();
                    media.appendChild(icon('file'));
                    hydrateIcons(media);
                }, {once: true});
                media.appendChild(image);
            } else {
                media.appendChild(icon('file'));
            }
            row.appendChild(media);
            container.appendChild(row);
        });
        if (!items.length) empty(container, 'خبری برای نمایش وجود ندارد.');
    }
    function showArticle(item) {
        openDialog(item.title, function (body) {
            body.appendChild(element('p', 'portal-article-text', item.content || item.summary || 'متن بیشتری ثبت نشده است.'));
        });
    }
    function renderDirectory(container, items) {
        items.forEach(function (item) {
            var children = data.menus.filter(function (child) { return child.parent === item.id; });
            var row = action('portal-directory-link', item.title, children.length ? '' : item.url, function () {
                if (children.length) openMenu(item, children);
                else unavailable(item.title);
            });
            row.textContent = item.title;
            container.appendChild(row);
        });
        if (!items.length) empty(container, 'پیوندی برای نمایش وجود ندارد.');
    }
    function openMenu(item, children) {
        openDialog(item.title, function (body) {
            if (safeUrl(item.url)) {
                var parentPage = action('portal-directory-link', item.title, item.url);
                parentPage.textContent = 'صفحهٔ ' + item.title;
                body.appendChild(parentPage);
            }
            renderDirectory(body, children);
        });
    }
    function appendFeatures(body) {
        [['widgets', 'بخش‌های سازمانی و وب‌پارت‌ها'], ['management', 'مدیریت سامانه']].forEach(function (entry) {
            var href = safeUrl(data.pages[entry[0]]);
            if (!href) return;
            var link = action('portal-directory-link', entry[1], href);
            link.textContent = entry[1];
            body.appendChild(link);
        });
    }
    function showCollection(kind) {
        if (kind === 'systems') openDialog('همه سامانه‌ها', function (body) {
            var grid = element('div', 'portal-system-grid');
            data.systems.forEach(function (item) {
                var design = systems.find(function (entry) { return normalized(entry[0]) === normalized(item.title); });
                grid.appendChild(systemCard(item.title, design ? design[1] : 'grid', item.url));
            });
            if (!data.systems.length) empty(body, 'سامانه‌ای ثبت نشده است.');
            else body.appendChild(grid);
        });
        if (kind === 'files') openDialog('فایل‌های مورد نیاز', function (body) { renderFiles(body, data.files); });
        if (kind === 'announcements') openDialog('اطلاعیه‌های مهم', function (body) { renderNotices(body, data.announcements); });
        if (kind === 'news') openDialog('اخبار سازمانی', function (body) { renderNews(body, data.news); });
    }

    renderPrioritySystems();
    var priorityUrls = new Set(Array.from(root.querySelectorAll('[data-priority-systems] a')).map(function (link) { return link.href; }));
    var grid = root.querySelector('[data-systems]');
    data.systems.filter(function (item) { return safeUrl(item.url) && !priorityUrls.has(safeUrl(item.url)); }).forEach(function (item) {
        var design = systems.find(function (entry) { return normalized(entry[0]) === normalized(item.title); });
        grid.appendChild(systemCard(item.title, design ? design[1] : 'grid', item.url));
    });
    if (!grid.children.length) empty(grid, 'سامانهٔ دیگری برای نمایش ثبت نشده است.');

    var home = action('portal-nav-item is-active', 'صفحه نخست', data.pages.home);
    home.setAttribute('aria-current', 'page');
    home.appendChild(icon('home'));
    home.appendChild(element('span', '', 'صفحه نخست'));
    root.querySelector('[data-navigation]').appendChild(home);
    data.menus.filter(function (item) { return !item.parent && !['صفحه نخست', 'صفحه اصلی', 'خانه'].some(function (name) { return normalized(item.title) === normalized(name); }); }).forEach(function (item) {
        var children = data.menus.filter(function (child) { return child.parent === item.id; });
        var isDirectory = normalized(item.title) === normalized('امور');
        if (!safeUrl(item.url) && !children.length && !isDirectory) return;
        var design = navigation.find(function (entry) { return normalized(entry[0]) === normalized(item.title); });
        var row = action('portal-nav-item', item.title, children.length || isDirectory ? '' : item.url, function () {
            if (isDirectory) openDialog('امور', function (body) { renderDirectory(body, data.menus.filter(function (entry) { return !entry.parent; })); appendFeatures(body); });
            else openMenu(item, children);
        });
        row.appendChild(icon(design ? design[1] : 'grid'));
        row.appendChild(element('span', '', item.title));
        root.querySelector('[data-navigation]').appendChild(row);
    });
    if (root.querySelector('[data-navigation]').children.length === 1) {
        [['widgets', 'بخش‌های سازمانی', 'grid'], ['about', 'درباره ما', 'building'], ['contact', 'تماس با ما', 'phone']].forEach(function (entry) {
            if (!safeUrl(data.pages[entry[0]])) return;
            var row = action('portal-nav-item', entry[1], data.pages[entry[0]]);
            row.appendChild(icon(entry[2]));
            row.appendChild(element('span', '', entry[1]));
            root.querySelector('[data-navigation]').appendChild(row);
        });
    }
    renderFiles(root.querySelector('[data-files]'), data.files.slice(0, 6));
    renderNotices(root.querySelector('[data-announcements]'), data.announcements.slice(0, 4));
    renderNews(root.querySelector('[data-news]'), data.news.slice(0, 4));
    root.querySelector('[data-username]').textContent = data.user;
    root.querySelectorAll('[data-page]').forEach(function (link) {
        var kind = link.getAttribute('data-page');
        var href = safeUrl(data.pages[kind]);
        if (href) link.href = href;
        else {
            link.setAttribute('role', 'button');
            link.tabIndex = 0;
            link.addEventListener('click', function (event) {
                event.preventDefault();
                if (kind === 'news') showCollection('news');
                else if (kind === 'about') openDialog('درباره پتروشیمی اروند', function (body) {
                    body.appendChild(element('p', '', data.organization || 'اینترانت شرکت پتروشیمی اروند'));
                });
                else if (kind === 'contact') openDialog('تماس با ما', function (body) {
                    renderDirectory(body, data.menus.filter(function (item) { return /تماس|تلفن|شماره/.test(item.title); }));
                });
            });
            link.addEventListener('keydown', function (event) {
                if (event.key === 'Enter' || event.key === ' ') { event.preventDefault(); link.click(); }
            });
        }
    });
    root.querySelectorAll('[data-open]').forEach(function (button) {
        button.addEventListener('click', function () { showCollection(button.getAttribute('data-open')); });
    });
    root.querySelectorAll('[data-feature]').forEach(function (button) {
        button.addEventListener('click', function () {
            var title = button.getAttribute('data-feature');
            var configured = find(data.systems, title) || find(data.systems, 'سامانه جامع ' + title) || find(data.menus, title);
            var href = configured && safeUrl(configured.url);
            if (href) location.assign(href);
            else unavailable(title);
        });
    });
    root.querySelector('[data-directory]').addEventListener('click', function () {
        openDialog('نقشه سایت', function (body) {
            renderDirectory(body, data.menus.filter(function (item) { return !item.parent; }));
            appendFeatures(body);
            if (data.divisions.length) {
                body.appendChild(element('h3', '', 'واحدهای سازمانی'));
                renderDirectory(body, data.divisions);
            }
        });
    });
    function showUser() {
        openDialog('حساب کاربری', function (body) { body.appendChild(element('p', '', data.user)); appendFeatures(body); });
    }
    root.querySelector('[data-user]').addEventListener('click', showUser);
    root.querySelector('[data-settings]').addEventListener('click', function () {
        openDialog('انتخاب واحد سازمانی', function (body) { renderDirectory(body, data.divisions); });
    });
    function search() {
        var query = root.querySelector('#portal-search').value.trim();
        var url = safeUrl(data.pages.search);
        if (!query) return;
        if (!url) {
            var needle = normalized(query);
            openDialog('نتایج جستجو', function (body) {
                body.appendChild(element('p', '', 'جستجو در اطلاعات بارگذاری‌شدهٔ همین صفحه'));
                var count = 0;
                [data.systems, data.menus, data.news, data.announcements, data.files].forEach(function (items, index) {
                    items.forEach(function (item) {
                        if (normalized(item.title + ' ' + (item.summary || '')).indexOf(needle) < 0) return;
                        count++;
                        var row = action('portal-directory-link', item.title, item.url,
                            index === 2 || index === 3 ? function () { showArticle(item); } : undefined);
                        row.textContent = item.title;
                        body.appendChild(row);
                    });
                });
                if (!count) empty(body, 'نتیجه‌ای یافت نشد.');
            });
            return;
        }
        var destination = new URL(url);
        destination.searchParams.set('q', query);
        location.assign(destination.href);
    }
    root.querySelector('[data-search]').addEventListener('click', search);
    root.querySelector('#portal-search').addEventListener('keydown', function (event) {
        if (event.key === 'Enter') { event.preventDefault(); search(); }
    });
    root.querySelector('[data-toggle-menu]').addEventListener('click', function (event) {
        var isOpen = root.querySelector('.portal-sidebar').classList.toggle('is-open');
        event.currentTarget.setAttribute('aria-expanded', String(isOpen));
    });
    root.addEventListener('keydown', function (event) {
        if (event.key === 'Escape') {
            root.querySelector('.portal-sidebar').classList.remove('is-open');
            root.querySelector('[data-toggle-menu]').setAttribute('aria-expanded', 'false');
        }
    });
    root.querySelector('[data-close-dialog]').addEventListener('click', function () { dialog.close(); });
    dialog.addEventListener('click', function (event) { if (event.target === dialog) dialog.close(); });
    dialog.addEventListener('close', function () { if (returnFocus) returnFocus.focus(); });

    var slideIndex = 0;
    function changeSlide(index) {
        if (!data.slides.length) return;
        slideIndex = (index + data.slides.length) % data.slides.length;
        var slide = data.slides[slideIndex];
        var image = root.querySelector('.portal-hero-image');
        if (safeUrl(slide.image)) image.src = safeUrl(slide.image);
        image.alt = slide.alt;
        root.querySelectorAll('[data-slide-index]').forEach(function (dot) {
            var active = Number(dot.getAttribute('data-slide-index')) === slideIndex;
            dot.classList.toggle('is-active', active);
            dot.setAttribute('aria-pressed', String(active));
        });
    }
    root.querySelectorAll('[data-slide]').forEach(function (button) {
        button.addEventListener('click', function () { changeSlide(slideIndex + Number(button.getAttribute('data-slide'))); });
    });
    root.querySelectorAll('[data-slide-index]').forEach(function (dot) {
        dot.addEventListener('click', function () { changeSlide(Number(dot.getAttribute('data-slide-index'))); });
    });
    function updateClock() {
        var now = new Date();
        var date = new Intl.DateTimeFormat('fa-IR-u-ca-persian', { timeZone: 'Asia/Tehran', weekday: 'long', year: 'numeric', month: 'long', day: 'numeric' }).format(now);
        var time = new Intl.DateTimeFormat('fa-IR', { timeZone: 'Asia/Tehran', hour: '2-digit', minute: '2-digit', hour12: false }).format(now);
        var clock = root.querySelector('[data-clock]');
        clock.textContent = date + '، ساعت ' + time;
        clock.dateTime = now.toISOString();
    }
    changeSlide(0);
    updateClock();
    window.setInterval(updateClock, 30000);
    hydrateIcons(root);
}());
