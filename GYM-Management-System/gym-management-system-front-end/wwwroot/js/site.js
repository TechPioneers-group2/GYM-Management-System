//
// Scripts
// 

window.addEventListener('DOMContentLoaded', event => {
    var navbarShrink = function () {
        const navbarCollapsible = document.body.querySelector('#mainNav');
        if (!navbarCollapsible) {
            return;
        }
        if (window.scrollY === 0) {
            navbarCollapsible.classList.remove('navbar-shrink');
            navbarCollapsible.classList.add('navbar-expanded');
        } else {
            navbarCollapsible.classList.remove('navbar-expanded');
            navbarCollapsible.classList.add('navbar-shrink');
        }
    };
    navbarShrink();
    document.addEventListener('scroll', navbarShrink);
});
