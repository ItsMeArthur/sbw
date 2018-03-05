using SBW.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBW.MVC.Data
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByDescription(string description);
        Product GetProductById(int id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
    }
}
