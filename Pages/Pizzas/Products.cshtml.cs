using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaritoShop.Data.Interfaces;
using PizzaritoShop.Model;

namespace PizzaritoShop.Pages.Pizzas
{
    public class ProductsModel : PageModel
    {
        private readonly IProductService _productService;

        public ProductsModel(IProductService productService)
        {
            _productService = productService;
        }

        public List<Product> Products { get; set; } = new List<Product>();

        public async Task<IActionResult> OnGetAsync()
        {
            Products = await _productService.GetProductsAsync();
            return Page();
        }
    }
}
