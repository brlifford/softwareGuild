using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderSystem.BLL.Helpers
{
    public class GetFromUser
    {
        public static DateTime GetDate()
        {
            DateTime date;
            
            do
            {
                Console.Write("Enter date of order: ");
                DateTime.TryParse(Console.ReadLine(), out date);
            } while (date == null);
            return date;
        }

        public static int GetOrderNum()
        {
            int orderNumber;
            do
            {
                Console.Write("Enter an order number: ");
                int.TryParse(Console.ReadLine(), out orderNumber);
            } while (orderNumber == 0);
            return orderNumber;
        }
    }
}
