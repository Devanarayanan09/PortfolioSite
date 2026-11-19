(function () {
    var root = document.documentElement;
    root.classList.add('js');

    function ready(fn) {
        if (document.readyState !== 'loading') fn();
        else document.addEventListener('DOMContentLoaded', fn);
    }

    ready(function () {
        // Theme toggle: explicit choice is stored; otherwise the OS preference applies.
        var themeBtn = document.getElementById('theme-toggle');
        if (themeBtn) {
            themeBtn.addEventListener('click', function () {
                var current = root.getAttribute('data-theme') ||
                    (window.matchMedia('(prefers-color-scheme: dark)').matches ? 'dark' : 'light');
                var next = current === 'dark' ? 'light' : 'dark';
                root.setAttribute('data-theme', next);
                try { localStorage.setItem('theme', next); } catch (e) { }
            });
        }

        // Mobile menu
        var menuBtn = document.getElementById('menu-toggle');
        var nav = document.getElementById('site-nav');
        function setMenu(open) {
            if (!menuBtn || !nav) return;
            nav.classList.toggle('is-open', open);
            menuBtn.setAttribute('aria-expanded', open ? 'true' : 'false');
            menuBtn.setAttribute('aria-label', open ? 'Close menu' : 'Open menu');
        }
        if (menuBtn && nav) {
            menuBtn.addEventListener('click', function (e) {
                e.stopPropagation();
                setMenu(!nav.classList.contains('is-open'));
            });
            document.addEventListener('click', function (e) {
                if (nav.classList.contains('is-open') && !nav.contains(e.target)) setMenu(false);
            });
            document.addEventListener('keydown', function (e) {
                if (e.key === 'Escape') setMenu(false);
            });
        }

        // Scroll reveal
        var items = document.querySelectorAll('.reveal');
        if (!('IntersectionObserver' in window)) {
            items.forEach(function (el) { el.classList.add('is-visible'); });
            return;
        }
        var observer = new IntersectionObserver(function (entries) {
            entries.forEach(function (entry) {
                if (entry.isIntersecting) {
                    entry.target.classList.add('is-visible');
                    observer.unobserve(entry.target);
                }
            });
        }, { threshold: 0.08, rootMargin: '0px 0px -40px 0px' });
        items.forEach(function (el) { observer.observe(el); });
    });
})();
