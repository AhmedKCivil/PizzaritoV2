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

            HttpContext.Session.SetObject(CartSessionKey, Cart);

            TotalPrice = Cart.Sum(i => i.PizzaPrice * i.Quantity);

            return RedirectToPage("/Checkout/CustomerDetails", new
            {
                PizzaPrice = TotalPrice
            });
        }


    }
}
