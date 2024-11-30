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
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PizzaritoShop.Data.Services;
using PizzaritoShop.Data.Interfaces;

namespace PizzaritoShop.Pages.Pizzas
{
    public class PizzaModel : PageModel
    {
        //private readonly IPizzasService _pizzasService;
        //private readonly IHttpClientFactory _httpClientFactory;
       
        private const string CartSessionKey = "Cart";
        private readonly IProductService _productService;

        public PizzaModel(IProductService productService)
        {
            _productService = productService;
        }

        //private readonly ICartRepository _cartRepository;


        public List<Product> Products { get; set; } = new List<Product>();
        public Product Product { get; set; } //Property to hold pizza details.

        [BindProperty(SupportsGet = true)]
        public string SearchQuery { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var products = await _productService.GetProductsAsync();
            return Page();

            //// Fetch pizzas using the PizzasService (API + Fallback to DB)
            //Products = await _productService.GetAllPizzasAsync("https://localhost:7030/api/Pizzas");

            //// Apply search filter if SearchQuery is provided
            //if (!string.IsNullOrEmpty(SearchQuery))
            //{
            //    Pizzas = Pizzas.Where(p => p.PizzaName.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase)).ToList();
            //}

            // Get the cart count from session
            //var cart = HttpContext.Session.GetObject<List<CartItem>>(CartSessionKey) ?? new List<CartItem>();

        }

        //public async Task<IActionResult> OnPostAsync([FromForm] int pizzaId, [FromForm] string imageTitle, [FromForm] string pizzaName, [FromForm] double pizzaPrice)
        //{
        //    // Handle adding pizza to cart
        //    await _pizzasService.AddToCartAsync(pizzaId, imageTitle, pizzaName, pizzaPrice, CartSessionKey);

        //    // Get the updated cart count
        //    var cartCount = HttpContext.Session.GetObject<List<CartItem>>(CartSessionKey)?.Sum(item => item.Quantity) ?? 0;

        //    // Return the cart count as a JSON response
        //    return new JsonResult(new { cartCount });
        //}
    }
}



    