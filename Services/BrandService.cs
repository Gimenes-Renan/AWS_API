using ReactCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_AWS.Model;

namespace AWS_API.Services
{
    public class BrandService
    {
        private readonly DatabaseContext context;

        public BrandService(DatabaseContext context)
        {
            this.context = context;
        }

        internal IEnumerable<Brand> Get()
        {
            return context.Brands.ToArray();
        }

        internal Brand Add(Brand body)
        {
            Brand b = new() { BrandName = body.BrandName };
            var data = context.Add(b);
            context.SaveChanges();
            return data.Entity;
        }

        internal Brand Put(Brand body)
        {
            var data = context.Update(body);
            context.SaveChanges();
            return data.Entity;
        }

        internal bool Delete(Brand body)
        {
            context.Remove(body);
            context.SaveChanges();
            return true;
        }

        internal bool Delete(int id)
        {
            context.Brands.Remove(new Brand() { BrandId = id });
            context.SaveChanges();
            return true;
        }
    }
}
