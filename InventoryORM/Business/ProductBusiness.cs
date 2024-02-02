using InventoryORM.Data.Interface;
using InventoryORM.Model;
using System.Collections.Generic;
using System.Linq;

namespace InventoryORM.Business
{
    public class ProductBusiness
    {
        private readonly IProductRepository _productRepository;
        public ProductBusiness(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public List<Product> GetAllProducts()
        {
            return _productRepository.GetProducts();
        }

        public Product GetProductById(int id)
        {
            return _productRepository.GetProducts(id).FirstOrDefault();
        }

        public void UpdateProduct(Product product)
        {
            _productRepository.UpdateProduct(product);
        }

        public void DeleteProduct(int id)
        {
            _productRepository.DeleteProduct(id);
        }

        public void CreateProduct(Product product)
        {
            _productRepository.CreateProduct(product);
        }
    }
}
