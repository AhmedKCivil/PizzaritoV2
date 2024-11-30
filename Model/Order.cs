using PizzaritoShop.Data.Services.Base;

namespace PizzaritoShop.Model
{
    public class Order : BaseEntity
    {
        public Order()
        {
            // we create this constractor because EF need it while migration
        }

        public Order(string user, OrderAddress shippingAddress, ICollection<OrderItem> items, decimal subTotal, string PaymentIntentId)
        {

        }
        public string User { get; set; }
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.UtcNow;
        public OrderAddress ShippingAddress { get; set; }
        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
        public decimal SubTotal { get; set; }
        public string PaymentIntentId { get; set; }
    }
}
