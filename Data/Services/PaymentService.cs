using PizzaritoShop.Data.Interfaces;
using PizzaritoShop.Model;

namespace PizzaritoShop.Data.Services
{
    public class PaymentService : IPaymentService
    {
        public Task<Cart> CreateOrUpdatePaymentIntent(string cartId)
        {
            throw new NotImplementedException();
        }
    }
}
