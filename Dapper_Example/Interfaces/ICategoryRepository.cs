using Dapper_Example.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dapper_Example.Interfaces
{
    public interface ICategoryRepository
    {
        void Create(Category item);
        void Delete(int id);
        Category Get(int id);
        List<Category> GetAll();
        void Update(Category item);
        Category GetCategoryWithMostProducts();
    }
}
