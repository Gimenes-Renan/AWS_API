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
    public class BrandController : ControllerBase
    {
        private readonly BrandService brandService;

        public BrandController(BrandService brandService)
        {
            this.brandService = brandService;
        }

        [HttpGet]
        public IEnumerable<Brand> Get()
        {
            return brandService.Get();
        }

        [HttpGet("{id:int}")]
        public Brand Get([FromRoute] int id)
        {
            return brandService.Get().Where(p => p.BrandId == id).FirstOrDefault();
        }

        [HttpGet("[action]")]
        public IEnumerable<Brand> Search([FromQuery] string title)
        {
            if (!string.IsNullOrEmpty(title))
            {
                return brandService.Get().Where(p => p.BrandName.ToLower().Contains(title.ToLower()));
            }
            return brandService.Get();
        }


        [HttpPost]
        public IActionResult Post([FromBody] Brand body)
        {
            try
            {
                return Ok(brandService.Add(body));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public Brand Put([FromBody] Brand body)
        {
            return brandService.Put(body);
        }

        [HttpPut("{id:int}")]
        public Brand Put([FromRoute] int id, [FromBody] Brand body)
        {
            if (id == body.BrandId)
            {
                return brandService.Put(body);
            }
            return null;
        }

        [HttpDelete]
        public bool Delete([FromBody] Brand body)
        {
            return brandService.Delete(body);
        }

        [HttpDelete("{id:int}")]
        public bool Delete([FromRoute] int id)
        {
            return brandService.Delete(id);
        }
    }
}
