using Microsoft.EntityFrameworkCore;
using PizzaritoShop.Data.Services.Base;
using PizzaritoShop.Data.ViewModel;
using PizzaritoShop.Model;
using PizzaritoShop.Pages.Checkout;

namespace PizzaritoShop.Data.Services
{
    public class PizzasService : EntityBaseRepository<PizzasModel>, IPizzasService
    {
        private readonly ApplicationDbContext _context;
        public PizzasService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewPizzaAsync(NewPizzaVM data)
        {
            var newPizza = new PizzasModel()
            {
                PizzaName = data.PizzaName,
                Price = data.Price,
                ImageTitle = data.ImageTitle

            };

           await  _context.Pizzas.AddAsync(newPizza);
           await _context.SaveChangesAsync();
        }

        public async Task<PizzasModel> GetPizzasModelByIdAsync(int id)
        {
            var pizzaDetails = await _context.Pizzas.FirstOrDefaultAsync(p => p.Id == id);

            return pizzaDetails;
        }




    }
}
