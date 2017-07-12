using FlooringOrderSystem.BLL;
using FlooringOrderSystem.BLL.Helpers;
using FlooringOrderSystem.Models;
using FlooringOrderSystem.Models.Responses;
using FlooringOrderSystem.UI.Helpers;
using System;

namespace FlooringOrderSystem.UI.Workflows
{
    public class AddOrderWorkflow
    {
        public void Execute()
        {
            OrderManager _manager = OrderManagerFactory.Create();
            Order order = new Order();
            DisplayOrderToSave showOrder = new DisplayOrderToSave();
            Console.Clear();

            DateTime date = GetFromUser.GetDate();

            OrderResponse response = _manager.AddOrder(date);

            if (response.Success)
            {
                showOrder.Show(response.Order);
                _manager.SaveOrder(response.Order);

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
