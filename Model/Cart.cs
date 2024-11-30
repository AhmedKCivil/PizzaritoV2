using Microsoft.Identity.Client;

namespace PizzaritoShop.Model
{
    public class Cart
    {
        public string Id { get; set; }
        public List<CartItem> Items { get; set; }
        public string? PaymentIntentId { get; set; }
        public string? ClientSecret { get; set; }
        public Cart(string id)
        {
            Id = id;
            Items = new List<CartItem>();
        }
    }
}
