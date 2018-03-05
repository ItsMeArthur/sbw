using SBW.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBW.MVC.Data
{
    public interface ISaleRepository
    {
        IEnumerable<Sale> GetAllSales();
        Sale GetSaleById(int id);
        IEnumerable<Sale> GetSalesByCustomer(int customerId);
        void AddSale(Sale sale);
        void UpdateSale(Sale sale);
        IEnumerable<Sale> GetSalesByDescription(string description);
        void AddItem(SaleItem saleItem);
    }
}
