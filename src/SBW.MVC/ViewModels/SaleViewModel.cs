using Microsoft.AspNetCore.Mvc.Rendering;
using SBW.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBW.MVC.ViewModels
{
    public class SaleViewModel
    {
        public List<SelectListItem> CustomerNamesListItem { get; set; }
        public Sale Sale { get; set; }
    }
}
