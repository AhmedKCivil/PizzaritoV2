//Function to update Cart count
function updateCartCount() {
    const cartItems = JSON.parse(sessionStorage.getItem("cartItems")) || [];
    const cartCount = cartItems.length;

    //Update the badge display
    document.getElementById("cart-count").textContent = cartCount;

}

