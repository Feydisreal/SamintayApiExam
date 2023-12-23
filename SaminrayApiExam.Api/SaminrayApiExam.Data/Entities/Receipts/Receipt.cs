
using SaminrayApiExam.Data.Entities.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SaminrayApiExam.Data.Entities.Receipts
{
    public class Receipt
    {
        [Key]
        public int ReceiptId { get; set; }
        public DateTime ReceiptDate { get; set; }
        public int ProductRef { get; set; }
        public int ProductCount { get; set; }
        public float ProductPrice { get; set; }
        public float TotalPrice { get; set; }


        [ForeignKey("ProductRef")]
        [JsonIgnore]
        public virtual Product Product { get; set; } = null!;
    }
}
