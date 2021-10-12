using GraphQL.Interfaces;
using GraphQL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GraphQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProduct productService { get; set; }

        public ProductsController(IProduct productService)
        {
            this.productService = productService;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return productService.GetAllProducts();
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return productService.GetProductById(id);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public Product Post([FromBody] Product product)
        {
            return productService.AddProduct(product);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public Product Put(int id, [FromBody] Product product)
        {
            return productService.UpdateProduct(id,product);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            productService.DeleteProduct(id);
        }
    }
}
