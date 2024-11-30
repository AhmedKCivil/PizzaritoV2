using PizzaritoShop.Data.Services.Base;

namespace PizzaritoShop.Model
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageCover { get; set; }
    }
}
