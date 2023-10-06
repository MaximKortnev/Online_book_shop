// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function addToCart(productId) {
    $.ajax({
        url: '/Cart/Add/' + productId,
        type: 'POST',
        success: function (data) {
            $('#cartModal').modal('show');
        },
        error: function (error) {
            console.error('Error adding to cart: ' + error);
        }
    });
}