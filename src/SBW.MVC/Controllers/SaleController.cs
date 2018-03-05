using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SBW.MVC.Data;
using SBW.MVC.Models;
using SBW.MVC.ViewModels;

namespace SBW.MVC.Controllers
{
    public class SaleController : Controller
    {
        private readonly ISaleRepository _salesRepository;
        private readonly ICustomerRepository _customerRepository;

        public SaleController(ISaleRepository saleRepository, ICustomerRepository customerRepository)
        {
            _salesRepository = saleRepository;
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public IActionResult Index([FromQuery]string description)
        {
            if (!String.IsNullOrWhiteSpace(description))
            {
                return View(_salesRepository.GetSalesByDescription(description).ToList());
            }

            return View(_salesRepository.GetAllSales().ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            // Create a view model with the Sale and a list of Names to fill the dropdown menu.
            SaleViewModel saleViewModel = new SaleViewModel
            {
                CustomerNamesListItem = new List<SelectListItem>(),
                Sale = new Sale()
                {
                    Date = DateTime.Today
                }
            };

            // Get the names for the dropdown menu.
            saleViewModel.CustomerNamesListItem = GetCustomerNamesListItem();

            return View(saleViewModel);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var sale = _salesRepository.GetSaleById(id);
            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        [HttpPost]
        public IActionResult Create([FromForm]SaleViewModel saleViewModel)
        {
            if (ModelState.IsValid)
            {
                _salesRepository.AddSale(saleViewModel.Sale);
                return RedirectToAction("Details", new { id = saleViewModel.Sale.Id });
            }

            saleViewModel.CustomerNamesListItem = GetCustomerNamesListItem();

            return View(saleViewModel);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            SaleViewModel saleViewModel = new SaleViewModel
            {
                CustomerNamesListItem = GetCustomerNamesListItem(),
                Sale = _salesRepository.GetSaleById(id)
            };

            return View(saleViewModel);
        }

        [HttpPost]
        public IActionResult Update([FromForm]SaleViewModel saleViewModel)
        {
            if (ModelState.IsValid)
            {
                _salesRepository.UpdateSale(saleViewModel.Sale);
                return RedirectToAction("Details", new { id = saleViewModel.Sale.Id});
            }

            saleViewModel.CustomerNamesListItem = GetCustomerNamesListItem();

            return View(saleViewModel);
        }

        private List<SelectListItem> GetCustomerNamesListItem()
        {
            List<Customer> customers = _customerRepository.GetAllCustomers().ToList();

            List<SelectListItem> selectListItems = new List<SelectListItem>();

            foreach (var customer in customers)
            {
                selectListItems.Add(new SelectListItem() { Text = customer.Name, Value = customer.Id.ToString() });
            }

            return selectListItems;
        }
    }
}