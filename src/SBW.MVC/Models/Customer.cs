using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SBW.MVC.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255, ErrorMessage = "The name is required.")]
        public string Name { get; set; }

        [Required]
        [MaxLength(255, ErrorMessage = "The address is required.")]
        public string Address { get; set; }

        [Required]
        [MaxLength(255, ErrorMessage = "The city is required.")]
        public string City { get; set; }

        [Required]
        [MaxLength(255, ErrorMessage = "The email is required.")]
        public string Email { get; set; }

        public bool IsActive { get; set; }
    }
}
