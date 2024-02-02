using InventoryORM.Data.Implementation;
using InventoryORM.Model;
using System.Transactions;

namespace InventoryORM.Test
{
    [TestClass]
    public class OrderRepositoryIntegrationTests
    {
        private TransactionScope _transactionScope;

        [TestInitialize]
        public void TestInitialize()
        {
            _transactionScope = new TransactionScope();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _transactionScope.Dispose();
        }

        [TestMethod]
        public void CreateOrder_ShouldInsertOrderIntoDatabase()
        {
            var productRepository = new OrderRepository();
            var order = new Order
            {
                Id = 200,
                StatusId = 1,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                ProductId = 1
            };

            var filter = new FilterOrder
            {
                OrderId = order.Id
            };

            productRepository.CreateOrder(order);

            var productsFromDatabase = productRepository.GetOrders(filter);
            Assert.AreEqual(1, productsFromDatabase.Count);
            Assert.AreEqual(order.CreatedDate.ToString("d"), productsFromDatabase[0].CreatedDate.ToString("d"));
        }

        [TestMethod]
        public void UpdateOrder_ShouldUpdateOrderInDatabase()
        {
            var productRepository = new OrderRepository();
            var order = new Order
            {
                Id = 1,
                StatusId = 3,
                UpdatedDate = DateTime.Now,
                ProductId = 1
            };

            var filter = new FilterOrder
            {
                OrderId = order.Id
            };

            productRepository.UpdateOrder(order);

            var productsFromDatabase = productRepository.GetOrders(filter);
            Assert.AreEqual(1, productsFromDatabase.Count);
            Assert.AreEqual(order.UpdatedDate.ToString("d"), DateTime.Now.ToString("d"));

        }

        [TestMethod]
        public void DeleteOrder_ShouldDeleteOrderByProductIdFromDatabase()
        {
            var productRepository = new OrderRepository();
            var productIdToDelete = 3;
            var filter = new FilterOrder
            {
                ProductId = productIdToDelete
            };
            productRepository.DeleteOrder(filter);

            var productsFromDatabase = productRepository.GetOrders(filter);
            Assert.AreEqual(0, productsFromDatabase.Count);
        }

        [TestMethod]
        public void DeleteOrder_ShouldDeleteOrdersByStatus3FromDatabase()
        {
            var productRepository = new OrderRepository();
            var statusIdToDelete = 3;
            var filter = new FilterOrder
            {
                StatusId = statusIdToDelete
            };
            productRepository.DeleteOrder(filter);

            var productsFromDatabase = productRepository.GetOrders(filter);
            Assert.AreEqual(0, productsFromDatabase.Count);
        }

        [TestMethod]
        public void GetOrders_ShouldReturnAllOrdersWithStatus1FromDatabase()
        {
            var productRepository = new OrderRepository();
            var productIdToDelete = 3;
            var filter = new FilterOrder
            {
                StatusId = 1
            };

            var productsFromDatabase = productRepository.GetOrders(filter);
            Assert.AreEqual(1, productsFromDatabase.Count);
        }
    }
}