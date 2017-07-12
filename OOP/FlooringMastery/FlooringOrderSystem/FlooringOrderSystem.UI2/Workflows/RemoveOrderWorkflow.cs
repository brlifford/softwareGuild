using System;
using FlooringOrderSystem.BLL;
using FlooringOrderSystem.Models;
using FlooringOrderSystem.Models.Responses;
using FlooringOrderSystem.UI.Helpers;

namespace FlooringOrderSystem.UI.Workflows
{
    public class RemoveOrderWorkflow
    {
        public void Execute()
        {
            OrderManager _manager = OrderManagerFactory.Create();
            Order order = new Order();
            DisplayOrderToSave showOrder = new DisplayOrderToSave();
            Console.Clear();
            DateTime date = new DateTime();
            while (date  == DateTime.MinValue)
            {
                Console.Write("Enter the date for the order: ");
                DateTime.TryParse(Console.ReadLine(), out date);
            }
            


            Console.Write("Enter an order number: ");
            int.TryParse(Console.ReadLine(), out int orderNumber);

            OrderResponse response = _manager.RemoveOrder(date, orderNumber);

            if (response.Success)
            {
                showOrder.Show(response.Order);
                _manager.DeleteOrder(response.Order);
            }

            else
            {
                Console.WriteLine("An error has occurred.");
                Console.WriteLine(response.Message);
            }



            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
