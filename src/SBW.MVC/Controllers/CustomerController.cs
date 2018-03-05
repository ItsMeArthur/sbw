using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SBW.MVC.Data;
using SBW.MVC.Models;
using SBW.MVC.ViewModels;

namespace SBW.MVC.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public IActionResult Index([FromQuery]string name)
        {
            // Run a search if the parameter contains a value.
            if (!String.IsNullOrWhiteSpace(name))
            {
                return View(_customerRepository.GetCustomersByName(name).ToList());
            }
            return View(_customerRepository.GetAllCustomers().ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm]Customer customer)
        {
            // Check if the model is valid before saving it.
            if (ModelState.IsValid)
            {
                _customerRepository.AddCustomer(customer);
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Customer customer = _customerRepository.GetCustomerById(id);
            return View(customer);
        }

        [HttpPost]
        public IActionResult Update([FromForm]Customer customer)
        {
            // Also check if the model is valid before updating it.
            if (ModelState.IsValid)
            {
                _customerRepository.UpdateCustomer(customer);
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var customer = _customerRepository.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        [HttpGet]
        public IActionResult ActiveCustomersCount()
        {
            // Returns the count of active customers (To be called via ajax).
            return Content(_customerRepository.GetActiveCustomersCount().ToString());
        }
    }
}