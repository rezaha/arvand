(function () {
    'use strict';
    function init() {
        if (!document.body.classList.contains('glass-ui')) { return; }
        // Move only rendered homepage branding, inside the same server form.
        var topbar = document.querySelector('.topnav');
        var branding = document.querySelector('.wrap > .header');
        if (topbar && branding) { topbar.insertBefore(branding, topbar.firstChild); }
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
            if (slides.length > 1) {
                var current = 0;
                var controls = document.createElement('div');
                controls.className = 'glass-slider-controls';
                var status = document.createElement('span');
                status.setAttribute('aria-live', 'polite');
                function show(next) {
                    current = (next + slides.length) % slides.length;
                    Array.prototype.forEach.call(slides, function (slide, index) { slide.hidden = index !== current; });
                    status.textContent = 'تصویر ' + (current + 1) + ' از ' + slides.length;
                }
                ['تصویر قبلی', 'تصویر بعدی'].forEach(function (label, index) {
                    var button = document.createElement('button');
                    button.type = 'button';
                    button.textContent = label;
                    button.addEventListener('click', function () { show(current + (index === 0 ? -1 : 1)); });
                    controls.appendChild(button);
                });
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
