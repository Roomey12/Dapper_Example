using Dapper_Example.Models;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dapper_Example.Interfaces
{
    public interface IProductRepository
    {
        void Create(Product item);
        void Delete(int id);
        Product Get(int id);
        List<Product> GetAll();
        void Update(Product item);
        List<Product> GetProductsCheaperThanPrice(int price);
    }
}
