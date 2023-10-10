// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function addToCart(productId) {
    $.ajax({
        url: '/cart/add?productId=' + productId,
        type: 'POST',
        success: function (data) {
            $('#cartModal').modal('show');
        },
        error: function (error) {
            console.error('Error adding to cart: ' + error);
        }
    });
}

function submitOrder() {
    const fullName = document.getElementById('fullName').value;
    const phone = document.getElementById('phone').value;
    const email = document.getElementById('email').value;
    const deliveryMethod = document.getElementById('deliveryMethod').value;
    const paymentMethod = document.getElementById('paymentMethod').value;
    const promoCode = document.getElementById('promoCode').value;
    const totalCost = document.getElementById('totalCost').value;

    const orderData = {
        fullName: fullName,
        phone: phone,
        email: email,
        deliveryMethod: deliveryMethod,
        paymentMethod: paymentMethod,
        promoCode: promoCode,
        totalCost: totalCost,
        // Добавьте информацию о товарах в заказ
        products: [
            { name: 'Товар 1', price: 500 },
            { name: 'Товар 2', price: 700 }
        ]
    };

    // Отправка данных на сервер
    fetch('/api/order', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(orderData)
    })
        .then(response => response.json())
        .then(data => {
            console.log('Ответ от сервера:', data);
            // Добавьте здесь логику для обработки ответа от сервера
        })
        .catch(error => {
            console.error('Произошла ошибка:', error);
        });
}