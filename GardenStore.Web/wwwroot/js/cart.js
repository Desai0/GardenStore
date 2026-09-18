// Задание 4 — Добавление в корзину через AJAX

const buttons = document.querySelectorAll('.add-to-cart');
buttons.forEach(function (btn) {
    btn.addEventListener('click', function () {
        const productId = this.dataset.productId;
        addToCart(productId, this);
    });
});

// функция addToCart
async function addToCart(productId, button) {
    const originalText = button.textContent;

    button.disabled = true;
    button.innerHTML =
        '<span class="spinner-border spinner-border-sm"></span> Добавление...';

    try {
        const response = await fetch('/Catalog/AddToCartAjax', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded'
            },
            body: 'id=' + productId
        });

        if (!response.ok) {
            throw new Error('HTTP ' + response.status);
        }

        const data = await response.json();

        if (data.success) {
            const badge = document.getElementById('cartBadge');
            badge.textContent = data.cartCount;

            button.innerHTML = 'Добавлено ✓';
            button.classList.remove('btn-primary');
            button.classList.add('btn-success');

            // Дополнительное задание (Лёгкий): показать Bootstrap Toast
            const toastEl = document.getElementById('cartToast');
            document.getElementById('cartToastText').textContent =
                'Товар «' + data.productName + '» добавлен в корзину';
            const toast = new bootstrap.Toast(toastEl, { delay: 3000 });
            toast.show();

            // Через 2 секунды вернуть исходное состояние кнопки
            setTimeout(function () {
                button.textContent = originalText;
                button.classList.remove('btn-success');
                button.classList.add('btn-primary');
                button.disabled = false;
            }, 2000);
        } else {
            alert('Ошибка: ' + data.message);
            button.textContent = originalText;
            button.disabled = false;
        }
    } catch (error) {
        console.error(error);
        button.textContent = 'Ошибка';
        button.disabled = false;
        setTimeout(function () {
            button.textContent = originalText;
        }, 2000);
    }
}
