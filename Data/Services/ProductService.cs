using Microsoft.EntityFrameworkCore;
using PizzaritoShop.Data.Interfaces;
using PizzaritoShop.Model;

namespace PizzaritoShop.Data.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            var products = await _context.Products.ToListAsync();
            if (products == null || !products.Any())
            {
                throw new Exception("No products found in the database.");
            }
            return products;
        }

        public async Task<Product> GetProductAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            return product;
        }
    }
}

