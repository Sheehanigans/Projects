using FOS.MODELS.Interfaces;
using FOS.MODELS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.DATA
{
    public class TestProductRepository : IProductRepository
    {
        private static Product _product1 = new Product
        {
            ProductType = "Carpet",
            CostPerSquareFoot = 2.25M,
            LaborCostPerSquareFoot = 2.10M
        };

        private static Product _product2 = new Product
        {
            ProductType = "Wood",
            CostPerSquareFoot = 2.15M,
            LaborCostPerSquareFoot = 4.75M
        };

        public List<Product> GetProductList()
        {
            List<Product> products = new List<Product>();

            products.Add(_product1);
            products.Add(_product2);

            return products;
        }
    }
}
