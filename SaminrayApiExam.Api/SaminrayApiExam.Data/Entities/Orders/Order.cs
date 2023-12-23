using SaminrayApiExam.Data.Entities.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SaminrayApiExam.Data.Entities.Orders
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int ProductRef { get; set; }
        public int ProductCount { get; set; }
        public float ProductPrice { get; set; }


        [ForeignKey("ProductRef")]
        [JsonIgnore] 
        public virtual Product Product { get; set; } = null!;
    }
}
