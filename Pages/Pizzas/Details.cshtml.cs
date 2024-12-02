using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaritoShop.Data.Interfaces;
using PizzaritoShop.Data.Services;
using PizzaritoShop.Data.Services.Base;
using PizzaritoShop.Model;

namespace PizzaritoShop.Pages.Pizzas
{
    public class DetailsModel : PageModel
    {
        private readonly IProductService _productService;

        public DetailsModel(IProductService productService)
        {
            _productService = productService;
        }

        public Product Product { get; set; } //Property to hold product details.

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Product = await _productService.GetProductAsync(id);

            return Product == null ? NotFound() : Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            try
            {
                await _productService.DeleteAsync(id);
                return RedirectToPage("/Pizzas/Products");
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

    }
}
