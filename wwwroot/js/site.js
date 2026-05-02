// Scroll Reveal Logic
document.addEventListener('DOMContentLoaded', () => {
    const observerOptions = {
        threshold: 0.1,
        rootMargin: '0px 0px -50px 0px'
    };

    const observer = new IntersectionObserver((entries) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                entry.target.classList.add('active');
                observer.unobserve(entry.target);
            }
        });
    }, observerOptions);

    document.querySelectorAll('.reveal').forEach(el => observer.observe(el));

    // Close Mobile Navbar on Outside Click
    document.addEventListener('click', (e) => {
        const navbar = document.querySelector('.navbar');
        const collapse = document.querySelector('.navbar-collapse');
        const toggler = document.querySelector('.navbar-toggler');
        
        if (collapse.classList.contains('show') && !navbar.contains(e.target)) {
            // Using Bootstrap's Collapse instance to hide it
            const bsCollapse = bootstrap.Collapse.getInstance(collapse);
            if (bsCollapse) {
                bsCollapse.hide();
            } else {
                // Fallback for older bootstrap versions or if instance isn't initialized
                toggler.click();
            }
        }
    });
});
