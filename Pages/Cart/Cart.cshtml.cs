//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using PizzaritoShop.Model;
//using PizzaritoShop.Helpers;
//using PizzaritoShop.Data;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.Components.Web;
//using System.Reflection.PortableExecutable;
//using Microsoft.Identity.Client;

//namespace PizzaritoShop.Pages.Cart
//{
//    public class CartModel : PageModel
//    {
//        private readonly ApplicationDbContext _context;

//        public CartModel(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        private const string CartSessionKey = "Cart";

//        public List<CartItem> Cart { get; set; }
//        public double TotalPrice { get; set; }
//        public List<Product> Products { get; set; } = new List<Product>();

//        public void OnGet()
//        {
//            Products = _context.Products.OrderBy(p => Guid.NewGuid()).Take(3).ToList();

//            // Retrieve custom pizza from session
//            var customPizza = HttpContext.Session.GetObject<CustomPizza>("CustomPizza");

//            // Retrieve cart from session
//            Cart = HttpContext.Session.GetObject<List<CartItem>>(CartSessionKey) ?? new List<CartItem>();

//            // If there is a custom pizza in the session, add it to the cart if not already present
//            if (customPizza != null)
//            {
//                // Check if the custom pizza is already in the cart
//                var existingItem = Cart.FirstOrDefault(c => c.PizzaName == customPizza.PizzaName);
            
//                if (existingItem == null)
//                {
//                    //add a new pizza to the cart
//                    var cartItem = new CartItem
//                    {
//                        PizzaName = customPizza.PizzaName,
//                        PizzaPrice = customPizza.TotalPrice,
//                        Quantity = 1,
//                    };

//                        Cart.Add(cartItem);
//                }

//                 HttpContext.Session.Remove("CustomPizza");
//            }

            
//            HttpContext.Session.SetObject(CartSessionKey, Cart);

//            TotalPrice = Cart.Sum(item => item.PizzaPrice * item.Quantity);

//        }

//        public IActionResult OnPostAddToCart(int pizzaId, string pizzaName, double pizzaPrice)
//        {
//            Cart = HttpContext.Session.GetObject<List<CartItem>>(CartSessionKey) ?? new List<CartItem>();
            
//            var item = Cart.FirstOrDefault(c => c.PizzaId == pizzaId);

//            if (item != null)
//            {
//                item.Quantity++;

//            }
//            else
//            {
//                item = new CartItem { 
//                    PizzaId = pizzaId, 
//                    PizzaName = pizzaName, 
//                    PizzaPrice = pizzaPrice, 
//                    Quantity = 1 };

//                Cart.Add(item);
//            }

//            Cart = Cart.Where(c => c.Quantity > 0).ToList();

//            HttpContext.Session.SetObject(CartSessionKey, Cart);

//            // Store the OrderId in session for retrieval in later steps
//            HttpContext.Session.SetInt32("OrderId", newOrder.Id);

//            TotalPrice = Cart.Sum(i => i.PizzaPrice * i.Quantity);

//            return RedirectToPage("/Checkout/CustomerDetails", new
//            {
//                orderId = newOrder.Id
//            });
//        }

//        public IActionResult OnPostRemove(int pizzaId)
//        {
//             // Retrieve the cart from session
//            Cart = HttpContext.Session.GetObject<List<CartItem>>(CartSessionKey) ?? new List<CartItem>();

//            var removeItem = Cart.FirstOrDefault(p => p.PizzaId == pizzaId);

//            if (removeItem != null)
//            {
//                if (removeItem.Quantity > 1)
//                {
//                    // Reduce quantity by 1
//                    removeItem.Quantity--;
//                }
//                else
//                {
//                    // Remove item from the cart if quantity is 1
//                    Cart.Remove(removeItem);
//                }
//            }

//            if (Cart.Any())
//            {
//                // If there are items in the cart, update the session
//                HttpContext.Session.SetObject(CartSessionKey, Cart);
//            }
//            else
//            {
//                // If the cart is empty, remove the cart session
//                HttpContext.Session.Remove(CartSessionKey);
//            }


//            // Recalculate the total price
//            TotalPrice = Cart.Sum(i => i.PizzaPrice * i.Quantity);

//            return RedirectToPage("/Cart/Cart");
//        }

        
//    }
//}
