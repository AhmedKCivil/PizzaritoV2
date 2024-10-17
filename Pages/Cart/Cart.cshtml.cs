using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaritoShop.Model;
using PizzaritoShop.Helpers;
using PizzaritoShop.Data;
using Microsoft.EntityFrameworkCore;

namespace PizzaritoShop.Pages.Cart
{
    public class CartModel : PageModel
    {
        private const string CartSessionKey = "Cart";

        public List<CartItem> Cart { get; set; }
        public double TotalPrice { get; set; }

        public void OnGet()
        {
            CustomPizza customPizza = HttpContext.Session.GetObject<CustomPizza>("CustomPizza");

            Cart = HttpContext.Session.GetObject<List<CartItem>>(CartSessionKey) ?? new List<CartItem>();
            TotalPrice = Cart.Sum(item => item.PizzaPrice * item.Quantity);

        }

        public IActionResult OnPostAddToCart(int pizzaId, string pizzaName, double pizzaPrice)
        {
            Cart = HttpContext.Session.GetObject<List<CartItem>>(CartSessionKey) ?? new List<CartItem>();
            
            var item = Cart.FirstOrDefault(c => c.PizzaId == pizzaId);

            if (item != null)
            {
                item.Quantity++;

            }
            else
            {
                item = new CartItem { PizzaId = pizzaId, PizzaName = pizzaName, PizzaPrice = pizzaPrice, Quantity = 1 };
                Cart.Add(item);
            }

            Cart = Cart.Where(c => c.Quantity > 0).ToList();


            HttpContext.Session.SetObject(CartSessionKey, Cart);

            TotalPrice = Cart.Sum(i => i.PizzaPrice * i.Quantity);

            return RedirectToPage("/Checkout/CustomerDetails", new
            {
                PizzaPrice = TotalPrice
            });
        }

        public IActionResult OnPostRemove(int pizzaId)
        {
             // Retrieve the cart from session
            Cart = HttpContext.Session.GetObject<List<CartItem>>(CartSessionKey) ?? new List<CartItem>();

            var removeItem = Cart.FirstOrDefault(p => p.PizzaId == pizzaId);

            if (removeItem != null)
            {
                if (removeItem.Quantity > 1)
                {
                    // Reduce quantity by 1
                    removeItem.Quantity--;
                }
                else
                {
                    // Remove item from the cart if quantity is 1
                    Cart.Remove(removeItem);
                }
            }

            if (Cart.Any())
            {
                // If there are items in the cart, update the session
                HttpContext.Session.SetObject(CartSessionKey, Cart);
            }
            else
            {
                // If the cart is empty, remove the cart session
                HttpContext.Session.Remove(CartSessionKey);
            }


            // Recalculate the total price
            TotalPrice = Cart.Sum(i => i.PizzaPrice * i.Quantity);

            return RedirectToPage("/Cart/Cart");
        }

        
    }
}
