using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace ChefsNDishes.Models
{
    public class Dish
    {
        [Key]
        public int DishId { get; set; }

        public string DishName { get; set; }

        public int Calories { get; set; }

        public int Tastiness { get; set; }

        public string Description { get; set; }


        public int CreatorId { get; set; }

        // Navigation property for related User object
        public Chef Creator { get; set; }
        // Creator

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }



    }
}