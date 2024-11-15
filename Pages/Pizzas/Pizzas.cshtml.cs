using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PizzaritoShop.Data;
using PizzaritoShop.Model;
using System.Reflection;
using PizzaritoShop.Helpers;
using Microsoft.AspNetCore.Authorization;
using System.Text.Json;
using System.Net.Http;
using Newtonsoft.Json;
using System.Reflection.PortableExecutable;
using PizzaritoShop.Data.Services.Base;
using PizzaritoShop.Interfaces;
using System.Linq.Expressions;

namespace PizzaritoShop.Pages.Pizzas
{
    public class PizzaModel : PageModel
    {
        private const string CartSessionKey = "Cart";
        private readonly IEntityBaseRepository<PizzasModel> _pizzaRepository;
        private readonly ApplicationDbContext _context;
        private readonly IHttpClientFactory _httpClientFactory;

        public PizzaModel(IEntityBaseRepository<PizzasModel> pizzaRepository, IHttpClientFactory httpClientFactory)
        {
            _pizzaRepository = pizzaRepository;
            _httpClientFactory = httpClientFactory;
        }

        public List<PizzasModel> Pizzas { get; set; } = new List<PizzasModel>();
        
        [BindProperty(SupportsGet = true)]
        public string SearchQuery { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {

            // Fetch pizzas from the repository method that handles both API and database
            Pizzas = await _pizzaRepository.GetAllPizzasAsync("https://localhost:7030/api/Pizzas");

            // Apply search filter if SearchQuery is provided
            if (!string.IsNullOrEmpty(SearchQuery))
            {
                Pizzas = Pizzas.Where(p => p.PizzaName.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            // Get the cart count from session
            var cart = HttpContext.Session.GetObject<List<CartItem>>(CartSessionKey) ?? new List<CartItem>();
            ViewData["CartCount"] = cart.Sum(item => item.Quantity);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync([FromForm] int pizzaId, [FromForm] string imageTitle, [FromForm] string pizzaName, [FromForm] double pizzaPrice)
        {
            // Call the repository method to handle the cart and add the pizza to the cart
            await _pizzaRepository.AddToCartAsync(pizzaId, imageTitle, pizzaName, pizzaPrice, CartSessionKey);

            // Get the updated cart count
            var cartCount = HttpContext.Session.GetObject<List<CartItem>>(CartSessionKey)?.Sum(item => item.Quantity) ?? 0;

            // Return the cart count as a JSON response
            return new JsonResult(new { cartCount });
        }


        //public IActionResult OnPost([FromForm] int pizzaId, [FromForm] string imageTitle, [FromForm] string pizzaName, [FromForm] double pizzaPrice)
        //{
        //    // Retrieve the existing cart from session or create a new one
        //    List<CartItem> cart = HttpContext.Session.GetObject<List<CartItem>>(CartSessionKey) ?? new List<CartItem>();

        //    // Check if the pizza already exists in the cart
        //    var existingItem = cart.FirstOrDefault(c => c.PizzaName == pizzaName);
        //    if (existingItem != null)
        //    {
        //        // If the pizza already exists, increase the quantity
        //        existingItem.Quantity++;
        //    }
        //    else
        //    {
        //        // Otherwise, add a new pizza to the cart
        //        var cartItem = new CartItem
        //        {
        //            PizzaId = pizzaId,
        //            PizzaName = pizzaName,
        //            PizzaPrice = pizzaPrice,
        //            Quantity = 1,
        //            ImageTitle = imageTitle
        //        };
        //        cart.Add(cartItem);
        //    }

        //    // Save the cart back to the session
        //    HttpContext.Session.SetObject(CartSessionKey, cart);

        //    return new JsonResult(new { cartCount = cart.Sum(item => item.Quantity) });
        //}


        //ABOVE EXPLAINED CODE
        //Why Pass These Parameters?
        //Purpose of Passing Data: When the user chooses a pizza and submits the form, you want to keep track of which pizza they selected.
        //By passing ImageTitle and PizzaPrice, you ensure that the checkout page receives the relevant information about the selected pizza.
        //Usage on Checkout Page: In the /Checkout/Checkout page, you can then access these values to display the correct pizza information, calculate totals, or perform any other actions necessary for processing the order


    }
}

//try
//{
//    // Option 1: Fetch from the API
//    var client = _httpClientFactory.CreateClient();
//    var response = await client.GetAsync("https://localhost:7030/api/Pizzas");

//    if (response.IsSuccessStatusCode)
//    {
//        var pizzasJson = await response.Content.ReadAsStringAsync();
//        var pizzas = JsonConvert.DeserializeObject<List<PizzasModel>>(pizzasJson);
//        Pizzas = pizzas;
//    }
//    else
//    {
//        // Handle API failure
//        ModelState.AddModelError(string.Empty, "Error fetching pizzas.");
//    }
//}
//catch (Exception ex)
//{
//    // Handle exception if API call fails
//    ModelState.AddModelError(string.Empty, "An error occurred while contacting the API.");
//}

//// Option 2: Fetch from the database (using repository) as a fallback if the API fails
//if (Pizzas == null || !Pizzas.Any())
//{
//    Pizzas = (await _pizzaRepository.GetAllAsync()).ToList();
//}


//// Apply search filter if SearchQuery is provided
//if (!string.IsNullOrEmpty(SearchQuery))
//{
//    // Filter pizzas based on the PizzaName containing the SearchQuery
//    Pizzas = Pizzas.Where(p => p.PizzaName.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase)).ToList();
//}

//var cart = HttpContext.Session.GetObject<List<CartItem>>(CartSessionKey) ?? new List<CartItem>();

//ViewData["CartCount"] = cart.Sum(item => item.Quantity);