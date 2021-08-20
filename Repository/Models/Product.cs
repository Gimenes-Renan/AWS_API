﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_AWS.Model
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public Int32 ProductId { get; set; }
        public string ProductName { get; set; }
        public Int32 BrandId { get; set; }
        public Int32 CategoryId { get; set; }
        public Int32 ModelYear { get; set; }
        public decimal ListPrice { get; set; }
    }
}
