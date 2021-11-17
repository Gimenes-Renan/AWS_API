using ReactCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_AWS.Model;

namespace AWS_API.Services
{
    public class CategoryService
    {
        private readonly DatabaseContext context;

        public CategoryService(DatabaseContext context)
        {
            this.context = context;
        }

        internal IEnumerable<Category> Get()
        {
            return context.Categories.ToArray();
        }

        internal Category Add(Category body)
        {
            Category c = new() { CategoryName = body.CategoryName };
            var data = context.Add(c);
            context.SaveChanges();
            return data.Entity;
        }

        internal Category Put(Category body)
        {
            var data = context.Update(body);
            context.SaveChanges();
            return data.Entity;
        }

        internal bool Delete(Category body)
        {
            context.Remove(body);
            context.SaveChanges();
            return true;
        }

        internal bool Delete(int id)
        {
            context.Categories.Remove(new Category() { CategoryId = id });
            context.SaveChanges();
            return true;
        }
    }
}
