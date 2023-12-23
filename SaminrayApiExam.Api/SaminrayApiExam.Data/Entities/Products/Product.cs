using SaminrayApiExam.Data.Entities.Receipts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SaminrayApiExam.Data.Entities.Products
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public int ProductGroupRef { get; set; }
        public float Price { get; set; }
        public DateTime ExpiryDate { get; set; }

        [ForeignKey("ProductGroupRef")]
        [JsonIgnore]
        public virtual ProductGroup ProductGroup { get; set; } = null!;


        [InverseProperty("Product")]
        [JsonIgnore]
        public virtual List<Receipt> Receipts { get; set; } = null!;
        [InverseProperty("Product")]
        [JsonIgnore]
        public virtual List<Orders.Order> Orders { get; set; } = null!;
    }
}
