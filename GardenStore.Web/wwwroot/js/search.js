// Задание 3 — Live-поиск без перезагрузки страницы

const input = document.getElementById('searchInput');
const grid = document.getElementById('catalogGrid');

let timeoutId;
input.addEventListener('input', function () {
    clearTimeout(timeoutId);

    const query = input.value.trim();

    if (query.length < 2) {
        window.location.reload();
        return;
    }

    timeoutId = setTimeout(function () {
        searchProducts(query);
    }, 300);
});

async function searchProducts(query) {
    grid.innerHTML =
        '<div class="text-center py-5">' +
        '<div class="spinner-border text-primary"></div>' +
        '</div>';

    try {
        const url = '/Catalog/Search?query=' + encodeURIComponent(query);
        const response = await fetch(url);

        if (!response.ok) {
            throw new Error('HTTP ' + response.status);
        }

        const html = await response.text();

        if (!html.trim()) {
            grid.innerHTML =
                '<div class="alert alert-info">Ничего не найдено</div>';
        } else {
            grid.innerHTML = html;
        }
    } catch (error) {
        grid.innerHTML =
            '<div class="alert alert-danger">Ошибка поиска</div>';
        console.error(error);
    }
}
