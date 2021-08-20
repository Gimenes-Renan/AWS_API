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
        private readonly DatabaseContext context;

        public ProductController(DatabaseContext context)
        {
            this.context = context; ;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return context.Products.ToArray();
        }


        [HttpPost]
        public Product Post([FromBody] Product body)
        {
            var data = context.Add(body);
            context.SaveChanges();
            return data.Entity;
        }

        [HttpPut]
        public Product Put([FromBody] Product body)
        {
            var data = context.Update(body);
            context.SaveChanges();
            return data.Entity;
        }

        [HttpDelete]
        public bool Delete([FromBody] Product body)
        {
            context.Remove(body);
            context.SaveChanges();
            return true;
        }
    }
}
