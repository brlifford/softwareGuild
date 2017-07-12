using FlooringOrderSystem.Models;
using FlooringOrderSystem.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FlooringOrderSystem.Data
{
    public class FileOrderRepository : IOrderRepository
    {
        public List<Order> Orders = new List<Order>();
        
        //string _directoryPath = Settings.LiveDirectoryPath;
        static int maxOrderNumber;

        public FileOrderRepository(string directoryPath)
        {
            DirectoryInfo directory = new DirectoryInfo(directoryPath);
            FileInfo[] _directoryFiles;
            

            _directoryFiles = directory.GetFiles("Orders_*.txt");
            foreach(var file in _directoryFiles)
            {
                string stringDate = file.Name.Substring(file.Name.Length - 12, 8);
                DateTime date = DateTime.Parse(stringDate.Substring(0,2) + "/" + stringDate.Substring(2,2) + "/" +
                    stringDate.Substring(4));
                maxOrderNumber += LoadAllOrders(date).Count;
                foreach(var order in LoadAllOrders(date))
                {
                    Orders.Add(order);
                }
                
            }
            
        }
        public List<Order> LoadAllOrders(DateTime date)
        {
            List<Order> _orderList = new List<Order>();
            string filePath = Settings.LiveDirectoryPath + "Orders_" + date.ToString("MMddyyyy") + ".txt";
            using (StreamReader sr = new StreamReader(filePath))
            {
                sr.ReadLine();
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    Order newOrder = new Order();
                    newOrder.OrderFileDate = filePath.Substring(filePath.Length - 12, 8);
                    newOrder.OrderDate = DateTime.Parse(newOrder.OrderFileDate.Substring(0, 2) + "/" +
                        newOrder.OrderFileDate.Substring(2, 2) + "/" + newOrder.OrderFileDate.Substring(4));

                    string[] columns = line.Split(',');

                    newOrder.OrderNumber = int.Parse(columns[0]);
                    newOrder.CustomerName = columns[1];
                    newOrder.State = columns[2];
                    newOrder.TaxRate = decimal.Parse(columns[3]);
                    newOrder.ProductType = columns[4];
                    newOrder.Area = decimal.Parse(columns[5]);
                    newOrder.CostPerSquareFoot = decimal.Parse(columns[6]);
                    newOrder.LaborCostPerSquareFoot = decimal.Parse(columns[7]);
                    newOrder.MaterialCost = decimal.Parse(columns[8]);
                    newOrder.LaborCost = decimal.Parse(columns[9]);
                    newOrder.Tax = decimal.Parse(columns[10]);
                    newOrder.Total = decimal.Parse(columns[11]);

                    _orderList.Add(newOrder);
                }
            }
            return _orderList;
        }

        public Order LoadOrder(DateTime date, int orderNumber)
        {
            
            Order foundOrder = Orders.Where(o => o.OrderDate == date)
                .SingleOrDefault(o => o.OrderNumber == orderNumber);
            return foundOrder;
        }

        public void SaveOrder(Order order, string date)
        {
            //List<Order> _newOrders = new List<Order>();

            //Orders.Add(order);
            
            maxOrderNumber = Orders.Count + 1;

            if (order.OrderNumber == 0)
            {
                order.OrderNumber = maxOrderNumber;
                Orders.Add(order);
            }

            //_newOrders.Add(order);
            string filePath = Settings.LiveDirectoryPath + $"Orders_{date}.txt";

            if (!File.Exists(filePath))
            {
                using (File.Create(filePath)) ;
            }
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.WriteLine("OrderNumber,CustomerName,State,TaxRate,ProductType,Area," +
                    "CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total");
                foreach (var ord in Orders.Where(o => o.OrderDate == order.OrderDate))
                {
                    string line = _createCsvForOrder(ord);
                    sw.WriteLine(line);
                }
            }
        }


        public void DeleteOrder(Order order, string date)
        {
            Orders.Remove(order);

            string filePath = Settings.LiveDirectoryPath + $"Orders_{date}.txt";
            int orderDateCount = Orders.Where(o => o.OrderDate == order.OrderDate).Count();

            if (orderDateCount > 0)
            {
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    sw.WriteLine("OrderNumber,CustomerName,State,TaxRate,ProductType,Area," +
                        "CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total");
                    foreach (var ord in Orders.Where(o => o.OrderDate == order.OrderDate))
                    {
                        string line = _createCsvForOrder(ord);
                        sw.WriteLine(line);
                    }
                }
            }

            else
            {
                File.Delete(filePath);
            }
            maxOrderNumber -= 1;
        }

        private string _createCsvForOrder(Order order)
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}",
                order.OrderNumber, order.CustomerName, order.State, order.TaxRate, order.ProductType,
                order.Area, order.CostPerSquareFoot, order.LaborCostPerSquareFoot, order.MaterialCost,
                order.LaborCost, order.Tax, order.Total);
        }
    }
}
