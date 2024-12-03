using PizzaritoShop.Model;

namespace PizzaritoShop.Data.Interfaces
{
    public interface IPaymentService
    {
        Task<Cart> CreateOrUpdatePaymentIntent(string cartId);
    }
}
