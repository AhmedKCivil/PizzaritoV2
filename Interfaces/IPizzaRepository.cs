using PizzaritoShop.Model;

namespace PizzaritoShop.Interfaces
{
    public interface IPizzaRepository
    {
        ICollection<PizzasModel> GetPizzas();
        PizzasModel GetPizza(int id);
        PizzasModel GetPizza(string name);
        bool PizzaExists(int PizzaId);
        bool CreatePizza(PizzasModel pizza);
        bool UpdatePizza(PizzasModel pizza);
        bool DeletePizza(PizzasModel pizza);
        bool Save();
    }
}
