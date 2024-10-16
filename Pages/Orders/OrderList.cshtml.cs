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
            //Cart = HttpContext.Session.GetObject<List<CartItem>>(CartSessionKey) ?? new List<CartItem>();
            //TotalPrice = Cart.Sum(item => item.PizzaPrice * item.Quantity);
            CartItems = HttpContext.Session.GetObject<List<CartItem>>(CartSessionKey) ?? new List<CartItem>();

            OrderList = await _context.OrdersTable.OrderByDescending(o => o.CreatedDate).ToListAsync();

            return Page();
        }


    }

}
