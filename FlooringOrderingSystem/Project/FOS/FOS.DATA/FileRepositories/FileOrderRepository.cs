using FOS.MODELS;
using FOS.MODELS.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.DATA.FileRepositories
{
    public class FileOrderRepository : IOrderRepository
    {
        private const string ordersFilePath = @"C:\Repos\ryan-sheehan-individual-work\FlooringOrderingSystem\Data\Orders\Orders_";

        public bool Add(Order order)
        {
            bool added = false;
            string orderDate = order.Date.ToString("MMddyyyy");
            string orderPath = ordersFilePath + orderDate + ".txt";

            if (File.Exists(orderPath))
            {
                using (StreamWriter sw = new StreamWriter(orderPath, true))
                {
                    string line = CreateCSVForOrder(order);
                    sw.WriteLine(line);
                    added = true;
                }
            }
            else if(!File.Exists(orderPath))
            {
                using (File.Create(orderPath)) { }

                using (StreamWriter sw = new StreamWriter(orderPath, true))
                {
                    string header = CreateHeaderForOrderFile();
                    sw.WriteLine(header);

                    string line = CreateCSVForOrder(order);
                    sw.WriteLine(line);
                    added = true;
                }
            }

            return added;
        }

        private string CreateHeaderForOrderFile()
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}", "OrderNumber", "CustomerName", "State", 
                "TaxRate", "ProductType", "Area", "CostPerSquareFoot","LaborCostPerSquareFoot", "MaterialCost", "LaborCost", 
                "Tax", "Total");
        }

        private string CreateCSVForOrder(Order order)
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}",
                order.OrderNumber, order.CustomerName, order.State, order.TaxRate.ToString(),
                order.ProductType, order.Area.ToString(), order.CostPerSquareFoot.ToString(),
                order.LaborCostPerSquareFoot.ToString(), order.MaterialCost.ToString(), order.LaborCost.ToString(),
                order.Tax.ToString(), order.Total.ToString());
        }

        public bool Edit(Order order)
        {
            throw new NotImplementedException();
        }

        public Order GetSingleOrder(DateTime date, int orderNumber)
        {
            throw new NotImplementedException();
        }

        public List<Order> ListOrders()
        {
            throw new NotImplementedException();
        }

        public List<Order> ListOrdersForDate(DateTime date)
        {
            string fileDate = date.ToString("MMddyyyy");

            List<Order> orders = new List<Order>();

            if (File.Exists(ordersFilePath + fileDate + ".txt"))
            {
                using (StreamReader sr = new StreamReader(ordersFilePath + fileDate + ".txt"))
                {
                    sr.ReadLine();
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        Order orderInFile = new Order();

                        string[] columns = line.Split(',');

                        orderInFile.OrderNumber = int.Parse(columns[0]);
                        orderInFile.CustomerName = columns[1];
                        orderInFile.State = columns[2];
                        orderInFile.TaxRate = decimal.Parse(columns[3]);
                        orderInFile.ProductType = columns[4];
                        orderInFile.Area = decimal.Parse(columns[5]);
                        orderInFile.CostPerSquareFoot = decimal.Parse(columns[6]);
                        orderInFile.LaborCostPerSquareFoot = decimal.Parse(columns[7]);

                        orders.Add(orderInFile);
                    }
                }
            }
            else
            {
                orders = null;
            }

            return orders;
        }

        public bool Remove(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
