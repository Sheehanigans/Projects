using LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main()
        {
            //PrintAllProducts();
            //PrintAllCustomers();

            //Exercise1();
            //Exercise2();
            //Exercise3();
            //Exercise4();
            //Exercise5();
            //Exercise6();
            //Exercise7();
            //Exercise8();
            //Exercise9();
            //Exercise10();
            //Exercise11();
            //Exercise12();
            Exercise13();





            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        #region "Sample Code"
        /// <summary>
        /// Sample, load and print all the product objects
        /// </summary>
        static void PrintAllProducts()
        {
            List<Product> products = DataLoader.LoadProducts();
            PrintProductInformation(products);
        }

        /// <summary>
        /// This will print a nicely formatted list of products
        /// </summary>
        /// <param name="products">The collection of products to print</param>
        static void PrintProductInformation(IEnumerable<Product> products)
        {
            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            foreach (var product in products)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock);
            }

        }

        /// <summary>
        /// Sample, load and print all the customer objects and their orders
        /// </summary>
        static void PrintAllCustomers()
        {
            var customers = DataLoader.LoadCustomers();
            PrintCustomerInformation(customers);
        }

        /// <summary>
        /// This will print a nicely formated list of customers
        /// </summary>
        /// <param name="customers">The collection of customer objects to print</param>
        static void PrintCustomerInformation(IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine("==============================================================================");
                Console.WriteLine(customer.CompanyName);
                Console.WriteLine(customer.Address);
                Console.WriteLine("{0}, {1} {2} {3}", customer.City, customer.Region, customer.PostalCode, customer.Country);
                Console.WriteLine("p:{0} f:{1}", customer.Phone, customer.Fax);
                Console.WriteLine();
                Console.WriteLine("\tOrders");
                foreach (var order in customer.Orders)
                {
                    Console.WriteLine("\t{0} {1:MM-dd-yyyy} {2,10:c}", order.OrderID, order.OrderDate, order.Total);
                }
                Console.WriteLine("==============================================================================");
                Console.WriteLine();
            }
        }
        #endregion

        /// <summary>
        /// Print all products that are out of stock.
        /// </summary>
        static void Exercise1()
        {
            var allProducts = DataLoader.LoadProducts();

            var filtered = allProducts.Where(p => p.UnitsInStock == 0);

            PrintProductInformation(filtered);
        }

        /// <summary>
        /// Print all products that are in stock and cost more than 3.00 per unit.
        /// </summary>
        static void Exercise2()
        {
            var inStockOverThree = DataLoader.LoadProducts()
                .Where(i => i.UnitsInStock > 0)
                .Where(i => i.UnitPrice >= 3.00m);

            PrintProductInformation(inStockOverThree);

        }

        /// <summary>
        /// Print all customer and their order information for the Washington (WA) region.
        /// </summary>
        static void Exercise3()
        {
            var customersAndOrdersWA = DataLoader.LoadCustomers()
                .Where(i => i.Region == "WA");

            PrintCustomerInformation(customersAndOrdersWA);
        }

        /// <summary>
        /// Create and print an anonymous type with just the ProductName
        /// </summary>
        static void Exercise4()
        {
            var anon = DataLoader.LoadProducts()
                .Select(i => new
                {
                    ProdName = i.ProductName
                });

            foreach (var prod in anon)
            {
                Console.WriteLine(prod);
            }
            Console.ReadLine();

            //PrintCustomerInformation();
        }

        /// <summary>
        /// Create and print an anonymous type of all product information but increase the unit price by 25%
        /// </summary>
        static void Exercise5()
        {
            var anon = DataLoader.LoadProducts()
                .Select(i => new
                {
                    ProdID = i.ProductID,
                    ProdName = i.ProductName,
                    ProdCat = i.Category,
                    ProdPrice = i.UnitPrice * 1.25M,
                    ProdStock = i.UnitsInStock
                });

            foreach (var prod in anon)
            {
                Console.WriteLine(prod);
            }
            Console.ReadLine();

        }

        /// <summary>
        /// Create and print an anonymous type of only ProductName and Category with all the letters in upper case
        /// </summary>
        static void Exercise6()
        {
            var anon = DataLoader.LoadProducts()
                .Select(i => new
                {
                    ProdName = i.ProductName.ToUpper(),
                    ProdCat = i.Category.ToUpper()
                });

            foreach (var prod in anon)
            {
                Console.WriteLine(prod);
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra bool property ReOrder which should 
        /// be set to true if the Units in Stock is less than 3
        /// 
        /// Hint: use a ternary expression
        /// </summary>
        static void Exercise7()
        {
            var anon = DataLoader.LoadProducts()
                .Select(i => new
                {
                    ProdID = i.ProductID,
                    ProdName = i.ProductName,
                    ProdCat = i.Category,
                    ProdPrice = i.UnitPrice,
                    ProdStock = i.UnitsInStock,
                    Reorder = i.UnitsInStock < 3
                });

            foreach (var prod in anon)
            {
                Console.WriteLine(prod);
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra decimal called 
        /// StockValue which should be the product of unit price and units in stock
        /// </summary>
        static void Exercise8()
        {
            var anon = DataLoader.LoadProducts()
                .Select(i => new
                {
                    ProdID = i.ProductID,
                    ProdName = i.ProductName,
                    ProdCat = i.Category,
                    ProdPrice = i.UnitPrice,
                    ProdStock = i.UnitsInStock,
                    Reorder = i.UnitsInStock,
                    StockValue = i.UnitPrice * i.UnitsInStock
                });

            foreach (var prod in anon)
            {
                Console.WriteLine(prod);
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Print only the even numbers in NumbersA
        /// </summary>
        static void Exercise9()
        {
            var numbers = DataLoader.NumbersA;
            var evens = numbers.Where(i => i % 2 == 0);
            foreach (var nums in evens)
            {
                Console.WriteLine(nums);
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Print only customers that have an order whos total is less than $500
        /// </summary>
        static void Exercise10()
        {
            var allCustomers = DataLoader.LoadCustomers();

            allCustomers.Where(o => o.Orders.Any(total => total.Total < 500M));

            PrintCustomerInformation(allCustomers);


            
        }

        /// <summary>
        /// Print only the first 3 odd numbers from NumbersC
        /// </summary>
        static void Exercise11()
        {
            var numbers = DataLoader.NumbersC;
            var odds = numbers.Where(i => i % 2 == 1).Take(3);

            foreach (var nums in odds)
            {
                Console.WriteLine(nums);
            }
        }

        /// <summary>
        /// Print the numbers from NumbersB except the first 3
        /// </summary>
        static void Exercise12()
        {
            var numbers = DataLoader.NumbersC;
            var skip = numbers.Skip(3);

            foreach (var nums in skip)
            {
                Console.WriteLine(nums);
            }

        }

        /// <summary>
        /// Print the Company Name and most recent order for each customer in Washington
        /// </summary>
        static void Exercise13()
        {
            var anon = DataLoader.LoadCustomers()
               .Where(i => i.Region == "WA")
               .Select(i => new
               {
                   Name = i.CompanyName,
                   Reg = i.Region,
                   Ord = i.Orders.Last()
               });

            foreach (var ords in anon)
            {
                Console.WriteLine(ords.Name + " | " + ords.Reg + " | " + ords.Ord);
            }
            Console.ReadLine();

        }

        /// <summary>
        /// Print all the numbers in NumbersC until a number is >= 6
        /// </summary>
        static void Exercise14()
        {

        }

        /// <summary>
        /// Print all the numbers in NumbersC that come after the first number divisible by 3
        /// </summary>
        static void Exercise15()
        {

        }

        /// <summary>
        /// Print the products alphabetically by name
        /// </summary>
        static void Exercise16()
        {

        }

        /// <summary>
        /// Print the products in descending order by units in stock
        /// </summary>
        static void Exercise17()
        {

        }

        /// <summary>
        /// Print the list of products ordered first by category, then by unit price, from highest to lowest.
        /// </summary>
        static void Exercise18()
        {

        }

        /// <summary>
        /// Print NumbersB in reverse order
        /// </summary>
        static void Exercise19()
        {

        }

        /// <summary>
        /// Group products by category, then print each category name and its products
        /// ex:
        /// 
        /// Beverages
        /// Tea
        /// Coffee
        /// 
        /// Sandwiches
        /// Turkey
        /// Ham
        /// </summary>
        static void Exercise20()
        {

        }

        /// <summary>
        /// Print all Customers with their orders by Year then Month
        /// ex:
        /// 
        /// Joe's Diner
        /// 2015
        ///     1 -  $500.00
        ///     3 -  $750.00
        /// 2016
        ///     2 - $1000.00
        /// </summary>
        /// 

        //skip this one!!!!!!!!!!
        
        static void Exercise21()
        {

        }

        /// <summary>
        /// Print the unique list of product categories
        /// </summary>
        static void Exercise22()
        {

        }

        /// <summary>
        /// Write code to check to see if Product 789 exists
        /// </summary>
        static void Exercise23()
        {

        }

        /// <summary>
        /// Print a list of categories that have at least one product out of stock
        /// </summary>
        static void Exercise24()
        {

        }

        /// <summary>
        /// Print a list of categories that have no products out of stock
        /// </summary>
        static void Exercise25()
        {

        }

        /// <summary>
        /// Count the number of odd numbers in NumbersA
        /// </summary>
        static void Exercise26()
        {

        }

        /// <summary>
        /// Create and print an anonymous type containing CustomerId and the count of their orders
        /// </summary>
        static void Exercise27()
        {

        }

        /// <summary>
        /// Print a distinct list of product categories and the count of the products they contain
        /// </summary>
        static void Exercise28()
        {

        }

        /// <summary>
        /// Print a distinct list of product categories and the total units in stock
        /// </summary>
        static void Exercise29()
        {

        }

        /// <summary>
        /// Print a distinct list of product categories and the lowest priced product in that category
        /// </summary>
        static void Exercise30()
        {

        }

        /// <summary>
        /// Print the top 3 categories by the average unit price of their products
        /// </summary>
        static void Exercise31()
        {

        }
    }
}
