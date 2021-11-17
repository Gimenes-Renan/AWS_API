using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_AWS.Model
{
    [Table("product")]
    public class Product
    {
        [Key]
        public Int32 ProductId { get; set; }
        public string ProductName { get; set; }
        public Int32 BrandId { get; set; }
        public Int32 CategoryId { get; set; }
        public Int32 Quantity { get; set; }
        public decimal ListPrice { get; set; }

        public Category Category { get; set; }
        public Brand Brand { get; set; }
    }
}
