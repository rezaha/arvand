(function () {
    'use strict';
    function lineIcon(path) {
        var ns = 'http://www.w3.org/2000/svg';
        var svg = document.createElementNS(ns, 'svg');
        svg.setAttribute('viewBox', '0 0 24 24');
        svg.setAttribute('aria-hidden', 'true');
        svg.setAttribute('class', 'glass-menu-icon');
        var shape = document.createElementNS(ns, 'path');
        shape.setAttribute('d', path);
        shape.setAttribute('fill', 'none');
        shape.setAttribute('stroke', 'currentColor');
        shape.setAttribute('stroke-width', '1.5');
        shape.setAttribute('stroke-linecap', 'round');
        shape.setAttribute('stroke-linejoin', 'round');
        svg.appendChild(shape);
        return svg;
    }
    function init() {
        if (!document.body.classList.contains('glass-ui')) { return; }
        var host = document.querySelector('.glass-menu-host');
        if (host && !host.querySelector('details')) {
            var details = document.createElement('details');
            details.className = 'glass-navigation';
            details.open = true;
            var summary = document.createElement('summary');
            summary.textContent = 'امور و مدیریت‌ها';
            details.appendChild(summary);
            var nav = document.createElement('nav');
            nav.setAttribute('aria-label', 'امور و مدیریت‌ها');
            while (host.firstChild) { nav.appendChild(host.firstChild); }
            details.appendChild(nav);
            host.appendChild(details);
        }
        if (host) {
            Array.prototype.forEach.call(host.querySelectorAll('.top-menu li > ul'), function (submenu) {
                var group = document.createElement('details');
                group.className = 'glass-submenu';
                var toggle = document.createElement('summary');
                var parentLink = submenu.parentNode.querySelector('a');
                toggle.textContent = 'زیرمجموعهٔ ' + (parentLink ? parentLink.textContent.trim() : 'منو');
                submenu.parentNode.insertBefore(group, submenu);
                group.appendChild(toggle);
                group.appendChild(submenu);
            });
            Array.prototype.forEach.call(host.querySelectorAll('a[href]'), function (link) {
                if (link.getAttribute('href') !== '#' && link.pathname === window.location.pathname && link.search === window.location.search) {
                    link.setAttribute('aria-current', 'page');
                    var ancestor = link.parentNode;
                    while (ancestor && ancestor !== host) {
                        if (ancestor.tagName === 'DETAILS') { ancestor.open = true; }
                        ancestor = ancestor.parentNode;
                    }
                }
            });
        }
        if (host) {
            var menuList = host.querySelector('.top-menu > ul');
            if (menuList) {
                Array.prototype.forEach.call(document.querySelectorAll('.glass-departments'), function (box) {
                    Array.prototype.forEach.call(box.querySelectorAll('.links > li'), function (item) {
                        var link = item.querySelector('a');
                        if (!link) { return; }
                        var duplicate = Array.prototype.some.call(menuList.querySelectorAll('a'), function (existing) {
                            return existing.href === link.href && existing.textContent.trim() === link.textContent.trim();
                        });
                        if (!duplicate) { menuList.appendChild(item); }
                    });
                    box.hidden = true;
                });
            }
            var icons = [
                [/مالی|بازرگانی/, 'M3 6h18v14H3z M3 9h18 M16 14h3'],
                [/حراست|ایمنی|آتش|حسابرس/, 'M12 3l8 3v6c0 5-8 9-8 9s-8-4-8-9V6z M8 12l3 3 5-6'],
                [/زیست|بهداشت|HSE/i, 'M5 20C2 9 9 3 20 4c0 11-6 16-15 16z M5 20L16 9'],
                [/اطلاعات|فناوری/, 'M5 4h14v12H5z M3 20h18 M9 16v4 M15 16v4'],
                [/تعمیر|فنی|بهره/, 'M14 4a5 5 0 0 0-6 6L3 18l3 3 8-8a5 5 0 0 0 6-6l-4 4-3-3 4-4z'],
                [/آموزش|دانش/, 'M3 4h7l2 2 2-2h7v15h-7l-2 2-2-2H3z M12 6v15'],
                [/تلفن|شماره/, 'M7 3l3 5-3 3c2 3 3 4 6 6l3-3 5 3c-1 8-9 4-14-1S0 4 7 3z'],
                [/نخست|خانه/, 'M3 11l9-8 9 8 M5 10v11h5v-7h4v7h5V10'],
                [/راهبرد|برنامه/, 'M4 21V11h4v10 M10 21V7h4v14 M16 21V3h4v18'],
                [/مدیر|ادار|منابع/, 'M3 21V7h18v14 M8 7V3h8v4 M7 11h2 M15 11h2 M7 15h2 M15 15h2 M10 21v-3h4v3']
            ];
            Array.prototype.forEach.call(host.querySelectorAll('.top-menu a'), function (link) {
                if (link.querySelector('.glass-menu-icon')) { return; }
                var name = link.textContent.replace(/ي/g, 'ی').replace(/ك/g, 'ک');
                var match = icons.filter(function (entry) { return entry[0].test(name); })[0];
                link.insertBefore(lineIcon(match ? match[1] : 'M4 4h6v6H4z M14 4h6v6h-6z M4 14h6v6H4z M14 14h6v6h-6z'), link.firstChild);
            });
        }
        var search = document.querySelector('.searchbox input[type=text]');
        if (search) {
            search.setAttribute('aria-label', 'جستجو در محتوای پرتال');
            search.setAttribute('placeholder', 'جستجو در محتوای پرتال…');
        }
        var submit = document.querySelector('.searchbox input[type=image]');
        if (submit) { submit.alt = 'جستجو'; }
        var lists = document.querySelectorAll('.thumb_link');
        Array.prototype.forEach.call(lists, function (list) {
            if (list.getAttribute('data-glass-ready')) { return; }
            list.setAttribute('data-glass-ready', 'true');
            var items = list.querySelectorAll('li');
            Array.prototype.forEach.call(items, function (item, index) {
                var link = item.querySelector('a');
                if (!link) { return; }
                var image = link.querySelector('img');
                var title = link.getAttribute('title') || (image && image.alt) || link.textContent.trim();
                // Only replace an icon when a readable name is available.
                if (title) {
                    if (image) { image.hidden = true; }
                    var icon = document.createElementNS('http://www.w3.org/2000/svg', 'svg');
                    icon.setAttribute('viewBox', '0 0 24 24');
                    icon.setAttribute('class', 'glass-system-icon');
                    icon.setAttribute('aria-hidden', 'true');
                    var path = document.createElementNS(icon.namespaceURI, 'path');
                    path.setAttribute('d', 'M3 3h7v7H3z M14 3h7v7h-7z M3 14h7v7H3z M14 14h7v7h-7z');
                    path.setAttribute('fill', 'none');
                    path.setAttribute('stroke', 'currentColor');
                    path.setAttribute('stroke-width', '1.5');
                    icon.appendChild(path);
                    link.appendChild(icon);
                    var label = document.createElement('span');
                    label.textContent = title;
                    link.appendChild(label);
                }
                if (index >= 12) { item.hidden = true; }
            });
            if (items.length > 12) {
                // Progressive disclosure preserves every original destination and permission.
                var button = document.createElement('button');
                button.type = 'button';
                button.className = 'glass-all-link';
                button.textContent = 'نمایش همه پیوندها (' + items.length + ')';
                button.setAttribute('aria-expanded', 'false');
                button.addEventListener('click', function () {
                    var expanded = button.getAttribute('aria-expanded') !== 'true';
                    Array.prototype.forEach.call(items, function (item, index) {
                        if (index >= 12) { item.hidden = !expanded; }
                    });
                    button.setAttribute('aria-expanded', String(expanded));
                    button.textContent = expanded ? 'نمایش ۱۲ پیوند نخست' : 'نمایش همه پیوندها (' + items.length + ')';
                });
                list.parentNode.insertBefore(button, list);
            }
        });
        var gallery = document.querySelector('#pikame');
        if (gallery && !gallery.getAttribute('data-glass-ready')) {
            gallery.setAttribute('data-glass-ready', 'true');
            var slides = gallery.querySelectorAll('li');
            gallery.parentNode.classList.add('glass-slider');
            gallery.parentNode.setAttribute('role', 'region');
            gallery.parentNode.setAttribute('aria-label', 'گالری تصاویر سازمان');
            Array.prototype.forEach.call(slides, function (slide, index) {
                var image = slide.querySelector('img');
                var caption = slide.querySelector('span');
                var captionText = caption ? caption.textContent.trim() : '';
                if (!caption) { caption = document.createElement('span'); slide.appendChild(caption); }
                caption.className = 'glass-slide-caption';
                caption.textContent = '';
                var english = document.createElement('span');
                english.className = 'glass-slide-english';
                english.lang = 'en'; english.dir = 'ltr';
                english.textContent = 'ARVAND PETROCHEMICAL';
                var persian = document.createElement('span');
                persian.className = 'glass-slide-persian';
                persian.lang = 'fa'; persian.dir = 'rtl';
                persian.textContent = captionText || 'پتروشیمی اروند';
                caption.appendChild(english); caption.appendChild(persian);
                if (image && !image.alt) { image.alt = captionText || 'تصویر سازمان ' + (index + 1); }
            });
            if (slides.length > 1) {
                var current = 0;
                var controls = document.createElement('div');
                controls.className = 'glass-slider-controls';
                var status = document.createElement('span');
                status.setAttribute('aria-live', 'polite');
                status.className = 'glass-visually-hidden';
                var dots = document.createElement('div');
                dots.className = 'glass-slider-dots';
                var dotButtons = [];
                function show(next) {
                    current = (next + slides.length) % slides.length;
                    Array.prototype.forEach.call(slides, function (slide, index) { slide.hidden = index !== current; });
                    status.textContent = 'تصویر ' + (current + 1) + ' از ' + slides.length;
                    dotButtons.forEach(function (dot, index) {
                        if (index === current) { dot.setAttribute('aria-current', 'true'); }
                        else { dot.removeAttribute('aria-current'); }
                    });
                }
                ['تصویر قبلی', 'تصویر بعدی'].forEach(function (label, index) {
                    var button = document.createElement('button');
                    button.type = 'button';
                    button.setAttribute('aria-label', label);
                    button.className = 'glass-slider-arrow';
                    button.appendChild(lineIcon(index === 0 ? 'M9 5l7 7-7 7' : 'M15 5l-7 7 7 7'));
                    button.addEventListener('click', function () { show(current + (index === 0 ? -1 : 1)); });
                    controls.appendChild(button);
                });
                Array.prototype.forEach.call(slides, function (slide, index) {
                    var dot = document.createElement('button');
                    dot.type = 'button';
                    dot.setAttribute('aria-label', 'نمایش تصویر ' + (index + 1));
                    dot.addEventListener('click', function () { show(index); });
                    dotButtons.push(dot);
                    dots.appendChild(dot);
                });
                controls.appendChild(dots);
                controls.appendChild(status);
                gallery.parentNode.appendChild(controls);
                gallery.parentNode.classList.add('glass-slider');
                show(0);
            }
        }
    }
    if (document.readyState === 'loading') { document.addEventListener('DOMContentLoaded', init); } else { init(); }
    if (window.Sys && window.Sys.Application) { window.Sys.Application.add_load(init); }
}());
