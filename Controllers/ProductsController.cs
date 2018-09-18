using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyfirstApi.Data;
using MyfirstApi.Models;

namespace MyfirstApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductsController : Controller
    {
        ApplicationDbContext applicationDbContext;

        public ProductsController(ApplicationDbContext _applicationDbContext)
        {
            applicationDbContext = _applicationDbContext;
        }


        // GET: api/Products
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return applicationDbContext.Products;
        }


        // POST: api/Products
        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //applicationDbContext.Add<Product>(product);
            applicationDbContext.Add(product);
            applicationDbContext.SaveChanges();

            return CreatedAtAction("Get Products", new { id = product.Id }, product);

        }



        // PUT: api/Products
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Product product)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = applicationDbContext.Products.FirstOrDefault(productId => productId.Id == id);

            //If someone put a wrong Id

            if (result == null)
            {
                return BadRequest("No record found against this Id...");
            }


            //If record match this following line will b executed
            result.ProductName = product.ProductName;
            result.Price = product.Price;

            applicationDbContext.SaveChanges();


            return Ok("The Record has been updated...");
        }


        // DELETE: api/Products
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            var result = applicationDbContext.Products.Find(id);

            if (result == null)
            {
                return NotFound();
            }

            applicationDbContext.Products.Remove(result);
            applicationDbContext.SaveChanges();

            return Ok("The record has been deleted...");

        }





    }
}