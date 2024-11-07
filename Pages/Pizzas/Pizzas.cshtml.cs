using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PizzaritoShop.Data;
using PizzaritoShop.Model;
using System.Reflection;
using PizzaritoShop.Helpers;

namespace PizzaritoShop.Pages.Pizzas
{
    public class PizzaModel : PageModel
    {
        private const string CartSessionKey = "Cart";
        private readonly ApplicationDbContext _context;

        public PizzaModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<PizzasModel> Pizzas { get; set; } = new List<PizzasModel>();
        
        [BindProperty(SupportsGet = true)]
        public string SearchQuery { get; set; }

       
        public async Task<IActionResult> OnGetAsync()
        {
            var query = _context.Pizzas.AsQueryable();

            if (!string.IsNullOrEmpty(SearchQuery))
            {
                query = query.Where(p => p.PizzaName.Contains(SearchQuery));
            }
            Pizzas = await query.ToListAsync();

            // Retrieve the cart from the session
            List<CartItem> cart = HttpContext.Session.GetObject<List<CartItem>>(CartSessionKey) ?? new List<CartItem>();

            // Calculate the total quantity in the cart
            int cartCount = cart.Sum(item => item.Quantity);

            // Set the cart count in ViewData for access in _Layout
            ViewData["CartCount"] = cartCount;

            return Page();
        }


        public IActionResult OnPost([FromForm] int pizzaId, [FromForm] string imageTitle, [FromForm] string pizzaName, [FromForm] double pizzaPrice)
        {
            // Retrieve the existing cart from session or create a new one
            List<CartItem> cart = HttpContext.Session.GetObject<List<CartItem>>(CartSessionKey) ?? new List<CartItem>();

            // Check if the pizza already exists in the cart
            var existingItem = cart.FirstOrDefault(c => c.PizzaName == pizzaName);
            if (existingItem != null)
            {
                // If the pizza already exists, increase the quantity
                existingItem.Quantity++;
            }
            else
            {
                // Otherwise, add a new pizza to the cart
                var cartItem = new CartItem
                {
                    PizzaId = pizzaId,
                    PizzaName = pizzaName,
                    PizzaPrice = pizzaPrice,
                    Quantity = 1,
                    ImageTitle = imageTitle
                };
                cart.Add(cartItem);
            }

            // Save the cart back to the session
            HttpContext.Session.SetObject(CartSessionKey, cart);

            //TempData["SuccessMessage"] = "Item added to cart!";

            return new JsonResult(new {cartCount = cart.Sum(item => item.Quantity)});

            //return RedirectToPage("/Pizzas/Pizzas"); // Redirect to same page to make customer shop more.

        }


        //ABOVE EXPLAINED CODE
        //Why Pass These Parameters?
        //Purpose of Passing Data: When the user chooses a pizza and submits the form, you want to keep track of which pizza they selected.
        //By passing ImageTitle and PizzaPrice, you ensure that the checkout page receives the relevant information about the selected pizza.
        //Usage on Checkout Page: In the /Checkout/Checkout page, you can then access these values to display the correct pizza information, calculate totals, or perform any other actions necessary for processing the order

    }
}
