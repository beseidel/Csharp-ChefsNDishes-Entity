using System.ComponentModel.DataAnnotations;
using System;

using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;


namespace ChefsNDishes.Models
{
    public class Chef
    {
        // auto-implemented properties need to match the columns in your table
        // the [Key] attribute is used to mark the Model property being used for your table's Primary Key
        [Key]

        [Required]
        public int ChefId { get; set; }
        // MySQL VARCHAR and TEXT types can be represeted by a string

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string DateOfBirth { get; set; }

        // The MySQL DATETIME type can be represented by a DateTime
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // public int DishId { get; set; }

        // Navigation property for related Message objects
        public List<Dish> CreatedDishes { get; set; }


        // public Chef myChef = new Chef;


    }
}