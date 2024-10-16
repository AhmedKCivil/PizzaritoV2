namespace PizzaritoShop.Model
{
    public class CartItem
    {
        public int PizzaId { get; set; }
        public string PizzaName { get; set; }
        public int Quantity { get; set; }
        public double PizzaPrice { get; set; }
        public string ImageTitle { get; set; }
        public double TotalPrice => Quantity * PizzaPrice;
    }



}
