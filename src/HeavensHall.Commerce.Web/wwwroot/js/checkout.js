'use strict';

const addToCart = (productId, quantity) => {
    let products = [];
    let cachedProducts = localStorage.getItem('cart_products');

    if (cachedProducts) {
        products = JSON.parse(cachedProducts).filter(product => product.id !== productId);
    }

    products.push({ id: productId, quantity: quantity });
    localStorage.setItem('cart_products', JSON.stringify(products));
}

const removeFromCart = productId => {
    let cachedProducts = JSON.parse(localStorage.getItem('cart_products'));

    let products = cachedProducts.filter(product => product.id !== productId);
    localStorage.setItem('cart_products', JSON.stringify(products));

    document.getElementById(productId).remove();
}

const setTotalAmount = () => {
    
}
