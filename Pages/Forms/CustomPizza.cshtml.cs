using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PizzaritoShop.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;
using static System.Collections.Specialized.BitVector32;
using System;

namespace PizzaritoShop.Pages.Forms
{
    public class CustomPizzaModel : PageModel
    {
        //[BindProperty]
        //public PizzasModel Pizza { get; set; }
        //public float PizzaPrice { get; set; }


        //public IActionResult OnPost()
        //{
        //    PizzaPrice = Pizza.BasePrice;

        //    if (Pizza.TomatoSauce) PizzaPrice += 1;
        //    if (Pizza.Cheese) PizzaPrice += 1;
        //    if (Pizza.Mushroom) PizzaPrice += 1;
        //    if (Pizza.Pineapple) PizzaPrice += 1;

        //    return RedirectToPage("/Checkout/Checkout", new {Pizza.PizzaName, PizzaPrice});

        //}
        
        //public void OnGet()
        //{
        //}
    }
}



//< h4 > CarModel </ h4 >
//< hr />
//< div class= "row" >
//    < div class= "col-md-4" >
//        < form method = "post" >
//            < div asp - validation - summary = "ModelOnly" class= "text-danger" ></ div >
//            < div class= "form-group" >
//                < label asp -for= "CarModel.PersonalCarName" class= "control-label" ></ label >
//                < input asp -for= "CarModel.PersonalCarName" class= "form-control" />
//                < span asp - validation -for= "CarModel.PersonalCarName" class= "text-danger" ></ span >
//            </ div >
//            < div class= "form-group form-check" >
//                < label class= "form-check-label" >
//                    < input class= "form-check-input" asp -for= "CarModel.Audi" /> @Html.DisplayNameFor(model => model.CarModel.Audi)
//                </ label >
//            </ div >
//            < div class= "form-group form-check" >
//                < label class= "form-check-label" >
//                    < input class= "form-check-input" asp -for= "CarModel.BMW" /> @Html.DisplayNameFor(model => model.CarModel.BMW)
//                </ label >
//            </ div >
//            < div class= "form-group form-check" >
//                < label class= "form-check-label" >
//                    < input class= "form-check-input" asp -for= "CarModel.A7" /> @Html.DisplayNameFor(model => model.CarModel.A7)
//                </ label >
//            </ div >
//            < div class= "form-group form-check" >
//                < label class= "form-check-label" >
//                    < input class= "form-check-input" asp -for= "CarModel.A3" /> @Html.DisplayNameFor(model => model.CarModel.A3)
//                </ label >
//            </ div >
//            < div class= "form-group form-check" >
//                < label class= "form-check-label" >
//                    < input class= "form-check-input" asp -for= "CarModel.FiveSeries" /> @Html.DisplayNameFor(model => model.CarModel.FiveSeries)
//                </ label >
//            </ div >
//            < div class= "form-group form-check" >
//                < label class= "form-check-label" >
//                    < input class= "form-check-input" asp -for= "CarModel.ThreeSeries" /> @Html.DisplayNameFor(model => model.CarModel.ThreeSeries)
//                </ label >
//            </ div >
//            < div class= "form-group form-check" >
//                < label class= "form-check-label" >
//                    < input class= "form-check-input" asp -for= "CarModel.Bhp1" /> @Html.DisplayNameFor(model => model.CarModel.Bhp1)
//                </ label >
//            </ div >
//            < div class= "form-group form-check" >
//                < label class= "form-check-label" >
//                    < input class= "form-check-input" asp -for= "CarModel.Bhp2" /> @Html.DisplayNameFor(model => model.CarModel.Bhp2)
//                </ label >
//            </ div >
//            < div class= "form-group form-check" >
//                < label class= "form-check-label" >
//                    < input class= "form-check-input" asp -for= "CarModel.PremiumFeatures" /> @Html.DisplayNameFor(model => model.CarModel.PremiumFeatures)
//                </ label >
//            </ div >
//            < div class= "form-group" >
//                < label asp -for= "CarModel.BasePrice" class= "control-label" ></ label >
//                < input asp -for= "CarModel.BasePrice" class= "form-control" />
//                < span asp - validation -for= "CarModel.BasePrice" class= "text-danger" ></ span >
//            </ div >
//            < div class= "form-group" >
//                < label asp -for= "CarModel.FinalPrice" class= "control-label" ></ label >
//                < input asp -for= "CarModel.FinalPrice" class= "form-control" />
//                < span asp - validation -for= "CarModel.FinalPrice" class= "text-danger" ></ span >
//            </ div >
//            < div class= "form-group" >
//                < input type = "submit" value = "Create" class= "btn btn-primary" />
//            </ div >
//        </ form >
//    </ div >
//</ div >

//< div >
//    < a asp - page = "Index" > Back to List</a>
//</div>

//@section Scripts {
//    @{await Html.RenderPartialAsync("_ValidationScriptsPartial");}
//}