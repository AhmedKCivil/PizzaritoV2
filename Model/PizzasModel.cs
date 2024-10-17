﻿using PizzaritoShop.Data.Services.Base;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace PizzaritoShop.Model
{
    public class PizzasModel : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Pizza Name")]
        public string PizzaName { get; set; }
        [Required]
        [Display(Name = "Price")]
        public double Price { get; set; }
        [Required]
        [Display(Name = "Image URL")]
        public string ImageTitle { get; set; }

        //public bool TomatoSauce { get; set; }
        //public bool Cheese { get; set; }
        //public bool Mushroom { get; set; }
        //public bool Pineapple { get; set; }
    }
}

