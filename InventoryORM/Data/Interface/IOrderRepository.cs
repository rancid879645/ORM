using InventoryORM.Model;
using System.Collections.Generic;

namespace InventoryORM.Data.Interface
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(FilterOrder filterOrder);
        List<Order> GetOrders(FilterOrder filterOrder);
    }
}
