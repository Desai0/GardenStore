// Задание 5 — Обновление счётчика корзины при загрузке любой страницы
document.addEventListener('DOMContentLoaded', async function () {
    try {
        // Запрашиваем у сервера актуальное число товаров в корзине
        // чтобы бейдж не сбрасывался в 0 при переходе между страницами
        const response = await fetch('/Catalog/GetCartCount');
        const data = await response.json();
        const badge = document.getElementById('cartBadge');
        if (badge) {
            badge.textContent = data.count > 0 ? data.count : '0';
        }
    } catch (error) {
        console.error('Не удалось получить количество товаров:', error);
    }
});

// Логика переключения фильтров каталога
document.addEventListener('DOMContentLoaded', function () {
    const filterButtons = document.querySelectorAll('[data-filter]');
    const filterSummary = document.querySelector('#filterSummary');

    filterButtons.forEach(function (button) {
        button.addEventListener('click', function () {
            filterButtons.forEach(function (item) {
                item.classList.remove('active', 'btn-primary');
                item.classList.add('btn-outline-secondary');
                item.setAttribute('aria-pressed', 'false');
            });

            button.classList.remove('btn-outline-secondary');
            button.classList.add('active', 'btn-primary');
            button.setAttribute('aria-pressed', 'true');

            if (filterSummary) {
                filterSummary.textContent = 'Выбран фильтр: ' + button.dataset.filter;
            }
        });
    });
});
