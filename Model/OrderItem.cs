using PizzaritoShop.Data.Services.Base;

namespace PizzaritoShop.Model
{
    public class OrderItem : BaseEntity
    {
        public OrderItem()
        {

        }
        public OrderItem(ProductOrderItem product, decimal price, decimal quantity)
        {
            Product = product;
            Price = price;
            Quantity = quantity;
        }

        public ProductOrderItem Product { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }

    }
}
