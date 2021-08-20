using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_AWS.Model
{
    [Table("Brand")]
    public class Brand
    {
        [Key]
        public Int32 BrandId { get; set; }
        public string BrandName { get; set; }
    }
}
