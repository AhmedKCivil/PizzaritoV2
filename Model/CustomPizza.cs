namespace PizzaritoShop.Model
{
    public class CustomPizza
    {
        public int Id { get; set; }
        public string PizzaName { get; set; }
        public double BasePrice { get; set; } = 7.95;
        public double TotalPrice { get; set; }
        public bool StuffedCrust { get; set; }
        public bool ThinCrispy { get; set; }
        public bool Chicken { get; set; }
        public bool Pepperoni { get; set; }


    }
}
