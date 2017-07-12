using System;
using System.Collections.Generic;

namespace FlooringOrderSystem.Models.Interfaces
{
    public interface IOrderRepository
    {
        List<Order> LoadAllOrders(DateTime date);
        Order LoadOrder(DateTime date, int orderNumber);
        void SaveOrder(Order order, string date);
        void DeleteOrder(Order order, string date);
    }
}
