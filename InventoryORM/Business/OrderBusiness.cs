using InventoryORM.Data.Interface;
using InventoryORM.Model;
using System.Collections.Generic;
using System.Linq;

namespace InventoryORM.Business
{
    public class OrderBusiness
    {
        private readonly IOrderRepository _orderRepository;
        public OrderBusiness(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public List<Order> GetAllorders()
        {
            var filter = new FilterOrder();
            return _orderRepository.GetOrders(filter);
        }

        public Order GetorderByParams(FilterOrder filterOrder)
        {
            return _orderRepository.GetOrders(filterOrder).FirstOrDefault();
        }

        public void Updateorder(Order order)
        {
            _orderRepository.UpdateOrder(order);
        }

        public void Deleteorder(FilterOrder filterOrder)
        {
            _orderRepository.DeleteOrder(filterOrder);
        }

        public void Createorder(Order order)
        {
            _orderRepository.CreateOrder(order);
        }
    }
}
