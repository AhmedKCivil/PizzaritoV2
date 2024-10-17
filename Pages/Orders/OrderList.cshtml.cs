using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PizzaritoShop.Data;
using PizzaritoShop.Helpers;
using PizzaritoShop.Model;

namespace PizzaritoShop.Pages.Orders
{
    public class OrdersModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private const string CartSessionKey = "Cart";

        public OrdersModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<OrderListModel> OrderList { get; set; } = new List<OrderListModel>();
        public List<CartItem> CartItems { get; set; }
        public double TotalPrice { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            
            //CartItems = HttpContext.Session.GetObject<List<CartItem>>(CartSessionKey) ?? new List<CartItem>();

            OrderList = await _context.OrdersTable.OrderByDescending(o => o.CreatedDate).ToListAsync();

            var ordersFromDb = await _context.OrdersTable.ToListAsync();

            foreach (var order in ordersFromDb)
            {
                if (!string.IsNullOrEmpty(order.SerializedCartItems))
                {
                    order.CartItems = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CartItem>>(order.SerializedCartItems);
                }
                else
                {
                    order.CartItems = new List<CartItem>(); // Initialize as empty list if null
                }
            }

            return Page();
        }


    }

}
