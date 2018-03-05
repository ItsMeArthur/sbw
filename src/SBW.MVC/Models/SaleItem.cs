using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SBW.MVC.Models
{
    public class SaleItem
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        [Required(ErrorMessage = "The price is required.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "The quantity is required.")]
        public int Quantity { get; set; }

        public int SaleId { get; set; }

        public Sale Sale { get; set; }
    }
}
