using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaritoShop.Data;

namespace PizzaritoShop.Pages.Checkout
{
    public class PaymentModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public PaymentModel(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public string PublishableKey => _configuration["Stripe:PublishableKey"];
        public string PizzaPriceId { get; set; } // Price ID for Stripe
        public int Quantity { get; set; }

        public async Task<IActionResult> OnGetAsync(int orderId)
        {
            var order = await _context.OrdersTable.FindAsync(orderId);

            // Assuming you have a method to get the Stripe Price ID based on the pizza/order
            PizzaPriceId = order?.GetStripePriceId();
            Quantity = order?.Quantity ?? 1;

            return Page();
        }
    }

}
