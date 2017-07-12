using System;
using System.Collections.Generic;
using FlooringOrderSystem.Models.Interfaces;
using FlooringOrderSystem.Models;

namespace FlooringOrderSystem.Data
{
    public class TestRepository : IOrderRepository
    {
        private static Order _order = new Order
        {
            OrderNumber = 12345,
            OrderDate = DateTime.Parse("12/25/2016"),
            CustomerName = "ABC Test, Inc.",
            State = "MN",
            ProductType = "Carpet",
            MaterialCost = 2.90M,
            LaborCost = 6.45M,
            Tax = 0.0725M,

        };
        
        public void DeleteOrder(Order order, string date)
        {
            throw new NotImplementedException();
        }

        
        public List<Order> LoadAllOrders(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Order LoadOrder(DateTime date, int OrderNumber)
        {
            if(OrderNumber != _order.OrderNumber)
            {
                return null;
            }
            return _order;
        }

        public void SaveOrder(Order order, string date)
        {
            _order = order;
        }
    }
}
