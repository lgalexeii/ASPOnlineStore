function addToCart(productId) {
    $.ajax({
        url: '/carrito/AddToCart?productoId=' + productId,
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        cache: false,
        success: function (data) {
            alert("Se agrego el producto al carrito");
            $("#cartTotal").html(data.response.total );
            $("#cartTotalItems").html(data.response.cantidad);
        }
    });
}