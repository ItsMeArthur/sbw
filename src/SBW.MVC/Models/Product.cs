using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SBW.MVC.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Brand { get; set; }

        [Required]
        [MaxLength(255, ErrorMessage = "The description is required.")]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
