namespace PizzaritoShop.Model
{
    public class PizzaOrder
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string PizzaName { get; set; }
        public double PizzaPrice { get; set; }
        public double TotalPrice { get; set; }
    }
}

