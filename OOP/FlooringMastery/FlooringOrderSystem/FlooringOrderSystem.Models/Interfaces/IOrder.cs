using FlooringOrderSystem.Models.Responses;
using System;

namespace FlooringOrderSystem.Models.Interfaces
{
    public interface IOrder
    {
        OrderResponse Update(Order order, DateTime date);
    }
}
