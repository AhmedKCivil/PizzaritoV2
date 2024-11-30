//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Newtonsoft.Json.Linq;
//using PizzaritoShop.Data;
//using PizzaritoShop.Helpers;
//using PizzaritoShop.Model;
//using PizzaritoShop.Services;
//using System.Drawing;
//using System.Linq.Expressions;
//using System.Reflection.Metadata.Ecma335;

//namespace PizzaritoShop.Pages.Checkout
//{
//    [BindProperties(SupportsGet = true)]
//    public class CustomerDetailsModel : PageModel
//    {
//        private readonly ApplicationDbContext _context;
//        private readonly PayPalService _payPalService;
//        private const string CartSessionKey = "Cart";

//        public CustomerDetailsModel(ApplicationDbContext context, PayPalService payPalService)
//        {
//            _context = context;
//            _payPalService = payPalService;
//        }

//        public PizzaOrder PizzaOrder { get; set; }
//        public double TotalPrice { get; set; }
//        public List<CartItem> CartItems { get; set; }


//        public void OnGet()
//        {
//            CartItems = HttpContext.Session.GetObject<List<CartItem>>(CartSessionKey) ?? new List<CartItem>();
//            TotalPrice = CartItems.Sum(item => item.PizzaPrice * item.Quantity);

//            // Set order details if present in session
//            if (HttpContext.Session.TryGetValue("OrderId", out var orderIdBytes))
//            {
//                ViewData["OrderId"] = BitConverter.ToInt32(orderIdBytes);
//            }

//            // Set PayPal Client ID (for client-side integration)
//            ViewData["ClientId"] = "AXDfw1oWvNXjJv8U4Iju24B2qNBCfEHcgfjy_nq7kFVKv3IQGRbeOk6SvbFoV9Q8U-HtMgOsk4a0ejR4";

//        }

//        public async Task<IActionResult> OnPost()
//        {
//            // Retrieve cart items
//            CartItems = HttpContext.Session.GetObject<List<CartItem>>(CartSessionKey) ?? new List<CartItem>();
//            TotalPrice = CartItems.Sum(item => item.PizzaPrice * item.Quantity);

//            // Create a new order
//            var combinedPizzaNames = string.Join(", ", CartItems.Select(item => item.PizzaName));
//            var newOrder = new OrderListModel
//            {
//                CustomerName = PizzaOrder.CustomerName,
//                Address = PizzaOrder.Address,
//                PizzaName = combinedPizzaNames,
//                CartItems = CartItems,
//                Quantity = CartItems.Sum(item => item.Quantity),
//                TotalPrice = CartItems.Sum(item => item.PizzaPrice * item.Quantity),
//                CreatedDate = DateTime.Now
//            };

//            // Save order to the database
//            _context.OrdersTable.Add(newOrder);
//            await _context.SaveChangesAsync();
//            // Create PayPal order and get approval URL
//            var payment = await _payPalService.CreateOrderAsync((decimal)TotalPrice);

//            if (payment != null && payment.links != null)
//            {
//                // Get the PayPal approval URL for redirecting
//                var approvalUrl = payment.links.FirstOrDefault(link => link.rel == "approval_url")?.href;

//                if (!string.IsNullOrEmpty(approvalUrl))
//                {
//                    // Store OrderId in session before redirecting to PayPal
//                    HttpContext.Session.SetString("OrderId", newOrder.Id.ToString());

//                    // Redirect to PayPal for approval
//                    return Redirect(approvalUrl);
//                }
//            }

//            // If PayPal creation fails, return to the same page with an error
//            ModelState.AddModelError(string.Empty, "An error occurred while creating the PayPal order.");
//            return Page();
//        }

       

//    }
//}