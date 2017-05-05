﻿using System.ComponentModel.DataAnnotations;

namespace OdeToFood.Entities
{

    public enum CuisineType
    {
        None,
        Italian,
        French,
        American,
        Japanese

    }

    public class Restaurant
    {
        public int Id { get; set; }
        [Required, MaxLength(35)]
        [Display(Name = "Restaurant Name")]
        public string Name { get; set; }
        public CuisineType Cuisine { get; set; } 

    }
}
