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
        public double PizzaPrice { get; set; }
        public string ImageTitle { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public List<CartItem> CartItems { get; set; }
        public double TotalPrice { get; set; }


        public void OnGet(List<CartItem> cartItems, double pizzaPrice)
        {
            CartItems = HttpContext.Session.GetObject<List<CartItem>>(CartSessionKey) ?? new List<CartItem>();
            TotalPrice = CartItems.Sum(item => item.PizzaPrice * item.Quantity);
        }

        public async Task<IActionResult> OnPost()
        {
            CartItems = HttpContext.Session.GetObject<List<CartItem>>(CartSessionKey) ?? new List<CartItem>();
            TotalPrice = CartItems.Sum(item => item.PizzaPrice * item.Quantity);


            var combinedPizzaNames = string.Join(", ", CartItems.Select(item => item.PizzaName));

            Console.WriteLine("Combined Pizza Names: " + combinedPizzaNames);


            var newOrder = new OrderListModel
            {
                CustomerName = PizzaOrder.CustomerName,
                Address = PizzaOrder.Address,
                PizzaName = combinedPizzaNames,
                CartItems = CartItems,
                Quantity = CartItems.Sum(item => item.Quantity),
                PizzaPrice = PizzaOrder.PizzaPrice,
                TotalPrice = CartItems.Sum(item => item.PizzaPrice * item.Quantity), // Total of all items in the cart
                CreatedDate = DateTime.Now
            };

            _context.OrdersTable.Add(newOrder);

            await _context.SaveChangesAsync();

            return RedirectToPage("/Checkout/ThankYou", new
            {
                PizzaOrder.CustomerName,
                PizzaOrder.Address,
                newOrder.TotalPrice

            });
        }

        //public IActionResult OnPost(string customerName, string customerAddress, string pizzaName, double pizzaPrice)
        //{
        //    return RedirectToPage("/Checkout/ThankYou", new 
        //    {   CustomerName = customerName, 
        //        Address = customerAddress, 
        //        PizzaName = pizzaName, 
        //        PizzaPrice = pizzaPrice 
        //    });
        //}


        //public async Task<IActionResult> OnPostAsync()
        //{
        //    // Check if form data is valid
        //    //if (!ModelState.IsValid)
        //    //{
        //    //    return Page();
        //    //}


        //public IActionResult OnPost(string customerName, string address, string pizzaName,
        //    double price)
        //{
        //    if (!ModelState.IsValid)
        //    { 
        //        return Page();
        //    }

        //    PizzaOrder.PizzaName = pizzaName;





        //return RedirectToPage("/Checkout/Checkout", new { CustomerName = customerName,
        //    Address = address, PizzaName = pizzaName, Price = price});
        //}

    }
}
