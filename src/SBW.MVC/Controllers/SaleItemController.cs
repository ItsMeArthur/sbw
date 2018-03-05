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
    public class SaleItemController : Controller
    {
        private readonly ISaleRepository _salesRepository;
        private readonly IProductRepository _productRepository;

        public SaleItemController(ISaleRepository saleRepository, IProductRepository productRepository)
        {
            _salesRepository = saleRepository;
            _productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult AddItem([FromQuery] int saleId)
        {
            Sale sale = _salesRepository.GetSaleById(saleId);

            if (sale == null)
            {
                return NotFound();
            }

            SaleItemViewModel saleItemViewModel = new SaleItemViewModel
            {
                ProductNamesListItem = new List<SelectListItem>(),
                SaleItem = new SaleItem() { SaleId = sale.Id }
            };

            saleItemViewModel.ProductNamesListItem = GetProductNamesListItem();

            return View(saleItemViewModel);
        }

        [HttpPost]
        public IActionResult AddItem([FromForm]SaleItem saleItem)
        {
            if (ModelState.IsValid)
            {
                Sale sale = _salesRepository.GetSaleById(saleItem.SaleId);

                _salesRepository.AddItem(saleItem);

                return RedirectToAction("Details", "Sale", new { id = saleItem.SaleId });
            }

            SaleItemViewModel saleItemViewModel = new SaleItemViewModel
            {
                ProductNamesListItem = new List<SelectListItem>(),
                SaleItem = saleItem
            };

            saleItemViewModel.ProductNamesListItem = GetProductNamesListItem();

            return View(saleItemViewModel);         
        }

        private List<SelectListItem> GetProductNamesListItem()
        {
            List<Product> products = _productRepository.GetAllProducts().ToList();

            List<SelectListItem> selectListItems = new List<SelectListItem>();

            foreach (var product in products)
            {
                selectListItems.Add(new SelectListItem() { Text = product.Description, Value = product.Id.ToString() });
            }

            return selectListItems;
        }
    }
}