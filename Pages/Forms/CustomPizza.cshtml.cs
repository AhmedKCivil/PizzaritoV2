using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaritoShop.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;
using static System.Collections.Specialized.BitVector32;
using System;
using Microsoft.AspNetCore.Http;
using PizzaritoShop.Helpers;

namespace PizzaritoShop.Pages.Forms
{
    [BindProperties(SupportsGet = true)]
    public class CustomPizzaModel : PageModel
    {
        private const string CartSessionKey = "Cart";
        public CustomPizza CustomPizza { get; set; }
        public double PizzaPrice { get; set; }

        public IActionResult OnPost()
        {
            PizzaPrice = CustomPizza.BasePrice;

            // Adjust price based on selected options
            if (CustomPizza.StuffedCrust) PizzaPrice += 4.5;
            if (CustomPizza.ThinCrispy) PizzaPrice += 2.5;
            if (CustomPizza.Chicken) PizzaPrice += 6.5;
            if (CustomPizza.Pepperoni) PizzaPrice += 5.5;

            CustomPizza.TotalPrice = PizzaPrice;

            var customPizzaCartItem = new CartItem
            {
                PizzaId = CustomPizza.Id,
                PizzaName = "Custom Pizza",
                PizzaPrice = PizzaPrice,
                Quantity = 1
            };

            var cart = HttpContext.Session.GetObject<List<CartItem>>(CartSessionKey) ?? new List<CartItem>();

            cart.Add(customPizzaCartItem);

            // Store the custom pizza object in the session
            HttpContext.Session.SetObject("CustomPizza", CustomPizza);

            return RedirectToPage("/Cart/Cart");
               
        }

     
    }
}



