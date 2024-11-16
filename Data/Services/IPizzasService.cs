using PizzaritoShop.Data.Services.Base;
using PizzaritoShop.Data.ViewModel;
using PizzaritoShop.Model;
using PizzaritoShop.Pages;

namespace PizzaritoShop.Data.Services
{
    public interface IPizzasService
    {
        //Task<PizzasModel> GetPizzasModelByIdAsync(int id);
        Task AddNewPizzaAsync(NewPizzaVM data);
        Task AddToCartAsync(int pizzaId, string imageTitle, string pizzaName, double pizzaPrice, string cartSessionKey);
        Task UpdateAsync(int id, PizzasModel updatedPizza);
        Task<List<PizzasModel>> GetAllPizzasAsync(string apiUrl);
        Task<PizzasModel> GetByIdAsync(int id);

    }
}
