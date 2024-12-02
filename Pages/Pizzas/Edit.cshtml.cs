using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PizzaritoShop.Data;
using PizzaritoShop.Data.Interfaces;
using PizzaritoShop.Data.Services;
using PizzaritoShop.Data.Services.Base;
using PizzaritoShop.Model;
using SQLitePCL;

namespace PizzaritoShop.Pages.Pizzas
{
    public class EditModel : PageModel
    {
        private readonly IProductService _productService;

        public EditModel(IProductService productService)
        {
            _productService = productService;
        }

        [BindProperty]
        public Product ProductDetails { get; set; } //Property to hold pizza details.

        public async Task<IActionResult> OnGetProductAsync(int id)
        {
            ProductDetails = await _productService.GetProductAsync(id);

            return ProductDetails == null ? NotFound() : Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                await _productService.UpdateAsync(id, ProductDetails);
                TempData["SuccessMessage"] = "Product updated successfully!";

                return Page();
            }
            catch (KeyNotFoundException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Page();
            }

        }


    }
}
