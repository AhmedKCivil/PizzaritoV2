using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaritoShop.Data.Services;
using PizzaritoShop.Data.Services.Base;
using PizzaritoShop.Interfaces;
using PizzaritoShop.Model;

namespace PizzaritoShop.Pages.Pizzas
{
    public class DetailsModel : PageModel
    {
        private readonly IPizzasService _pizzasService;

        public DetailsModel(IPizzasService pizzasService)
        {
            _pizzasService = pizzasService;
        }

        public PizzasModel PizzaDetail { get; set; } //Property to hold pizza details.

        public async Task<IActionResult> OnGetAsync(int id)
        {
            PizzaDetail = await _pizzasService.GetByIdAsync(id);

            return PizzaDetail == null ? NotFound() : Page();
        }
    }
}
