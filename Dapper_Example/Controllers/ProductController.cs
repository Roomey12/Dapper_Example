using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper_Example.Interfaces;
using Dapper_Example.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dapper_Example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IUnitOfWork Database;

        public ProductController(IUnitOfWork uow)
        {
            Database = uow;
        }

        // GET: api/Product
        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            return Database.Products.GetAll();
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = Database.Products.Get(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // POST: api/Product
        [HttpPost]
        public void Post([FromBody] Product product)
        {
            Database.Products.Create(product);
        }

        // PUT: api/Product
        [HttpPut]
        public void Put([FromBody] Product product)
        {
            Database.Products.Update(product);
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = Database.Products.Get(id);
            if (product == null)
            {
                return NotFound();
            }
            Database.Products.Delete(id);
            return Ok();
        }

        [HttpGet("cheaper/{price}")]
        public IActionResult GetProductCheaperThanPrice(int price)
        {
            return Ok(Database.Products.GetProductsCheaperThanPrice(price));
        }
    }
}
