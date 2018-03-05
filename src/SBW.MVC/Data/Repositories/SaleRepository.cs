using Microsoft.EntityFrameworkCore;
using SBW.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBW.MVC.Data
{
    public class SaleRepository : ISaleRepository
    {
        private readonly AppDbContext _dbContext;

        public SaleRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddItem(SaleItem saleItem)
        {
            _dbContext.SalesItems.Add(saleItem);
            _dbContext.SaveChanges();
        }

        public void AddSale(Sale sale)
        {
            _dbContext.Sales.Add(sale);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Sale> GetAllSales()
        {
            return _dbContext.Sales.Include(c => c.Customer);
        }

        public Sale GetSaleById(int id)
        {
            // Loads the sale and all related entities.
            return _dbContext.Sales.Include(c => c.Customer)
                .Include(si => si.SaleItems)
                .ThenInclude(p => p.Product)
                .FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<Sale> GetSalesByCustomer(int customerId)
        {
            return _dbContext.Sales.Include(c => c.Customer).Where(s => s.CustomerId == customerId).ToList();
        }

        public IEnumerable<Sale> GetSalesByDescription(string description)
        {
            return _dbContext.Sales.Include(c => c.Customer).Where(s => s.Description.Contains(description));
        }

        public void UpdateSale(Sale sale)
        {
            _dbContext.Sales.Update(sale);
            _dbContext.SaveChanges();
        }
    }
}
