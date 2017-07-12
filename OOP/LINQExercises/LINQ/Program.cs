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
            //Exercise13();
            //Exercise14();
            //Exercise15();
            //Exercise16();
            //Exercise17();
            //Exercise18();
            //Exercise19();
            //Exercise20();
            //Exercise21(); //<----- Errors out, change print method
            //Exercise22();
            //Exercise23();
            //Exercise24();
            //Exercise25();
            //Exercise26();
            //Exercise27();
            Exercise28();
            //Exercise29();
            //Exercise30();
            //Exercise31();

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
            List<Product> products = DataLoader.LoadProducts();
            IEnumerable<Product> filtered = products.Where(product => product.UnitsInStock <= 0);

            PrintProductInformation(filtered);
        }

        /// <summary>
        /// Print all products that are in stock and cost more than 3.00 per unit.
        /// </summary>
        static void Exercise2()
        {
            List<Product> products = DataLoader.LoadProducts();
            IEnumerable<Product> filtered = products.Where(product => product.UnitPrice > 3M && product.UnitsInStock > 0);

            PrintProductInformation(filtered);
        }

        /// <summary>
        /// Print all customer and their order information for the Washington (WA) region.
        /// </summary>
        static void Exercise3()
        {
            List<Customer> customers = DataLoader.LoadCustomers();
            var cByRegion = customers.Where(c => c.Region == "WA");

            PrintCustomerInformation(cByRegion);
        }

        /// <summary>
        /// Create and print an anonymous type with just the ProductName
        /// </summary>
        static void Exercise4()
        {
            List<Product> products = DataLoader.LoadProducts();
            var productNames = products.Select(p => new { ProductName = p.ProductName });
            string line = "{0,-35}";
            Console.WriteLine(line, "Product Name");
            Console.WriteLine("==============================================================================");
            foreach (var name in productNames)
            {
                Console.WriteLine(line, name.ProductName);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all product information but increase the unit price by 25%
        /// </summary>
        static void Exercise5()
        {
            List<Product> products = DataLoader.LoadProducts();

            var priceChange = products.Select(product => new
            {
                product.ProductID,
                product.ProductName,
                product.Category,
                newPrice = product.UnitPrice + (product.UnitPrice * .25M),
                product.UnitsInStock
            });
            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            foreach (var product in priceChange)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.newPrice, product.UnitsInStock);
            }

        }

        /// <summary>
        /// Create and print an anonymous type of only ProductName and Category with all the letters in upper case
        /// </summary>
        static void Exercise6()
        {
            List<Product> products = DataLoader.LoadProducts();

            var onlyNameAndCategory = products.Select(product => new
            {
                upperName = product.ProductName.ToUpper(),
                upperCategory = product.Category.ToUpper()
            });

            string line = "{0,-35} {1,-15}";
            Console.WriteLine(line, "Product Name", "Category");
            Console.WriteLine("==============================================================================");
            foreach (var name in onlyNameAndCategory)
            {
                Console.WriteLine(line, name.upperName, name.upperCategory);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra bool property ReOrder which should 
        /// be set to true if the Units in Stock is less than 3
        /// 
        /// Hint: use a ternary expression
        /// </summary>
        static void Exercise7()
        {
            List<Product> products = DataLoader.LoadProducts();

            var shortStock = products.Select(product => new
            {
                product.ProductID,
                product.ProductName,
                product.Category,
                product.UnitPrice,
                product.UnitsInStock,
                ReOrder = product.UnitsInStock < 3
            });

            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6} {5,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock", "Reorder?");
            Console.WriteLine("==============================================================================");

            foreach (var product in shortStock)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                product.UnitPrice, product.UnitsInStock, product.ReOrder);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra decimal called 
        /// StockValue which should be the product of unit price and units in stock
        /// </summary>
        static void Exercise8()
        {
            List<Product> products = DataLoader.LoadProducts();

            var stockPrice = products.Select(product => new
            {
                product.ProductID,
                product.ProductName,
                product.Category,
                product.UnitPrice,
                product.UnitsInStock,
                StockValue = product.UnitsInStock * product.UnitPrice
            });

            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6} {5,12:c}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock", "Stock Value");
            Console.WriteLine("==============================================================================");

            foreach (var product in stockPrice)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                product.UnitPrice, product.UnitsInStock, product.StockValue);
            }
        }

        /// <summary>
        /// Print only the even numbers in NumbersA
        /// </summary>
        static void Exercise9()
        {
            int[] numbers = DataLoader.NumbersA;
            var evens = numbers.Where(number => number % 2 == 0);
            foreach (var number in evens)
            {
                Console.WriteLine(number);
            }
        }

        /// <summary>
        /// Print only customers that have an order whos total is less than $500
        /// </summary>
        static void Exercise10()
        {
            List<Customer> customers = DataLoader.LoadCustomers();
            var smallOrders = customers.Where(customer => customer.Orders.Any(order => order.Total < 500M));
            PrintCustomerInformation(smallOrders);
        }

        /// <summary>
        /// Print only the first 3 odd numbers from NumbersC
        /// </summary>
        static void Exercise11()
        {
            int[] numbers = DataLoader.NumbersC;
            var oddNums = numbers.Where(number => number % 2 == 1).Take(3);

            foreach (var number in oddNums)
            {
                Console.WriteLine(number);
            }
        }

        /// <summary>
        /// Print the numbers from NumbersB except the first 3
        /// </summary>
        static void Exercise12()
        {
            int[] numbers = DataLoader.NumbersB;
            var skipThree = numbers.Skip(3);

            foreach (var number in skipThree)
            {
                Console.WriteLine(number);
            }
        }

        /// <summary>
        /// Print the Company Name and most recent order for each customer in Washington
        /// </summary>
        static void Exercise13()
        {
            List<Customer> customers = DataLoader.LoadCustomers();
            var washCustomers = customers.Where(customer => customer.Region == "WA")
                .Select(c => new
            {
                c.CompanyName,
                mro = c.Orders.OrderByDescending(order => order.OrderDate)
                .First()
            });


            foreach (var c in washCustomers)
            {

                Console.WriteLine(c.CompanyName);
                Console.WriteLine("==============================================================================");
                Console.WriteLine();
                Console.WriteLine("\t{0} {1:MM-dd-yyyy} {2,10:c}", c.mro.OrderID, c.mro.OrderDate, c.mro.Total);
                Console.WriteLine("==============================================================================");
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Print all the numbers in NumbersC until a number is >= 6
        /// </summary>
        static void Exercise14()
        {
            int[] numbers = DataLoader.NumbersC;
            var printUntilSix = numbers.TakeWhile(number => number <= 6);
            foreach (var number in printUntilSix)
            {
                Console.WriteLine(number);
            }
        }

        /// <summary>
        /// Print all the numbers in NumbersC that come after the first number divisible by 3
        /// </summary>
        static void Exercise15()
        {
            int[] numbers = DataLoader.NumbersC;
            var printAfterThree = numbers.SkipWhile(number => !(number % 3 == 0)).Skip(1);
            foreach (var number in printAfterThree)
            {
                Console.WriteLine(number);
            }
            //check first num
        }

        /// <summary>
        /// Print the products alphabetically by name
        /// </summary>
        static void Exercise16()
        {
            List<Product> products = DataLoader.LoadProducts();
            var sortProducts = products.OrderBy(product => product.ProductName);
            PrintProductInformation(sortProducts);
        }

        /// <summary>
        /// Print the products in descending order by units in stock
        /// </summary>
        static void Exercise17()
        {
            List<Product> products = DataLoader.LoadProducts();
            var sortDesc = products.OrderByDescending(product => product.UnitsInStock);
            PrintProductInformation(sortDesc);
        }

        /// <summary>
        /// Print the list of products ordered first by category, then by unit price, from highest to lowest.
        /// </summary>
        static void Exercise18()
        {
            List<Product> products = DataLoader.LoadProducts();
            var sortCatThenPrice = products.OrderBy(product => product.Category).ThenByDescending(p => p.UnitPrice);
            PrintProductInformation(sortCatThenPrice);
        }

        /// <summary>
        /// Print NumbersB in reverse order
        /// </summary>
        static void Exercise19()
        {
            int[] numbers = DataLoader.NumbersB;
            var reverseOrder = numbers.Reverse();
            foreach (var num in reverseOrder)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
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
            List<Product> products = DataLoader.LoadProducts();
            var byCategory = products.GroupBy(product => product.Category);
            foreach (var category in byCategory)
            {
                Console.WriteLine(category.Key);
                foreach (var product in category)
                {
                    Console.WriteLine(product.ProductName);
                }
                Console.WriteLine();
            }
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
        static void Exercise21()
        {
            //groupby within foreach loop
            List<Customer> customers = DataLoader.LoadCustomers();
            var orderByYearMonth = customers
                .Select(c => new
                {
                    name = c.CompanyName,
                    orders = c.Orders

                });

            foreach (var name in orderByYearMonth)
            {
                Console.WriteLine(name.name);
                Console.WriteLine("==============================================================================");

                foreach (var order in name.orders)
                {
                    Console.WriteLine(order.OrderDate.Year);
                    Console.WriteLine($"\t{order.OrderDate.Month} - {order.Total}");
                    Console.WriteLine();

                }
            }
            //.Select(c => new
            //{
            //    name = c.CompanyName,
            //    order = c.Orders
            //})

            //.GroupBy(c => c.name);

            //.Select(g => new
            //{
            //    company = g.Key,
            //    order = g.OrderBy(c => c.Orders
            //    .OrderBy(o => o.OrderDate.Year)
            //    .ThenBy(o => o.OrderDate.Month))
            //}


            //PrintCustomerInformation(orderByYearMonth);
            //foreach (var c in orderByYearMonth)
            //{
            //    Console.WriteLine(c.name);
            //    Console.WriteLine("==============================================================================");
            //    foreach (var order in orderByYearMonth)
            //    {
            //        Console.WriteLine(order.year.ToString());
            //        //foreach(var month in orderByYearMonth)
            //        //{
            //        //    Console.WriteLine($"\t{month.month} - {month.total}");
            //        //}

            //        Console.WriteLine("==============================================================================");
            //        Console.WriteLine();
            //    }
            //}
        }

        /// <summary>
        /// Print the unique list of product categories
        /// </summary>
        static void Exercise22()
        {
            List<Product> products = DataLoader.LoadProducts();
            var categories = products.Select(product => product.Category).Distinct();
            foreach (var c in categories)
            {
                Console.WriteLine(c);
            }
        }

        /// <summary>
        /// Write code to check to see if Product 789 exists
        /// </summary>
        static void Exercise23()
        {
            List<Product> products = DataLoader.LoadProducts();
            var checkProd = products.Any(product => product.ProductID == 789);


            if (checkProd)
            {
                Console.WriteLine("Item exists");
            }
            else
            {
                Console.WriteLine("Item not found!");
            }
        }


        /// <summary>
        /// Print a list of categories that have at least one product out of stock
        /// </summary>
        static void Exercise24()
        {


            List<Product> products = DataLoader.LoadProducts();
            var categoryOOS = products.Where(p => p.UnitsInStock < 1)
                .Select(p => p.Category).Distinct();
            foreach (var c in categoryOOS)
            {
                Console.WriteLine(c);
            }
        }

        /// <summary>
        /// Print a list of categories that have no products out of stock
        /// </summary>
        static void Exercise25()
        {

            //group first then look at each
            List<Product> products = DataLoader.LoadProducts();
            var categoryInStock = products.GroupBy(p => p.Category)
                .Where(g => g.All(p => p.UnitsInStock > 0));
                
            //    .Select(p => new
            //{
            //    category = p.Category,
            //    inStock = p.UnitsInStock > 0
            //})
            //.All(i => i.inStock)
            //.OrderBy(i => i.category)
            
            //;

            foreach (var category in categoryInStock)
            {
                Console.WriteLine(category.Key);
            }
            

            //    prodInStock = p.UnitsInStock > 0
            //}).OrderBy(i => i.categoryName).Distinct();
            //    ;
                
            //foreach (var category in categoryInStock)
            //{
            //    Console.WriteLine(category);
            //}
        }

        /// <summary>
        /// Count the number of odd numbers in NumbersA
        /// </summary>
        static void Exercise26()
        {
            int[] numbers = DataLoader.NumbersA;
            var count = numbers.Count(n => n % 2 == 1);

            Console.WriteLine(count);
        }

        /// <summary>
        /// Create and print an anonymous type containing CustomerId and the count of their orders
        /// </summary>
        static void Exercise27()
        {
            List<Customer> customers = DataLoader.LoadCustomers();
            var idOrderCount = customers.Select(c => new
            {
                id = c.CustomerID,
                orders = c.Orders.Count()
            });
                

            //int count = 0;
            foreach (var i in idOrderCount)
            {

                Console.Write(i.id + ": ");
                Console.WriteLine(i.orders);
            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the count of the products they contain
        /// </summary>
        static void Exercise28()
        {
            //group products by category then count
            List<Product> products = DataLoader.LoadProducts();
            var categoryProdCount = products.GroupBy(p => p.Category)
                .Select(g => new
                {
                    category = g.Key,
                    prodCount = g.Sum(p => p.ProductID)
                });
                
            //    .Select(p => new
            //{
            //    category = p.Category,
            //    prodCount = p.ProductName.Count()
            //});

            foreach (var category in categoryProdCount)
            {
                Console.WriteLine(category.category);
                Console.WriteLine(category.prodCount);
            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the total units in stock
        /// </summary>
        static void Exercise29()
        {
            //group products then sum
            List<Product> products = DataLoader.LoadProducts();
            var prodCategoryTotal = products.GroupBy(p => p.Category)
                ;

            foreach (var cat in prodCategoryTotal)
            {
                Console.WriteLine(cat.Key);
                Console.WriteLine(cat.Sum(p => p.UnitsInStock));
            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the lowest priced product in that category
        /// </summary>
        static void Exercise30()
        {
            List<Product> products = DataLoader.LoadProducts();
            var lowPriceInCat = products
                .GroupBy(p => p.Category)

                .Select(g => new
                {
                    CategoryName = g.Key,
                    ProductName = g.OrderBy(p => p.UnitPrice).First().ProductName
                });

            foreach (var cat in lowPriceInCat)
            {
                Console.WriteLine(cat.CategoryName);
                Console.WriteLine(cat.ProductName);

            }
        }

        /// <summary>
        /// Print the top 3 categories by the average unit price of their products
        /// </summary>
        static void Exercise31()
        {
            List<Product> products = DataLoader.LoadProducts();
            var catByAvgPrice = products
                .GroupBy(p => p.Category)
                .Select(g => new
                {
                    CategoryName = g.Key,
                    AvgPrice = g.Average(p => p.UnitPrice)
                })
                .OrderByDescending(i => i.AvgPrice)
                .Take(3);

            foreach (var cat in catByAvgPrice)
            {
                Console.WriteLine(cat.CategoryName);
                Console.WriteLine(cat.AvgPrice);
            }
        }
    }
}
