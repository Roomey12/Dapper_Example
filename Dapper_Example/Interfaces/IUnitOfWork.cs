using Dapper_Example.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dapper_Example.Interfaces
{
    public interface IUnitOfWork
    {
        ICategoryRepository Categories { get; }
        IProductRepository Products { get; }
    }
}
