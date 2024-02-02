using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using InventoryORM.Data.Implementation;
using InventoryORM.Model;

namespace InventoryORM.Test
{
    [TestClass]
    public class ProductRepositoryIntegrationTest
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
        public void CreateProduct_ShouldInsertProductIntoDatabase()
        {
            var productRepository = new ProductRepository();
            var product = new Product
            {
                Id = 100,
                Name = "TestProduct",
                Description = "TestDescription",
                Weight = 10,
                Height = 5,
                Width = 3,
                Length = 7
            };

            productRepository.CreateProduct(product);

            var productsFromDatabase = productRepository.GetProducts(product.Id);
            Assert.AreEqual(1, productsFromDatabase.Count);
            Assert.AreEqual(product.Name, productsFromDatabase[0].Name);
        }

        [TestMethod]
        public void UpdateProduct_ShouldUpdateProductInDatabase()
        {
            var productRepository = new ProductRepository();
            var product = new Product
            {
                Id = 1,
                Name = "UpdatedProduct",
                Description = "New Description",
                Weight = 15,
                Height = 8,
                Width = 6,
                Length = 10
            };

            productRepository.UpdateProduct(product);

            var productsFromDatabase = productRepository.GetProducts(product.Id);
            Assert.AreEqual(1, productsFromDatabase.Count);
            Assert.AreEqual(product.Name, productsFromDatabase[0].Name);

        }

        [TestMethod]
        public void DeleteProduct_ShouldDeleteProductFromDatabase()
        {
            var productRepository = new ProductRepository();
            var productIdToDelete = 4;

            productRepository.DeleteProduct(productIdToDelete);

            var productsFromDatabase = productRepository.GetProducts(productIdToDelete);
            Assert.AreEqual(0, productsFromDatabase.Count);
        }
    }
}
