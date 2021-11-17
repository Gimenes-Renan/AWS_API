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
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService categoryService;

        public CategoryController(CategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return categoryService.Get();
        }

        [HttpGet("[action]")]
        public IEnumerable<Category> Search([FromQuery] string title)
        {
            if (!string.IsNullOrEmpty(title))
            {
                return categoryService.Get().Where(p => p.CategoryName.ToLower().Contains(title.ToLower()));
            }
            return categoryService.Get();
        }


        [HttpPost]
        public IActionResult Post([FromBody] Category body)
        {
            try
            {
                return Ok(categoryService.Add(body));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public Category Put([FromBody] Category body)
        {
            return categoryService.Put(body);
        }

        [HttpPut("{id:int}")]
        public Category Put([FromRoute] int id, [FromBody] Category body)
        {
            if (id == body.CategoryId)
            {
                return categoryService.Put(body);
            }
            return null;
        }

        [HttpDelete]
        public bool Delete([FromBody] Category body)
        {
            return categoryService.Delete(body);
        }

        [HttpDelete("{id:int}")]
        public bool Delete([FromRoute] int id)
        {
            return categoryService.Delete(id);
        }
    }
}
