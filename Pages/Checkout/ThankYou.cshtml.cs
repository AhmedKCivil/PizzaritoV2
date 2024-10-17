using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaritoShop.Data;
using PizzaritoShop.Helpers;
using PizzaritoShop.Model;

namespace PizzaritoShop.Pages.Checkout
{
    [BindProperties(SupportsGet = true)]
    public class ThankYouModel : PageModel
    {
        private const string CartSessionKey = "Cart";

        public string CustomerName { get; set; }
        public string PizzaNames { get; set; }
        public string Address { get; set; }
        public double TotalPrice { get; set; }
        public List<CartItem> CartItems { get; set; }

        public IActionResult OnGet()
        {
            // Retrieve data from TempData
            CustomerName = TempData["CustomerName"] as string;
            Address = TempData["Address"] as string;


            // Convert the TotalPrice back to double
            if (double.TryParse(TempData["TotalPrice"] as string, out double totalPrice))
            {
                TotalPrice = totalPrice;
            }

            var cartItemsJson = TempData["CartItems"] as string;
            if (!string.IsNullOrEmpty(cartItemsJson))
            {
                CartItems = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CartItem>>(cartItemsJson);

            }

            if (CartItems == null || !CartItems.Any())
            {
                return RedirectToPage("/Pizzas/Pizzas");
            }



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
