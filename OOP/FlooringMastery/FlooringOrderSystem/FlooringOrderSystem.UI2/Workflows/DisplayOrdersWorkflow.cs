using FlooringOrderSystem.BLL;
using FlooringOrderSystem.BLL.Helpers;
using FlooringOrderSystem.Models.Responses;
using System;

namespace FlooringOrderSystem.UI.Workflows
{
    public class DisplayOrdersWorkflow
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();
            Console.Clear();

            DateTime date = GetFromUser.GetDate();
            //int orderNumber = GetFromUser.GetOrderNum();

            OrderLookupResponse response = manager.DisplayOrders(date);
            if(!response.Success)
            {                
                Console.WriteLine("An error occurred: ");
                Console.WriteLine(response.Message);
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
