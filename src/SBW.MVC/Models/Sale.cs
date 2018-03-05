using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SBW.MVC.Models
{
    public class Sale
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public string Description { get; set; }

        [Required]
        [DataType(DataType.Date, ErrorMessage = "The date is required.")]
        public DateTime Date { get; set; }

        public bool IsActive { get; set; }

        public bool IsClosed { get; set; }

        public IEnumerable<SaleItem> SaleItems { get; set; }
    }
}
