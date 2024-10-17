using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PizzaritoShop.Data;
using PizzaritoShop.Helpers;
using PizzaritoShop.Model;

namespace PizzaritoShop.Pages.Checkout
{
    [BindProperties(SupportsGet = true)]
    public class ThankYouModel : PageModel
    {
        private const string CartSessionKey = "Cart";

        private readonly ApplicationDbContext _context;
        public ThankYouModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public string CustomerName { get; set; }
        public string PizzaNames { get; set; }
        public string Address { get; set; }
        public double TotalPrice { get; set; }
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();

        public int OrderId { get; set; }  // Get the OrderId from the query string


        public async Task<IActionResult> OnGetAsync()
        {

            // Fetch the order using OrderId passed via query string
            var order = await _context.OrdersTable
                .Include(o => o.CartItems)  // Include the related CartItems
                .FirstOrDefaultAsync(o => o.Id == OrderId);

            //if (order == null)
            //{
            //    // If no order found, redirect to the pizzas page
            //    return RedirectToPage("/Pizzas/Pizzas");
            //}

            // Populate the properties with the order details
            CustomerName = order.CustomerName;
            Address = order.Address;
            TotalPrice = order.TotalPrice;
            CartItems = order.CartItems;  // Retrieve the CartItems from the order

            return Page();
        }



        //private const string CartSessionKey = "Cart";
        //public ThankYouModel(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        //[BindProperty]
        //public PizzaOrder PizzaOrder { get; set; }
        //public string CustomerName { get; set; }
        //public string Address { get; set; }
        //public string PizzaName { get; set; }
        //public double TotalPrice { get; set; }
        //public List<CartItem> CartItems { get; set; }


        //public void OnGet()
        //{
        //    CartItems = HttpContext.Session.GetObject<List<CartItem>>(CartSessionKey) ?? new List<CartItem>();
        //    TotalPrice = CartItems.Sum(item => item.PizzaPrice * item.Quantity);



        //}



        //public async Task<IActionResult> OnPostAsync()
        //{
        //    var newOrder = new OrderListModel
        //    {
        //        CustomerName = PizzaOrder.CustomerName,
        //        Address = PizzaOrder.Address,
        //        PizzaName = PizzaOrder.PizzaName,
        //        PizzaPrice = PizzaOrder.PizzaPrice,
        //        TotalPrice = CartItems.Sum(item => item.PizzaPrice * item.Quantity),
        //        CreatedDate = DateTime.Now
        //    };

        //    _context.OrdersTable.Add(newOrder);

        //}






        //public void OnGet()
        //{
        //    if (string.IsNullOrWhiteSpace(PizzaName))
        //    {
        //        PizzaName = "Custom Pizza";


        //    }
        //    if (string.IsNullOrWhiteSpace(ImageTitle))
        //    {
        //        ImageTitle = "Create";

        //    }
        //}
    }
}
