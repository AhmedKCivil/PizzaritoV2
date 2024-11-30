//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using PizzaritoShop.Data.Services;
//using PizzaritoShop.Data.Services.Base;
//using PizzaritoShop.Model;

//namespace PizzaritoShop.Pages.Pizzas
//{
//    public class DetailsModel : PageModel
//    {
//        private readonly IPizzasService _pizzasService;

//        public DetailsModel(IPizzasService pizzasService)
//        {
//            _pizzasService = pizzasService;
//        }

//        public PizzasModel PizzaDetail { get; set; } //Property to hold pizza details.

//        public async Task<IActionResult> OnGetAsync(int id)
//        {
//            PizzaDetail = await _pizzasService.GetByIdAsync(id);

//            return PizzaDetail == null ? NotFound() : Page();
//        }

//        public async Task<IActionResult> OnPostDeleteAsync(int id)
//        {
//            try
//            {
//                await _pizzasService.DeleteAsync(id);
//                return RedirectToPage("/Pizzas/Pizzas"); 
//            }
//            catch (InvalidOperationException)
//            {
//                return NotFound();
//            }
//        }

//    }
//}
