using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using InventoryORM.Data.Interface;
using InventoryORM.Model;
using Microsoft.Data.SqlClient;

namespace InventoryORM.Data.Implementation
{
    public class OrderRepository:IOrderRepository
    {
        private readonly string _connectionString = "Data Source=EPCOBOGW0669\\SQLEXPRESS;Initial Catalog=Inventory;Integrated Security=True;";

        public void CreateOrder(Order order)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute(
                    "InsertOrder",
                    new
                    {
                        Id = order.Id,
                        StatusId = order.StatusId,
                        CreatedDate = order.CreatedDate,
                        UpdatedDate = order.UpdatedDate,
                        ProductId = order.ProductId
                    },
                    commandType: CommandType.StoredProcedure
                );
            }
        }

        public void UpdateOrder(Order order)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute(
                    "UpdateOrder",
                    new
                    {
                        Id = order.Id,
                        StatusId = order.StatusId,
                        CreatedDate = order.CreatedDate,
                        UpdatedDate = order.UpdatedDate,
                        ProductId = order.ProductId
                    },
                    commandType: CommandType.StoredProcedure
                    );
            }
        }

        public void DeleteOrder(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute(
                    "DeleteOrder",
                    new
                    {
                        OrderId = id
                    },
                    commandType: CommandType.StoredProcedure
                    );
            }
        }

        public List<Order> GetOrders(FilterOrder filterOrder)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var parameters = new
                {
                    Month = filterOrder.Month,
                    Year = filterOrder.Year,
                    StatusId = filterOrder.StatusId,
                    ProductId = filterOrder.ProductId,
                    OrderId = filterOrder.OrderId
                };

                // Utilize Dapper to call the stored procedure
                var orders = connection.Query<Order>(
                    "GetOrders",
                    parameters,
                    commandType: CommandType.StoredProcedure
                ).ToList();

                return orders;
            }
        }
    }
}
