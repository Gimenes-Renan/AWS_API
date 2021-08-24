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
    public class CategoryController : ControllerBase
    {
        private readonly DatabaseContext context;

        public CategoryController(DatabaseContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return context.Categories.ToArray();
        }


        [HttpPost]
        public Category Post([FromBody] Category body)
        {
            var data = context.Add(body);
            context.SaveChanges();
            return data.Entity;
        }

        [HttpPut]
        public Category Put([FromBody] Category body)
        {
            var data = context.Update(body);
            context.SaveChanges();
            return data.Entity;
        }

        [HttpDelete]
        public bool Delete([FromBody] Category body)
        {
            context.Remove(body);
            context.SaveChanges();
            return true;
        }

        [HttpDelete("[action]")]
        public bool DeleteById([FromQuery] int id)
        {
            context.Categories.Remove(new Category() { CategoryId = id });
            context.SaveChanges();
            return true;
        }
    }
}
