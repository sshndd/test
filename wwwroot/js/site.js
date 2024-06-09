document.addEventListener('DOMContentLoaded', function () {
    var menuToggle = document.getElementById('menu-toggle');
    var sidebar = document.getElementById('sidebar');
    var overlay = document.getElementById('overlay');

    menuToggle.addEventListener('click', function () {
        sidebar.style.right = '0';
        overlay.classList.add('active');
    });

    overlay.addEventListener('click', function () {
        sidebar.style.right = '-250px';
        overlay.classList.remove('active');
    });
});
