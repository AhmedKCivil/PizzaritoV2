using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;
using PizzaritoShop.Model;
using PizzaritoShop.Pages.Forms;

namespace PizzaritoShop.Pages.Checkout
{
    [BindProperties(SupportsGet = true)]
    public class CheckoutModel : PageModel
    {
       public string PizzaName { get; set; }
       public double  PizzaPrice { get; set; }
       public string ImageTitle { get; set; }



        //public void OnGet()
        //{
        //    if (string.IsNullOrWhiteSpace(PizzaName))
        //    {
        //        PizzaName = "Custom";


        //    }
        //    if (string.IsNullOrWhiteSpace(ImageTitle))
        //    {
        //        ImageTitle = "Create";

        //    }

        //}

        //public IActionResult OnPost(string imageTitle, double pizzaPrice)
        //{
        //    return RedirectToPage("/Checkout/Checkout", new { ImageTitle = imageTitle, PizzaPrice = pizzaPrice });
        //}


        public IActionResult OnPost(string imageTitle, string pizzaName, double pizzaPrice)
        {
            return RedirectToPage("/Checkout/CustomerDetails", new { PizzaName = pizzaName, ImageTitle = imageTitle, PizzaPrice = pizzaPrice });
        }


        //public IActionResult OnPostConfirmOrder()
        //{
        //    return RedirectToPage("/Checkout/CustomerDetails", new
        //    {
        //        PizzaName = PizzaName,
        //        PizzaPrice = PizzaPrice,
        //        ImageTitle = ImageTitle
        //    });
        //}



    }
}

