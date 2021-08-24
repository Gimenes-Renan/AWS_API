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
    public class BrandController : ControllerBase
    {
        private readonly DatabaseContext context;

        public BrandController(DatabaseContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Brand> Get()
        {
            return context.Brands.ToArray(); //não tem body, retorna lista completa (select * from tabela)
        }


        [HttpPost]
        public Brand Post([FromBody] Brand body)
        {
            var data = context.Add(body); //insert -> não precisa ID
            context.SaveChanges(); //commit;
            return data.Entity;
        }

        [HttpPut]
        public Brand Put([FromBody] Brand body)
        {
            var data = context.Update(body); //update -> precisa ter o ID
            context.SaveChanges();
            return data.Entity;
        }

        [HttpDelete]
        public bool Delete([FromBody] Brand body)
        {
            context.Remove(body); //Delete -> precisa ter SOMENTE o ID (outros parâmetros -> opcional)
            context.SaveChanges();
            return true;
        }

        [HttpDelete("[action]")]
        public bool DeleteById([FromQuery] int id)
        {
            context.Brands.Remove(new Brand() { BrandId = id });
            context.SaveChanges();
            return true;
        }
    }
}
