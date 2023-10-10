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
    const fullName = $('#fullName').val();
    const phone = $('#phone').val();
    const email = $('#email').val();
    const deliveryMethod = $('#deliveryMethod').val();
    const paymentMethod = $('#paymentMethod').val();
    const promoCode = $('#promoCode').val();
    const totalCost = $('#totalCost').val();

    const orderData = {
        fullName: fullName,
        phone: phone,
        email: email,
        deliveryMethod: deliveryMethod,
        paymentMethod: paymentMethod,
        promoCode: promoCode,
        totalCost: totalCost
    };


    fetch("/Order/OrdersToFile", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(orderData)
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.json();
        })
        .then(data => {
            console.log('Ответ от сервера:', data);
            $('#orderSuccessModal').modal('show');
            // Добавьте здесь логику для обработки ответа от сервера
        })
        .catch(error => {
            console.error('Произошла ошибка:', error);
        });
}