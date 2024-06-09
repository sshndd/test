document.addEventListener('DOMContentLoaded', function () {
    var menuToggle = document.getElementById('menu-toggle');
    var sidebar = document.getElementById('sidebar');
    var overlay = document.getElementById('overlay');
    var blurBackground = document.getElementById('blur-background'); // Получаем элемент размытия

    function openMenu() {
        sidebar.style.right = '0';
        overlay.classList.add('active');
        blurBackground.classList.add('active'); // Активируем размытие
    }

    function closeMenu() {
        sidebar.style.right = '-250px';
        overlay.classList.remove('active');
        blurBackground.classList.remove('active'); // Деактивируем размытие
    }

    menuToggle.addEventListener('click', function () {
        openMenu();
    });

    overlay.addEventListener('click', function () {
        closeMenu();
    });
});
