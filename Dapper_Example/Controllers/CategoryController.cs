using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper_Example.Interfaces;
using Dapper_Example.Models;
using Dapper_Example.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dapper_Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        IUnitOfWork Database;

        public CategoryController(IUnitOfWork uow)
        {
            Database = uow;
        }

        // GET: api/Category
        [HttpGet]
        public IEnumerable<Category> GetAll()
        {
            return Database.Categories.GetAll();
        }

        // GET: api/Category/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var category = Database.Categories.Get(id);
            if(category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        // POST: api/Category
        [HttpPost]
        public void Post([FromBody] Category category)
        {
            Database.Categories.Create(category);
        }

        // PUT: api/Category
        [HttpPut]
        public void Put([FromBody] Category category)
        {
            Database.Categories.Update(category);
        }

        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category = Database.Categories.Get(id);
            if(category == null)
            {
                return NotFound();
            }
            Database.Categories.Delete(id);
            return Ok();
        }

        [HttpGet("popular")]
        public IActionResult GetCategoryWithMostProducts()
        {
            var category = Database.Categories.GetCategoryWithMostProducts();
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }
    }
}
