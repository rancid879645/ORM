using InventoryORM.Model;
using System.Collections.Generic;

namespace InventoryORM.Data.Interface
{
    public interface IProductRepository
    {
        void CreateProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
        List<Product> GetProducts(int? id = null);

    }
}
