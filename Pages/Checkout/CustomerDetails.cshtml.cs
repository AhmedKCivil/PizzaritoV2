using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaritoShop.Data;
using PizzaritoShop.Helpers;
using PizzaritoShop.Model;
using System.Reflection.Metadata.Ecma335;

namespace PizzaritoShop.Pages.Checkout
{
    [BindProperties(SupportsGet = true)]
    public class CustomerDetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private const string CartSessionKey = "Cart";

        public CustomerDetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public PizzaOrder PizzaOrder { get; set; }
        public string PizzaName { get; set; }
        public double TotalPrice { get; set; }
        public string ImageTitle { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public List<CartItem> CartItems { get; set; }


        public void OnGet(List<CartItem> cartItems, double pizzaPrice)
        {
            CartItems = HttpContext.Session.GetObject<List<CartItem>>(CartSessionKey) ?? new List<CartItem>();
            TotalPrice = CartItems.Sum(item => item.PizzaPrice * item.Quantity);
        }

        public async Task<IActionResult> OnPost()
        {
            CartItems = HttpContext.Session.GetObject<List<CartItem>>(CartSessionKey) ?? new List<CartItem>();

            //if (CartItems.Count == 0)
            //{
            //    ModelState.AddModelError("", "Your cart is empty.");
            //    return Page();
            //}

            TotalPrice = CartItems.Sum(item => item.PizzaPrice * item.Quantity);
            var combinedPizzaNames = string.Join(", ", CartItems.Select(item => item.PizzaName));  // Combining pizza names

            var newOrder = new OrderListModel
            {
                CustomerName = PizzaOrder.CustomerName,
                Address = PizzaOrder.Address,
                PizzaName = combinedPizzaNames,  // This should now be populated with a combined string of pizza names
                CartItems = CartItems,
                Quantity = CartItems.Sum(item => item.Quantity),
                TotalPrice = CartItems.Sum(item => item.PizzaPrice * item.Quantity), // Total of all items in the cart
                CreatedDate = DateTime.Now
            };

            _context.OrdersTable.Add(newOrder);
            await _context.SaveChangesAsync();

            // Clear session and redirect after order
            HttpContext.Session.Remove(CartSessionKey);

            return RedirectToPage("/Checkout/ThankYou", new { OrderId = newOrder.Id });
        }










        //public async Task<IActionResult> OnPost()
        //{
        //    CartItems = HttpContext.Session.GetObject<List<CartItem>>(CartSessionKey) ?? new List<CartItem>();

        //    TotalPrice = CartItems.Sum(item => item.PizzaPrice * item.Quantity);

        //    var combinedPizzaNames = string.Join(", ", CartItems.Select(item => item.PizzaName));

        //    var newOrder = new OrderListModel
        //    {
        //        CustomerName = PizzaOrder.CustomerName,
        //        Address = PizzaOrder.Address,
        //        PizzaName = combinedPizzaNames,
        //        CartItems = CartItems,
        //        Quantity = CartItems.Sum(item => item.Quantity),
        //        PizzaPrice = PizzaOrder.PizzaPrice,
        //        TotalPrice = CartItems.Sum(item => item.PizzaPrice * item.Quantity), // Total of all items in the cart
        //        CreatedDate = DateTime.Now
        //    };

        //    _context.OrdersTable.Add(newOrder);

        //    await _context.SaveChangesAsync();

        //    TempData["CustomerName"] = PizzaOrder.CustomerName;
        //    TempData["Address"] = PizzaOrder.Address;
        //    TempData["TotalPrice"] = TotalPrice.ToString();
        //    TempData["CartItems"] = Newtonsoft.Json.JsonConvert.SerializeObject(CartItems);

        //    HttpContext.Session.Remove(CartSessionKey);

        //    return RedirectToPage("/Checkout/ThankYou", new
        //    {
        //        PizzaOrder.CustomerName,
        //        PizzaOrder.Address,
        //        newOrder.TotalPrice

        //    });
        //}



    }
}
