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
    public class CategoryRepository : ICategoryRepository
    {
        string _connectionString;
        public CategoryRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Create(Category category)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "INSERT INTO Categories (Name) VALUES (@Name)";
                db.Execute(sqlQuery, category);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "DELETE FROM Categories Where Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }

        public Category Get(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.QuerySingle<Category>("SELECT * FROM Categories WHERE Id = @id", new { id });
            }
        }

        public List<Category> GetAll()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Category>("SELECT * FROM Categories").ToList();
            }
        }

        public Category GetCategoryWithMostProducts()
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            return db.QuerySingle<Category>("SELECT TOP 1 c.Name, c.Id, count(p.CategoryId) as CountOfProducts FROM Categories c " +
                                            "JOIN Products p on c.Id = p.CategoryId " +
                                            "Group by c.Name, c.Id " +
                                            "order by CountOfProducts desc");
        }

        public void Update(Category category)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "Update Categories SET Name = @Name WHERE Id = @id";
                db.Execute(sqlQuery, category);
            }
        }
    }
}
