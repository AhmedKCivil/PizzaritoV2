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
            try
            {
                var products = await _context.Products.ToListAsync();
                return products;


            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching the products.");
            }
        }

        public async Task<Product> GetProductAsync(int id)
        {
            try
            {
                var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
                
                if (product == null)
                {
                    throw new Exception($"Product with ID {id} not found.");
                }

                return product;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching the product.");

            }
        }

        public async Task UpdateAsync(int id, Product updatedProduct)
        {
            try
            {
                var existingProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
                if (existingProduct == null)
                {
                    throw new Exception($"Product with the ID {id} was not found");
                }
                existingProduct.Name = updatedProduct.Name;
                existingProduct.Description = updatedProduct.Description;
                existingProduct.Price = updatedProduct.Price;

                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception("Error while trying to update product.");
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var product =  await _context.Products.FindAsync(id);
                if (product == null)
                {
                    throw new Exception("Product was not found");

                }

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex) 
            {
                throw new Exception("An error occurred while removing the product.");
            }
        }
    }
}

