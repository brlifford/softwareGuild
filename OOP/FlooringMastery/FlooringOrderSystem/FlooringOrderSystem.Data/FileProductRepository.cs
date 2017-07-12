using FlooringOrderSystem.Data;
using FlooringOrderSystem.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FlooringOrderSystem.Data
{
    public class FileProductRepository
    {
        List<Product> _products = new List<Product>();

        public FileProductRepository()
        {
            using (StreamReader sr = new StreamReader(Settings.ProdFilePath))
            {
                sr.ReadLine();
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Product product = new Product();

                    string[] columns = line.Split(',');

                    product.ProductType = columns[0];
                    product.CostPerSquareFoot = decimal.Parse(columns[1]);
                    product.LaborCostPerSquareFoot = decimal.Parse(columns[2]);

                    _products.Add(product);
                }
            }
        }

        public void DisplayProducts()
        {

            string format = "{0,-1}. {1,-20} {2,-6:c} {3,12:c}";
            int prodNum = 1;
            
            Console.WriteLine("   Product               PerSF  LaborPerSF");
            Console.WriteLine("------------------------------------------");
            foreach (var product in _products)
            {
                string line = string.Format(format, prodNum.ToString(), product.ProductType,
                    product.CostPerSquareFoot, product.LaborCostPerSquareFoot);
                Console.WriteLine(line);
                prodNum++;
            }
            Console.WriteLine();
        }

        public Product ChooseProduct()
        { 
            Console.Write("Please select an option from the list above: ");
            string input = Console.ReadLine();
            Product returnProduct = new Product();

            while(returnProduct.ProductType == null)
            {
                if (input.Length > 1)
                {
                    string stringProd = input.Substring(0, 1).ToUpper() + input.Substring(1);
                    if(_products.Any(p => p.ProductType == stringProd))
                    {
                        returnProduct = _products.SingleOrDefault(p => p.ProductType == stringProd);
                    }

                    else
                    {
                        Console.WriteLine("That is not a valid option!");
                        Console.Write("Please select an option from the list above: ");
                        input = Console.ReadLine();
                    }
                }
                else
                {
                    int.TryParse(input, out int numProd);
                    if(_products.Count < numProd)
                    {
                        returnProduct = _products.Skip(numProd - 1).First();
                    }
                    else
                    {
                        Console.WriteLine("That is not a valid option!");
                        Console.Write("Please select an option from the list above: ");
                        input = Console.ReadLine();
                    }
                }
            }

            return returnProduct;
        }
    }
}
