using System.ComponentModel.DataAnnotations;

namespace PizzaritoShop.Data.ViewModel
{
    public class NewPizzaVM
    {
        public int Id { get; set; }

        [Display(Name = "Pizza name")]
        [Required(ErrorMessage = "Name is required")]
        public string PizzaName { get; set; }

        [Display(Name = "Price in £")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Display(Name = "Pizza poster URL")]
        [Required(ErrorMessage = "Pizza poster URL is required")]
        public string ImageTitle { get; set; }

    }
}
