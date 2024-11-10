//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.AspNetCore.Mvc;
//using PizzaritoShop.Data;
//using Microsoft.EntityFrameworkCore;

//public class PaymentModel : PageModel
//{
//    private readonly ApplicationDbContext _context;
//    private readonly IConfiguration _configuration;

//    public PaymentModel(ApplicationDbContext context, IConfiguration configuration)
//    {
//        _context = context;
//        _configuration = configuration;
//    }

//    public string PublishableKey => _configuration["Stripe:PublishableKey"];
//    public string PizzaPriceId { get; set; }
//    public int Quantity { get; set; }

//    public async Task<IActionResult> OnGetAsync(int orderId)
//    {
//        // Retrieve the order
//        var order = await _context.OrdersTable
//            .Include(o => o.CartItems)
//            .FirstOrDefaultAsync(o => o.Id == orderId);

//        if (order == null || order.CartItems == null || !order.CartItems.Any())
//        {
//            return NotFound("Order not found or empty.");
//        }

//        // Get the first item's Stripe Price ID and quantity for demonstration
//        var firstItem = order.CartItems.First();
//        var pizza = await _context.Pizzas
//            .FirstOrDefaultAsync(p => p.Id == firstItem.PizzaId);

//        if (pizza == null)
//        {
//            return NotFound("Pizza not found.");
//        }

//        PizzaPriceId = pizza.StripePriceId;
//        Quantity = firstItem.Quantity;

//        return Page();
//    }
//}
