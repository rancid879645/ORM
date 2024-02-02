using System.Collections.Generic;
using System.Data;
using System.Linq;
using InventoryORM.Data.Interface;
using InventoryORM.Model;
using Dapper;
using Microsoft.Data.SqlClient;

namespace InventoryORM.Data.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connectionString = "Data Source=EPCOBOGW0669\\SQLEXPRESS;Initial Catalog=Inventory;Integrated Security=True;";

        public void CreateProduct(Product product)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute(
                    "InsertProduct",
                    new
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        Weight = product.Weight,
                        Height = product.Height,
                        Width = product.Width,
                        Length = product.Length
                    },
                    commandType: CommandType.StoredProcedure
                );
            }
        }

        public void UpdateProduct(Product product)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute(
                    "UpdateProduct",
                    new
                    {

                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        Weight = product.Weight,
                        Height = product.Height,
                        Width = product.Width,
                        Length = product.Length
                    },
                    commandType: CommandType.StoredProcedure
                    );
            }
        }

        public void DeleteProduct(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute(
                    "DeleteProduct",
                    new
                    {
                        ProductId = id
                    },
                    commandType: CommandType.StoredProcedure
                    );
            }
        }

        public List<Product> GetProducts(int? id = null)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var products = connection.Query<Product>(
                    "GetProducts",
                    new {ProductIt = id},
                    commandType:CommandType.StoredProcedure
                    ).ToList();
                return products;
            }
        }
    }
}
