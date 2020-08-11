using Dapper_Example.Interfaces;
using Dapper_Example.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dapper_Example.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        string _connectionString;
        CategoryRepository _categoryRepository;
        ProductRepository _productRepository;

        public UnitOfWork(string connectionString)
        {
            _connectionString = connectionString;
        }
        public ICategoryRepository Categories
        {
            get
            {
                if(_categoryRepository == null)
                {
                    _categoryRepository = new CategoryRepository(_connectionString);
                }
                return _categoryRepository;
            }
        }

        public IProductRepository Products 
        {
            get
            {
                if (_productRepository == null)
                {
                    _productRepository = new ProductRepository(_connectionString);
                }
                return _productRepository;
            }
        }
    }
}
