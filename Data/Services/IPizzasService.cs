using PizzaritoShop.Data.Services.Base;
using PizzaritoShop.Data.ViewModel;
using PizzaritoShop.Model;
using PizzaritoShop.Pages;

namespace PizzaritoShop.Data.Services
{
    public interface IPizzasService : IEntityBaseRepository<PizzasModel>
    {
        Task<PizzasModel> GetPizzasModelByIdAsync(int id);
        Task AddNewPizzaAsync(NewPizzaVM data);

    }
}
