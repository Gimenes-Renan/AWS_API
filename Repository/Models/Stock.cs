using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_AWS.Model
{
    [Table("Stock")]
    public class Stock
    {
        [Key]
        public Int32 StoreId { get; set; }
        public Int32 ProductId { get; set; }
        public Int32 Quantity { get; set; }
    }
}
