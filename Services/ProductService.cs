using ReactCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_AWS.Model;

namespace AWS_API.Services
{
    public class ProductService
    {
        private readonly DatabaseContext context;

        public ProductService(DatabaseContext context)
        {
            this.context = context;
        }

        internal IEnumerable<Product> Get()
        {
            var query = from product in context.Products
                        join category in context.Categories on product.CategoryId equals category.CategoryId
                        join brand in context.Brands on product.BrandId equals brand.BrandId
                        select new Product                       {
                            ProductId = product.ProductId,
                            BrandId = product.BrandId,
                            CategoryId = product.CategoryId,
                            ListPrice = product.ListPrice,
                            Quantity = product.Quantity,
                            ProductName = product.ProductName,
                            Category = category,
                            Brand = brand
                        };
            return query.ToArray();
        }

        internal Product Add(Product body)
        {
            if (!context.Categories.Any(c => c.CategoryId == body.CategoryId))
                throw new InvalidOperationException("Essa categoria não existe");

            var data = context.Add(body);
            context.SaveChanges();
            return data.Entity;
        }

        internal Product Put(Product body)
        {
            var data = context.Update(body);
            context.SaveChanges();
            return data.Entity;
        }

        internal bool Delete(Product body)
        {
            context.Remove(body);
            context.SaveChanges();
            return true;
        }

        internal bool Delete(int id)
        {
            context.Products.Remove(new Product() { ProductId = id });
            context.SaveChanges();
            return true;
        }
    }
}
