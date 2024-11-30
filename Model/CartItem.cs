namespace PizzaritoShop.Model
{
    public class CartItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageCover { get; set; }
        public string Quantity { get; set; }
        public bool StuffedCrust { get; set; }
        public bool ThinCrispy { get; set; }
        public bool Chicken { get; set; }
        public bool Pepperoni { get; set; }

    }
}
