using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaritoShop.Data.Services.Base;
using PizzaritoShop.Interfaces;
using PizzaritoShop.Model;

namespace PizzaritoShop.Pages.Pizzas
{
    public class DetailsModel : PageModel
    {
        private readonly IEntityBaseRepository<PizzasModel> _pizzaRepository;

        public DetailsModel(IEntityBaseRepository<PizzasModel> pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }

        public PizzasModel PizzaDetail { get; set; } //Property to hold pizza details.

        public async Task<IActionResult> OnGetAsync(int id)
        {
            PizzaDetail = await _pizzaRepository.GetByIdAsync(id);

            return PizzaDetail == null ? NotFound() : Page();
        }
    }
}
