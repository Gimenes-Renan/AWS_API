using AWS_API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReactCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_AWS.Model;

namespace WebAPI_AWS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        
        private readonly ProductService productService;

        public ProductController(ProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return productService.Get(); 
        }

        [HttpGet("{id:int}")]
        public Product Get([FromRoute] int id)
        {
            return  productService.Get().Where(p => p.ProductId == id).FirstOrDefault();
        }

        [HttpGet("[action]")]
        public IEnumerable<Product> Search([FromQuery] string title)
        {
            if (!string.IsNullOrEmpty(title))
            {
                return productService.Get().Where(p => p.ProductName.ToLower().Contains(title.ToLower()));

            }
            return productService.Get();
        }


        [HttpPost]
        public IActionResult Post([FromBody] Product body)
        {
            try
            {
                return Ok(productService.Add(body));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public Product Put([FromBody] Product body)
        {
            return productService.Put(body);
        }

        [HttpPut("{id:int}")]
        public Product Put([FromRoute] int id, [FromBody] Product body)
        {
            if (id == body.ProductId)
            {
                return productService.Put(body);
            }
            return null;
        }

        [HttpDelete]
        public bool Delete([FromBody] Product body)
        {
            return productService.Delete(body);
        }

        [HttpDelete("{id:int}")]
        public bool Delete([FromRoute] int id)
        {
            return productService.Delete(id);
        }
    }
}
