using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_AWS.Model
{
    [Table("category")]
    public class Category
    {
        [Key]
        public Int32 CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
