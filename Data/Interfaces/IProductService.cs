using PizzaritoShop.Model;
using PizzaritoShop.Pages.Pizzas;

namespace PizzaritoShop.Data.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetProductsAsync();
        Task<Product> GetProductAsync(int id);
        Task UpdateAsync(int id, Product updatedProduct);
        Task DeleteAsync(int id);

    }
}
