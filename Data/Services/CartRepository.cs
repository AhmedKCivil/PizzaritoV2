using PizzaritoShop.Data.Interfaces;
using PizzaritoShop.Model;
using StackExchange.Redis;
using System.Text.Json;
using IDatabase = StackExchange.Redis.IDatabase;

namespace PizzaritoShop.Data.Services
{
    //public class CartRepository : ICartRepository
    //{
    //    private readonly ApplicationDbContext _context;

    //    public CartRepository(ApplicationDbContext context)
    //    {
    //        _context = context;
    //    }

    //    public async Task<Cart?> CreateOrUpdateCartAsync(Cart cart)
    //    {
    //        var createdOrUpdated = await _context.StringSetAsync(cart.Id, JsonSerializer.Serialize(cart), TimeSpan.FromDays(30));
    //        if (createdOrUpdated is false) return null;
    //        return await GetCartAsync(cart.Id);
    //    }

    //    public async Task<bool> DeleteCartAsync(string cartId)
    //    {
    //        return await _database.KeyDeleteAsync(cartId);
    //    }

    //    public async Task<Cart?> GetCartAsync(string cartId)
    //    {
    //        var cart = await _database.StringGetAsync(cartId);
    //        return cart.IsNullOrEmpty ? null : JsonSerializer.Deserialize<Cart>(cart);
    //    }
    //}
}
