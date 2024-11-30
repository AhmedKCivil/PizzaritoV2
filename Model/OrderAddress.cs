namespace PizzaritoShop.Model
{
    public class OrderAddress
    {
        public OrderAddress()
        {

        }
        public OrderAddress(string fullName, string street, string postCode)
        {
            FullName = fullName;
            Street = street;
            PostCode = postCode;
        }

        public string FullName { get; set; }
        public string Street { get; set; }
        public string PostCode { get; set; }

    }
}
