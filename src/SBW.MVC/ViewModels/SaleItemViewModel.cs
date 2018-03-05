using Microsoft.AspNetCore.Mvc.Rendering;
using SBW.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBW.MVC.ViewModels
{
    public class SaleItemViewModel
    {
        public List<SelectListItem> ProductNamesListItem { get; set; }
        public SaleItem SaleItem { get; set; }
    }
}
