using FlooringOrderSystem.Models;
using System;

namespace FlooringOrderSystem.BLL.Helpers
{
    public class DisplayOrder 
    {
        public void Show(Order order)
        {
            Console.Write($" {order.OrderNumber}");
            Console.WriteLine($"\t\t{order.OrderDate.ToShortDateString()}");
            Console.WriteLine($" {order.CustomerName}");
            Console.WriteLine($" {order.State}");
            Console.WriteLine($" Product:\t{order.ProductType}");
            Console.WriteLine($" Area:\t\t{order.Area} sqft");
            Console.WriteLine($" Materials:\t{order.MaterialCost.ToString("c")}");
            Console.WriteLine($" Labor:\t\t{order.LaborCost.ToString("c")}");
            Console.WriteLine($" Tax:\t\t{order.Tax.ToString("c")}");
            Console.WriteLine($" Total:\t\t{order.Total.ToString("c")}");
            Console.WriteLine("==================================================");
            Console.WriteLine();
        }
    }
}
