using Dapper;
using Dapper_Example.Interfaces;
using Dapper_Example.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Dapper_Example.Repositories
{
    public class ProductRepository : IProductRepository
    {
        string _connectionString = null;
        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Create(Product product)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "INSERT INTO Products (Name, CategoryId, Price) VALUES (@Name, @CategoryId, @Price)";
                db.Execute(sqlQuery, product);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "DELETE FROM Products Where Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }

        public Product Get(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.QuerySingle<Product>("SELECT * FROM Products WHERE Id = @id", new { id });
            }
        }

        public List<Product> GetAll()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Product>("SELECT * FROM Products").ToList();
            }
        }

        public List<Product> GetProductsCheaperThanPrice(int price)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            return db.Query<Product>("SELECT * FROM Products Where Price < @price", new { price }).ToList();
        }

        public void Update(Product product)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "Update Products SET Name = @Name, CategoryId = @CategoryId, Price = @Price WHERE Id = @id";
                db.Execute(sqlQuery, product);
            }
        }
    }
}
